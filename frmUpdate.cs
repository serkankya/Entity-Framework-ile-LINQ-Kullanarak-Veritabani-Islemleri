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
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        dbo_sonsiteyonetimiEntities ent = new dbo_sonsiteyonetimiEntities();

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            var tbl = ent.tbl_sahipler.Where(k => k.gorunurluk == true).ToList();
            dataGridView1.DataSource = tbl;
            MaximizeBox = false;
            MinimizeBox = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtTel.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtID.Text);
            tbl_sahipler tbl = ent.tbl_sahipler.First(f => f.sahip_id == id);

            tbl.sahip_ad = txtAd.Text;
            tbl.sahip_soyad = txtSoyad.Text;
            tbl.sahip_tel = txtTel.Text;

            ent.SaveChanges();
            MessageBox.Show("Veriler başarıyla güncellendi.");
            dataGridView1.DataSource = ent.tbl_sahipler.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }
    }
}
