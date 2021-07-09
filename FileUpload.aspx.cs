using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (ddlfolders.SelectedIndex == 0)
        {
            lblMessage.Text = "Please select folder to upload file with-in !!!";
            ddlfolders.Focus();
        }
        else if (string.IsNullOrEmpty(FileUpload1.PostedFile.FileName))
        {
            lblMessage.Text = "Please select file to upload !!!";
            FileUpload1.Focus();
        }
        else
        {
            string path = Server.MapPath("~/" + ddlfolders.SelectedItem.Text.Trim() + "/");
            string FileExtention = Path.GetExtension(FileUpload1.FileName);
            string Fromfile = path + Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Tofile = path + Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName) + System.DateTime.Now.Date.ToString("ddMMyyyy") + FileExtention;
            if (File.Exists(Fromfile))
            {
                if (File.Exists(Tofile))
                {
                    string filePath = Tofile;
                    File.Delete(filePath);
                }
                File.Move(Fromfile, Tofile);
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Fromfile);
                lblMessage.Text = "Old file has been Renamed !!!<br>New file has been Uploaded successfully !!!";
                ddlfolders.SelectedIndex = 0;
            }
            else
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Fromfile);
                lblMessage.Text = "New file has been Uploaded successfully !!!";
                ddlfolders.SelectedIndex = 0;
            }
        }
    }
}