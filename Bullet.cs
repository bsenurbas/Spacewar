using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spacewar
{
    public class Bullet
    {
        // Merminin görsel temsilcisi olan PictureBox
        public PictureBox PictureBox { get; private set; }

        // Merminin verdiği hasar miktarı
        public int Damage { get; } = 10;

        // Merminin boyut ve konum bilgilerini döndüren özellik
        public Rectangle Bounds => PictureBox.Bounds;

        // Constructor: Yeni bir mermi oluşturur
        public Bullet(int x, int y, PictureBox parent)
        {
            // Mermi için yeni bir PictureBox tanımlanır
            PictureBox = new PictureBox
            {
                Size = new Size(10, 20), // Merminin boyutu (genişlik x yükseklik)
                Location = new Point(x, y), // Başlangıç konumu
                BackColor = Color.Transparent, // Arka plan şeffaf
                Image = Properties.Resources.laser, // Mermi görüntüsü atanır
                SizeMode = PictureBoxSizeMode.StretchImage, // Görüntü boyutlandırılır
                Parent = parent // Parent olarak, oyun sahnesini temsil eden PictureBox atanır
            };

            PictureBox.BringToFront(); // Mermiyi ön plana getir
        }

        // Mermiyi yukarı hareket ettiren metot
        public void Move()
        {
            PictureBox.Top -= 10; // Mermiyi yukarı doğru 10 piksel hareket ettir
        }

        // Mermiyi yok eden metot
        public void Destroy()
        {
            if (PictureBox?.Parent != null)
            {
                // Parent kontrolünden mermiyi kaldır
                PictureBox.Parent.Controls.Remove(PictureBox);
            }

            // PictureBox nesnesini bellekten serbest bırak
            PictureBox?.Dispose();
        }

        // Yeni bir mermi oluşturan statik metot
        public static Bullet Create_Bullet(Spaceship player, PictureBox parent)
        {
            // Oyuncu nesnesi null ise hata fırlat
            if (player == null)
                throw new ArgumentNullException(nameof(player), "Spaceship null olamaz.");

            // Parent nesnesi null ise hata fırlat
            if (parent == null)
                throw new ArgumentNullException(nameof(parent), "Parent null olamaz.");

            // Merminin başlangıç X konumu: Uzay gemisinin ortası
            int x = player.PictureBox.Location.X + (player.PictureBox.Width / 2) - 5;

            // Merminin başlangıç Y konumu: Uzay gemisinin üstü
            int y = player.PictureBox.Location.Y - 20;

            // Yeni bir mermi nesnesi oluştur ve döndür
            return new Bullet(x, y, parent);
        }
    }
}
