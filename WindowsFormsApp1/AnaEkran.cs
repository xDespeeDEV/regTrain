using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=XDESPEE\\SQL;Initial Catalog=regTrain;Integrated Security=True");
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bilgiler.Items.Add("Yolcu: " + textBox1.Text);
            Bilgiler.Items.Add("TCK: " + textBox2.Text);
            Bilgiler.Items.Add("Doğum Yılı: " + textBox3.Text);
            Bilgiler.Items.Add("Kalkış: " + comboBox1.Text);
            Bilgiler.Items.Add("Varış: " + comboBox2.Text);
            Bilgiler.Items.Add("Tarih: " + dateTimePicker1.Text);
            SqlCommand komut = new SqlCommand("INSERT INTO Musteriler(musteri_isimsoyisim,musteri_tck,musteri_dogumtarihi,musteri_telno,musteri_kalkis,musteri_varis,musteri_tarih) VALUES (@MusteriName,@MusteriTck,@MusteriDt,@MusteriTel,@MusteriKalkis,@MusteriVaris,@MusteriTarih)", baglanti);
            komut.Parameters.AddWithValue("@MusteriName", textBox1.Text);
            komut.Parameters.AddWithValue("@MusteriTck", textBox2.Text);
            komut.Parameters.AddWithValue("@MusteriTel", textBox3.Text);
            komut.Parameters.AddWithValue("@MusteriDt", dateTimePicker2.Text);
            komut.Parameters.AddWithValue("@MusteriKalkis", comboBox1.Text);
            komut.Parameters.AddWithValue("@MusteriVaris", comboBox2.Text);
            komut.Parameters.AddWithValue("@MusteriTarih", dateTimePicker1.Text);

            MessageBox.Show("Müşteri kaydı başarıyla yapıldı.");

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Musteriler frm = new Musteriler();
            frm.Show();
        }

        private void Bilgiler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
