using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace TBL04
{
    public partial class Form1 : Form
    {
        
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int HT_CAPTION = 0x02;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();

            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;

            btnRestaurar.BringToFront();

            button1.Image = CriarIconeFechar();
            btnMaximizar.Image = CriarIconeMaximizar();
            btnRestaurar.Image = CriarIconeRestaurar();
            button2.Image = CriarIconeClientes();
            button3.Image = CriarIconeProdutos();
            button4.Image = CriarIconeVendas();
            button5.Image = CriarIconeRelatorios();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form2>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form3>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form4>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form5>();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
        {
            Form formulario = new Forms();
            formulario.Show();
        }

        

        private static Bitmap CriarIconeFechar()
        {
            Bitmap bmp = new Bitmap(28, 28);
            using (Graphics g = Graphics.FromImage(bmp))
            using (GraphicsPath caminho = new GraphicsPath())
            using (SolidBrush fundo = new SolidBrush(Color.FromArgb(190, 40, 60)))
            using (Pen xis = new Pen(Color.White, 3.5f))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int r = 8;
                Rectangle a = new Rectangle(1, 1, 26, 26);
                caminho.AddArc(a.X, a.Y, r, r, 180, 90);
                caminho.AddArc(a.Right - r, a.Y, r, r, 270, 90);
                caminho.AddArc(a.Right - r, a.Bottom - r, r, r, 0, 90);
                caminho.AddArc(a.X, a.Bottom - r, r, r, 90, 90);
                caminho.CloseFigure();
                g.FillPath(fundo, caminho);
                xis.StartCap = LineCap.Round;
                xis.EndCap = LineCap.Round;
                g.DrawLine(xis, 8, 8, 20, 20);
                g.DrawLine(xis, 20, 8, 8, 20);
            }
            return bmp;
        }

        private static Bitmap CriarIconeMaximizar()
        {
            Bitmap bmp = new Bitmap(28, 28);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen caneta = new Pen(Color.White, 2.5f))
            {
                g.DrawRectangle(caneta, 6, 6, 15, 15);
            }
            return bmp;
        }

        private static Bitmap CriarIconeRestaurar()
        {
            Bitmap bmp = new Bitmap(28, 28);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen caneta = new Pen(Color.White, 2.5f))
            {
                g.DrawRectangle(caneta, 5, 10, 12, 12);   
                g.DrawLine(caneta, 10, 10, 10, 5);       
                g.DrawLine(caneta, 10, 5, 22, 5);
                g.DrawLine(caneta, 22, 5, 22, 17);
                g.DrawLine(caneta, 22, 17, 17, 17);
            }
            return bmp;
        }

        private static Bitmap CriarIconeClientes()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen caneta = new Pen(Color.White, 2f))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
              
                g.DrawEllipse(caneta, 4, 5, 9, 9);
                g.DrawArc(caneta, 1, 16, 15, 14, 180, 180);
               
                g.DrawEllipse(caneta, 19, 5, 9, 9);
                g.DrawArc(caneta, 16, 16, 15, 14, 180, 180);
            }
            return bmp;
        }

        private static Bitmap CriarIconeProdutos()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen caneta = new Pen(Color.White, 2f))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawRectangle(caneta, 4, 10, 24, 18);  
                g.DrawLine(caneta, 4, 16, 28, 16);       
                g.DrawLine(caneta, 16, 16, 16, 28);       
                g.DrawLine(caneta, 4, 10, 8, 4);          
                g.DrawLine(caneta, 28, 10, 24, 4);
                g.DrawLine(caneta, 8, 4, 24, 4);
            }
            return bmp;
        }

        private static Bitmap CriarIconeVendas()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen caneta = new Pen(Color.White, 2f))
            using (Font fonte = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.DrawEllipse(caneta, 2, 2, 27, 27);
                g.DrawString("$", fonte, Brushes.White, 8, 6);
            }
            return bmp;
        }

        private static Bitmap CriarIconeRelatorios()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(Brushes.White, 4, 18, 7, 11);
                g.FillRectangle(Brushes.White, 13, 10, 7, 19);
                g.FillRectangle(Brushes.White, 22, 3, 7, 26);
            }
            return bmp;
        }
    }
}
