using System.Drawing;
using System.Windows.Forms;

namespace Spacewar
{
    // Düşmanları temsil eden soyut sınıf (abstract class)
    public abstract class Enemy
    {
        // Düşmanın görsel temsilcisi olan PictureBox
        public PictureBox PictureBox { get; protected set; }

        // Düşmanın sağlık değeri
        public int Health { get; set; }

        // Düşmanın yenildiğinde verdiği puan
        public int Points { get; protected set; }

        // Düşmanın hareket hızı
        public int MoveSpeed { get; set; }

        // Constructor: Yeni bir düşman oluşturur
        protected Enemy(int x, int y, int width, int height, int health, int points, Control parent)
        {
            // Düşmanın görsel özelliklerini tanımlayan PictureBox
            PictureBox = new PictureBox
            {
                Size = new Size(width, height), // Düşmanın boyutu
                Location = new Point(x, y), // Düşmanın başlangıç konumu
                BackColor = Color.Transparent, // Arka plan şeffaf
                Image = Spacewar.Properties.Resources.ufo, // Varsayılan düşman görüntüsü
                SizeMode = PictureBoxSizeMode.StretchImage, // Görüntü boyutlandırması
                Parent = parent // Parent olarak sahne (genelde galaxy resmi) atanır
            };

            // Düşmanın özelliklerini ayarla
            this.Health = health; // Sağlık puanı
            this.Points = points; // Yenildiğinde verilen puan
            this.MoveSpeed = 1; // Varsayılan hareket hızı
            PictureBox.BringToFront(); // Düşmanı ön plana getir
        }

        // Düşmanın hareket mantığını tanımlayan soyut metot
        public abstract void Move();

        // Düşman hasar aldığında çağrılır
        public void TakeDamage(int damage)
        {
            Health -= damage; // Sağlık değerini azalt
        }

        // Düşmanın yok olma durumunu kontrol eder
        public bool IsDestroyed => Health <= 0;

        // Düşmanı sahneden ve bellekten kaldırır
        public void Destroy()
        {
            if (PictureBox?.Parent != null)
            {
                PictureBox.Parent.Controls.Remove(PictureBox); // Parent kontrolünden çıkar
            }
            PictureBox?.Dispose(); // Kaynağı serbest bırak
        }
    }
}
