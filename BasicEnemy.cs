using System.Drawing;
using System.Windows.Forms;
using Spacewar.Properties;

namespace Spacewar
{
    // Basit düşmanı temsil eden sınıf
    public class BasicEnemy : Enemy
    {
        // Constructor: Yeni bir basit düşman oluşturur
        public BasicEnemy(int x, Control parent)
            : base(x, 0, 40, 40, 1, 10, parent) // Enemy sınıfının yapıcı metoduna parametre gönder
        {
            // Düşman için görsel ayarları yap
            PictureBox.Image = Resources.ufo; // Görsel olarak UFO resmi kullanılır
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Resim boyutlandırılır
            Health = 20; // Düşmanın sağlık değeri
            PictureBox.BringToFront(); // Düşmanı ön plana getir
            this.MoveSpeed = 2; // Düşmanın hareket hızı
        }

        // Düşmanın hareket mantığını tanımlayan metot
        public override void Move()
        {
            // Düşmanı her çağrıldığında aşağı doğru 2 piksel hareket ettir
            PictureBox.Top += MoveSpeed;
        }
    }
}
