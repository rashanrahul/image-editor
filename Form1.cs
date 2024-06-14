using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void openImage()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file =Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                opened=true;
            }
        }

        void filter2()
        {
            if (!opened)
            {
                MessageBox.Show("Open an image then apply changes");

            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] { .393f, .349f + 0.5f, 272f, 0, 0 },
                    new float[] { .769f + 0.3f, .686f, .534f, 0, 0 },
                    new float[] { .189f, .168f, .131f + 0.5f, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 0, 0, 0, 0, 1 }
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel,ia);

                g.Dispose();
                pictureBox1.Image = bmpInverted;
            }
        }

        void filter3()
        {
            if (!opened)
            {
                MessageBox.Show("Open an image then apply changes");

            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] { .53f, 2.39f,0, 0, 0 },
                    new float[] { .769f + 0.3f, 1.986f, .534f, 0, 0 },
                    new float[] { .189f, 2.168f, 0, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 0, 0, 0, 0, 1 }
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();
                pictureBox1.Image = bmpInverted;
            }
        }

        void filter4()
        {
            if (!opened)
            {
                MessageBox.Show("Open an image then apply changes");

            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] { 1.53f, 2.39f,0, 0, 0 },
                    new float[] { .769f + 0.3f, 2.986f, .534f, 0, 0 },
                    new float[] { .189f, 4.168f, 0, 0, 0 },
                    new float[] { 0, 0.2f, 0, 1, 0 },
                    new float[] { 0, 0, 0, 0, 1 }
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();
                pictureBox1.Image = bmpInverted;
            }
        }



        void hue()
        {
            float changered = redbar.Value * 0.1f;
            float changegreen = greenbar.Value * 0.1f;
            float changeblue = bluebar.Value * 0.1f;


           // redvalue.Text = changered.ToString();
           // greenvalue.Text = changeblue.ToString();
           // bluevalue.Text = changegreen.ToString();

            reload();

            if (!opened)
            {

            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] { 0, 1 + changered, 0, 0, 0, 0 },
                    new float[] { 0 , 1 + changegreen, 0, 0, 0 },
                    new float[] { 0, 0,1+changeblue, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 0, 0, 0, 0, 1 }
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();
                pictureBox1.Image = bmpInverted;
            }
        }
        void reload()
        {
            if (!opened)
            {

            }
            else
            {
                if (opened)
                {
                    file=Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    opened = true;
                }
            }
        }
        void saveImage()
        {
            if (opened)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String ext=Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(sfd.FileName, format);

                }
            }
            else
                    {
                        MessageBox.Show("No Image loaded, first upload image");
                    }
        }

        Image file;
        Boolean opened = false;



        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveImage(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
            filter2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            redbar.Value = 0;
            greenbar.Value = 0;
            bluebar.Value = 0;
            reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload();
            filter2();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            hue();
        }

        private void TrackBar3_Scoll(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void greenbar_valueChange(object sender, EventArgs e)
        {
            hue();
        }

        private void bluebar_valueChange(object sender, EventArgs e)
        {
            hue();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
            filter4();
        }
    }
}
