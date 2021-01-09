var app = angular.module('MyApp', []);

app.factory('authService', ['$http', '$rootScope', '$q', '$timeout', '$window',
    function ($http, $rootScope, $q, $timeout, $window) {
        var service = {};
        service.LoginForget = function (username, callback, ErrorCallback) {
            $http.post('api/UserAccountsApi/Register', { LoginID: username })
                .success(function (data, status, headers, config) {
                    console.log(data)
                    if (data.USERID !== "0") {

                        callback(data, status, headers, config);
                    } else {
                        ErrorCallback(data, status, headers, config);
                    }
                })
                .error(function (data, status, headers, config) {
                    console.log(status)
                    ErrorCallback(data, status, headers, config);
                });
        };

        service.USERIDFN = function () {
            return localStorage.getItem('USERID');
        };


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
    }])






app.controller('CtrRegister', ['$scope', '$rootScope', 'authService', '$window', function ($scope, $rootScope, authService, $window) {

    var ctrl = this;

    var md = {};
    ctrl.md = md;


    ctrl.myFunc = function () {


        var SearchForm = { RegID: ctrl.md.SponsorID }
        authService.PostData("/api/UserAccountsApi/GetName", SearchForm).then(function (response) {
            if (response) {
                if (response !== 'NOT EXIST !') {
                    $scope.username = response;
                    $scope.FailUser = '';
                }
                else { $scope.FailUser = 'User Does not exit'; $scope.username = ''; }
            } else { $scope.FailUser = 'User Does not exit'; $scope.username = ''; }
        });

    }
    ctrl.md.Position = "Select Position";
    ctrl.mypassword = function () {

        if (ctrl.md.Password !== ctrl.md.CPassword) { demo.showNotificationwarning('Confirm Password have to match!'); return; }
    }
    ctrl.Save = function (form) {


        if (ctrl.md.Position == "Select Position") {
            demo.showNotificationError('Please Select Position');
            return;
        }
        if (ctrl.md.Name == undefined) {
            demo.showNotificationError('Please Enter Name');
            return;
        }




        if (ctrl.md.Email == undefined) {
            demo.showNotificationError('Please Enter Email');
            return;
        }

        if (ctrl.md.Password == undefined) {
            demo.showNotificationError('Please Enter Password');
            return;

        }

        if (ctrl.md.CPassword == undefined) {
            demo.showNotificationError('Please Enter Confirm Password');
            return;

        }

        if (ctrl.md.SKey == undefined) {
            demo.showNotificationError('Please Enter Security Key');
            return;

        }
        if (ctrl.md.Password == ctrl.md.CPassword) {
            var data = ctrl.md;
            authService.PostData("api/UserAccountsApi/Register", data).then(function (response) {

                $scope.seccessMsg = " Yor login details sent to your " + response;
                localStorage.setItem('SessionID', response);
                $window.location.href = 'register-done.htm';
            }, function (x) {
                $scope.errorMsg = data;
            });

        }
        else { demo.showNotificationError('Confirm Password have to match!'); }
    }




}]);





app.controller('CtrThanks', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;

    var UserId = localStorage.getItem('SessionID')

    if (UserId == null) {
        $window.location.href = 'register.html';
    }
    ctrl.SlotGetList = function () {
        var SearchForm = { UserID: UserId }
        authService.PostData("/API/ReportUserAPI/GetUserInformation", SearchForm).then(function (response) {
            if (response) {

                ctrl.Details = response;
                localStorage.removeItem('SessionID');
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

