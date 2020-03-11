using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1.calorifit
{
    public partial class KayitOl : Form
    {
        public static char Cinsiyet = ' ';
        public KayitOl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_KayitOl_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == txtSifreTekrar.Text)
            {
                DbOperation db = new DbOperation();
                DataTable tablo = db.UyeVarmi("select * from tbl_kullanici where e_mail='" + txtEmail.Text + "'");
                if (tablo.Rows.Count > 0)
                {
                    lbl_UyariMesaj.Text = "Böyle bir e posta bulunmaktadır. Başka e posta deneyiniz";

                }
                else
                {
                    db.KullaniciEkle("insert into tbl_kullanici values('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtEmail.Text + "','" + txtSifre.Text + "','" + txtSifre.Text + "','" + Cinsiyet + "','" + dateTimePicker1.Value + "')");
                    lbl_UyariMesaj.Text = "Kayıt olundu";
                }

            }
            else
            {
                lbl_UyariMesaj.Text = "Şifreler uyuşmamaktadır.";
            }

        }

        private void radioE_CheckedChanged(object sender, EventArgs e)
        {
            Cinsiyet = 'E';
        }

        private void radioK_CheckedChanged(object sender, EventArgs e)
        {
            Cinsiyet = 'K';
        }
    }



   
}

