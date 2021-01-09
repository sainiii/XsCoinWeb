

UserAppLogin.controller('GTree', ['$scope', '$rootScope', 'authService', '$window', function ($scope, $rootScope, authService, $window) {

    var ctrl = this;

    var md = {};
    ctrl.md = md;

    $rootScope.showModalnew = false;


    $rootScope.FN_View = function (d) {
        $rootScope.showModalnew = true;
        $rootScope.SponsorID = d.SponsorID;
        $rootScope.AppMstFName = d.AppMstFName;
        $rootScope.AppMstRegNo = d.AppMstRegNo;
        $rootScope.AppMstLeftTotal = d.AppMstLeftTotal;
        $rootScope.AppMstRightTotal = d.AppMstRightTotal;
        $rootScope.carryleft = d.carryleft;
        $rootScope.carryright = d.carryright;
        $rootScope.totalnewleft = d.totalnewleft;
        $rootScope.totalnewright = d.totalnewright;
    }

    function GetParameterValues(param) {
        var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < url.length; i++) {
            var urlparam = url[i].split('=');
            if (urlparam[0] == param) {
                return urlparam[1];
            }
        }
    }

    ctrl.TreeFirst = function (inexvalues) {

        var SearchForm = { UserID: inexvalues }
        authService.PostData("/API/AppTree/GetFirstLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.FirstLeve = response;
                ctrl.TreeLeftSecond(response[0].AppMstRegNo);
                ctrl.TreeRightSecond(response[0].AppMstRegNo);
            }
            else
                ctrl.FirstLeve = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }



    ctrl.FN_TopTreeValues = function (d) {
        var IDDD = d.AppMstRegNo;
        ctrl.TreeFirst(IDDD);
    }

    var ID = localStorage.getItem('USERID')
    ctrl.TreeFirst(ID);







    ctrl.TreeLeftSecond = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.SLeftLeve = response;
                ctrl.TreeLeft1Third(response[0].AppMstRegNo);
                ctrl.TreeLeft2Third(response[0].AppMstRegNo);
            }
            else
                ctrl.SLeftLeve = [];
        }, function (x) {
            ctrl.SLeftLeve = [];
            console.log(x)
            x.Message;
        });
    }

    ctrl.TreeRightSecond = function (index) {

        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.RigthSecondtLevel = response;
                ctrl.TreeLeft3Third(response[0].AppMstRegNo);
                ctrl.TreeLeft4Third(response[0].AppMstRegNo);
            }
            else
                ctrl.RigthSecondtLevel = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }




    ctrl.TreeLeft1Third = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.T1LeftLeve = response;
            }
            else
                ctrl.T1LeftLeve = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.TreeLeft2Third = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.T2LeftLeve = response;
            }
            else
                ctrl.T2LeftLeve = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }





    ctrl.TreeLeft3Third = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.T3LeftLeve = response;
            }
            else
                ctrl.T3LeftLeve = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.TreeLeft4Third = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.T4LeftLeve = response;
            }
            else
                ctrl.T4LeftLeve = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
}]);
