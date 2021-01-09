


UserAppLogin.factory('authService', ['$http', '$q', '$rootScope', '$timeout', '$window', '$interval',
    function ($http, $q, $rootScope, $timeout, $window, $interval) {
        var service = {};

        service.USERIDFN = function () {
            return localStorage.getItem('USERID');
        };
        service.getUserData = function () {
            return JSON.parse(localStorage.getItem('User'));
        };
        service.GetBlance = function () {
            var SearchForm = { UserID: localStorage.getItem('USERID') }

            $http.post("/api/ReportUserAPI/GetBlanceVPIncome", SearchForm).then(function (response) {
                if (response) {
                    $rootScope.VpBallance = response.data;

                } else { }
            }, function (x) {
                console.log(x)
                x.Message;
            });

        }


        $rootScope.UserData = JSON.parse(localStorage.getItem('User'));



        if ($rootScope.UserData) { } else { $window.location.href = '../login.html'; }




        service.GetData = function (url, data) {
            var deferred = $q.defer();
            $http.defaults.headers.common['Authorization'] = localStorage.getItem('AccessToken');
            $http({ method: 'GET', url: url, params: data })
                .success(deferred.resolve)
                .error(deferred.reject);

            return deferred.promise;
        };
        service.PostData = function (url, data) {
            var deferred = $q.defer();
            $http.defaults.headers.common['Authorization'] = localStorage.getItem('AccessToken')
            $http({ method: 'POST', url: url, data: data })
                .success(deferred.resolve)
                .error(deferred.reject);

            return deferred.promise;
        };

        return service;
    }])



UserAppLogin.controller('UserController', ['$scope', '$rootScope', 'authService', '$window', function ($scope, $rootScope, authService, $window) {

    $scope.Logout = function () {
        console.log('logout')
        localStorage.removeItem('USERID');
        localStorage.removeItem('AccessToken');
        localStorage.removeItem('User');
        sessionStorage.clear();
        $window.location.href = '../login.html';

    };





}]);