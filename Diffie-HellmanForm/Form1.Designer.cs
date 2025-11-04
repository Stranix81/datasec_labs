namespace Diffie_HellmanForm
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
            labelp = new Label();
            labelg = new Label();
            splitContainer1 = new SplitContainer();
            textBoxSFirst = new TextBox();
            textBoxAPublicKey = new TextBox();
            textBoxASecret = new TextBox();
            buttonASecretFromFile = new Button();
            buttonCalculateA = new Button();
            labelSFirst = new Label();
            labelAPrivateKey = new Label();
            labelNameFirst = new Label();
            labelASecret = new Label();
            textBoxSSecond = new TextBox();
            textBoxBPublicKey = new TextBox();
            textBoxBSecret = new TextBox();
            buttonBSecretFromFile = new Button();
            buttonCalculateB = new Button();
            labelSSecond = new Label();
            labelBPrivateKey = new Label();
            labelNameSecond = new Label();
            labelBSecret = new Label();
            buttonCalculateS = new Button();
            buttonPAndGFromFile = new Button();
            textBoxP = new TextBox();
            textBoxG = new TextBox();
            buttonGenerate = new Button();
            buttonSToFile = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // labelp
            // 
            labelp.AutoSize = true;
            labelp.Location = new Point(223, 14);
            labelp.Name = "labelp";
            labelp.Size = new Size(17, 15);
            labelp.TabIndex = 1;
            labelp.Text = "p:";
            // 
            // labelg
            // 
            labelg.AutoSize = true;
            labelg.Location = new Point(223, 43);
            labelg.Name = "labelg";
            labelg.Size = new Size(17, 15);
            labelg.TabIndex = 2;
            labelg.Text = "g:";
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.Location = new Point(12, 70);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlDark;
            splitContainer1.Panel1.Controls.Add(textBoxSFirst);
            splitContainer1.Panel1.Controls.Add(textBoxAPublicKey);
            splitContainer1.Panel1.Controls.Add(textBoxASecret);
            splitContainer1.Panel1.Controls.Add(buttonASecretFromFile);
            splitContainer1.Panel1.Controls.Add(buttonCalculateA);
            splitContainer1.Panel1.Controls.Add(labelSFirst);
            splitContainer1.Panel1.Controls.Add(labelAPrivateKey);
            splitContainer1.Panel1.Controls.Add(labelNameFirst);
            splitContainer1.Panel1.Controls.Add(labelASecret);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlDark;
            splitContainer1.Panel2.Controls.Add(textBoxSSecond);
            splitContainer1.Panel2.Controls.Add(textBoxBPublicKey);
            splitContainer1.Panel2.Controls.Add(textBoxBSecret);
            splitContainer1.Panel2.Controls.Add(buttonBSecretFromFile);
            splitContainer1.Panel2.Controls.Add(buttonCalculateB);
            splitContainer1.Panel2.Controls.Add(labelSSecond);
            splitContainer1.Panel2.Controls.Add(labelBPrivateKey);
            splitContainer1.Panel2.Controls.Add(labelNameSecond);
            splitContainer1.Panel2.Controls.Add(labelBSecret);
            splitContainer1.Size = new Size(572, 211);
            splitContainer1.SplitterDistance = 286;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 4;
            // 
            // textBoxSFirst
            // 
            textBoxSFirst.Location = new Point(47, 116);
            textBoxSFirst.Name = "textBoxSFirst";
            textBoxSFirst.ReadOnly = true;
            textBoxSFirst.Size = new Size(120, 23);
            textBoxSFirst.TabIndex = 12;
            // 
            // textBoxAPublicKey
            // 
            textBoxAPublicKey.Location = new Point(47, 77);
            textBoxAPublicKey.Name = "textBoxAPublicKey";
            textBoxAPublicKey.ReadOnly = true;
            textBoxAPublicKey.Size = new Size(120, 23);
            textBoxAPublicKey.TabIndex = 11;
            // 
            // textBoxASecret
            // 
            textBoxASecret.Location = new Point(47, 36);
            textBoxASecret.Name = "textBoxASecret";
            textBoxASecret.Size = new Size(120, 23);
            textBoxASecret.TabIndex = 10;
            // 
            // buttonASecretFromFile
            // 
            buttonASecretFromFile.Location = new Point(173, 36);
            buttonASecretFromFile.Name = "buttonASecretFromFile";
            buttonASecretFromFile.Size = new Size(75, 23);
            buttonASecretFromFile.TabIndex = 9;
            buttonASecretFromFile.Text = "From file";
            buttonASecretFromFile.UseVisualStyleBackColor = true;
            buttonASecretFromFile.Click += buttonASecretFromFile_Click;
            // 
            // buttonCalculateA
            // 
            buttonCalculateA.Location = new Point(173, 77);
            buttonCalculateA.Name = "buttonCalculateA";
            buttonCalculateA.Size = new Size(75, 23);
            buttonCalculateA.TabIndex = 7;
            buttonCalculateA.Text = "Calculate";
            buttonCalculateA.UseVisualStyleBackColor = true;
            buttonCalculateA.Click += buttonCalculateA_Click;
            // 
            // labelSFirst
            // 
            labelSFirst.AutoSize = true;
            labelSFirst.Font = new Font("Segoe UI", 9F);
            labelSFirst.Location = new Point(25, 119);
            labelSFirst.Name = "labelSFirst";
            labelSFirst.Size = new Size(15, 15);
            labelSFirst.TabIndex = 5;
            labelSFirst.Text = "s:";
            // 
            // labelAPrivateKey
            // 
            labelAPrivateKey.AutoSize = true;
            labelAPrivateKey.Font = new Font("Segoe UI", 9F);
            labelAPrivateKey.Location = new Point(25, 78);
            labelAPrivateKey.Name = "labelAPrivateKey";
            labelAPrivateKey.Size = new Size(18, 15);
            labelAPrivateKey.TabIndex = 3;
            labelAPrivateKey.Text = "A:";
            // 
            // labelNameFirst
            // 
            labelNameFirst.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelNameFirst.AutoSize = true;
            labelNameFirst.Font = new Font("Segoe UI", 12F);
            labelNameFirst.Location = new Point(124, 0);
            labelNameFirst.Name = "labelNameFirst";
            labelNameFirst.Size = new Size(43, 21);
            labelNameFirst.TabIndex = 2;
            labelNameFirst.Text = "Alice";
            // 
            // labelASecret
            // 
            labelASecret.AutoSize = true;
            labelASecret.Font = new Font("Segoe UI", 9F);
            labelASecret.Location = new Point(25, 38);
            labelASecret.Name = "labelASecret";
            labelASecret.Size = new Size(16, 15);
            labelASecret.TabIndex = 0;
            labelASecret.Text = "a:";
            // 
            // textBoxSSecond
            // 
            textBoxSSecond.Location = new Point(51, 116);
            textBoxSSecond.Name = "textBoxSSecond";
            textBoxSSecond.ReadOnly = true;
            textBoxSSecond.Size = new Size(120, 23);
            textBoxSSecond.TabIndex = 13;
            // 
            // textBoxBPublicKey
            // 
            textBoxBPublicKey.Location = new Point(51, 77);
            textBoxBPublicKey.Name = "textBoxBPublicKey";
            textBoxBPublicKey.ReadOnly = true;
            textBoxBPublicKey.Size = new Size(120, 23);
            textBoxBPublicKey.TabIndex = 12;
            // 
            // textBoxBSecret
            // 
            textBoxBSecret.Location = new Point(51, 35);
            textBoxBSecret.Name = "textBoxBSecret";
            textBoxBSecret.Size = new Size(120, 23);
            textBoxBSecret.TabIndex = 11;
            // 
            // buttonBSecretFromFile
            // 
            buttonBSecretFromFile.Location = new Point(177, 36);
            buttonBSecretFromFile.Name = "buttonBSecretFromFile";
            buttonBSecretFromFile.Size = new Size(75, 23);
            buttonBSecretFromFile.TabIndex = 9;
            buttonBSecretFromFile.Text = "From file";
            buttonBSecretFromFile.UseVisualStyleBackColor = true;
            buttonBSecretFromFile.Click += buttonBSecretFromFile_Click;
            // 
            // buttonCalculateB
            // 
            buttonCalculateB.Location = new Point(177, 77);
            buttonCalculateB.Name = "buttonCalculateB";
            buttonCalculateB.Size = new Size(75, 23);
            buttonCalculateB.TabIndex = 8;
            buttonCalculateB.Text = "Calculate";
            buttonCalculateB.UseVisualStyleBackColor = true;
            buttonCalculateB.Click += buttonCalculateB_Click;
            // 
            // labelSSecond
            // 
            labelSSecond.AutoSize = true;
            labelSSecond.Location = new Point(28, 119);
            labelSSecond.Name = "labelSSecond";
            labelSSecond.Size = new Size(15, 15);
            labelSSecond.TabIndex = 5;
            labelSSecond.Text = "s:";
            // 
            // labelBPrivateKey
            // 
            labelBPrivateKey.AutoSize = true;
            labelBPrivateKey.Location = new Point(28, 78);
            labelBPrivateKey.Name = "labelBPrivateKey";
            labelBPrivateKey.Size = new Size(17, 15);
            labelBPrivateKey.TabIndex = 3;
            labelBPrivateKey.Text = "B:";
            // 
            // labelNameSecond
            // 
            labelNameSecond.AutoSize = true;
            labelNameSecond.Font = new Font("Segoe UI", 12F);
            labelNameSecond.Location = new Point(125, 0);
            labelNameSecond.Name = "labelNameSecond";
            labelNameSecond.Size = new Size(37, 21);
            labelNameSecond.TabIndex = 2;
            labelNameSecond.Text = "Bob";
            // 
            // labelBSecret
            // 
            labelBSecret.AutoSize = true;
            labelBSecret.Location = new Point(28, 38);
            labelBSecret.Name = "labelBSecret";
            labelBSecret.Size = new Size(17, 15);
            labelBSecret.TabIndex = 0;
            labelBSecret.Text = "b:";
            // 
            // buttonCalculateS
            // 
            buttonCalculateS.Location = new Point(202, 287);
            buttonCalculateS.Name = "buttonCalculateS";
            buttonCalculateS.Size = new Size(192, 23);
            buttonCalculateS.TabIndex = 7;
            buttonCalculateS.Text = "Calculate shared key (s)";
            buttonCalculateS.UseVisualStyleBackColor = true;
            buttonCalculateS.Click += buttonCalculateS_Click;
            // 
            // buttonPAndGFromFile
            // 
            buttonPAndGFromFile.Location = new Point(376, 12);
            buttonPAndGFromFile.Name = "buttonPAndGFromFile";
            buttonPAndGFromFile.Size = new Size(75, 23);
            buttonPAndGFromFile.TabIndex = 8;
            buttonPAndGFromFile.Text = "From file";
            buttonPAndGFromFile.UseVisualStyleBackColor = true;
            buttonPAndGFromFile.Click += buttonPAndGFromFile_Click;
            // 
            // textBoxP
            // 
            textBoxP.Location = new Point(246, 12);
            textBoxP.Name = "textBoxP";
            textBoxP.Size = new Size(112, 23);
            textBoxP.TabIndex = 9;
            // 
            // textBoxG
            // 
            textBoxG.Location = new Point(246, 41);
            textBoxG.Name = "textBoxG";
            textBoxG.Size = new Size(112, 23);
            textBoxG.TabIndex = 10;
            // 
            // buttonGenerate
            // 
            buttonGenerate.Location = new Point(376, 41);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(75, 23);
            buttonGenerate.TabIndex = 11;
            buttonGenerate.Text = "Generate";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // buttonSToFile
            // 
            buttonSToFile.Location = new Point(202, 316);
            buttonSToFile.Name = "buttonSToFile";
            buttonSToFile.Size = new Size(192, 23);
            buttonSToFile.TabIndex = 12;
            buttonSToFile.Text = "Write shared key (s) to file";
            buttonSToFile.UseVisualStyleBackColor = true;
            buttonSToFile.Click += buttonSToFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 360);
            Controls.Add(buttonSToFile);
            Controls.Add(buttonGenerate);
            Controls.Add(textBoxG);
            Controls.Add(textBoxP);
            Controls.Add(buttonPAndGFromFile);
            Controls.Add(splitContainer1);
            Controls.Add(buttonCalculateS);
            Controls.Add(labelg);
            Controls.Add(labelp);
            Name = "Form1";
            Text = "Diffie-Hellman Demo";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelp;
        private Label labelg;
        private SplitContainer splitContainer1;
        private Label labelNameFirst;
        private Label labelASecret;
        private Label labelNameSecond;
        private Label labelBSecret;
        private Label labelAPrivateKey;
        private Label labelBPrivateKey;
        private Label labelSFirst;
        private Label labelSSecond;
        private Button buttonCalculateA;
        private Button buttonCalculateS;
        private Button buttonCalculateB;
        private Button buttonASecretFromFile;
        private Button buttonBSecretFromFile;
        private Button buttonPAndGFromFile;
        private TextBox textBoxP;
        private TextBox textBoxSFirst;
        private TextBox textBoxAPublicKey;
        private TextBox textBoxASecret;
        private TextBox textBoxSSecond;
        private TextBox textBoxBPublicKey;
        private TextBox textBoxBSecret;
        private TextBox textBoxG;
        private Button buttonGenerate;
        private Button buttonSToFile;
    }
}
