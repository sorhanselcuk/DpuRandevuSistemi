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
    public class SQLGecmisRandevuDal : VeriTabani, IGecmisRandevuDal
    {
        public GecmisRandevu GecmisRandevuGetir(int id)
        {
            GecmisRandevu gecmisRandevu = new GecmisRandevu();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spGecmisRandevuGetir @Id";
            _sqlCommand = new SqlCommand(commandText,_sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Id",id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                gecmisRandevu.Id = Convert.ToInt32(sqlDataReader["Id"]);
                gecmisRandevu.Akademisyen = new Akademisyen {
                    AkmId = Convert.ToInt32(sqlDataReader["AkmId"]),
                    Ad = sqlDataReader["AkmAd"].ToString(),
                    Soyad = sqlDataReader["AkmSoyad"].ToString(),
                    EPosta = sqlDataReader["AkmEPosta"].ToString(),
                    Fakulte = new Fakulte
                    {
                        FakulteId = Convert.ToInt32(sqlDataReader["AkmFakulteId"]),
                        FakulteAd = sqlDataReader["AkmFakulteAd"].ToString()
                    },
                    Bolum = new Bolum
                    {
                        BolumId = Convert.ToInt32(sqlDataReader["AkmBolumId"]),
                        BolumAd = sqlDataReader["AkmBolumAd"].ToString()
                    }
                };
                gecmisRandevu.Ogrenci = new Ogrenci {
                    OgrId = Convert.ToInt32(sqlDataReader["OgrId"]),
                    OgrNo = sqlDataReader["OgrNo"].ToString(),
                    Ad = sqlDataReader["OgrAd"].ToString(),
                    Soyad = sqlDataReader["OgrSoyad"].ToString(),
                    EPosta = sqlDataReader["OgrEPosta"].ToString(),
                    Fakulte = new Fakulte
                    {
                        FakulteId = Convert.ToInt32(sqlDataReader["OgrFakulteId"]),
                        FakulteAd = sqlDataReader["OgrFakulteAd"].ToString()
                    },
                    Bolum = new Bolum
                    {
                        BolumId = Convert.ToInt32(sqlDataReader["OgrBolumId"]),
                        BolumAd = sqlDataReader["OgrBolumAd"].ToString()
                    }
                };
                gecmisRandevu.Konu = sqlDataReader["Konu"].ToString();
                gecmisRandevu.Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]);
                gecmisRandevu.Saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString());
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return gecmisRandevu;
        }

        public List<GecmisRandevu> AkademisyenGecmisRandevuHepsiniGetir(int akademisyenId)
        {
            List<GecmisRandevu> gecmisRandevular = new List<GecmisRandevu>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spAkademisyenGecmisRandevuHepsiniGetir @AkmId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@AkmId",akademisyenId);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                gecmisRandevular.Add(new GecmisRandevu
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Akademisyen = new Akademisyen
                    {
                        AkmId = Convert.ToInt32(sqlDataReader["AkmId"]),
                        Ad = sqlDataReader["AkmAd"].ToString(),
                        Soyad = sqlDataReader["AkmSoyad"].ToString(),
                        EPosta = sqlDataReader["AkmEPosta"].ToString(),
                        Fakulte = new Fakulte
                        {
                            FakulteId = Convert.ToInt32(sqlDataReader["AkmFakulteId"]),
                            FakulteAd = sqlDataReader["AkmFakulteAd"].ToString()
                        },
                        Bolum = new Bolum
                        {
                            BolumId = Convert.ToInt32(sqlDataReader["AkmBolumId"]),
                            BolumAd = sqlDataReader["AkmBolumAd"].ToString()
                        }
                    },
                    Ogrenci = new Ogrenci
                    {
                        OgrId = Convert.ToInt32(sqlDataReader["OgrId"]),
                        OgrNo = sqlDataReader["OgrNo"].ToString(),
                        Ad = sqlDataReader["OgrAd"].ToString(),
                        Soyad = sqlDataReader["OgrSoyad"].ToString(),
                        EPosta = sqlDataReader["OgrEPosta"].ToString(),
                        Fakulte = new Fakulte
                        {
                            FakulteId = Convert.ToInt32(sqlDataReader["OgrFakulteId"]),
                            FakulteAd = sqlDataReader["OgrFakulteAd"].ToString()
                        },
                        Bolum = new Bolum
                        {
                            BolumId = Convert.ToInt32(sqlDataReader["OgrBolumId"]),
                            BolumAd = sqlDataReader["OgrBolumAd"].ToString()
                        }
                    },
                    Konu = sqlDataReader["Konu"].ToString(),
                    Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]),
                    Saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                });
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return gecmisRandevular;
        }

        public List<GecmisRandevu> OgrenciGecmisRandevuHepsiniGetir(int ogrenciId)
        {
            List<GecmisRandevu> gecmisRandevular = new List<GecmisRandevu>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spOgrenciGecmisRandevuHepsiniGetir @OgrId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@OgrId",ogrenciId);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                gecmisRandevular.Add(new GecmisRandevu {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                Akademisyen = new Akademisyen
                {
                    AkmId = Convert.ToInt32(sqlDataReader["AkmId"]),
                    Ad = sqlDataReader["AkmAd"].ToString(),
                    Soyad = sqlDataReader["AkmSoyad"].ToString(),
                    EPosta = sqlDataReader["AkmEPosta"].ToString(),
                    Fakulte = new Fakulte
                    {
                        FakulteId = Convert.ToInt32(sqlDataReader["AkmFakulteId"]),
                        FakulteAd = sqlDataReader["AkmFakulteAd"].ToString()
                    },
                    Bolum = new Bolum
                    {
                        BolumId = Convert.ToInt32(sqlDataReader["AkmBolumId"]),
                        BolumAd = sqlDataReader["AkmBolumAd"].ToString()
                    }
                },
                Ogrenci = new Ogrenci
                {
                    OgrId = Convert.ToInt32(sqlDataReader["OgrId"]),
                    OgrNo = sqlDataReader["OgrNo"].ToString(),
                    Ad = sqlDataReader["OgrAd"].ToString(),
                    Soyad = sqlDataReader["OgrSoyad"].ToString(),
                    EPosta = sqlDataReader["OgrEPosta"].ToString(),
                    Fakulte = new Fakulte
                    {
                        FakulteId = Convert.ToInt32(sqlDataReader["OgrFakulteId"]),
                        FakulteAd = sqlDataReader["OgrFakulteAd"].ToString()
                    },
                    Bolum = new Bolum
                    {
                        BolumId = Convert.ToInt32(sqlDataReader["OgrBolumId"]),
                        BolumAd = sqlDataReader["OgrBolumAd"].ToString()
                    }
                },
                Konu = sqlDataReader["Konu"].ToString(),
                Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]),
                Saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
            });
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return gecmisRandevular;
        }
    }
}
