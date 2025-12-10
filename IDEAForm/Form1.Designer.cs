namespace IDEAForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            buttonEncrypt = new Button();
            buttonSaveData = new Button();
            buttonSaveMessageHex = new Button();
            labelEncrMessage = new Label();
            textBoxEncrMessage = new TextBox();
            labelMessage = new Label();
            textBoxPlainText = new TextBox();
            buttonGenerateIV = new Button();
            buttonGenerateKey = new Button();
            labelIVEncr = new Label();
            buttonImportKeyIVEncr = new Button();
            labelCipherKeyEncr = new Label();
            textBoxIVEncr = new TextBox();
            textBoxKeyEncr = new TextBox();
            buttonDecrypt = new Button();
            buttonOpenMessageHex = new Button();
            labelDecryptedMessage = new Label();
            textBoxDecrMessage = new TextBox();
            labelEncrMessageToDecr = new Label();
            textBoxEncrMessageToDecrypt = new TextBox();
            labelIVDecr = new Label();
            buttonImportKeyIVDecr = new Button();
            labelKeyDecr = new Label();
            textBoxIVDecr = new TextBox();
            textBoxKeyDecr = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlDark;
            splitContainer1.Panel1.Controls.Add(buttonEncrypt);
            splitContainer1.Panel1.Controls.Add(buttonSaveData);
            splitContainer1.Panel1.Controls.Add(buttonSaveMessageHex);
            splitContainer1.Panel1.Controls.Add(labelEncrMessage);
            splitContainer1.Panel1.Controls.Add(textBoxEncrMessage);
            splitContainer1.Panel1.Controls.Add(labelMessage);
            splitContainer1.Panel1.Controls.Add(textBoxPlainText);
            splitContainer1.Panel1.Controls.Add(buttonGenerateIV);
            splitContainer1.Panel1.Controls.Add(buttonGenerateKey);
            splitContainer1.Panel1.Controls.Add(labelIVEncr);
            splitContainer1.Panel1.Controls.Add(buttonImportKeyIVEncr);
            splitContainer1.Panel1.Controls.Add(labelCipherKeyEncr);
            splitContainer1.Panel1.Controls.Add(textBoxIVEncr);
            splitContainer1.Panel1.Controls.Add(textBoxKeyEncr);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlDark;
            splitContainer1.Panel2.Controls.Add(buttonDecrypt);
            splitContainer1.Panel2.Controls.Add(buttonOpenMessageHex);
            splitContainer1.Panel2.Controls.Add(labelDecryptedMessage);
            splitContainer1.Panel2.Controls.Add(textBoxDecrMessage);
            splitContainer1.Panel2.Controls.Add(labelEncrMessageToDecr);
            splitContainer1.Panel2.Controls.Add(textBoxEncrMessageToDecrypt);
            splitContainer1.Panel2.Controls.Add(labelIVDecr);
            splitContainer1.Panel2.Controls.Add(buttonImportKeyIVDecr);
            splitContainer1.Panel2.Controls.Add(labelKeyDecr);
            splitContainer1.Panel2.Controls.Add(textBoxIVDecr);
            splitContainer1.Panel2.Controls.Add(textBoxKeyDecr);
            splitContainer1.Size = new Size(1093, 465);
            splitContainer1.SplitterDistance = 548;
            splitContainer1.TabIndex = 0;
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point(415, 401);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(75, 52);
            buttonEncrypt.TabIndex = 14;
            buttonEncrypt.Text = "Encrypt";
            buttonEncrypt.UseVisualStyleBackColor = true;
            buttonEncrypt.Click += buttonEncrypt_Click;
            // 
            // buttonSaveData
            // 
            buttonSaveData.Location = new Point(12, 430);
            buttonSaveData.Name = "buttonSaveData";
            buttonSaveData.Size = new Size(191, 23);
            buttonSaveData.TabIndex = 13;
            buttonSaveData.Text = "Save data";
            buttonSaveData.UseVisualStyleBackColor = true;
            buttonSaveData.Click += buttonSaveData_Click;
            // 
            // buttonSaveMessageHex
            // 
            buttonSaveMessageHex.Location = new Point(12, 401);
            buttonSaveMessageHex.Name = "buttonSaveMessageHex";
            buttonSaveMessageHex.Size = new Size(191, 23);
            buttonSaveMessageHex.TabIndex = 12;
            buttonSaveMessageHex.Text = "Save encrypted message (hex)";
            buttonSaveMessageHex.UseVisualStyleBackColor = true;
            buttonSaveMessageHex.Click += buttonSaveMessageHex_Click;
            // 
            // labelEncrMessage
            // 
            labelEncrMessage.AutoSize = true;
            labelEncrMessage.Location = new Point(12, 238);
            labelEncrMessage.Name = "labelEncrMessage";
            labelEncrMessage.Size = new Size(109, 15);
            labelEncrMessage.TabIndex = 11;
            labelEncrMessage.Text = "Encrypted message";
            // 
            // textBoxEncrMessage
            // 
            textBoxEncrMessage.Location = new Point(138, 235);
            textBoxEncrMessage.Multiline = true;
            textBoxEncrMessage.Name = "textBoxEncrMessage";
            textBoxEncrMessage.ReadOnly = true;
            textBoxEncrMessage.Size = new Size(352, 113);
            textBoxEncrMessage.TabIndex = 10;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(12, 99);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(53, 15);
            labelMessage.TabIndex = 9;
            labelMessage.Text = "Message";
            // 
            // textBoxPlainText
            // 
            textBoxPlainText.Location = new Point(138, 96);
            textBoxPlainText.Multiline = true;
            textBoxPlainText.Name = "textBoxPlainText";
            textBoxPlainText.Size = new Size(352, 113);
            textBoxPlainText.TabIndex = 8;
            // 
            // buttonGenerateIV
            // 
            buttonGenerateIV.Location = new Point(334, 53);
            buttonGenerateIV.Name = "buttonGenerateIV";
            buttonGenerateIV.Size = new Size(75, 23);
            buttonGenerateIV.TabIndex = 7;
            buttonGenerateIV.Text = "Generate";
            buttonGenerateIV.UseVisualStyleBackColor = true;
            buttonGenerateIV.Click += buttonGenerateIV_Click;
            // 
            // buttonGenerateKey
            // 
            buttonGenerateKey.Location = new Point(334, 12);
            buttonGenerateKey.Name = "buttonGenerateKey";
            buttonGenerateKey.Size = new Size(75, 23);
            buttonGenerateKey.TabIndex = 6;
            buttonGenerateKey.Text = "Generate";
            buttonGenerateKey.UseVisualStyleBackColor = true;
            buttonGenerateKey.Click += buttonGenerateKey_Click;
            // 
            // labelIVEncr
            // 
            labelIVEncr.AutoSize = true;
            labelIVEncr.Location = new Point(12, 56);
            labelIVEncr.Name = "labelIVEncr";
            labelIVEncr.Size = new Size(46, 15);
            labelIVEncr.TabIndex = 4;
            labelIVEncr.Text = "IV (hex)";
            // 
            // buttonImportKeyIVEncr
            // 
            buttonImportKeyIVEncr.Location = new Point(415, 12);
            buttonImportKeyIVEncr.Name = "buttonImportKeyIVEncr";
            buttonImportKeyIVEncr.Size = new Size(75, 64);
            buttonImportKeyIVEncr.TabIndex = 3;
            buttonImportKeyIVEncr.Text = "From file";
            buttonImportKeyIVEncr.UseVisualStyleBackColor = true;
            buttonImportKeyIVEncr.Click += buttonImportKeyIVEncr_Click;
            // 
            // labelCipherKeyEncr
            // 
            labelCipherKeyEncr.AutoSize = true;
            labelCipherKeyEncr.Location = new Point(12, 15);
            labelCipherKeyEncr.Name = "labelCipherKeyEncr";
            labelCipherKeyEncr.Size = new Size(92, 15);
            labelCipherKeyEncr.TabIndex = 2;
            labelCipherKeyEncr.Text = "Cipher key (hex)";
            // 
            // textBoxIVEncr
            // 
            textBoxIVEncr.Location = new Point(138, 53);
            textBoxIVEncr.Name = "textBoxIVEncr";
            textBoxIVEncr.Size = new Size(171, 23);
            textBoxIVEncr.TabIndex = 1;
            // 
            // textBoxKeyEncr
            // 
            textBoxKeyEncr.Location = new Point(138, 12);
            textBoxKeyEncr.Name = "textBoxKeyEncr";
            textBoxKeyEncr.Size = new Size(171, 23);
            textBoxKeyEncr.TabIndex = 0;
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Location = new Point(419, 401);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(75, 52);
            buttonDecrypt.TabIndex = 28;
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += buttonDecrypt_Click;
            // 
            // buttonOpenMessageHex
            // 
            buttonOpenMessageHex.Location = new Point(16, 416);
            buttonOpenMessageHex.Name = "buttonOpenMessageHex";
            buttonOpenMessageHex.Size = new Size(191, 23);
            buttonOpenMessageHex.TabIndex = 26;
            buttonOpenMessageHex.Text = "Open encrypted message (hex)";
            buttonOpenMessageHex.UseVisualStyleBackColor = true;
            buttonOpenMessageHex.Click += buttonOpenMessageHex_Click;
            // 
            // labelDecryptedMessage
            // 
            labelDecryptedMessage.AutoSize = true;
            labelDecryptedMessage.Location = new Point(16, 238);
            labelDecryptedMessage.Name = "labelDecryptedMessage";
            labelDecryptedMessage.Size = new Size(110, 15);
            labelDecryptedMessage.TabIndex = 25;
            labelDecryptedMessage.Text = "Decrypted message";
            // 
            // textBoxDecrMessage
            // 
            textBoxDecrMessage.Location = new Point(142, 235);
            textBoxDecrMessage.Multiline = true;
            textBoxDecrMessage.Name = "textBoxDecrMessage";
            textBoxDecrMessage.ReadOnly = true;
            textBoxDecrMessage.Size = new Size(352, 113);
            textBoxDecrMessage.TabIndex = 24;
            // 
            // labelEncrMessageToDecr
            // 
            labelEncrMessageToDecr.AutoSize = true;
            labelEncrMessageToDecr.Location = new Point(16, 99);
            labelEncrMessageToDecr.Name = "labelEncrMessageToDecr";
            labelEncrMessageToDecr.Size = new Size(109, 15);
            labelEncrMessageToDecr.TabIndex = 23;
            labelEncrMessageToDecr.Text = "Encrypted message";
            // 
            // textBoxEncrMessageToDecrypt
            // 
            textBoxEncrMessageToDecrypt.Location = new Point(142, 96);
            textBoxEncrMessageToDecrypt.Multiline = true;
            textBoxEncrMessageToDecrypt.Name = "textBoxEncrMessageToDecrypt";
            textBoxEncrMessageToDecrypt.Size = new Size(352, 113);
            textBoxEncrMessageToDecrypt.TabIndex = 22;
            // 
            // labelIVDecr
            // 
            labelIVDecr.AutoSize = true;
            labelIVDecr.Location = new Point(16, 56);
            labelIVDecr.Name = "labelIVDecr";
            labelIVDecr.Size = new Size(46, 15);
            labelIVDecr.TabIndex = 19;
            labelIVDecr.Text = "IV (hex)";
            // 
            // buttonImportKeyIVDecr
            // 
            buttonImportKeyIVDecr.Location = new Point(319, 12);
            buttonImportKeyIVDecr.Name = "buttonImportKeyIVDecr";
            buttonImportKeyIVDecr.Size = new Size(75, 64);
            buttonImportKeyIVDecr.TabIndex = 18;
            buttonImportKeyIVDecr.Text = "From file";
            buttonImportKeyIVDecr.UseVisualStyleBackColor = true;
            buttonImportKeyIVDecr.Click += buttonImportKeyIVDecr_Click;
            // 
            // labelKeyDecr
            // 
            labelKeyDecr.AutoSize = true;
            labelKeyDecr.Location = new Point(16, 15);
            labelKeyDecr.Name = "labelKeyDecr";
            labelKeyDecr.Size = new Size(92, 15);
            labelKeyDecr.TabIndex = 17;
            labelKeyDecr.Text = "Cipher key (hex)";
            // 
            // textBoxIVDecr
            // 
            textBoxIVDecr.Location = new Point(142, 53);
            textBoxIVDecr.Name = "textBoxIVDecr";
            textBoxIVDecr.Size = new Size(171, 23);
            textBoxIVDecr.TabIndex = 16;
            // 
            // textBoxKeyDecr
            // 
            textBoxKeyDecr.Location = new Point(142, 12);
            textBoxKeyDecr.Name = "textBoxKeyDecr";
            textBoxKeyDecr.Size = new Size(171, 23);
            textBoxKeyDecr.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 465);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "IDEA (CFB)";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label labelCipherKeyEncr;
        private TextBox textBoxIVEncr;
        private TextBox textBoxKeyEncr;
        private Label labelIVEncr;
        private Button buttonImportKeyIVEncr;
        private Button buttonGenerateIV;
        private Button buttonGenerateKey;
        private TextBox textBoxPlainText;
        private Label labelEncrMessage;
        private TextBox textBoxEncrMessage;
        private Label labelMessage;
        private Button buttonSaveMessageHex;
        private Button buttonEncrypt;
        private Button buttonSaveData;
        private Button buttonDecrypt;
        private Button buttonOpenMessageHex;
        private Label labelDecryptedMessage;
        private TextBox textBoxDecrMessage;
        private Label labelEncrMessageToDecr;
        private TextBox textBoxEncrMessageToDecrypt;
        private Label labelIVDecr;
        private Button buttonImportKeyIVDecr;
        private Label labelKeyDecr;
        private TextBox textBoxIVDecr;
        private TextBox textBoxKeyDecr;
    }
}
