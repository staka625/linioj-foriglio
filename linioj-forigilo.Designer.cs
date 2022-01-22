namespace liniojForigilo
{
    partial class liniojforigilo
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(liniojforigilo));
            this.openButton = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.fromLabel = new System.Windows.Forms.Label();
            this.fromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.toNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.toLabel = new System.Windows.Forms.Label();
            this.linesLabel = new System.Windows.Forms.Label();
            this.outFileName = new System.Windows.Forms.Label();
            this.encodelabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fromNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.openButton.Location = new System.Drawing.Point(368, 40);
            this.openButton.Margin = new System.Windows.Forms.Padding(4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(88, 29);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fileNameTextBox.Location = new System.Drawing.Point(38, 44);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(322, 23);
            this.fileNameTextBox.TabIndex = 1;
            this.fileNameTextBox.TextChanged += new System.EventHandler(this.fileNameTextBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(368, 183);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 29);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Delete";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(60, 123);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(39, 15);
            this.fromLabel.TabIndex = 3;
            this.fromLabel.Text = "From :";
            // 
            // fromNumericUpDown
            // 
            this.fromNumericUpDown.Location = new System.Drawing.Point(105, 121);
            this.fromNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.fromNumericUpDown.Name = "fromNumericUpDown";
            this.fromNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.fromNumericUpDown.TabIndex = 4;
            this.fromNumericUpDown.ThousandsSeparator = true;
            // 
            // toNumericUpDown
            // 
            this.toNumericUpDown.Location = new System.Drawing.Point(105, 150);
            this.toNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.toNumericUpDown.Name = "toNumericUpDown";
            this.toNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.toNumericUpDown.TabIndex = 6;
            this.toNumericUpDown.ThousandsSeparator = true;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(60, 152);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 15);
            this.toLabel.TabIndex = 5;
            this.toLabel.Text = "To :";
            // 
            // linesLabel
            // 
            this.linesLabel.AutoSize = true;
            this.linesLabel.Location = new System.Drawing.Point(60, 94);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(40, 15);
            this.linesLabel.TabIndex = 7;
            this.linesLabel.Text = "Lines :";
            // 
            // outFileName
            // 
            this.outFileName.AutoSize = true;
            this.outFileName.Location = new System.Drawing.Point(45, 190);
            this.outFileName.Name = "outFileName";
            this.outFileName.Size = new System.Drawing.Size(0, 15);
            this.outFileName.TabIndex = 8;
            // 
            // encodelabel
            // 
            this.encodelabel.AutoSize = true;
            this.encodelabel.Location = new System.Drawing.Point(274, 94);
            this.encodelabel.Name = "encodelabel";
            this.encodelabel.Size = new System.Drawing.Size(55, 15);
            this.encodelabel.TabIndex = 9;
            this.encodelabel.Text = "Encode : ";
            // 
            // comboBox1
            // 
            this.comboBox1.CausesValidation = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "UTF-8",
            "UTF-8BOM",
            "UTF-16",
            "UTF-16BOM",
            "Shift-JIS",
            "EUC",
            "Keep Source"});
            this.comboBox1.Location = new System.Drawing.Point(345, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Convert to:";
            // 
            // liniojforigilo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 235);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.encodelabel);
            this.Controls.Add(this.outFileName);
            this.Controls.Add(this.linesLabel);
            this.Controls.Add(this.toNumericUpDown);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromNumericUpDown);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.openButton);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "liniojforigilo";
            this.Text = "Linioj-Forigilo";
            this.Load += new System.EventHandler(this.liniojforigilo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fromNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.NumericUpDown fromNumericUpDown;
        private System.Windows.Forms.NumericUpDown toNumericUpDown;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.Label outFileName;
        private System.Windows.Forms.Label encodelabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

