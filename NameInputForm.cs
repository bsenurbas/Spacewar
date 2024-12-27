using System;
using System.Windows.Forms;

namespace Spacewar
{
    // Oyuncu adını almak için kullanılan giriş formu
    public partial class NameInputForm : Form
    {
        // Oyuncunun girdiği adı tutan özellik
        public string PlayerName { get; private set; }

        // Constructor: Formun başlatılması ve bileşenlerin yüklenmesi
        public NameInputForm()
        {
            InitializeComponent(); // Form bileşenlerini başlatır
        }

        // Submit (Gönder) butonuna tıklandığında çalışan olay
        private void buttonSumbit_Click(object sender, EventArgs e)
        {
            // Eğer oyuncu adı boşsa veya yalnızca boşluk içeriyorsa
            if (string.IsNullOrWhiteSpace(txtPlayerName.Text))
            {
                // Hata mesajı göster
                MessageBox.Show("Please enter a valid name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // İşlemi sonlandır
            }

            // Geçerli bir ad girildiyse, adı `PlayerName` değişkenine ata
            PlayerName = txtPlayerName.Text;

            // Formdan başarıyla çıkıldığını belirtmek için DialogResult ayarla
            this.DialogResult = DialogResult.OK;

            // Formu kapat
            this.Close();
        }

        // Cancel (İptal) butonuna tıklandığında çalışan olay
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Kullanıcı işlemi iptal ettiyse, DialogResult'ı Cancel olarak ayarla
            this.DialogResult = DialogResult.Cancel;

            // Formu kapat
            this.Close();
        }
    }
}
