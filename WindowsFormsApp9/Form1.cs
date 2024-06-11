
/* NESNEYE DAYALI PROGRAMLAMA PROJE ÖDEVİ
   BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ 
   FURKAN ÖZTÜRK  B201200038
*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public static string TalepEdilenÜrün = "";
        public static string OyunSüresi = "";
        public static long BaşlamaZamanı;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ürün toplama çubuğunu hareket ettirmek için yön tuşların kullanınız ve durdurmak için P tuşuna basınız","BİLGİ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaşlamaZamanı = DateTimeOffset.Now.ToUnixTimeSeconds();
            Console.WriteLine(BaşlamaZamanı);
            TalepEdilenÜrün = textBox5.Text;
            OyunSüresi = textBox4.Text;
            

            Form2 form = new Form2();
            form.Show();
           

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
