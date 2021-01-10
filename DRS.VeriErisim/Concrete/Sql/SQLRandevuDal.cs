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
    public class SQLRandevuDal : VeriTabani, IRandevuDal
    {
        public List<Randevu> AkademisyenRandevulariniGetir(int akademisyenId)
        {
            List<Randevu> randevular = new List<Randevu>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spRandevuGetirAkademisyen @AkmId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@AkmId", akademisyenId);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Randevu randevu = new Randevu();
                randevu.RandevuId = Convert.ToInt32(sqlDataReader["RandevuId"]);
                randevu.Akademisyen = new Akademisyen
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
                };
                randevu.Ogrenci = new Ogrenci
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
                };
                randevu.AktifMi = Convert.ToBoolean(sqlDataReader["AktifMi"]);
                randevu.Konu = sqlDataReader["Konu"].ToString();
                randevu.Saat = new Saat
                {
                    SaatId = Convert.ToInt32(sqlDataReader["SaatId"]),
                    saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                };
                randevu.Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]);
                randevular.Add(randevu);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return randevular;
        }

        public void Ekle(Randevu veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText
                = "insert into Randevu values(@AkmId,@OgrId,@Konu,@Tarih,@SaatId,@AktifMi)";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@AkmId", veri.Akademisyen.AkmId);
            _sqlCommand.Parameters.AddWithValue("@OgrId", veri.Ogrenci.OgrId);
            _sqlCommand.Parameters.AddWithValue("@Konu", veri.Konu);
            _sqlCommand.Parameters.AddWithValue("@Tarih", veri.Tarih);
            _sqlCommand.Parameters.AddWithValue("@SaatId", veri.Saat.SaatId);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Randevu Getir(int id)
        {
            Randevu randevu = new Randevu();
            randevu.RandevuId = id;
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spRandevuGetir @RandevuId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@RandevuId", id);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                randevu.Akademisyen = new Akademisyen
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
                };
                randevu.Ogrenci = new Ogrenci
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
                };
                randevu.AktifMi = Convert.ToBoolean(sqlDataReader["AktifMi"]);
                randevu.Konu = sqlDataReader["Konu"].ToString();
                randevu.Saat = new Saat
                {
                    SaatId = Convert.ToInt32(sqlDataReader["SaatId"]),
                    saat=TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                };
                randevu.Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return randevu;
        }

        public void Guncelle(Randevu veri)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Update Randevu set OgrId=@OgrId,AkmId=@AkmId,Konu=@Konu,Tarih=@Tarih" +
                ",SaatId=@SaatId,AktifMi=@AktifMi where RandevuId=@RandevuId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@RandevuId", veri.RandevuId);
            _sqlCommand.Parameters.AddWithValue("@OgrId", veri.Ogrenci.OgrId);
            _sqlCommand.Parameters.AddWithValue("@AkmId", veri.Akademisyen.AkmId);
            _sqlCommand.Parameters.AddWithValue("@Konu", veri.Konu);
            _sqlCommand.Parameters.AddWithValue("@Tarih", veri.Tarih);
            _sqlCommand.Parameters.AddWithValue("@SaatId", veri.Saat.SaatId);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<Randevu> HepsiniGetir()
        {
            List<Randevu> randevular = new List<Randevu>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spRandevuGetirTumu";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Randevu randevu = new Randevu();
                randevu.RandevuId = Convert.ToInt32(sqlDataReader["RandevuId"]);
                randevu.Akademisyen = new Akademisyen
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
                };
                randevu.Ogrenci = new Ogrenci
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
                };
                randevu.AktifMi = Convert.ToBoolean(sqlDataReader["AktifMi"]);
                randevu.Konu = sqlDataReader["Konu"].ToString();
                randevu.Saat = new Saat
                {
                    SaatId = Convert.ToInt32(sqlDataReader["SaatId"]),
                    saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                };
                randevu.Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]);
                randevular.Add(randevu);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return randevular;
        }

        public List<Randevu> OgrenciRandevulariniGetir(int ogrenciId)
        {
            List<Randevu> randevular = new List<Randevu>();
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Exec spRandevuGetirOgrenci @OgrId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@OgrId",ogrenciId);
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Randevu randevu = new Randevu();
                randevu.RandevuId = Convert.ToInt32(sqlDataReader["RandevuId"]);
                randevu.Akademisyen = new Akademisyen
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
                };
                randevu.Ogrenci = new Ogrenci
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
                };
                randevu.AktifMi = Convert.ToBoolean(sqlDataReader["AktifMi"]);
                randevu.Konu = sqlDataReader["Konu"].ToString();
                randevu.Saat = new Saat
                {
                    SaatId = Convert.ToInt32(sqlDataReader["SaatId"]),
                    saat = TimeSpan.Parse(sqlDataReader["Saat"].ToString())
                };
                randevu.Tarih = Convert.ToDateTime(sqlDataReader["Tarih"]);
                randevular.Add(randevu);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return randevular;
        }

        public void Sil(int id)
        {
            _sqlConnection = new SqlConnection(_yol);
            BaglantiAc();
            string commandText = "Delete from Randevu where RandevuId=@RandevuId";
            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@RandevuId",id);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
