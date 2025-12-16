using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace halıYıkama
{
    public partial class Form1 : Form
    {
        List<Musteri> musteriler = new List<Musteri>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.AdSoyad = textBox1.Text;
            musteri.telefon = textBox2.Text;
            musteri.adres = textBox3.Text;
            musteriler.Add(musteri);
            comboBox1.Items.Add(musteri);
            MessageBox.Show("Müşteri eklendi");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Musteri secilenMusteri)
            {
                Hali hali = new Hali();
                hali.metreKare = Convert.ToInt32(textBox4.Text);
                hali.alimTarihi = dateTimePicker1.Value;
                hali.tahminiTeslimTarihi = dateTimePicker2.Value;
                hali.teslimEdildi = false;
                secilenMusteri.Halilar.Add(hali);
                listeGuncelle();
                MessageBox.Show("Hali eklendi");
                textBox4.Text = "";
            }
        }
        private void listeGuncelle()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var musteri in musteriler)
            {
                foreach (var hali in musteri.Halilar)
                {
                    string bilgi = $"{musteri}-{hali}";
                    if (hali.teslimEdildi)
                        listBox2.Items.Add(bilgi);
                    else
                        listBox1.Items.Add(bilgi);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var musteri in musteriler)
            {
                foreach (var hali in musteri.Halilar)
                {
                    string bilgi = $"{musteri}-{hali}";
                    if (listBox1.SelectedItem != null && bilgi == listBox1.SelectedItem.ToString())
                    {
                        hali.teslimEdildi = true;
                        listeGuncelle();
                        MessageBox.Show("Halı teslim edildi olarak güncellendi");
                    }
                }
            }
        }

        public class Musteri
        {
            public string AdSoyad { get; set; }
            public string telefon { get; set; }
            public string adres { get; set; }
            public List<Hali> Halilar { get; set; } = new List<Hali>();
            public override string ToString()
            {
                return $"{AdSoyad}";
            }

        }

        public class Hali
        {
            public double metreKare { get; set; }
            public DateTime alimTarihi { get; set; }
            public DateTime tahminiTeslimTarihi { get; set; }
            public bool teslimEdildi { get; set; }
            public double ucret => metreKare * 20;
            public override string ToString()
            {
                string durum = teslimEdildi ? "Teslim Edildi" : "Yıkamada";
                return $"metreKare: {metreKare}, Ücret: {ucret} TL,Durum: {durum}";
            }


        }



    }
}

