Imports System.IO
Imports System.Diagnostics
Partial Class searchpage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            Dim paramStr As String = ""
            Dim parampos As Integer = Request.RawUrl.IndexOf("?")
            If (parampos >= 0) Then
                paramStr = Request.RawUrl.Substring((parampos + 1))
            End If
            Dim psi As ProcessStartInfo = New ProcessStartInfo
            psi.FileName = Server.MapPath("search.cgi")
            psi.EnvironmentVariables("REQUEST_METHOD") = "GET"
            psi.EnvironmentVariables("QUERY_STRING") = paramStr

            psi.EnvironmentVariables("REMOTE_ADDR") = Request.ServerVariables("REMOTE_ADDR")
            psi.RedirectStandardInput = False
            psi.RedirectStandardOutput = True
            psi.UseShellExecute = False
            Dim proc As Process = Process.Start(psi)
            proc.StandardOutput.ReadLine()
            Dim zoom_results As String = proc.StandardOutput.ReadToEnd
            Dim zoom_results1 As String = Replace(zoom_results, "ï»¿", "")
            ' read from stdout 
            'proc.WaitForExit()
            ' Print the output 


            Dim ReqSrchWord As String = ""
            ReqSrchWord = Request.QueryString("zoom_query")
            If Not ReqSrchWord = "" And chkText1(ReqSrchWord) = False Then
                Page.RegisterClientScriptBlock("key", "<script>alert('Hello World');</script>")


            Else

                Dim strOutput = zoom_results1.Replace("<form method=""get"" action=""search.cgi"" class=""zoom_searchform"">", "<form method=""get"" action=""SearchPage.aspx"" class=""zoom_searchform"">")
                'Response.Write(strOutput)
                Dim strOutput1 = strOutput.Replace("search.cgi", "searchPage.aspx")
                strOutput1 = strOutput1.Replace("<input type=""submit"" value=""Submit"" class=""zoom_button"" />", "<input type=""submit"" value=""Submit"" class=""zoom_button"" onclick='return check(this.form)'/>")

                Response.Write(strOutput1)
                'Response.Write(zoom_results)
            End If
            'testaaa.aspx



            If Not Page.IsPostBack Then

                'Dim x1 As String = ""
                'x1 = Request.QueryString("zoom_query")
                'Dim x2 As String = x1

            End If


        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("InvalidPage.htm")
                Catch

                End Try
            End If
        End Try
    End Sub

    Function chkText1(ByVal data1 As String)

        Try


            Dim allowed1 As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_&., "
            Dim ALLOW_FLAG As Integer = 0

            Dim txtchar As String = ""
            Dim allchar As String = ""

            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim next1 As Integer = 0

            Dim flag1 As Integer = 0
            Dim flag2 As Integer = 0
            Dim charfound As Integer = 0

            For i = 0 To data1.Length - 1
                txtchar = data1.Chars(i)
                charfound = 0

                If flag1 = i Then

                    For j = 0 To allowed1.Length - 1

                        allchar = allowed1.Chars(j)
                        flag2 = j + 1
                        If charfound = 0 Then
                            If txtchar = allchar Then
                                flag1 = flag1 + 1
                                charfound = 1
                            Else
                                'flag1 = 0
                                charfound = 0
                            End If
                        End If

                    Next

                End If

            Next

            If flag1 = data1.Length Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            'Response.Write(ex.ToString())
            Dim ma1 As String = ""
            ma1 = ex.ToString

            If Not ma1.Contains("Thread was being aborted") Then
                Try
                    Dim ErrorPath As String = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath")
                    Dim sw As New StreamWriter(ErrorPath + "ErrorLog" + Now.ToString("yyyyddmm") + ".txt", True)
                    sw.WriteLine(ex.Message)
                    sw.Write(ex.StackTrace)
                    sw.Close()
                    Response.Redirect("InvalidPage.htm")
                Catch

                End Try
            End If
        End Try

    End Function
End Class
