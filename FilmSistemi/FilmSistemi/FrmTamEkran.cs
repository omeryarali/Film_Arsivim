using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmSistemi
{
    public partial class FrmTamEkran : Form
    {
        public FrmTamEkran()
        {
            InitializeComponent();
        }
        public string link;
        private void FrmTamEkran_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            webBrowser1.Navigate(link);
            
        }
    }
}
