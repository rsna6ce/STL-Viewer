/**
  ******************************************************************************
  * @file    AppMainForm.cs
  * @author  Ali Batuhan KINDAN
  * @date    21.09.2016
  * @brief   This file contains the implementaion of main application form functionality
  ******************************************************************************
  */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using STL_Tools;
using OpenTK.Graphics.OpenGL;
using BatuGL;
using Mouse_Orbit;

namespace STLViewer
{
    public partial class AppMainForm : Form
    {
        bool monitorLoaded = false;
        bool moveForm = false;
        int moveOffsetX = 0;
        int moveOffsetY = 0;
        Batu_GL.VAO_TRIANGLES modelVAO = null; // 3d model vertex array object
        private Orbiter orb;
        Vector3 minPos = new Vector3();
        Vector3 maxPos = new Vector3();

        int anigif_deg_step = 2;
        int anigif_deg_curr = 0;
        List<Bitmap> anigif_frames = new List<Bitmap>();

        public AppMainForm()
        {
            /* dot/comma selection for floating point numbers */
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
            orb = new Orbiter();
            GL_Monitor.MouseDown += orb.Control_MouseDownEvent;
            GL_Monitor.MouseUp += orb.Control_MouseUpEvent;
            GL_Monitor.MouseWheel += orb.Control_MouseWheelEvent;
            GL_Monitor.KeyPress += orb.Control_KeyPress_Event;
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            orb.UpdateOrbiter(MousePosition.X, MousePosition.Y);
            GL_Monitor.Invalidate();
            if (moveForm)
            {
                this.SetDesktopLocation(MousePosition.X - moveOffsetX, MousePosition.Y - moveOffsetY);
            }
        }

        private void GL_Monitor_Load(object sender, EventArgs e)
        {
            GL_Monitor.AllowDrop = true;
            monitorLoaded = true;
            GL.ClearColor(Color.Black);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
        }

        private void ConfigureBasicLighting(Color modelColor)
        {
            float[] light_1 = new float[] {
            0.2f * modelColor.R / 255.0f,
            0.2f * modelColor.G / 255.0f,
            0.2f * modelColor.B / 255.0f,
            1.0f };
            float[] light_2 = new float[] {
            3.0f * modelColor.R / 255.0f,
            3.0f * modelColor.G / 255.0f,
            3.0f * modelColor.B / 255.0f,
            1.0f };
            float[] specref = new float[] { 
                0.01f * modelColor.R / 255.0f, 
                0.01f * modelColor.G / 255.0f, 
                0.01f * modelColor.B / 255.0f, 
                1.0f };
            float[] specular_0 = new float[] { -1.0f, -1.0f, 1.0f, 1.0f };
            float[] specular_1 = new float[] { 1.0f, -1.0f, 1.0f, 1.0f };
            float[] lightPos_0 = new float[] { 1000f, 1000f, -200.0f, 0.0f };
            float[] lightPos_1 = new float[] { -1000f, 1000f, -200.0f, 0.0f };

            GL.Enable(EnableCap.Lighting);
            /* light 0 */
            GL.Light(LightName.Light0, LightParameter.Ambient, light_1);
            GL.Light(LightName.Light0, LightParameter.Diffuse, light_2);
            GL.Light(LightName.Light0, LightParameter.Specular, specular_0);
            GL.Light(LightName.Light0, LightParameter.Position, lightPos_0);
            GL.Enable(EnableCap.Light0);
            /* light 1 */
            GL.Light(LightName.Light1, LightParameter.Ambient, light_1);
            GL.Light(LightName.Light1, LightParameter.Diffuse, light_2);
            GL.Light(LightName.Light1, LightParameter.Specular, specular_1);
            GL.Light(LightName.Light1, LightParameter.Position, lightPos_1);
            GL.Enable(EnableCap.Light1);
            /*material settings  */
            GL.Enable(EnableCap.ColorMaterial);
            GL.ColorMaterial(MaterialFace.Front, ColorMaterialParameter.AmbientAndDiffuse);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, specref);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, 10);
            GL.Enable(EnableCap.Normalize);
        }

        private void GL_Monitor_Paint(object sender, PaintEventArgs e)
        {
            if (!monitorLoaded)
                return;

            Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
            if (modelVAO != null) ConfigureBasicLighting(modelVAO.color);
            GL.Translate(orb.PanX, orb.PanY, 0);
            GL.Rotate(orb.orbitStr.angle, orb.orbitStr.ox, orb.orbitStr.oy, orb.orbitStr.oz);
            GL.Rotate(-90, 1, 0, 0);
            GL.Rotate(-anigif_deg_curr, 0, 0, 1);
            GL.Scale(orb.scaleVal*4.0f, orb.scaleVal * 4.0f, orb.scaleVal * 4.0f);
            GL.Translate(-minPos.x, -minPos.y, -minPos.z);
            GL.Translate(-(maxPos.x - minPos.x) / 2.0f, -(maxPos.y - minPos.y) / 2.0f, -(maxPos.z - minPos.z) / 2.0f);
            if (modelVAO != null) modelVAO.Draw();

            GL_Monitor.SwapBuffers();
        }

        private void ReadSelectedFile(string fileName)
        {
            STLReader stlReader = new STLReader(fileName);
            TriangleMesh[] meshArray = stlReader.ReadFile();
            modelVAO = new Batu_GL.VAO_TRIANGLES();
            modelVAO.parameterArray = STLExport.Get_Mesh_Vertices(meshArray);
            modelVAO.normalArray = STLExport.Get_Mesh_Normals(meshArray);
            modelVAO.color = Color.LightGray;
            minPos = stlReader.GetMinMeshPosition(meshArray);
            maxPos = stlReader.GetMaxMeshPosition(meshArray);
            orb.Reset_Orientation();
            orb.Reset_Pan();
            orb.Reset_Scale();
            if (stlReader.Get_Process_Error())
            { 
                modelVAO = null;
                /* if there is an error, deinitialize the gl monitor to clear the screen */
                Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
                GL_Monitor.SwapBuffers();
            }
        }

        private void FileMenuImportBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog newFileDialog = new OpenFileDialog();
            newFileDialog.Filter = "STL Files|*.stl;*.txt;";

            if (newFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadSelectedFile(newFileDialog.FileName);
            }
        }

        private void FileMenuExitBt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AppToolBarMStp_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm = true;
            moveOffsetX = MousePosition.X - this.Location.X;
            moveOffsetY = MousePosition.Y - this.Location.Y;
        }

        private void AppToolBarMStp_MouseUp(object sender, MouseEventArgs e)
        {
            moveForm = false;
            moveOffsetX = 0;
            moveOffsetY = 0;
        }

        private void AppToolBarMStp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            else this.WindowState = FormWindowState.Maximized;
        }



        private void GL_Monitor_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                string[] fileNames = data as string[];
                string ext = System.IO.Path.GetExtension(fileNames[0]);
                if (fileNames.Length > 0 && (ext == ".stl" || ext == ".STL" || ext == ".txt" || ext == ".TXT"))
                {
                    ReadSelectedFile(fileNames[0]);
                }
            }
        }

        private void GL_Monitor_DragEnter(object sender, DragEventArgs e)
        {
            // if the extension is not *.txt or *.stl change drag drop effect symbol
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                string[] fileNames = data as string[];
                string ext = System.IO.Path.GetExtension(fileNames[0]);
                if (ext == ".stl" || ext == ".STL" || ext == ".txt" || ext == ".TXT") 
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }                
        }

        private void HelpMenuHowToUseBt_Click(object sender, EventArgs e)
        {
            AppHowToUseForm newHowToUseForm = new AppHowToUseForm();
            newHowToUseForm.ShowDialog();
        }

        private void HelpMenuAboutBt_Click(object sender, EventArgs e)
        {
            AppAboutForm aboutForm = new AppAboutForm();
            aboutForm.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //debug
        }

        private void animationGIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anigif_deg_curr = 0;
            anigif_frames.Clear();
            timerAnimationGif.Start();
        }

        private void timerAnimationGIF_Tick(object sender, EventArgs e)
        {
            GL_Monitor.Refresh();
            if (OpenTK.Graphics.GraphicsContext.CurrentContext == null)
                throw new OpenTK.Graphics.GraphicsContextMissingException();
            int w = GL_Monitor.ClientSize.Width;
            int h = GL_Monitor.ClientSize.Height;
            Bitmap bmp = new Bitmap(w, h);
            System.Drawing.Imaging.BitmapData data =
                bmp.LockBits(GL_Monitor.ClientRectangle, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.ReadPixels(0, 0, w, h, PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            anigif_frames.Add(bmp);

            anigif_deg_curr += anigif_deg_step;
            if (anigif_deg_curr >= 360)
            {
                var bmps = new List<MyGifEncorder.BitmapAndDelayTime>();
                ushort delayTime = 3;
                foreach (var f in anigif_frames)
                {
                    bmps.Add(new MyGifEncorder.BitmapAndDelayTime(f, delayTime));
                }
                timerAnimationGif.Stop();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save Animation GIF";
                DateTime dt = DateTime.Now;
                saveFileDialog.FileName = dt.ToString("yyyyMMdd_HHmmss") + ".gif";
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MyGifEncorder.SaveAnimatedGif(saveFileDialog.FileName, bmps, 0);
                }                
                anigif_deg_curr = 0;
            }
        }
    }
}