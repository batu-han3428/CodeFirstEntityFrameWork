using CodeFirst.Context;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (dbContext context = new dbContext())
            {

                Kategori kategoriler = new Kategori();
                kategoriler.kategoriAd = Convert.ToString(textBox1.Text);
                kategoriler.kategoriAciklama = Convert.ToString(textBox2.Text);
                var durum = false;

                if (radioButton1.Checked == true)
                {
                    durum = true;
                }
                else
                {
                    durum = false;
                }

                List<Urun> urunler = new List<Urun>() {

                   new Urun { 
                              urunAd =  Convert.ToString(textBox3.Text),
                              urunFiyat = Convert.ToDecimal(textBox4.Text),
                              urunStok = Convert.ToInt32(textBox5.Text),
                              aktif = Convert.ToBoolean(durum),
                            }, 

                };


                kategoriler.urunler = urunler;
                context.kategoriler.Add(kategoriler);
                context.SaveChanges();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (dbContext context = new dbContext())
            {
                listBox1.Items.Clear();

                var a = context.urunler.ToList();

                foreach (var item in a)
                {
                    Console.WriteLine(listBox1.Items.Add("Ürün Id:" + item.urunId));
                    Console.WriteLine(listBox1.Items.Add("Ürün Ad:" + item.urunAd));
                    Console.WriteLine(listBox1.Items.Add("Ürün Fiyat:" + item.urunFiyat));
                    Console.WriteLine(listBox1.Items.Add("Ürün Stok:" + item.urunStok));
                    Console.WriteLine(listBox1.Items.Add("Ürün Aktif:" + item.aktif));
                    Console.WriteLine(listBox1.Items.Add("-----------------------------------------------\n"));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (dbContext context = new dbContext())
            {
                int urunId = Convert.ToInt32(textBox9.Text);
                string urunAd = Convert.ToString(textBox8.Text);
                decimal urunFiyat = Convert.ToDecimal(textBox7.Text);
                int urunStok = Convert.ToInt32(textBox6.Text);
                Boolean urunDurum;
                var urun = context.urunler.Find(urunId);

                if (radioButton4.Checked == true)
                {
                    urunDurum = true;
                    urun.aktif = urunDurum;
                }
                else
                {
                    urunDurum = false;
                    urun.aktif = urunDurum;
                }



                urun.urunAd = urunAd;
                urun.urunFiyat = urunFiyat;
                urun.urunStok = urunStok;
                urun.aktif = urunDurum;
                context.Entry<Urun>(urun).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
