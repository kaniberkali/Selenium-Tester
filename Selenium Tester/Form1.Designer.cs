
namespace Selenium_Tester
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Metotlar = new System.Windows.Forms.ListBox();
            this.metot_veri = new System.Windows.Forms.TextBox();
            this.Kod = new System.Windows.Forms.TextBox();
            this.veri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Tür = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.elements = new System.Windows.Forms.RadioButton();
            this.element = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Console = new System.Windows.Forms.ListBox();
            this.test_et = new System.Windows.Forms.Button();
            this.kopyala = new System.Windows.Forms.Button();
            this.kodeditör = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.site = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.kopyalamak = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.consoleyardimcisi = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 38);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(609, 0);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 39);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(609, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 39);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(659, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selenium Tester";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Metotlar);
            this.groupBox1.Controls.Add(this.metot_veri);
            this.groupBox1.Location = new System.Drawing.Point(9, 43);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(232, 229);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metotlar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(7, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Veri :";
            // 
            // Metotlar
            // 
            this.Metotlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Metotlar.FormattingEnabled = true;
            this.Metotlar.ItemHeight = 29;
            this.Metotlar.Items.AddRange(new object[] {
            "Click",
            "Text",
            "GetAttribute",
            "Clear",
            "Displayed",
            "Enabled",
            "GetCssValue",
            "GetHashCode",
            "GetProperty",
            "Location",
            "Selected",
            "SendKeys",
            "Size",
            "Submit",
            "TagName",
            "ToString"});
            this.Metotlar.Location = new System.Drawing.Point(4, 34);
            this.Metotlar.Margin = new System.Windows.Forms.Padding(2);
            this.Metotlar.Name = "Metotlar";
            this.Metotlar.Size = new System.Drawing.Size(224, 149);
            this.Metotlar.TabIndex = 3;
            // 
            // metot_veri
            // 
            this.metot_veri.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.metot_veri.Location = new System.Drawing.Point(79, 187);
            this.metot_veri.Margin = new System.Windows.Forms.Padding(2);
            this.metot_veri.Name = "metot_veri";
            this.metot_veri.Size = new System.Drawing.Size(149, 35);
            this.metot_veri.TabIndex = 9;
            // 
            // Kod
            // 
            this.Kod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Kod.Location = new System.Drawing.Point(313, 167);
            this.Kod.Margin = new System.Windows.Forms.Padding(2);
            this.Kod.Multiline = true;
            this.Kod.Name = "Kod";
            this.Kod.ReadOnly = true;
            this.Kod.Size = new System.Drawing.Size(389, 37);
            this.Kod.TabIndex = 5;
            // 
            // veri
            // 
            this.veri.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.veri.Location = new System.Drawing.Point(375, 43);
            this.veri.Margin = new System.Windows.Forms.Padding(2);
            this.veri.Name = "veri";
            this.veri.Size = new System.Drawing.Size(327, 35);
            this.veri.TabIndex = 7;
            this.veri.Text = "//span[@id=\'wsite-title\']";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.Location = new System.Drawing.Point(240, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kod :";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(382, 3);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(49, 35);
            this.count.TabIndex = 11;
            this.count.Text = "0";
            this.count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.count_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "drv.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(436, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "]";
            // 
            // Tür
            // 
            this.Tür.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tür.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Tür.FormattingEnabled = true;
            this.Tür.Items.AddRange(new object[] {
            "XPath",
            "Id",
            "CssSelector",
            "Name",
            "LinkText",
            "ClassName",
            "PartialLinkText",
            "TagName"});
            this.Tür.Location = new System.Drawing.Point(245, 47);
            this.Tür.Margin = new System.Windows.Forms.Padding(2);
            this.Tür.Name = "Tür";
            this.Tür.Size = new System.Drawing.Size(126, 28);
            this.Tür.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "drv.";
            // 
            // elements
            // 
            this.elements.AutoSize = true;
            this.elements.Location = new System.Drawing.Point(47, 1);
            this.elements.Name = "elements";
            this.elements.Size = new System.Drawing.Size(335, 33);
            this.elements.TabIndex = 10;
            this.elements.Text = "FindElemets(By.Xpath(\"\")[";
            this.elements.UseVisualStyleBackColor = true;
            // 
            // element
            // 
            this.element.AutoSize = true;
            this.element.Checked = true;
            this.element.Location = new System.Drawing.Point(48, 43);
            this.element.Name = "element";
            this.element.Size = new System.Drawing.Size(314, 33);
            this.element.TabIndex = 18;
            this.element.TabStop = true;
            this.element.Text = "FindElemet(By.Xpath(\"\")";
            this.element.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Console);
            this.groupBox3.Location = new System.Drawing.Point(9, 277);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(693, 160);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Console";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.Color.Black;
            this.Console.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Console.ForeColor = System.Drawing.Color.Lime;
            this.Console.FormattingEnabled = true;
            this.Console.ItemHeight = 20;
            this.Console.Items.AddRange(new object[] {
            "website : https://kodzamani.weebly.com",
            "instagram : @kaniberkali, @kodzamani.tk"});
            this.Console.Location = new System.Drawing.Point(4, 32);
            this.Console.Margin = new System.Windows.Forms.Padding(2);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(681, 124);
            this.Console.TabIndex = 3;
            this.Console.SelectedIndexChanged += new System.EventHandler(this.Console_SelectedIndexChanged);
            // 
            // test_et
            // 
            this.test_et.Location = new System.Drawing.Point(478, 209);
            this.test_et.Name = "test_et";
            this.test_et.Size = new System.Drawing.Size(224, 38);
            this.test_et.TabIndex = 19;
            this.test_et.Text = "Test Et";
            this.test_et.UseVisualStyleBackColor = true;
            this.test_et.Click += new System.EventHandler(this.test_et_Click);
            // 
            // kopyala
            // 
            this.kopyala.Location = new System.Drawing.Point(245, 209);
            this.kopyala.Name = "kopyala";
            this.kopyala.Size = new System.Drawing.Size(227, 38);
            this.kopyala.TabIndex = 20;
            this.kopyala.Text = "Kopyala";
            this.kopyala.UseVisualStyleBackColor = true;
            this.kopyala.Click += new System.EventHandler(this.kopyala_Click);
            // 
            // kodeditör
            // 
            this.kodeditör.Tick += new System.EventHandler(this.kodeditör_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(7, 442);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(302, 33);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Chrome.Visible = True;";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // site
            // 
            this.site.Location = new System.Drawing.Point(245, 252);
            this.site.Name = "site";
            this.site.Size = new System.Drawing.Size(397, 35);
            this.site.TabIndex = 23;
            this.site.Text = "https://kodzamani.weebly.com";
            this.site.KeyUp += new System.Windows.Forms.KeyEventHandler(this.site_KeyUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(644, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 38);
            this.button2.TabIndex = 24;
            this.button2.Text = "Git";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // kopyalamak
            // 
            this.kopyalamak.AutoSize = true;
            this.kopyalamak.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kopyalamak.Location = new System.Drawing.Point(315, 444);
            this.kopyalamak.Name = "kopyalamak";
            this.kopyalamak.Size = new System.Drawing.Size(382, 28);
            this.kopyalamak.TabIndex = 25;
            this.kopyalamak.Text = "Kopyalanan                    otomatik getir";
            this.kopyalamak.UseVisualStyleBackColor = true;
            this.kopyalamak.CheckedChanged += new System.EventHandler(this.kopyalamak_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.Location = new System.Drawing.Point(457, 431);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(80, 29);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "siteyi";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton2.Location = new System.Drawing.Point(451, 454);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(111, 29);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "elementi";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // consoleyardimcisi
            // 
            this.consoleyardimcisi.BackColor = System.Drawing.Color.Black;
            this.consoleyardimcisi.Dock = System.Windows.Forms.DockStyle.Left;
            this.consoleyardimcisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.consoleyardimcisi.ForeColor = System.Drawing.Color.Lime;
            this.consoleyardimcisi.Location = new System.Drawing.Point(0, 38);
            this.consoleyardimcisi.Multiline = true;
            this.consoleyardimcisi.Name = "consoleyardimcisi";
            this.consoleyardimcisi.ReadOnly = true;
            this.consoleyardimcisi.Size = new System.Drawing.Size(705, 446);
            this.consoleyardimcisi.TabIndex = 4;
            this.consoleyardimcisi.Text = "website : https://kodzamani.weebly.com\r\ninstagram : @kaniberkali, @kodzamani.tk\r\n" +
    "";
            this.consoleyardimcisi.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Lime;
            this.button3.Location = new System.Drawing.Point(659, 38);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "_";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.elements);
            this.panel2.Controls.Add(this.element);
            this.panel2.Controls.Add(this.count);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(245, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 77);
            this.panel2.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 484);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.consoleyardimcisi);
            this.Controls.Add(this.site);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.kopyalamak);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.kopyala);
            this.Controls.Add(this.test_et);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Tür);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.veri);
            this.Controls.Add(this.Kod);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selenium Tester";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Kod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox metot_veri;
        private System.Windows.Forms.TextBox veri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox count;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Tür;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton elements;
        private System.Windows.Forms.RadioButton element;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.Button test_et;
        private System.Windows.Forms.Button kopyala;
        private System.Windows.Forms.Timer kodeditör;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox site;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox kopyalamak;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ListBox Metotlar;
        private System.Windows.Forms.TextBox consoleyardimcisi;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

