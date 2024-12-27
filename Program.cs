using System;
using System.Windows.Forms;

namespace Spacewar
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kullanıcı adını almak için NameInputForm'u açıyoruz
            string playerName = null;
            using (NameInputForm nameForm = new NameInputForm())
            {
                if (nameForm.ShowDialog() == DialogResult.OK)
                {
                    playerName = nameForm.PlayerName; // Kullanıcı adını al
                }
                else
                {
                    // Kullanıcı adı girmediyse uygulamayı kapat
                    MessageBox.Show("You must enter a valid name to play the game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Eğer kullanıcı adı alındıysa oyunu başlat
            Application.Run(new Game(playerName)); // Oyuncu adını oyun ekranına gönder
        }
    }
}
