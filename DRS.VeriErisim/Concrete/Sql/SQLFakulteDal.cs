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
    public class SQLFakulteDal : VeriTabani,IFakulteDal
    {
        public void Ekle(Fakulte veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Insert into Fakulteler values(@FakulteAd)";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@FakulteAd", veri.FakulteAd);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Fakulte Getir(int id)
        {
            Fakulte fakulte = new Fakulte();
            fakulte.FakulteId = id;
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Select * from Fakulteler where FakulteId=@FakulteId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                fakulte.FakulteAd = sqlDataReader["FakulteAd"].ToString();
                fakulte.FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"]);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return fakulte;
        }

        public void Guncelle(Fakulte veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Update Fakulteler set FakulteAd=@FakulteAd where FakulteId=@FakulteId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", veri.FakulteId);
            _sqlCommand.Parameters.AddWithValue("@FakulteAd", veri.FakulteAd);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<Fakulte> HepsiniGetir()
        {
            List<Fakulte> fakulteler = new List<Fakulte>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Select * from Fakulteler";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                fakulteler.Add(new Fakulte
                {
                    FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"]),
                    FakulteAd = sqlDataReader["FakulteAd"].ToString()
                });
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return fakulteler;
        }

        public void Sil(int id)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "exec spFakulteSil @FakulteId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
