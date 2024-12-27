using Spacewar;
using System.Windows.Forms;
using System;

public static class EnemyFactory
{
    // Rastgele düşman konumu ve türü seçmek için Random nesnesi
    private static Random rnd = new Random();

    // Rastgele bir düşman oluşturan metot
    public static Enemy CreateRandomEnemy(int formWidth, PictureBox parent, int level)
    {
        // Rastgele X koordinatı (form genişliğine bağlı)
        int randomX = rnd.Next(0, formWidth - 50);

        // Rastgele düşman türü seçimi (1-100 arası rastgele sayı)
        int randomEnemyType = rnd.Next(1, 101);

        // Düşman türünü seç ve seviyeyle uyumlu özellikler ata
        if (randomEnemyType <= 50)
        {
            // Basit düşman: Sağlık seviyeyle artar
            return new BasicEnemy(randomX, parent) { Health = 20 + level * 5 };
        }
        else if (randomEnemyType <= 75)
        {
            // Hızlı düşman: Hızı seviyeyle artar
            return new FastEnemy(randomX, parent) { MoveSpeed = 5 + level };
        }
        else if (randomEnemyType <= 95)
        {
            // Güçlü düşman: Sağlığı seviyeyle artar
            return new StrongEnemy(randomX, parent) { Health = 30 + level * 10 };
        }
        else
        {
            // Boss düşman: Sağlık seviyeyle çok daha fazla artar
            return new BossEnemy(randomX, parent) { Health = 50 + level * 20 };
        }
    }
}
