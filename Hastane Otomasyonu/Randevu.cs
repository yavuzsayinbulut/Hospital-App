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
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=. ; Initial Catalog=HastaneOtomasyonu ; Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        DataTable tablo3 = new DataTable();
        public void listele1()
        {
            tablo2.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select Doktor.Personel_ID,Doktor.uzmanlik,Polikinlik.Brans,Personel.Ad,Personel.Soyad from Polikinlik inner join Doktor ON Polikinlik.Poliklinik_ID=Doktor.Poliklinik_ID inner join Personel ON Doktor.Personel_ID=Personel.Personel_ID", baglanti);

             adp.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }
        public void verileriGetir()
        {

            tablo.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Polikinlik ", baglanti);
            adp.Fill(tablo);
            comboBox1.DataSource = tablo; 
            comboBox1.DisplayMember = "Brans"; 
            comboBox1.ValueMember = "Poliklinik_ID"; 
        }

        public string doktorid;
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime karsi1 = DateTime.Now;
            DateTime karsi2 = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());

            int sonuc = DateTime.Compare(karsi2, karsi1);
            int sayi = txtTC.Text.Length;
            
            if (sonuc == 1 && txtTC.Text!="" && saat!=""  && sayi>10 && sayi<12)
            {
                DialogResult cevap = new DialogResult();
                cevap = MessageBox.Show("Bu işlem geri alınmayacaktır!", "Eminmisiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();


                  string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                    SqlCommand komut1 = new SqlCommand("insert into Hasta_Kaydı(TC) values ('" + txtTC.Text + "')", baglanti);
                    int secim = comboBox1.SelectedIndex;
                    secim++;
                    SqlCommand komut2 = new SqlCommand("insert into Randevu(Tarih,TC,Poliklinik_ID,D_ID,randevu_saati) values ('" + tarih.ToString() + "','" + txtTC.Text + "','" + secim.ToString() + "','" + doktorid + "','" + saat + "')", baglanti);

                   try { komut1.ExecuteNonQuery(); }
                    catch { }
                    komut2.ExecuteNonQuery();

                    MessageBox.Show("Başarılı.");
                    baglanti.Close();

                    this.Hide();
                    giris yeni = new giris();
                    yeni.Show();
                
                }
                else
                {
                    this.Hide();
                    giris yeni = new giris();
                    yeni.Show();
                }
            }
            else
            {
                MessageBox.Show("Değerleri giriniz!");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris yeni = new giris();
            yeni.Show();
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            listele1();
            txtTC.MaxLength = 11;
            verileriGetir();
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
             doktorid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
         
        }
        public string saat="";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
             saat = "09.00";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            saat = "10.45";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            saat = "13.00";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            saat = "14.45";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            saat = "15.00";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime karsi1 = DateTime.Now;
            DateTime karsi2 = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());

            int sonuc = DateTime.Compare(karsi2,karsi1);

            if(sonuc==1)
            { }
            else
            {
                MessageBox.Show("Bugünün tarihinden sonrasını seçiniz!");
            }
            



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tablo2.Clear();
            int a = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
            a++;
       
        
            SqlDataAdapter adp = new SqlDataAdapter("Select Doktor.Personel_ID,Doktor.uzmanlik,Polikinlik.Brans,Personel.Ad,Personel.Soyad from Polikinlik inner join Doktor ON Polikinlik.Poliklinik_ID=Doktor.Poliklinik_ID inner join Personel ON Doktor.Personel_ID=Personel.Personel_ID   where Doktor.Poliklinik_ID='" + a.ToString() + "'", baglanti);

             adp.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
         
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
