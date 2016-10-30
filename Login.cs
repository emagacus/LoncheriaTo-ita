using LoncheriaToñita.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoncheriaToñita
{
    public partial class Login : Form
    {


        public Login()
        {
           
            InitializeComponent();
            textBox2.Select();
            Size size = new Size(160, 160);
            pictureBox1.Image = new Bitmap(Resources.icon_user, size);
            

        }

         byte[] entropy = System.Text.Encoding.Unicode.GetBytes("Salt Is Not A Password");

        public string EncryptString(string input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                Encoding.Unicode.GetBytes(input),
                entropy,
                System.Security.Cryptography.DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedData);
        }

         string DecryptString(string encryptedData)
        {
            
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return Encoding.Unicode.GetString(decryptedData);
           
        }

    

      

      


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {


                if (textBox2.Text == Settings.Default.User && textBox1.Text == DecryptString(Settings.Default.Password))
                {

                    BaseForm basefrm = new BaseForm();
                    basefrm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Contraseña o usuario incorrecto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
    }
}
