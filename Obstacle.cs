using System.Drawing;
using System.Windows.Forms;

namespace Spacewar
{
    public class Obstacle
    {
        // Engel için görsel temsilci
        public PictureBox PictureBox { get; private set; }

        // Constructor: Yeni bir engel oluşturur
        public Obstacle(int x, int y, int width, int height, Control parent)
        {
            // PictureBox ile engelin boyut ve konumunu ayarla
            PictureBox = new PictureBox
            {
                Size = new Size(width, height), // Engel boyutları
                Location = new Point(x, y), // Engel konumu
                BackColor = Color.Transparent, // Arka plan şeffaf
                Image = Spacewar.Properties.Resources.rock, // Engel resmi atanır
                SizeMode = PictureBoxSizeMode.StretchImage, // Görüntü boyutlandırılır
                Parent = parent, // Ebeveyn kontrol 
            };

            PictureBox.BringToFront();
        }
    }
}
