<%@ Page Title="" Language="C#" MasterPageFile="~/secaue/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XsCoinWeb.secaue.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="side-app" id="CtrIndex" data-ng-controller="CtrIndex as ctrl">
        <div class="bg-white p-3 header-secondary row">
            <div class="col">
                <div class="d-flex"></div>
            </div>
            <div class="col col-auto"><a style="color: #000;" href="#">XSC Current Price&nbsp;&nbsp;&nbsp; ${{ExchangeRate}}</a>  </div>
        </div>
        <!-- page-header -->
        <br />
        <br />



        <div class="row">
            <div class="col-md-12">
                <script src="https://widgets.coingecko.com/coingecko-coin-price-marquee-widget.js"></script>
                <coingecko-coin-price-marquee-widget coin-ids="bitcoin,eos,ethereum,litecoin,ripple,xscoin" currency="usd" background-color="#ffffff" locale="en"></coingecko-coin-price-marquee-widget>


                <br />
                <br />
               
                <div class="row">
                    <div class="col-sm-12 col-lg-6 col-xl-3">
                        <div class="card">
                            <div class="row">
                                <div class="col-4">
                                    <div class="feature">
                                        <div class="fa-stack fa-lg fa-2x icon bg-purple"><i class="fa fa-bed fa-stack-1x text-white"></i></div>
                                    </div>
                                </div>
                                <div class="col-8">
                                    <div class="card-body p-3  d-flex">
                                        <div>
                                            <p class="text-muted mb-1">My Package</p>
                                            <h2 class="mb-0 text-dark">${{MYpakage}} </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- col end -->
                    <div class="col-sm-12 col-lg-6 col-xl-3">
                        <div class="card">
                            <div class="row">
                                <div class="col-4">
                                    <div class="feature">
                                        <div class="fa-stack fa-lg fa-2x icon bg-green"><i class="fa fa-user-md fa-stack-1x text-white"></i></div>
                                    </div>
                                </div>
                                <div class="col-8">
                                    <div class="card-body p-3  d-flex">
                                        <div>
                                            <p class="text-muted mb-1">Matching</p>
                                            <h2 class="mb-0 text-dark">${{TeamSales}}</h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- col end -->
                    <div class="col-sm-12 col-lg-6 col-xl-3">
                        <div class="card">
                            <div class="row">
                                <div class="col-4">
                                    <div class="feature">
                                        <div class="fa-stack fa-lg fa-2x icon bg-orange"><i class="fa fa-hospital-o fa-stack-1x text-white"></i></div>
                                    </div>
                                </div>
                                <div class="col-8">
                                    <div class="card-body p-3  d-flex">
                                        <div>
                                            <p class="text-muted mb-1">ROI Income</p>
                                            <h2 class="mb-0 text-dark">${{ROI}}</h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- col end -->
                    <div class="col-sm-12 col-lg-6 col-xl-3">
                        <div class="card">
                            <div class="row">
                                <div class="col-4">
                                    <div class="feature">
                                        <div class="fa-stack fa-lg fa-2x icon bg-yellow"><i class="fa fa-flask fa-stack-1x text-white"></i></div>
                                    </div>
                                </div>
                                <div class="col-8">
                                    <div class="card-body p-3  d-flex">
                                        <div>
                                            <p class="text-muted mb-1">Direct Income </p>
                                            <h2 class="mb-0 text-dark">${{DirectINcome}}</h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- col end -->
                </div>
                <br />
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="row">
                        <div class="col-6 border-right">
                            <div class="card-body iconfont text-center">
                                <h5 class="text-muted">Available XSC  {{VpBallance}} </h5>
                                <h1 class="mt-4 text-dark mainvalue">${{DollarBallance}}</h1>
                                <p><span class="text-dark"><i class="fa fa-arrow-up text-success mr-1"></i>You can withraw or Transfer </span></p>
                                <div class="progress progress-sm mb-0">
                                    <div class="progress-bar progress-bar-striped progress-bar-animated bg-info w-50"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="card-body iconfont text-center">
                                <h5 class="text-muted">Total Income</h5>
                                <h1 class="mt-4 text-dark mainvalue">{{TeamIncome}} $ </h1>
                                <p><span class="text-dark"><i class="fa fa-arrow-down text-success mr-1"></i>from starting - till date</span> </p>
                                <div class="progress progress-sm mb-0">
                                    <div class="progress-bar progress-bar-striped progress-bar-animated bg-info w-70"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="card card-bgimg br-7">
                    <div class="row">
                        <div class="col-xl-3 col-lg-6 col-sm-6 pr-0 pl-0">
                            <div class="card-body text-center">
                                <h5 class="text-white">Direct Team</h5>
                                <h4 class="  text-white  ">{{AppmstSponsorTotal}}</h4>
                                <%-- <div><i class="si si-graph mr-1 text-danger"></i><span class="text-white">Sales</span></div>--%>
                            </div>
                        </div>
                        <div class="col-xl-3  col-lg-6 col-sm-6 pr-0 pl-0">
                            <div class="card-body text-center">
                                <h5 class="text-white">Sponser ID</h5>
                                <h4 class="text-white">{{sponsorid}}</h4>

                            </div>
                        </div>
                        <div class="col-xl-3 col-lg-6 col-sm-6 pr-0 pl-0">
                            <div class="card-body text-center">
                                <h5 class="text-white">Last Upgrade</h5>
                                <h4 class="text-white">{{appPaiddatetime}}</h4>

                            </div>
                        </div>
                        <div class="col-xl-3 col-lg-6 col-sm-6 pr-0 pl-0">
                            <div class="card-body text-center">
                                <h5 class="text-white">Join Date</h5>
                                <h4 class="text-white">{{appmstDOJ}}</h4>

                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-xl-12 col-md-12 col-lg-12">
                <div class="card">

                    <div class="card-body">
                        <div class="table-responsive">

                            <script src="https://widgets.coingecko.com/coingecko-coin-compare-chart-widget.js"></script>
                            <coingecko-coin-compare-chart-widget coin-ids="xscoin" currency="usd" locale="en"></coingecko-coin-compare-chart-widget>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header ">
                        <h3 class="card-title ">My Referral</h3>

                    </div>
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

                                <tr ng-repeat="d in ctrl.Detailsnew">
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
        </div>




         <script type="text/javascript">
             function copyToClipboard(element) {
                 //alert('hi');
                 var $temp = $("<input>");
                 $("body").append($temp);
                 $temp.val($(element).text()).select();
                 document.execCommand("copy");
                 $temp.remove();
             }
                </script>

                <div class="col-12 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <p class="text-uppercase text-center font-weight-bold text-primary">Referral Code</p>
                            <div class="text-center">
                                <h2 style="margin-bottom: 5px;" id="copcode">{{AppMstRegNo}}</h2>

                                <h6 style="margin-bottom: 15px;" id="copurl">https://www.xscoin.io/register.html?ref={{AppMstRegNo}} </h6>

                                <a href="javascript:void" onclick="copyToClipboard('#copcode')" class="btn btn-outline-primary">Copy Code</a> &nbsp;&nbsp;
                                    <a href="javascript:void" onclick="copyToClipboard('#copurl')" class="btn btn-outline-primary">Copy URL</a>
                            </div>

                        </div>
                    </div>
                </div>
    </div>

</asp:Content>
