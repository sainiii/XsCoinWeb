var app = angular.module('MyApp', []);

app.factory('authService', ['$http', '$rootScope', '$timeout', '$window',
    function ($http, $rootScope, $timeout, $window) {
        var service = {};
        service.LoginForget = function (username, callback, ErrorCallback) {
            $http.post('/api/UserAccountsApi/ForgetPassword', { LoginID: username })
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


        return service;
    }])






app.controller('ForgetPasswordController', ['$scope', '$rootScope', 'authService', '$window', function ($scope, $rootScope, authService, $window) {



    $scope.LoginForget = function () {
        if ($scope.UserID && $scope.UserID.length > 0) {
            authService.LoginForget($scope.UserID,
                function (data, status, headers, config) {
                    if (status == 200) {
                        $scope.seccessMsg = " Yor login details sent to your " + data.USERID  ;
                        $scope.errorMsg = "";
                    }
                },
                function (data, status, headers, config) {

                    if (status == config) {
                        $scope.errorMsg = "Invalid Account ID";
                        $scope.seccessMsg = "";
                    }
                    else {
                        if (data instanceof Object) {
                            $scope.errorMsg = "Invalid Account ID";
                            $scope.seccessMsg = "";
                        }
                        else
                        {
                            $scope.errorMsg = "Invalid Account ID";
                            $scope.seccessMsg = "";
                        }
                    }

                });
        } else {
            $scope.errorMsg = "Please enter userid ";
            $scope.seccessMsg = "";
          


        }
    }



}]);