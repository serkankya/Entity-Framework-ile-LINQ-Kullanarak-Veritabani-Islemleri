using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siteyonetimi
{
    public partial class frmKayit : Form
    {
        public frmKayit()
        {
            InitializeComponent();
        }

        dbo_sonsiteyonetimiEntities ent = new dbo_sonsiteyonetimiEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_sahipler tbl = new tbl_sahipler();

            tbl.sahip_ad = txtAd.Text;
            tbl.sahip_soyad = txtSoyad.Text;
            tbl.sahip_tel = txtTel.Text;
            if(cbKendi.Checked == true)
            {
                tbl.sahip_kiradurum = true;
            }
            else
            {
                tbl.sahip_kiradurum = false;
            }
            
            if(cbOdedi.Checked == true)
            {
                tbl.sahip_aydatdurum = true;
            }
            else
            {
                tbl.sahip_aydatdurum = false;
            }

            tbl.gorunurluk = true;

            ent.tbl_sahipler.Add(tbl);
            ent.SaveChanges();
            MessageBox.Show("Başarıyla kaydedildi.");
            

        }

        private void frmKayit_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }
    }
}
