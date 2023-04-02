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
    public partial class Form10 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Oyun_İci oyun;
        int indis;
        int karsi_id;
        public Form10(int oyun_id,int indis,int karsi_id)
        {
            InitializeComponent();
            this.oyun = db.SoS_Oyun_İci.Where(s => s.OyunId == oyun_id).Single();
            this.indis = indis;
            this.karsi_id = karsi_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oyun.Degisenİndis = indis;
            oyun.İndisDegeri = "s";
            oyun.Sira = karsi_id;
            oyun.HamleSayisi++;
            db.SaveChanges();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oyun.Degisenİndis = indis;
            oyun.İndisDegeri = "o";
            oyun.Sira = karsi_id;
            oyun.HamleSayisi++;
            db.SaveChanges();
            Close();
        }
    }
}
