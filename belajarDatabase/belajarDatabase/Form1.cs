using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajarDatabase
{
    public partial class Form1 : Form
    {
        string koneksi = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:/Users/Embah_Salto/Documents/Visual Studio 2015/Projects/belajarDatabase/belajarDatabase/Mahasiswa.accdb";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_peserta";
            OleDbConnection con = new OleDbConnection(koneksi);
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "tb_peserta");
            con.Close();
            dataGridView1.DataSource = ds.Tables["tb_peserta"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("insert into tb_peserta (nik,nama,tang_lahir,email,hp,organisasi,rekomen,tang_terbit,Kota,Skema) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    txt_nik.Text, txt_nama.Text, data1.Text, txt_email.Text, txt_hp.Text, txt_org.Text, txt_rekom.Text,textBox2.Text, txt_tmpt.Text,txt_skema.Text);
                OleDbConnection conn = new OleDbConnection(koneksi);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OleDbException salah)
            {
                MessageBox.Show(salah.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql1 = "select * from tb_peserta";
            OleDbConnection con = new OleDbConnection(koneksi);
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql1, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "tb_peserta");
            con.Close();
            dataGridView1.DataSource = ds.Tables["tb_peserta"].DefaultView;
        }
    }
}
