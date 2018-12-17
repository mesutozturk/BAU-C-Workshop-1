using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string ad = txtName.Text;
            DateTime dogumTarihi = dtpBirthDate.Value;
            int yas = DateTime.Now.Year - dogumTarihi.Year;

            //MessageBox.Show("Giris yapan kullanici " + ad + " Yasi: " + yas);

            decimal fiyat = numericUpDown1.Value;
            string c = "asmdklasmdaklsd";
            int a = 10;
            double b = 20.6;

            decimal tutar = fiyat * 12 * Convert.ToDecimal(0.1);
            double alan = 5 * 5 * Math.PI;
            double yuvarlanmis = Math.Round(alan,4);
            string formatli = $"%10 {tutar:C4}";

            MessageBox.Show(formatli);
            formatli = $"{DateTime.Now:dddd dd/MMM/yy HH:mm}";
            MessageBox.Show(formatli);
        }
    }
}
