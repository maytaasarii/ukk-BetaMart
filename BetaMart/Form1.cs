using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BetaMart
{
    public partial class Form1 : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\erna mayta\source\repos\BetaMart\BetaMart\BetaMart.accdb");
        public Form1()
        {
            InitializeComponent();
        }
        void ShowData()
        {
            koneksi.Open();
            string query = "select * from Barang";
            OleDbDataAdapter data = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "DELETE FROM Barang WHERE ID = " + textid.Text;
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Terhapus");
            ShowData();
        }

        void ClearText()
        {
            textid.Clear();
            textBarang.Clear();
            textkode.Clear();
            textharga.Clear();
            textstok.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Insert into Barang (NamaBarang, Kode, Harga, Stok) values ('" + textBarang.Text + "', '" + textkode.Text + "', '" + textharga.Text + "', '" + textstok.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Tersimpan");

            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE Barang SET NamaBarang = '" + textBarang.Text + "', Kode = '" + textkode.Text + "', Harga = '" + textharga.Text + "', Stok = '" + textstok.Text + "' where ID=" + textid.Text + " ", koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Diupdate");

            ShowData();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "select * from Barang where NamaBarang='" + textBox6.Text + "'";
            OleDbDataAdapter data = new OleDbDataAdapter(perintah, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'betaMartDataSet.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.betaMartDataSet.Barang);

        }
    }
}
