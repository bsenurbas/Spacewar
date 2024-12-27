using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spacewar
{
    public class Spaceship
    {
        // Oyuncunun kontrol ettiği uzay gemisinin görsel temsilcisi
        public PictureBox PictureBox { get; private set; }

        // Uzay gemisinin koordinatlarını tutan değişkenler
        private int x, y;

        // Uzay gemisinin x ve y eksenlerindeki hızları
        private int speedX = 0;
        private int speedY = 0;

        // Constructor: Uzay gemisini tanımlayan yapılandırıcı
        public Spaceship(PictureBox pictureBox, PictureBox parent)
        {
            this.PictureBox = pictureBox; // Uzay gemisinin görsel öğesi atanıyor
            this.x = pictureBox.Location.X; // Başlangıç X koordinatı
            this.y = pictureBox.Location.Y; // Başlangıç Y koordinatı

            // Uzay gemisinin arka planı şeffaf yapılıyor
            this.PictureBox.BackColor = Color.Transparent;

            // Uzay gemisi için parent olarak arka plan atanıyor
            this.PictureBox.Parent = parent;
        }

        // Uzay gemisini ekranda hareket ettiren metot
        public void Move(int formWidth, int formHeight, int speedX, int speedY)
        {
            // Hareket hesaplaması
            x += speedX; // X eksenindeki hareket
            y += speedY; // Y eksenindeki hareket

            // Uzay gemisinin ekranın dışına çıkmasını önleme
            x = Math.Max(0, Math.Min(formWidth - PictureBox.Width, x)); // X sınır kontrolü
            y = Math.Max(0, Math.Min(formHeight - PictureBox.Height, y)); // Y sınır kontrolü

            // Uzay gemisinin yeni konumunu ayarla
            PictureBox.Location = new Point(x, y);
        }

        // Uzay gemisinin hareket hızını ayarlayan metot
        public void SetSpeed(int xSpeed, int ySpeed)
        {
            speedX = xSpeed; // X ekseni hızı
            speedY = ySpeed; // Y ekseni hızı
        }
    }
}
