using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.VeriErisim.Abstracts;
using DRS.Veriler.Concrete;

namespace DRS.VeriErisim.Concrete.Sql
{
    public class SQLOgrenciDal : VeriTabani,IOgrenciDal
    {
        public void Ekle(Ogrenci veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText
                = "insert Ogrenciler values(@OgrNo,@EPosta,@Parola,@Ad,@Soyad,@FakulteId,@BolumId)";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@OgrNo", veri.OgrNo);
            _sqlCommand.Parameters.AddWithValue("@EPosta", veri.EPosta);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", veri.Fakulte.FakulteId);
            _sqlCommand.Parameters.AddWithValue("@BolumId", veri.Bolum.BolumId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Ogrenci Getir(int id)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.OgrId = id;
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spOgrenciGetir @OgrId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@OgrId", id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ogrenci.OgrNo = sqlDataReader["OgrNo"].ToString();
                ogrenci.EPosta = sqlDataReader["EPosta"].ToString();
                ogrenci.Ad = sqlDataReader["Ad"].ToString();
                ogrenci.Soyad = sqlDataReader["Soyad"].ToString();
                ogrenci.Fakulte = new Fakulte
                {
                    FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"]),
                    FakulteAd = sqlDataReader["FakulteAd"].ToString()
                };
                ogrenci.Bolum = new Bolum
                {
                    BolumId = Convert.ToInt32(sqlDataReader["BolumId"]),
                    BolumAd = sqlDataReader["BolumAd"].ToString(),
                    FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"])

                };
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return ogrenci;
        }

        public void Guncelle(Ogrenci veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Update Ogrenciler set OgrNo=@OgrNo,EPosta=@EPosta,Parola=@Parola" +
                ",Ad=@Ad,Soyad=@Soyad,FakulteId=@FakulteId,BolumId=@BolumId where OgrId=@OgrId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@OgrId", veri.OgrId);
            _sqlCommand.Parameters.AddWithValue("@OgrNo", veri.OgrNo);
            _sqlCommand.Parameters.AddWithValue("@EPosta", veri.EPosta);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", veri.Fakulte.FakulteId);
            _sqlCommand.Parameters.AddWithValue("@BolumId", veri.Bolum.BolumId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<Ogrenci> HepsiniGetir()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spOgrenciGetirTumu";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ogrenciler.Add(new Ogrenci
                {
                    OgrNo = sqlDataReader["OgrNo"].ToString(),
                    OgrId = Convert.ToInt32(sqlDataReader["OgrId"]),
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
            return ogrenciler;
        }

        public void Sil(int id)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spOgrenciSil @Id";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Id", id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
