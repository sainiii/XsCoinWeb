

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
                ctrl.HyperLink1 = response;
                ctrl.Tree2(response[0].AppMstRegNo);
                ctrl.Tree3(response[0].AppMstRegNo);
            }
            else
                ctrl.HyperLink1 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink1 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            console.log(x)
            x.Message;
        });
    }


    var Sourceid = GetParameterValues('NValues');

    if (Sourceid == null) {

        var ID = localStorage.getItem('USERID')
        ctrl.TreeFirst(ID);
    }
    else {

        ctrl.TreeFirst(Sourceid);
    }


    ctrl.FN_TopTreeValues = function (d) {
        var IDDD = d.AppMstRegNo;
        ctrl.TreeFirst(IDDD);
    }










    ctrl.Tree2 = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink2 = response;
                ctrl.Tree4(response[0].AppMstRegNo);
                ctrl.Tree5(response[0].AppMstRegNo);
            }
            else {
                ctrl.HyperLink2 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            }
        }, function (x) {
                ctrl.HyperLink2 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            console.log(x)
            x.Message;
        });
    }

    ctrl.Tree3 = function (index) {

        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink3 = response;
                ctrl.Tree6(response[0].AppMstRegNo);
                ctrl.Tree7(response[0].AppMstRegNo);
            }
            else
                ctrl.HyperLink3 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink3 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            console.log(x)
            x.Message;
        });
    }




    ctrl.Tree4 = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink4 = response;
                ctrl.Tree8(response[0].AppMstRegNo);
                ctrl.Tree9(response[0].AppMstRegNo);
            }
            else
                ctrl.HyperLink4 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink4 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            console.log(x)
            x.Message;
        });
    }
    ctrl.Tree5 = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink5 = response;
                ctrl.Tree10(response[0].AppMstRegNo);
                ctrl.Tree11(response[0].AppMstRegNo);
            }
            else
                ctrl.HyperLink5 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink5 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }





    ctrl.Tree6 = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink6 = response;
                ctrl.Tree12(response[0].AppMstRegNo);
                ctrl.Tree13(response[0].AppMstRegNo);
            }
            else
                ctrl.HyperLink6 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink6 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }
    ctrl.Tree7 = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink7 = response;
                ctrl.Tree14(response[0].AppMstRegNo);
                ctrl.Tree15(response[0].AppMstRegNo);
            }
            else
                ctrl.HyperLink7 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink7 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }





    ctrl.Tree8 = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink8 = response;
            }
            else
                ctrl.HyperLink8 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink8 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }
    ctrl.Tree9 = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink9 = response;
            }
            else
                ctrl.HyperLink9 = [{ ImagePath: '../tree/open.png',   AppMstRegNo: '0' }];
        }, function (x) {
                ctrl.HyperLink9 = [{ ImagePath: '../tree/open.png',   AppMstRegNo: '0' }];
            x.Message;
        });
    }
    ctrl.Tree10 = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Hten = response;
            }
            else
                ctrl.Hten = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.Hten = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }
    ctrl.Tree11 = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink11 = response;
            }
            else
                ctrl.HyperLink11 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink11 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }



    ctrl.Tree12 = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink12 = response;
            }
            else
                ctrl.HyperLink12 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink12 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }
    ctrl.Tree13 = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink13 = response;
            }
            else
                ctrl.HyperLink13 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink13 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }
    ctrl.Tree14 = function (index) {
        var SearchForm = { UserID: index, PType: '0' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink14 = response;
            }
            else
                ctrl.HyperLink14 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink14 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }
    ctrl.Tree15 = function (index) {
        var SearchForm = { UserID: index, PType: '1' }
        authService.PostData("/API/AppTree/GetSecondLevel", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.HyperLink15 = response;
            }
            else
                ctrl.HyperLink15 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
        }, function (x) {
                ctrl.HyperLink15 = [{ ImagePath: '../tree/open.png', AppMstRegNo: '0'  }];
            x.Message;
        });
    }


}]);
