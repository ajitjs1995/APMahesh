Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

Partial Class Admin_Manage_UserModAuth
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationSettings.AppSettings("TMBCON"))
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New Data.DataSet
    Dim dr As SqlDataReader
    Private chkclass As New AdmChkClass

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        If Not Page.IsPostBack Then

            If chkclass.Chk_ModAuth(Session("log_name"), "Manage Administration", "Manage Users", Session("usr_privilege")) = True Then
                ''''''''''''''''''''''''''''''''''''''''''

                lblUsrNm.Text = "Modules Alloted to : " & Session("UsrEdit")
                bind_mods()
                Dim UsrLogNm As String = Session("UsrEdit")

                Dim usrnm As String = Session("usr_privilege")




                If usrnm = "admin" Then
                    '    If Session("usr_privilege") = "Maker" Then
                    btnChk.Visible = True
                    '    Else
                    '        btnChk.Visible = True
                    '    End If
                ElseIf usrnm = "Both" Then
                    '    If Session("usr_privilege") = "Maker" Then
                    btnChk.Visible = True
                ElseIf usrnm = "Maker" Then
                    btnChk.Visible = False

                ElseIf usrnm = "Checker" Then
                    btnChk.Visible = True

                Else
                    Response.Redirect("AdmMainPage.aspx")
                End If

                Dim modcheck As String = ""
                con.Open()
                cmd = New SqlCommand("Proc_AmdLog", con)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strLogNm", Session("UsrEdit"))
                cmd.Parameters("@Mode").Value = "GetModAuthChk"

                If IsDBNull(cmd.ExecuteScalar()) = False Then
                    modcheck = cmd.ExecuteScalar()
                Else
                    modcheck = "N"
                End If
                con.Close()

                If modcheck = "Y" Then
                    btnChk.Visible = False
                Else
                    btnChk.Visible = True
                End If

                '''''''''''''''''''''''''''''''''''''''''
            Else
                Response.Redirect("AdmMainPage.aspx")
            End If


        End If
    End Sub
    Sub get_ModAuthAuthority(ByVal lognm1 As String, ByVal AuthNm1 As String)

        Session("current_mod") = "Manage Administration"

        If Session("usr_privilege") = "admin" Then
            Session("auth_view") = "Y"
            Session("auth_add") = "Y"
            Session("auth_edit") = "Y"
            Session("auth_delete") = "Y"
            Session("auth_arch") = "Y"
            Session("auth_reply") = "Y"
            Session("auth_check") = "Y"
        ElseIf Session("usr_privilege") = "Both" Then
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
            cmd = New SqlCommand("Proc_AmdMods", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            cmd.Parameters.AddWithValue("@strAuthNm", "Manage Users")
            cmd.Parameters.AddWithValue("@strUsrNm", Replace(Replace(Session("UsrEdit"), "'", "''"), "<", ""))
            cmd.Parameters("@Mode").Value = "CntAuthByNmUnm"
            cnt1 = cmd.ExecuteScalar
            con.Close()

            If Not cnt1 = 0 Then

                con.Open()
                cmd = New SqlCommand("Proc_AmdMods", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strAuthNm", "Manage Users")
                cmd.Parameters.AddWithValue("@strUsrNm", Replace(Replace(Session("UsrEdit"), "'", "''"), "<", ""))
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

    Sub fill_UsrAuth(ByVal lognm As String)

        Dim n As Integer = 0
        For n = 0 To dg_UsrAuth.Items.Count - 1

            Dim mod_id1 As String = dg_UsrAuth.Items(n).Cells(0).Text
            If Not mod_id1 = "" Then

                Dim len1 As Integer = CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items.Count
                Dim i As Integer = 0
                For i = 0 To len1 - 1

                    Dim ModAuth_Id1 As String = CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(0).Text

                    ''''''''''''''''''''''fill main modules
                    Dim cnt2 As Integer = 0
                    con.Open()
                    cmd = New SqlCommand("Proc_AmdMods", con)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                    cmd.Parameters.AddWithValue("@strAuthId", Replace(Replace(ModAuth_Id1, "'", "''"), "<", ""))
                    cmd.Parameters.AddWithValue("@strModId", Replace(Replace(mod_id1, "'", "''"), "<", ""))
                    cmd.Parameters.AddWithValue("@strUsrNm", Replace(Replace(lognm, "'", "''"), "<", ""))
                    cmd.Parameters("@Mode").Value = "CntAuthorMkr1"
                    cnt2 = cmd.ExecuteScalar()
                    con.Close()


                    If cnt2 > 0 Then

                        con.Open()
                        cmd = New SqlCommand("Proc_AmdMods", con)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                        cmd.Parameters.AddWithValue("@strAuthId", Replace(Replace(ModAuth_Id1, "'", "''"), "<", ""))
                        cmd.Parameters.AddWithValue("@strModId", Replace(Replace(mod_id1, "'", "''"), "<", ""))
                        cmd.Parameters.AddWithValue("@strUsrNm", Replace(Replace(lognm, "'", "''"), "<", ""))
                        cmd.Parameters("@Mode").Value = "GetAuthorMkr1"
                        da = New SqlDataAdapter
                        da.SelectCommand = cmd
                        ds = New DataSet
                        da.Fill(ds, "tbl_Authors1")
                        con.Close()

                        If Not ds.Tables("tbl_Authors1").Rows.Count = 0 Then

                            Dim k As Integer = 0
                            For k = 0 To ds.Tables("tbl_Authors1").Rows.Count - 1

                                Dim view1 As String = ""
                                Dim add1 As String = ""
                                Dim edit1 As String = ""
                                Dim delete1 As String = ""
                                Dim Arch1 As String = ""
                                Dim reply1 As String = ""
                                Dim check1 As String = ""

                                If IsDBNull(ds.Tables("tbl_Authors1").Rows(k)("auth_view")) = False Then
                                    view1 = ds.Tables("tbl_Authors1").Rows(k)("auth_view")
                                Else
                                    view1 = ""
                                End If

                                If IsDBNull(ds.Tables("tbl_Authors1").Rows(k)("auth_add")) = False Then
                                    add1 = ds.Tables("tbl_Authors1").Rows(k)("auth_add")
                                Else
                                    add1 = ""
                                End If

                                If IsDBNull(ds.Tables("tbl_Authors1").Rows(k)("auth_edit")) = False Then
                                    edit1 = ds.Tables("tbl_Authors1").Rows(k)("auth_edit")
                                Else
                                    edit1 = ""
                                End If

                                If IsDBNull(ds.Tables("tbl_Authors1").Rows(k)("auth_delete")) = False Then
                                    delete1 = ds.Tables("tbl_Authors1").Rows(k)("auth_delete")
                                Else
                                    delete1 = ""
                                End If

                                If IsDBNull(ds.Tables("tbl_Authors1").Rows(k)("auth_arch")) = False Then
                                    Arch1 = ds.Tables("tbl_Authors1").Rows(k)("auth_arch")
                                Else
                                    Arch1 = ""
                                End If

                                If IsDBNull(ds.Tables("tbl_Authors1").Rows(k)("auth_reply")) = False Then
                                    reply1 = ds.Tables("tbl_Authors1").Rows(k)("auth_reply")
                                Else
                                    reply1 = ""
                                End If

                                If IsDBNull(ds.Tables("tbl_Authors1").Rows(k)("auth_check")) = False Then
                                    check1 = ds.Tables("tbl_Authors1").Rows(k)("auth_check")
                                Else
                                    check1 = ""
                                End If


                                If view1 = "Y" Then
                                    CType(CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(3).FindControl("chkView"), CheckBox).Checked = True
                                End If
                                If add1 = "Y" Then
                                    CType(CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(4).FindControl("chkAdd"), CheckBox).Checked = True
                                End If
                                If edit1 = "Y" Then
                                    CType(CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(5).FindControl("chkEdit"), CheckBox).Checked = True
                                End If
                                If delete1 = "Y" Then
                                    CType(CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(6).FindControl("chkDelete"), CheckBox).Checked = True
                                End If
                                If Arch1 = "Y" Then
                                    CType(CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(7).FindControl("chkArchive"), CheckBox).Checked = True
                                End If
                                If reply1 = "Y" Then
                                    CType(CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(8).FindControl("chkReply"), CheckBox).Checked = True
                                End If
                                If check1 = "Y" Then
                                    CType(CType(dg_UsrAuth.Items(n).Cells(1).FindControl("dg_ModRights"), DataGrid).Items(i).Cells(9).FindControl("chkCheck"), CheckBox).Checked = True
                                End If

                            Next

                        End If

                    End If

                Next

            End If

        Next

    End Sub

    Sub bind_mods()
        Try

            Dim x1 As String = Session("UsrEdit")

            Dim cnt1 As Integer = 0
            con.Open()
            cmd = New SqlCommand("Proc_AmdMods", con)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@strUsrNm", Replace(Replace(Session("UsrEdit"), "'", "''"), "<", ""))
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            cmd.Parameters("@Mode").Value = "CntUsrAuthMkr1"
            cnt1 = cmd.ExecuteScalar()
            con.Close()

            If cnt1 > 0 Then

                con.Open()
                cmd = New SqlCommand("Proc_AmdMods", con)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@strUsrNm", Replace(Replace(Session("UsrEdit"), "'", "''"), "<", ""))
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters("@Mode").Value = "GetUsrAuthmodnm1"
                da = New SqlDataAdapter
                da.SelectCommand = cmd
                ds = New DataSet
                da.Fill(ds, "tbl_auths")
                con.Close()

                If Not ds.Tables("tbl_auths").Rows.Count = 0 Then
                    dg_UsrAuth.Visible = True
                    Try
                        dg_UsrAuth.DataSource = ds.Tables("tbl_auths").DefaultView
                        dg_UsrAuth.DataBind()
                    Catch
                        Try
                            Me.dg_UsrAuth.CurrentPageIndex = 0
                            Me.dg_UsrAuth.DataBind()
                        Catch ex As Exception
                            'Response.Write(ex.ToString())
                        End Try
                    End Try

                Else
                    dg_UsrAuth.DataSource = Nothing
                    dg_UsrAuth.DataBind()
                    dg_UsrAuth.Visible = False
                End If

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

    Protected Sub btnOk_Click(sender As Object, e As System.EventArgs) Handles btnOk.Click
        Session("UsrEdit") = ""
        Session("UsrEdit") = ""

        Response.Write("<script type='text/javascript'>detailedresults=window.close();</script>")
    End Sub

    Protected Sub btnChk_Click(sender As Object, e As System.EventArgs) Handles btnChk.Click
        Try



            con.Open()
            cmd = New SqlCommand("Proc_AmdMods", con)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            cmd.Parameters.AddWithValue("@strUsrNm", Session("UsrEdit"))
            cmd.Parameters("@Mode").Value = "delUsrMods1"
            cmd.ExecuteNonQuery()
            con.Close()

            con.Open()
            cmd = New SqlCommand("Proc_AmdMods", con)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            cmd.Parameters.AddWithValue("@strUsrNm", Session("UsrEdit"))
            cmd.Parameters("@Mode").Value = "getCheckUsrMods1"
            da.SelectCommand = cmd
            ds = New DataSet()
            da.Fill(ds, "tbl")
            Dim j As Integer = 0
            Dim id As String = ""
            Dim officerid As String = ""
            Dim staff As String = ""
            Dim mod1 As String = ""
            Dim act As String = ""
            For j = 0 To ds.Tables("tbl").Rows.Count - 1
                id = ds.Tables("tbl").Rows(j)("id1").ToString()
                officerid = ds.Tables("tbl").Rows(j)("offcr_id").ToString()
                staff = ds.Tables("tbl").Rows(j)("off_staff_no").ToString()
                mod1 = ds.Tables("tbl").Rows(j)("mod_id").ToString()
                act = ds.Tables("tbl").Rows(j)("active").ToString()

                ' con.Open()
                cmd = New SqlCommand("Proc_AmdMods", con)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                cmd.Parameters.AddWithValue("@strId1", id)
                cmd.Parameters.AddWithValue("@strAuthId", officerid)
                cmd.Parameters.AddWithValue("@strModId", mod1)
                cmd.Parameters.AddWithValue("@strModAct", act)
                cmd.Parameters("@Mode").Value = "addmod"
                cmd.ExecuteNonQuery()
                'con.Close()

            Next

            con.Close()

            ''''''''''''''''''''''''''''' update module allotment checked field
            con.Open()
            cmd = New SqlCommand("Proc_AmdMods", con)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            cmd.Parameters.AddWithValue("@strUsrNm", Session("UsrEdit"))
            cmd.Parameters("@Mode").Value = "CheckUsrMods1"
            cmd.ExecuteNonQuery()
            con.Close()
            'con.Open()
            'cmd = New SqlCommand("Proc_User_Master", con)
            'cmd.CommandType = Data.CommandType.StoredProcedure
            'cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            'cmd.Parameters.AddWithValue("@strUsrNm", staff)
            'cmd.Parameters("@Mode").Value = "UserModCheckMkr"
            'cmd.ExecuteNonQuery()

            'con.Close()
            ''''''''''''''''''''''''''''''''' btnCheck 
            Dim modcheck As String = ""
            con.Open()
            cmd = New SqlCommand("Proc_AmdLog", con)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
            cmd.Parameters.AddWithValue("@strLogNm", Session("UsrEdit"))
            cmd.Parameters("@Mode").Value = "GetModAuthChk"
            If IsDBNull(cmd.ExecuteScalar()) = False Then
                modcheck = cmd.ExecuteScalar()
            Else
                modcheck = "N"
            End If
            con.Close()

            If modcheck = "Y" Then
                btnChk.Visible = False
            Else
                btnChk.Visible = True
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
    

    Protected Sub dg_UsrAuth_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dg_UsrAuth.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem Or e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.EditItem Then

            Dim mod_id As String = ""
            If IsDBNull(DataBinder.Eval(e.Item.DataItem, "mod_id")) = False Then
                mod_id = DataBinder.Eval(e.Item.DataItem, "mod_id")
                e.Item.Cells(0).Text = mod_id
            Else
                mod_id = ""
                e.Item.Cells(0).Text = ""
            End If

            Dim mod_nm As String = ""
            If IsDBNull(DataBinder.Eval(e.Item.DataItem, "mod_nm")) = False Then
                mod_nm = DataBinder.Eval(e.Item.DataItem, "mod_nm")
                CType(e.Item.Cells(1).FindControl("lblMainModuleNm"), Label).Text = mod_nm
            Else
                mod_nm = ""
                CType(e.Item.Cells(1).FindControl("lblMainModuleNm"), Label).Text = ""
            End If

           

        End If

    End Sub
End Class
