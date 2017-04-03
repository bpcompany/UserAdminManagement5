<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableViewState="true" Inherits="BPS_Crashes" Codebehind="BPS Crashes.aspx.cs" %>



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
        <a href="BPS Crashes.aspx" class="logo" style="text-wrap: normal">
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
                        <a href="BPS Crashes.aspx" class="Highlight">
                            <i class="fa fa-dashboard" ></i><span>User Access Administration</span>
                        </a>
                    </li>
                    <li class="sidebar-menu">
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


                <form class="form-horizontal margingtop20" runat="server">
                    <fieldset class="box">
                        <div class="box-header">
                            <h3 class="box-title">Request Submission</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="">NTID</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtNTID" ReadOnly="true" runat="server" class="form-control input-md" />
                                <%--<input id="" name="" type="text" placeholder="NTID" class="form-control input-md">--%>
                            </div>
                        </div>

                        <!-- Select Basic -->
                        <div class="form-group">
                            <asp:Label runat="server" class="col-md-4 control-label">Application Name</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlApplication" class="selectpicker form-control pull-left " runat="server">
                                </asp:DropDownList>



                            </div>
                        </div>



                        <!-- Select Basic -->
                        <div class="form-group">
                            <asp:Label class="col-md-4 control-label" runat="server">RequestType</asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlRequestType" class="selectpicker form-control pull-left " runat="server" AutoPostBack="false">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <!-- Button -->
                        <div class="form-group">
                            <asp:Label runat="server" class="col-md-4 control-label" ID="lblsubmitbtn"></asp:Label>
                            <div class="col-md-4">
                                <asp:Button ID="singlebutton" runat="server" name="singlebutton" class="btn btn-success" Text="Submit" OnClick="singlebutton_Click" />
                            </div>
                        </div>

                    </fieldset>



                    <!-- Multiple Checkboxes -->
                    <asp:Panel ID="pnlAccess" runat="server" Visible="false" class="box">
                        <div class=" box-info" id="Div1">
                            <div class="box-header">
                                <h3 class="box-title">User Access Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <div class="row no-padding">
                                    <div class="col-sm-11">
                                        <div class="form-group">
                                            <asp:Label runat="server" class="col-md-4 control-label">Application User Roles</asp:Label>
                                            <div class="col-md-4 ">
                                                <asp:CheckBoxList ID="chkBoxlistRole" class="checkbox checkboxlabel" runat="server"></asp:CheckBoxList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-4"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success "
                                                    OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnCancel" Visible="false" runat="server" Text="Back" CssClass="btn btn-success"
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




            </section>
        </aside>
    </div>



</body>
</html>
