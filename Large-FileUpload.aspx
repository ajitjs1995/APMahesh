<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Large-FileUpload.aspx.cs"
    Inherits="Admin_Large_FileUpload" %>

<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="demo.css" type="text/css" />
    <script runat="server">
		
        void InsertMsg(string msg)
        {
            //ListBoxEvents.Items.Insert(0, msg);
            //ListBoxEvents.SelectedIndex = 0;
            Label1.Text = msg;
        }
        void ButtonPostBack_Click(object sender, EventArgs e)
        {
            InsertMsg("You clicked a PostBack Button.");
        }

        void Uploader_FileUploaded(object sender, UploaderEventArgs args)
        {
            InsertMsg("File uploaded! " + args.FileName + ", " + args.FileSize + " bytes.");
            args.CopyTo(Server.MapPath("doc/" + args.FileName));
            //Copies the uploaded file to a new location.
            //args.CopyTo("c:\\temp\\"+args.FileName);
            //You can also open the uploaded file's data stream.
            //System.IO.Stream data = args.OpenStream();
        }
     
    </script>
	
	<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-157825538-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-157825538-1');
</script>
	
	
</head>
<body>
    <form id="form1" method="post" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div>
        <CuteWebUI:Uploader runat="server" ID="Uploader1" InsertText="Upload File" OnFileUploaded="Uploader_FileUploaded">
        </CuteWebUI:Uploader>
    </div>
    </form>
</body>
</html>
