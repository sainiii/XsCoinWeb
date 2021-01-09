<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="roi-report.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.roi_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="side-app" id="roireport" data-ng-controller="roireport as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">ROI Income</li>
            </ol>


        </div>



        <div class="card mb-4 fullscreen">
            <div class="card-header">
                <div class="card-title">ROI Income</div>
            </div>



            <div class="card-body">
                <div id="dataTables-example_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer">

                    <div class="col-sm-12">  <div class="table-responsive">
                        <table class="table table-striped table-bordered text-nowrap w-100 dataTable no-footer" role="grid" aria-describedby="example_info">

                            <thead>
                                <tr>
                                    <th>Due Date</th>
                                    <th>Amount</th>
                                    <th>Remark</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="d in ctrl.Details">
                                    <td>{{d.BankTranDate}} </td>
                                    <td>{{d.Amount}} </td>
                                    <td>{{d.BankTranRemarks}} </td>
                                    <td>Given</td>
                                </tr>


                            </tbody>
                        </table></div>
                    </div>

                </div>
                <!-- /.table-responsive -->
            </div>
        </div>
    </div>



</asp:Content>
