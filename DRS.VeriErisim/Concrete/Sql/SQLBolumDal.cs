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
    public class SQLBolumDal : VeriTabani, IBolumDal
    {
        public void Ekle(Bolum veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Insert into Bolumler values(@BolumAd,@FakulteId)";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@BolumAd", veri.BolumAd);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", veri.FakulteId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Bolum Getir(int id)
        {
            Bolum bolum = new Bolum();
            bolum.BolumId = id;
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Select * from Bolumler where BolumId=@BolumId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@BolumId", id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                bolum.BolumAd = sqlDataReader["BolumAd"].ToString();
                bolum.FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"]);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return bolum;
        }

        public void Guncelle(Bolum veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Update Bolumler set BolumAd=@BolumAd, FakulteId=@FakulteId where BolumId=@BolumId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@BolumId", veri.BolumId);
            _sqlCommand.Parameters.AddWithValue("@BolumAd", veri.BolumAd);
            _sqlCommand.Parameters.AddWithValue("@FakulteId", veri.FakulteId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<Bolum> HepsiniGetir()
        {
            List<Bolum> bolumler = new List<Bolum>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Select * from Bolumler";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                bolumler.Add(new Bolum { 
                    BolumId = Convert.ToInt32(sqlDataReader["BolumId"]),
                    BolumAd = sqlDataReader["BolumAd"].ToString(),
                    FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"])
            });
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return bolumler;
        }

        public List<Bolum> HepsiniGetir(int fakulteId)
        {
            List<Bolum> bolumler = new List<Bolum>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Select * from Bolumler where FakulteId=@FakulteId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@FakulteId",fakulteId);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                bolumler.Add(new Bolum
                {
                    BolumId = Convert.ToInt32(sqlDataReader["BolumId"]),
                    BolumAd = sqlDataReader["BolumAd"].ToString(),
                    FakulteId = Convert.ToInt32(sqlDataReader["FakulteId"])
                });
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return bolumler;
        }

        public void Sil(int id)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "exec spBolumSil @BolumId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@BolumId", id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
