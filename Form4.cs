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
    public partial class Form4 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Kullanici kullanici = new SoS_Kullanici();

        public Form4(int id)
        {
            InitializeComponent();
            kullanici=db.SoS_Kullanici.Where(s => s.Id == id).Single();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==textBox2.Text)
            {
                kullanici.Sifre = textBox1.Text;
                db.SaveChanges();
                MessageBox.Show("Şifre güncelleme başarılı");
                Close();
            }
        }
    }
}
