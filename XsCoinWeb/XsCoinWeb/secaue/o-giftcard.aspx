<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="o-giftcard.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.o_giftcard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .form-horizontal .form-control {
            border-width: 1px;
        }

        .form-horizontal select {
            border-color: #6eb961;
            background: #e6ffe6;
            color: #000;
        }

        .label-blue {
            font-size: 10px;
    letter-spacing: 0.5px;
    font-weight: normal;
    text-transform: uppercase;
    background: #2184DA;
    color: #fff;
    padding: 4px 10px;
    display: initial;
    vertical-align: baseline;
    margin-bottom: 5px;
        }

        .form-control {border: 1px solid #a7a7a7;}

        ul {
            padding-left: 20px;
        }
    </style>

    <div class="content-sticky-footer pt-0">
        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-body text-center">
                    <h1><span class="font-weight-light small">Order Gift Card</span></h1>
                </div>
            </div>
        </div>
        <div class="col-12 mb-4">
            <div class="card mb-4 fullscreen">

                <div class="card-body">
                    


               

    <div class="text-center" id="GiftCarDetial" data-ng-controller="GiftCarDetial">
        
                    <!-- Main content -->
                        <div class="thumbnail mb-4" style="border: solid 1px #afafaf;">
                            <img src='/cards/{{Photo}}' />
                        </div>
                   
                    <div class="col-sm-12">
                        <div class="single-port-content" data-margin="0px 0px 0 0">
                            <h3 style="margin-top: 0;">{{ProductName}} <span class="label label-blue m-b-5">{{Country}}</span></h3>
                            <p>Purchase {{ProductName}} Gift Card from your GBT wallet funds</p>
                            <hr />
                            <div style="display: inherit">
                                <div class="form-horizontal row">
                                    <div class="col-sm-4 mb-4">
                                        <b class="m-t-0">Select amount </b>
                                        <select class="form-control select m-b-15" ng-model="DDLPrice" ng-change="getData(DDLPrice)">
                                            <option value="">-Choose Amount-</option>
                                            <option ng-repeat="x in Details" value="{{x.Amount}}">{{x.Amount}} {{Curency}}</option>

                                        </select>
                                    </div>

                                    <div class="col-sm-7 mb-4">
                                        <b class="m-t-0">{{SendTypeData}} </b>
                                        <input type="text" ng-model="SendonMail" name="SendonMail" class="form-control">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4 mb-4">
                                        <b class="m-t-0">Security Key</b>
                                        <input placeholder="1234" type="password" maxlength="4" ng-model="Skey" name="Skey" class="form-control">
                                    </div>
                                    <div class="col-sm-7 mb-4">
                                        <b class="m-t-0">Available wallet balance</b>
                                        <div class="form-control" style="color: #000; background: #e2e2e2"><b>$ {{BalanceVp}} </b>-  {{ConvertBalanceVp}} {{Curency}}</div>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col-sm-11 m-b-15">
                                        <div style="background: #eee; text-align: center; padding: 5px;">
                                            <b>Total Amount : ${{ConvertBTC}} </b>( Incl +$2 Processing fee )
                                        </div>
                                        <h3>{{Balanceno}}</h3>
                                        <a href="#modal-dialog" data-toggle="modal" ng-show="btnpayment" ng-click="ProceedtoCheck()" class="btn btn-lg btn-success btn-block">Countinue
                                        </a>
                                    </div>
                                </div>
                            </div>

                            <hr />
                            <div class="row" style="display:none">
                                <div class="col-lg-12">
                                    <!-- begin panel -->
                                    <div class="panel">
                                        <ul class="nav nav-tabs">
                                            <li class="nav-item active"><a class="nav-link" href="#default-tab-1" data-toggle="tab" role="tab">Description</a></li>
                                            <li class="nav-item"><a class="nav-link" href="#default-tab-3" data-toggle="tab">Terms and Conditions</a></li>
                                        </ul>
                                        <div class="tab-content m-b-0">
                                            <div class="tab-pane fade active in" id="default-tab-1">
                                                <p class="m-b-20">
                                                    {{Termscondition}}   
                                                </p>
                                            </div>

                                            <div class="tab-pane fade" id="default-tab-3">


                                                <p ng-bind-html="Description"></p>
                                                <%--   <li><span style="font-size: 11pt; font-family: Calibri, sans-serif;">The Money in Gift Sub-Wallet &nbsp; cannot be transferred to Bank Account Nor Peer-Peer transfer can happen.</span></li>
                                                    <li><span style="font-size: 11pt; font-family: Calibri, sans-serif;"><span style="font-variant-numeric: normal; font-variant-east-asian: normal; font-stretch: normal; font-size: 7pt; line-height: normal; font-family: &quot; times new roman&quot;">&nbsp;</span>It can be utilised in Paytm Offline and Online Ecosystem</span></li>
                                                    <li><span style="font-family: Calibri, sans-serif; font-size: 11pt;">Validity is 3 Years.</span></li>
                                                    <li><span style="font-family: Calibri, sans-serif; font-size: 11pt;">1 lakh is the maximum transaction can be done in a month.</span></li>
                                                    <li><span style="font-family: Calibri, sans-serif; font-size: 11pt;">Above 10k Customer need to update KYC in Paytm or else the amount will not reflect in wallet.</span></li>
                                                    <li><span style="font-family: Calibri, sans-serif; font-size: 11pt;">Please note the mobile no. which is entered while placing order to the same no. the money will be added.</span></li>
                                                    <li>Gift vouchers validity can not be extended once expired.</li>
                                                    <li>Voucher will be delivered within 5 to 6 working days.</li>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end panel -->
                                </div>
                            </div>

                            
                        </div>
                    </div>
                
    </div>


                     </div>
            </div>
        </div>

        <div class="modal fade" id="modal-dialog" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content" style="text-align: center;">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h3 class="modal-title">Confirm Payment</h3>
                                        </div>
                                        <div ng-show="Proceduesuccessfully">
                                            <div class="modal-body">
                                                <p class="m-b-20">
                                                    <b>Please confirm your all details are correct that you have filled. Please note after order your gift card, it cannot be refund or cancel. </b>
                                                </p>

                                                <h4>Complete you order</h4>

                                            </div>
                                            <div class="modal-footer" style="text-align: center;">
                                                <a href="javascript:;" class="btn btn-success btn-lg btn-blue" ng-click="ProceedtoPay()">Proceed to pay</a>
                                            </div>
                                            <br />
                                            <h5>{{Proceederror}}</h5>
                                            <br />
                                        </div>
                                        <div ng-show="ordersuccessfully">
                                            <h4 style="color: #02a10a"><i class="fa fa-check-square-o"></i>Your order has been successfully processed!</h4>
                                            <p style="color: #000">
                                                Thank you for your order.
                                    <br />
                                                You will receive your gift card within an hour, usually it takes 30-45 minutes. Sit back and relax your will receive your order soon. You can view your order history to check status.
                                            </p>
                                            <a href="order-history" class="btn btn-default m-b-5 btn-block">Order History</a>
                                        </div>
                                    </div>



                                </div>
                            </div>

    </div>
</asp:Content>
