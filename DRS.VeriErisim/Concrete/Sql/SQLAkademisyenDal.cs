using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.VeriErisim.Abstracts;
using DRS.Veriler.Concrete;

namespace DRS.VeriErisim.Concrete.Sql
{
    public class SQLAkademisyenDal : VeriTabani, IAkademisyenDal
    {
        public void Ekle(Akademisyen veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText
                = "insert Akademisyenler values(@EPosta,@Ad,@Soyad,@FakulteId,@BolumId,@Parola)";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@EPosta", veri.EPosta);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", veri.Fakulte.FakulteId);
            _sqlCommand.Parameters.AddWithValue("@BolumId", veri.Bolum.BolumId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Akademisyen Getir(int id)
        {
            Akademisyen akademisyen = new Akademisyen();
            akademisyen.AkmId = id;
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spAkademisyenGetir @AkmId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@AkmId", id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                akademisyen.EPosta = sqlDataReader["EPosta"].ToString();
                akademisyen.Ad = sqlDataReader["Ad"].ToString();
                akademisyen.Soyad = sqlDataReader["Soyad"].ToString();
                akademisyen.Fakulte = new Fakulte
                {
                    FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"]),
                    FakulteAd = sqlDataReader["FakulteAd"].ToString()
                };
                akademisyen.Bolum = new Bolum
                {
                    BolumId = Convert.ToInt32(sqlDataReader["BolumId"]),
                    BolumAd = sqlDataReader["BolumAd"].ToString()
                };
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return akademisyen;
        }

        public void Guncelle(Akademisyen veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Update Akademisyenler set EPosta=@EPosta,Parola=@Parola" +
                ",Ad=@Ad,Soyad=@Soyad,FakulteId=@FakulteId,BolumId=@BolumId where AkmId=@AkmId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@AkmId", veri.AkmId);
            _sqlCommand.Parameters.AddWithValue("@EPosta", veri.EPosta);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", veri.Fakulte.FakulteId);
            _sqlCommand.Parameters.AddWithValue("@BolumId", veri.Bolum.BolumId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<Akademisyen> HepsiniGetir()
        {
            List<Akademisyen> akademisyenler = new List<Akademisyen>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spAkademisyenGetirTumu";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                akademisyenler.Add(new Akademisyen { 
                AkmId = Convert.ToInt32(sqlDataReader["AkmId"]),
                EPosta = sqlDataReader["EPosta"].ToString(),
                Ad = sqlDataReader["Ad"].ToString(),
                Soyad = sqlDataReader["Soyad"].ToString(),
                Fakulte = new Fakulte
                {
                    FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"]),
                    FakulteAd = sqlDataReader["FakulteAd"].ToString()
                },
                Bolum = new Bolum 
                {
                    BolumId = Convert.ToInt32(sqlDataReader["BolumId"]),
                    BolumAd = sqlDataReader["BolumAd"].ToString()
                }

                });
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return akademisyenler;
        }

        public void Sil(int id)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText= "Exec spAkademisyenSil @Id";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Id", id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        
    }
}
