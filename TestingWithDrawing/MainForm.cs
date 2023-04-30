namespace NeuralNetworkTesting
{
    public partial class MainForm : Form
    {
        private Point? lastPoint;
        private Bitmap bitmap;
        private Graphics graphics;

        public MainForm()
        {
            InitializeComponent();

            bitmap = new Bitmap(pbImage.Width, pbImage.Height);
            graphics = Graphics.FromImage(bitmap);
        }

        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = null;
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lastPoint != null)
                {
                    graphics.DrawLine(Pens.Black, lastPoint.Value, e.Location);
                    lastPoint = e.Location;
                    pbImage.Invalidate();
                }
            }
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}