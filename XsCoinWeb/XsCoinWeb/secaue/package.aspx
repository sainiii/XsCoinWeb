<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="package.aspx.cs" Inherits="XsCoinWeb.secaue.package" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="side-app" id="Packages" data-ng-controller="Packages as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Package </li>
            </ol>
            <!-- End breadcrumb -->
        </div>


        <!-- row -->
        <div class="row">
            <div class="col-xs-6 col-sm-6 col-lg-6 col-xl-4 mt-2" ng-repeat="d in ctrl.Details">
                <div class="panel price  panel-color">
                    <div class=" bg-orange text-center">
                        <h1 style="padding: 10px 0px;">{{d.Pname}} </h1>
                    </div>
                    <div class="panel-body text-center">
                        <p class="lead"><strong>$ {{d.Amount}} </strong></p>
                    </div>
                    <ul class="list-group list-group-flush text-center">
                        <li class="list-group-item"><strong>{{d.JoinFor}}%</strong> Weekly profit.</li>
                        <li class="list-group-item"><strong>{{d.Points}}% </strong>Total </li>

                    </ul>
                    <div class="panel-footer text-center">

                        <a class="btn btn-lg btn-orange btn-block" ng-hide="ctrl.isdellist[{{$index}}]" ng-click="ctrl.ClickToActive(d)">Purchase Now!</a>



                    </div>
                </div>
            </div>

           <%--  
            <div class="col-xs-6 col-sm-6 col-lg-6 col-xl-4  mt-2">
                <div class="panel price  panel-color">
                    <div class=" bg-white text-center">
                        <svg x="0" y="0" viewBox="0 0 360 220">
                            <g>
                                <path fill="#05883a" d="M0.732,193.75c0,0,29.706,28.572,43.736-4.512c12.976-30.599,37.005-27.589,44.983-7.061
													c8.09,20.815,22.83,41.034,48.324,27.781c21.875-11.372,46.499,4.066,49.155,5.591c6.242,3.586,28.729,7.626,38.246-14.243
													s27.202-37.185,46.917-8.488c19.715,28.693,38.687,13.116,46.502,4.832c7.817-8.282,27.386-15.906,41.405,6.294V0H0.48
													L0.732,193.75z">
                                </path>
                            </g>
                            <text transform="matrix(1 0 0 1 69.7256 116.2686)" fill="#fff" font-size="50.4489">Crown</text>
                        </svg>
                    </div>
                    <div class="panel-body text-center">
                        <p class="lead"><strong>$ 25000</strong>  </p>
                    </div>
                    <ul class="list-group list-group-flush text-center">
                        <li class="list-group-item"><strong>4 %</strong> Weekly profit.</li>
                        <li class="list-group-item"><strong>200% </strong>Total </li>
                    </ul>
                    <div class="panel-footer text-center"><a class="btn btn-lg btn-success btn-block" href="upgrade.aspx">Purchase Now!</a> </div>
                </div>
            </div>
          --%>
        </div>
        <!-- row end -->
    </div>
</asp:Content>
