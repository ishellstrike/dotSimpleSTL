namespace SimpleSTL
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glControl1 = new OpenTK.GLControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимОтображенияПолигоновToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сеткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заливкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.смешанныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестAOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генерацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.икосаэдрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кубToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.тесселяцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нормализацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пересчитатьНормалиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перевернутьНормалиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удратьИндексациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.удалениеНевидимыхГранейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пересчетAOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сбросAOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеВнутреннихПолигоновToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логРендераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.умнаяТесселяцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(0, 52);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(711, 310);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(711, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 365);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(711, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.видToolStripMenuItem,
            this.генерацияToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.логРендераToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.открытьToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимОтображенияПолигоновToolStripMenuItem,
            this.отображениеToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            this.видToolStripMenuItem.Click += new System.EventHandler(this.видToolStripMenuItem_Click);
            // 
            // режимОтображенияПолигоновToolStripMenuItem
            // 
            this.режимОтображенияПолигоновToolStripMenuItem.Name = "режимОтображенияПолигоновToolStripMenuItem";
            this.режимОтображенияПолигоновToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.режимОтображенияПолигоновToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.режимОтображенияПолигоновToolStripMenuItem.Text = "Режим отображения полигонов";
            this.режимОтображенияПолигоновToolStripMenuItem.Click += new System.EventHandler(this.режимОтображенияПолигоновToolStripMenuItem_Click);
            // 
            // отображениеToolStripMenuItem
            // 
            this.отображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сеткаToolStripMenuItem,
            this.заливкаToolStripMenuItem,
            this.смешанныйToolStripMenuItem,
            this.тестAOToolStripMenuItem});
            this.отображениеToolStripMenuItem.Name = "отображениеToolStripMenuItem";
            this.отображениеToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.отображениеToolStripMenuItem.Text = "Режим отображения";
            // 
            // сеткаToolStripMenuItem
            // 
            this.сеткаToolStripMenuItem.Name = "сеткаToolStripMenuItem";
            this.сеткаToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сеткаToolStripMenuItem.Text = "Каркас";
            this.сеткаToolStripMenuItem.Click += new System.EventHandler(this.сеткаToolStripMenuItem_Click);
            // 
            // заливкаToolStripMenuItem
            // 
            this.заливкаToolStripMenuItem.Name = "заливкаToolStripMenuItem";
            this.заливкаToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.заливкаToolStripMenuItem.Text = "Заливка";
            this.заливкаToolStripMenuItem.Click += new System.EventHandler(this.заливкаToolStripMenuItem_Click);
            // 
            // смешанныйToolStripMenuItem
            // 
            this.смешанныйToolStripMenuItem.Name = "смешанныйToolStripMenuItem";
            this.смешанныйToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.смешанныйToolStripMenuItem.Text = "Затенение";
            this.смешанныйToolStripMenuItem.Click += new System.EventHandler(this.смешанныйToolStripMenuItem_Click);
            // 
            // тестAOToolStripMenuItem
            // 
            this.тестAOToolStripMenuItem.Name = "тестAOToolStripMenuItem";
            this.тестAOToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.тестAOToolStripMenuItem.Text = "Тест AO";
            this.тестAOToolStripMenuItem.Click += new System.EventHandler(this.тестAOToolStripMenuItem_Click);
            // 
            // генерацияToolStripMenuItem
            // 
            this.генерацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.икосаэдрToolStripMenuItem,
            this.кубToolStripMenuItem,
            this.toolStripSeparator1,
            this.тесселяцияToolStripMenuItem,
            this.умнаяТесселяцияToolStripMenuItem,
            this.нормализацияToolStripMenuItem,
            this.пересчитатьНормалиToolStripMenuItem,
            this.перевернутьНормалиToolStripMenuItem,
            this.удратьИндексациюToolStripMenuItem,
            this.toolStripSeparator2,
            this.удалениеНевидимыхГранейToolStripMenuItem,
            this.пересчетAOToolStripMenuItem,
            this.сбросAOToolStripMenuItem,
            this.удалениеВнутреннихПолигоновToolStripMenuItem,
            this.toolStripSeparator3,
            this.сохранитьToolStripMenuItem1,
            this.загрузитьToolStripMenuItem});
            this.генерацияToolStripMenuItem.Name = "генерацияToolStripMenuItem";
            this.генерацияToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.генерацияToolStripMenuItem.Text = "Работа с Mesh";
            this.генерацияToolStripMenuItem.Click += new System.EventHandler(this.генерацияToolStripMenuItem_Click);
            // 
            // икосаэдрToolStripMenuItem
            // 
            this.икосаэдрToolStripMenuItem.Name = "икосаэдрToolStripMenuItem";
            this.икосаэдрToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.икосаэдрToolStripMenuItem.Text = "Икосаэдр";
            this.икосаэдрToolStripMenuItem.Click += new System.EventHandler(this.икосаэдрToolStripMenuItem_Click);
            // 
            // кубToolStripMenuItem
            // 
            this.кубToolStripMenuItem.Name = "кубToolStripMenuItem";
            this.кубToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.кубToolStripMenuItem.Text = "Куб";
            this.кубToolStripMenuItem.Click += new System.EventHandler(this.кубToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(252, 6);
            // 
            // тесселяцияToolStripMenuItem
            // 
            this.тесселяцияToolStripMenuItem.Name = "тесселяцияToolStripMenuItem";
            this.тесселяцияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.тесселяцияToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.тесселяцияToolStripMenuItem.Text = "Тесселяция";
            this.тесселяцияToolStripMenuItem.Click += new System.EventHandler(this.тесселяцияToolStripMenuItem_Click);
            // 
            // нормализацияToolStripMenuItem
            // 
            this.нормализацияToolStripMenuItem.Name = "нормализацияToolStripMenuItem";
            this.нормализацияToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.нормализацияToolStripMenuItem.Text = "Нормализация";
            this.нормализацияToolStripMenuItem.Click += new System.EventHandler(this.нормализацияToolStripMenuItem_Click);
            // 
            // пересчитатьНормалиToolStripMenuItem
            // 
            this.пересчитатьНормалиToolStripMenuItem.Name = "пересчитатьНормалиToolStripMenuItem";
            this.пересчитатьНормалиToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.пересчитатьНормалиToolStripMenuItem.Text = "Пересчитать нормали";
            this.пересчитатьНормалиToolStripMenuItem.Click += new System.EventHandler(this.пересчитатьНормалиToolStripMenuItem_Click);
            // 
            // перевернутьНормалиToolStripMenuItem
            // 
            this.перевернутьНормалиToolStripMenuItem.Name = "перевернутьНормалиToolStripMenuItem";
            this.перевернутьНормалиToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.перевернутьНормалиToolStripMenuItem.Text = "Перевернуть нормали";
            this.перевернутьНормалиToolStripMenuItem.Click += new System.EventHandler(this.перевернутьНормалиToolStripMenuItem_Click);
            // 
            // удратьИндексациюToolStripMenuItem
            // 
            this.удратьИндексациюToolStripMenuItem.Name = "удратьИндексациюToolStripMenuItem";
            this.удратьИндексациюToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.удратьИндексациюToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.удратьИндексациюToolStripMenuItem.Text = "Убрать индексацию";
            this.удратьИндексациюToolStripMenuItem.Click += new System.EventHandler(this.удратьИндексациюToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(252, 6);
            // 
            // удалениеНевидимыхГранейToolStripMenuItem
            // 
            this.удалениеНевидимыхГранейToolStripMenuItem.Name = "удалениеНевидимыхГранейToolStripMenuItem";
            this.удалениеНевидимыхГранейToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.удалениеНевидимыхГранейToolStripMenuItem.Text = "Удаление невидимых граней";
            this.удалениеНевидимыхГранейToolStripMenuItem.Click += new System.EventHandler(this.удалениеНевидимыхГранейToolStripMenuItem_Click);
            // 
            // пересчетAOToolStripMenuItem
            // 
            this.пересчетAOToolStripMenuItem.Name = "пересчетAOToolStripMenuItem";
            this.пересчетAOToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.пересчетAOToolStripMenuItem.Text = "пересчет AO";
            this.пересчетAOToolStripMenuItem.Click += new System.EventHandler(this.пересчетAOToolStripMenuItem_Click);
            // 
            // сбросAOToolStripMenuItem
            // 
            this.сбросAOToolStripMenuItem.Name = "сбросAOToolStripMenuItem";
            this.сбросAOToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.сбросAOToolStripMenuItem.Text = "сброс AO";
            this.сбросAOToolStripMenuItem.Click += new System.EventHandler(this.сбросAOToolStripMenuItem_Click);
            // 
            // удалениеВнутреннихПолигоновToolStripMenuItem
            // 
            this.удалениеВнутреннихПолигоновToolStripMenuItem.Name = "удалениеВнутреннихПолигоновToolStripMenuItem";
            this.удалениеВнутреннихПолигоновToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.удалениеВнутреннихПолигоновToolStripMenuItem.Text = "Удаление внутренних полигонов";
            this.удалениеВнутреннихПолигоновToolStripMenuItem.Click += new System.EventHandler(this.удалениеВнутреннихПолигоновToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(252, 6);
            // 
            // сохранитьToolStripMenuItem1
            // 
            this.сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            this.сохранитьToolStripMenuItem1.Size = new System.Drawing.Size(255, 22);
            this.сохранитьToolStripMenuItem1.Text = "Сохранить";
            this.сохранитьToolStripMenuItem1.Click += new System.EventHandler(this.сохранитьToolStripMenuItem1_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // логРендераToolStripMenuItem
            // 
            this.логРендераToolStripMenuItem.Name = "логРендераToolStripMenuItem";
            this.логРендераToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.логРендераToolStripMenuItem.Text = "Лог рендера";
            this.логРендераToolStripMenuItem.Click += new System.EventHandler(this.логРендераToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // timer1
            // 
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(416, 52);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(295, 310);
            this.textBox1.TabIndex = 4;
            // 
            // умнаяТесселяцияToolStripMenuItem
            // 
            this.умнаяТесселяцияToolStripMenuItem.Name = "умнаяТесселяцияToolStripMenuItem";
            this.умнаяТесселяцияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.умнаяТесселяцияToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.умнаяТесселяцияToolStripMenuItem.Text = "Умная тесселяция";
            this.умнаяТесселяцияToolStripMenuItem.Click += new System.EventHandler(this.умнаяТесселяцияToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 387);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.glControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem генерацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem икосаэдрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кубToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимОтображенияПолигоновToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem тесселяцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нормализацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пересчитатьНормалиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перевернутьНормалиToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem удратьИндексациюToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem удалениеНевидимыхГранейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сеткаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заливкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem смешанныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пересчетAOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сбросAOToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem тестAOToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеВнутреннихПолигоновToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem логРендераToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem умнаяТесселяцияToolStripMenuItem;
    }
}

