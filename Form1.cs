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
    public partial class Form1 : Form
    {
        GenelEntities db = new GenelEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SoS_Kullanici gir=db.SoS_Kullanici.Where(s => s.KullaniciAdi == textBox1.Text && s.Sifre == textBox2.Text).Single();
                int id = gir.Id;
                Form2 frm2 = new Form2(id);
                Hide();
                frm2.ShowDialog();
                Show();

            }
            catch(Exception)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            Hide();
            frm3.ShowDialog();
            Show();
        }
    }
}
