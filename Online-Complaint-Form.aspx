<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Online-Complaint-Form.aspx.cs" Inherits="Online_Complaint_Form" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen">
    <link rel="stylesheet" href="css/vertical_menu.css" type="text/css" media="screen">
    <link rel="stylesheet" type="text/css" media="all" href="css/webslidemenu.css">
    <link rel="stylesheet" href="css/main.css" type="text/css">
    <link rel="stylesheet" href="css/homepage.css" type="text/css">
    <link rel="stylesheet" href="css/rates.css" type="text/css">
    <script type="text/javascript">
        javascript: window.history.forward(1);
        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isalphaKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode < 33 || charCode > 47 && charCode < 48 || charCode > 57) {
                return true;
            }
            return false;
        }



    </script>
    <%-- <img src="InnerBanner/Banner/Complaint-Grievance.jpg" alt="Complaint-Grievance" class="img-responsive">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1 style="color: #ce1c7b; font-size: 28px;">If you have any complaints/grievance please submit</h1>

                    Customers and Public may feel free to approach the Branch Manager on any of their grievances / suggestions on account of our service, procedures, and delays, if any. They may also give such suggestions / grievances in writing to the Branch Manager. If the grievances are not redressed within reasonable time, they may contact or write to our General Manager (PD & RM Department) at Thoothukudi. The full address and phone numbers are as follows:

                    <p>&nbsp;</p>

                    <h4>General Manager</h4>

                    (PD & RM Department)
                    <p>&nbsp;</p>


                    <h4>Tamilnad Mercantile Bank Limited</h4>

                    57, V.E. Road, Tuticorin, Tamilnadu, India. Zip: 628 002.<br />
                    Toll Free Phone: 180 0425 0426. Customer Care: +91 9842 461 461.<br />
                    Email: <a href="mailto:customerservice@tmbank.in">customerservice@tmbank.in</a>

                    <p>&nbsp;</p>


                    <h4>TMB Customer Care:</h4>

                    For all your grievances, on any of our services in any branch in India, you can now SMS “help” or call +91 9842 461 461. TMB’s Customer Care team is at your service (10:00am to 5:30pm) & will address your concerns immediately. You can also email us at: <a href="mailto:customerservice@tmbank.in">customerservice@tmbank.in</a>

                    <p>&nbsp;</p>
                    <h4>Online Complaint Form:</h4>

                    <div class="tabbs">
                        <p>Customers can use the form below to help us resolve any issues to the best of the satisfaction of the customer:</p>
                        <p>
                            <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </p>

                        <div class="form-group">
                            <label for="">Branch:</label>
                            <asp:DropDownList ID="ddlBranch" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="">Name:</label>
                            <asp:TextBox ID="txtname" runat="server" onkeypress="return isalphaKey(event)" class="form-control" AutoComplete="off"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="">Address:</label>
                            <asp:TextBox ID="txtAddress" runat="server" class="form-control" Style="resize: none" TextMode="MultiLine" Rows="2" AutoComplete="off"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="">Mobile No :</label>
                            <asp:TextBox ID="txtphone"
                                runat="server" MaxLength="10" class="form-control" onkeypress="return isNumberKey(event)" AutoComplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Email Address :</label>
                            <asp:TextBox ID="txtemail"
                                runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Subject :</label>
                            <asp:DropDownList ID="ddlsub" runat="server" class="form-control">
                                <asp:ListItem>choose appropriate subject</asp:ListItem>
                                <asp:ListItem Value="1">complaint & grievence</asp:ListItem>
                                <asp:ListItem Value="2">feedback & suggestion</asp:ListItem>

                            </asp:DropDownList>
                        </div>


                        <div class="form-group">
                            <label for="">Message:</label>
                            <asp:TextBox ID="txtmsg"
                                runat="server" class="form-control" AutoComplete="off" MaxLength="6000" Rows="7" Style="resize: none" TextMode="MultiLine"></asp:TextBox>

                        </div>
                        <div class="col-lg-12" style="margin-bottom: 30px; margin-left: -25px">
                            <div class="col-lg-4">
                                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6"
                                    CaptchaHeight="40" CaptchaWidth="200" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                    FontColor="#000000" NoiseColor="#B1B1B1" />
                            </div>
                            <div class="col-lg-4" style="width: 100px">
                                <asp:ImageButton ID="ImageButton1" ImageUrl="images/refresh.png" runat="server" CausesValidation="false" Width="40px" />
                            </div>
                            <div class="col-lg-4" style="width: 300px">
                                <label for="email">Enter the code from the image here:</label>
                                <asp:TextBox ID="txtCaptcha" AutoComplete="off" runat="server" class="form-control"></asp:TextBox>
                            </div>

                        </div>

                        <asp:Button ID="Btnsave" runat="server" Text="Send" OnClick="Btnsave_Click" class="btn btn-primary em-cta related-product-click-apply" />&nbsp;
               <asp:Button ID="Btnreset" runat="server" Text="Reset" OnClick="Btnreset_Click" class="btn btn-primary em-cta related-product-click-apply" />
                    </div>

                    <p>&nbsp;</p>


                    If the grievances are not redressed within reasonable time, customers may contact or write to the following Nodal Officers at Regional Level as well as the Customer Service Cell at Thoothukudi.

                  

                    <h4>Nodal Officers for Complaints</h4>

                    <div class="main-contentz">
                      <div class="table-container tblscroll">


                    <table border="0">
                      <thead>
                        <tr>
                          <th><strong>Name</strong></th>
                          <th><strong>Designation /Contact ID</strong></th>
                        </tr>
                        <tr>
                          <td>Shri K. Vijayan</td>
                          <td>Regional Manager, Hyderabad Region<br />
                            <a href="mailto:hyderabad_region@tmbank.in">hyderabad_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri J. Chidambara Kani</td>
                          <td>Regional Manager, Mumbai Region<br />
                            <a href="mailto:mumbai_region@tmbank.in">mumbai_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri D. Ramesh</td>
                          <td>Regional Manager, Chennai Region<br />
                            <a href="mailto:chennai_region@tmbank.in">chennai_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri R. Gouthaman</td>
                          <td>Regional Manager, Tirunelveli Region<br />
                            <a href="mailto:tirunelveli_region@tmbank.in">tirunelveli_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri J. Sundaresh Kumar</td>
                          <td>Regional Manager, Madurai Region<br />
                            <a href="mailto:madurai_region@tmbank.in">madurai_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri M. Ramanathan</td>
                          <td>Regional Manager, Coimbatore Region<br />
                            <a href="mailto:coimbatore_region@tmbank.in">coimbatore_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri I. Mohan Raj</td>
                          <td>Regional Manager, Thoothukudi Region<br />
                            <a href="mailto:thoothukudi_region@tmbank.in">thoothukudi_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri S. Pratheep Kumar</td>
                          <td>Regional Manager, Bangaluru Region<br />
                            <a href="mailto:bengaluru_region@tmbank.in">bengaluru_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri J. Natarajan</td>
                          <td><a href="/network_info/code-981/branch_atm_network_complete_information.html" title="branch / atm network complete information">Regional Manager, Tiruchirapalli Region</a><br />
                              <span class="email_id"><a href="/clickmail/clickinfo=BBUODzcNMhA6RFgwLh9NXRIGCQdxHQM" rel="nofollow" onclick="ga('send', 'event', 'clickmail', 'id-7130', 'Regional Manager, Tiruchirapalli Region Email ID.');" title="Regional Manager, Tiruchirapalli Region Email ID."><span id="11e7130">trichy_region@tmbank.in</span></a></span>
                            <script data-cfasync="false" type="text/javascript">document.getElementById("11e7130").innerHTML = ("gevpul_ertvba_NG_GUR_ENGR_BS_gzonax_QBG_va".replace(/[a-zA-Z]/g, function (c) { return String.fromCharCode((c <= "Z" ? 90 : 122) >= (c = c.charCodeAt(0) + 13) ? c : c - 26); }).replace(/_AT_THE_RATE_OF_/g, '@').replace(/_DOT_/g, '.'));</script>
                            <noscript>
                              . Since Javascript is disabled, <a href="/clickmail/clickinfo=BBUODzcNMhA6RFgwLh9NXRIGCQdxHQM" rel="nofollow" onclick="ga('send', 'event', 'clickmail', 'id-7130', 'Regional Manager, Tiruchirapalli Region Email ID.');" title="Regional Manager, Tiruchirapalli Region Email ID.">click this link</a> / encrypted &quot;nospam&quot; email link to write to us.
                            </noscript>                          </td>
                        </tr>
                        <tr>
                          <td>Shri P. Jebananth Julius</td>
                          <td>Regional Manager, Thiruvananthapuram Region<br />
                            <a href="mailto:thiruvananthapuram_region@tmbank.in">thiruvananthapuram_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri J. Surendrabalaji</td>
                          <td>Regional Manager, Salem Region<br />
                            <a href="mailto:salem_region@tmbank.in">salem_region@tmbank.in</a> </td>
                        </tr>
                        <tr>
                          <td>Shri M. Syed Mohamed</td>
                          <td>Regional Manager, Ahmedabad Region<br />
                            <a href="mailto:ahmedabad_region@tmbank.in">ahmedabad_region@tmbank.in</a> </td>
                        </tr>
                      </thead>
                    </table>
					
					</div>
                    </div>
                    <h4>Details of Complaints Received (Apr 01, 2018 to Mar 31, 2019)</h4>
                    <div class="listing">
                        <ul>
                            <li>Number of ATM failed transaction claims at the beginning of the year - 96<br>
                                [Settled within April 7, 2019]</li>
                            <li>Number of Complaints pending at the beginning of the year - NIL<br>
                                [Other than ATM failed transaction claims referred above]</li>
                            <li>Number of complaints received during the year - 15116<br>
                                [Including 9047 ATM failed transaction claims and 5873 IT related claims]</li>
                            <li>Number of complaints redressed during the year - 15088<br>
                                [Including 8923 ATM failed transaction claims and 5873 IT related claims]</li>
                            <li>Number of complaints pending at the end of the year - 124<br>
                                [Including 124 ATM failed transaction claims]</li>
                            <li>Number of complaints pending at the end of the year - NIL<br>
                                [Other than ATM failed transaction claims referred above]</li>
                        </ul>

                    </div>
                    <h4>Awards passed by Banking Ombudsman</h4>
                    <div class="listing">
                        <ul>
                            <li>Number of unimplemented awards at the beginning of the year - NIL</li>
                            <li>Number of awards passed by the Banking Ombudsman during the year - NIL</li>
                            <li>Number of awards implemented during the year - NIL</li>
                            <li>Number of unimplemented awards pending at the end of the year - NIL</li>
                        </ul>
                    </div>

                    <h4>Detailed Analysis of Complaints</h4>
                    <div class="listing">
                        <ul>
                            <li><a href="/doc/complaints-analysis-03.pdf" target="_blank" rel="noopener" title="Click Here to Download" onclick="javascript:ga('send', 'pageview', '/forms_download/complaints_grievances/Recent_Detailed_Analysis_of_Complaints_Document/doc/complaints_analysis_03.pdf');">Recent Detailed Analysis of Complaints Document (Format: Adobe "PDF" Document)</a></li>
                        </ul>
                    </div>
                    <h4>Detailed Analysis of Complaints</h4>

                    A communication for the purpose of reporting any event / information of concern (the complaint) should be sent in a closed / secured envelope super-scribed “under Protected Disclosure Scheme” and shall be addressed to the Chief of Internal Vigilance, Tamilnad Mercantile Bank Ltd., Head Office, # 57, V.E.Road, Thoothukudi 628 002. The whistle blower shall not write the "from" address on the envelope. The complaint can also be also sent by email to civ@tmbank.in if the complaint so wishes.</p>

                    <h4>Complaints / Grievance Escalation</h4>

                    The names, addresses, telephone numbers and fax numbers of our Line Functioning Heads are mentioned below to enable our customers to approach them in case of need.

                    <h4>A. Shidambaranathan</h4>
                    (Vice President: Secretarial Section and oversee the department of Accounts, Compliance and Inspection.)                 
                        <h4>Tamilnad Mercantile Bank Limited</h4>

                    # 57, V.E. Road, Tuticorin, Tamilnadu, India. Zip: 628 002.<br>
                    Phone: <a href="tel:+914612333390" title="Click to Call (Mobile Browsers Only)">+91 (461) 233 3390</a>


                 <!--    <h4>S. Senthil Anandan</h4>
                    (General Manager: PD & RM, OSD, CSC, Bancassurance, DP Cell, Credit Card (Marketing), KYC & AML, Alternate Delivery Channel and Information Technology.)
                    <h4>Tamilnad Mercantile Bank Limited</h4>

                    # 57, V.E. Road, Tuticorin, Tamilnadu, India. Zip: 628 002.<br>
                    Phone: <a href="tel:+914612333390" title="Click to Call (Mobile Browsers Only)">+91 461 232 1130</a> -->


                    <h4>P. Suriaraj</h4>
                    (General Manager: HRD, Establishment , Inspection, Integrated Treasury (IBD, Domestic Treasury & RTGS) Accounts and Returns.)
                     <h4>Tamilnad Mercantile Bank Limited</h4>

                    # 57, V.E. Road, Tuticorin, Tamilnadu, India. Zip: 628 002.<br>
                    Phone: <a href="tel:+914612333390" title="Click to Call (Mobile Browsers Only)">+91 461 232 0360</a>

                    <h4>D. Inbamani</h4>
                    (General Manager: Recovery, CAM, Compliance, Legal and MIS.)                   
                   <h4>Tamilnad Mercantile Bank Limited</h4>

                    # 57, V.E. Road, Tuticorin, Tamilnadu, India. Zip: 628 002.<br>
                    Phone: <a href="tel:+914612333390" title="Click to Call (Mobile Browsers Only)">+91 461 233 9146</a>


                    <h4>R. Arumugapandi</h4>
                    (General Manager: Credit.)                  
                    <h4>Tamilnad Mercantile Bank Limited</h4>

                    # 57, V.E. Road, Tuticorin, Tamilnadu, India. Zip: 628 002.<br>
                    Phone: <a href="tel:+914612333390" title="Click to Call (Mobile Browsers Only)">+91 461 232 5411</a>

                </div>

               <div class="col-md-3 related-products em" data-type="product">
                        <div class="hp-main-box">
                            <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto; border: none;">
                                <img class="rel-img-right em-img lazyloaded" src="images/products1.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
                                <div class="details-box">
                                    <div class="hp-card-box">
                                        <h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 24px;">Savings Account</h4>

                                       
                                    </div>



                                    <p class="link-box" style="display: none;"><a class="em-cta related-product-click-know-more" href="/en/personal-banking/accounts/savings-account/silk-woman-savings-account.html">Know More...</a></p>

                                    <div class="clearfix">
                                        <div class="FR MT15">
                                            <div class="share-box">
                                                <div class="share-positon-box clearfix">
                                                    <div class="share-bubble white">&nbsp;</div>
                                                </div>
                                            </div>
                                        </div>
                                        <a class="btn btn-primary em-cta related-product-click-apply" href="https://www.tmbnet.in/tmbankonline/" target="_blank">Apply Now</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </section>







</asp:Content>

