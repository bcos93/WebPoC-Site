using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Configuration;


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("File", typeof(string));
                dt.Columns.Add("Size", typeof(string));
                dt.Columns.Add("Type", typeof(string));

                foreach (String strFile in Directory.GetFiles(Server.MapPath("~/Download/All Clear")))
                {
                    FileInfo fi = new FileInfo(strFile);

                    dt.Rows.Add(fi.Name, fi.Length, fi.Extension);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();

                DataTable dt3 = new DataTable();
                dt3.Columns.Add("File", typeof(string));
                dt3.Columns.Add("Size", typeof(string));
                dt3.Columns.Add("Type", typeof(string));

                foreach (String strFile in Directory.GetFiles(Server.MapPath("~/Download/Metadata = Y")))
                {
                    FileInfo fi3 = new FileInfo(strFile);

                    dt3.Rows.Add(fi3.Name, fi3.Length, fi3.Extension);
                }
                GridView3.DataSource = dt3;
                GridView3.DataBind();

                DataTable dt4 = new DataTable();
                dt4.Columns.Add("File", typeof(string));
                dt4.Columns.Add("Size", typeof(string));
                dt4.Columns.Add("Type", typeof(string));

                foreach (String strFile in Directory.GetFiles(Server.MapPath("~/Download/Metadata & Text Contained = Y")))
                {
                    FileInfo fi4 = new FileInfo(strFile);

                    dt4.Rows.Add(fi4.Name, fi4.Length, fi4.Extension);
                }
                GridView4.DataSource = dt4;
                GridView4.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            }


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("File", typeof(string));
            dt2.Columns.Add("Size", typeof(string));
            dt2.Columns.Add("Type", typeof(string));

            foreach (String strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
            {
                FileInfo fi2 = new FileInfo(strFile);

                dt2.Rows.Add(fi2.Name, fi2.Length, fi2.Extension);
            }
            GridView2.DataSource = dt2;
            GridView2.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Download/All Clear/") + e.CommandArgument);
                Response.End();
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Download/Metadata = Y/") + e.CommandArgument);
                Response.End();
            }
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Download/Metadata & Text Contained = Y/") + e.CommandArgument);
                Response.End();
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Data/") + e.CommandArgument);
                Response.End();
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}