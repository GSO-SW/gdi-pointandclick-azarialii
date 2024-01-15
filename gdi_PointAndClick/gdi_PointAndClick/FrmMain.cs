using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            //Farben 
            var rand = new Random();
            // Zeichenmittel
            Brush b = new SolidBrush(Color.FromArgb(rand.Next(0,256), rand.Next(0, 256), 0));


            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(b, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
       
            
            Point mausposition = e.Location;
            bool RechtangleContains= false;
            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i].Contains(mausposition))
                {
                    RechtangleContains = true;
                     break;
                }
               
            }
            if (RechtangleContains==false)
            {
                var rand = new Random();
                int RechtangleSize = rand.Next(0, 50);
                Rectangle r = new Rectangle(mausposition.X -(RechtangleSize/2), mausposition.Y - (RechtangleSize/2), RechtangleSize, RechtangleSize);

                rectangles.Add(r);  // Kurze Variante: rectangles.Add( new Rectangle(...)  );

                Refresh();
            }
            if (e.Button == MouseButtons.Left)
            {
                
                    for (int i = 0; i < rectangles.Count; i++)
                    {
                        if (rectangles[i].Contains(mausposition))
                        {
                        rectangles.Remove(rectangles[i]);
                            break;
                        }

                    }
                
            }

        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}