<%@ Page Language="C#" AutoEventWireup="true" Inherits="Adminstration" Codebehind="Adminstration.aspx.cs" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8">
    <title>BP User Administration</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
    <link href="css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-select.css" rel="stylesheet" type="text/css" />
    <!-- DATA TABLES -->
    <link href="css/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />


    <link rel="stylesheet" type="text/css" media="all" href="css/daterangepicker-bs3.css" />

    <script src="js/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <!-- DATA TABES SCRIPT -->

    <script src="js/plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>
    <!-- AdminLTE App -->
    <script src="js/AdminLTE/app.js" type="text/javascript"></script>
    <script src="js/moment.js" type="text/javascript"></script>
    <script src="js/daterangepicker.js" type="text/javascript"></script>
    <script src="js/bootstrap-select.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".selectpicker").selectpicker();
            $("#btnAddApprover img").attr("src", "../img/Plus.png");

        });

        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div"  class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" >&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
    <style type="text/css">
        #submit
        {
            border: 1px solid #563d7c;
            padding: 1px 1px 1px 1px;
            background: url('img/Plus.png') left 3px top 5px no-repeat #563d7c;
        }
    </style>



</head>
<body class="skin-black">

    <!-- header logo: style can be found in header.less -->
    <!-- header-->
    <header class="header">
        <a href="BPS Crashes.aspx" class="logo">
            <!-- Add the class icon to your logo image or logo icon to add the margining -->
            BP User Administration
        </a>

        <!-- Header Navbar: style can be found in header.less -->
        <nav class="navbar navbar-static-top" role="navigation">
            <!-- Sidebar toggle button-->
            <a href="#" class="navbar-btn sidebar-toggle" data-toggle="offcanvas" role="button">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </a>
            <div class="navbar-right">
                <ul class="nav navbar-nav">
                    <!-- Messages: style can be found in dropdown.less-->

                    <!-- User Account: style can be found in dropdown.less -->
                    <li class="dropdown user user-menu">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="glyphicon glyphicon-user"></i>
                            <span>
                                <asp:Label ID="lblname" runat="server"></asp:Label>
                                <i class="caret"></i></span>
                        </a>
                        <ul class="dropdown-menu">
                            <!-- User image -->
                            <li class="user-header bg-light-blue">
                                <img src="img/user.jpg" class="img-circle" alt="User Image" />
                                <p>
                                    <asp:Label ID="lblfullname" runat="server"></asp:Label>
                                </p>
                            </li>

                            <li class="user-footer">
                                <div>
                                    <button type="submit" id="btnLogout" runat="server" value="Profile" onclick="window.location.href = 'BPSLogin.aspx'" class="btn btn-default btn-flat  btn-block">Logout</button>
                                </div>

                            </li>
                        </ul>
                    </li>
                    <li>
                        <div class="navbar-header pull-right">
                            <img src="img/bp-logo.png" alt="BP Logo" width="50" height="50" />&nbsp;&nbsp;
                       
                        </div>
                    </li>
                </ul>
            </div>

        </nav>
    </header>


    <!-- SideBar -->
    <div class="wrapper row-offcanvas row-offcanvas-left" style="margin-top: 23px;">
        <!-- Left side column. contains the logo and sidebar -->
        <!-- SideNavigation -->


        <aside class="left-side sidebar-offcanvas">
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <!-- Sidebar user panel -->
                <div class="user-panel">
                    <div class="pull-left image">
                        <img src="img/user.jpg" class="img-circle" alt="User Image" />
                    </div>
                    <div class="pull-left info">
                        <p>
                            <asp:Label ID="lblusedid" runat="server"></asp:Label>
                        </p>

                    </div>
                </div>
                <!-- search form -->
                <form action="#" method="get" class="sidebar-form">
                    <div class="input-group">
                        <input type="text" name="q" class="form-control" placeholder="Search..." />
                        <span class="input-group-btn">
                            <button type='submit' name='seach' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button>
                        </span>
                    </div>
                </form>
                <!-- /.search form -->
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu">
                    <li>
                        <a href="BPS Crashes.aspx">
                            <i class="fa fa-dashboard"></i><span>User Access Administration</span>
                        </a>
                    </li>



                    <li class="sidebar-menu">
                        <a href="ActionItems.aspx">
                            <i class="fa fa-calendar"></i><span>Pending Actions</span>

                        </a>
                    </li>
                    <% if ((bool)Session["AdminUser"])
                       { %>
                    <li class="treeview" >
                        <a href="Adminstration.aspx" class="Highlight">
                            <i class="fa fa-folder"></i><span>Adminstration</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="Adminstration.aspx"><i class="fa fa-angle-double-right"></i>Approval Matrix</a></li>
                            <li><a href="#"><i class="fa fa-angle-double-right"></i>Applicationwise Requests</a></li>
                            <li><a href="#"><i class="fa fa-angle-double-right"></i>Amend Request</a></li>

                        </ul>
                    </li>
                    <% } %>
                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>


        <!-- Right side column. Contains the navbar and content of the page -->

        <aside class="right-side">
            <div class="messagealert" id="alert_container">
            </div>
            <form id="form1" class="form-horizontal margingtop20" runat="server">
                <asp:Panel ID="pnlAppMatrix" runat="server">
                    <section class="content">
                        <div class="row">

                            <div class="col-xs-12">
                                <div class="box">
                                    <div class="box-header">
                                        <h3 class="box-title">Approval Matrix</h3>

                                        <div class="box-tools">
                                            <div class="input-group">
                                                <input type="text" name="table_search" class="form-control input-sm pull-right" style="width: 150px;" placeholder="Search" />
                                                <div class="input-group-btn">
                                                    <button class="btn btn-sm btn-default"><i class="fa fa-search"></i></button>
                                                </div>
                                            </div>

                                        </div>

                                        <!-- /.box-header -->
                                    </div>
                                    <%--    <div class="form-group">
                                   
                                    <div class="col-md-2">
                                       
                                    </div>
                                </div>--%>
                                    <div class="pull-left" style="padding-bottom: 10px; padding-left: 12px;">
                                         <%-- <asp:Button ID="btnAddApprover" runat="server" CssClass="btn btn-success" Text="Add New Approver"
                                            OnClick="btnAddApprover_Click"></asp:Button>--%>
                                        <%--<i class="fa fa-angle-double-right"></i>--%>
                                        <button type="submit" id="btnAddApprover" runat="server" class="btn btn-success" OnServerClick="btnAddApprover_Click"><i class="fa fa-plus" ></i>Add New Approver</button>
                                    </div>
                                    <div class="box-body table-responsive ">


                                        <asp:GridView ID="gvApprovalMatrix" runat="server"
                                            AlternatingRowStyle-CssClass="fieldGroupContainerGreenGrid"
                                            AutoGenerateColumns="False" BorderStyle="None"
                                            HeaderStyle-CssClass="dialogTitleGreenSmallHeader"
                                            ShowHeaderWhenEmpty="True"
                                            EmptyDataText="No records Found"
                                            HeaderStyle-HorizontalAlign="Left"
                                            Width="100%">
                                            <AlternatingRowStyle CssClass="fieldGroupContainerGreenGrid" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Application"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppID" runat="server" Text='<%# Eval("AppID")%>' Visible="false" Width="60px"></asp:Label>
                                                        <asp:Label ID="lblApplication" runat="server" Text='<%# String.Format("{0:0.00}",Eval("AppName"))%>' Width="60px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Role"
                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Wrap="true">
                                                    <ItemStyle Wrap="false" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoleID" runat="server" Text='<%# Eval("RoleID")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblRole" runat="server" Text='<%# String.Format("{0:0.00}",Eval("RoleName"))%>' Width="60px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Approver"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApproverNTID" runat="server" Text='<%# Eval("ApproverNTID")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblApprover" runat="server" Text='<%# String.Format("{0:0.00}",Eval("ApproverName"))%>' Width="60px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Approver Email"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApproverEmail" runat="server" Text='<%# String.Format("{0:0.00}",Eval("ApproverEmail"))%>' Width="60px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <a id="editAppMatrix" href='Adminstration.aspx?param=<%# Eval("ID") %>'>Edit</a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>




                                        <!-- /.box-body -->
                                    </div>
                                    <!-- /.box -->
                                </div>
                            </div>
                        </div>
                    </section>
                </asp:Panel>

                <asp:Panel ID="pnlApprovalUpdate" runat="server" Visible="false" class="box">
                    <div class=" box-info" id="Div1">
                        <div class="box-header">
                            <h3 class="box-title">Update Approval Matrix</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body no-padding">
                            <div class="row no-padding">
                                <div class="col-sm-11">

                                    <div class="form-group">
                                        <asp:Label ID="lblAppName" runat="server" class="col-md-4 control-label">Application</asp:Label>
                                        <div class="col-md-4 ">
                                            <asp:DropDownList ID="ddlApp" runat="server" class="selectpicker form-control pull-left " AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="ddlApp_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" class="col-md-4 control-label">Role</asp:Label>
                                        <div class="col-md-4 ">
                                            <asp:DropDownList ID="ddlRole" runat="server" class="selectpicker form-control pull-left ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblApprover" runat="server" class="col-md-4 control-label">Approver</asp:Label>
                                        <div class="col-md-4 ">
                                            <asp:TextBox ID="txtApprover" runat="server" class="col-md-4 control-text" />
                                            <asp:RequiredFieldValidator ID="RFVResponsibleUser" runat="server" ValidationGroup="ReqTxtGrp" ControlToValidate="txtApprover" Display="Dynamic"
                                                ErrorMessage=" Approver User Required." ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblApproverEmailID" runat="server" class="col-md-4 control-label">Approver EmailID</asp:Label>
                                        <div class="col-md-4 ">
                                            <asp:TextBox ID="txtApproverEmailID" runat="server" class="col-md-4 control-text" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ReqTxtGrp" ControlToValidate="txtApprover" Display="Dynamic"
                                                ErrorMessage=" Approver User Required." ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-4"></div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success " ValidationGroup="ReqTxtGrp" Width="100px"
                                                OnClick="btnSubmit_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-success" Width="80px"
                                                OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                    <%--   </div>--%>
                                </div>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row - inside box -->
                    </div>
                    <!-- /.box-body -->

                </asp:Panel>
            </form>
        </aside>






    </div>



</body>
</html>
