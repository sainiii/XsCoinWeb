<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="btc-report.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.btc_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="side-app" id="btcactivereport" data-ng-controller="btcactivereport as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="#">BTC Upgrade Report Fund</a></li>
                <li class="breadcrumb-item active" aria-current="page">BTC Upgrade Report</li>
            </ol>


        </div>



        <div class="card mb-4 fullscreen">
            <div class="card-header">
                <div class="card-title">BTC Upgrade Report Fund </div>
            </div>
            <div class="card-body">
                <div id="dataTables-example_wrapper" class="table-responsive">
                    <div class="col-sm-12">
                        <table class="table table-striped table-bordered text-nowrap w-100 dataTable no-footer" role="grid" aria-describedby="example_info">
                            <thead>
                                <tr>
                                    <th>
                                        <center>S. No</center>
                                    </th>
                                    <th>Account ID
                                    </th>
                                    <th>Amount
                                    </th>
                                    <th>Date
                                    </th>
                                    <th>Pay Mode
                                    </th>
                                    <th>Type</th>
                                </tr>
                            </thead>
                            <tbody>

                                <tr ng-repeat="d in ctrl.Details">
                                    <td>{{$index + 1}}</td>
                                    <td>{{d.AppMstRegNo}}
                                    </td>
                                    <td>{{d.BankTranAmount}}
                                    </td>
                                    <td>{{d.BankTranDate}}
                                    </td>
                                    <td>{{d.BankTranMode}} 
                                    </td>
                                    <td>{{d.AmountFor}}
                                    </td>
                                </tr>



                            </tbody>
                        </table>
                    </div>

                </div>
                <!-- /.table-responsive -->
            </div>
        </div>
    </div>

</asp:Content>
