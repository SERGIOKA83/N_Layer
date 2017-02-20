using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace MyWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Com c = new Com();
            c.CreateBLL(tbxComment.Text, Convert.ToInt32(ddlRating.SelectedValue), 1);
            rptComents.DataBind();
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Mov m = new Mov();
            using (FileStream f = new FileStream(@"c:\o1.jpg", FileMode.Open, FileAccess.Read))
            {
                
                BinaryReader reader = new BinaryReader(f);
                byte[] photo = reader.ReadBytes((int)f.Length);
               
                m.CreateBLL("Турция", "Море",  photo);
               //m.UpdateBLL(2, "Турция", "Море", photo);

            }

        }

        protected void rptComents_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void tbxRating_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}