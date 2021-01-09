<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="side-app" id="CtrProfile" ng-controller="CtrProfile  as ctrl">

        <style type="text/css">
            .mb-3 {
                position: relative;
            }

            .badge2 {
                position: absolute;
                right: 5px;
                top: 5px;
                color: #000000;
                background: #eee;
                padding: 4px 10px;
                font-size: 13px;
                font-weight: normal;
            }

            .btn-primary:focus, .btn-primary:active:focus {
                background: rgb(4,133,8);
                background: linear-gradient(180deg, rgba(4,133,8,1) 0%, rgba(2,219,129,1) 100%);
            }

            a[aria-expanded="true"] {
                background: rgb(4,133,8);
                background: linear-gradient(180deg, rgba(4,133,8,1) 0%, rgba(2,219,129,1) 100%);
            }

            .btntop {
                font-size: 12px;
                text-transform: none;
                padding-bottom: 10px;
            }

                .btntop b {
                    font-size: 15px;
                    display: block;
                }
        </style>
        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Edit Profile</li>
            </ol>
            <!-- End breadcrumb -->

        </div>

        <div class="row">

            <div class="col-lg-12 col-xl-8 col-md-12 col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Edit Profile</h3>
                    </div>
                    <div class="card-body">

                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Email address   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                            </div>
                            <input type="text" class="form-control" name="Email" readonly ng-model="ctrl.md.Email" id="Email">
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Username   &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                            </div>

                            <input type="text" class="form-control" readonly name="AppMstRegNo" ng-model="ctrl.md.AppMstRegNo" id="AppMstRegNo">
                        </div>

                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Sponsor ID   &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                            </div>

                            <input type="text" class="form-control" readonly  name="sponsorid" ng-model="ctrl.md.sponsorid" id="sponsorid">
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </span>
                            </div>

                            <input type="text" class="form-control" name="AppmstFName" ng-model="ctrl.md.AppmstFName" id="AppmstFName">
                        </div>

                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Country &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                            </div>

                            <input type="text" class="form-control" readonly name="Country" ng-model="ctrl.md.Country" id="Country">
                        </div>


                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">XSC Coin Address</span>
                            </div>
                            <input type="text" class="form-control" name="zipCode" ng-model="ctrl.md.BTC" id="BTC">
                        </div>

                        <div class="input-group mb-3 text-center">
                            {{MessagesType}}
                       
                        
                        </div>

                        <div class="card-footer text-center">
                            <button  class="mb-2 btn btn-info" ng-show="ctrl.Buttonshow" type="button" ng-click="ctrl.SaveProfile()">Update Profile</button>

                            <a href="#"  class="mb-2 btn btn-info">Cancel</a>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-xl-4 col-md-12 col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">My Profile</h3>
                        <div class="card-options"><a href="profile.html" class="btn btn-primary btn-sm"><i class="si si-eye mr-1"></i>View Profile</a> </div>
                    </div>
                    <div class="card-body">
                        <div class="text-center">
                            <div class="userprofile ">
                                <div class="userpic  brround">
                                    <img src="{{UserData.ProfileImage}}" alt="" class="userpicimg">
                                </div>


                                <h3 class="username mb-2">{{UserData.sponsorid}}</h3>
                                <p class="mb-1">{{EmailH}} {{NumberH}}</p>
                            </div>
                        </div>

                        <div class="input-group mb-3">

                            <div class="input-group-prepend">
                                <input type="hidden" ng-model="ctrl.md.Regno" name="ctrl.md.Regno">
                            </div>
                            <input class="dropify" type="file" id="file" name="file" onchange="angular.element(this).scope().setFile(this)" accept="image/*">
                        </div>
                    </div>

                </div>

            </div>


        </div>
    </div>
</asp:Content>
