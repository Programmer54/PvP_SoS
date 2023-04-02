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
    public partial class Form8 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Sohbet sohbet=new SoS_Sohbet();
        SoS_Kullanici kullanici = new SoS_Kullanici();
        List<SoS_Sohbet> liste;
        int sohbet_iddd;

        public Form8(int sohbet_id,int kullanici)
        {
            InitializeComponent();
            sohbet_iddd = sohbet_id;
            this.kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici).Single();
            sohbet = db.SoS_Sohbet.Where(s => s.Sohbet_id == sohbet_id).Single();
            Yenile.Enabled = true;
            try
            {
                
                liste = db.SoS_Sohbet.Where(s => s.Sohbet_id == sohbet_id).OrderBy(s=>s.Id).ToList();
                foreach (var item in liste)
                {
                    listBox1.Items.Add(item.Mesaj);
                }
                sohbet = liste.Last();

            }
            catch (Exception) { }
        }

        private void Yenile_Tick(object sender, EventArgs e)
        {
            try
            {
                List<SoS_Sohbet> yeni_liste = db.SoS_Sohbet.Where(s => s.Sohbet_id == sohbet_iddd).OrderBy(s=>s.Id).ToList();
                if(liste.Count!=yeni_liste.Count)
                {
                    liste = yeni_liste;
                    listBox1.Items.Add(liste.Last().Mesaj);
                }
                if (liste.Last().Bittimi == -1)
                    Close();
            }
            catch(Exception){ }
            
            try
            {
                if (liste.Last().Bittimi == -1)
                {
                    MessageBox.Show("Karşı taraf sohbeti sonlandırdı.");
                    Close();
                }
            }
            catch (Exception) { }
        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                liste.Last().Bittimi = -1;
                db.SoS_Kullanici.Where(s => s.Id == sohbet.Kimden).Single().Sohbet = 0;
                db.SoS_Kullanici.Where(s => s.Id == sohbet.Kime).Single().Sohbet = 0;
                db.SaveChanges();
                Close();
            }
            catch(Exception)
            {
                sohbet.Bittimi = -1;
                db.SoS_Kullanici.Where(s => s.Id == sohbet.Kimden).Single().Sohbet = 0;
                db.SoS_Kullanici.Where(s => s.Id == sohbet.Kime).Single().Sohbet = 0;
                db.SaveChanges();
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null)
            {
                sohbet = liste.Last();
                sohbet.Mesaj = kullanici.KullaniciAdi + ": " + textBox1.Text;
                sohbet.Tarih = DateTime.Now;
                db.SoS_Sohbet.Add(sohbet);
                db.SaveChanges();
            }
        }
    }
}
