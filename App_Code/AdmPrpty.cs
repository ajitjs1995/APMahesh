using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Summary description for AdmPrpty
/// </summary>
public class AdmPrpty
{

    public string _lognm;
    public string _logid;
    public string _logpwd;
    public string _tblnm;
    public string _fieldnm;
    public string _pgnm;
    public string _modnm;
    public string _auditdt;
    public string _remark;
    public string _added;


    public string Logid
    {
        get { return _logid; }
        set { _logid = value; }
    }

    public string LogNm
    {
        get { return _lognm; }
        set { _lognm = value; }
    }
    public string LogPwd
    {
        get { return _logpwd; }
        set { _logpwd = value; }
    }
    public string TblNm
    {
        get { return _tblnm; }
        set { _tblnm = value; }
    }

    public string FieldNm
    {
        get { return _fieldnm; }
        set { _fieldnm = value; }
    }
    public string PageNm
    {
        get { return _pgnm; }
        set { _pgnm = value; }
    }
    public string ModuleNm
    {
        get { return _modnm; }
        set { _modnm = value; }
    }

    public string Auditdt
    {
        get { return _auditdt; }
        set { _auditdt = value; }
    }
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }

    public string Addon
    {
        get { return _added; }
        set { _added = value; }
    }

}
