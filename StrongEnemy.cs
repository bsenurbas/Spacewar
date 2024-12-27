using System.Drawing;
using System.Windows.Forms;

namespace Spacewar
{
    // Oyundaki güçlü düşmanı temsil eden sınıf
    public class StrongEnemy : Enemy
    {
        // Constructor: Yeni bir güçlü düşman oluşturur
        public StrongEnemy(int x, Control parent)
            : base(x, 0, 50, 50, 3, 30, parent) // Enemy sınıfının yapıcı metoduna parametreler gönderilir
        {
            // Güçlü düşman için görsel ayarları yap
            PictureBox.Image = Spacewar.Properties.Resources.ufo__1_; // Güçlü düşman için özel bir UFO resmi
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Görüntü boyutlandırılır
            Health = 30; // Sağlık değeri (yüksek)
            Points = 20; // Yenildiğinde kazandırdığı puan
            PictureBox.BringToFront(); // Düşmanı ön plana getir
        }

        // Güçlü düşmanın hareket mantığını tanımlayan metot
        public override void Move()
        {
            // Güçlü düşman her çağrıldığında 1 piksel aşağı hareket eder
            PictureBox.Top += 1;
        }
    }
}
