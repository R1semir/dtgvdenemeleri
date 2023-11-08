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
namespace dtgv12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BJO2DGU\\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");
        
        private void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from tblKitaplar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblKitaplar (ad,yazar,sayfaNo,basımEvi) values (@p1,@p2,@p3,@p4)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtYazar.Text);
            komut.Parameters.AddWithValue("@p3",txtSayfaNo.Text);
            komut.Parameters.AddWithValue("@p4",txtBasimEvi.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            txtKitapAdi.Clear();
            txtYazar.Clear();
            txtSayfaNo.Clear();
            txtBasimEvi.Clear();
            verilerigoster("select * from tblKitaplar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from tblKitaplar where ad =@id",baglanti);
            komut.Parameters.AddWithValue("@id",textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            verilerigoster("select * from tblKitaplar");
        }
    }
}
