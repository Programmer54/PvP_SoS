using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PvP_SoS
{
    public partial class Form2 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Kullanici kullanici = new SoS_Kullanici();
        int id;
        
        public Form2(int id)
        {
            
            InitializeComponent();
            this.id = id;
            kullanici = db.SoS_Kullanici.Where(s => s.Id == id).Single();
            label1.Text = "Hoşgeldin " + kullanici.KullaniciAdi;
            label3.Text = kullanici.Zafer.ToString();
            label5.Text = kullanici.Bozgun.ToString();
            kullanici.Online = true;
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(kullanici.Id);
            Hide();
            frm4.ShowDialog();
            Show();
        }
        #region Kapatılma
        private void button3_Click(object sender, EventArgs e)
        {
            kullanici.Online = false;
            db.SaveChanges();
            Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            kullanici.Online = false;
            db.SaveChanges();
            Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            kullanici.Online = false;
            db.SaveChanges();
            Close();
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5(kullanici.Id);
            Hide();
            frm5.ShowDialog();
            kullanici = db.SoS_Kullanici.Where(s => s.Id == id).Single();
            label1.Text = "Hoşgeldin " + kullanici.KullaniciAdi;
            label3.Text = kullanici.Zafer.ToString();
            label5.Text = kullanici.Bozgun.ToString();
            Show();

        }
    }
}
