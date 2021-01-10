using DRS.VeriErisim.Abstract;
using DRS.VeriErisim.Abstracts;
using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.VeriErisim.Concrete.Sql
{
    public class SQLMusaitlikDal : VeriTabani, IMusaitlikDal
    {
        public void Ekle(Musaitlik veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Insert into Müsaitlikler values(@Tarih,@SaatId,@AkmId)";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Tarih", veri.Tarih);
            _sqlCommand.Parameters.AddWithValue("@SaatId", veri.Saat.SaatId);
            _sqlCommand.Parameters.AddWithValue("@AkmId", veri.Akademisyen.AkmId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Musaitlik Getir(int id)
        {
            Musaitlik musaitlik = new Musaitlik();
            musaitlik.Id = id;
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "exec spMusaitlikGetir @Id";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Id", id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                musaitlik.Akademisyen = new Akademisyen { AkmId = Convert.ToInt32(sqlDataReader["AkmId"]) };
                musaitlik.Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]);
                musaitlik.Saat = new Saat
                {
                    SaatId = Convert.ToInt32(sqlDataReader["SaatId"]),
                    saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                };
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return musaitlik;
        }

        public void Guncelle(Musaitlik veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Update Musaitlikler set Tarih=@Tarih, SaatId=@SaatId where Id=@Id";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Tarih", veri.Tarih);
            _sqlCommand.Parameters.AddWithValue("@SaatId", veri.Saat.SaatId);
            _sqlCommand.Parameters.AddWithValue("@Id", veri.Id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<Musaitlik> HepsiniGetir(int akademisyenId)
        {
            List<Musaitlik> musaitlikler = new List<Musaitlik>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "exec spMusaitlikGetirTumu @AkmId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@AkmId", akademisyenId);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Musaitlik musaitlik = new Musaitlik
                {
                    Akademisyen = new Akademisyen { AkmId = akademisyenId },
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]),
                    Saat = new Saat
                    {
                        SaatId = Convert.ToInt32(sqlDataReader["SaatId"]),
                        saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                    }

                };
                musaitlikler.Add(musaitlik);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return musaitlikler;
        }

        public void Sil(int id)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Delete from Müsaitlikler where Id=@Id";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Id", id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
