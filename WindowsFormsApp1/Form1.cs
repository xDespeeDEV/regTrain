using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=XDESPEE\\SQL;Initial Catalog=regTrain;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string sifre = textBox2.Text;
            con = new SqlConnection("Data Source=XDESPEE\\SQL;Initial Catalog=regTrain;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT * FROM Adminler WHERE kullanici_adi='" + textBox1.Text + "' AND kullanici_sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş başarılı!");
                AnaEkran frm = new AnaEkran();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş başarısız.");
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
