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
    public partial class IK2 : Form
    {
        public IK2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=. ; Initial Catalog=HastaneOtomasyonu ; Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        DataTable tablo2 = new DataTable();
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

        public void verileriGetir()
        {

            tablo2.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Polikinlik ", baglanti);
            adp.Fill(tablo2);
            comboBox2.DataSource = tablo2;
            comboBox2.DisplayMember = "Brans";
            comboBox2.ValueMember = "Poliklinik_ID";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                int a = int.Parse(comboBox2.SelectedIndex.ToString());
                a++;
                SqlCommand komut = new SqlCommand("update Doktor set Personel_ID=(select Personel_ID from Personel where TC=" + textBox1.Text + "), Poliklinik_ID='" + a.ToString() + "', uzmanlik='" + comboBox4.SelectedItem.ToString() + "'  where Personel_ID=(select Personel_ID from Personel where TC=" + textBox1.Text + ")", baglanti);


                komut.ExecuteNonQuery();

                MessageBox.Show("Personel kaydı güncellendi.");
                baglanti.Close();

           
         /*       SqlCommand cmdekle = new SqlCommand("sp_Ik2", baglanti);
                cmdekle.CommandType = CommandType.StoredProcedure;
                cmdekle.Parameters.AddWithValue("@tc", textBox1.Text);
                cmdekle.Parameters.AddWithValue("@Poliklinik_ID", comboBox4.SelectedIndex.ToString());
                cmdekle.Parameters.AddWithValue("@uzmanlik", comboBox2.SelectedItem.ToString());

                if (baglanti.State == ConnectionState.Closed)
                { baglanti.Open(); }
                */
            }
            else

            { MessageBox.Show("Değerleri Giriniz"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void IK2_Load(object sender, EventArgs e)
        {
            verileriGetir();
            textBox1.MaxLength = 11;
        }
    }
}
