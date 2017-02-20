using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BLL;

namespace MyWeb
{
   
    public class PictureH : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Mov _mov = new Mov();
            byte[] byteImg = new byte[_mov.ReadImgBLL(3).Length];
            byteImg = _mov.ReadImgBLL(3);

            //Image img = Image.FromFile(@"c:\o1.jpg");
            //MemoryStream stream = new MemoryStream();
            //img.Save(stream, ImageFormat.Png);

            //img.Dispose();

            //byte[] byteImg = new byte[stream.Length];
            //stream.Position=0;
            //stream.Read(byteImg,0,(int)byteImg.Length);

            //stream.Close();

            context.Response.ContentType = "image/png";
           
            context.Response.BinaryWrite(byteImg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}