<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="trn-hostory.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.trn_hostory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-sticky-footer pt-0">
        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-body text-center">
                    <h1><span class="font-weight-light small">Fund Transfer Report</span></h1>
                </div>
            </div>
        </div>
        <div class="col-12 mb-4" id="trnhostory" data-ng-controller="trnhostory as ctrl">
            <div class="card mb-4 fullscreen">

                <div class="card-body">
                    <div id="dataTables-example_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer">

                        <div class="col-sm-12">
                            <table class="table " id="dataTables-example">
                                <thead>
                                    <tr>
                                        <th>Date</th>
                                        <th>Amount</th>
                                        <th>Remark</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr ng-repeat="d in ctrl.Details">
                                        <td>{{d.BankTranDate}}</td>
                                        <td>{{d.Amount}}</td>
                                        <td>Transfer to {{d.PaidDetail}}</td>

                                    </tr>
                                    
                                </tbody>
                            </table>
                        </div>

                    </div>
                    <!-- /.table-responsive -->
                </div>
            </div>
        </div>


    </div>
</asp:Content>
