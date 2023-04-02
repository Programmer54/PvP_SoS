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
    public partial class Form3 : Form
    {
        GenelEntities db = new GenelEntities();
        SoS_Kullanici ekle = new SoS_Kullanici();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db.SoS_Kullanici.Where(s => s.KullaniciAdi == textBox1.Text).Single();
                MessageBox.Show("Böyle bir kullanıcı adı zaten mevcut. Lütfen başka bir kullanıcı adı yazınız.");
            }
            catch(Exception)
            {
                ekle.KullaniciAdi = textBox1.Text;
                ekle.Adi = textBox2.Text;
                ekle.Sifre = textBox3.Text;
                db.SoS_Kullanici.Add(ekle);
                db.SaveChanges();
                MessageBox.Show("Kayıt başarılı.");
                Close();

            }
        }
    }
}
