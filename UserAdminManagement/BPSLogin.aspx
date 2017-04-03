<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" Inherits="BPSLogin" Codebehind="BPSLogin.aspx.cs" %>


<html>
<head>
    <meta charset="UTF-8">
    <title>BP User Administration | Log in</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
          <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
    <!-- jQuery 2.0.2 -->

    <script src="js/jquery.min.js"></script>

    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function ShowModal() {
            $("#myModal").modal('show');
        }
    </script>


    <div class="navbar navbar-default navbar-static-top">

        <div><a class="navbar-brand" href="#">BP User Administration</a></div>
        <div class="navbar-header pull-right">
            <img src="img/bp-logo.png" alt="BP Logo" width="50" height="50" />&nbsp;&nbsp;
   
        </div>
    </div>

</head>
<body class="loginbody">

    <div class=" col-md-4"></div>
    <div class=" col-md-4">

        <div class="login-panel panel panel-default">
            <div class="panel-heading" style="background: #00a65a; color: white; font-weight: bold; font-size: 12px;">
                <h3 class="panel-title">User Access Management Sign In</h3>
            </div>
            <div class="panel-body">
                <form role="form" runat="server">
                    <fieldset>
                        <div class="form-group">
                            <input class="form-control" runat="server" id="login_userid" placeholder="NT login ID" name="email" type="text" autofocus="">
                        </div>
                        <div class="form-group">
                            <input class="form-control" runat="server" id="login_password" placeholder="Password" name="password" type="password" value="">
                        </div>
                        <div class="">
                            <label>
                                <p><a href="#">Reset Password</a></p>
                            </label>
                        </div>
                        <!-- Change this to a button or input when using this as a form -->
                        <asp:Button ID="btnsignin" Text="Login" runat="server" OnClick="btnsignin_Click" class="btn btn-sm btn-success"></asp:Button>

                    </fieldset>
                </form>
            </div>
        </div>

    </div>
    <div class=" col-md-4"></div>

    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Invalid User</h4>
                </div>
                <div class="modal-body">

                    <p class="text-warning"><small>Invalid UserID/Password Entered. Please Try Again...</small></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>




</body>
</html>
