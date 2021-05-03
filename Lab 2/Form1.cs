using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Lab_2.Files;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        private Bin bin;
        private MyView view;
        private bool loaded;
        private bool needReload = false;
        private int currentLayer = 0;
        private int FrameCount;
        private bool renderByTextures = false;
        private int minValue = 0;
        private int width = 2000;
        private DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);
        public Form1()
        {
            InitializeComponent();
            renderByTextures = checkBox1.Checked;
            loaded = false;
            bin = new Bin();
            view = new MyView();
            trackBar2.Maximum = 1000;
            trackBar3.Maximum = 4000;
            trackBar2.Value = 0;
            trackBar3.Value = 2000;
            textBox1.Text = (1000).ToString();
            textBox2.Text = (3000).ToString();
            textBox3.Text = minValue.ToString();
            textBox4.Text = width.ToString();
            Application.Idle += Application_Idle1;
        }

        private void Application_Idle1(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                displayFPS();
                glControl1.Invalidate();
            }
        }

        private void displayFPS()
        {
            if (DateTime.Now >= NextFPSUpdate)
            {
                this.Text = String.Format("KT Visualizer (fps={0})", FrameCount);
                NextFPSUpdate = DateTime.Now.AddSeconds(1);
                FrameCount = 0;
            }
            FrameCount++;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str = dialog.FileName;
                bin.readBIN(str);
                trackBar1.Maximum = Bin.Z - 1;
                view.SetupView(glControl1.Width, glControl1.Height);
                loaded = true;
                glControl1.Invalidate();
            }
        }

        
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                if (renderByTextures)
                {
                    if (needReload)
                    {
                        view.generateTextureImage(currentLayer, minValue, minValue + width);
                        view.Load2DTexture();
                        needReload = false;
                    }
                    view.DrawTexture();
                    glControl1.SwapBuffers();
                }
                else
                {
                    view.DrawQuads(currentLayer, minValue, minValue + width);
                    glControl1.SwapBuffers();
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentLayer = trackBar1.Value;
            needReload = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            renderByTextures = checkBox1.Checked;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            minValue = trackBar2.Value;
            textBox3.Text = minValue.ToString();
            needReload = true;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

            width = trackBar3.Value;
            if (width < 5)
                width = 5;
            textBox4.Text = width.ToString();
            needReload = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string minStr = textBox1.Text;
            string widthStr = textBox2.Text;
            int wid = Convert.ToInt32(widthStr);
            if (wid < 5)
                wid = 5;
            trackBar2.Maximum = wid;
            trackBar3.Maximum = Convert.ToInt32(widthStr);

            needReload = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
