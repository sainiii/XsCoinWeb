<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="transfer.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        table span {
            display: block;
            color: #0163c2;
            padding-top: 5px;
        }

        .table tr, .table td {
            position: relative;
        }

        .row111 td span::after, .row222 td span::after {
            content: '';
            border: solid 1px #828282;
            position: absolute;
            height: 10px;
            bottom: -10px;
            left: 25%;
        }

        .row111 td span::before, .row222 td span::before {
            content: '';
            border: solid 1px #828282;
            position: absolute;
            height: 10px;
            bottom: -10px;
            right: 25%;
        }

        .row111 td::after, .row222 td::after {
            content: '';
            border: solid 1px #828282;
            left: 50%;
            height: 10px;
            position: absolute;
            bottom: 0;
        }

        .row111 td::before, .row222 td::before {
            content: '';
            border: solid 1px #828282;
            position: absolute;
            width: 50%;
            bottom: 0;
            left: 25%;
        }

        .btn-sm:hover {
            background: none;
            padding: 0px 10px;
        }

        .btn-sm {
            background: none;
            padding: 0px 10px;
            text-transform: none;
            color: #000 !important;
            font-size: 12px !important;
        }

        .table-borderless p {
            margin-bottom: 0px;
            margin-top: 5px;
        }
        .modal-body p {
            padding-bottom: 5px;
            padding-top: 5px;
            margin: 0;
            color:#000;
            border-bottom: solid 1px #cecece;
        }
        .modal-body span {float:right}
    </style>

    <div class="content-sticky-footer pt-0" id="Trnasfer" data-ng-controller="Trnasfer as ctrl">
        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-body text-center">
                    <h1><span class="font-weight-light small">Transfer Fund</span></h1>
                </div>
            </div>
        </div>
        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-12">
                            <h5 class="card-title text-center">Available Balance : $ {{VpBallance}}</h5>
                        </div>
                    </div>
                </div>
                <div class="card-body text-center">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">$</span>
                        </div>
                        <input type="text" class="form-control" placeholder="Transfer Amount" ng-model="Amount" name="Amount">
                    </div>
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Enter User ID for Transfer" ng-model="TrsferID" name="TrsferID" ng-change="ctrl.myFunc()">
                        <div class="input-group-append">
                            <span class="input-group-text">{{username}}</span>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Security Key</span>
                        </div>
                        <input type="text" class="form-control is-valid" placeholder="Enter Security Key" ng-model="Skey" name="Skey">
                    </div>
                    <div class="input-group mb-3 text-center">
                        <button type="button" class="mb-2 btn btn-block btn-info" model="TrasferClick" ng-click="ctrl.TrasferClick()">Transfer Fund</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-12">
                            <h5 class="card-title text-center">Genealogy Tree</h5>
                        </div>
                    </div>
                </div>
                <div class="card-body text-center">
                    <div class="table-responsive">
                        <table class="table table-borderless">
                            <tr class="row111">
                                <td colspan="4" style="width: 100%">
                                    <img src="../tree/paid12.gif" />
                                    <span>Raj Kumar</span>
                                    <p><a class="btn btn-sm btn-outline-primary" href="#">Open Tree </a></p>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal">View Detail </a></p>
                                </td>
                            </tr>
                            <tr class="row222">
                                <td colspan="2" style="width: 50%">
                                    <img src="../tree/paid12.gif" />
                                    <span>Raj Kumar</span>
                                    <p><a class="btn btn-sm btn-outline-primary" href="#">Open Tree </a></p>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal">View Detail </a></p>
                                </td>
                                <td colspan="2" style="width: 50%">
                                    <img src="../tree/paid12.gif" />
                                    <span>Raj Kumar</span>
                                    <p><a class="btn btn-sm btn-outline-primary" href="#">Open Tree </a></p>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal">View Detail </a></p>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%">
                                    <img src="../tree/paid12.gif" />
                                    <span>Raj Kumar</span>
                                    <p><a class="btn btn-sm btn-outline-primary" href="#">Open Tree </a></p>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal">View Detail </a></p>
                                </td>
                                <td style="width: 25%">
                                    <img src="../tree/paid12.gif" />
                                    <span>Raj Kumar</span>
                                    <p><a class="btn btn-sm btn-outline-primary" href="#">Open Tree </a></p>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal">View Detail </a></p>
                                </td>
                                <td style="width: 25%">
                                    <img src="../tree/paid12.gif" />
                                    <span>Raj Kumar</span>
                                    <p><a class="btn btn-sm btn-outline-primary" href="#">Open Tree </a></p>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal">View Detail </a></p>
                                </td>
                                <td style="width: 25%">
                                    <img src="../tree/paid12.gif" />
                                    <span>Raj Kumar</span>
                                    <p><a class="btn btn-sm btn-outline-primary" href="#">Open Tree </a></p>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal">View Detail </a></p>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>


    </div>


    <!-- Modal -->

</asp:Content>
