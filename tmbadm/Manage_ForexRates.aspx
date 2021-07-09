<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/tmbadm/AdmMaster.master"
    CodeFile="Manage_ForexRates.aspx.cs" Inherits="tmbadm_Manage_ForexRates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <script type="text/javascript">
        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <asp:Label ID="Label2" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="Large">Update Forex Rates</asp:Label>
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
                            <th valign="top">
                                <p>Buy</p>
                            </th>
                            <th valign="top">
                                <p>Sell</p>
                            </th>
                            <th valign="top">
                                <p>View Trend Charts</p>
                            </th>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>US Dollar</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSBuy" onkeypress="return isNumberKey(event,this)" CssClass="form-control" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSSells" onkeypress="return isNumberKey(event,this)" CssClass="form-control" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>Today~P.Day~7 Day~30 Day</p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>Euro</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEurobuy" onkeypress="return isNumberKey(event,this)" CssClass="form-control" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEuroSells" onkeypress="return isNumberKey(event,this)"  CssClass="form-control" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>Today~P.Day~7 Day~30 Day</p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>GB Pounds</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBBuy" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBSells" CssClass="form-control" MaxLength="7" Width="50px" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>Today~P.Day~7 Day~30 Day</p>
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
                                <td style="height: 5px"></td>
                            </tr>
                            <tr>
                                <th valign="top">
                                    <p>Currency</p>
                                </th>
                                <th valign="top">
                                    <p>Buy</p>
                                </th>
                                <th valign="top">
                                    <p>Sell</p>
                                </th>
                                <th valign="top">
                                    <p>View Trend Charts</p>
                                </th>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>US Dollar</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSBuy"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSSell"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>Today~P.Day~7 Day~30 Day</p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>Euro</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroBuy"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroSells"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>Today~P.Day~7 Day~30 Day</p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>GB Pounds</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBBuy"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBSells"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>Today~P.Day~7 Day~30 Day</p>
                                </td>
                            </tr>

                        </tbody>
                    </table>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
