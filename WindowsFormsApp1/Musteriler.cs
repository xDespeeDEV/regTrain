using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Musteriler : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=XDESPEE\\SQL;Initial Catalog=regTrain;Integrated Security=True");
        public Musteriler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM Musteriler";
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void Bilgiler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bilgiler.Items.Add("Müşteri: " + textBox1.Text);
            Bilgiler.Items.Add("TCK: " + textBox2.Text);
            Bilgiler.Items.Add("Doğum Yılı: " + textBox3.Text);
            Bilgiler.Items.Add("Kalkış: " + "Müşteri kaydı manuel olduğundan dolayı *Belirtilmedi*");
            Bilgiler.Items.Add("Varış: " + "Müşteri kaydı manuel olduğundan dolayı *Belirtilmedi*");
            Bilgiler.Items.Add("Tarih: " + "Müşteri kaydı manuel olduğundan dolayı *Belirtilmedi*");
            SqlCommand komut = new SqlCommand("INSERT INTO Musteriler(musteri_isimsoyisim,musteri_tck,musteri_dogumtarihi,musteri_telno,musteri_kalkis,musteri_varis,musteri_tarih) VALUES (@MusteriName,@MusteriTck,@MusteriDt,@MusteriTel,@MusteriKalkis,@MusteriVaris,@MusteriTarih)", baglanti);
            komut.Parameters.AddWithValue("@MusteriName", textBox1.Text);
            komut.Parameters.AddWithValue("@MusteriTck", textBox2.Text);
            komut.Parameters.AddWithValue("@MusteriTel", textBox3.Text);
            komut.Parameters.AddWithValue("@MusteriDt", dateTimePicker2.Text);
            komut.Parameters.AddWithValue("@MusteriKalkis", "Manuel Ekleme");
            komut.Parameters.AddWithValue("@MusteriVaris", "Manuel Ekleme");
            komut.Parameters.AddWithValue("@MusteriTarih", "Manuel Ekleme");

            MessageBox.Show("Müşteri kaydı başarıyla yapıldı.");

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void musteriKaldirbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM Musteriler WHERE musteri_id=@musteriID", baglanti);
                komut.Parameters.AddWithValue("@musteriID", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));


                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Müşteri başarıyla silindi.");
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bir veri seçiniz.");
            }
            listView1.Items.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM Musteriler";
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                listView1.Items.Add(tablo.Rows[i]["musteri_id"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["musteri_isimsoyisim"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["musteri_isimsoyisim"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["musteri_tck"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["musteri_telno"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["musteri_kalkis"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["musteri_varis"].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i]["musteri_tarih"].ToString());

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT @MusteriTCK, musteri_isimsoyisim, musteri_id, musteri_tck, musteri_telno, musteri_dogumtarihi, musteri_varis, musteri_kalkis, musteri_tarih FROM Musteriler;";
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            komut.Parameters.AddWithValue("@MusteriTCK", textBox4.Text);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                listView2.Items.Add(tablo.Rows[i]["musteri_id"].ToString());
                listView2.Items[i].SubItems.Add(tablo.Rows[i]["musteri_isimsoyisim"].ToString());
                listView2.Items[i].SubItems.Add(tablo.Rows[i]["musteri_tck"].ToString());
                listView2.Items[i].SubItems.Add(tablo.Rows[i]["musteri_telno"].ToString());
                listView2.Items[i].SubItems.Add(tablo.Rows[i]["musteri_kalkis"].ToString());
                listView2.Items[i].SubItems.Add(tablo.Rows[i]["musteri_varis"].ToString());
                listView2.Items[i].SubItems.Add(tablo.Rows[i]["musteri_tarih"].ToString());
            }
        }
    }
}
