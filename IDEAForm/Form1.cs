using ClassLibrary;
using IDEA.CFB;
using IDEA.Core;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace IDEAForm
{
    public partial class Form1 : Form
    {
        private byte[] key = new byte[16];
        byte[] iv = new byte[8];
        byte[] encryptedMessageBytes;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonImportKeyIVEncr_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    string[] fileContent = File.ReadAllLines(filePath);

                    textBoxKeyEncr.Text = fileContent[0];
                    textBoxIVEncr.Text = fileContent[1];
                }
            }
        }

        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            RandomNumberGenerator.Fill(key);

            textBoxKeyEncr.Text = BitConverter.ToString(key);
        }

        private void buttonGenerateIV_Click(object sender, EventArgs e)
        {
            RandomNumberGenerator.Fill(iv);

            textBoxIVEncr.Text = BitConverter.ToString(iv);
        }

        private void buttonSaveMessageHex_Click(object sender, EventArgs e)
        {
            if(textBoxEncrMessage.TextLength == 0)
            {
                MessageBox.Show("The message is not encrypted yet!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] msgBytes = encryptedMessageBytes;
            string hexString = BitConverter.ToString(msgBytes);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    File.WriteAllText(filePath, hexString);
                }
            }
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    File.WriteAllLines(filePath, new List<string> { textBoxKeyEncr.Text, textBoxIVEncr.Text });
                }
            }
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (textBoxPlainText.TextLength == 0)
            {
                MessageBox.Show("Enter a message!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxKeyEncr.TextLength == 0)
            {
                MessageBox.Show("Enter a cipher key!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxIVEncr.TextLength == 0)
            {
                MessageBox.Show("Enter an IV!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keyToConvert = textBoxKeyEncr.Text.Replace("-", "");
            key = Convert.FromHexString(keyToConvert);

            string ivToConvert = textBoxIVEncr.Text.Replace("-", "");
            iv = Convert.FromHexString(ivToConvert);


            var core = new IDEACore();
            core.Init(key);

            var cfb = new CFBIDEA(core, iv);

            byte[] msgBytes = Encoding.ASCII.GetBytes(textBoxPlainText.Text);
            byte[] cipher = cfb.Encrypt(msgBytes);
            encryptedMessageBytes = cipher;

            textBoxEncrMessage.Text = Encoding.ASCII.GetString(cipher);
        }

        private void buttonImportKeyIVDecr_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    string[] fileContent = File.ReadAllLines(filePath);

                    textBoxKeyDecr.Text = fileContent[0];
                    textBoxIVDecr.Text = fileContent[1];
                }
            }
        }

        private void buttonOpenMessageHex_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    string fileContent = File.ReadAllText(filePath).Replace("-","");

                    byte[] bytes = Convert.FromHexString(fileContent);
                    encryptedMessageBytes = bytes;
                    textBoxEncrMessageToDecrypt.Text = Encoding.ASCII.GetString(bytes);
                }
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (textBoxEncrMessageToDecrypt.TextLength == 0)
            {
                MessageBox.Show("Enter an encrypted message!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxKeyDecr.TextLength == 0)
            {
                MessageBox.Show("Enter a cipher key!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxIVDecr.TextLength == 0)
            {
                MessageBox.Show("Enter an IV!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keyToConvert = textBoxKeyDecr.Text.Replace("-", "");
            key = Convert.FromHexString(keyToConvert);

            string ivToConvert = textBoxIVDecr.Text.Replace("-", "");
            iv = Convert.FromHexString(ivToConvert);


            var core = new IDEACore();
            core.Init(key);

            var cfb = new CFBIDEA(core, iv);

            byte[] recovered = cfb.Decrypt(encryptedMessageBytes);

            textBoxDecrMessage.Text = Encoding.ASCII.GetString(recovered);
        }
    }
}
