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
    public partial class Form6 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Oyun_Kabul Kabul = new SoS_Oyun_Kabul();
        SoS_Kullanici kullanici = new SoS_Kullanici();
        SoS_Kullanici karsi_kullanici = new SoS_Kullanici();
        public Form6(int gelen,int id)
        {
            InitializeComponent();
            // -1: red edildi
            //  1: kabul edildi
            Kabul = db.SoS_Oyun_Kabul.Where(s => s.OyunId == gelen).Single();//gelen istek sutunuda oyun_kabul_id gelecek.
            karsi_kullanici = db.SoS_Kullanici.Where(s => s.Id == Kabul.Kimden).Single();
            kullanici = db.SoS_Kullanici.Where(s => s.Id == id).Single();
            label1.Text = karsi_kullanici.KullaniciAdi + " size oyun daveti gönderdi.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kabul.Kabul = -1;
            kullanici.İstek = 0;
            db.SaveChanges();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)// istek kabul edildiğinde oyun alalına gitdecek.
        {
            Kabul.Kabul = 1;
            db.SaveChanges();
            Form9 frm9 = new Form9(kullanici.İstek, kullanici.Id);
            Hide();
            frm9.ShowDialog();
            Close();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Kabul.Kabul = -1;
            kullanici.İstek = 0;
            db.SaveChanges();
            Close();
            
        }
    }
}
