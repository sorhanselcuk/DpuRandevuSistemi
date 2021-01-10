using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.VeriErisim.Abstracts
{
   public abstract class VeriTabani
    {
        protected string _yol = @"Data Source=CASPERNIRVANA\SQLEXPRESS;Initial Catalog = RandevuSistemi; Integrated Security = True";
        protected SqlConnection _sqlConnection;
        protected SqlCommand _sqlCommand;
        protected void BaglantiAc()
        {
            if (_sqlConnection.State == ConnectionState.Closed)
                _sqlConnection.Open();
        }
    }
}
