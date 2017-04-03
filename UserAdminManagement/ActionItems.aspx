<%@ Page Language="C#" AutoEventWireup="true" Inherits="ActionItems" Codebehind="ActionItems.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8">
    <title>BP UserAdministration</title>
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
    <div class="wrapper row-offcanvas row-offcanvas-left">
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



                    <li class="active">
                        <a href="ActionItems.aspx">
                            <i class="fa fa-calendar"></i><span>Pending Actions</span>

                        </a>
                    </li>

                    <% if ((bool)Session["AdminUser"])
                       { %>
                    <li class="treeview">
                        <a href="Adminstration.aspx">
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
            <section class="content">
                <div class="messagealert" id="alert_container">
                </div>
                <div class="row">

                    <form id="form1" runat="server">

                        <div>
                            <div class="panel with-nav-tabs">
                                <div class="panel-heading">
                                    <ul class="nav nav-tabs">
                                        <li class="active" runat="server" id="MyrequestsID"><a href="#tab1myrequestss" data-toggle="tab">My Requests</a></li>
                                        <li runat="server" id="ActionrequiredID"><a href="#tab2actionrequired" data-toggle="tab">Action Required</a></li>
                                        <li><a href="#tab3actionedrequests" data-toggle="tab">Requests Actioned</a></li>

                                    </ul>
                                </div>
                                <div class="panel-body">
                                    <div class="tab-content">
                                        <div class="tab-pane fade in active" runat="server" id="tab1myrequestss">
                                            <div class="col-xs-12">
                                                <div class="">

                                                    <div class=" table-responsive no-padding">




                                                        <asp:GridView ID="gvMyRequest" runat="server"
                                                            AlternatingRowStyle-CssClass="fieldGroupContainerGreenGrid"
                                                            AutoGenerateColumns="False" BorderStyle="None"
                                                            HeaderStyle-CssClass="dialogTitleGreenSmallHeader"
                                                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                                            HeaderStyle-HorizontalAlign="Left" Width="100%" CssClass="box">
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
                                                                        <asp:Label ID="lblApplication" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Application"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Role"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRole" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Role"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="AssignedTo"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAssignedTo" runat="server" Text='<%# String.Format("{0:0.00}",Eval("AssignedTo"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Status"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remarks"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Remarks"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>

                                                        </asp:GridView>





                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box -->
                                            </div>

                                        </div>
                                        <div class="tab-pane fade" id="tab2actionrequired" runat="server">

                                            <div class="col-xs-12">
                                                <div class="">

                                                    <div class=" table-responsive no-padding">

                                                        <asp:GridView ID="gvActionRequired" runat="server"
                                                            AlternatingRowStyle-CssClass="fieldGroupContainerGreenGrid"
                                                            AutoGenerateColumns="False" BorderStyle="None"
                                                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                                            HeaderStyle-CssClass="dialogTitleGreenSmallHeader" OnRowCommand="gvActionRequired_RowCommand"
                                                            HeaderStyle-HorizontalAlign="Left"
                                                            Width="100%">
                                                            <AlternatingRowStyle CssClass="fieldGroupContainerGreenGrid" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                                        <asp:Label ID="lblUserNTID" runat="server" Visible="false" Text='<%# Eval("UserNTID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Application"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAppID" runat="server" Text='<%# Eval("AppID")%>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblApplication" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Application"))%>' Width="60px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Role"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRoleID" runat="server" Text='<%# Eval("RoleID")%>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblRole" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Role"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Status"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedNTID"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedNTID" runat="server" Text='<%# String.Format("{0:0.00}",Eval("CreatedNTID"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remarks"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Remarks"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Approve"></asp:Button>
                                                                        <asp:Button ID="btnDelete" runat="server" Text="Decline" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Decline"></asp:Button>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>





                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box -->
                                            </div>



                                        </div>
                                        <div class="tab-pane fade" id="tab3actionedrequests">
                                            <div class="col-xs-12">
                                                <div class="">

                                                    <div class="table-responsive no-padding">

                                                        <asp:GridView ID="gvActionedRequests" runat="server"
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
                                                                        <asp:Label ID="lblApplication" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Application"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Role"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRole" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Role"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Status"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedNTID"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedNTID" runat="server" Text='<%# String.Format("{0:0.00}",Eval("CreatedNTID"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remarks"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# String.Format("{0:0.00}",Eval("Remarks"))%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>

                                                        </asp:GridView>





                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box -->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>



                </div>

            </section>
        </aside>
    </div>



</body>
</html>

