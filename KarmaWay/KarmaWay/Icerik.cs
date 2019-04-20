using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarmaWay
{
    public partial class Icerik : Form
    {
        public Icerik()
        {
            InitializeComponent();
        }

        private void Icerik_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnMuhasebe_Click(object sender, EventArgs e)
        {
            Muhasebe mh = new Muhasebe();
            mh.Show();
            this.Hide();
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            Urunler ur = new Urunler();
            ur.Show();
            this.Hide();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            Musteri mst = new Musteri();
            mst.Show();
            this.Hide();
        }

        private void btnIslemler_Click(object sender, EventArgs e)
        {
            Islemler isl = new Islemler();
            isl.Show();
            this.Hide();
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            Siparis sip = new Siparis();
            sip.Show();
            this.Hide();
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            YoneticiIslemleri yi = new YoneticiIslemleri();
            yi.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            KarmaWay kw = new KarmaWay();
            kw.Show();
            this.Hide();
        }
    }
}
