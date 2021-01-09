<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="dir-ref.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.dir_ref" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="side-app" id="refreport" data-ng-controller="refreport as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Direct Referral List</li>
            </ol>


        </div>



        <div class="card mb-4 fullscreen">
            <div class="card-header">
                <div class="card-title">Direct Referral List </div>
            </div>



            <div class="card mb-4 fullscreen">
                <div class="card-body">
                    <div id="dataTables-example_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered text-nowrap w-100 dataTable no-footer" role="grid" aria-describedby="example_info">
                                    <thead>
                                        <tr>
                                            <th>User ID</th>
                                            <th>Position</th>

                                            <th>Reg Date</th>
                                            <th>Upgrade Date</th>
                                            <th>Package</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <tr ng-repeat="d in ctrl.Details">
                                            <td>{{d.AppMstRegNo}} -{{d.membername}} </td>
                                            <td>{{d.AppMstLeftRight}}</td>

                                            <td>{{d.AppmstDOJ}} </td>
                                            <td>{{d.topupdate}} </td>
                                            <td>{{d.jamount}}</td>
                                            <td>{{d.Appmstpaid}}</td>
                                        </tr>



                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                    <!-- /.table-responsive -->
                </div>
            </div>
        </div>


    </div>
</asp:Content>
