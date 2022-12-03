using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRG
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            btnGenerate.Click += BtnGenerate_Click;
            btnCopy.Click += BtnCopy_Click;
            btnSave.Click += BtnSave_Click;
        }
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (txtAdress.Text.Equals(""))
            {
                MessageBox.Show("You should type the Address first!", "Error");
            }
            else
            {
                try
                {
                    QRCodeGenerator qr = new QRCodeGenerator();
                    QRCodeData data = qr.CreateQrCode(txtAdress.Text, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrcode = new QRCode(data);

                    QRpic.Image = qrcode.GetGraphic(20);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error");
                }
            }
        }
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (QRpic.Image == null)
            {
                MessageBox.Show("You should generate QR Code First!", "Error");
            }
            else
            {
                try
                {
                    Clipboard.SetImage(QRpic.Image);
                    MessageBox.Show("Successfully copied to clipboard!", "Copied");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error");
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (QRpic.Image == null)
            {
                MessageBox.Show("You should generate QR Code First!", "Error");
            }
            else
            {
                try
                {
                    string filePath = Application.StartupPath;
                    QRpic.Image.Save(filePath + "\\qrcode.jpg", ImageFormat.Jpeg);
                    MessageBox.Show($"Successfully Saved image:\n{filePath}\\qrcode.jpg", "Saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error");
                }
            }
        }
    }
}
