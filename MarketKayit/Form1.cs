using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime simdi = DateTime.Now;
            dtpSKTarihi.MaxDate = simdi.AddYears(5);
            dtpSKTarihi.MinDate = simdi.AddYears(-2);
            VerileriGetir();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Urun yeniUrun = new Urun("Su",1,DateTime.Now); //instance
            try
            {
                Urun yeniUrun = new Urun();
                yeniUrun.Ad = txtUrunAdi.Text;
                yeniUrun.Fiyat = nudFiyat.Value;
                yeniUrun.SonKullanmaTarihi = dtpSKTarihi.Value;

                MyContext db = new MyContext();
                db.Urunler.Add(yeniUrun);
                db.SaveChanges();
                
                VerileriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olustu: "+ex.Message);
            }
        }

        private void VerileriGetir()
        {
            MyContext db =  new MyContext();
            lstUrunler.DataSource = db.Urunler.ToList();
        }
        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstUrunler.SelectedItem == null) return;

            //Urun seciliUrun = lstUrunler.SelectedItem as Urun;
            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;
            txtUrunAdi.Text = seciliUrun.Ad;
            nudFiyat.Value = seciliUrun.Fiyat;
            dtpSKTarihi.Value = seciliUrun.SonKullanmaTarihi;

            

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItem == null) return;

            //Urun seciliUrun = lstUrunler.SelectedItem as Urun;
            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;
            MyContext db = new MyContext();
            Urun silinecekUrun = db.Urunler.Find(seciliUrun.Id);

            db.Urunler.Remove(silinecekUrun);
            db.SaveChanges();

            VerileriGetir();
        }
    }
}
