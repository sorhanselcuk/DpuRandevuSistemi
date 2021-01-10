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
    public class SQLAkademisyenGirisDal : VeriTabani, IAkademisyenGirisDal
    {
        public bool GirisYap(GirisBilgileri girisBilgileri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Select * from Akademisyenler where EPosta=@EPosta and Parola=@Parola";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@EPosta", girisBilgileri.KullaniciAdi);
            _sqlCommand.Parameters.AddWithValue("@Parola", girisBilgileri.Parola);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                    girisBilgileri.KullaniciId = Convert.ToInt32(sqlDataReader["AkmId"].ToString());
                sqlDataReader.Close();
                _sqlConnection.Close();
                return true;
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return false;
        }
    }
}
