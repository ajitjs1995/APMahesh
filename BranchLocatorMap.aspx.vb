Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions

Partial Class BranchLocatorMap
    Inherits System.Web.UI.Page
    Private cmd As SqlCommand = New SqlCommand()
    Private cmd1 As SqlCommand = New SqlCommand()
    Private da As SqlDataAdapter = New SqlDataAdapter()
    Private ds As System.Data.DataSet = New System.Data.DataSet()
    Private ds1 As System.Data.DataSet = New System.Data.DataSet()
    Private dt As DataTable
    Private dr As SqlDataReader
    Public con As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("TMBCON").ToString())
    Private val As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not Me.IsPostBack Then
            state()
            ctyy.Items.Add("Please Select District")
        End If
    End Sub

    Public Sub state()
        con.Open()
        cmd = New SqlCommand("USP_BranchMaster", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Query", SqlDbType.VarChar, 50))
        cmd.Parameters("@Query").Value = "FillState"
        da = New SqlDataAdapter()
        da.SelectCommand = cmd
        dt = New DataTable()
        da.Fill(dt)
        stt.DataSource = dt
        stt.Items.Add("Please Select State")
        stt.DataTextField = "State"
        stt.DataBind()
        con.Close()
    End Sub

    Public Sub city()
        ctyy.Items.Clear()
        con.Open()
        cmd = New SqlCommand("USP_BranchMaster", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Query", SqlDbType.VarChar, 50))
        cmd.Parameters("@Query").Value = "FillDistrict"
        cmd.Parameters.AddWithValue("@State", stt.SelectedItem.Text)
        da = New SqlDataAdapter()
        da.SelectCommand = cmd
        ds = New DataSet()
        da.Fill(ds, "Branch_Mastre")
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        ctyy.DataSource = dr
        ctyy.Items.Add("Please Select District")
        ctyy.DataTextField = "District"
        ctyy.DataBind()
        con.Close()
    End Sub

    Protected Sub btnreset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnreset.Click
        cleardata()
    End Sub

    Public Sub cleardata()
        LblError.Visible = False
        stt.Items.Clear()
        state()
        ctyy.Items.Clear()
        ctyy.Items.Add("Please Select District")
    End Sub

    Protected Sub state_selection(ByVal sender As Object, ByVal e As EventArgs) Handles stt.SelectedIndexChanged
        city()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsrch.Click
        Try
            con.Open()
            cmd = New SqlCommand("Proc_map", con)
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50))
            cmd.Parameters.AddWithValue("@state", stt.SelectedValue.Trim())
            cmd.Parameters.AddWithValue("@city", ctyy.SelectedValue.Trim())
            cmd.Parameters("@mode").Value = "GetValue"
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            da.SelectCommand = cmd
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "map")
            rptMarkers.DataSource = ds
            rptMarkers.DataBind()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub
End Class
