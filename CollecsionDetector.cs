using System;
using System.Collections.Generic;

namespace Spacewar
{
    public class CollectionDetector
    {
        // Mermi ve düşman çarpışmalarını tespit eden ve işlemleri yöneten metot
        public void DetectBulletEnemyCollision(List<Bullet> bullets, List<Enemy> enemies, ref int score)
        {
            // Mermiler arasında geriye doğru döngü
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Move(); // Mermiyi yukarı doğru hareket ettir

                // Düşmanlar arasında geriye doğru döngü
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    // Eğer mermi ve düşman çarpışırsa
                    if (bullets[i].PictureBox.Bounds.IntersectsWith(enemies[j].PictureBox.Bounds))
                    {
                        bullets[i].Destroy(); // Mermiyi yok et
                        enemies[j].TakeDamage(bullets[i].Damage); // Düşmana merminin verdiği hasarı uygula

                        // Eğer düşman yok olursa
                        if (enemies[j].IsDestroyed)
                        {
                            score += enemies[j].Points; // Skora düşmanın puanını ekle
                            enemies[j].Destroy(); // Düşmanı yok et
                            enemies.RemoveAt(j); // Düşmanı listeden kaldır
                        }

                        bullets.RemoveAt(i); // Mermiyi listeden kaldır
                        break; // Çarpışma olduğu için bu mermi için döngüyü kır
                    }
                }
            }
        }

        // Oyuncu (uzay gemisi) ve düşman çarpışmasını tespit eden metot
        public bool DetectPlayerEnemyCollision(Spaceship player, List<Enemy> enemies)
        {
            // Tüm düşmanlar üzerinde döngü
            foreach (var enemy in enemies)
            {
                // Eğer oyuncunun uzay gemisi bir düşmanla çarpışırsa
                if (player.PictureBox.Bounds.IntersectsWith(enemy.PictureBox.Bounds))
                {
                    return true; // Çarpışma tespit edildi
                }
            }
            return false; // Çarpışma yok
        }

        // Ekranın dışına çıkan mermileri ve düşmanları temizleyen metot
        public void CleanupOffScreenObjects(List<Bullet> bullets, List<Enemy> enemies, int formHeight)
        {
            // Ekranın üstünden çıkan mermileri temizle
            bullets.RemoveAll(bullet => bullet.PictureBox.Top < 0);

            // Ekranın altından çıkan düşmanları temizle
            enemies.RemoveAll(enemy => enemy.PictureBox.Top > formHeight);
        }
    }
}
