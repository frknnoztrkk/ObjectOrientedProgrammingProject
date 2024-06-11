
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            RestartGame();
        }

        bool goLeft, goRight;
        int speed = 3;
        long DurdurmaZamanı;
        bool Durdumu = false;
        int Üretilen = 0;
        int TalepEdilenÜrün = int.Parse(Form1.TalepEdilenÜrün);

        Random randX = new Random();
        Random randY = new Random();


        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            int ArtışMiktarı = 5;

            if (e.KeyCode == Keys.Left && x>=0)
            {
                x -= ArtışMiktarı;
            }
            if(e.KeyCode == Keys.Right && x<420)
            {
                x += ArtışMiktarı;
            }

            if (e.KeyCode == Keys.P)
            {
                Durdumu = !Durdumu;

                if (Durdumu)
                {
                    DurdurmaZamanı = DateTimeOffset.Now.ToUnixTimeSeconds();
                    Gametimer.Stop();
                   
                }
                else
                {
                    long DurdurulmaSüresi = DateTimeOffset.Now.ToUnixTimeSeconds() - DurdurmaZamanı;
                    Form1.BaşlamaZamanı += DurdurulmaSüresi;
                    Gametimer.Start();
                }
            }

            pictureBox1.Location = new Point(x,y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label10.Text = Form1.TalepEdilenÜrün.ToString();
            textBox5.Text = Form1.OyunSüresi;
            Console.WriteLine(Form1.OyunSüresi);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
          
        }
        private void RestartGame()
        {
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top = randY.Next(80, 360) * -1;
                    x.Left = randX.Next(5, this.ClientSize.Width - x.Width - 140);
                }
            }
           
            goLeft = false;
            goRight = false;

            Gametimer.Start();


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top += speed;

                    if (x.Top + x.Height > this.ClientSize.Height)
                    {
                        x.Top = randX.Next(80, 360) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width - x.Width - 140);
                    }

                }
            }

            long ŞimdikiZaman = DateTimeOffset.Now.ToUnixTimeSeconds();
            long KalanZaman = Form1.BaşlamaZamanı +long.Parse(Form1.OyunSüresi) - ŞimdikiZaman;
            int GeçenZaman = unchecked((int) (ŞimdikiZaman - Form1.BaşlamaZamanı));
            textBox5.Text = KalanZaman.ToString();

            speed = 3 + (GeçenZaman / 20);

            if (KalanZaman <= 0)
            {
                this.Close();
            }



             
            #region AABB Collision Detection 
            var egg = pictureBox7;
            var drop = pictureBox5;
            var salt = pictureBox6;

            var cake = pictureBox1;

            #region egg Collision
            if (cake.Location.X < egg.Location.X + egg.Width &&
                cake.Location.X + cake.Width > egg.Location.X &&
                cake.Location.Y < egg.Location.Y + egg.Height &&
                cake.Location.Y + cake.Height > egg.Location.Y)
            {
                egg.Top = randY.Next(80, 360) * -1;
                egg.Left = randX.Next(5, this.ClientSize.Width - egg.Width - 140);

                label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
            }
            #endregion
            #region drop Collision
            if (cake.Location.X < drop.Location.X + drop.Width &&
                cake.Location.X + cake.Width > drop.Location.X &&
                cake.Location.Y < drop.Location.Y + drop.Height &&
                cake.Location.Y + cake.Height > drop.Location.Y)
            {
                drop.Top = randY.Next(80, 360) * -1;
                drop.Left = randX.Next(5, this.ClientSize.Width - drop.Width - 140);

                label3.Text = (Convert.ToInt32(label3.Text) + 1).ToString();
            }
            #endregion
            #region salt Collision
            if (cake.Location.X < salt.Location.X + salt.Width &&
                cake.Location.X + cake.Width > salt.Location.X &&
                cake.Location.Y < salt.Location.Y + salt.Height &&
                cake.Location.Y + cake.Height > salt.Location.Y)
            {
                salt.Top = randY.Next(80, 360) * -1;
                salt.Left = randX.Next(5, this.ClientSize.Width - salt.Width - 140);

                label4.Text = (Convert.ToInt32(label4.Text) + 1).ToString();
            }
            #endregion
            #region Total

            #endregion
            #endregion

            int a = Convert.ToInt32(label3.Text);
            int b = Convert.ToInt32(label4.Text) / 2;
            int c = Convert.ToInt32(label5.Text) / 3;

            if (a < b)
            {
                if (a < c)
                {
                    Üretilen = a;
                }
                else
                {
                    Üretilen = c;
                }
            }
            else
            {
                if (b < c)
                {
                    Üretilen = b;
                }
                else
                {
                    Üretilen=c;
                }
            }

            label9.Text = Üretilen.ToString();
            label10.Text = (TalepEdilenÜrün - Üretilen).ToString();
            
            if(Üretilen >= TalepEdilenÜrün)
            {
                this.Close();
            }

        }
    }
}
