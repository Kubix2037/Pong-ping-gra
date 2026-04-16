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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) moveUp = true;
            if (e.KeyCode == Keys.Escape) moveDown = true;

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) moveUp = false;
            if (e.KeyCode == Keys.Down) moveDown = false;

        }
    }
}
