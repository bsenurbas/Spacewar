using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Spacewar
{
    public partial class Game : Form
    {
        private Spaceship player; // Oyuncunun kontrol ettiği uzay gemisi
        private int formHeight = 700; // Formun yüksekliği
        private int formWidth = 500;  // Formun genişliği

        // Mermiler ve düşmanlar için liste
        private List<Bullet> bullets = new List<Bullet>();
        private List<Enemy> enemies = new List<Enemy>();

        //Engller için liste
        private List<Obstacle> obstacles = new List<Obstacle>();

        // Oyuncunun hareket hızını tutan değişkenler
        int Player_speed_x = 0;
        int Player_speed_y = 0;

        // Oyuncunun skorunu ve adını tutan değişkenler
        int score = 0;
        private string playerName;

        // Oyun seviyesini ve seviye geçiş eşiğini tutan değişkenler
        private int level = 1;
        private int levelThreshold = 200;

        // Constructor: Oyunu başlatan yapılandırıcı
        public Game(string playerName)
        {
            this.playerName = playerName; // Oyuncu adını kaydet
            InitializeComponent();
            InitializeLabelScore(); // Skor ve seviye bilgisi için Label başlat
            this.Load += new EventHandler(Form1_Load); // Form yüklendiğinde çalışacak
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // Tuşa basıldığında
            this.KeyUp += new KeyEventHandler(Form1_KeyUp); // Tuş bırakıldığında
            this.KeyPreview = true; // Tuş olaylarını öncelikle yakalamayı sağlar
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Formun boyutlarını ayarla
            this.Height = formHeight;
            this.Width = formWidth;

            // Uzay gemisini başlat
            player = new Spaceship(pictureBoxSpaceship, pictureBoxGalaxy);

            // Oyuncuya hoş geldin mesajı göster
            MessageBox.Show($"Welcome, {playerName}! Get ready to play.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AddObstacles(); // Engelleri sahneye ekle

            // Timer'ı oluştur ve ayarlarını yap
            obstacleMoveTimer = new Timer
            {
                Interval = 20000 // 20 saniye (milisaniye cinsinden)
            };
            obstacleMoveTimer.Tick += obstacleMoveTimer_Tick; // Tick olayına metodu bağla
            obstacleMoveTimer.Start(); // Timer'ı başlat
        }

        // Oyuncunun klavye girişlerini işleyen metot
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 5; // Hareket hızı
            switch (e.KeyCode)
            {
                case Keys.Left: // Sol ok tuşu
                    Player_speed_x -= speed;
                    break;
                case Keys.Right: // Sağ ok tuşu
                    Player_speed_x += speed;
                    break;
                case Keys.Up: // Yukarı ok tuşu
                    Player_speed_y -= speed;
                    break;
                case Keys.Down: // Aşağı ok tuşu
                    Player_speed_y += speed;
                    break;
                case Keys.Enter: // Enter tuşu: Oyunu başlat
                    score = 0; // Skoru sıfırla
                    UpdateScoreLabel();
                    timerPlayer.Start();
                    timerBulletAttack.Start();
                    timerEnemyCreate.Start();
                    timerEnemy.Start();
                    timerBulletControl.Start();
                    break;
                case Keys.Space: // Boşluk tuşu: Mermi ateşle
                    Bullet_Create();
                    break;
            }
        }

        // Mermi oluşturma işlemini yapan metot
        public void Bullet_Create()
        {
            Bullet newBullet = Bullet.Create_Bullet(player, pictureBoxGalaxy); // Yeni bir mermi oluştur
            bullets.Add(newBullet); // Mermiyi listeye ekle
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Tuş bırakıldığında hız değişikliklerini sıfırla
            int speed = 5;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Player_speed_x -= 0;
                    break;
                case Keys.Right:
                    Player_speed_x += 0;
                    break;
                case Keys.Up:
                    Player_speed_y -= 0;
                    break;
                case Keys.Down:
                    Player_speed_y += 0;
                    break;
            }
        }

        // Oyuncuyu hareket ettiren Timer Tick metodu
        private void timerPlayer_Tick(object sender, EventArgs e)
        {
            player.Move(formWidth, formHeight, Player_speed_x, Player_speed_y); // Uzay gemisini hareket ettir

            // Engel ile çarpışma durumunda oyunu bitir
            foreach (var obstacle in obstacles)
            {
                if (player.PictureBox.Bounds.IntersectsWith(obstacle.PictureBox.Bounds))
                {
                    GameOver(); // Oyun biter
                    return; // Daha fazla kontrol yapılmaz
                }
            }
        }

        // Yeni düşmanların oluşturulmasını sağlayan Timer Tick metodu
        private void timerEnemyCreate_Tick(object sender, EventArgs e)
        {
            Enemy newEnemy = EnemyFactory.CreateRandomEnemy(this.Width, pictureBoxGalaxy, level); // Seviyeye göre düşman oluştur
            enemies.Add(newEnemy); // Listeye ekle
        }

        // Düşmanların hareketini ve çarpışmalarını kontrol eden Timer Tick metodu
        private void timerEnemy_Tick(object sender, EventArgs e)
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Move(); // Düşmanı hareket ettir

                if (enemies[i].PictureBox.Top > formHeight) // Eğer düşman ekranın altına çıkarsa
                {
                    enemies[i].Destroy(); // Düşmanı yok et
                    enemies.RemoveAt(i); // Listeden çıkar
                    continue;
                }

                // Eğer düşman oyuncuya çarparsa
                if (enemies[i].PictureBox.Bounds.IntersectsWith(player.PictureBox.Bounds))
                {
                    GameOver(); // Oyunu bitir
                    return;
                }
            }
        }

        // Mermilerin ve düşmanların hareketini kontrol eden Timer Tick metodu
        private void timerBulletControl_Tick(object sender, EventArgs e)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Move(); // Mermiyi hareket ettir

                if (bullets[i].PictureBox.Top < 0) // Eğer mermi ekranın üstüne çıkarsa
                {
                    bullets[i].Destroy(); // Mermiyi yok et
                    bullets.RemoveAt(i); // Listeden çıkar
                    continue;
                }

                // Düşmanlarla çarpışmayı kontrol et
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    if (bullets[i].PictureBox.Bounds.IntersectsWith(enemies[j].PictureBox.Bounds))
                    {
                        enemies[j].TakeDamage(bullets[i].Damage); // Düşmana hasar uygula
                        bullets[i].Destroy(); // Mermiyi yok et
                        bullets.RemoveAt(i);
                        
                        if (enemies[j].IsDestroyed) // Eğer düşman yok olursa
                        {
                            score += enemies[j].Points; // Skoru artır
                            UpdateScoreLabel(); // Skoru güncelle
                            enemies[j].Destroy(); // Düşmanı yok et
                            enemies.RemoveAt(j); // Listeden çıkar
                        }

                        break;
                    }
                }
                for (int j = bullets.Count - 1; j >= 0; j--)
                {
                    foreach (var obstacle in obstacles)
                    {
                        if (bullets[j].PictureBox.Bounds.IntersectsWith(obstacle.PictureBox.Bounds))
                        {
                            bullets[j].Destroy(); // Mermiyi yok et
                            bullets.RemoveAt(j); // Listeden çıkar
                            break;
                        }
                    }
                }
            }
        }
        private void timerBulletAttack_Tick(object sender, EventArgs e)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Move();

                if (bullets[i].PictureBox.Top < 0) // Eğer mermi ekranın üstünden çıktıysa
                {
                    bullets[i].Destroy();
                    bullets.RemoveAt(i); // Listeden kaldır
                }
            }
        }


        // Oyun sonunda skoru ve durumu kaydeden metot
        private void GameOver()
        {
            // Tüm timer'ları durdur
            timerPlayer.Stop();
            timerBulletAttack.Stop();
            timerEnemyCreate.Stop();
            timerEnemy.Stop();
            timerBulletControl.Stop();

            SaveScore(playerName, score, level); // Skoru kaydet

            // Skor ekranını göster
            ScoreForm scoreForm = new ScoreForm();
            scoreForm.ShowDialog();

            MessageBox.Show($"Game Over! Your score: {score}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit(); // Uygulamayı kapat
        }

        // Skor ve seviye bilgisi için Label başlatan metot
        private void InitializeLabelScore()
        {
            labelScore = new Label
            {
                Text = "Puan = 0", // Başlangıç skoru
                Location = new Point(10, 10), // Ekranın sol üst köşesi
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            pictureBoxGalaxy.Controls.Add(labelScore); // Label'ı arka plana ekle
            labelScore.BringToFront(); // Label'ı öne getir
        }

        // Skoru ve seviyeyi güncelleyen metot
        private void UpdateScoreLabel()
        {
            labelScore.Text = $"Puan = {score} | Level = {level}";

            // Seviye kontrolü
            if (score >= levelThreshold * level)
            {
                level++;
                IncreaseDifficulty(); // Zorluğu artır
                MessageBox.Show($"Level Up! Welcome to Level {level}", "Level Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Oyunun zorluk seviyesini artıran metot
        private void IncreaseDifficulty()
        {
            timerEnemyCreate.Interval = Math.Max(500, timerEnemyCreate.Interval - 200); // Düşman oluşturma hızını artır

            foreach (var enemy in enemies) // Tüm düşmanların hızını artır
            {
                if (enemy is FastEnemy fastEnemy)
                {
                    fastEnemy.MoveSpeed += 1;
                }
                else if (enemy is BasicEnemy basicEnemy)
                {
                    basicEnemy.MoveSpeed += 1;
                }
            }
        }
        private void SaveScore(string playerName, int score, int level)
        {
            string filePath = "scores.txt"; // Kaydedilecek dosyanın yolu
            string scoreData = $"{playerName}:{score}:{level}"; // Format: "playerName:score:level"

            // Dosyaya yazma işlemi
            using (StreamWriter sw = new StreamWriter(filePath, true)) // Ekleme modunda aç
            {
                sw.WriteLine(scoreData); // Veriyi dosyaya yaz
            }
        }

        private void obstacleMoveTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            foreach (var obstacle in obstacles)
            {
                // Rastgele yeni X ve Y koordinatları hesapla
                int newX = rnd.Next(0, formWidth - obstacle.PictureBox.Width);
                int newY = rnd.Next(0, formHeight - obstacle.PictureBox.Height);

                // Engel pozisyonunu güncelle
                obstacle.PictureBox.Location = new Point(newX, newY);
            }
        }
        private void AddObstacles()
        {
            // Örnek engeller oluştur
            Obstacle obstacle1 = new Obstacle(100, 200, 50, 20, pictureBoxGalaxy);
            Obstacle obstacle2 = new Obstacle(300, 400, 70, 30, pictureBoxGalaxy);

            // Engelleri listeye ekle
            obstacles.Add(obstacle1);
            obstacles.Add(obstacle2);

            // Engelleri sahneye ekle
            this.Controls.Add(obstacle1.PictureBox);
            this.Controls.Add(obstacle2.PictureBox);
            obstacle1.PictureBox.BringToFront();
            obstacle2.PictureBox.BringToFront();
        }
    }
}
