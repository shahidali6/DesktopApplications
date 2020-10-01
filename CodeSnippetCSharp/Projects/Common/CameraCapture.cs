using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSnippetCSharp
{
    public partial class CameraCapture : Form
    {
        public CameraCapture()
        {
            InitializeComponent();
            button1.Text = startText;
        }

        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;
        string startText = "Start Camera";
        string stopText = "Stop Camera";


        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = image;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(startText))
            {
                CaptureCamera();
                button1.Text = stopText;
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                button1.Text = startText;
                isCameraRunning = false;
            }
        }
    }
}
