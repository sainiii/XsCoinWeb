<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="XsCoinWeb.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unique Login Form Flat Responsive widget Template :: w3layouts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Unique Login Form Widget Responsive, Login form web template,Flat Pricing tables,Flat Drop downs  Sign up Web Templates, Flat Web Templates, Login signup Responsive web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- font files  -->
    <link href='//fonts.googleapis.com/css?family=Muli:400,300' rel='stylesheet' type='text/css' />
    <link href='//fonts.googleapis.com/css?family=Nunito:400,300,700' rel='stylesheet' type='text/css' />
    <!-- /font files  -->

    <link href="Content/login/style.css" rel='stylesheet' type='text/css' media="all" />
    <script src='//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js'></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="AppJS/angular.min.js"></script>
    <script src="AppJS/authService.js"></script>
</head>

<body>
    <form id="form1" runat="server">


      
        <h1 style="color: #fff;">XS Coin Login</h1>
        <!---728x90--->


        <div id="global-loader" style="display: none;">
            <img src="https://www.spruko.com/demo/hogo/Hogo(ltr-rtl)/assets/images/icons/loader.svg" alt="loader" />
        </div>
        <div class="page">
            <!-- page-content -->
            <div class="page-content">
                <div class="container text-center text-dark">
                    <div class="row">
                        <div class="col-lg-4 d-block mx-auto">
                            <div class="row">
                                <div class="col-xl-12 col-md-12 col-md-12">
                                    <div class="card" ng-app="MyApp">
                                        <div class="card-body" ng-controller="LoginController">
                                            <div class="text-center mb-6">
                                                <img src="../../assets/images/brand/logo.png" class="" alt="">
                                            </div>
                                            <h3>Login</h3>
                                            <p class="text-muted">Sign In to your account</p>
                                            <div class="input-group mb-3">
                                                <span class="input-group-addon bg-white"><i class="fa fa-user"></i></span>
                                                <input type="text" class="form-control" placeholder="Username">
                                            </div>
                                            <div class="input-group mb-4">
                                                <span class="input-group-addon bg-white"><i class="fa fa-unlock-alt"></i></span>
                                                <input type="password" class="form-control" placeholder="Password">
                                            </div>
                                            <div class="row">
                                                <div class="col-12">
                                                    <button type="button" class="btn btn-primary btn-block">Login</button>
                                                </div>
                                                <div class="col-12"><a href="forgot-password.html" class="btn btn-link box-shadow-0 px-0">Forgot password?</a> </div>
                                            </div>
                                            <div class="mt-6 btn-list">
                                                <button type="button" class="btn btn-icon btn-facebook"><i class="fa fa-facebook"></i></button>
                                                <button type="button" class="btn btn-icon btn-google"><i class="fa fa-google"></i></button>
                                                <button type="button" class="btn btn-icon btn-twitter"><i class="fa fa-twitter"></i></button>
                                                <button type="button" class="btn btn-icon btn-dribbble"><i class="fa fa-dribbble"></i></button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- page-content end -->
        </div>

        <div class="log" ng-app="MyApp">
            <div class="content1" ng-controller="LoginController">
                <h2>Sign In Form</h2>

                <input type="text" name="UserID" ng-model="UserID" id="UserID" placeholder="Username" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'USERNAME';}" />
                <input type="password" name="password" ng-model="password" id="password" placeholder="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'PASSWORD';}" />
                <div class="button-row">

                    <a href="javascript:;" ng-click="Login()" class="sign-in">Sign in</a>
                    {{errorMsg}}
                    <div class="clear"></div>
                </div>

            </div>
            <%-- <div class="content2">
                <h2>Sign Up Form</h2>

                <input type="text" name="userid" value="USERNAME" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'NAME AND SURNAME';}">
                <input type="tel" name="usrtel" value="PHONE" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'PHONE';}">
                <input type="email" name="email" value="EMAIL ADDRESS" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'EMAIL ADDRESS';}">
                <input type="password" name="psw" value="PASSWORD" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'PASSWORD';}">
                <input type="submit" class="register" value="Register">
            </div>--%>
            <div class="clear"></div>
        </div>
        <!---728x90--->

        <div class="footer">
            <p>© 2016 Unique Login Form. All Rights Reserved | Design by <a href="https://w3layouts.com/" target="_blank">w3layouts</a></p>
        </div>

        <script src="AppJS/demo.js"></script>

        <script src="AppJS/bootstrap-notify.js"></script>
    </form>
</body>
</html>
