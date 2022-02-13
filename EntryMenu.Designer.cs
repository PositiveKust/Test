
namespace ProgrammBaseData
{
    partial class EntryMenu
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
            this.Enterbutton = new System.Windows.Forms.Button();
            this.labelWorker = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.checkPasswordBox = new System.Windows.Forms.CheckBox();
            this.EntryWorkerBox = new System.Windows.Forms.ComboBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Enterbutton
            // 
            this.Enterbutton.Location = new System.Drawing.Point(30, 161);
            this.Enterbutton.Name = "Enterbutton";
            this.Enterbutton.Size = new System.Drawing.Size(244, 37);
            this.Enterbutton.TabIndex = 0;
            this.Enterbutton.Text = "Войти";
            this.Enterbutton.UseVisualStyleBackColor = true;
            this.Enterbutton.Click += new System.EventHandler(this.Enterbutton_Click);
            // 
            // labelWorker
            // 
            this.labelWorker.AutoSize = true;
            this.labelWorker.Location = new System.Drawing.Point(36, 22);
            this.labelWorker.Name = "labelWorker";
            this.labelWorker.Size = new System.Drawing.Size(81, 17);
            this.labelWorker.TabIndex = 1;
            this.labelWorker.Text = "Должность";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(37, 83);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(57, 17);
            this.Password.TabIndex = 2;
            this.Password.Text = "Пароль";
            // 
            // checkPasswordBox
            // 
            this.checkPasswordBox.AutoSize = true;
            this.checkPasswordBox.Location = new System.Drawing.Point(256, 113);
            this.checkPasswordBox.Name = "checkPasswordBox";
            this.checkPasswordBox.Size = new System.Drawing.Size(18, 17);
            this.checkPasswordBox.TabIndex = 3;
            this.checkPasswordBox.UseVisualStyleBackColor = true;
            this.checkPasswordBox.CheckedChanged += new System.EventHandler(this.checkPasswordBox_CheckedChanged);
            // 
            // EntryWorkerBox
            // 
            this.EntryWorkerBox.FormattingEnabled = true;
            this.EntryWorkerBox.Items.AddRange(new object[] {
            "Оператор базы",
            "Менеджер",
            "Инженер",
            "Сотрудник отдела снабжения",
            "Сотрудник отдела сбыта"});
            this.EntryWorkerBox.Location = new System.Drawing.Point(37, 48);
            this.EntryWorkerBox.Name = "EntryWorkerBox";
            this.EntryWorkerBox.Size = new System.Drawing.Size(237, 24);
            this.EntryWorkerBox.TabIndex = 4;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(38, 113);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(212, 22);
            this.PasswordBox.TabIndex = 5;
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // EntryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 226);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.EntryWorkerBox);
            this.Controls.Add(this.checkPasswordBox);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.labelWorker);
            this.Controls.Add(this.Enterbutton);
            this.Name = "EntryMenu";
            this.Text = "EntryMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Enterbutton;
        private System.Windows.Forms.Label labelWorker;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.CheckBox checkPasswordBox;
        private System.Windows.Forms.ComboBox EntryWorkerBox;
        private System.Windows.Forms.TextBox PasswordBox;
    }
}