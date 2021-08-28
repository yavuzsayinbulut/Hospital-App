using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Hastane_Otomasyonu
{
    public partial class YetkiliGiris : Form
    {
        public YetkiliGiris()
        {
            InitializeComponent();
        }
        public static string gonderilecekveri;
            
              string connStr = "Data Source=.; Initial Catalog=HastaneOtomasyonu; Integrated Security=true;";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris yeni = new giris();
            yeni.Show();
        }
        DataTable tablo = new DataTable();
      
        private void button1_Click(object sender, EventArgs e)
        {
   
            gonderilecekveri = textBox1.Text;

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmdGirisKontrol = new SqlCommand("sp_yetkiKontrol", conn);
            cmdGirisKontrol.CommandType = CommandType.StoredProcedure;
            cmdGirisKontrol.Parameters.AddWithValue("@TC",textBox1.Text );
            cmdGirisKontrol.Parameters.AddWithValue("@Sifre", textBox2.Text);
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

          

           try { string unvan = cmdGirisKontrol.ExecuteScalar().ToString().Trim();

            if (unvan == "Doktor")
            {// MessageBox.Show("Başarılı");
                this.Hide(); Doktor yeni = new Doktor(); yeni.Show();
            }
            else if (unvan == "Vezne")
            {
                // MessageBox.Show("Başarılı");
                this.Hide();
                Vezne yeni = new Vezne();
                yeni.Show();
            }
            else if (unvan == "IK")
            {
                // MessageBox.Show("Başarılı");
                this.Hide();
                InsanKaynaklari yeni = new InsanKaynaklari();
                yeni.Show();
            }
            else if (unvan == "Temizlik" || unvan == "Hasta Bakıcı" || unvan == "Stajyer")
            {
                MessageBox.Show("Sisteme giriş yetkiniz bulunamamaktadır.");
            }
            else { MessageBox.Show("Giriş başarısız!"); }
            conn.Close();
            }
            catch { MessageBox.Show("Giriş başarısız!"); }
            

 
         
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void YetkiliGiris_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 11;

            textBox2.PasswordChar = '*';
        }

        private void YetkiliGiris_DragEnter(object sender, DragEventArgs e)
        {
      
        }
    }
}
