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
    public partial class Form5 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Kullanici kullanici = new SoS_Kullanici();
        List<SoS_Kullanici> liste;
        public static int S_id;
        int O_id;
        public Form5(int id)
        {
            InitializeComponent();
            kullanici = db.SoS_Kullanici.Where(s => s.Id == id).Single();
            İstek_Kontrol.Enabled = true;
            Mesaj_Kontrol.Enabled = true;
            Online_Yenile.Enabled = true;
            liste = db.SoS_Kullanici.Where(s => s.Online == true).ToList();
            foreach (var item in liste)
            {
                if (item.KullaniciAdi == kullanici.KullaniciAdi)
                    continue;

                listBox1.Items.Add(item.KullaniciAdi);
            }
        }

        private void İstek_Kontrol_Tick(object sender, EventArgs e)//burda kaldım istek gelince yeni form açılıcak
        {
            kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
            if(kullanici.İstek!=0)
            {
                db = new GenelEntities();
                Form6 frm6 = new Form6(kullanici.İstek,kullanici.Id);
                İstek_Kontrol.Enabled = false;
                frm6.ShowDialog();
                İstek_Kontrol.Enabled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)// istek göndericek(oyun)
        {
            try
            {
                SoS_Kullanici secilen = db.SoS_Kullanici.Where(s => s.KullaniciAdi == listBox1.SelectedItem.ToString()).Single();
                if (secilen.İstek == 0)
                {
                    try
                    {
                        int oyun_id = db.SoS_Oyun_Kabul.OrderBy(s => s.OyunId).ToList().Last().OyunId + 1;
                        int asil_oyun_id;
                        SoS_Oyun_Kabul oyun = new SoS_Oyun_Kabul();
                        oyun.Kimden = kullanici.Id;
                        oyun.Kime = secilen.Id;
                        oyun.OyunId = oyun_id;
                        try
                        {
                            asil_oyun_id = db.SoS_Oyun_İci.OrderBy(s => s.OyunId).ToList().Last().OyunId + 1;
                        }
                        catch (Exception)
                        {
                            asil_oyun_id = 1;
                        }
                        oyun.Oyun_Asil_İd = asil_oyun_id;
                        kullanici.İstek = oyun_id;
                        secilen.İstek = oyun_id;
                        İstek_Kontrol.Enabled = false;
                        db.SoS_Oyun_Kabul.Add(oyun);
                        db.SaveChanges();
                        Giden_Oyun_Kontrol.Enabled = true;

                    }
                    catch (Exception)
                    {
                        int oyun_id = 1;
                        int asil_oyun_id;
                        SoS_Oyun_Kabul oyun = new SoS_Oyun_Kabul();
                        oyun.Kimden = kullanici.Id;
                        oyun.Kime = secilen.Id;
                        oyun.OyunId = oyun_id;
                        try
                        {
                            asil_oyun_id = db.SoS_Oyun_İci.OrderBy(s => s.OyunId).ToList().Last().OyunId + 1;
                        }
                        catch (Exception)
                        {
                            asil_oyun_id = 1;
                        }
                        oyun.Oyun_Asil_İd = asil_oyun_id;
                        kullanici.İstek = oyun_id;
                        secilen.İstek = oyun_id;
                        İstek_Kontrol.Enabled = false;
                        db.SoS_Oyun_Kabul.Add(oyun);
                        db.SaveChanges();
                        Giden_Oyun_Kontrol.Enabled = true;

                    }
                }
                else
                    MessageBox.Show("Kullanıcı şu anda müsait değil.");
            }
            catch(Exception)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)// istek göndericek(mesaj)
        {
            
            try
            {
                SoS_Kullanici secilen = db.SoS_Kullanici.Where(s => s.KullaniciAdi == listBox1.SelectedItem.ToString()).Single();
                if (secilen.Sohbet == 0)
                {
                    try
                    {
                        int S_id = db.SoS_Sohbet.OrderBy(s => s.Sohbet_id).ToList().Last().Sohbet_id + 1;
                        SoS_Sohbet s_istek = new SoS_Sohbet();
                        s_istek.Kimden = kullanici.Id;
                        s_istek.Kime = secilen.Id;
                        s_istek.Sohbet_id = S_id;
                        s_istek.Tarih = DateTime.Now;
                        secilen.Sohbet = S_id;
                        kullanici.Sohbet = S_id;
                        Mesaj_Kontrol.Enabled = false;
                        db.SoS_Sohbet.Add(s_istek);
                        Giden_Sohbet_Kontrol.Enabled = true;
                        db.SaveChanges();

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                        S_id = 1;
                        SoS_Sohbet s_istek = new SoS_Sohbet();
                        s_istek.Kimden = kullanici.Id;
                        s_istek.Kime = secilen.Id;
                        s_istek.Sohbet_id = S_id;
                        s_istek.Tarih = DateTime.Now;
                        secilen.Sohbet = S_id;
                        kullanici.Sohbet = S_id;
                        Mesaj_Kontrol.Enabled = false;
                        db.SoS_Sohbet.Add(s_istek);
                        Giden_Sohbet_Kontrol.Enabled = true;
                        db.SaveChanges();

                    }
                }
                else
                    MessageBox.Show("Kullanıcı şu anda müsait değil.");
            }
            catch(Exception)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
            }
        }

        private void Mesaj_Kontrol_Tick(object sender, EventArgs e)
        {
            db = new GenelEntities();
            if(kullanici.Sohbet!=0)
            {
                
                Form7 frm7 = new Form7(kullanici.Sohbet);
                Mesaj_Kontrol.Enabled = false;
                frm7.ShowDialog();
                Mesaj_Kontrol.Enabled = true;
            }
        }

        private void Online_Yenile_Tick(object sender, EventArgs e)
        {
            db = new GenelEntities();
            kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();//kendimi yeniliyorum aD:GfdGH:hf:g
            List<SoS_Kullanici> yeni_liste = db.SoS_Kullanici.Where(s => s.Online == true).ToList();
            if(liste.Count!=yeni_liste.Count)
            {
                liste = yeni_liste;
                listBox1.Items.Clear();
                foreach (var item in liste)
                {
                    if (item.KullaniciAdi == kullanici.KullaniciAdi)
                        continue;
                    listBox1.Items.Add(item.KullaniciAdi);
                }
            }
        }

        private void Giden_Sohbet_Kontrol_Tick(object sender, EventArgs e)
        {
            //db = new GenelEntities();
            //kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
            //if(db.SoS_Sohbet.Where(s=>s.Sohbet_id==S_id).Single().Bittimi==1)
            //if(kullanici.Sohbet!=0)
                try
                {
                    if (db.SoS_Sohbet.Where(s => s.Sohbet_id == kullanici.Sohbet).OrderBy(s => s.Sohbet_id).ToList().Last().Bittimi == 1)
                    {
                        Form8 frm8 = new Form8(kullanici.Sohbet, kullanici.Id);
                        Giden_Sohbet_Kontrol.Enabled = false;
                        frm8.ShowDialog();
                        Mesaj_Kontrol.Enabled = true;
                    }
                    else if (db.SoS_Sohbet.Where(s => s.Sohbet_id == kullanici.Sohbet).Single().Bittimi == -1)
                    {
                        kullanici.Sohbet = 0;
                        db.SaveChanges();
                        Giden_Sohbet_Kontrol.Enabled = false;
                        Mesaj_Kontrol.Enabled = true;
                    }
                }
                catch (Exception) { }
        }

        private void Giden_Oyun_Kontrol_Tick(object sender, EventArgs e)
        {
            try
            {
                if (db.SoS_Oyun_Kabul.Where(s => s.OyunId == kullanici.İstek).Single().Kabul == 1)
                {
                    Form9 frm9 = new Form9(kullanici.İstek,kullanici.Id);
                    Giden_Oyun_Kontrol.Enabled = false;
                    frm9.ShowDialog();
                    İstek_Kontrol.Enabled = true;

                }
                else if(db.SoS_Oyun_Kabul.Where(s => s.OyunId == kullanici.İstek).Single().Kabul == -1)
                {
                    kullanici.İstek = 0;
                    db.SaveChanges();
                    Giden_Oyun_Kontrol.Enabled = false;
                    İstek_Kontrol.Enabled = true;
                }
            }
            catch (Exception) { }
        }
    }
}
