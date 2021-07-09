<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/tmbadm/AdmMaster.master"
    CodeFile="Manage_IFCRates.aspx.cs" Inherits="tmbadm_Manage_IFCRates" %>

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
                <table runat="server" id="tblUpdate" class="admtbl tblUpdate" style="height: 246px; width: 80%" cellspacing="1"
                    cellpadding="10" border="0">
                    <tbody>
                        <tr>
                            <td valign="middle" align="center" colspan="8" class="tdHeader">
                                <asp:Label ID="Label2" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="Large">Update Indicative/Forward/Cross Rates</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" valign="middle" align="left">&nbsp;<asp:Label ID="lblErr" runat="server" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th valign="top">
                                <p>Currency</p>
                            </th>
                            <th valign="top">
                                <p>For Export</p>
                            </th>
                            <th valign="top">
                                <p>For Import</p>
                            </th>
                            <th valign="top">
                                <p>For Export</p>
                            </th>
                            <th valign="top">
                                <p>For Import</p>
                            </th>
                            <th valign="top">
                                <p>For Export</p>
                            </th>
                            <th valign="top">
                                <p>For Import</p>
                            </th>
                            <th valign="top">
                                <p>Month</p>
                            </th>
                        </tr>
                        <tr>
                            <th></th>
                            <th align="center" colspan="2" valign="top">Indicative Rates</th>
                            <th align="center" colspan="2" valign="top">Indicative Forward Rates</th>
                            <th align="center" colspan="2" valign="top">Indicative Cross Rates</th>
                            <th></th>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>USD</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSIREx" TabIndex="1" CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSIRIm" TabIndex="2"  CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSIFREx" TabIndex="3"  CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSIFRIm" TabIndex="4"  CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSICREx" TabIndex="5"  CssClass="form-control" onkeypress="return isNumberKey(event,this)"  MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtUSICRIm" TabIndex="6"  CssClass="form-control" onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:DropDownList runat="server" ID="ddlMonthUS" TabIndex="7"  CssClass="form-control"  MaxLength="7" Width="110px">
                                        <asp:ListItem Selected="True" Text="---Month---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                            </td>

                        </tr>
                        <tr>
                            <td valign="top">
                                <p>GBP</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBIREx" CssClass="form-control" TabIndex="8"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBIRIm" CssClass="form-control" TabIndex="9"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBIFREx" CssClass="form-control" TabIndex="10"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBIFRIm" CssClass="form-control" TabIndex="11"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBICREx" CssClass="form-control" TabIndex="12"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtGBICRIm" CssClass="form-control" TabIndex="13"  MaxLength="7" onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:DropDownList runat="server" ID="ddlGBMonth" CssClass="form-control" TabIndex="14"  MaxLength="7" Width="110px">
                                        <asp:ListItem Selected="True" Text="---Month---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>Euro</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEuroIREx" CssClass="form-control" TabIndex="15"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEuroIRIm" CssClass="form-control" TabIndex="16"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEuroIFREx" CssClass="form-control" TabIndex="17"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEuroIFRIm" CssClass="form-control" TabIndex="18"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEuroICREx" CssClass="form-control" TabIndex="19"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtEuroICRIm" CssClass="form-control" TabIndex="20"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:DropDownList runat="server" ID="ddlEuroMonth" TabIndex="21"  CssClass="form-control" MaxLength="7" Width="110px">
                                        <asp:ListItem Selected="True" Text="---Month---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>JPY</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYIREx" CssClass="form-control" TabIndex="22"  MaxLength="7" onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYIRIm" CssClass="form-control"  TabIndex="23"  MaxLength="7" onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYIFREx" CssClass="form-control" MaxLength="7"  TabIndex="23"  onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYIFRIm" CssClass="form-control" MaxLength="7"  TabIndex="24" onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYICREx" CssClass="form-control" MaxLength="7"  TabIndex="25"  onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtJPYICRIm" CssClass="form-control" MaxLength="7"  TabIndex="26"  onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:DropDownList runat="server" ID="ddlJPYMonth" CssClass="form-control" MaxLength="7"  TabIndex="27"  Width="110px">
                                        <asp:ListItem Selected="True" Text="---Month---" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <p>CHF</p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFIREx" CssClass="form-control"  TabIndex="28"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFIRIM" CssClass="form-control"  TabIndex="29"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFIFREx" CssClass="form-control"  TabIndex="30"  MaxLength="7" onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFIFRIm" CssClass="form-control"  TabIndex="31"  MaxLength="7" onkeypress="return isNumberKey(event,this)" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFICREx" CssClass="form-control"  TabIndex="32"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:TextBox runat="server" ID="txtCHFICRIm" CssClass="form-control"  TabIndex="33"  onkeypress="return isNumberKey(event,this)" MaxLength="7" Width="50px"></asp:TextBox>
                                </p>
                            </td>
                            <td valign="top">
                                <p>
                                    <asp:DropDownList runat="server" ID="ddlCHFMonth" CssClass="form-control"  TabIndex="34"  MaxLength="7" Width="110px">
                                   <asp:ListItem Selected="True" Text="---Month---" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                </p>
                            </td>
                        </tr>

                        <tr style="text-align: center">
                            <td colspan="8">
                                <asp:Button runat="server" ID="btnAdd" Text="Update" CssClass="btn7" OnClick="btnAdd_Click"  TabIndex="35"  />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn7" OnClick="btnReset_Click"  TabIndex="36"  />
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
                    <table runat="server" id="tblGrid" visible="false" class="tblGrid" style="height: 246px; width: 100%" cellspacing="1" 
                        cellpadding="10" border="0">
                        <tbody>

                            <tr>
                                <th valign="top">
                                    <p>Currency</p>
                                </th>
                                <th valign="top">
                                    <p>For Export</p>
                                </th>
                                <th valign="top">
                                    <p>For Import</p>
                                </th>
                                <th valign="top">
                                    <p>For Export</p>
                                </th>
                                <th valign="top">
                                    <p>For Import</p>
                                </th>
                                <th valign="top">
                                    <p>For Export</p>
                                </th>
                                <th valign="top">
                                    <p>For Import</p>
                                </th>
                                <th valign="top">
                                    <p>Month</p>
                                </th>

                            </tr>
                            <tr>
                                <th></th>
                                <th align="center" colspan="2" valign="top">Indicative Rates</th>
                                <th align="center" colspan="2" valign="top">Indicative Forward Rates</th>
                                <th align="center" colspan="2" valign="top">Indicative Cross Rates</th>
                                <th></th>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>USD</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSIREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSIRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSIFREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSICREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSICRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblUSMonth" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>

                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>GBP</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBIREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBIRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBIFREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBICREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBICRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblGBMonth" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>Euro</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroIREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroIRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroIFREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroICREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroICRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblEuroMonth" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>JPY</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYIREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYIRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYIFREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYICREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYICRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblJPYMonth" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p>CHF</p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFIREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFIRIM" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFIFREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFICREx" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFICRIm" MaxLength="7" Width="50px"></asp:Label>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p>
                                        <asp:Label runat="server" ID="lblCHFMonth" MaxLength="7" Width="50px"></asp:Label>
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
