using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepairApp
{
    public partial class CaptchaForm : Form
    {
        private string captchaText = "";

        public CaptchaForm()
        {
            InitializeComponent();
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            Random rand = new Random();
            captchaText = "";
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 4; i++)
            {
                captchaText += allowedChars[rand.Next(0, allowedChars.Length)];
            }
            DrawCaptcha();
        }

        private void DrawCaptcha()
        {
            Bitmap bitmap = new Bitmap(captchaPictureBox.Width, captchaPictureBox.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                Random rand = new Random();
                using (Font font = new Font("Arial", 18, FontStyle.Bold))
                {
                    GraphicsPath path = new GraphicsPath();
                    for (int i = 0; i < captchaText.Length; i++)
                    {
                        path.AddString(captchaText[i].ToString(), font.FontFamily, (int)FontStyle.Bold, 20,
                                       new Point(i * 25, rand.Next(10)), new StringFormat());
                    }

                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPath(Pens.Black, path);
                    g.FillPath(Brushes.Blue, path);
                }

                // Рисуем шум
                for (int i = 0; i < 10; i++)
                {
                    g.DrawLine(Pens.Black, rand.Next(captchaPictureBox.Width), rand.Next(captchaPictureBox.Height),
                        rand.Next(captchaPictureBox.Width), rand.Next(captchaPictureBox.Height));
                }
            }
            captchaPictureBox.Image = bitmap;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (captchaTextBox.Text == captchaText)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Неверная CAPTCHA.");
            }
        }

        private void regenerateButton_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }
    }

}
