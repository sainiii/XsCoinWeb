var appnew = angular.module("appModule", []);
appnew.directive('ngFileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.ngFileModel);
            var isMultiple = attrs.multiple;
            var modelSetter = model.assign;
            element.bind('change', function () {
                var values = [];
                angular.forEach(element[0].files, function (item) {
                    var value = {
                        // File Name 
                        name: item.name,
                        //File Size 
                        size: item.size,
                        type: item.type,
                        url: URL.createObjectURL(item),
                        _file: item
                    };
                    values.push(value);
                });
                scope.$apply(function () {
                    if (isMultiple) {
                        modelSetter(scope, values);
                    } else {
                        modelSetter(scope, values[0]);
                    }
                });
            });
        }
    };
}]);




appnew.factory('authService', function ($http, $rootScope, $q, $timeout, $window) {
    var service = {};

    service.GetData = function (url, data) {
        var deferred = $q.defer();
        $http({ method: 'GET', url: url, params: data })
            .success(deferred.resolve)
            .error(deferred.reject);
        return deferred.promise;
    };
    service.PostData = function (url, data) {
        var deferred = $q.defer();
        $http({ method: 'POST', url: url, data: data })
            .success(deferred.resolve)
            .error(deferred.reject);
        return deferred.promise;
    };
    return service;
})



appnew.controller("clockCtrl", function ($scope, $http, $interval, $window, authService) {

    $scope.GetBlance = function () {
        var SearchForm = { Email: "1" }
        authService.PostData("/api/WithdrawFund/GetBlanceVPIncome", SearchForm).then(function (response) {
            if (response) {
                $scope.BalanceVp = response;
            } else { }
        });
    }
    $scope.GetBlance();
    $scope.myRate = function () {
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
        var url = "https://api.cryptonator.com/api/ticker/usd-BTC";
        $http.get(url).then(function (response) {
            var Amount = $scope.Amount * 10 / 100
            var AdminCharge = $scope.Amount - Amount
            var btcc = response.data.ticker.price * AdminCharge;
            $scope.AmountTotal = '10% admin charges you will get $ ' + AdminCharge + ' (' + btcc + ' BTC)';
            $scope.BTCAMount = btcc;
        })
       .error(function (data, status, headers, config) {
       });


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

    var UserID = readCookie('userId');
    $scope.myFunc = function () {
        var SearchForm = { UserID: UserID }
        authService.PostData("/api/WithdrawFund/GetBTCAddress", SearchForm).then(function (response) {
            if (response) {
                $scope.txtbtc = response;
            } else { }
        });
    }

    $scope.myFunc();




    $scope.PaymentClick = function () {
        $scope.MessagesOutput = "";
        var UserID = readCookie('userId');
        var SearchForm = { Amount: $scope.Amount, txtbtc: $scope.txtbtc, BTCAMount: $scope.BTCAMount, SKey: $scope.Skey, UserID: UserID };
        if ($scope.Amount && $scope.Amount.length > 0 && $scope.txtbtc && $scope.txtbtc.length > 0) {
            authService.PostData("/api/WithdrawFund/FundWithDraw", SearchForm).then(function (response) {
                if (response) {
                    if (response == '1') {
                        demo.showNotificationSucess('Account Upgrade Request Succsfully');
                        $scope.GetBlance();
                    }
                    else { demo.showNotificationError(response) }
                }
                $scope.txtRegNo = $scope.Amount = $scope.Skey = '';
                $scope.selectedCar = 0
                $scope.ConvertBTC = 0

            });
        }

        else { demo.showNotificationError("Please Enter Amount and Security Key"); }
    }






});



appnew.controller("FundTrasfar", function ($scope, $http, $interval, $window, authService) {



    $scope.GetBlance = function () {
        var SearchForm = { Email: "1" }
        authService.PostData("/api/UserAPI/GetBlanceVPIncome", SearchForm).then(function (response) {
            if (response) {
                $scope.BalanceVp = response;
            } else { }
        });
    }
    $scope.GetBlance();
    $scope.myRate = function () {
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

    var UserID = readCookie('userId');
    $scope.GetName = function () {
        var SearchForm = { RegID: $scope.txtRegNo }
        authService.PostData("/api/AccountTopAPI/GetName", SearchForm).then(function (response) {
            if (response) {
                $scope.username = response;
            } else { }
        });
    }

    $scope.PaymentClick = function () {
        $scope.MessagesOutput = "";
        var UserID = readCookie('userId');
        var SearchForm = { Amount: $scope.Amount, PregNo: $scope.txtRegNo, SKey: $scope.Skey, UserID: UserID };
        if ($scope.Amount && $scope.Amount.length > 0 && $scope.txtRegNo && $scope.txtRegNo.length > 0) {
            authService.PostData("/api/AccountTopAPI/Fundtrasfer", SearchForm).then(function (response) {
                if (response) {
                    if (response == '1') {
                        demo.showNotificationSucess('Fund Transfer Succsfully');
                        $scope.GetBlance();
                        $scope.txtRegNo = $scope.Amount = $scope.Skey = $scope.username = '';
                        $scope.selectedCar = 0
                        $scope.ConvertBTC = 0
                    }
                    else { demo.showNotificationError(response) }
                }


            });
        }

        else { demo.showNotificationError("Please Enter Amount and Security Key"); }
    }






});



