<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="g-tree.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.g_tree" %>

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
            color: #000;
            border-bottom: solid 1px #cecece;
        }

        .modal-body span {
            float: right;
        }
    </style>


    <script src="../AppJS/GtreeNew.js"></script>


    <div class="side-app" id="GTree" data-ng-controller="GTree as ctrl">

        <!-- page-header -->
        <div class="page-header">
            <ol class="breadcrumb">
                <!-- breadcrumb -->
                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Genealogy Tree</li>
            </ol>


        </div>


        {{MMMM}}


        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-body text-center">
                    <div class="table-responsive">
                        <table class="table table-borderless">
                            <tr class="row111" ng-repeat="H1 in ctrl.HyperLink1">
                                <td colspan="8" style="width: 100%">
                                    <img src="{{H1.ImagePath}}" />
                                    <span>{{H1.AppMstRegNo}}</span>
                                    <p><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H1)">View Detail </a></p>
                                </td>
                            </tr>
                            <tr class="row222">
                                <td colspan="4" style="width: 50%">
                                    <div ng-repeat="H2 in ctrl.HyperLink2">
                                        <img src="{{H2.ImagePath}}" />
                                        <span ng-show="H2.AppMstRegNo != 0"><a href="g-tree?NValues={{H2.AppMstRegNo}}">{{H2.AppMstFName}} ({{H2.AppMstRegNo}})</a></span>
                                        <p ng-show="H2.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H2)">View Detail </a></p>
                                    </div>
                                </td>
                                <td colspan="4" style="width: 50%">
                                    <div ng-repeat="H3 in ctrl.HyperLink3">
                                        <img src="{{H3.ImagePath}}" />
                                        <span ng-show="H3.AppMstRegNo != 0"><a href="g-tree?NValues={{H3.AppMstRegNo}}">{{H3.AppMstFName}} ({{H3.AppMstRegNo}}) </a></span>
                                        <p ng-show="H3.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H3)">View Detail </a></p>
                                    </div>
                                </td>
                            </tr>
                            <tr class="row222">
                                <td style="width: 25%" colspan="2">
                                    <div ng-repeat="H4 in ctrl.HyperLink4">
                                        <img src="{{H4.ImagePath}}" />
                                        <span ng-show="H4.AppMstRegNo != 0"><a href="g-tree?NValues={{H4.AppMstRegNo}}">{{H4.AppMstFName}} ({{H4.AppMstRegNo}})</a></span>
                                        <p ng-show="H4.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H4)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 25%" colspan="2">
                                    <div ng-repeat="H5 in ctrl.HyperLink5">
                                        <img src="{{H5.ImagePath}}" />
                                        <span ng-show="H5.AppMstRegNo != 0"><a href="g-tree?NValues={{H5.AppMstRegNo}}">{{H5.AppMstFName}} ({{H5.AppMstRegNo}}) </a></span>
                                        <p ng-show="H5.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H5)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 25%" colspan="2">
                                    <div ng-repeat="H6 in ctrl.HyperLink6">
                                        <img src="{{H6.ImagePath}}" />
                                        <span ng-show="H6.AppMstRegNo != 0"><a href="g-tree?NValues={{H6.AppMstRegNo}}">{{H6.AppMstFName}} ({{H6.AppMstRegNo}})</a></span>
                                        <p ng-show="H6.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H6)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 25%" colspan="2">
                                    <div ng-repeat="H7 in ctrl.HyperLink7">
                                        <img src="{{H7.ImagePath}}" />
                                        <span ng-show="H7.AppMstRegNo != 0"><a href="g-tree?NValues={{H7.AppMstRegNo}}">{{H7.AppMstFName}} ({{H7.AppMstRegNo}}) </a></span>
                                        <p ng-show="H7.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H7)">View Detail </a></p>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 12.5%">
                                    <div ng-repeat="H8 in ctrl.HyperLink8">
                                        <img src="{{H8.ImagePath}}" />
                                        <span ng-show="H8.AppMstRegNo != 0"><a href="g-tree?NValues={{H8.AppMstRegNo}}">{{H8.AppMstFName}} ({{H8.AppMstRegNo}}) </a></span>
                                        <p ng-show="H8.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H8)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 12.5%">
                                    <div ng-repeat="H9 in ctrl.HyperLink9">
                                        <img src="{{H9.ImagePath}}" />
                                        <span ng-show="H9.AppMstRegNo != 0"><a href="g-tree?NValues={{H9.AppMstRegNo}}">{{H9.AppMstFName}} ({{H9.AppMstRegNo}})</a></span>
                                        <p ng-show="H9.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H9)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 12.5%">
                                    <div ng-repeat="Hten in ctrl.HyperLink10">
                                        <img src="{{Hten.ImagePath}}" />
                                        <span ng-show="Hten.AppMstRegNo != 0"><a href="g-tree?NValues={{Hten.AppMstRegNo}}">{{Hten.AppMstFName}} ({{Hten.AppMstRegNo}}) </a></span>
                                        <p ng-show="Hten.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(Hten)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 12.5%">
                                    <div ng-repeat="H11 in ctrl.HyperLink11">
                                        <img src="{{H11.ImagePath}}" />

                                        <span ng-show="H11.AppMstRegNo != 0"><a href="g-tree?NValues={{H11.AppMstRegNo}}">{{H11.AppMstFName}} ({{H11.AppMstRegNo}}) </a></span>
                                        <p ng-show="H11.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H11)">View Detail </a></p>


                                    </div>
                                </td>


                                <td style="width: 12.5%">
                                    <div ng-repeat="H112 in ctrl.HyperLink12">
                                        <img src="{{H112.ImagePath}}" />
                                        <span ng-show="H12.AppMstRegNo != 0"><a href="g-tree?NValues={{H12.AppMstRegNo}}">{{H12.AppMstFName}} ({{H12.AppMstRegNo}}) </a></span>
                                        <p ng-show="H12.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H112)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 12.5%">
                                    <div ng-repeat="H13 in ctrl.HyperLink13">
                                        <img src="{{H13.ImagePath}}" />
                                        <span ng-show="H13.AppMstRegNo != 0"><a href="g-tree?NValues={{H13.AppMstRegNo}}">{{H13.AppMstFName}} ({{H13.AppMstRegNo}}) </a></span>
                                        <p ng-show="H13.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H13)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 12.5%">
                                    <div ng-repeat="H14 in ctrl.HyperLink14">
                                        <img src="{{H14.ImagePath}}" />
                                        <span ng-show="H14.AppMstRegNo != 0"><a href="g-tree?NValues={{H14.AppMstRegNo}}">{{H14.AppMstFName}} ({{H14.AppMstRegNo}}) </a></span>
                                        <p ng-show="H14.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H14)">View Detail </a></p>
                                    </div>
                                </td>
                                <td style="width: 12.5%">
                                    <div ng-repeat="H15 in ctrl.HyperLink15">
                                        <img src="{{H15.ImagePath}}" />
                                        <span ng-show="H15.AppMstRegNo != 0"><a href="g-tree?NValues={{H15.AppMstRegNo}}">{{H15.AppMstFName}} ({{H15.AppMstRegNo}})</a></span>
                                        <p ng-show="H15.AppMstRegNo != 0"><a class="btn btn-sm btn-outline-success" data-toggle="modal" data-target="#exampleModal" ng-click="FN_View(H15)">View Detail </a></p>

                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
            </div>
            <div class="modal" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content" ng-show="showModalnew">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">{{AppMstRegNo}} ({{AppMstFName}})</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>Sponsor ID : <span>{{SponsorID}}</span></p>
                            <p>Business Left : <span>${{AppMstLeftTotal}} </span></p>
                            <p>Business Right : <span>${{AppMstRightTotal}}</span></p>
                            <p>Carry Forward Left : <span>${{carryleft}}</span></p>
                            <p>Carry Forward Right : <span>${{carryright}}</span></p>
                            <p>New Business Left : <span>${{totalnewleft}}</span></p>
                            <p>New Business Right : <span>${{totalnewright}}</span></p>
                        </div>

                    </div>
                </div>
            </div>
        </div>


    </div>


    <!-- Modal -->

</asp:Content>
