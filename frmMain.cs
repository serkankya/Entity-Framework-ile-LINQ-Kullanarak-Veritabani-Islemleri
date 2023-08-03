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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //bağlantı
        dbo_sonsiteyonetimiEntities ent = new dbo_sonsiteyonetimiEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            frmKayit reg = new frmKayit();
            this.Hide();
            reg.Show();
        }

        //Kayıtları gösterir
        private void button2_Click(object sender, EventArgs e)
        {
            var tbl = ent.tbl_sahipler.Where(k => k.gorunurluk == true).ToList();
            dataGridView1.DataSource = tbl;
        }

        //Aydat ödeme durumunu gösterir
        private void button3_Click(object sender, EventArgs e)
        {
            var tbl = ent.tbl_sahipler.Where(k => k.sahip_aydatdurum == false && k.gorunurluk==true).ToList();

            dataGridView1.DataSource = tbl;
        }


        //Kira durumunu gösterir
        private void button4_Click(object sender, EventArgs e)
        {
            var tbl = ent.tbl_sahipler.Where(k => k.sahip_kiradurum == false && k.gorunurluk==true).ToList();

            dataGridView1.DataSource = tbl;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmUpdate update = new frmUpdate();
            update.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idYazdir = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[idYazdir].Cells[0].Value.ToString();
        }


        //Veriyi pasif etme/silme
        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtID.Text);

            tbl_sahipler tbl = ent.tbl_sahipler.First(f => f.gorunurluk == true && f.sahip_id==id);
            tbl.gorunurluk = false;
            ent.SaveChanges();
            MessageBox.Show("Veri başarıyla pasif hale getirildi.");

            var tbl2 = ent.tbl_sahipler.Where(k => k.gorunurluk == true).ToList();
            dataGridView1.DataSource = tbl2;




        }
    }
}
