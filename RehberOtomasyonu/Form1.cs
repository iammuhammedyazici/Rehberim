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
    public partial class frmRehber : Form
    {
        public frmRehber()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD, SOYAD ,TEL FROM TBL_REHBER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource=dt;
        }
        void temizle()
        {
            txtad.Clear();
            txtid.Clear();
            txtmah.Clear();
            txtmail.Clear();
            txtno.Clear();
            txtres.Clear();
            txtsoyad.Clear();
            msktel.Clear();
            cmbil.Text = "";
            cmbilce.Text = "";
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
        private void BtnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtres.Text = openFileDialog1.FileName;
        }
      
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_REHBER " +
                "(AD,SOYAD, IL,ILCE,MAHALLE,NO,TEL,MAIL,RESIM) " +
                " VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9) ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbil.Text);
            komut.Parameters.AddWithValue("@p4", cmbilce.Text);
            komut.Parameters.AddWithValue("@p5", txtmah.Text);
            komut.Parameters.AddWithValue("@p6", txtno.Text);
            komut.Parameters.AddWithValue("@p7", msktel.Text);
            komut.Parameters.AddWithValue("@p8", txtmail.Text);
            komut.Parameters.AddWithValue("@p9", txtres.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void frmRehber_Load(object sender, EventArgs e)
        {
            listele();
            iller();
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmDetay frm = new FrmDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.id = dr["ID"].ToString();
                
            }
            frm.Show();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                txtid.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtsoyad.Text = dr["SOYAD"].ToString();
            }
        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            DialogResult uyari;
            uyari = MessageBox.Show("Silmek istediğinize emin misiniz ?", "UYARI!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (uyari == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from TBL_REHBER WHERE ID=@P1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Silindi. ", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                listele();
            }
        }
    }
    }
