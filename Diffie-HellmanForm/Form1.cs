using datasec_lab6.Diffie_Hellman;
using System.IO;
using System.Numerics;

namespace Diffie_HellmanForm
{
    public partial class Form1 : Form
    {
        datasec_lab6.Diffie_Hellman.Diffie_Hellman? firstParticipant = null;
        datasec_lab6.Diffie_Hellman.Diffie_Hellman? secondParticipant = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPAndGFromFile_Click(object sender, EventArgs e)
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

                    textBoxP.Text = fileContent[0];
                    textBoxG.Text = fileContent[1];
                }
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var (p, g) = datasec_lab6.Diffie_Hellman.Diffie_Hellman.GenerateParameters();

            textBoxP.Text = p.ToString();
            textBoxG.Text = g.ToString();
        }

        private void buttonASecretFromFile_Click(object sender, EventArgs e)
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

                    textBoxASecret.Text = fileContent[0];
                }
            }
        }

        private void buttonBSecretFromFile_Click(object sender, EventArgs e)
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

                    textBoxBSecret.Text = fileContent[0];
                }
            }
        }

        private void buttonSToFile_Click(object sender, EventArgs e)
        {
            BigInteger s = default;
            if(textBoxSFirst.Text.Length == 0 || (textBoxSSecond.Text.Length == 0))
            {
                MessageBox.Show(
                    $"Shared key s is not calculated!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }
            else
                s = BigInteger.Parse(textBoxSFirst.Text);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    File.WriteAllText(filePath, s.ToString());
                }
            }
        }

        private void buttonCalculateA_Click(object sender, EventArgs e)
        {
            BigInteger p = default;
            BigInteger g = default;
            BigInteger a = default;

            if (textBoxP.Text.Length != 0)
                BigInteger.TryParse(textBoxP.Text, out p);
            else
            {
                MessageBox.Show(
                    $"Specify the value of p!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }


            if (textBoxG.Text.Length != 0)
                BigInteger.TryParse(textBoxG.Text, out g);
            else
            {
                MessageBox.Show(
                    $"Specify the value of g!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }


            if (textBoxASecret.Text.Length != 0)
                BigInteger.TryParse(textBoxASecret.Text, out a);
            else
            {
                MessageBox.Show(
                    $"Specify the value of a!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            firstParticipant = new datasec_lab6.Diffie_Hellman.Diffie_Hellman(p, g, a);
            textBoxAPublicKey.Text = firstParticipant.PublicKey.ToString();
        }

        private void buttonCalculateB_Click(object sender, EventArgs e)
        {
            BigInteger p = default;
            BigInteger g = default;
            BigInteger b = default;

            if (textBoxP.Text.Length != 0)
                BigInteger.TryParse(textBoxP.Text, out p);
            else
            {
                MessageBox.Show(
                    $"Specify the value of p!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }


            if (textBoxG.Text.Length != 0)
                BigInteger.TryParse(textBoxG.Text, out g);
            else
            {
                MessageBox.Show(
                    $"Specify the value of g!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }


            if (textBoxBSecret.Text.Length != 0)
                BigInteger.TryParse(textBoxBSecret.Text, out b);
            else
            {
                MessageBox.Show(
                    $"Specify the value of b!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            secondParticipant = new datasec_lab6.Diffie_Hellman.Diffie_Hellman(p, g, b);
            textBoxBPublicKey.Text = secondParticipant.PublicKey.ToString();
        }

        private void buttonCalculateS_Click(object sender, EventArgs e)
        {
            BigInteger A = default;
            BigInteger B = default;
            BigInteger? s = default;

            if (firstParticipant == null || secondParticipant == null)
            {
                MessageBox.Show(
                    $"Specify the values of p, g, a or b first!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            if (textBoxAPublicKey.Text.Length != 0)
            {
                BigInteger.TryParse(textBoxAPublicKey.Text, out A);
                secondParticipant?.ComputeSharedKey(A);
            }
            else
            {
                MessageBox.Show(
                    $"Specify the value of A!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            if (textBoxBPublicKey.Text.Length != 0)
            {
                BigInteger.TryParse(textBoxBPublicKey.Text, out B);
                firstParticipant?.ComputeSharedKey(B);
            }
            else
            {
                MessageBox.Show(
                    $"Specify the value of B!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            if (firstParticipant?.SharedKey == secondParticipant?.SharedKey)
            {
                s = firstParticipant?.SharedKey;
                textBoxSFirst.Text = s.ToString();
                textBoxSSecond.Text = s.ToString();
            }
            else
            {
                MessageBox.Show(
                    $"Calculated shared keys are not equal!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }

        }
    }
}
