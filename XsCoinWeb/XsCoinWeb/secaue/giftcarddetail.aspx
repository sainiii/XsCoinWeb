<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="giftcarddetail.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.giftcarddetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="content-sticky-footer pt-0">
        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-body text-center">
                    <h1><span class="font-weight-light small">Order History</span></h1>
                </div>
            </div>
        </div>
        <div class="col-12 mb-4" id="mainstatement" data-ng-controller="OrderGiftCarDetial as ctrl">
            <div class="card mb-4 fullscreen">

                <div class="card-body">
                     <div class="panel">
                <div class="panel-heading">
                </div>
                <div class="table-responsive">
                    <table class="table table-bordered table-hover table-striped table-td-valign-middle">
                        <thead>
                            <tr class="inverse">
                                <th>Product name</th>
                                <th class="text-center">Amount</th>
                                <th>Order Date</th>
                                <th>Status</th>
                                <th>Detail</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="d in Details">
                                <td>{{d.Productname}}  </td>
                                <td>{{d.Amount}} {{d.Curency}}</td>
                                <td>{{d.OrderDate}}</td>

                                <td>{{d.Status}} </td>

                                <td><a href="#modal-code" data-toggle="modal" ng-hide="isdellist[{{$index}}]" ng-click="FNView(d)" class="btn btn-success btn-xs btn-rounded p-l-10 p-r-10">Details</a></td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
            <div class="modal fade" id="modal-code" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog">
                    <div class="modal-content" style="text-align: center;">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 class="modal-title">Gift Card Detail</h3>
                        </div>
                        <div class="modal-body row justify-content-md-center " ng-show="SecurityDetail">
                            <div class="col-md-4 col-md-offset-4 has-warning">

                                <input type="hidden" ng-model="OrderID" name="OrderID" />
                                <h4 style="color: #e80000;">Enter Security Code  </h4>
                                <input type="password" ng-model="Skey" name="Skey" class="form-control text-center m-b-15" maxlength="4" placeholder="****">
                                <a href="" class="btn btn-primary m-r-5 width-100 m-b-15" ng-click="FN_Code()">Submit</a>
                                <h5>{{Securityerror}}</h5>
                            </div>
                        </div>
                        <div class="modal-body row justify-content-md-center" ng-show="GiftCardDetail">
                            <h4 style="line-height: 30px; color: #007529;">Gift Card : {{ProductName}}
                                <br />
                                Gift Code : {{GiftCode}}
                                <br />
                                <%--Expiry Date : 6 months--%>
                            </h4>
                        </div>
                    </div>
                </div>
            </div>
                    <!-- /.table-responsive -->
                </div>
            </div>
        </div>


    </div>
</asp:Content>
