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

    public partial class Form9 : Form
    {
        GenelEntities db=new GenelEntities ();
        SoS_Kullanici kullanici = new SoS_Kullanici();
        int karsi_id;
        SoS_Oyun_İci oyun = new SoS_Oyun_İci();
        bool sira;
        bool skor_tablosundaki_yerim;
        bool nerden_geldin=false;
        //enum indisler
        //{
        //    button1=1,
        //    button2=2,
        //    button3=3,
        //    button4=4,
        //    button5=5,
        //    button6=6,
        //    button7=7,
        //    button8=8,
        //    button9=9,
        //}
        public Form9(int istek, int id)
        {
            InitializeComponent();
            kullanici = db.SoS_Kullanici.Where(s => s.Id == id).Single();
            
            if (db.SoS_Oyun_Kabul.Where(s => s.OyunId == istek).Single().Kimden == kullanici.Id)
            {
                skor_tablosundaki_yerim = true;
                karsi_id = db.SoS_Oyun_Kabul.Where(s => s.OyunId == istek).Single().Kime;
                oyun.OyunId = db.SoS_Oyun_Kabul.Where(s => s.OyunId == istek).Single().Oyun_Asil_İd;
                oyun.Sira = kullanici.Id;
                oyun.Bittimi = false;
                oyun.HamleSayisi = 0;
                db.SoS_Oyun_İci.Add(oyun);
                db.SaveChanges();
                sira = true;
                label1.Text = "Sıra sizde";
            }
            else
            {
                skor_tablosundaki_yerim = false;
                oyun.OyunId = db.SoS_Oyun_Kabul.Where(s => s.OyunId == istek).Single().Oyun_Asil_İd;
                karsi_id = db.SoS_Oyun_Kabul.Where(s => s.OyunId == istek).Single().Kimden;
                GuncellemeVeSira.Enabled = true;
                label1.Text = "Sıra karşı tarafta";
            }


        }

        private void GuncellemeVeSira_Tick(object sender, EventArgs e)
        {
            db = new GenelEntities();
           
            try
            {
                oyun = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (oyun.Sira == kullanici.Id)
                {
                    sira = true;
                    label1.Text = "Sıra sizde";
                    GuncellemeVeSira.Enabled = false;
                   
                }
                
            }
            catch (Exception) { }
            try
            {
                if (oyun.Degisenİndis == 1)
                {
                    button1.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button1.Text = "s";
                    else
                        button1.Text = "o";
                }
                if (oyun.Degisenİndis == 2)
                {
                    button2.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button2.Text = "s";
                    else
                        button2.Text = "o";
                }
                if (oyun.Degisenİndis == 3)
                {
                    button3.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button3.Text = "s";
                    else
                        button3.Text = "o";
                }
                if (oyun.Degisenİndis == 4)
                {
                    button4.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button4.Text = "s";
                    else
                        button4.Text = "o";
                }
                if (oyun.Degisenİndis == 5)
                {
                    button5.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button5.Text = "s";
                    else
                        button5.Text = "o";
                }
                if (oyun.Degisenİndis == 6)
                {
                    button6.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button6.Text = "s";
                    else
                        button6.Text = "o";
                }
                if (oyun.Degisenİndis == 7)
                {
                    button7.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button7.Text = "s";
                    else
                        button7.Text = "o";
                }
                if (oyun.Degisenİndis == 8)
                {
                    button8.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button8.Text = "s";
                    else
                        button8.Text = "o";
                }
                if (oyun.Degisenİndis == 9)
                {
                    button9.Enabled = false;
                    if (oyun.İndisDegeri == "s")
                        button9.Text = "s";
                    else
                        button9.Text = "o";
                }
            }
            catch (Exception) { }
            if(skor_tablosundaki_yerim==true)
            {
                try
                {
                    db = new GenelEntities();
                    oyun = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                    kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                    if (oyun.HamleSayisi == 9)
                    {
                        oyun.Bittimi = true;
                        if (oyun.Ben > oyun.O)
                        {
                            GuncellemeVeSira.Enabled = false;
                            //kullanici.Zafer++;
                            kullanici.Zafer = kullanici.Zafer + 1;
                            kullanici.İstek = 0;
                            oyun.Bittimi = true;
                            oyun.Kazanan = kullanici.Id;
                            db.SaveChanges();
                            nerden_geldin = true;
                            Close();
                            MessageBox.Show("Kazandınız.");
                        }
                        else if (oyun.Ben < oyun.O)
                        {
                            GuncellemeVeSira.Enabled = false;
                            db = new GenelEntities();
                            kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                            //kullanici.Bozgun++;
                            kullanici.Bozgun = kullanici.Bozgun + 1;
                            kullanici.İstek = 0;
                            oyun.Bittimi = true;
                            db.SaveChanges();
                            nerden_geldin = true;
                            Close();
                            MessageBox.Show("Kaybettiniz.");
                        }
                        else if (oyun.Ben == oyun.O)
                        {
                            GuncellemeVeSira.Enabled = false;
                            db = new GenelEntities();
                            kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                            kullanici.İstek = 0;
                            oyun.Bittimi = true;
                            db.SaveChanges();
                            nerden_geldin = true;
                            Close();
                            MessageBox.Show("Beraberlik");
                        }
                    }
                    if (oyun.Bittimi == true && oyun.HamleSayisi != 9)
                    {
                        GuncellemeVeSira.Enabled = false;
                        db = new GenelEntities();
                        kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                        kullanici.İstek = 0;
                        //kullanici.Zafer++;
                        kullanici.Zafer = kullanici.Zafer + 1;
                        oyun.Kazanan = kullanici.Id;
                        db.SaveChanges();
                        nerden_geldin = true;
                        Close();
                        MessageBox.Show("Karşı taraf oyunu terk etti. Kazandınız.");
                    }
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    db = new GenelEntities();
                    oyun = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                    kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                    if (oyun.HamleSayisi == 9)
                    {
                        oyun.Bittimi = true;
                        if (oyun.O > oyun.Ben)
                        {
                            GuncellemeVeSira.Enabled = false;
                            //kullanici.Zafer++;
                            kullanici.Zafer = kullanici.Zafer + 1;
                            kullanici.İstek = 0;
                            oyun.Bittimi = true;
                            oyun.Kazanan = kullanici.Id;
                            db.SaveChanges();
                            nerden_geldin = true;
                            Close();
                            MessageBox.Show("Kazandınız.");
                        }
                        else if (oyun.O < oyun.Ben)
                        {
                            GuncellemeVeSira.Enabled = false;
                            db = new GenelEntities();
                            kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                            //kullanici.Bozgun++;
                            kullanici.Bozgun = kullanici.Bozgun + 1;
                            kullanici.İstek = 0;
                            oyun.Bittimi = true;
                            db.SaveChanges();
                            nerden_geldin = true;
                            Close();
                            MessageBox.Show("Kaybettiniz.");
                        }
                        else if (oyun.O == oyun.Ben)
                        {
                            GuncellemeVeSira.Enabled = false;
                            db = new GenelEntities();
                            kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                            kullanici.İstek = 0;
                            oyun.Bittimi = true;
                            db.SaveChanges();
                            nerden_geldin = true;
                            Close();
                            MessageBox.Show("Beraberlik");
                        }
                    }
                    if (oyun.Bittimi == true && oyun.HamleSayisi != 9)
                    {
                        GuncellemeVeSira.Enabled = false;
                        db = new GenelEntities();
                        kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                        kullanici.İstek = 0;
                        //kullanici.Zafer++;
                        kullanici.Zafer = kullanici.Zafer + 1;
                        oyun.Kazanan = kullanici.Id;
                        db.SaveChanges();
                        nerden_geldin = true;
                        Close();
                        MessageBox.Show("Karşı taraf oyunu terk etti. Kazandınız.");
                    }
                }
                catch (Exception) { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(sira==true)
            {
                Form10 frm10 = new Form10(oyun.OyunId,1,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if(degistimi.Degisenİndis!=oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 2,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 3,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 4,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 5,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 6,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 7,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 8,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sira == true)
            {
                Form10 frm10 = new Form10(oyun.OyunId, 9,karsi_id);
                frm10.ShowDialog();
                db = new GenelEntities();
                SoS_Oyun_İci degistimi = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                if (degistimi.Degisenİndis != oyun.Degisenİndis)
                {
                    kontrol();
                    sira = false;
                    label1.Text = "Sıra karşı tarafta";
                    GuncellemeVeSira.Enabled = true;
                }
            }
        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(nerden_geldin==false)
            {
                db = new GenelEntities();
                kullanici = db.SoS_Kullanici.Where(s => s.Id == kullanici.Id).Single();
                oyun = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
                int zafer = kullanici.Zafer;
                //kullanici.Bozgun++;
                kullanici.Bozgun = kullanici.Bozgun + 1;
                kullanici.İstek = 0;
                oyun.Bittimi = true;
                db.SaveChanges();
            }
        }
        #region Hamle Tanımları
        void kontrol()
        {
            oyun = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun.OyunId).Single();
            if(skor_tablosundaki_yerim==true)
            {
                if (oyun.Degisenİndis == 1)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button2.Text == "o" && button3.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button4.Text == "o" && button7.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button9.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }

                }
                if (oyun.Degisenİndis == 2)
                {
                    if (oyun.İndisDegeri == "o")
                    {
                        if (button1.Text == "s" && button3.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button8.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 3)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button2.Text == "o" && button1.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button6.Text == "o" && button9.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button7.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 4)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button6.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "o")
                    {
                        if (button1.Text == "s" && button7.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 5)
                {
                    if (oyun.İndisDegeri == "o")
                    {
                        if (button1.Text == "s" && button9.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button2.Text == "s" && button8.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button3.Text == "s" && button7.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 6)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button4.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "o")
                    {
                        if (button3.Text == "s" && button9.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 7)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button4.Text == "o" && button1.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button8.Text == "o" && button9.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button3.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 8)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button2.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "o")
                    {
                        if (button7.Text == "s" && button9.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 9)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button6.Text == "o" && button3.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button1.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                        if (button8.Text == "o" && button7.Text == "s")
                        {
                            oyun.Ben++;
                            db.SaveChanges();
                        }
                    }
                }
            }
            else
            {
                if (oyun.Degisenİndis == 1)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button2.Text == "o" && button3.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button4.Text == "o" && button7.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button9.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }

                }
                if (oyun.Degisenİndis == 2)
                {
                    if (oyun.İndisDegeri == "o")
                    {
                        if (button1.Text == "s" && button3.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button8.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 3)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button2.Text == "o" && button1.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button6.Text == "o" && button9.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button7.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 4)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button6.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "o")
                    {
                        if (button1.Text == "s" && button7.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 5)
                {
                    if (oyun.İndisDegeri == "o")
                    {
                        if (button1.Text == "s" && button9.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button2.Text == "s" && button8.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button3.Text == "s" && button7.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 6)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button4.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "o")
                    {
                        if (button3.Text == "s" && button9.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 7)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button4.Text == "o" && button1.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button8.Text == "o" && button9.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button3.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 8)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button5.Text == "o" && button2.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                    else if (oyun.İndisDegeri == "o")
                    {
                        if (button7.Text == "s" && button9.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
                if (oyun.Degisenİndis == 9)
                {
                    if (oyun.İndisDegeri == "s")
                    {
                        if (button6.Text == "o" && button3.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button5.Text == "o" && button1.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                        if (button8.Text == "o" && button7.Text == "s")
                        {
                            oyun.O++;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        #endregion

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

}
