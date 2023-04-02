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
    public partial class Form7 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Sohbet Kabul = new SoS_Sohbet();
        SoS_Kullanici kullanici = new SoS_Kullanici();
        SoS_Kullanici karsi_kullanici = new SoS_Kullanici();
        public Form7(int gelen)
        {
            InitializeComponent();
            Kabul = db.SoS_Sohbet.Where(s => s.Sohbet_id == gelen).Single();
            kullanici = db.SoS_Kullanici.Where(s => s.Id == Kabul.Kime).Single();
            karsi_kullanici = db.SoS_Kullanici.Where(s => s.Id == Kabul.Kimden).Single();
            label1.Text = karsi_kullanici.KullaniciAdi + " sizi sohbete davet ediyor.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullanici.Sohbet = 0;
            Kabul.Bittimi = -1;
            db.SaveChanges();
            Close();
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            kullanici.Sohbet = 0;
            Kabul.Bittimi = -1;
            db.SaveChanges();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kabul.Bittimi = 1;
            db.SaveChanges();
            Form8 frm8 = new Form8(kullanici.Sohbet,kullanici.Id);
            frm8.ShowDialog();
            Close();

        }
    }
}
