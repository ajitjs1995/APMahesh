Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Admin_Manage_PageRights
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationSettings.AppSettings("TMBCON"))
    Dim cmd As New SqlCommand
    Dim cmd2 As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New Data.DataSet
    Dim da1 As New SqlDataAdapter
    Dim ds1 As New Data.DataSet
    Dim dr As SqlDataReader
    Dim userid As Integer
    Private chkclass As New AdmChkClass

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        '  lblpath1 = Me.Form.Parent.FindControl("lblCubModNm")
        If Not Session("usr_privilege") = "" Then


            If Not Session("usr_privilege").ToString() = "admin" Then
                Try
                    con.Open()
                    Dim cnt As Integer
                    'cmd = New SqlCommand("select count(*) from USerModAuthMaker a , tbl_AdmModules b where a .off_staff_no='" + Session("UsrEdit").ToString() + "' and a.mod_id=b.mod_id and b.mod_nm='Adminstrator'", con)
                    cmd = New SqlCommand("Proc_User_Master", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 50))
                    cmd.Parameters.AddWithValue("@strStaffNum", Session("UsrEdit").ToString())
                    cmd.Parameters.AddWithValue("@strAuthName", "CMS")
                    cmd.Parameters("@Mode").Value = "countmoduleusr"
                    cnt = Convert.ToInt32(cmd.ExecuteScalar())
                    con.Close()
                    If cnt = 0 Then
                        Response.Redirect("AdmMainPage.aspx")

                    End If



                Catch ex As Exception

                Finally

                End Try
            End If

        End If

        If Not Page.IsPostBack Then

            'lblpath1.Text = "Content Management : Page Rights"

            If chkclass.Chk_ModAuth(Session("log_name"), "Content Management", "Manage Page Rights", Session("usr_privilege")) = True Then
                ''''''''''''''''''''''''''''''''''''''''''

                get_ModAuthAuthority(Session("log_name"), "Manage Page Rights")

                Session("auth_view") = Session("auth_view")
                Session("auth_add") = Session("auth_add")
                Session("auth_edit") = Session("auth_edit")
                Session("auth_delete") = Session("auth_delete")
                Session("auth_arch") = Session("auth_arch")
                Session("auth_reply") = Session("auth_reply")
                Session("auth_check") = Session("auth_check")
                Session("userid") = ""
                clear_data()

                fill_PageTypes()
                fill_UsrData()
                fill_UsrPgAuth()
                '
                If Session("usr_privilege") = "admin" Then
                    'If Session("log_prevlg") = "Maker" Then
                    btnCheck.Visible = True
                    btnEdit.Visible = True
                    'Else
                    '    btnCheck.Visible = True
                    '    btnEdit.Visible = False
                    'End If

                ElseIf Session("usr_privilege") = "Both" Then
                    'If Session("log_prevlg") = "Maker" Then
                    btnCheck.Visible = True
                    btnEdit.Visible = True


                ElseIf Session("usr_privilege") = "Maker" Then
                    btnCheck.Visible = False
                    ' If Session("auth_add") = "Y" Or Session("auth_edit") = "Y" Then
                    btnEdit.Visible = True
                    ' Else
                    '    btnEdit.Visible = False
                    ' End If

                Else
                    btnEdit.Visible = False
                    ' If Session("auth_check") = "Y" Then
                    btnCheck.Visible = True
                    ' Else
                    ' btnCheck.Visible = False
                End If

                ' End If


                '''''''''''''''''''''''''''''''''''''''''
            Else
                Response.Redirect("AdmMainPage.aspx")
            End If

        End If
    End Sub
    Sub get_ModAuthAuthority(ByVal lognm1 As String, ByVal AuthNm1 As String)

        Session("current_mod") = "Content Management"

        If Session("usr_privilege") = "admin" Or Session("usr_privilege") = "Both" Then
            Session("auth_view") = "Y"
            Session("auth_add") = "Y"
            Session("auth_edit") = "Y"
            Session("auth_delete") = "Y"
            Session("auth_arch") = "Y"
            Session("auth_reply") = "Y"
            Session("auth_check") = "Y"
        Else

            Dim cnt1 As Integer = 0
            con.Open()
            cmd = New SqlCommand("Proc_BankAmdMods", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            ' cmd.Parameters.AddWithValue("@strAuthNm", "Manage Page Rights")
            cmd.Parameters.AddWithValue("@strstaffno", Session("log_name"))
            cmd.Parameters("@Mode").Value = "CntAuthByNmUnm"
            cnt1 = cmd.ExecuteScalar
            con.Close()

            If Not cnt1 = 0 Then

                con.Open()
                cmd = New SqlCommand("Proc_BankAmdMods", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                'cmd.Parameters.AddWithValue("@strAuthNm", "Manage Page Rights")
                cmd.Parameters.AddWithValue("@strstaffno", Session("log_name"))
                cmd.Parameters("@Mode").Value = "GetAuthByNmUnm"
                da = New SqlDataAdapter
                da.SelectCommand = cmd
                ds = New DataSet
                da.Fill(ds, "tbl_off_auth")
                con.Close()
                If Not ds.Tables("tbl_off_auth").Rows.Count = 0 Then

                    If IsDBNull(ds.Tables("tbl_off_auth").Rows(0)("auth_view")) = False Then
                        Session("auth_view") = ds.Tables("tbl_off_auth").Rows(0)("auth_view")
                    Else
                        Session("auth_view") = "N"
                    End If

                    If IsDBNull(ds.Tables("tbl_off_auth").Rows(0)("auth_add")) = False Then
                        Session("auth_add") = ds.Tables("tbl_off_auth").Rows(0)("auth_add")
                    Else
                        Session("auth_add") = "N"
                    End If

                    If IsDBNull(ds.Tables("tbl_off_auth").Rows(0)("auth_edit")) = False Then
                        Session("auth_edit") = ds.Tables("tbl_off_auth").Rows(0)("auth_edit")
                    Else
                        Session("auth_edit") = "N"
                    End If

                    If IsDBNull(ds.Tables("tbl_off_auth").Rows(0)("auth_delete")) = False Then
                        Session("auth_delete") = ds.Tables("tbl_off_auth").Rows(0)("auth_delete")
                    Else
                        Session("auth_delete") = "N"
                    End If

                    If IsDBNull(ds.Tables("tbl_off_auth").Rows(0)("auth_arch")) = False Then
                        Session("auth_arch") = ds.Tables("tbl_off_auth").Rows(0)("auth_arch")
                    Else
                        Session("auth_arch") = "N"
                    End If

                    If IsDBNull(ds.Tables("tbl_off_auth").Rows(0)("auth_reply")) = False Then
                        Session("auth_reply") = ds.Tables("tbl_off_auth").Rows(0)("auth_reply")
                    Else
                        Session("auth_reply") = "N"
                    End If

                    If IsDBNull(ds.Tables("tbl_off_auth").Rows(0)("auth_check")) = False Then
                        Session("auth_check") = ds.Tables("tbl_off_auth").Rows(0)("auth_check")
                    Else
                        Session("auth_check") = "N"
                    End If

                End If

            End If

        End If

    End Sub

    Sub clear_data()

        lblName.Text = ""
        lblEmail.Text = ""
        lblUserType.Text = ""
        lblMainDept.Text = ""
        lblSubDept.Text = ""
        lblUsrNm.Text = ""

        dg_fillPage.DataSource = Nothing
        dg_fillPage.DataBind()

        lblmsg.Text = ""

    End Sub

    Sub fill_PageTypes()

        Try

            Dim cnt1 As Integer = 0
            con.Open()
            cmd2 = New SqlCommand("Proc_ManageCmsPages", con)
            cmd2.CommandType = Data.CommandType.StoredProcedure
            cmd2.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 50))
            cmd2.Parameters("@Mode").Value = "cntParMainTypes1"
            cnt1 = cmd2.ExecuteScalar()
            con.Close()

            If cnt1 > 0 Then

                con.Open()
                cmd2 = New SqlCommand("Proc_ManageCmsPages", con)
                cmd2.CommandType = Data.CommandType.StoredProcedure
                cmd2.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 50))
                'cmd2.Parameters("@Mode").Value = "getParMainTypes1"
                cmd2 = New SqlCommand("select a.MainParentId,a.MainParentName,b.parentid,b.MainPageName from Main_PageParents a,Main_Pages b where a.MainParentId=b.MainParent  order by a.MainParentId,b.parentid  ", con)
                da1 = New SqlDataAdapter
                da1.SelectCommand = cmd2
                ds1 = New DataSet
                ds1.Clear()
                da1.Fill(ds1, "tbl")
                con.Close()

                If Not ds1.Tables("tbl").Rows.Count = 0 Then
                    lblmsg.Text = ds1.Tables("tbl").Rows.Count & " Records found !!"
                    dg_fillPage.Visible = True
                    Try
                        dg_fillPage.DataSource = ds1.Tables("tbl").DefaultView
                        dg_fillPage.DataBind()
                    Catch
                        Try
                            Me.dg_fillPage.CurrentPageIndex = 0
                            Me.dg_fillPage.DataBind()
                        Catch ex As Exception
                            'Response.Write(ex.ToString())
                        End Try
                    End Try

                Else
                    dg_fillPage.DataSource = Nothing
                    dg_fillPage.DataBind()
                    dg_fillPage.Visible = False
                    lblmsg.Text = "No Records found !!"
                End If

            Else
                dg_fillPage.DataSource = Nothing
                dg_fillPage.DataBind()
                dg_fillPage.Visible = False
                lblmsg.Text = "No Records found !!"
            End If


        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    con.Close()
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("ErrorPg.aspx")
                Catch

                End Try
            End If
        End Try

    End Sub

    Sub fill_UsrData()
        Try

            Dim UsrLogId As String = Session("UsrEdit")
            Dim UsrLogNm As String = Session("edit_lognm")

            If Not UsrLogNm = "" Then

                lblmsg.Text = ""
                Dim cnt1 As Integer = 0
                con.Open()
                cmd = New SqlCommand("Proc_AmdLog", con)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strlog_id", UsrLogId)
                cmd.Parameters("@Mode").Value = "cntUsrChkrByUid"
                cnt1 = cmd.ExecuteScalar()
                con.Close()

                If cnt1 > 0 Then

                    con.Open()
                    cmd = New SqlCommand("Proc_AmdLog", con)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                    cmd.Parameters.AddWithValue("@strlog_id", UsrLogId)

                    cmd.Parameters("@Mode").Value = "shUsrChkrByUid"


                    da = New SqlDataAdapter
                    da.SelectCommand = cmd
                    ds = New DataSet
                    da.Fill(ds, "tbl_UsrDtl")
                    con.Close()

                    Dim x1 As String = ds.Tables("tbl_UsrDtl").Rows.Count

                    If Not ds.Tables("tbl_UsrDtl").Rows.Count = 0 Then

                        For i = 0 To ds.Tables("tbl_UsrDtl").Rows.Count - 1

                            If IsDBNull(ds.Tables("tbl_UsrDtl").Rows(0)("officer_name")) = False Then
                                lblName.Text = ds.Tables("tbl_UsrDtl").Rows(0)("officer_name")
                            Else
                                lblName.Text = "--"
                            End If

                            If IsDBNull(ds.Tables("tbl_UsrDtl").Rows(0)("officer_id")) = False Then
                                userid = ds.Tables("tbl_UsrDtl").Rows(0)("officer_id").ToString
                                lblSubDept.Text = userid
                            Else
                                userid = "--"
                            End If

                            If IsDBNull(ds.Tables("tbl_UsrDtl").Rows(0)("officer_email")) = False Then
                                lblEmail.Text = ds.Tables("tbl_UsrDtl").Rows(0)("officer_email")
                            Else
                                lblEmail.Text = "--"
                            End If

                            If IsDBNull(ds.Tables("tbl_UsrDtl").Rows(0)("officer_privilege")) = False Then
                                lblUserType.Text = ds.Tables("tbl_UsrDtl").Rows(0)("officer_privilege")
                            Else
                                lblUserType.Text = "--"
                            End If

                            If IsDBNull(ds.Tables("tbl_UsrDtl").Rows(0)("officer_uid")) = False Then
                                lblUsrNm.Text = ds.Tables("tbl_UsrDtl").Rows(0)("officer_uid")
                            Else
                                lblUsrNm.Text = "--"
                            End If


                        Next

                        'fill_DeptDtls()

                    Else
                        lblmsg.Text = "No user found !!"
                        clear_data()
                    End If
                Else
                    lblmsg.Text = "No user found !!"
                    clear_data()
                End If

            Else
                lblmsg.Text = "No user found !!"
                clear_data()
            End If

        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    con.Close()
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("ErrorPg.aspx")
                Catch

                End Try
            End If
        End Try
    End Sub

    Sub fill_DeptDtls()

        Try

            If Not lblUserType.Text = "" And Not lblUserType.Text = "--" Then

                Dim cnt1 As Integer = 0
                con.Open()
                cmd = New SqlCommand("Proc_DeptMaster", con)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text.Trim)
                If lblUserType.Text = "Dept" Then
                    cmd.Parameters("@Mode").Value = "CntUsrDeptNm1"
                ElseIf lblUserType.Text = "Sub Dept" Then
                    cmd.Parameters("@Mode").Value = "CntUsrSubDeptNm1"
                ElseIf lblUserType.Text = "ZO" Then
                    cmd.Parameters("@Mode").Value = "CntUsrZoNm1"
                ElseIf lblUserType.Text = "Branch" Then
                    cmd.Parameters("@Mode").Value = "CntUsrBrNm1"
                End If
                cnt1 = cmd.ExecuteScalar()
                con.Close()

                If cnt1 > 0 Then

                    con.Open()
                    cmd = New SqlCommand("Proc_DeptMaster", con)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                    cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)

                    If lblUserType.Text = "Dept" Then
                        cmd.Parameters("@Mode").Value = "GetUsrDeptNm1"
                    ElseIf lblUserType.Text = "Sub Dept" Then
                        cmd.Parameters("@Mode").Value = "GetUsrSubDeptNm1"
                    ElseIf lblUserType.Text = "ZO" Then
                        cmd.Parameters("@Mode").Value = "GetUsrZoNm1"
                    ElseIf lblUserType.Text = "Branch" Then
                        cmd.Parameters("@Mode").Value = "GetUsrBrNm1"
                    End If
                    da = New SqlDataAdapter
                    da.SelectCommand = cmd
                    ds = New DataSet
                    da.Fill(ds, "tbl_DeptDtls1")
                    con.Close()

                    If Not ds.Tables("tbl_DeptDtls1").Rows.Count = 0 Then

                        For i = 0 To ds.Tables("tbl_DeptDtls1").Rows.Count - 1

                            If IsDBNull(ds.Tables("tbl_DeptDtls1").Rows(0)("DeptNm1")) = False Then
                                lblMainDept.Text = ds.Tables("tbl_DeptDtls1").Rows(0)("DeptNm1")
                            Else
                                lblMainDept.Text = "--"
                            End If

                            If lblUserType.Text = "Sub Dept" Then
                                If IsDBNull(ds.Tables("tbl_DeptDtls1").Rows(0)("SubDeptNm1")) = False Then
                                    lblSubDept.Text = ds.Tables("tbl_DeptDtls1").Rows(0)("SubDeptNm1")
                                Else
                                    lblSubDept.Text = "--"
                                End If
                            Else
                                lblSubDept.Text = "--"
                            End If

                        Next

                    Else
                        lblmsg.Text = "No user found !!"
                        clear_data()
                    End If

                Else
                    lblMainDept.Text = ""
                    lblSubDept.Text = ""
                End If

            Else
                lblMainDept.Text = ""
                lblSubDept.Text = ""
            End If

        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    con.Close()
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("ErrorPg.aspx")
                Catch

                End Try
            End If
        End Try

    End Sub

    Function chk_CmsAuth()

        Dim cnt1 As Integer = 0
        con.Open()
        cmd = New SqlCommand("Proc_AmdMods", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 50))
        cmd.Parameters.AddWithValue("@strModName", "CMS")
        cmd.Parameters.AddWithValue("@strstaffno", lblSubDept.Text)
        cmd.Parameters("@Mode").Value = "CntAuthByNmUnm_m"
        cnt1 = cmd.ExecuteScalar()
        con.Close()

        If cnt1 > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Sub fill_UsrPgAuth()

        ''''''''''''''''''''''fill main modules
        Dim cnt1 As Integer = 0
        con.Open()
        cmd = New SqlCommand("Proc_ManageCmsPages", con)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 50))
        cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
        cmd.Parameters("@Mode").Value = "CntPgAuthByIdUnm_M"
        cnt1 = cmd.ExecuteScalar()
        con.Close()

        Dim p As Integer = 0
        For p = 0 To dg_fillPage.Items.Count - 1
            CType(dg_fillPage.Items(p).Cells(1).FindControl("chkAllot"), CheckBox).Checked = False
        Next

        If cnt1 > 0 Then

            con.Open()
            cmd = New SqlCommand("Proc_ManageCmsPages", con)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 50))
            ' cmd.Parameters("@Mode").Value = "GetUsrAuthMkr1"
            cmd = New SqlCommand("select a.*,c.*,b.* from Main_PageParents a,Main_Pages b,tbl_PageAuthority_maker c,UserMasterMaker d where a.MainParentId=b.MainParent and b.parentid=c.ParentId and c.active='Y' and c.UsrLog=d.officer_uid and d.officer_uid='" + lblUsrNm.Text + "'  ", con)
            da = New SqlDataAdapter
            da.SelectCommand = cmd
            ds = New DataSet
            da.Fill(ds, "tbl_modAuth1")
            con.Close()

            If Not ds.Tables("tbl_modAuth1").Rows.Count = 0 Then

                Dim i As Integer = 0
                Dim authid1 As String = ""
                Dim authunm1 As String = ""
                Dim authmod1 As String = ""

                For i = 0 To ds.Tables("tbl_modAuth1").Rows.Count - 1

                    If IsDBNull(ds.Tables("tbl_modAuth1").Rows(i)("parentid")) = False Then
                        authid1 = ds.Tables("tbl_modAuth1").Rows(i)("parentid")
                    Else
                        authid1 = ""
                    End If

                    If IsDBNull(ds.Tables("tbl_modAuth1").Rows(i)("UsrLog")) = False Then
                        authunm1 = ds.Tables("tbl_modAuth1").Rows(i)("UsrLog")
                    Else
                        authunm1 = ""
                    End If

                    If IsDBNull(ds.Tables("tbl_modAuth1").Rows(i)("ParentId")) = False Then
                        authmod1 = ds.Tables("tbl_modAuth1").Rows(i)("ParentId")
                    Else
                        authmod1 = ""
                    End If

                    Dim j As Integer = 0
                    Dim x1 As Integer = dg_fillPage.Items.Count
                    For j = 0 To dg_fillPage.Items.Count - 1
                        'Dim mod1 As String = ""
                        'mod1 = dg_Mod.Items(j).Cells(2).Text

                        Dim modid1 As String = ""
                        modid1 = dg_fillPage.Items(j).Cells(3).Text

                        If modid1 = authid1 Then
                            CType(dg_fillPage.Items(j).Cells(1).FindControl("chkAllot"), CheckBox).Checked = True
                        End If

                    Next

                Next

            End If

        End If

        ' fill_UsrModuleAuth(lognm)


    End Sub

    Sub fill_UsrPgAuth1()

        Try

            If chk_CmsAuth() = True Then
                lblmsg.Text = ""

                Dim x1 As Integer = dg_fillPage.Items.Count
                If x1 > 0 Then

                    Dim i As Integer = 0
                    For i = 0 To dg_fillPage.Items.Count - 1

                        Dim PgId1 As String = dg_fillPage.Items(i).Cells(3).Text

                        If Not PgId1 = "" Then
                            ''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim PgParCnt As Integer = 0
                            con.Open()
                            cmd = New SqlCommand("Proc_ManageCmsPages", con)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 50))
                            cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                            cmd.Parameters.AddWithValue("@strParentId1", PgId1)
                            cmd.Parameters("@Mode").Value = "CntPgAuthByIdUnm_M"
                            PgParCnt = cmd.ExecuteScalar()
                            con.Close()

                            If PgParCnt > 0 Then
                                CType(dg_fillPage.Items(i).Cells(5).FindControl("chkAllot"), CheckBox).Checked = True
                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                    Next

                End If

            Else
                dg_fillPage.DataSource = Nothing
                dg_fillPage.DataBind()
                btnEdit.Visible = False
                lblmsg.Text = "MS module is not allotted to this user !!"
            End If

        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    con.Close()
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("ErrorPg.aspx")
                Catch

                End Try
            End If
        End Try

    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As System.EventArgs) Handles btnEdit.Click
        Try
            Dim k As Integer = 0
            Dim allot1 As Integer = 0
            Dim j As Integer = 0
            For k = 0 To dg_fillPage.Items.Count - 1
                If CType(dg_fillPage.Items(k).Cells(5).FindControl("chkAllot"), CheckBox).Checked = True Then
                    allot1 = allot1 + 1
                End If
            Next

            If allot1 > 0 Then
                lblmsg.Text = ""



                For j = 0 To dg_fillPage.Items.Count - 1

                    If CType(dg_fillPage.Items(j).Cells(5).FindControl("chkAllot"), CheckBox).Checked = True Then

                        Dim parId1 As String = dg_fillPage.Items(j).Cells(3).Text
                        Dim cnt12 As Integer = 0
                        Dim act As String = ""


                        con.Open()
                        cmd = New SqlCommand("Proc_ManageMenus", con)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                        cmd.Parameters.AddWithValue("@strParentId1", parId1)
                        cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                        cmd.Parameters("@Mode").Value = "chkAuthForUsr_M"
                        cnt12 = Convert.ToInt32(cmd.ExecuteScalar())
                        con.Close()


                        If cnt12 = 0 Then



                            con.Open()
                            cmd = New SqlCommand("Proc_ManageCmsPages", con)
                            cmd.CommandType = Data.CommandType.StoredProcedure
                            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                            cmd.Parameters.AddWithValue("@strParentId1", parId1)
                            cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                            cmd.Parameters.AddWithValue("@strPgAuthDt", Now.Date)
                            cmd.Parameters.AddWithValue("@checked1", "N")
                            cmd.Parameters("@Mode").Value = "AddPgAuthMkr"
                            cmd.ExecuteNonQuery()
                            con.Close()

                        Else

                            con.Open()
                            cmd = New SqlCommand("Proc_AmdLog", con)
                            cmd.CommandType = Data.CommandType.StoredProcedure
                            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                            cmd.Parameters.AddWithValue("@strParentId1", parId1)
                            cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                            cmd.Parameters("@Mode").Value = "chkAuthForact"
                            act = Convert.ToString(cmd.ExecuteScalar())
                            con.Close()
                            If act = "N" Then
                                con.Open()
                                cmd = New SqlCommand("Proc_AmdLog", con)
                                cmd.CommandType = Data.CommandType.StoredProcedure
                                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                                cmd.Parameters.AddWithValue("@strParentId1", parId1)
                                cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                                cmd.Parameters("@Mode").Value = "chkAuthForactUpd"
                                cmd.ExecuteNonQuery()
                                con.Close()

                            End If

                        End If

                    End If



                Next


                con.Open()
                cmd = New SqlCommand("Proc_User_Master", con)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strUsrNm", lblUsrNm.Text)
                cmd.Parameters("@Mode").Value = "UserModCheckMkr"
                cmd.ExecuteNonQuery()
                con.Close()

                audit_trail()

                'clear_data()

                lblmsg.Text = "Page authorities are updated successfully !!"

            End If

            For j = 0 To dg_fillPage.Items.Count - 1

                If CType(dg_fillPage.Items(j).Cells(5).FindControl("chkAllot"), CheckBox).Checked = False Then

                    Dim parId1 As String = dg_fillPage.Items(j).Cells(3).Text
                    Dim cnt12 As Integer = 0


                    con.Open()
                    cmd = New SqlCommand("Proc_AmdLog", con)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                    cmd.Parameters.AddWithValue("@strParentId1", parId1)
                    cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                    cmd.Parameters("@Mode").Value = "chkAuthForUsr_M"
                    cnt12 = Convert.ToInt32(cmd.ExecuteScalar())
                    con.Close()

                    If cnt12 > 0 Then



                        con.Open()
                        cmd = New SqlCommand("Proc_AmdLog", con)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                        cmd.Parameters.AddWithValue("@strParentId1", parId1)
                        cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                        cmd.Parameters("@Mode").Value = "updateAuthForUsr_M"
                        cmd.ExecuteNonQuery()
                        con.Close()

                    End If

                End If
            Next
            lblmsg.Text = "Page authorities are updated successfully !!"


        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    con.Close()
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("ErrorPg.aspx")
                Catch

                End Try
            End If
        Finally
            con.Close()


        End Try
    End Sub
    Protected Sub btnCheck_Click(sender As Object, e As System.EventArgs) Handles btnCheck.Click
        Try

            Dim i As Integer = 0
            Dim j As Integer = 0
            For i = 0 To dg_fillPage.Items.Count - 1
                If CType(dg_fillPage.Items(i).Cells(5).FindControl("chkAllot"), CheckBox).Checked = True Then
                    j = j + 1
                End If
            Next



            Try
                con.Open()
                cmd = New SqlCommand("Proc_ManageMenus", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                cmd.Parameters("@Mode").Value = "DelPgAuthForUsr_C"
                cmd.ExecuteNonQuery()
                con.Close()

            Catch ex As Exception
                Dim ma1 As String = ""
                ma1 = ex.ToString

                If Not ma1.Contains("Thread was being aborted") Then
                    Try
                        con.Close()
                        Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                        Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                        sw.WriteLine(ex.Message)
                        sw.Write(ex.StackTrace)
                        sw.Close()
                        Response.Redirect("ErrorPg.aspx")
                    Catch

                    End Try
                End If
            Finally
                con.Close()
            End Try





            Try
                con.Open()
                cmd = New SqlCommand("Proc_ManageMenus", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                cmd.Parameters("@Mode").Value = "getpageauth"
                da = New SqlDataAdapter
                da.SelectCommand = cmd
                ds = New DataSet
                da.Fill(ds, "tab_offMkrPgAuth")

                con.Close()

            Catch ex As Exception
                Dim ma1 As String = ""
                ma1 = ex.ToString

                If Not ma1.Contains("Thread was being aborted") Then
                    Try
                        con.Open()
                        Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                        Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                        sw.WriteLine(ex.Message)
                        sw.Write(ex.StackTrace)
                        sw.Close()
                        Response.Redirect("ErrorPg.aspx")
                    Catch

                    End Try
                End If
            Finally
                con.Close()
            End Try


            Dim k As Integer = 0
            For k = 0 To ds.Tables("tab_offMkrPgAuth").Rows.Count - 1

                Dim pgAuthId As String = ""
                Dim PgParId As String = ""
                Dim act As String = ""

                If IsDBNull(ds.Tables("tab_offMkrPgAuth").Rows(k)("PgAuthId1")) = False Then
                    pgAuthId = ds.Tables("tab_offMkrPgAuth").Rows(k)("PgAuthId1")
                Else
                    pgAuthId = ""
                End If

                If IsDBNull(ds.Tables("tab_offMkrPgAuth").Rows(k)("ParentId")) = False Then
                    PgParId = ds.Tables("tab_offMkrPgAuth").Rows(k)("ParentId")
                Else
                    PgParId = ""
                End If
                If IsDBNull(ds.Tables("tab_offMkrPgAuth").Rows(k)("active")) = False Then
                    act = ds.Tables("tab_offMkrPgAuth").Rows(k)("active")
                Else
                    act = ""
                End If

                If Not pgAuthId = "" And Not PgParId = "" Then

                    Try
                        con.Open()
                        cmd = New SqlCommand("Proc_ManageMenus", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                        cmd.Parameters.AddWithValue("@PgAuthId", pgAuthId)
                        cmd.Parameters.AddWithValue("@strLogNm", lblUsrNm.Text)
                        cmd.Parameters.AddWithValue("@strPgAuthDt", Now.Date)
                        cmd.Parameters.AddWithValue("@strParentId1", PgParId)
                        cmd.Parameters.AddWithValue("@strAction", act)
                        cmd.Parameters("@Mode").Value = "AddPgAuthChkr1"
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        Dim ma1 As String = ""
                        ma1 = ex.ToString

                        If Not ma1.Contains("Thread was being aborted") Then
                            Try
                                con.Close()
                                Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                                Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                                sw.WriteLine(ex.Message)
                                sw.Write(ex.StackTrace)
                                sw.Close()
                                Response.Redirect("ErrorPg.aspx")
                            Catch

                            End Try
                        End If
                    Finally
                        con.Close()
                    End Try

                    Try
                        con.Open()
                        cmd = New SqlCommand("Proc_ManageCmsPages", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                        cmd.Parameters.AddWithValue("@PgAuthId", pgAuthId)
                        cmd.Parameters("@Mode").Value = "ChkPgAuthMkr1"
                        cmd.ExecuteNonQuery()
                        con.Close()

                    Catch ex As Exception
                        Dim ma1 As String = ""
                        ma1 = ex.ToString

                        If Not ma1.Contains("Thread was being aborted") Then
                            Try
                                con.Close()
                                Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                                Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                                sw.WriteLine(ex.Message)
                                sw.Write(ex.StackTrace)
                                sw.Close()
                                Response.Redirect("ErrorPg.aspx")
                            Catch

                            End Try
                        End If
                    Finally
                        con.Close()
                    End Try


                End If

            Next

            lblmsg.Text = "Page authorities are updated check successfully !!"



        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    con.Open()
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("ErrorPg.aspx")
                Catch

                End Try
            End If
        Finally
            con.Close()
        End Try

    End Sub


    Sub audit_trail()
        Try
            If dg_fillPage.Items.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''
                Dim j As Integer = 0
                Dim AllotedPg As String = ""
                For j = 0 To dg_fillPage.Items.Count - 1

                    If CType(dg_fillPage.Items(j).Cells(5).FindControl("chkAllot"), CheckBox).Checked = True Then

                        Dim MainpgNm1 As String = dg_fillPage.Items(j).Cells(2).Text
                        Dim pgNm1 As String = dg_fillPage.Items(j).Cells(4).Text
                        If Not pgNm1 = "" And MainpgNm1 = "" Then

                            If AllotedPg = "" Then
                                AllotedPg = pgNm1
                            Else
                                AllotedPg = AllotedPg & ", " & MainpgNm1 & " - " & pgNm1
                            End If

                        End If

                    End If

                Next

                Dim fields1 As String = ""
                fields1 = "Alloted To : " & lblUsrNm.Text

                If Not AllotedPg = "" Then
                    If fields1 = "" Then
                        fields1 = "Pages Alloted : " & AllotedPg
                    Else
                        fields1 = fields1 & ", Pages Alloted : " & AllotedPg
                    End If
                End If

                con.Open()
                cmd = New SqlCommand("proc_audittrail", con)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strLogNm", Session("log_name"))
                cmd.Parameters.AddWithValue("@strTblNm", "PageAuthority_tbl")
                cmd.Parameters.AddWithValue("@strFildNm", fields1)
                cmd.Parameters.AddWithValue("@strPgNm", "Adm_PageRights.aspx")
                cmd.Parameters.AddWithValue("@strModuleNm", "Content Management")
                cmd.Parameters.AddWithValue("@strAuditDt", Now.Date)
                cmd.Parameters.AddWithValue("@strAddOn", Now.Date)
                cmd.Parameters("@mode").Value = "AuditOnAdd"
                cmd.ExecuteNonQuery()
                con.Close()
                ''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    con.Open()
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("ErrorPg.aspx")
                Catch

                End Try
            End If
        Finally
            con.Close()
        End Try

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        clear_data()
        lblmsg.Text = ""
        Session("UsrEdit") = ""
        Session("edit_lognm") = ""
        Response.Redirect("ManageUsers.aspx")
    End Sub

    Protected Sub chkall_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then


            Dim p As Integer = 0
            For p = 0 To dg_fillPage.Items.Count - 1
                CType(dg_fillPage.Items(p).Cells(1).FindControl("chkAllot"), CheckBox).Checked = True
            Next
        Else
            Dim p As Integer = 0
            For p = 0 To dg_fillPage.Items.Count - 1
                CType(dg_fillPage.Items(p).Cells(1).FindControl("chkAllot"), CheckBox).Checked = False
            Next
        End If
    End Sub
End Class
