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
    public class SQLSaatDal : VeriTabani, ISaatDal
    {
        public void Ekle(Saat veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText
                = "insert into Saatler values(@Saat)";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Saat", veri.saat);

            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Saat Getir(int id)
        {
            Saat saat = new Saat();
            saat.SaatId = id;
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText
                = "Select * from Saatler where SaatId=@SaatId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@SaatId", id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                //saat.saat = Convert.ToDateTime(sqlDataReader["Saat"]);
                //saat.saat = new TimeSpan((TimeSpan)sqlDataReader["Saat"]);
                saat.saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString());
                
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return saat;
        }

        public void Guncelle(Saat veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Update Saatler set Saat=@Saat where SaatId=@SaatId";
            _sqlCommand = new SqlCommand(commandText,_sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@SaatId",veri.SaatId);
            _sqlCommand.Parameters.AddWithValue("@Saat",veri.saat);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<Saat> HepsiniGetir()
        {
            List<Saat> saatler = new List<Saat>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commanText = "Select * from Saatler";
            _sqlCommand = new SqlCommand(commanText, _sqlConnection);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                saatler.Add(new Saat { 
                SaatId = Convert.ToInt32(sqlDataReader["SaatId"]),
                saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                });
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return saatler;
        }

        public void Sil(int id)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commanText = "Delete from Saatler where SaatId=@SaatId";
            _sqlCommand = new SqlCommand(commanText,_sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@SaatId",id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

        }
    }
}
