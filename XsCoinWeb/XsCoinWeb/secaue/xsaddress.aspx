<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="xsaddress.aspx.cs" Inherits="XsCoinWeb.secaue.xsaddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .red {
            background: #fff !important;
        }

        .blue {
            border: solid 1px green !important;
            background: #deffe6 !important;
        }

        .table > thead > tr > th {
            padding: 7px 20px 7px !important;
            font-weight: 700;
            background-color: #ebeced;
            border-color: #bec3c6 !important;
            color: #000;
        }

        .table > tbody > tr > td {
            padding: 7px 20px !important;
        }
    </style>


    <script language="JavaScript" type="text/ecmascript">

        function ModifyEnterKeyPressAsTab() {
            if (window.event && window.event.keyCode == 9) {
                window.event.keyCode = 13;
            }

        }

    </script>

    <style>
        .intro {
            color: green !important;
            border: solid 1px green !important;
            background: #deffe6 !important;
        }


        .paymode td {
            border: none;
        }

        #crypto, #wallet {
            background: #fff;
            display: inline-block;
            padding: 5px 15px;
            cursor: pointer;
            border: solid 1px #e2e2e2;
        }

            #crypto i, #wallet i {
                color: #bbbbbb;
            }

        .blue i, .blue {
            color: green !important;
        }

        .usrname {
            right: 5px;
            bottom: 5px;
            background: #eee;
            padding: 3px 10px;
            position: absolute;
            border: 0;
            background: #fff;
            text-align: right;
            color: #000;
            font-weight: bold;
            font-size: 11px;
        }

        .form-horizontal span.textlbl {
            background: #e8e8e8;
            padding: 6px 10px 4px 10px;
            min-width: 30%;
            border-radius: 2px 0 0 2px;
            margin: -6px 15px 0px -12px;
            display: inline-block;
        }

        .form-horizontal span {
            display: inline-block;
            color: #000;
        }

        .form-horizontal .form-control {
            margin-bottom: 8px;
        }

        .psuccess {
            text-align: center;
            font-size: 16px;
            color: #000;
        }

            .psuccess b {
                font-size: 20px;
                line-height: 30px;
                display: block;
                color: #008e0c
            }

            .psuccess i {
                font-size: 100px;
                color: green
            }
    </style>
    <div class="row">
        <div class="col-md-12" data-ng-controller="PaymentCtrl as ctrl">
            <!-- begin breadcrumb -->


            <div class="col-sm-12" ng-show="ctrl.PaymentDetail">

                <div class="panel panel-info lobidrag">

                    <div class="panel-heading" style="text-align: center">
                        <h3 style="margin: 0; color: #fff; margin-bottom: 6px;">Payment Detail</h3>
                        <p style="margin-bottom: 0">Please transfer exact amount as shown</p>
                    </div>

                    <div class="panel-body">
                        <!-- Main content -->
                        <div class="col-sm-3">
                            <img src='{{qrcode_url}}' alt='{{qrcode_url}}'>
                        </div>
                        <div class="col-sm-8">
                            <div class="single-port-content" data-margin="0px 0px 0 0">
                                <br />
                                <div class="form-horizontal">
                                    <div class="form-control">
                                        <span class="textlbl">Account {{AmountFor}}</span> <span>{{UserID}} - $  {{RequestAmount}}</span>
                                    </div>
                                    <div class="form-control">
                                        <span class="textlbl">Payment Mode</span> <span>{{Currency2}}</span>
                                    </div>
                                    <div class="form-control">
                                        <span class="textlbl">Amount to Pay</span> <span>{{amount}}</span>
                                    </div>
                                    <div class="form-control">
                                        <span class="textlbl">{{Currency2}} Address</span> <span>{{address}}</span>
                                    </div>
                                    <div class="form-control">
                                        <span class="textlbl">Payment Status</span> <span style="color: #fa3f03">{{paymentstatus}} <i class="fa fa-spinner fa-pulse fa-fw"></i></span>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>



                </div>
            </div>


            <div class="col-sm-12" ng-show="ctrl.ConfirmDetail">

                <div class="panel panel-info lobidrag">

                    <div class="panel-heading" style="text-align: center">
                        <h3 style="margin: 0; color: #fff; margin-bottom: 6px;">Account Activate</h3>
                        <p style="margin-bottom: 0">Choose your best package to Account Top</p>
                    </div>

                    <div class="panel-body">
                        <div class="col-sm-12 psuccess">
                            <i class="fa fa-check-square-o"></i>
                            <b>Payment Completed</b>
                            Your account {{UserID}}
                            <br />
                            {{AmountFor}}
                            <br />
                            Successfully
                            <br />
                            <br />
                            <a href="/backoffice/" class="btn btn-inverse m-r-5 m-b-5">Go to Dashboard</a>
                        </div>
                    </div>

                </div>



            </div>





        </div>
    </div>
    <br />
    <br />
    <br />

</asp:Content>
