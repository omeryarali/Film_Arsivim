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

namespace FilmSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-7KPL2B4\MSSQLSERVERRRR;Initial Catalog=DbFilmArsivim;Integrated Security=True");
        void filmler()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from TBLFİLMLER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFİLMLER (AD,KATEGORİ,LİNK) VALUES (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtKategori.Text);
            komut.Parameters.AddWithValue("@p3",TxtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film listesnize Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            filmler();

        }
        public string link = null;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            link=dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Ömer Yaralı tarafından 27 Aralık 2022'de kodlandı.","Bilgi"
                ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void BtnRenkDegistir_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 11);
            
                switch(i)
                {
                    case 0:
                        this.BackColor=Color.Brown;
                        break;
                    case 1:
                        this.BackColor = Color.Yellow;
                        break;
                    case 2:
                        this.BackColor = Color.Gray;
                        break;
                    case 3:
                        this.BackColor = Color.GreenYellow;
                        break;
                    case 4:
                        this.BackColor = Color.Pink;
                        break;
                    case 5:
                        this.BackColor = Color.Red;
                        break;
                    case 6:
                        this.BackColor = Color.Blue;
                        break;
                    case 7:
                        this.BackColor = Color.Purple;
                        break;
                    case 8:
                        this.BackColor = Color.Orange;
                        break;
                    case 9:
                        this.BackColor = Color.Green;
                        break;
                    case 10:
                        this.BackColor = Color.Turquoise;
                        break;

                }
            
        }

        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            FrmTamEkran frm = new FrmTamEkran();
            frm.link = link;
            frm.Show();
        }
    }
}
