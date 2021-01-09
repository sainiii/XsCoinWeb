<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="main-statement.aspx.cs" Inherits="GlobalBTC.MobileApp.main_statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .Red {
            background: #ff6a00 !important;
        }

        .Green {
            background: green !important;
        }
    </style>
    <div class="side-app" id="mainstatement" data-ng-controller="mainstatement as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Account Statement</li>
            </ol>


        </div>



        <div class="card mb-4 fullscreen">
            <div class="card-header">
                <div class="card-title">Account Statement</div>
            </div>




            <div class="card-body">
                <div id="dataTables-example_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer">

                    <div class="col-sm-12">  <div class="table-responsive">
                        <table class="table table-striped table-bordered text-nowrap w-100 dataTable no-footer" role="grid" aria-describedby="example_info">
                            <thead>
                                <tr>
                                    <th>XS Coin </th>  <th>XS Coin Balance</th>
                                    <th>Date</th>
                                   <th>Price</th>
                                    <th>Remark</th>
                                </tr>
                            </thead>
                            <tbody>

                                <tr ng-repeat="d in ctrl.Details" class="ng-style: d.PType=='Debit'  && {'color':'red'} || d.PType=='credit' && { 'color' : 'green' };">


                                    <td>{{d.PType}} - {{d.Amount}} </td><td>{{d.BankTranBalance}}</td>
                                    <td>{{d.BankTranDate}}</td>
                                     <td>${{d.dollar}} @{{d.OutAmount}}  </td>
                                    <td>{{d.BankTranRemarks}}</td>



                                </tr>



                            </tbody>
                        </table>
                    </div></div>

                </div>
                <!-- /.table-responsive -->
            </div>
        </div>
    </div>

</asp:Content>

