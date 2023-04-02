namespace PvP_SoS
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.İstek_Kontrol = new System.Windows.Forms.Timer(this.components);
            this.Mesaj_Kontrol = new System.Windows.Forms.Timer(this.components);
            this.Online_Yenile = new System.Windows.Forms.Timer(this.components);
            this.Giden_Sohbet_Kontrol = new System.Windows.Forms.Timer(this.components);
            this.Giden_Oyun_Kontrol = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 290);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Oyun Başlat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Sohbet Et";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // İstek_Kontrol
            // 
            this.İstek_Kontrol.Tick += new System.EventHandler(this.İstek_Kontrol_Tick);
            // 
            // Mesaj_Kontrol
            // 
            this.Mesaj_Kontrol.Tick += new System.EventHandler(this.Mesaj_Kontrol_Tick);
            // 
            // Online_Yenile
            // 
            this.Online_Yenile.Tick += new System.EventHandler(this.Online_Yenile_Tick);
            // 
            // Giden_Sohbet_Kontrol
            // 
            this.Giden_Sohbet_Kontrol.Tick += new System.EventHandler(this.Giden_Sohbet_Kontrol_Tick);
            // 
            // Giden_Oyun_Kontrol
            // 
            this.Giden_Oyun_Kontrol.Tick += new System.EventHandler(this.Giden_Oyun_Kontrol_Tick);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form5";
            this.Text = "Oyuncular";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer İstek_Kontrol;
        private System.Windows.Forms.Timer Mesaj_Kontrol;
        private System.Windows.Forms.Timer Online_Yenile;
        private System.Windows.Forms.Timer Giden_Sohbet_Kontrol;
        private System.Windows.Forms.Timer Giden_Oyun_Kontrol;
    }
}