using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using CodeStrikeBot;
using System.ServiceModel;

namespace CodeStrikeBot.Debug
{
    public partial class Main : Form
    {
        private BotDatabase Database { get; set; }
        private ChannelFactory<Services.ICodeBotService> CodeBotServiceFactory;

        public Main()
        {
            InitializeComponent();

            CodeBotServiceFactory = new ChannelFactory<Services.ICodeBotService>(new NetTcpBinding(), "net.tcp://localhost:2633");
            NetTcpBinding binding = CodeBotServiceFactory.Endpoint.Binding as NetTcpBinding;
            binding.MaxReceivedMessageSize = 524288;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            picScreen1.Image = new Bitmap(394, 702);

            Database = new BotDatabase();
        }

        private void UpdateColorCheckTextboxes()
        {
            Point p = picScreen1.PointToClient(Cursor.Position);
            Rectangle rect = new Rectangle();

            rect.X = p.X;
            rect.Y = p.Y;

            int value;
            Int32.TryParse(txtBmpSizeX.Text, out value);
            rect.Width = value;
            Int32.TryParse(txtBmpSizeY.Text, out value);
            rect.Height = value;

            if (rect.X >= 0 && rect.X < picScreen1.Image.Width && rect.Y >= 0 && rect.Y < picScreen1.Image.Height)
            {
                txtCustomX.Text = rect.X.ToString();
                txtCustomY.Text = rect.Y.ToString();
            }
            else
            {
                if (txtCustomX.Text == "")
                {
                    txtCustomX.Text = "0";
                }

                if (txtCustomY.Text == "")
                {
                    txtCustomY.Text = "0";
                }

                Int32.TryParse(txtCustomX.Text, out value);
                rect.X = value;
                Int32.TryParse(txtCustomY.Text, out value);
                rect.Y = value;
            }

            if (rect.Width > 0 && rect.Height > 0)
            {
                Bitmap bmp = new Bitmap(rect.Width, rect.Height);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(picScreen1.Image, -1, -1, new Rectangle(rect.X - 1, rect.Y - 1, rect.Width + 1, rect.Height + 1), GraphicsUnit.Pixel);
                    if (picCheck.Image != null)
                    {
                        picCheck.Image.Dispose();
                    }

                    picCheck.Image = bmp;
                    lblBmpChecksum.Text = bmp.Checksum(0, 0, picCheck.Image.Width, picCheck.Image.Height).ToString("X4");
                }

                Color c = bmp.GetPixel(0, 0);
                txtRGB.Text = String.Format("{0},{1},{2}", c.R, c.G, c.B);
            }
        }

        private void txtCustomX_TextChanged(object sender, EventArgs e)
        {
            UpdateColorCheckTextboxes();
        }

        private void txtCustomY_TextChanged(object sender, EventArgs e)
        {
            UpdateColorCheckTextboxes();
        }

        private void txtBmpSizeX_TextChanged(object sender, EventArgs e)
        {
            UpdateColorCheckTextboxes();
        }

        private void txtBmpSizeY_TextChanged(object sender, EventArgs e)
        {
            UpdateColorCheckTextboxes();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dlgLoad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SetNewImage(new Bitmap(dlgLoad.FileName));
            }
        }

        private void SetNewImage(Bitmap bmp)
        {
            Bitmap converted;
            using (bmp)
            {
                converted = Utilities.ChangePixelFormat(bmp, System.Drawing.Imaging.PixelFormat.Format16bppRgb565);
            }

            if (picScreen1.Image != null)
            {
                picScreen1.Image.Dispose();
            }

            picScreen1.Image = converted;
            UpdateColorCheckTextboxes();
        }

        private void picScreen1_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateColorCheckTextboxes();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void btnScreen1_Click(object sender, EventArgs e)
        {
            GetScreenServiceCall(0);
        }

        private void btnScreen2_Click(object sender, EventArgs e)
        {
            GetScreenServiceCall(1);
        }

        private void btnScreen3_Click(object sender, EventArgs e)
        {
            GetScreenServiceCall(2);
        }

        private void btnScreen4_Click(object sender, EventArgs e)
        {
            GetScreenServiceCall(3);
        }

        private void GetScreenServiceCall(int screenId)
        {
            bool success = false;

            while (!success)
            {
                Services.ICodeBotService svc = CodeBotServiceFactory.CreateChannel();

                try
                {
                    SetNewImage(svc.GetScreen(screenId));
                    success = true;

                    (svc as ICommunicationObject).Close();
                }
                catch (CommunicationException ex)
                {
                    (svc as ICommunicationObject).Abort();
                }
            }
        }
    }
}
