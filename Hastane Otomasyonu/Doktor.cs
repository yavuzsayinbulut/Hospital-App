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
    public partial class Doktor : Form
    {
        public Doktor()
        {
            InitializeComponent();
        }
        private void ClearAll(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris yeni = new giris();
            yeni.Show();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=. ; Initial Catalog=HastaneOtomasyonu ; Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        SqlCommand komut2 = new SqlCommand();
        DataTable tablo2 = new DataTable();
        DataTable tablodoktor = new DataTable();
        DataTable tablo1 = new DataTable();
        public void listele1()
        {
            DateTime karsi1 = DateTime.Now;
            string tarih = karsi1.ToString("yyyy-MM-dd");
               tablodoktor.Clear();
               SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.Ad,Hasta_kaydı.Soyad,Randevu.Tarih,Randevu.TC,Randevu.Muayne,Randevu.D_ID,Randevu.randevu_saati,Personel.Ad as 'DoktorAd',Personel.Soyad as'DoktorSoyad' from Randevu inner join Hasta_Kaydı  ON Randevu.TC=Hasta_Kaydı.TC inner join  Personel ON Randevu.D_ID=Personel.Personel_ID  where  Randevu.Muayne is null and Randevu.D_ID=(select Personel_ID from Personel where TC=" + YetkiliGiris.gonderilecekveri.ToString() + ") and Randevu.Tarih in('"+tarih.ToString()+"') ", baglanti);
            adp.Fill(tablodoktor);
            dataGridView1.DataSource = tablodoktor;
        }

       public void listele2()
        {
            tablo1.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.TC,Hasta_Kaydı.Ad,Hasta_Kaydı.Soyad,muayneDetay.muayne_aciklamasi,muayneDetay.teshis_recete from Hasta_Kaydı inner join Randevu ON Hasta_Kaydı.TC=Randevu.TC inner join muayneDetay ON muayneDetay.sira_no=Randevu.SıraNo",baglanti);
            adp.Fill(tablo1);
            dataGridView2.DataSource = tablo1;
        }
        private void Doktor_Load(object sender, EventArgs e)
        {
            listele1();
     
            txtAd.Enabled = false;
            txtSoyad.Enabled = false;
            txtTC.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
       
            DateTime karsi1 = DateTime.Now;
            string tarih = karsi1.ToString("yyyy-MM-dd");
            tablodoktor.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.Ad,Hasta_kaydı.Soyad,Randevu.Tarih,Randevu.TC,Randevu.Muayne,Randevu.D_ID,Randevu.randevu_saati,Personel.Ad as 'DoktorAd',Personel.Soyad as'DoktorSoyad' from Randevu inner join Hasta_Kaydı  ON Randevu.TC=Hasta_Kaydı.TC inner join  Personel ON Randevu.D_ID=Personel.Personel_ID  where  Randevu.Muayne is null and Randevu.D_ID=(select Personel_ID from Personel where TC=" + YetkiliGiris.gonderilecekveri.ToString() + ") and Randevu.Tarih in('" + tarih.ToString() + "') and randevu_saati='09.00'", baglanti);
            adp.Fill(tablodoktor);
            dataGridView1.DataSource = tablodoktor;



            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime karsi1 = DateTime.Now;
            string tarih = karsi1.ToString("yyyy-MM-dd");
            tablodoktor.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.Ad,Hasta_kaydı.Soyad,Randevu.Tarih,Randevu.TC,Randevu.Muayne,Randevu.D_ID,Randevu.randevu_saati,Personel.Ad as 'DoktorAd',Personel.Soyad as'DoktorSoyad' from Randevu inner join Hasta_Kaydı  ON Randevu.TC=Hasta_Kaydı.TC inner join  Personel ON Randevu.D_ID=Personel.Personel_ID  where  Randevu.Muayne is null and Randevu.D_ID=(select Personel_ID from Personel where TC=" + YetkiliGiris.gonderilecekveri.ToString() + ") and Randevu.Tarih in('" + tarih.ToString() + "') and randevu_saati='10.45'", baglanti);
            adp.Fill(tablodoktor);
            dataGridView1.DataSource = tablodoktor;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateTime karsi1 = DateTime.Now;
            string tarih = karsi1.ToString("yyyy-MM-dd");
            tablodoktor.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.Ad,Hasta_kaydı.Soyad,Randevu.Tarih,Randevu.TC,Randevu.Muayne,Randevu.D_ID,Randevu.randevu_saati,Personel.Ad as 'DoktorAd',Personel.Soyad as'DoktorSoyad' from Randevu inner join Hasta_Kaydı  ON Randevu.TC=Hasta_Kaydı.TC inner join  Personel ON Randevu.D_ID=Personel.Personel_ID  where  Randevu.Muayne is null and Randevu.D_ID=(select Personel_ID from Personel where TC=" + YetkiliGiris.gonderilecekveri.ToString() + ") and Randevu.Tarih in('" + tarih.ToString() + "') and randevu_saati='13.00'", baglanti);
            adp.Fill(tablodoktor);
            dataGridView1.DataSource = tablodoktor;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DateTime karsi1 = DateTime.Now;
            string tarih = karsi1.ToString("yyyy-MM-dd");
            tablodoktor.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.Ad,Hasta_kaydı.Soyad,Randevu.Tarih,Randevu.TC,Randevu.Muayne,Randevu.D_ID,Randevu.randevu_saati,Personel.Ad as 'DoktorAd',Personel.Soyad as'DoktorSoyad' from Randevu inner join Hasta_Kaydı  ON Randevu.TC=Hasta_Kaydı.TC inner join  Personel ON Randevu.D_ID=Personel.Personel_ID  where  Randevu.Muayne is null and Randevu.D_ID=(select Personel_ID from Personel where TC=" + YetkiliGiris.gonderilecekveri.ToString() + ") and Randevu.Tarih in('" + tarih.ToString() + "') and randevu_saati='14.45'", baglanti);
            adp.Fill(tablodoktor);
            dataGridView1.DataSource = tablodoktor;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DateTime karsi1 = DateTime.Now;
            string tarih = karsi1.ToString("yyyy-MM-dd");
            tablodoktor.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.Ad,Hasta_kaydı.Soyad,Randevu.Tarih,Randevu.TC,Randevu.Muayne,Randevu.D_ID,Randevu.randevu_saati,Personel.Ad as 'DoktorAd',Personel.Soyad as'DoktorSoyad' from Randevu inner join Hasta_Kaydı  ON Randevu.TC=Hasta_Kaydı.TC inner join  Personel ON Randevu.D_ID=Personel.Personel_ID  where  Randevu.Muayne is null and Randevu.D_ID=(select Personel_ID from Personel where TC=" + YetkiliGiris.gonderilecekveri.ToString() + ") and Randevu.Tarih in('" + tarih.ToString() + "') and randevu_saati='15.00'", baglanti);
            adp.Fill(tablodoktor);
            dataGridView1.DataSource = tablodoktor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text == "Sıra")
            {
                label5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("update Personel set Sifre='" + textBox24.Text + "' where TC='" + YetkiliGiris.gonderilecekveri.ToString() + "' ", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele1();
                MessageBox.Show("Başarılı.");
                ClearAll(this);

            }
            catch
            {
                MessageBox.Show("Başarısız!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTC.Text != "" && txtMuayne.Text != "" && txtRecete.Text != "")
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand("insert into muayneDetay values ('" + label5.Text + "','" + txtMuayne.Text + "','" + txtRecete.Text + "')", baglanti);
                    SqlCommand komut2 = new SqlCommand("update Randevu set Muayne='+' where TC='" + txtTC.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Hasta durumu kayıt edildi.");
                    baglanti.Close();
                
                    ClearAll(this);
                    listele1();
                    listele2();
                }
            }
            catch { MessageBox.Show("HATA"); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tablo2.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Hasta_Kaydı.Ad,Hasta_kaydı.Soyad,Randevu.Tarih,Randevu.TC,Randevu.Muayne as 'Muayene Durum',Randevu.D_ID,Randevu.randevu_saati,Personel.Ad as 'DoktorAd',Personel.Soyad as'DoktorSoyad' from Randevu inner join Hasta_Kaydı  ON Randevu.TC=Hasta_Kaydı.TC inner join  Personel ON Randevu.D_ID=Personel.Personel_ID  where Personel.TC='" + YetkiliGiris.gonderilecekveri.ToString() + "'  ", baglanti);
            adp.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from Randevu where TC like ('%" + textBox18.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Randevu");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
