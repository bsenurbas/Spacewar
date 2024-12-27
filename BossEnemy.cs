using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Spacewar
{
    // Oyundaki büyük ve güçlü düşmanı temsil eden sınıf
    public class BossEnemy : Enemy
    {
        // Constructor: Yeni bir Boss düşmanı oluşturur
        public BossEnemy(int x, Control parent)
             : base(x, 0, 80, 80, 5, 50, parent) // Enemy sınıfının yapıcı metoduna parametreler gönderilir
        {
            // Boss düşman için görsel ayarları yap
            PictureBox.Image = Properties.Resources.ufo__2_; // Boss düşman için farklı bir UFO resmi
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Resim boyutlandırılır
            Health = 50; // Boss düşmanın sağlık değeri
            Points = 50; // Boss düşmanın yenildiğinde kazandırdığı puan
            PictureBox.BringToFront(); // Düşmanı ön plana getir
        }

        // Boss düşmanın hareket mantığını tanımlayan metot
        public override void Move()
        {
            // Boss düşman her çağrıldığında çok yavaş hareket eder (1 piksel aşağı)
            PictureBox.Top += 1;
        }
    }
}
