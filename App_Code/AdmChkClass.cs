using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for AdmChkClass
/// </summary>
public class AdmChkClass
{
    DataProperties prop = new DataProperties();
    DataFunctions func = new DataFunctions();
    Validation valid_obj = new Validation();
	public AdmChkClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Chk_ModAuth(string uid, string modnm1, string authnm1, string Admtype1)
    {

        if (Admtype1 == "admin")
        {
            return true;
        }

        else if (Admtype1 == "Checker")
            {
                return true;
            }
        else if (Admtype1 == "Maker")
        {
            return true;
        }
        else if (Admtype1 == "Both")
        {
            return true;
        }
        else
        {
            if (Chk_ModuleAuthority(uid, modnm1, Admtype1) == false)
            {
               // return true;
                return false;  
            }
            else
            {
                return true;
            }
        }
    }
    public bool Chk_ModuleAuthority(string uid, string modnm, string Admtype)
    {
        int val1 = 0;
        try
        {
            int cnt1 = 0;
            int cnt2 = 0;
            int flag1 = 0;

            prop.Procname = "Proc_BankAmdMods"; // Procedure name
            prop.key = "TMBCON";          // Connection Key
            prop.ExeType = ExecuteType.ExecuteScalar; // Execution Type
            string[] arrPara = new string[2];    // Parameters required for executing Procedure
            string[] arrVal = new string[2];    // Values of Parameters required for executing Procedure
            prop.arrPara = arrPara;
            prop.arrParaValues = arrVal;
            arrPara[0] = "@Mode";
            arrVal[0] = "CntAuth3";
            arrPara[1] = "@strUsrid";
            arrVal[1] = uid;
            cnt1 =Convert.ToInt32(func.Add_sqlPara(prop));

           
            prop.arrPara = arrPara;
            prop.arrParaValues = arrVal;
            arrPara[0] = "@Mode";
            arrVal[0] = "CntAuth33";
            arrPara[1] = "@strUsrid";
            arrVal[1] = uid;
            cnt2 = Convert.ToInt32(func.Add_sqlPara(prop));
            if (cnt1 > 0)
            {
                prop.Procname = "Proc_BankAmdMods"; // Procedure name
                prop.key = "TMBCON";          // Connection Key
                prop.ExeType = ExecuteType.ExecuteNull; // Execution Type
                string[] arrPara1 = new string[2];    // Parameters required for executing Procedure
                string[] arrVal1 = new string[2];    // Values of Parameters required for executing Procedure
                prop.arrPara = arrPara1;
                prop.arrParaValues = arrVal1;
                arrPara1[0] = "@Mode";
                arrVal1[0] = "GetAuth3";
                arrPara1[1] = "@strUsrid";
                arrVal1[1] = uid;
                DataSet ds = new DataSet();
                ds = (DataSet)func.Add_sqlPara(prop);

                if (!(ds.Tables[0].Rows.Count == 0))
                {
                    int n = 0;

                    for (n = 0; n <= ds.Tables[0].Rows.Count - 1; n++)
                    {

                        if (flag1 == 0)
                        {
                            string mod_nm1 = "";
                            if (Information.IsDBNull(ds.Tables[0].Rows[n]["mod_nm"]) == false)
                            {
                                mod_nm1 = ds.Tables[0].Rows[n]["mod_nm"].ToString();
                            }
                            else
                            {
                                mod_nm1 = "";
                            }

                            if (!string.IsNullOrEmpty(mod_nm1) & !string.IsNullOrEmpty(modnm))
                            {
                                if (modnm == mod_nm1)
                                {
                                    flag1 = flag1 + 1;
                                }
                            }

                        }

                    }

                }
                else
                {
                    flag1 = 0;
                }

            }
            else if  (cnt2 > 0)
            {
                prop.Procname = "Proc_BankAmdMods"; // Procedure name
                prop.key = "TMBCON";          // Connection Key
                prop.ExeType = ExecuteType.ExecuteNull; // Execution Type
                string[] arrPara1 = new string[2];    // Parameters required for executing Procedure
                string[] arrVal1 = new string[2];    // Values of Parameters required for executing Procedure
                prop.arrPara = arrPara1;
                prop.arrParaValues = arrVal1;
                arrPara1[0] = "@Mode";
                arrVal1[0] = "GetAuth32";
                arrPara1[1] = "@strUsrid";
                arrVal1[1] = uid;
                DataSet ds = new DataSet();
                ds = (DataSet)func.Add_sqlPara(prop);

                if (!(ds.Tables[0].Rows.Count == 0))
                {
                    int n = 0;

                    for (n = 0; n <= ds.Tables[0].Rows.Count - 1; n++)
                    {

                        if (flag1 == 0)
                        {
                            string mod_nm1 = "";
                            if (Information.IsDBNull(ds.Tables[0].Rows[n]["mod_nm"]) == false)
                            {
                                mod_nm1 = ds.Tables[0].Rows[n]["mod_nm"].ToString();
                            }
                            else
                            {
                                mod_nm1 = "";
                            }

                            if (!string.IsNullOrEmpty(mod_nm1) & !string.IsNullOrEmpty(modnm))
                            {
                                if (modnm == mod_nm1)
                                {
                                    flag1 = flag1 + 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    flag1 = 0;
                }
            }
            else
            {
                flag1 = 0;
            }
            if (flag1 == 0)
            {
                return false;
            }
            else if (flag1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
