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
        OleDbConnection koneksi = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Wigan\UKK\BetaMartDB.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = koneksi.CreateCommand();
            string query = "update products set Nama='" + Nama.Text + "' ,Stock='" + Stock.Text + "' ,Price='" + Price.Text + "' ,Code='" + Code.Text + "' where ID=" + ID.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            ID.Text = "";
            Nama.Text = "";
            Stock.Text = "";
            Price.Text = "";
            Code.Text = "";
            MessageBox.Show("Barang kamu sudah berhasil diedit");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "INSERT INTO products (Nama, Code, Price, Stock) values (' " + Nama.Text + " ' , ' " + Code.Text + " ' , ' " + Price.Text + " ' , ' " + Stock.Text + " ' )";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Tersimpan");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = koneksi.CreateCommand();
            string query = "delete from products where ID=" + ID.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            ID.Text = "";
            MessageBox.Show("Menghapus barang berhasil");
        }
        void ShowData()
        {
            koneksi.Open();
            string query = "select * from products";
            OleDbDataAdapter da = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "select * from products where Nama='" + Search.Text + "'or Code='" + Search.Text + "'or Price='" + Search.Text + "'or Stock='" + Search.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(perintah, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }
    }
}
