<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/tmbadm/AdmMaster.master"
    CodeFile="Manage_CardRates.aspx.cs" Inherits="tmbadm_Manage_CardRates" %>

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
            text-align: center;
        }

        .tblUpdate p {
            text-align: center;
        }

        .wrap {
            outline: 1px dotted blue; /* Just for demonstration... */
            overflow: auto;
        }

            .wrap label {
                outline: 1px dashed blue;
                float: left;
                width: 10em;
                margin-right: 1.00em;
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
    <table id="tbl_main" runat="server" style="width: 80%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td style="width: 5px; height: 20px;"
                valign="middle" align="center"></td>

            <td style="width: 150%; height: 20px;" valign="middle" align="center">
                <table runat="server" id="tblUpdate" class="admtbl tblUpdate" style="height: 246px; width: 100%" cellspacing="1"
                    cellpadding="10" border="0">
                    <tbody>
                        <tr>
                            <td valign="middle" align="center" colspan="8" class="tdHeader">
                                <asp:Label ID="Label2" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="Large">Update Card Rates</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" valign="middle" align="left">&nbsp;<asp:Label ID="lblErr" runat="server" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Add Header</p>
                            </td>
                            <td colspan="7" valign="middle" align="left">&nbsp;
                                <asp:TextBox ID="txtHeader" TextMode="MultiLine" Width="1000px"   Rows="5" Height="100px" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th valign="top">
                                <p>Currency</p>
                            </th>
                            <th valign="top">
                                <p>TT</p>
                            </th>
                            <th valign="top">
                                <p>Bills</p>
                            </th>
                            <th valign="top">
                                <p>Cheqs</p>
                            </th>
                            <th valign="top">
                                <p>Bills</p>
                            </th>
                            <th valign="top">
                                <p>TT</p>
                            </th>

                        </tr>
                        <tr>

                            <th align="center" valign="top">Foreign Currency</th>
                            <th align="center" colspan="3" valign="top">Buying</th>
                            <th align="center" colspan="2" valign="top">Selling</th>
                            <th></th>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>USD</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSBTT" TabIndex="1" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSBBill" TabIndex="2" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSBChq" TabIndex="3" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSSBill" TabIndex="4" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSSTT" TabIndex="5" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>GBP</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBPBTT" TabIndex="6" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBPBBill" TabIndex="7" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBPBChq" TabIndex="8" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBPSBill" TabIndex="9" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBPSTT" TabIndex="10" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>

                        </tr>
                        <tr>
                            <td valign="top">
                                <p>Euro</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEURBTT" TabIndex="11" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEURBBill" TabIndex="12" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEURBChq" TabIndex="13" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEURSBill" TabIndex="14" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEURSTT" TabIndex="15" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>

                        </tr>
                        <tr>
                            <td valign="top">
                                <p>JPY</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYBTT" TabIndex="16" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYBBill" TabIndex="17" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYBChq" TabIndex="18" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYSBill" TabIndex="19" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYSTT" TabIndex="20" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>

                        </tr>
                        <tr>
                            <td valign="top">
                                <p>AUD</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAUDBTT" TabIndex="21" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAUDBBill" TabIndex="22" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAUDBChq" TabIndex="23" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAUDSBill" TabIndex="24" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAUDSTT" TabIndex="25" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>CAD</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCADBTT" TabIndex="26" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCADBBill" TabIndex="27" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCADBChq" TabIndex="28" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCADSBill" TabIndex="29" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCADSTT" TabIndex="30" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>

                        </tr>
                        <tr>
                            <td valign="top">
                                <p>CHF</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFBTT" TabIndex="31" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFBBill" TabIndex="32" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFBChq" TabIndex="33" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFSBill" TabIndex="34" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFSTT" TabIndex="35" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td valign="top">
                                <p>SGD</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtSGDBTT" TabIndex="36" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtSGDBBill" TabIndex="37" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtSGDBChq" TabIndex="38" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtSGDSBill" TabIndex="39" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtSGDSTT" TabIndex="40" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>AED</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAEDBTT" TabIndex="41" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAEDBBill" TabIndex="42" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAEDBChq" TabIndex="43" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAEDSBill" TabIndex="44" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtAEDSTT" TabIndex="45" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td style="width: 30px; height: 20px;" valign="middle" align="center"></td>
        </tr>
        <tr>
            <td style="width: 5px; height: 20px;"
                valign="middle" align="center"></td>
            <td style="width: 150%; height: 20px;" valign="middle" align="center">
                <table runat="server" id="tblUpdate2" class="admtbl" style="height: 246px; width: 100%" cellspacing="1"
                    cellpadding="10" border="0">
                    <tbody>
                        <tr>
                            <th valign="top">
                                <p style="text-align: center">Currency</p>
                            </th>
                            <th valign="top">
                                <p style="text-align: center">CCY Buying</p>
                            </th>
                            <th valign="top">
                                <p style="text-align: center">CCY Selling</p>
                            </th>
                            <th valign="top">
                                <p style="text-align: center">TC Buying</p>
                            </th>
                            <th valign="top">
                                <p style="text-align: center">TC Selling</p>
                            </th>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>USD</p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtUSDCCYBuying" TabIndex="46" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtUSDCCYSelling" TabIndex="47" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtUSDTCBuying" TabIndex="48" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtUSDTCSelling" TabIndex="49" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>GBP</p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtGBPCCYBuying" TabIndex="50" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtGBPCCYSelling" TabIndex="51" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtGBPTCBuying" TabIndex="52" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtGBPTCSelling" TabIndex="53" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>EUR</p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtEURCCYBuying" TabIndex="54" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtEURCCYSelling" TabIndex="55" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtEURTCBuying" TabIndex="56" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p style="text-align: center">
                                    <asp:TextBox runat="server" ID="txtEURTCSelling" TabIndex="57" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="5" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr style="text-align: center">

                            <td colspan="8">
                                <asp:Button runat="server" ID="btnAdd" Text="Update" CssClass="btn7" OnClick="btnAdd_Click" TabIndex="58" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn7" TabIndex="59" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>


            </td>

        </tr>

        <tr>
            <td style="width: 30px; height: 20px;" valign="middle" align="center"></td>
        </tr>
        <tr>
            <td style="width: 30px; height: 20px;" valign="middle" align="center"></td>
        </tr>


        <tr>
            <td style="width: 30px; height: 20px;" valign="middle" align="center"></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <center>
                    <table runat="server" id="tblGrid" visible="false" class="tblGrid" style="height: 246px; width: 70%" cellspacing="1"
                        cellpadding="10" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label1" Text="Header" Font-Bold="true"></asp:Label>
                                </td>
                                <td>:</td>
                                <td colspan="6">
                                    <asp:Label runat="server" ID="lblHeader" CssClass=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;"></td>
                            </tr>
                            <tr>
                                <th valign="top">
                                    <p>Currency</p>
                                </th>
                                <th valign="top">
                                    <p>TT</p>
                                </th>
                                <th valign="top">
                                    <p>Bills</p>
                                </th>
                                <th valign="top">
                                    <p>Cheqs</p>
                                </th>
                                <th valign="top">
                                    <p>Bills</p>
                                </th>
                                <th valign="top">
                                    <p>TT</p>
                                </th>

                            </tr>
                            <tr>

                                <th align="center" valign="top">Foreign Currency</th>
                                <th align="center" colspan="3" valign="top">Buying</th>
                                <th align="center" colspan="2" valign="top">Selling</th>

                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>USD</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSSTT"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>GBP</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBPBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBPBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBPBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBPSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBPSTT"></asp:Label>
                                    </p>
                                </td>

                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>Euro</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEURBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEURBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEURBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEURSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEURSTT"></asp:Label>
                                    </p>
                                </td>

                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>JPY</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYSTT"></asp:Label>
                                    </p>
                                </td>

                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>AUD</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAUDBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAUDBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAUDBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAUDSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAUDSTT"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>CAD</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCADBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCADBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCADBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCADSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCADSTT"></asp:Label>
                                    </p>
                                </td>

                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>CHF</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFSTT"></asp:Label>
                                    </p>
                                </td>
                            </tr>

                            <tr>
                                <td valign="top">
                                    <p>SGD</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblSGDBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblSGDBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblSGDBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblSGDSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblSGDSTT"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>AED</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAEDBTT"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAEDBBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAEDBChq"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAEDSBill"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblAEDSTT"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>
            </td>

        </tr>
        <tr>
            <td style="height: 10px;"></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <center>
                    <table runat="server" id="tblGrid1" class="tblGrid" style="height: 246px; width: 80%" cellspacing="1" cellpadding="10" border="0">
                        <tbody>
                            <tr>
                                <th valign="top">
                                    <p style="text-align: center">Currency</p>
                                </th>
                                <th valign="top">
                                    <p style="text-align: center">CCY Buying</p>
                                </th>
                                <th valign="top">
                                    <p style="text-align: center">CCY Selling</p>
                                </th>
                                <th valign="top">
                                    <p style="text-align: center">TC Buying</p>
                                </th>
                                <th valign="top">
                                    <p style="text-align: center">TC Selling</p>
                                </th>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>USD</p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblUSDCCYBuying"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblUSDCCYSelling"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblUSDTCBuying"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblUSDTCSelling"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>GBP</p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblGBPCCYBuying"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblGBPCCYSelling"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblGBPTCBuying"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblGBPTCSelling"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>EUR</p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblEURCCYBuying"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblEURCCYSelling"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblEURTCBuying"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="text-align: center">
                                        <asp:Label runat="server" ID="lblEURTCSelling"  Width="50px"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>

            </td>
        </tr>
    </table>
</asp:Content>
