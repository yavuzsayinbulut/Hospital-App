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
    public partial class Vezne : Form
    {
        public Vezne()
        {
            InitializeComponent();
        }
  

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            giris yeni = new giris();
            yeni.Show();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=. ; Initial Catalog=HastaneOtomasyonu ; Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        public void listele()
        {
            tablo.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Hasta_Kaydı", baglanti);
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        public void listele2()
        {
            tablo2.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Randevu.SıraNo,Randevu.Tarih,Randevu.TC,Randevu.Poliklinik_ID,Randevu.D_ID,Randevu.randevu_saati,Personel.Ad,Personel.Soyad from Randevu inner join Personel ON Randevu.D_ID=Personel.Personel_ID", baglanti);
            adp.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
        }

        private void Vezne_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 11;
            listele();
            listele2();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from Hasta_Kaydı where TC like ('" + textBox1.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Hasta_Kaydı");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        string cinsiyet="";
        private void Button1_Click(object sender, EventArgs e)
        {
            int sayi = textBox1.Text.Length;

            if (sayi > 10 && sayi < 12 && textBox1.Text != "" && txtAd.Text != "" && txtAnne.Text != "" && txtBaba.Text != "" && txtDogum.Text != "" &&  txtProtokol.Text != "" && cinsiyet != "" && txtSGK.Text != "" && txtSoyad.Text != "" && txtTel.Text != "" && comboBoxil.SelectedIndex != -1 && comboBoxKan.SelectedIndex != -1 && comboBoxSgk.SelectedIndex != -1  && comboAktif.SelectedIndex!=-1)
           {
                 baglanti.Open();

                    SqlCommand komut = new SqlCommand("update Hasta_Kaydı set Protokol_No='" + txtProtokol.Text + "',Sgk_No='" + txtSGK.Text + "',Sgk_FaydalanılanKisi='" + comboBoxSgk.SelectedItem.ToString() + "',Ad='" + txtAd.Text + "',Soyad='" + txtSoyad.Text + "',Telefon='" + txtTel.Text + "',Dogum_Tarihi='" + txtDogum.Text + "',Kan_Grubu='" + comboBoxKan.SelectedItem.ToString() + "',Durum='" + comboAktif.SelectedItem.ToString() + "',Cinsiyet='" + cinsiyet.ToString() + "',il='" + comboBoxil.SelectedItem.ToString() + "',anne_adi='" + txtAnne.Text + "',baba_adi='" + txtBaba.Text + "' where TC='" + textBox1.Text + "'  ", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                     MessageBox.Show("Başarılı.");
                
               

            }
            else
            {
                MessageBox.Show ( "DEĞERLERİ DOLDURUNUZ!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Erkek";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Kadın";
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from Randevu where TC like ('" + textBox18.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Randevu");
            this.dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("update Personel set Sifre='"+textBox24.Text+"' where TC='"+YetkiliGiris.gonderilecekveri.ToString()+"' ",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Başarılı.");
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtProtokol_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtProtokol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSGK_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
