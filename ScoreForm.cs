using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Spacewar
{
    // Oyuncu skorlarını listelemek için kullanılan form
    public partial class ScoreForm : Form
    {
        private string filePath = "scores.txt"; // Skorların saklandığı dosyanın yolu

        // Constructor: Formu başlatır ve skorları yükler
        public ScoreForm()
        {
            InitializeComponent();
            LoadScores(); // Skorları yükle ve listele
        }

        // Skorları listeleyen metot
        private void LoadScores()
        {
            var scores = GetSortedScores(); // Sıralı skorları al

            // Eğer hiç skor yoksa, kullanıcıya bilgi ver
            if (scores.Count == 0)
            {
                lstScores.Items.Add("No scores available yet."); // Listeye bilgi ekle
                return;
            }

            // Her bir skoru listeye ekle
            foreach (var score in scores)
            {
                lstScores.Items.Add($"{score.PlayerName} - {score.Score} (Level {score.Level})");
            }
        }

        // Skorları sıralayan ve formatını kontrol eden metot
        private List<(string PlayerName, int Score, int Level)> GetSortedScores()
        {
            // Eğer skor dosyası yoksa boş bir liste döndür
            if (!File.Exists(filePath))
            {
                return new List<(string, int, int)>();
            }

            var scores = new List<(string PlayerName, int Score, int Level)>(); // Skorları tutan liste

            // Dosyadaki her satırı oku
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(':'); // Satırı parçalarına ayır
                if (parts.Length == 3 // Satırın formatını kontrol et
                    && int.TryParse(parts[1], out int score) // Skorun geçerli bir sayı olup olmadığını kontrol et
                    && int.TryParse(parts[2], out int level)) // Seviyenin geçerli bir sayı olup olmadığını kontrol et
                {
                    scores.Add((PlayerName: parts[0], Score: score, Level: level)); // Geçerli skorları listeye ekle
                }
            }

            // Skorları sıralı şekilde döndür (önce level'e, sonra skora göre azalan sırada)
            return scores
                .OrderByDescending(s => s.Level) // Seviyeye göre sırala
                .ThenByDescending(s => s.Score) // Skora göre sırala
                .ToList();
        }

        // Formu kapatan butonun click olay metodu
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Formu kapat
        }
    }
}
