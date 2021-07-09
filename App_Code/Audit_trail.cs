using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for Audit_trail
/// </summary>
public class Audit_trail
{
    //public Audit_trail()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}


    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader dr;
    AdmPrpty cms = new AdmPrpty();
   

    public void AditOnAdd(AdmPrpty adm, string auditfor)
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["UBI_con"]);
        con.Open();
        cmd = new SqlCommand("proc_AuditTrail", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@strLogNm", adm.LogNm);
        cmd.Parameters.AddWithValue("@strTblNm", adm.TblNm);
        cmd.Parameters.AddWithValue("@strFildNm", adm.FieldNm);
        cmd.Parameters.AddWithValue("@strPgNm", adm.PageNm);
        cmd.Parameters.AddWithValue("@strModuleNm", adm.ModuleNm);
        cmd.Parameters.AddWithValue("@strAuditDt", dtindd1(DateTime.Now.ToString("dd/MM/yyyy")));
        cmd.Parameters.AddWithValue("@strRemark", adm.Remark);

        if (auditfor == "Add")
        {
            cmd.Parameters.AddWithValue("@strAddOn", dtindd1(DateTime.Now.ToString("dd/MM/yyyy")));
            cmd.Parameters["@mode"].Value = "AuditOnAdd";
        }
        else if (auditfor == "Edit")
        {
            cmd.Parameters.AddWithValue("@strEditOn", dtindd1(DateTime.Now.ToString("dd/MM/yyyy")));
            cmd.Parameters["@mode"].Value = "AuditOnEdit";
        }
        else if (auditfor == "Delete")
        {
            cmd.Parameters.AddWithValue("@strDelOn", dtindd1(DateTime.Now.ToString("dd/MM/yyyy")));
            cmd.Parameters["@mode"].Value = "AuditOnDelete";
        }
        else if (auditfor == "Archieve")
        {
            cmd.Parameters.AddWithValue("@strArchOn", dtindd1(DateTime.Now.ToString("dd/MM/yyyy")));
            cmd.Parameters["@mode"].Value = "AuditOnArch";
        }
        else if (auditfor == "Reply")
        {
            cmd.Parameters.AddWithValue("@strReplyOn", dtindd1(DateTime.Now.ToString("dd/MM/yyyy")));
            cmd.Parameters["@mode"].Value = "AuditOnReply";
        }
        else if (auditfor == "Close")
        {
            cmd.Parameters.AddWithValue("@strClosedOn", dtindd1(DateTime.Now.ToString("dd/MM/yyyy")));
            cmd.Parameters["@mode"].Value = "AuditOnClose";
        }

        cmd.ExecuteNonQuery();
        con.Close();
    }

   

    public string dtindd1(string txtdate)
    {
        string s = null;
        string[] split = new string[4];
        string day = null;
        string month = null;
        string year = null;
        s = txtdate.Trim();
        split = s.Split('/');
        day = split[0].ToString();
        month = split[1].ToString();
        year = split[2].ToString();

        string dtinmm = month + "/" + day + "/" + year;
        return dtinmm;

    }

}
