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

namespace RehberOtomasyonu
{
    public partial class FrmDetay : Form
    {
        public FrmDetay()
        {
            InitializeComponent();
        }
        public string id;
        sqlbaglantisi bgl = new sqlbaglantisi();
        void liste()
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_REHBER WHERE ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", id);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtmah.Text = dr["MAHALLE"].ToString();
                txtno.Text = dr["NO"].ToString();
                msktel.Text = dr["TEL"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                pictureBox1.ImageLocation = dr["RESIM"].ToString();
            }
            bgl.baglanti().Close();

        }
        void iller()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        private void FrmDetay_Load(object sender, EventArgs e)
        {
            iller();
            liste();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Update TBL_REHBER set " +
               "AD=@P1, SOYAD=@P2, IL=@P3, ILCE=@P4, MAHALLE=@P5,NO=@P6, TEL=@P7,MAIL=@P8 " +
               "where ID=@P9",
               bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", cmbil.Text);
            komut.Parameters.AddWithValue("@P4", cmbilce.Text);
            komut.Parameters.AddWithValue("@P5", txtmah.Text);
            komut.Parameters.AddWithValue("@P6", txtno.Text);
            komut.Parameters.AddWithValue("@P7", msktel.Text);
            komut.Parameters.AddWithValue("@P8", txtmail.Text);
            komut.Parameters.AddWithValue("@P9",id);
            komut.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Müşteri bilgisi güncellendi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }
    }
}
