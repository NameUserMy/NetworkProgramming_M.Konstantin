using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace NetworkProgramming_HW_5_WF_.NET.Model
{
    internal class ScreanServer
    {


        public byte[] Screan()
        {
            Bitmap screenPicture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                 Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(screenPicture))
            {
                g.CopyFromScreen(0, 0, 0, 0, screenPicture.Size);
            }
            screenPicture.Save("Screen.jpg", ImageFormat.Jpeg);

            FileStream fs = new FileStream("Screen.jpg", FileMode.Open, FileAccess.ReadWrite);
            MemoryStream ms = new MemoryStream();
            fs.CopyTo(ms);
            long size = fs.Length;
            byte[] bytes = new byte[size];
            bytes = ms.ToArray();
            ms.Close();
            fs.Close();
            return bytes;
        }
       
    }
}
