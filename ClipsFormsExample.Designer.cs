namespace ClipsFormsExample
{
    partial class ClipsFormsExample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipsFormsExample));
            this.panel2 = new System.Windows.Forms.Panel();
            this.fontButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.clipsSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.codeBox = new System.Windows.Forms.RichTextBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fontButton);
            this.panel2.Controls.Add(this.nextButton);
            this.panel2.Controls.Add(this.resetButton);
            this.panel2.Controls.Add(this.saveAsButton);
            this.panel2.Controls.Add(this.openButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 470);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1317, 66);
            this.panel2.TabIndex = 6;
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(409, 14);
            this.fontButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(160, 37);
            this.fontButton.TabIndex = 9;
            this.fontButton.Text = "Шрифт...";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontSelect_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(1140, 14);
            this.nextButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(160, 37);
            this.nextButton.TabIndex = 8;
            this.nextButton.Text = "Дальше";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(972, 14);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(160, 37);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Рестарт";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(241, 14);
            this.saveAsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(160, 37);
            this.saveAsButton.TabIndex = 6;
            this.saveAsButton.Text = "Сохранить как...";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(28, 14);
            this.openButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(206, 37);
            this.openButton.TabIndex = 5;
            this.openButton.Text = "Выбрать папку с базой";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openFile_Click);
            // 
            // clipsSaveFileDialog
            // 
            this.clipsSaveFileDialog.Filter = "CLIPS files|*.clp|All files|*.*";
            this.clipsSaveFileDialog.Title = "Созранить файл как...";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Code\\CLIPSForms\\db";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.codeBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.outputBox);
            this.splitContainer1.Size = new System.Drawing.Size(1317, 470);
            this.splitContainer1.SplitterDistance = 760;
            this.splitContainer1.TabIndex = 7;
            // 
            // codeBox
            // 
            this.codeBox.BackColor = System.Drawing.Color.White;
            this.codeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeBox.Location = new System.Drawing.Point(0, 0);
            this.codeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.codeBox.Name = "codeBox";
            this.codeBox.ReadOnly = true;
            this.codeBox.Size = new System.Drawing.Size(760, 470);
            this.codeBox.TabIndex = 0;
            this.codeBox.Text = "";
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.Color.White;
            this.outputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputBox.Location = new System.Drawing.Point(0, 0);
            this.outputBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(553, 470);
            this.outputBox.TabIndex = 0;
            this.outputBox.Text = "";
            this.outputBox.TextChanged += new System.EventHandler(this.outputBox_TextChanged);
            // 
            // ClipsFormsExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 536);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(872, 354);
            this.Name = "ClipsFormsExample";
            this.Text = "Конструктор ноутбуков";
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button nextButton;
    private System.Windows.Forms.Button resetButton;
    private System.Windows.Forms.Button saveAsButton;
    private System.Windows.Forms.Button openButton;
    private System.Windows.Forms.Button fontButton;
    private System.Windows.Forms.FontDialog fontDialog1;
    private System.Windows.Forms.SaveFileDialog clipsSaveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox codeBox;
        private System.Windows.Forms.RichTextBox outputBox;
    }
}

