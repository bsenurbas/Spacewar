namespace Spacewar
{
    partial class Game
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxGalaxy = new System.Windows.Forms.PictureBox();
            this.timerPlayer = new System.Windows.Forms.Timer(this.components);
            this.timerEnemyCreate = new System.Windows.Forms.Timer(this.components);
            this.timerEnemy = new System.Windows.Forms.Timer(this.components);
            this.timerBulletControl = new System.Windows.Forms.Timer(this.components);
            this.timerBulletAttack = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxSpaceship = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.obstacleMoveTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalaxy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpaceship)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGalaxy
            // 
            this.pictureBoxGalaxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGalaxy.Image = global::Spacewar.Properties.Resources.uzay01;
            this.pictureBoxGalaxy.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGalaxy.Name = "pictureBoxGalaxy";
            this.pictureBoxGalaxy.Size = new System.Drawing.Size(591, 587);
            this.pictureBoxGalaxy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGalaxy.TabIndex = 0;
            this.pictureBoxGalaxy.TabStop = false;
            // 
            // timerPlayer
            // 
            this.timerPlayer.Tick += new System.EventHandler(this.timerPlayer_Tick);
            // 
            // timerEnemyCreate
            // 
            this.timerEnemyCreate.Interval = 2000;
            this.timerEnemyCreate.Tick += new System.EventHandler(this.timerEnemyCreate_Tick);
            // 
            // timerEnemy
            // 
            this.timerEnemy.Tick += new System.EventHandler(this.timerEnemy_Tick);
            // 
            // timerBulletControl
            // 
            this.timerBulletControl.Tick += new System.EventHandler(this.timerBulletControl_Tick);
            // 
            // timerBulletAttack
            // 
            this.timerBulletAttack.Tick += new System.EventHandler(this.timerBulletAttack_Tick);
            // 
            // pictureBoxSpaceship
            // 
            this.pictureBoxSpaceship.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSpaceship.Image = global::Spacewar.Properties.Resources.spaceship;
            this.pictureBoxSpaceship.Location = new System.Drawing.Point(240, 423);
            this.pictureBoxSpaceship.Name = "pictureBoxSpaceship";
            this.pictureBoxSpaceship.Size = new System.Drawing.Size(113, 133);
            this.pictureBoxSpaceship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSpaceship.TabIndex = 2;
            this.pictureBoxSpaceship.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelScore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelScore.Location = new System.Drawing.Point(23, 19);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(0, 29);
            this.labelScore.TabIndex = 3;
            // 
            // obstacleMoveTimer
            // 
            this.obstacleMoveTimer.Tick += new System.EventHandler(this.obstacleMoveTimer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Spacewar.Properties.Resources.uzay01;
            this.ClientSize = new System.Drawing.Size(591, 587);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBoxSpaceship);
            this.Controls.Add(this.pictureBoxGalaxy);
            this.Name = "Game";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalaxy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpaceship)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGalaxy;
        private System.Windows.Forms.Timer timerPlayer;
        private System.Windows.Forms.Timer timerEnemyCreate;
        private System.Windows.Forms.Timer timerEnemy;
        private System.Windows.Forms.Timer timerBulletControl;
        private System.Windows.Forms.Timer timerBulletAttack;
        private System.Windows.Forms.PictureBox pictureBoxSpaceship;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer obstacleMoveTimer;
    }
}

