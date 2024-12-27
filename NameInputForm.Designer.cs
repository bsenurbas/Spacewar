namespace Spacewar
{
    partial class NameInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.buttonSumbit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(243, 127);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(289, 29);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Enter your nickname : ";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(268, 173);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(220, 22);
            this.txtPlayerName.TabIndex = 1;
            // 
            // buttonSumbit
            // 
            this.buttonSumbit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSumbit.Location = new System.Drawing.Point(397, 214);
            this.buttonSumbit.Name = "buttonSumbit";
            this.buttonSumbit.Size = new System.Drawing.Size(111, 50);
            this.buttonSumbit.TabIndex = 2;
            this.buttonSumbit.Text = "Start";
            this.buttonSumbit.UseVisualStyleBackColor = true;
            this.buttonSumbit.Click += new System.EventHandler(this.buttonSumbit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCancel.Location = new System.Drawing.Point(248, 214);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 50);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // NameInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSumbit);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.labelName);
            this.Name = "NameInputForm";
            this.Text = "NameInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button buttonSumbit;
        private System.Windows.Forms.Button buttonCancel;
    }
}