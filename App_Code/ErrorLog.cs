using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.IO;

/// <summary>
/// Summary description for ErrorLog
/// </summary>
public class ErrorLog
{
	public ErrorLog()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //Write Error to the log file
    public static void WriteError(string ErrMethod, string ErrMessage)
    {
        try
        {
            string dirroot = System.Web.HttpContext.Current.Server.MapPath("~/");

            if (!Directory.Exists(dirroot + "ErrorLog"))  // if it doesn't exist, create
                Directory.CreateDirectory(dirroot + "ErrorLog");

            string path = "~/ErrorLog/" + DateTime.Today.ToString("dd-MM-yyyy") + ".config";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }

            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                string err = "\r\nError in: " + System.Web.HttpContext.Current.Request.Url.ToString() + ". \r\nError Method: " + ErrMethod + ". \r\nError Message: " + ErrMessage;
                w.WriteLine(err);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();

            }
        }
        catch (Exception ex)
        {
            ErrorLog.WriteError("WriteError", ex.Message);
        }

    }
}