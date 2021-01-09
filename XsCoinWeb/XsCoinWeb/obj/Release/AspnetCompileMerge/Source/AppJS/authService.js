var app = angular.module('MyApp', []);

app.factory('authService', ['$http', '$rootScope', '$timeout', '$window',
    function ($http, $rootScope, $timeout, $window) {
        var service = {};
        service.Login = function (username, password, callback, ErrorCallback) {
            $http.post('/api/UserAccountsApi/LoginUserWeb', { LoginID: username, Password: password })
                .success(function (data, status, headers, config) {
                    console.log(data[0].UserID)
                    if (data && data[0].UserID > 0) {
                        localStorage.setItem('USERID', data[0].AppMstRegNo);
                        localStorage.setItem('AccessToken', data[0].AccessToken);
                        localStorage.setItem('User', JSON.stringify(data[0]));
                        callback(data, status, headers, config);
                        $window.location.href = 'secaue/index.aspx';
                    } else {
                        ErrorCallback(data, status, headers, config);
                    }
                })
                .error(function (data, status, headers, config) {
                    console.log(status)
                    ErrorCallback(data, status, headers, config);
                });
        };


        service.getUserData = function () {
            return JSON.parse(localStorage.getItem('User'));
        };


        service.USERIDFN = function () {
            return localStorage.getItem('USERID');
        };


        return service;
    }])






app.controller('LoginController', ['$scope', '$rootScope', 'authService', '$window', function ($scope, $rootScope, authService, $window) {

    var Userid
    var user = authService.USERIDFN();
    if (user) {
        //  $window.location.href = 'secaue/index.aspx'; return
    }


    $scope.Login = function () {
        $scope.loading = true; // start loading

       
        if ($scope.UserID && $scope.UserID.length > 0 && $scope.password && $scope.password.length > 0) {
            authService.Login($scope.UserID, $scope.password,
                function (data, status, headers, config) {
                    if (status == 200) {
                        $scope.errorMsg = "Please wait..., Redirect to Home";
                        $scope.loading = false;
                    }
                },
                function (data, status, headers, config) {

                    if (status == config)
                        demo.showNotificationError("Account ID or Password Not Matched");

                    else {
                        if (data instanceof Object)
                            demo.showNotificationError("Account ID or Password Not Matched");
                        else
                            demo.showNotificationError("Account ID or Password Not Matched");

                    }

                });
        } else {
            demo.showNotificationError("Please Enter User ID and Password");
            $scope.loading = false;

        }
    }
    $scope.loading = false;


}]);