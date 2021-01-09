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
                <li class="breadcrumb-item active" aria-current="page">Choose your best package to Account Top</li>
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
                                        <h5 class="card-title text-center">Package Detail</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body text-center">
                                <div class="input-group mb-3">
                                    <input type="text" class="form-control" placeholder="Enter Account ID (GBT123456)" ng-model="TopID" name="TopID" ng-change="ctrl.myFunc()">
                                    <span class="badge2">{{username}}</span>
                                </div>

                                <div class="input-group mb-3">
                                    <input type="text" class="form-control" placeholder="Amount (USD)" ng-change="myRate()" ng-model="Amount" name="Amount">
                                </div>
                                <div class="input-group mb-3">
                                    <input type="text" class="form-control is-valid" placeholder="Security Key" ng-model="Skey" name="Skey">
                                </div>


                                <div class="row">
                                    <div class="col-6">
                                        <a href="" class="collapsed btn btn-primary btn-block btntop mb-2" data-toggle="collapse" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne" ng-click="walletClick()">
                                            <b>Account Funds </b>Available: ${{VpBallance}}
                                        </a>
                                    </div>
                                    <div class="col-6">
                                        <a href="" class="collapsed btn btn-block btn-primary btntop mb-2" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" ng-click="BTCClick()">
                                            <b>Crypto Currency </b>BTC, ETH, BCH, LTC
                                        </a>
                                    </div>
                                </div>
                                <div id="accordion">
                                    <div class="card mt-1 border-10 rounded">
                                        <div id="collapseOne" class="collapse" data-parent="#accordion">
                                            <div class="card-body">
                                                <div class="custom-control custom-checkbox">
                                                    <input type="checkbox" class="custom-control-input" id="customCheck2">
                                                    <label class="custom-control-label" for="customCheck2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Use Account Funds</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card mb-1 border-10 rounded">
                                        <div id="collapseTwo" class="collapse" data-parent="#accordion">
                                            <div class="card-body">
                                                <h1 style="font-size: 14px!important; background: #eee; color: #000; margin-bottom: 0px; padding: 10px 0;" class="text-center">Select Crypto Currency</h1>
                                            </div>
                                            <div class="col-12 mb-4">
                                                <select class="form-control ng-pristine ng-valid ng-not-empty ng-touched" ng-model="selectedCar" ng-change="getPayment(selectedCar)">
                                                    <option value="0">-Payment Mode-</option>
                                                    <option value="BTC">Bitoin (BTC) Wallet</option>
                                                    <option value="ETH">Ethereum (ETH) Wallet</option>
                                                    <option value="LTC">Litecoin (LTC) Wallet</option>
                                                    <option value="BCH">Bitcoin Cash (BCH) Wallet</option>
                                                    <option value="XRP">Ripple (XRP) Wallet</option>
                                                </select>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="input-group mb-3 text-center">
                                    <button type="button" class="mb-2 btn btn-block btn-danger" ng-click="ctrl.PaymentClick()">Activate</button>
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
