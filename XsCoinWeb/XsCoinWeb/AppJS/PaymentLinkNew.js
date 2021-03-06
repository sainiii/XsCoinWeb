﻿var appnew = angular.module("appModule", ['ui.bootstrap.modal', ]);
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

    $scope.selectedCar = '0';
    $scope.getPayment = function () {
        getGeoLoc($scope.selectedCar);

    };



    $scope.GetBlance = function () {
        var SearchForm = { Email: "1" }
        authService.PostData("/api/UserAPI/GetBlanceIncome", SearchForm).then(function (response) {
            if (response) {
                $scope.BalanceVp = response;
            } else { }
        });
    }

    $scope.GetBlance();


    getGeoLoc = function (TaxID) {
        var url = "https://api.cryptonator.com/api/ticker/usd-" + TaxID;
        $http.get(url).then(function (response) {
            $scope.ConvertBTC = response.data.ticker.price * $scope.Amount;

        })
       .error(function (data, status, headers, config) {

       });
    }





    $scope.myRate = function () {
        if ($scope.ModePayment == 'CRP') {
            var url = "https://api.cryptonator.com/api/ticker/usd-" + $scope.selectedCar;
            $http.get(url).then(function (response) {
                $scope.ConvertBTC = response.data.ticker.price * $scope.Amount;
            })
           .error(function (data, status, headers, config) {
           });
        }
    }


    $scope.myFunc = function () {
        var SearchForm = { RegID: $scope.txtRegNo }
        authService.PostData("/api/UserAPI/GetName", SearchForm).then(function (response) {
            if (response) {
                $scope.username = response;
            } else { }
        });
    }


    $scope.PaymentClickM = true;
    $scope.CryptopPayment = false;

    $scope.BTCClick = function () {
        $scope.ModePayment = "CRP";
        $scope.CryptopPayment = true;

    }

    $scope.walletClick = function () {
        $scope.ModePayment = "FUND";
        $scope.CryptopPayment = false;
        if ($scope.BalanceVp >= 25) {
            $scope.PaymentClickM = true;
        }
        else { $scope.Modalwalletp = true; $scope.PaymentClickM = false; }

    }

    var updateClock = function () {
        var parameters = { keyword: $scope.keyword, typess: "Game15" };
        var config = { params: parameters };
        $http.get('/Home/CheckGiveHelp', config)
        .success(function (data, status, headers, config) {


            if (data != 0) {
                $scope.gridOptions = data
                $scope.isdellist = [];
                for (var i = 0; i < $scope.gridOptions.length; i++) {
                    if ($scope.gridOptions[i].Remarks == "") {

                        $scope.isdellist.push(false);
                    }
                    else {
                        $scope.isdellist.push(true);
                    }
                }
            }
            else { $scope.gridOptions = [] }

        })





    }


  

    $scope.PaymentClick = function () {
        $scope.MessagesOutput = "";
        var SearchForm = { RegID: $scope.txtRegNo, Amt: $scope.Amount, Mode: $scope.ModePayment, modeType: $scope.selectedCar, CAmt: $scope.ConvertBTC };
        if ($window.confirm("Are Sure  Top ID?")) {
            authService.PostData("/api/UserAPI/Rechargeuser", SearchForm).then(function (response) {
                if (response) {
                  
                    if ($scope.ModePayment=="CRP")
                    { $scope.uploadFile(response.OutID); }
                    $scope.MessagesOutput = response.OutMsg;

                } else { }
            });
        }
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
        xhr.open("POST", "../api/UserAPI/MyFileUpload");
        xhr.setRequestHeader("filename", file.name);
        xhr.setRequestHeader("FileID", CustID);
        xhr.send(file);
        $scope.showModalnew = false;
    }


});



