<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="ManageTrendIndicatorsINR.aspx.cs" Inherits="Admin_ManageTrendIndicatorsINR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

     
   <script type="text/javascript">
       function onlyDotsAndNumbers(event) {
           var charCode = (event.which) ? event.which : event.keyCode
           if (charCode == 46) {
               return true;
           }
           if (charCode == 47) {
               return true;
           }
           if (charCode > 31 && (charCode < 48 || charCode > 57))
               return false;

           return true;
       }


       function Validate(event) {
           var regex = new RegExp("^[0-9a-z. ]");
           var key = String.fromCharCode(event.charCode ? event.which : event.charCode);
           if (!regex.test(key)) {
               event.preventDefault();
               return false;
           }
       }       

      
    </script>
      
    
    <style type="text/css">
        .tblGrid th {
            background: #18388c;
            color: white;
            height: 25px;
            vertical-align: middle;
            font-size: 15px;
        }

        .tblGrid td {
            background: white;
            color: black;
            height: 30px;
            width: 50px;
            vertical-align: middle;
            font-size: 15px;
        }
        .tblGrid p {
            text-align:center;
        }
        .tblUpdate p {
            text-align:center;
        }
    </style>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
   <table id="tbl_main" runat="server" style="width: 70%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td style="                    width: 5px;
                    height: 20px;
            " valign="middle" align="center"></td>

            <td style="width: 90%; height: 20px;" valign="middle" align="center">
                <table runat="server" id="tblUpdate" class="admtbl tblUpdate" style="height: 246px; width: 80%" cellspacing="1"
                    cellpadding="10" border="0">
                    <tbody>
                        <tr>
                            <td valign="middle" align="center" colspan="4" class="tdHeader">
                                <asp:Label ID="Label5" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="Large">Update Trend Rates</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" valign="middle" align="left">&nbsp;<asp:Label ID="lblErr" runat="server" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th valign="top">
                                <p>Currency</p>
                            </th>
                            <th>
                                <p>USD</p>
                            </th>
                            <th valign="top">
                                <p>EURO</p>
                            </th>
                             <th valign="top">
                                <p>GBP</p>
                            </th>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p style="text-align:center">Previous Day </p>
                            </td>
                            <td valign="top">
                                <p style="text-align:center">
                                    <asp:TextBox runat="server" ID="txtPreUS" CssClass="form-control" MaxLength="11" Width="90px" onkeypress="return onlyDotsAndNumbers(event)" ></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align:center">
                                    <asp:TextBox runat="server" ID="txtPreEURO" CssClass="form-control" MaxLength="11" Width="90px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align:center">
                                    <asp:TextBox runat="server" ID="txtPreGB" CssClass="form-control" MaxLength="11" Width="90px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p style="text-align:center">Today's Opening</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtTodUs" CssClass="form-control" MaxLength="11" Width="90px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtTodEuro" CssClass="form-control" MaxLength="11" Width="90px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtTodGB" CssClass="form-control" MaxLength="11" Width="90px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p style="text-align:center">Today Range</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtRanUS" CssClass="form-control" MaxLength="14" Width="90px" onkeypress="return Validate(event);"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtRanEuro" CssClass="form-control" MaxLength="14" Width="90px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtRanGB" CssClass="form-control" MaxLength="14" Width="90px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p style="text-align:center">Current Month</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCurrUS" CssClass="form-control" MaxLength="14" Width="90px" onkeypress="return Validate(event);"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCurrEuro" CssClass="form-control" MaxLength="14" Width="90px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCurrGB" CssClass="form-control" MaxLength="14" Width="90px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                       
                        <tr style="text-align:center">
                            <td colspan="4">
                                <asp:Button runat="server" ID="btnAdd" Text="Update" CssClass="btn7" OnClick="btnAdd_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn7" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                        
                    </tbody>
                </table>


            </td>
            <td style="width: 30px; height: 20px;" valign="middle" align="center"></td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px;" valign="middle" align="center"></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <center>
                    <table runat="server" id="tblGrid" visible="false" class="tblGrid" style="height: 246px; width: 80%" cellspacing="1"
                        cellpadding="10" border="0">
                        <tbody>


                            <tr>
                                <td style="height: 4px"></td>
                            </tr>
                            <tr>
                                <th valign="top">
                                    <p>Currency</p>
                                </th>
                                <th valign="top">
                                    <p>USD</p>
                                </th>
                                <th valign="top">
                                    <p>EURO</p>
                                </th>
                                 <th valign="top">
                                    <p>GBP</p>
                                </th>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>Previous Day</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblPreUS"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblPreEURO"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblPreGB"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>Today's Opening</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblTodUS"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblTodEURO"></asp:Label>
                                    </p>
                                </td>
                               <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblTodGB"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>Today Range</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblRanUS"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblRanEURO"></asp:Label>
                                    </p>
                                </td>
                                 <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblRanGB"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                             <tr>
                                <td valign="top">
                                    <p>Current Month</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCurrUS"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCurrEURO"></asp:Label>
                                    </p>
                                </td>
                               <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCurrGB"></asp:Label>
                                    </p>
                                </td>
                            </tr>

                        </tbody>
                    </table>
                </center>
            </td>
        </tr>
    </table>
    <table id="Table6" runat="server" style="width: 90%;" cellspacing="0" cellpadding="0"
        align="center">

         <tr>
           <td style="width: 5px; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 550px; height: 20px;" valign="middle" align="center">
                <table id="Table7" runat="server"   style="width: 77%;border-collapse: separate;
                    border: Solid thin #cccccc" class="admtbl"  cellspacing="1" cellpadding="0" border="0">
        <tr>
                        <td valign="middle" align="center" colspan="9"  class="tdHeader">
                            <asp:Label ID="lblAddMainHead" runat="server" Text="Add  Content" ForeColor="#FFFFFF" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        
                      
                       <%-- <td style="height: 25px;" colspan="6" valign="top" align="left">--%>
                        <td colspan="4" valign="middle" align="left">
                        <asp:Label ID="lblerror" runat="server" CssClass="error"></asp:Label>
                        </td>
                    </tr>
        <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 17%;padding-left: 3%;">
                            <asp:Label ID="Label6" runat="server" Text="HEADING :"></asp:Label>
                        </td>
                       
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 20%;padding-Right: 3%;">
                            <asp:Label ID="Label7" runat="server" Text="SPOT/INR :"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                       
                        <td style="padding-left: 5%;" valign="middle" align="left">
                            <asp:TextBox ID="txtheading" runat="server" CssClass="form-control" Width="370px" TextMode="MultiLine" Rows="5" Height="50px"></asp:TextBox>
                        </td>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        
                        <td style="padding-left: 5%;" valign="middle" align="left">
                            <asp:TextBox ID="txtspot" runat="server" CssClass="form-control" Width="370px" TextMode="MultiLine" Rows="5" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                     <td style="width: 2%; height: 20px;" valign="top" align="left">
                        </td>
                    </tr>
                        <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 17%;padding-left: 3%;">
                            <asp:Label ID="Label1" runat="server" Text="FORWARD PREMIUM  :"></asp:Label>
                        </td>
                       
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 20%;padding-Right: 3%;">
                            <asp:Label ID="Label2" runat="server" Text="GLOBAL DEVELOPMENTS :"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                       
                        <td style="padding-left: 5%;" valign="middle" align="left">
                            <asp:TextBox ID="Textforword" runat="server" CssClass="form-control" Width="370px" TextMode="MultiLine" Rows="5" Height="50px" ></asp:TextBox>
                        </td>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        
                        <td style="padding-left: 5%;" valign="middle" align="left">
                            <asp:TextBox ID="Textglobal" runat="server" CssClass="form-control" Width="370px" TextMode="MultiLine" Rows="5" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                     <td style="width: 2%; height: 20px;" valign="top" align="left">
                        </td>
                    </tr>
                      <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 17%;padding-left: 3%;">
                            <asp:Label ID="Label3" runat="server" Text="POSITIVE FACTORS FOR RUPEE :"></asp:Label>
                        </td>
                       
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 20%;padding-Right: 3%;">
                            <asp:Label ID="Label4" runat="server" Text="FACTORS AGAINST RUPEE :"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                       
                        <td style="padding-left: 5%;" valign="middle" align="left">
                            <asp:TextBox ID="Textpositive" runat="server" CssClass="form-control" Width="370px" TextMode="MultiLine" Rows="5" Height="50px"></asp:TextBox>
                        </td>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        
                        <td style="padding-left: 5%;" valign="middle" align="left">
                            <asp:TextBox ID="Textfactor" runat="server" CssClass="form-control" Width="370px" TextMode="MultiLine" Rows="5" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td valign="middle" align="center" colspan="6" style="padding:10px;">
                            <asp:Button ID="Btn" runat="server" Text="Add" class="btn7"
                                   Width="90px" onclick="Btn_Click"  
                                 />&nbsp;&nbsp;
                            <asp:Button ID="Btn1" runat="server" Text="Reset" class="btn7" 
                                 
                                Width="90px" onclick="Btn1_Click"     />
                        
                           
                        </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
        </table>

        </asp:Content>
