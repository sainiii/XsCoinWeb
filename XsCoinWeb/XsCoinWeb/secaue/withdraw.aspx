<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="withdraw.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.withdraw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="side-app" id="WithDrawFund" data-ng-controller="WithDrawFund as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Withdraw XSC</li>
            </ol>


        </div>

        <div class="row row-cards">

            <div class="col-lg-12 col-xl-9">

                <div class="row">
                    <div class="col-md-12 col-lg-12">
                        <div class="card mb-3">
                            <div class="card-header">
                                <div class="row">
                                    <div class="col-12">
                                        <h5 class="card-title text-center">Available XSC {{VpBallance}} <span style="color: darkblue; font-size: 13px;">(${{DollarBallance}})</span></h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body text-center" ng-show="ctrl.Checkouttab">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Withdraw XSC&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </span>
                                    </div>
                                    <input type="text" class="form-control" ng-model="Amount" name="Amount" ng-change="ctrl.myRate()">
                                </div>

                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">XSC Wallet Address</span>
                                    </div>
                                    <input type="text" class="form-control" ng-model="txtbtc" name="txtbtc" disabled="disabled">
                                </div>

                                <div class="input-group mb-3">

                                    <span id="ctl00_ContentPlaceHolder1_lblpackgeamt" style="color: green; font-weight: bold;">{{AmountTotal}}</span>
                                    <input type="hidden" ng-model="BTCAMount" name="BTCAMount">
                                </div>



                                <div class="text-center">
                                    {{MessagesType}}
                            <a href="javascript:void(0);" class="mb-2 btn  btn-info" ng-show="btnBtc" model="PaymentClickM" ng-click="ctrl.CreateOTPClick()">Withdraw Fund</a>


                                </div>


                            </div>

                            <div class="card-body text-center" ng-show="ctrl.QRCodetab">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">OTP Code Key &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                                    </div>

                                    <a></a>
                                    <input type="text" class="form-control is-valid" placeholder="Enter OTPCode" ng-model="OTPCode" name="OTPCode">
                                </div>

                                <div class="text-center">
                                    {{MessagesType}}

                        
                       
                         <a href="javascript:void(0);" class="mb-2 btn btn-info" model="PaymentClickM" ng-click="ctrl.PaymentClick()">Sumbit</a>
                                </div>
                            </div>
                        </div>


                        <!-- Filter -->

                    </div>
                </div>
                <!-- row end -->
            </div>
            <!-- col end -->
        </div>


    </div>
</asp:Content>
