using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FileUpload_Large_Size : System.Web.UI.Page
{
    string Filelocation = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void FileType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FileType.SelectedIndex != 0)
        {
            if (FileType.SelectedItem.Text.Trim() == "css")
            {
                Filelocation = "css/";
            }
            else if (FileType.SelectedItem.Text.Trim() == "doc")
            {
                Filelocation = "doc/";
            }
            else if (FileType.SelectedItem.Text.Trim() == "forms")
            {
                Filelocation = "forms/";
            }
            else if (FileType.SelectedItem.Text.Trim() == "images")
            {
                Filelocation = "images/";
            }
            else if (FileType.SelectedItem.Text.Trim() == "InnerBanner")
            {
                Filelocation = "InnerBanner/";
            }
            else if (FileType.SelectedItem.Text.Trim() == "press")
            {
                Filelocation = "press/";
            }
            else if (FileType.SelectedItem.Text.Trim() == "js")
            {
                Filelocation = "js/";
            }
            else
            {
                Response.Write("Please select Valid File Folder !!!");
            }
        }
        Location.Text = Filelocation;
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        string filename = System.IO.Path.GetFileName(FileUpload1.FileName);

        FileUpload1.SaveAs(Server.MapPath(Location.Text) + filename);
        Response.Write("File uploaded successfully !!");
        Result.Text = "FilePath: " + Location.Text + filename;

    }
}