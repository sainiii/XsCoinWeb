<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="activate.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.activate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="side-app" id="ActivateAccount" data-ng-controller="ActivateAccount as ctrl">

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
                <li class="breadcrumb-item active" aria-current="page">Parchase</li>
            </ol>
            <!-- End breadcrumb -->

        </div>
        <!-- End page-header -->
        <!-- row -->
        <div class="row row-cards">

            <div class="col-lg-12 col-xl-9">

                <div class="row">
                    <div class="col-md-12 col-lg-12">
                        <div class="card mb-3">
                            <div class="card-header">
                                <div class="row">
                                    <div class="col">
                                        <h1 class="card-title text-center">package </h1>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body">

                                <div id="global-loader" ng-show="ctrl.loderscreen">
                                    <img src="../Content/img/loader.svg" />
                                </div>
                                <div class="panel-body text-center">

                                    <div class="col-12">
                                        <h5 class="card-title text-center">Available XSC {{VpBallance}} 
                                                <span style="color: darkblue; font-size: 13px;">($ {{DollarBallance}})</span></h5>
                                    </div>
                                    <p class="lead">
                                        {{ctrl.pakcageName}}
                                           
                                            $
                                            {{ctrl.Amount}}
                                    </p>
                                </div>
                                <ul class="list-group list-group-flush text-center">
                                    <li class="list-group-item"><strong>{{ctrl.Profit}}%</strong> Weekly profit.</li>
                                    <li class="list-group-item"><strong>{{ctrl.Total}}
                                            % </strong>Total </li>
                                </ul>
                                <div class="col-md-12 col-lg-12  " ng-show="ctrl.QRCodetab">
                                    <br />

                                    <input type="hidden" class="form-control is-valid" ng-model="AType" name="AType">
                                    <input type="hidden" class="form-control is-valid" ng-model="ctrl.ACodeType" name="ctrl.ACodeType">
                                    <input type="text" class="form-control is-valid" placeholder="OTP Code" ng-model="ctrl.OTP" name="ctrl.OTP">



                                    <div class="text-center">
                                        <br />
                                        <button type="button" class="mb-2 btn  btn-info" ng-click="ctrl.PaymentClick()">CheckOut</button>


                                    </div>
                                </div>


                                <div class="col-md-12 col-lg-12  " ng-show="ctrl.Checkouttab">
                                    <br />
                                    <div class="text-center" ng-show='DollarBallance >= ctrl.Amount'>

                                        <button type="button" class="mb-2 btn  btn-info" ng-click="ctrl.CreateOTPClick()">CheckOut</button>
                                    </div>

                                    <div class="text-center" ng-show='DollarBallance <= ctrl.Amount'>

                                        <h5 style="color: #0970ff">Insuficient Balance </h5>
                                    </div>
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
        <!-- row end -->
    </div>
</asp:Content>
