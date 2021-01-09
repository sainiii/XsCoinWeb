<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="g-cards.aspx.cs" Inherits="GlobalBTC.MobileApp.secaue.g_cards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .info {
            text-align: center;
            padding: 8px 0;
            background: #e0e0e0;
        }

            .info h5 {
                font-size: 100%;
                font-weight: bold;
                margin: 0;
            }

        .image-container {
            border: solid 1px #b9b9b9;
        }
    </style>
    <div class="content-sticky-footer pt-0">
        <div class="col-12 mb-4">
            <div class="card">
                <div class="card-body text-center">
                    <h1><span class="font-weight-light small">Gift Cards</span></h1>
                </div>
            </div>
        </div>
        <div class="col-12 mb-4" id="GiftCarList" data-ng-controller="GiftCarList as ctrl">
            <div class="card mb-4 fullscreen">

                <div class="card-body">
                    <div id="dataTables-example_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer">

                        <div class="col-sm-12">

                            <!-- Main content -->
                            <div class="single-port-content" data-margin="0px 0px 0 0">
                                <div class="row mx-0">
                                    <div class="col-12" style="text-align:center">

                                            
                                                <div class="form-group m-b-10">
                                                    <b class="m-t-0">Select your country </b>

                                                    <select class="form-control" ng-model="DDLLocation" ng-change="getData(DDLLocation)">
                                                        <option value="">-Choose Country-</option>
                                                        <option ng-repeat="x in ctrl.CountryList">{{x.country}}</option>
                                                    </select>
                                                </div>
                                                <div class="form-group m-b-10">
                                                    <b class="m-t-0">Search gift cards</b>
                                                    <input class="form-control" id="searchKeyword" data-ng-model="searchKeyword" name="searchKeyword" type="text" placeholder="Enter keywords...">
                                                </div>
                                           
                                        
                                    </div>
                                </div>
                                <hr />
                                <div class="row mx-0">

                                    <div class="col-4 col-md-3 my-2" ng-repeat="d in ctrl.Details | filter: searchKeyword">
                                        <a href="javascript:;" ng-click="BuyNow(d)">
                                            <div class="image-container">
                                                <div class="image">
                                                    <img class="mw-100" src='/cards/{{d.Photo}}' />
                                                </div>
                                                <div class="info">
                                                    <h5>{{d.ProductName}}</h5>
                                                </div>
                                            </div>
                                        </a>
                                    </div>


                                    <h3>{{NoReord}}</h3>


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
