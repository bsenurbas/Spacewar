using System.Drawing;
using System.Windows.Forms;

namespace Spacewar
{
    // Oyundaki hızlı düşmanı temsil eden sınıf
    public class FastEnemy : Enemy
    {
        // Constructor: Yeni bir hızlı düşman oluşturur
        public FastEnemy(int x, Control parent)
            : base(x, 0, 40, 40, 1, 20, parent) // Enemy sınıfının yapıcı metoduna parametreler gönderilir
        {
            // Hızlı düşman için görsel ayarları yap
            PictureBox.Image = Spacewar.Properties.Resources.ufo__3_; // Hızlı düşman için özel bir UFO resmi
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Görüntü boyutlandırılır
            Health = 10; // Sağlık değeri (düşük)
            Points = 30; // Yenildiğinde kazandırdığı puan
            PictureBox.BringToFront(); // Düşmanı ön plana getir
            this.MoveSpeed = 5; // Hareket hızı (yüksek)
        }

        // Hızlı düşmanın hareket mantığını tanımlayan metot
        public override void Move()
        {
            // Hızlı düşman her çağrıldığında 5 piksel aşağı hareket eder
            PictureBox.Top += MoveSpeed;
        }
    }
}
