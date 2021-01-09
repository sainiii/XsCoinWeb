
UserAppLogin.controller('CtrIndex', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    authService.GetBlance();
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/Fn_UserInformationFull", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                $scope.AppmstFName = response[0].AppmstFName;
                $scope.TeamIncome = response[0].TeamIncome;
                $scope.AppmstRightTotal = response[0].AppmstRightTotal;
                $scope.LeftMember = response[0].LeftMember;
                $scope.rightMember = response[0].rightMember;
                $scope.AppmstSponsorTotal = response[0].AppmstSponsorTotal;
                $scope.ROI = response[0].ROI;
                $scope.DirectINcome = response[0].DirectINcome;
                $scope.TeamSales = response[0].TeamSales;
                $scope.MYpakage = response[0].MYpakage;
                $scope.sponsorid = response[0].sponsorid;
                $scope.appmstDOJ = response[0].appmstDOJ;

                $scope.AppMstRegNo = response[0].AppMstRegNo;
                $rootScope.AppMstRegNo = response[0].AppMstRegNo;
                $rootScope.AppmstFName = response[0].AppmstFName;

                $rootScope.appmstpaid = response[0].appmstpaid;

                if ($rootScope.appmstpaid == 1) { $scope.appPaiddatetime = response[0].appPaiddatetime; }
                else {
                    $scope.appPaiddatetime = "--";

                }
                $rootScope.ROICountShow = response[0].ROICountShow;
                var DAysCount = response[0].DAysCount;

                var Newdays = 0;
                Newdays = 15 - DAysCount;
                if (DAysCount <= 15) {
                    $rootScope.DaysLeft = 'NO BOOSTER TIME LEFT- ' + Newdays + ' DAYS'
                }

                authService.GetBlance();
            }
            else
                ctrl.Details = [];
        }, function (x) {

            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();



    ctrl.Getrefreport = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/Getrefreport", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Detailsnew = response;
            }
            else
                ctrl.Detailsnew = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.Getrefreport();

}]);


UserAppLogin.controller('mainstatement', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/Getaccountstatement", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;

            }
            else
                ctrl.Details = [];
        }, function (x) {
            if (response.status == 401) {
                $window.location.href = "/login.html";
            }
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('downline', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/Getdownlinedetail", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);



UserAppLogin.controller('roireport', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/GetROIIncome", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('refreport', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/Getrefreport", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('btcactivereport', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/UserAppAPI/activeandUpgradeHistory", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('refIncomereport', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/Getreferralincome", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('trnhostory', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/transferreport", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('upgradereport', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/upgradereport", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('whistory', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/ReportUserAPI/withdrawhistory", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('Packages', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;

    var Base64 = { _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=", encode: function (e) { var t = ""; var n, r, i, s, o, u, a; var f = 0; e = Base64._utf8_encode(e); while (f < e.length) { n = e.charCodeAt(f++); r = e.charCodeAt(f++); i = e.charCodeAt(f++); s = n >> 2; o = (n & 3) << 4 | r >> 4; u = (r & 15) << 2 | i >> 6; a = i & 63; if (isNaN(r)) { u = a = 64 } else if (isNaN(i)) { a = 64 } t = t + this._keyStr.charAt(s) + this._keyStr.charAt(o) + this._keyStr.charAt(u) + this._keyStr.charAt(a) } return t }, decode: function (e) { var t = ""; var n, r, i; var s, o, u, a; var f = 0; e = e.replace(/[^A-Za-z0-9\+\/\=]/g, ""); while (f < e.length) { s = this._keyStr.indexOf(e.charAt(f++)); o = this._keyStr.indexOf(e.charAt(f++)); u = this._keyStr.indexOf(e.charAt(f++)); a = this._keyStr.indexOf(e.charAt(f++)); n = s << 2 | o >> 4; r = (o & 15) << 4 | u >> 2; i = (u & 3) << 6 | a; t = t + String.fromCharCode(n); if (u != 64) { t = t + String.fromCharCode(r) } if (a != 64) { t = t + String.fromCharCode(i) } } t = Base64._utf8_decode(t); return t }, _utf8_encode: function (e) { e = e.replace(/\r\n/g, "\n"); var t = ""; for (var n = 0; n < e.length; n++) { var r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r) } else if (r > 127 && r < 2048) { t += String.fromCharCode(r >> 6 | 192); t += String.fromCharCode(r & 63 | 128) } else { t += String.fromCharCode(r >> 12 | 224); t += String.fromCharCode(r >> 6 & 63 | 128); t += String.fromCharCode(r & 63 | 128) } } return t }, _utf8_decode: function (e) { var t = ""; var n = 0; var r = c1 = c2 = 0; while (n < e.length) { r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r); n++ } else if (r > 191 && r < 224) { c2 = e.charCodeAt(n + 1); t += String.fromCharCode((r & 31) << 6 | c2 & 63); n += 2 } else { c2 = e.charCodeAt(n + 1); c3 = e.charCodeAt(n + 2); t += String.fromCharCode((r & 15) << 12 | (c2 & 63) << 6 | c3 & 63); n += 3 } } return t } }


    ctrl.ClickToActive = function (index) {

        var PID = index.srno;
        var url = 'activate.aspx?PackageID=' + Base64.encode(PID);

        window.location.href = url
    };

    ctrl.SlotGetList = function () {
        var SearchForm = { RegNo: localStorage.getItem('USERID') }
        authService.PostData("/API/UserAPI/Package", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
                ctrl.isdellist = [];

                for (var i = 0; i < ctrl.Details.length; i++) {
                    if (ctrl.Details[i].isactive == "1") {
                        ctrl.isdellist.push(false);

                        ctrl.messages = '';
                    }
                    else {

                        ctrl.isdellist.push(true);

                    }
                }



            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();
}]);

UserAppLogin.controller('WithDrawFund', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;

    ctrl.QRCodetab = false;
    ctrl.Checkouttab = true;
    authService.GetBlance();
   // authService.GetBlanceexchange();
    ctrl.myRate = function () {
        var sText = $scope.Amount
        validText = sText.substring(0, sText.length - 1)
        var ValidChars = "0123456789.";
        var Char;
        for (i = 0; i < sText.length; i++) {
            Char = sText.charAt(i);
            if (ValidChars.indexOf(Char) == -1) {
                $scope.Amount = validText
            }
        }



        var Amount = $scope.Amount * 10 / 100
        var AdminCharge = $scope.Amount - Amount
        var btcc = $rootScope.ExchangeRate;
        $scope.AmountTotal = '10% admin charges you will get XSC ' + AdminCharge + ' (' + Amount + ' XSC)';
        $scope.BTCAMount = btcc;


       





    }




    ctrl.myFunc = function () {
        var SearchForm = { UserID: localStorage.getItem('USERID') }
        authService.PostData("/API/WithdrawFundAPP/GetBTCAddress", SearchForm).then(function (response) {
            if (response) {
                $scope.txtbtc = response;
                $scope.MessagesType = "";
                $scope.btnBtc = true;
            } else {
                $scope.btnBtc = false;
                $scope.MessagesType = "Please update your BTC address";
            }
        });
    }

    ctrl.myFunc();


    ctrl.CreateOTPClick = function () {
        $scope.MessagesOutput = "";
        var UserID = localStorage.getItem('USERID')
        var SearchForm = { RegID: UserID, OTPType: "WithDraw" };
        if ($scope.Amount && $scope.Amount.length > 0 && $scope.txtbtc && $scope.txtbtc.length > 0) {
            authService.PostData("/API/UserAPI/CreateOTP", SearchForm).then(function (response) {
                if (response) {
                    if (response !== '') {

                        ctrl.ACodeType = response;
                        ctrl.QRCodetab = true;
                        ctrl.Checkouttab = false;
                    }
                    else { }
                }


            });
        }

        else { demo.showNotificationError("Please  Enter Amount") }
    }

    ctrl.PaymentClick = function () {
        $scope.MessagesOutput = "";
        var UserID = localStorage.getItem('USERID')
        var SearchForm = { Amount: $scope.Amount, txtbtc: $scope.txtbtc, BTCAMount: $scope.BTCAMount, OTPCode: $scope.OTPCode, UserID: UserID };
        if ($scope.Amount && $scope.Amount.length > 0 && $scope.txtbtc && $scope.txtbtc.length > 0) {
            authService.PostData("/API/WithdrawFundAPP/FundWithDraw", SearchForm).then(function (response) {
                if (response) {
                    if (response == '1') {
                        ctrl.QRCodetab = false;
                        ctrl.Checkouttab = true;
                        authService.GetBlance();
                        demo.showNotificationSucess("Sucess")
                    }
                    else { demo.showNotificationError(response.SeatArragement) }
                }
                $scope.txtRegNo = $scope.Amount = $scope.Skey = '';
                $scope.selectedCar = 0
                $scope.ConvertBTC = 0

            });
        }

        else { demo.showNotificationError("Please  Enter Amount") }
    }
}]);

UserAppLogin.controller('Trnasfer', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    authService.GetBlance();

    ctrl.myFunc = function () {
        var SearchForm = { RegID: $scope.TrsferID }
        authService.PostData("/api/UserAccountsApi/GetName", SearchForm).then(function (response) {
            if (response) {
                $scope.username = response;
            } else { }
        });
    }

    ctrl.TrasferClick = function () {
        $scope.MessagesOutput = "";
        var UserID = localStorage.getItem('USERID')
        var SearchForm = { Amount: $scope.Amount, TrsferID: $scope.TrsferID, SKey: $scope.Skey, UserID: UserID };
        if ($scope.Amount && $scope.Amount.length > 0 && $scope.TrsferID && $scope.TrsferID.length > 0) {
            authService.PostData("/API/WithdrawFundAPP/Fundtrasfer", SearchForm).then(function (response) {
                if (response) {
                    if (response == '1') {

                        authService.GetBlance();
                        $scope.TrsferID = $scope.Amount = $scope.Skey = $scope.username = '';
                    }
                    else { }
                }



            });
        }

        else { }
    }
}]);

UserAppLogin.controller('ActivateAccount', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;


    authService.GetBlanceexchange();
    authService.GetBlance();
    var rate = $rootScope.ExchangeRate;
    ctrl.Checkouttab = true;
    ctrl.QRCodetab = false;
    function decode_base64(s) {
        var b = l = 0, r = '',
            m = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'.split('');
        s.split('').forEach(function (v) {
            b = (b << 6) + m.indexOf(v); l += 6;
            while (l >= 8) r += String.fromCharCode((b >>> (l -= 8)) & 0xff);
        });
        return r;
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
    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }
    ctrl.myFunc = function () {
        var SearchForm = { RegID: $scope.TopID }
        authService.PostData("/api/UserAccountsApi/GetName", SearchForm).then(function (response) {
            if (response) {
                $scope.username = response;
            } else { }
        });
    }


    $scope.selectedCar = '0';
    $scope.getPayment = function () {
        getGeoLoc($scope.selectedCar);

    };

    var Sourceid = decode_base64(GetParameterValues('PackageID'));

    ctrl.Getpackage = function () {
        var SearchForm = { PackageId: Sourceid }
        authService.PostData("/API/UserAPI/PackageDetial", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.pakcageName = response[0].Pname;
                ctrl.Amount = response[0].Amount;
                ctrl.Profit = response[0].JoinFor;
                ctrl.Total = response[0].Points;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.Getpackage();
    $scope.BTCClick = function () {
        $scope.ModePayment = "CRP";
        $scope.CryptopPayment = true;
        $scope.BTCclass = "blue";
        $scope.fundclass = "red";
    }

    $scope.walletClick = function () {

        $scope.BTCclass = "red";
        $scope.fundclass = "blue";
        $scope.ModePayment = "FUND";
        $scope.CryptopPayment = false;
        if ($scope.BalanceVp >= 25) {
            $scope.PaymentClickM = true;
        }
        else { $scope.Modalwalletp = true; $scope.PaymentClickM = false; }

    }
    getGeoLoc = function (TaxID) {
        if ($scope.Amount == undefined || $scope.Amount == '') {
            window.alert("Please Enter Upgrade Amount");
        }
        else {
            if ($scope.selectedCar !== '0') {


                var SearchForm = { BTCType: TaxID }
                authService.PostData("/api/UserAppAPI/GetBTCAddminAddress", SearchForm).then(function (response) {
                    if (response) {
                        $scope.BTCAddressAddress = response;
                        $scope.Address = response;

                    } else { }
                });



            }
            else { $scope.ConvertBTC = 0 }
        }
    }
    $scope.myRate = function () {
        if ($scope.ModePayment == 'CRP') {
            if ($scope.selectedCar !== '0') {

                var SearchForm = { BTCType: $scope.selectedCar }
                authService.PostData("/api/UserAppAPI/GetBTCAddminAddress", SearchForm).then(function (response) {
                    if (response) {
                        $scope.BTCAddressAddress = response;
                        $scope.Address = response;

                    } else { }
                });
                //var url = "https://api.cryptonator.com/api/ticker/usd-" + $scope.selectedCar;
                //$http.get(url).then(function (response) {
                //    $scope.ConvertBTC = response.data.ticker.price * $scope.Amount;

                //})
                //    .error(function (data, status, headers, config) {
                //    });
            }
            else { $scope.ConvertBTC = 0 }
        }


    }

    ctrl.CreateOTPClick = function () {
        $scope.MessagesOutput = "";
        ctrl.loderscreen = true;
        var UserID = localStorage.getItem('USERID')
        var SearchForm = { RegID: UserID, OTPType: "Active" };
        authService.PostData("/API/UserAPI/CreateOTP", SearchForm).then(function (response) {
            if (response) {
                if (response !== '') {

                    ctrl.ACodeType = response;
                    ctrl.QRCodetab = true;
                    ctrl.Checkouttab = false;
                }
                else { }
                ctrl.loderscreen = false;
            }
            $scope.txtRegNo = $scope.Amount = $scope.Skey = '';
            $scope.selectedCar = 0;
            $scope.ConvertBTC = 0;
            ctrl.loderscreen = false;

        });

    }


    ctrl.PaymentClick = function () {

        ctrl.loderscreen = true;
        var CAmount = parseFloat((ctrl.Amount * $rootScope.ExchangeRate).toFixed(2));
        ctrl.Type = 'Active';
        if (ctrl.OTP == undefined) { demo.showNotificationError("Please Enter OTP Code"); return }
        var UserID = localStorage.getItem('USERID');
        var SearchForm = { RegID: UserID, Amt: ctrl.Amount, Type: ctrl.Type, OTP: ctrl.OTP, Amountrate: $rootScope.ExchangeRate, ConverAmt: CAmount };
        authService.PostData("/api/UserAppAPI/Purchasepackage", SearchForm).then(function (response) {
            if (response) {
                console.log(response.SeatArragement);
                if (response.SeatArragement == "1") {

                    ctrl.QRCodetab = false;
                    ctrl.Checkouttab = true;
                    authService.GetBlance();
                    demo.showNotificationSucess("Sucess")

                }
                else { demo.showNotificationError(response.SeatArragement) }

                ctrl.loderscreen = false;
            }
        }, function (x) {
            demo.showNotificationError(x);
            ctrl.loderscreen = false;
        });

        //}
        //else { demo.showNotificationError("Please Enter Upgrade User ID and  Upgrade Amount, and Security Key"); }
    }


    $scope.fileList = [];
    $scope.curFile;
    $scope.ImageProperty = {
        file: ''
    }
    $scope.setFile = function (element) {
        $scope.fileList = [];
        var files = element.files;
        for (var i = 0; i < files.length; i++) {
            $scope.ImageProperty.file = files[i];
            $scope.fileList.push($scope.ImageProperty);
            $scope.ImageProperty = {};
            $scope.$apply();

        }
    }




    $scope.uploadFile = function (CustID) {
        var xhr = new XMLHttpRequest();
        var file = $scope.fileList[0].file
        xhr.open("POST", "/api/UserAppAPI/MyFileUpload");
        xhr.setRequestHeader("filename", file.name);
        xhr.setRequestHeader("FileID", CustID);
        xhr.send(file);

    }
}]);

UserAppLogin.controller('GiftCarList', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    function decode_base64(s) {
        var b = l = 0, r = '',
            m = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'.split('');
        s.split('').forEach(function (v) {
            b = (b << 6) + m.indexOf(v); l += 6;
            while (l >= 8) r += String.fromCharCode((b >>> (l -= 8)) & 0xff);
        });
        return r;
    }
    var Base64 = { _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=", encode: function (e) { var t = ""; var n, r, i, s, o, u, a; var f = 0; e = Base64._utf8_encode(e); while (f < e.length) { n = e.charCodeAt(f++); r = e.charCodeAt(f++); i = e.charCodeAt(f++); s = n >> 2; o = (n & 3) << 4 | r >> 4; u = (r & 15) << 2 | i >> 6; a = i & 63; if (isNaN(r)) { u = a = 64 } else if (isNaN(i)) { a = 64 } t = t + this._keyStr.charAt(s) + this._keyStr.charAt(o) + this._keyStr.charAt(u) + this._keyStr.charAt(a) } return t }, decode: function (e) { var t = ""; var n, r, i; var s, o, u, a; var f = 0; e = e.replace(/[^A-Za-z0-9\+\/\=]/g, ""); while (f < e.length) { s = this._keyStr.indexOf(e.charAt(f++)); o = this._keyStr.indexOf(e.charAt(f++)); u = this._keyStr.indexOf(e.charAt(f++)); a = this._keyStr.indexOf(e.charAt(f++)); n = s << 2 | o >> 4; r = (o & 15) << 4 | u >> 2; i = (u & 3) << 6 | a; t = t + String.fromCharCode(n); if (u != 64) { t = t + String.fromCharCode(r) } if (a != 64) { t = t + String.fromCharCode(i) } } t = Base64._utf8_decode(t); return t }, _utf8_encode: function (e) { e = e.replace(/\r\n/g, "\n"); var t = ""; for (var n = 0; n < e.length; n++) { var r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r) } else if (r > 127 && r < 2048) { t += String.fromCharCode(r >> 6 | 192); t += String.fromCharCode(r & 63 | 128) } else { t += String.fromCharCode(r >> 12 | 224); t += String.fromCharCode(r >> 6 & 63 | 128); t += String.fromCharCode(r & 63 | 128) } } return t }, _utf8_decode: function (e) { var t = ""; var n = 0; var r = c1 = c2 = 0; while (n < e.length) { r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r); n++ } else if (r > 191 && r < 224) { c2 = e.charCodeAt(n + 1); t += String.fromCharCode((r & 31) << 6 | c2 & 63); n += 2 } else { c2 = e.charCodeAt(n + 1); c3 = e.charCodeAt(n + 2); t += String.fromCharCode((r & 15) << 12 | (c2 & 63) << 6 | c3 & 63); n += 3 } } return t } }
    var ctrl = this;
    var md = {};
    ctrl.md = md;

    $scope.DDLLocation = "India";
    $scope.ModePayment = "";
    $scope.selectedCar = '0';


    ctrl.GetCountryList = function () {
        var SearchForm = {
            "Country": $scope.DDLLocation,
            "CurrencyCode": ""
        }
        authService.PostData("/api/GiftCard/GetCountryList", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                if (response != "No Record Found") {
                    ctrl.CountryList = response;
                    ctrl.NoReord = '';
                }
                else {

                    ctrl.NoReord = 'No Record Found';
                    ctrl.CountryList = [];
                }
            } else { }
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.GetCountryList();



    ctrl.SlotGetList = function () {
        var SearchForm = {
            "Country": $scope.DDLLocation,
            "CurrencyCode": ""
        }
        authService.PostData("/api/GiftCard/GetGiftCardList", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.Details = response;
            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();


    $scope.OnLoadgetData = function () {
        $scope.DDLLocation = "India";
        ctrl.SlotGetList();
    }
    $scope.OnLoadgetData();


    $scope.getData = function () {
        ctrl.SlotGetList();
    };

    $scope.BuyNow = function (index) {

        var SourceID = index.ID;
        var url = 'o-giftcard.aspx?Source=' + Base64.encode(SourceID);
        window.location.href = url
    }
}]);

UserAppLogin.controller('GiftCarDetial', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    $scope.Proceduesuccessfully = true;
    $scope.ConvertAmount = 0;
    function GetParameterValues(param) {
        var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < url.length; i++) {
            var urlparam = url[i].split('=');
            if (urlparam[0] == param) {
                return urlparam[1];
            }
        }
    }
    function decode_base64(s) {
        var b = l = 0, r = '',
            m = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'.split('');
        s.split('').forEach(function (v) {
            b = (b << 6) + m.indexOf(v); l += 6;
            while (l >= 8) r += String.fromCharCode((b >>> (l -= 8)) & 0xff);
        });
        return r;
    }
    var Base64 = { _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=", encode: function (e) { var t = ""; var n, r, i, s, o, u, a; var f = 0; e = Base64._utf8_encode(e); while (f < e.length) { n = e.charCodeAt(f++); r = e.charCodeAt(f++); i = e.charCodeAt(f++); s = n >> 2; o = (n & 3) << 4 | r >> 4; u = (r & 15) << 2 | i >> 6; a = i & 63; if (isNaN(r)) { u = a = 64 } else if (isNaN(i)) { a = 64 } t = t + this._keyStr.charAt(s) + this._keyStr.charAt(o) + this._keyStr.charAt(u) + this._keyStr.charAt(a) } return t }, decode: function (e) { var t = ""; var n, r, i; var s, o, u, a; var f = 0; e = e.replace(/[^A-Za-z0-9\+\/\=]/g, ""); while (f < e.length) { s = this._keyStr.indexOf(e.charAt(f++)); o = this._keyStr.indexOf(e.charAt(f++)); u = this._keyStr.indexOf(e.charAt(f++)); a = this._keyStr.indexOf(e.charAt(f++)); n = s << 2 | o >> 4; r = (o & 15) << 4 | u >> 2; i = (u & 3) << 6 | a; t = t + String.fromCharCode(n); if (u != 64) { t = t + String.fromCharCode(r) } if (a != 64) { t = t + String.fromCharCode(i) } } t = Base64._utf8_decode(t); return t }, _utf8_encode: function (e) { e = e.replace(/\r\n/g, "\n"); var t = ""; for (var n = 0; n < e.length; n++) { var r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r) } else if (r > 127 && r < 2048) { t += String.fromCharCode(r >> 6 | 192); t += String.fromCharCode(r & 63 | 128) } else { t += String.fromCharCode(r >> 12 | 224); t += String.fromCharCode(r >> 6 & 63 | 128); t += String.fromCharCode(r & 63 | 128) } } return t }, _utf8_decode: function (e) { var t = ""; var n = 0; var r = c1 = c2 = 0; while (n < e.length) { r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r); n++ } else if (r > 191 && r < 224) { c2 = e.charCodeAt(n + 1); t += String.fromCharCode((r & 31) << 6 | c2 & 63); n += 2 } else { c2 = e.charCodeAt(n + 1); c3 = e.charCodeAt(n + 2); t += String.fromCharCode((r & 15) << 12 | (c2 & 63) << 6 | c3 & 63); n += 3 } } return t } }
    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }
    var Sourceid = decode_base64(GetParameterValues('Source'));

    $scope.GetGiftDetial = function () {

        var SearchForm = {
            "GiftCardId": Sourceid,
            "CurrencyCode": ""
        }
        authService.PostData("/api/GiftCard/GetGiftCardListbyID", SearchForm).then(function (response) {
            if (response) {
                if (response != "No Record Found") {

                    $scope.Details = response[0].GiftCardAmount;
                    if (response[0].SendType == 'M') { $scope.SendTypeData = "The phone number to top up" } else { $scope.SendTypeData = "Email addres to receive Gift Card" }
                    $scope.Country = response[0].Country;
                    $scope.ProductName = response[0].ProductName;
                    $scope.Termscondition = response[0].Termscondition;
                    $scope.Description = response[0].Description;
                    $scope.Photo = response[0].Photo;
                    $scope.Curency = response[0].Curency;
                    $scope.Country = response[0].Country;
                    $scope.CrrrencyRate();
                    $scope.NoReord = '';
                }
                else {

                    $scope.NoReord = 'No Record Found';
                    $scope.Details = [];
                }
            } else { }
        });
    }


    $scope.GetGiftDetial();
    $scope.CrrrencyRate = function () {
        var url = "https://api.exchangerate-api.com/v6/latest";
        $http.get(url).then(function (response) {

            var array = response.data.rates// $scope.Curency
            var a = $scope.Curency;
            var c = array;

            $scope.rate;
            $scope.rate = c[a]
            if ($scope.rate > 1) {
                $scope.ConvertAmount = 1 / $scope.rate
                $scope.GetBlance();
            }
            else {
                $scope.ConvertAmount = 1 * $scope.rate;
                $scope.GetBlance();
            }

            //const result = array.filter(word => word.length > 6);

        });
    }



    $scope.GetBlance = function () {
        var UserID = readCookie('userId');
        var SearchForm = { Email: UserID }
        authService.PostData("/api/UserAPI/GetBlanceIncome", SearchForm).then(function (response) {
            if (response) {
                $scope.BalanceVp = response;

                $scope.ConvertBalanceVp = parseFloat($scope.BalanceVp * $scope.rate).toFixed(2)

            } else { }
        });
    }




    $scope.getData = function (TaxID) {
        if (TaxID !== '') {

            var usd = 1.00;
            console.log($scope.rate);


            if (parseFloat(usd).toFixed(2) >= parseFloat($scope.rate).toFixed(2)) {

                var Convettopay = parseFloat(usd).toFixed(2) / parseFloat($scope.rate).toFixed(2)
                $scope.ConvertBTC = parseFloat((Convettopay * TaxID) + 2).toFixed(2);
                // console.log('dollar higi', Convettopay * TaxID);
            }
            else {
                var Convettopay = parseFloat(usd).toFixed(2) / parseFloat($scope.rate).toFixed(2)
                $scope.ConvertBTC = parseFloat((Convettopay * TaxID) + 2).toFixed(2);
                //console.log('drllar below ', ll = Convettopay*TaxID);
            }


            if (parseFloat($scope.ConvertBTC) >= parseFloat($scope.BalanceVp)) {
                $scope.btnpayment = false;
                $scope.Balanceno = 'Insuficient Balance !'
            }
            else {
                $scope.btnpayment = true;
                $scope.Balanceno = ''
            }

        }
        else {
            $scope.btnpayment = false;
            $scope.Balanceno = 'Insuficient Balance !'
        }


    }

    $scope.ProceedtoCheck = function () {
        $scope.Proceederror = '';
        if ($scope.SendonMail && $scope.SendonMail.length > 0 && $scope.Skey && $scope.Skey.length > 0) {

        }
        else { demo.showNotificationError("Please Key"); }
    }


    $scope.ProceedtoPay = function () {

        $scope.MessagesOutput = "";
        var UserID = readCookie('userId');
        var SearchForm = { RegID: UserID, Amt: $scope.DDLPrice, SentID: $scope.SendonMail, SKey: $scope.Skey, RequestAmount: $scope.ConvertBTC, GiftCardId: Sourceid };
        if ($scope.SendonMail && $scope.SendonMail.length > 0 && $scope.Skey && $scope.Skey.length > 0) {
            authService.PostData("/api/GiftCard/RequestGiftOrderbyUser", SearchForm).then(function (response) {
                if (response) {

                    if (response.SeatArragement == "1") {
                        $scope.Proceduesuccessfully = false;
                        $scope.ordersuccessfully = true;

                        //Redirectpage();
                    }
                    else {

                        $scope.Proceederror = response.SeatArragement;
                        $scope.ordersuccessfully = false;
                        $scope.Proceduesuccessfully = true;
                    }



                }
            }, function (x) {
                demo.showNotificationError(x);
            });

        }
        else { demo.showNotificationError("Please Enter Upgrade User ID and  Upgrade Amount"); }
    }
}]);
UserAppLogin.controller('OrderGiftCarDetial', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    $scope.SecurityDetail = true;
    function decode_base64(s) {
        var b = l = 0, r = '',
            m = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'.split('');
        s.split('').forEach(function (v) {
            b = (b << 6) + m.indexOf(v); l += 6;
            while (l >= 8) r += String.fromCharCode((b >>> (l -= 8)) & 0xff);
        });
        return r;
    }
    var Base64 = { _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=", encode: function (e) { var t = ""; var n, r, i, s, o, u, a; var f = 0; e = Base64._utf8_encode(e); while (f < e.length) { n = e.charCodeAt(f++); r = e.charCodeAt(f++); i = e.charCodeAt(f++); s = n >> 2; o = (n & 3) << 4 | r >> 4; u = (r & 15) << 2 | i >> 6; a = i & 63; if (isNaN(r)) { u = a = 64 } else if (isNaN(i)) { a = 64 } t = t + this._keyStr.charAt(s) + this._keyStr.charAt(o) + this._keyStr.charAt(u) + this._keyStr.charAt(a) } return t }, decode: function (e) { var t = ""; var n, r, i; var s, o, u, a; var f = 0; e = e.replace(/[^A-Za-z0-9\+\/\=]/g, ""); while (f < e.length) { s = this._keyStr.indexOf(e.charAt(f++)); o = this._keyStr.indexOf(e.charAt(f++)); u = this._keyStr.indexOf(e.charAt(f++)); a = this._keyStr.indexOf(e.charAt(f++)); n = s << 2 | o >> 4; r = (o & 15) << 4 | u >> 2; i = (u & 3) << 6 | a; t = t + String.fromCharCode(n); if (u != 64) { t = t + String.fromCharCode(r) } if (a != 64) { t = t + String.fromCharCode(i) } } t = Base64._utf8_decode(t); return t }, _utf8_encode: function (e) { e = e.replace(/\r\n/g, "\n"); var t = ""; for (var n = 0; n < e.length; n++) { var r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r) } else if (r > 127 && r < 2048) { t += String.fromCharCode(r >> 6 | 192); t += String.fromCharCode(r & 63 | 128) } else { t += String.fromCharCode(r >> 12 | 224); t += String.fromCharCode(r >> 6 & 63 | 128); t += String.fromCharCode(r & 63 | 128) } } return t }, _utf8_decode: function (e) { var t = ""; var n = 0; var r = c1 = c2 = 0; while (n < e.length) { r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r); n++ } else if (r > 191 && r < 224) { c2 = e.charCodeAt(n + 1); t += String.fromCharCode((r & 31) << 6 | c2 & 63); n += 2 } else { c2 = e.charCodeAt(n + 1); c3 = e.charCodeAt(n + 2); t += String.fromCharCode((r & 15) << 12 | (c2 & 63) << 6 | c3 & 63); n += 3 } } return t } }

    $scope.DDLLocation = "India";
    $scope.ModePayment = "";
    $scope.selectedCar = '0';
    $scope.getPayment = function () {
        getGeoLoc($scope.selectedCar);

    };

    $scope.GetGiftList = function () {

        var UserID = localStorage.getItem('USERID');
        var SearchForm = {
            "UserID": UserID
        }
        authService.PostData("/api/GiftCard/OrderGiftCardUserList", SearchForm).then(function (response) {
            if (response) {
                if (response != "No Record Found") {
                    $scope.Details = response;

                    $scope.isdellist = [];
                    for (var i = 0; i < $scope.Details.length; i++) {
                        if ($scope.Details[i].Status == "Delivered") {

                            $scope.isdellist.push(false);
                        }
                        else {
                            $scope.isdellist.push(true);

                        }
                    }

                    $scope.NoReord = '';
                }
                else {

                    $scope.NoReord = 'No Record Found';
                    $scope.Details = [];
                }
            } else { }
        });
    }
    $scope.GetGiftList();


    $scope.FNView = function (index) {
        $scope.OrderID = index.orderID;
        $scope.ProductName = index.Productname;
    }
    $scope.FN_Code = function () {
        var SearchForm = {
            "Skey": $scope.Skey,
            "OrderID": $scope.OrderID
        }

        authService.PostData("/api/GiftCard/GetGiftCardCode", SearchForm).then(function (response) {
            if (response) {
                if (response.SeatArragement == "1") { $scope.GiftCode = response.Code; $scope.GiftCardDetail = true; $scope.SecurityDetail = false; }
                else { $scope.Securityerror = response.SeatArragement }

            }
        });



    }
}]);

UserAppLogin.controller('UpgradeAccount', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    authService.GetBlance();

    ctrl.myFunc = function () {
        var SearchForm = { RegID: $scope.TopID }
        authService.PostData("/api/UserAccountsApi/GetName", SearchForm).then(function (response) {
            if (response) {
                $scope.username = response;
            } else { }
        });
    }


    $scope.selectedCar = '0';
    $scope.getPayment = function () {
        getGeoLoc($scope.selectedCar);

    };




    $scope.BTCClick = function () {
        $scope.ModePayment = "CRP";
        $scope.CryptopPayment = true;
        $scope.BTCclass = "blue";
        $scope.fundclass = "red";
    }

    $scope.walletClick = function () {

        $scope.BTCclass = "red";
        $scope.fundclass = "blue";
        $scope.ModePayment = "FUND";
        $scope.CryptopPayment = false;
        if ($scope.BalanceVp >= 25) {
            $scope.PaymentClickM = true;
        }
        else { $scope.Modalwalletp = true; $scope.PaymentClickM = false; }

    }
    getGeoLoc = function (TaxID) {
        if ($scope.Amount == undefined || $scope.Amount == '') {
            window.alert("Please Enter Upgrade Amount");
        }
        else {
            if ($scope.selectedCar !== '0') {


                var SearchForm = { BTCType: TaxID }
                authService.PostData("/api/UserAppAPI/GetBTCAddminAddress", SearchForm).then(function (response) {
                    if (response) {
                        $scope.BTCAddressAddress = response;
                        $scope.Address = response;

                    } else { }
                });




            }
            else { $scope.ConvertBTC = 0 }
        }
    }
    $scope.myRate = function () {
        if ($scope.ModePayment == 'CRP') {
            if ($scope.selectedCar !== '0') {

                var SearchForm = { BTCType: $scope.selectedCar }
                authService.PostData("/api/UserAppAPI/GetBTCAddminAddress", SearchForm).then(function (response) {
                    if (response) {
                        $scope.BTCAddressAddress = response;
                        $scope.Address = response;

                    } else { }
                });
                //var url = "https://api.cryptonator.com/api/ticker/usd-" + $scope.selectedCar;
                //$http.get(url).then(function (response) {
                //    $scope.ConvertBTC = response.data.ticker.price * $scope.Amount;

                //})
                //    .error(function (data, status, headers, config) {
                //    });
            }
            else { $scope.ConvertBTC = 0 }
        }


    }
    Redirectpage = function () {
        sessionStorage.removeItem('txn_id');

        $scope.MessagesOutput = "";
        var UserID = localStorage.getItem('USERID');

        var parameters = { PayMentby: UserID, UserID: $scope.TopID, Amount: $scope.Amount, currency2: $scope.selectedCar, PaymentType: "Active" };
        var config = { params: parameters };
        setRequestHeader = "Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept";
        $http.get('https://api.XsCoinWebtrading.com/Payment/PaymentMake.asmx/MakePayment', config, setRequestHeader)
            .success(function (data, status, headers, config) {
                console.log(data.result.txn_id);
                sessionStorage.setItem('txn_id', data.result.txn_id);
                $window.location.href = 'Pay-ment.aspx';
            })


    }

    ctrl.PaymentClick = function () {
        $scope.MessagesOutput = "";
        var UserID = localStorage.getItem('USERID');
        var SearchForm = { RegID: $scope.TopID, Amt: $scope.Amount, Mode: $scope.ModePayment, modeType: $scope.selectedCar, CAmt: $scope.ConvertBTC, UserID: UserID, SKey: $scope.Skey, AddressBTC: $scope.Address };
        if ($scope.TopID && $scope.TopID.length > 0 && $scope.Amount && $scope.Amount.length && $scope.Skey && $scope.Skey.length > 0) {
            if ($scope.ModePayment == "CRP") {
                if ($scope.selectedCar !== "0") {
                    authService.PostData("/api/UserAppAPI/UpgradeUser", SearchForm).then(function (response) {
                        if (response) {
                            console.log(response.SeatArragement);
                            if (response.SeatArragement == "1") {
                                Redirectpage();

                            }
                            else { demo.showNotificationError(response.SeatArragement) }


                        }
                    }, function (x) {
                        demo.showNotificationError(x);
                    });
                }
                else { demo.showNotificationError("Please Select Payment Mode"); }
            }
            else {
                authService.PostData("/api/UserAppAPI/UpgradeUser", SearchForm).then(function (response) {
                    if (response) {
                        if (response == "1") {
                            authService.GetBlance();
                            demo.showNotificationSucess('Account Upgrade Request Succsfully');
                            $scope.TopID = $scope.Amount = $scope.ModePayment = $scope.Skey = $scope.Address = $scope.username = '';
                            $scope.selectedCar = 0
                            $scope.ConvertBTC = 0
                            $scope.fileList = [];

                        }
                        else { demo.showNotificationError(response); }
                    }
                });
            }

        }
        else { demo.showNotificationError("Please Enter Upgrade User ID and  Upgrade Amount, and Security Key"); }
    }


    $scope.fileList = [];
    $scope.curFile;
    $scope.ImageProperty = {
        file: ''
    }
    $scope.setFile = function (element) {
        $scope.fileList = [];
        var files = element.files;
        for (var i = 0; i < files.length; i++) {
            $scope.ImageProperty.file = files[i];
            $scope.fileList.push($scope.ImageProperty);
            $scope.ImageProperty = {};
            $scope.$apply();

        }
    }




    $scope.uploadFile = function (CustID) {
        var xhr = new XMLHttpRequest();
        var file = $scope.fileList[0].file
        xhr.open("POST", "/api/UserAppAPI/MyFileUpload");
        xhr.setRequestHeader("filename", file.name);
        xhr.setRequestHeader("FileID", CustID);
        xhr.send(file);

    }
}]);

UserAppLogin.controller('PaymentCtrl', ['$http', '$interval', '$scope', '$rootScope', 'authService', '$window', function ($http, $interval, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;
    authService.GetBlance();

    ctrl.ConfirmDetail = false;
    ctrl.PaymentDetail = true;
    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }



    var TransactionDetail = function () {
        ctrl.Detials = [];
        var txn_id = sessionStorage.getItem('txn_id');
        var USERID = localStorage.getItem('USERID');
        var SearchForm = { TransactionID: txn_id, UserId: USERID };
        authService.PostData("/api/UserAppAPI/GetCoinPayMentTxn", SearchForm).then(function (response) {
            if (response) {
                console.log(response[0]);
                $scope.RequestAmount = response[0].RequestAmount;
                $scope.amount = response[0].amount;
                $scope.Currency = response[0].Currency;
                $scope.Currency2 = response[0].Currency2;
                $scope.address = response[0].address;
                $scope.txn_id = response[0].txn_id;
                $scope.qrcode_url = response[0].qrcode_url;
                $scope.LeftTime = response[0].LeftTime;
                $scope.UpdateDate = response[0].UpdateDate;
                $scope.AmountFor = response[0].AmountFor;
                $scope.status = response[0].status;
                $scope.UserID = response[0].UserID;

                $scope.status_text = response[0].status_text;

                if ($scope.status == 1) {

                    $scope.ConfirmDetail = true;
                    $scope.PaymentDetail = false;
                    $scope.paymentstatus = status_text;

                }

                else {
                    $scope.ConfirmDetail = false;
                    $scope.PaymentDetail = true
                    $scope.paymentstatus = 'Pending';
                }
            } else { $window.location.href = 'Index.aspx'; }
        });
    }


    $interval(function () { TransactionDetail(); }, 1000);




}]);

UserAppLogin.controller('CtrProfile', ['$scope', '$rootScope', 'authService', '$window', function ($scope, $rootScope, authService, $window) {

    var ctrl = this;

    var md = {};
    ctrl.md = md;

    ctrl.SaveProfile = function () {
        var data = ctrl.md;
        authService.PostData("/api/UserAccountsApi/UpdateProfile", data).then(function (response) {
            if ($scope.fileList.length >= 0) {
                $scope.uploadPic(ctrl.md.Regno);
            }
            ctrl.SlotGetList();
            demo.showNotificationSucess(response);
        }, function (x) {
            $scope.errorMsg = data;
        });

    }


    $scope.fileList = [];
    $scope.curFile;
    $scope.ImageProperty = {
        file: ''
    }
    $scope.setFile = function (element) {
        $scope.fileList = [];
        var files = element.files;
        for (var i = 0; i < files.length; i++) {
            $scope.ImageProperty.file = files[i];
            $scope.fileList.push($scope.ImageProperty);
            $scope.ImageProperty = {};
            $scope.$apply();

        }
    }


    $scope.uploadPic = function (CustID) {
        var xhr = new XMLHttpRequest();
        var file = $scope.fileList[0].file
        xhr.open("POST", "/api/UserAppAPI/UploadPic");
        xhr.setRequestHeader("filename", file.name);
        xhr.setRequestHeader("FileID", CustID);
        xhr.send(file);

    }

    ctrl.SlotGetList = function () {

        var ID = localStorage.getItem('USERID')
        var SearchForm = { UserID: ID }
        authService.PostData("/API/ReportUserAPI/GetUserInformation", SearchForm).then(function (response) {
            if (response) {
                console.log(response);
                ctrl.md.Regno = response[0].AppMstRegNo;
                ctrl.md.Email = response[0].Email;
                ctrl.md.Number = response[0].Number;
                ctrl.md.Country = response[0].Country;
                ctrl.md.zipCode = response[0].zipCode;
                ctrl.md.BTC = response[0].BTC;
                ctrl.md.AppmstFName = response[0].AppmstFName;
                ctrl.md.AppMstRegNo = response[0].AppMstRegNo;
                ctrl.md.sponsorid = response[0].sponsorid;

                if (response[0].Type == "1") {
                    $scope.MessagesType = "To update profile please contact support@XsCoinWebtrading.com";
                    ctrl.Buttonshow = false;
                }
                else { ctrl.Buttonshow = true; $scope.MessagesType = ""; }

            }
            else
                ctrl.Details = [];
        }, function (x) {
            console.log(x)
            x.Message;
        });
    }
    ctrl.SlotGetList();



}]);






