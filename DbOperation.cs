using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.calorifit
{
   public  class DbOperation
    {

        private string yol;
        public SqlConnection baglanti; // Bağlantı
        public DataTable tablo; // Tablo 
        public SqlDataAdapter adaptor; // 
        public SqlDataReader okuyucu;
        public SqlCommand komut;
        public DbOperation()
        {
            

            yol = "Data Source=LAPTOP-J52RCB6V\\SQLEXPRESS;Initial Catalog = dbCaloriFit;Integrated Security=True";

        }
        public void VeritabaninaBaglan()
        {
            baglanti = new SqlConnection(yol);
            if (baglanti.State == ConnectionState.Closed)
            {
                Console.WriteLine("Veritabanı kapalıydı tekrar bağlandı.");
                baglanti.Open();

            }
            if (baglanti.State == ConnectionState.Open)
            {
                Console.WriteLine("Veritabanina Bağlı");
            }
        }


        public void KullaniciEkle(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable UyeVarmi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }


    }
}
