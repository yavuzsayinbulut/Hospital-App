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
using System.Data.Sql;

namespace Hastane_Otomasyonu
{
    public partial class InsanKaynaklari : Form
    {
        public InsanKaynaklari()
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
        SqlCommand komut3 = new SqlCommand();
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
   
        public void listele()
        {
            tablo.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Personel", baglanti);
            adp.Fill(tablo);
           
            dataGridView1.DataSource = tablo;
            dataGridView2.DataSource = tablo;
            dataGridView3.DataSource = tablo;
        }

        
        string cinsiyett="";
        private void InsanKaynaklari_Load(object sender, EventArgs e)
        {
            txtTC.MaxLength = 11;
            txtTC2.MaxLength = 11;
            textBox1.MaxLength = 11;
            textBox23.MaxLength = 11;
            listele();
            verileriGetir();
            groupBox1.Enabled = false;
       
          
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtTC2.Text.Length > 10 && txtTC2.Text.Length < 12 && cinsiyet2 != "" && txtAd2.Text != "" && txtSoyad2.Text != "" && txtSifre2.Text !="" && txtDogum2.Text != "" && txtTC2.Text != "" && txtAdres2.Text != "" && txtTel2.Text != "" && comboBox3.SelectedIndex != -1)
            {
                baglanti.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand komut = new SqlCommand("update Personel set TC='" + textBox1.Text + "',Sifre='" + txtSifre2.Text + "',Ad='" + txtAd2.Text + "',Soyad='" + txtSoyad2.Text + "',Telefon='" + txtTel2.Text + "',Adres='" + txtAdres2.Text + "',Dogum_Tarihi='" + txtDogum2.Text + "',Gorevi='" + comboBox3.SelectedItem.ToString() + "',Cinsiyet='" + cinsiyet2.ToString() + "' where TC='" + txtTC2.Text + "' ", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                    MessageBox.Show("Başarılı.");
                    ClearAll(this);
                }
                else
                {
                    SqlCommand komut = new SqlCommand("update Personel set Sifre='" + txtSifre2.Text + "',Ad='" + txtAd2.Text + "',Soyad='" + txtSoyad2.Text + "',Telefon='" + txtTel2.Text + "',Adres='" + txtAdres2.Text + "',Dogum_Tarihi='" + txtDogum2.Text + "',Gorevi='" + comboBox3.SelectedItem.ToString() + "',Cinsiyet='" + cinsiyet2.ToString() + "' where TC='" + txtTC2.Text + "' ", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                    MessageBox.Show("Başarılı.");
                    ClearAll(this);
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("update Personel set Sifre='" + textBox24.Text + "' where TC='" + YetkiliGiris.gonderilecekveri.ToString() + "' ", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("Başarılı.");
                ClearAll(this);
               
            }
            catch
            {
                MessageBox.Show("Başarısız!");
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from Personel where TC like ('%" + textBox23.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Personel");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (cinsiyett != "" && comboBox1.SelectedIndex != -1 && txtAd.Text != "" && txtSoyad.Text != "" && txtDogum.Text != "" && txtTel.Text != "" && txtSifre.Text != "" && txtTC.Text.Length > 10 && txtTC.Text.Length < 12)
            {
                try
                {
                    baglanti.Open();
                    DateTime karsi1 = DateTime.Now;
                    string tarih = karsi1.ToString("yyyy-MM-dd");
                    SqlCommand komut = new SqlCommand("insert into Personel(TC,Sifre,Ad,Soyad,Telefon,Adres,Dogum_Tarihi,Baslangic_Tarihi,Cinsiyet,Gorevi)  values ('" + txtTC.Text + "', '" + txtSifre.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtTel.Text + "','" + txtAdres.Text + "','" + txtDogum.Text + "','" + tarih.ToString() + "','" + cinsiyett.ToString() + "','" + comboBox1.SelectedItem.ToString() + "')", baglanti);
                    int a = int.Parse(comboBox2.SelectedIndex.ToString());
                    a++;
                    komut.ExecuteNonQuery();

                    if (comboBox1.SelectedItem.ToString() == "Doktor")
                    {
                       
                        SqlCommand komut2 = new SqlCommand("insert into Doktor values((select Personel_ID from Personel where TC='" + txtTC.Text + "'),'" + a.ToString() + "','" + comboBox4.SelectedItem.ToString() + "')", baglanti);
                        komut2.ExecuteNonQuery();
                    }
                  
                    MessageBox.Show("Personel kaydı gerçekleşti.");
                    baglanti.Close();
                    listele();
                    ClearAll(this);
                }
                catch
                {
                    MessageBox.Show("BU TC NUMARASI KAYITLIDIR!");
                }

            }
            else
                
            { MessageBox.Show("Değerleri giriniz!"); }
            }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyett = "Erkek";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyett = "Kadın";
        }
        string cinsiyet2 = "";
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet2 = "Erkek";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet2 = "Kadın";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtTC2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTC2_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from Personel where TC like ('%" + txtTC2.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Personel");
            this.dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {

            }
            else
            {
                DialogResult cevap = new DialogResult();
                cevap = MessageBox.Show("Bu işlem geri alınmayacaktır!", "Eminmisiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();
                    DateTime karsi2 = DateTime.Now;
                    string tarih2 = karsi2.ToString("yyyy-MM-dd");
                    SqlCommand komut = new SqlCommand("update Personel set Cikis_Tarihi='" + tarih2.ToString() + "' where TC='" + textBox17.Text + "'", baglanti);
                 komut.ExecuteNonQuery();
                
                    MessageBox.Show("Personel çıkışı gerçekleşti.");
                    baglanti.Close();
                    listele();
                    ClearAll(this);
                }
                else
                { }
            }
        }
        public void verileriGetir()
        {

            tablo2.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Polikinlik ", baglanti);
            adp.Fill(tablo2);
            comboBox2.DataSource = tablo2;
            comboBox2.DisplayMember = "Brans";
            comboBox2.ValueMember = "Poliklinik_ID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Doktor")
            {
                groupBox1.Enabled = true;
            }

            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IK2 yeni = new IK2();
            yeni.Show();
        }

        
      





    }
}
