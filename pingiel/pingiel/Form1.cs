using System;
using System.Drawing;
using System.Windows.Forms;

namespace pingiel
{
    public partial class Form1 : Form
    {
        int playery = 150;
        int aiy = 150;
        int ballX = 200;
        int ballY = 200;
        int ballSpeedX = 4;
        int ballSpeedY = 4;
        int playerscore = 0;
        int aiscore = 0;
        bool moveUp, moveDown;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) moveUp = true;
            if (e.KeyCode == Keys.Down) moveDown = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) moveUp = false;
            if (e.KeyCode == Keys.Down) moveDown = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (moveUp && playery > 0) playery -= 6;
            if (moveDown && playery < this.ClientSize.Height - 80) playery += 6;

            if (aiy + 40 < ballY) aiy += 2;
            if (aiy + 40 > ballY) aiy -= 2;

            if (aiy < 0) aiy = 0;
            if (aiy > this.ClientSize.Height - 80)
                aiy = this.ClientSize.Height - 80;

            ballX += ballSpeedX;
            ballY += ballSpeedY;

            Rectangle playerRect = new Rectangle(10, playery, 10, 80);
            Rectangle ballRect = new Rectangle(ballX, ballY, 10, 10);
            Rectangle aiRect = new Rectangle(this.ClientSize.Width - 20, aiy, 10, 80);

            if (ballY <= 0 || ballY >= this.ClientSize.Height - 10)
                ballSpeedY *= -1;

            if (aiRect.IntersectsWith(ballRect))
                ballSpeedX = -Math.Abs(ballSpeedX);

            if (playerRect.IntersectsWith(ballRect))
                ballSpeedX = Math.Abs(ballSpeedX);

            if (ballX < 0)
            {
                aiscore++;
                ResetBall();
            }

            if (ballX > this.ClientSize.Width)
            {
                playerscore++;
                ResetBall();
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.White, 10, playery, 10, 80);
            g.FillRectangle(Brushes.White, this.ClientSize.Width - 20, aiy, 10, 80);
            g.FillEllipse(Brushes.White, ballX, ballY, 10, 10);

            g.DrawString($"Gracz: {playerscore}", new Font("Arial", 12), Brushes.White, 50, 10);
            g.DrawString($"AI: {aiscore}", new Font("Arial", 12), Brushes.White, this.ClientSize.Width - 150, 10);
        }

        private void ResetBall()
        {
            ballX = this.ClientSize.Width / 2;
            ballY = this.ClientSize.Height / 2;
            ballSpeedX *= -1;
        }
    }
}