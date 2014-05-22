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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.генерацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.икосаэдрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кубToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимОтображенияПолигоновToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.тесселяцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нормализацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пересчитатьНормалиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перевернутьНормалиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.удратьИндексациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.glControl1.Size = new System.Drawing.Size(607, 352);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(607, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(607, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.видToolStripMenuItem,
            this.генерацияToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(607, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
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
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
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
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // генерацияToolStripMenuItem
            // 
            this.генерацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.икосаэдрToolStripMenuItem,
            this.кубToolStripMenuItem,
            this.toolStripSeparator1,
            this.тесселяцияToolStripMenuItem,
            this.нормализацияToolStripMenuItem,
            this.пересчитатьНормалиToolStripMenuItem,
            this.перевернутьНормалиToolStripMenuItem,
            this.удратьИндексациюToolStripMenuItem});
            this.генерацияToolStripMenuItem.Name = "генерацияToolStripMenuItem";
            this.генерацияToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.генерацияToolStripMenuItem.Text = "Генерация";
            this.генерацияToolStripMenuItem.Click += new System.EventHandler(this.генерацияToolStripMenuItem_Click);
            // 
            // икосаэдрToolStripMenuItem
            // 
            this.икосаэдрToolStripMenuItem.Name = "икосаэдрToolStripMenuItem";
            this.икосаэдрToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.икосаэдрToolStripMenuItem.Text = "Икосаэдр";
            this.икосаэдрToolStripMenuItem.Click += new System.EventHandler(this.икосаэдрToolStripMenuItem_Click);
            // 
            // кубToolStripMenuItem
            // 
            this.кубToolStripMenuItem.Name = "кубToolStripMenuItem";
            this.кубToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.кубToolStripMenuItem.Text = "Куб";
            this.кубToolStripMenuItem.Click += new System.EventHandler(this.кубToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимОтображенияПолигоновToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            this.видToolStripMenuItem.Click += new System.EventHandler(this.видToolStripMenuItem_Click);
            // 
            // режимОтображенияПолигоновToolStripMenuItem
            // 
            this.режимОтображенияПолигоновToolStripMenuItem.Name = "режимОтображенияПолигоновToolStripMenuItem";
            this.режимОтображенияПолигоновToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.режимОтображенияПолигоновToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.режимОтображенияПолигоновToolStripMenuItem.Text = "Режим отображения полигонов";
            this.режимОтображенияПолигоновToolStripMenuItem.Click += new System.EventHandler(this.режимОтображенияПолигоновToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // тесселяцияToolStripMenuItem
            // 
            this.тесселяцияToolStripMenuItem.Name = "тесселяцияToolStripMenuItem";
            this.тесселяцияToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.тесселяцияToolStripMenuItem.Text = "Тесселяция";
            this.тесселяцияToolStripMenuItem.Click += new System.EventHandler(this.тесселяцияToolStripMenuItem_Click);
            // 
            // нормализацияToolStripMenuItem
            // 
            this.нормализацияToolStripMenuItem.Name = "нормализацияToolStripMenuItem";
            this.нормализацияToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.нормализацияToolStripMenuItem.Text = "Нормализация";
            this.нормализацияToolStripMenuItem.Click += new System.EventHandler(this.нормализацияToolStripMenuItem_Click);
            // 
            // пересчитатьНормалиToolStripMenuItem
            // 
            this.пересчитатьНормалиToolStripMenuItem.Name = "пересчитатьНормалиToolStripMenuItem";
            this.пересчитатьНормалиToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.пересчитатьНормалиToolStripMenuItem.Text = "Пересчитать нормали";
            this.пересчитатьНормалиToolStripMenuItem.Click += new System.EventHandler(this.пересчитатьНормалиToolStripMenuItem_Click);
            // 
            // перевернутьНормалиToolStripMenuItem
            // 
            this.перевернутьНормалиToolStripMenuItem.Name = "перевернутьНормалиToolStripMenuItem";
            this.перевернутьНормалиToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.перевернутьНормалиToolStripMenuItem.Text = "Перевернуть нормали";
            this.перевернутьНормалиToolStripMenuItem.Click += new System.EventHandler(this.перевернутьНормалиToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // удратьИндексациюToolStripMenuItem
            // 
            this.удратьИндексациюToolStripMenuItem.Name = "удратьИндексациюToolStripMenuItem";
            this.удратьИндексациюToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.удратьИндексациюToolStripMenuItem.Text = "Убрать индексацию";
            this.удратьИндексациюToolStripMenuItem.Click += new System.EventHandler(this.удратьИндексациюToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 429);
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
    }
}

