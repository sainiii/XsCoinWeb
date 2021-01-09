<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="GlobalBTC.MobileApp.password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="side-app" id="WithDrawFund" data-ng-controller="WithDrawFund as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Reset Password </li>
            </ol>


        </div>

        <div class="row">

            <div class="col-md-12 col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="row">

                            <h5 class="card-title">Reset Login Password</h5>
                             
                        </div>
                    </div>
                    <div class="card-body text-center">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">  Old Password &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  </span>
                            </div>
                            <input type="text" class="form-control">
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">New Password &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                            </div>
                            <input type="text" class="form-control">
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Confirm Password </span>
                            </div>
                            <input type="text" class="form-control">
                        </div>
                        <div class="text-center">
                            <button type="button" class="mb-2 btn btn-info" >Change Password</button>
                        </div>
                    </div>
                </div>
            </div>

            
        </div>
    </div>
</asp:Content>
