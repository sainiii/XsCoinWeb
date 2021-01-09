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
    ctrl.md.country = 'Select';
    ctrl.loderscreen = false;
    ctrl.ShowOTPPanel = false;
    ctrl.ShowDataPanel = true;
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

        if (ctrl.md.Password !== ctrl.md.CPassword) { demo.showNotificationError('Confirm Password have to match!'); return; }
    }



    ctrl.SaveOTP = function (form) {

        if (ctrl.md.Password !== ctrl.md.CPassword) { demo.showNotificationError('Confirm Password have to match!'); return; }


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

        if (ctrl.md.country == 'Select') {
            demo.showNotificationError('Please Select  Country');
            return;

        }

        if (ctrl.md.CPassword == undefined) {
            demo.showNotificationError('Please Enter Confirm Password');
            return;

        }

        ctrl.loderscreen = true;
        $scope.MessagesOutput = "";
        var SearchForm = { Email: ctrl.md.Email, OTPType: "registration" };
        authService.PostData("/API/UserAPI/CreateOTPRegistraion", SearchForm).then(function (response) {
            if (response) {
                if (response !== '') {
                    ctrl.md.OTPhidden = response;
                    ctrl.ShowDataPanel = false;
                    ctrl.ShowOTPPanel = true;
                    ctrl.loderscreen = true;
                }
                else { }
            }


        });

    }


    ctrl.Save = function (form) {

        ctrl.loderscreen = true;
        var data = ctrl.md;
        localStorage.setItem('data', ctrl.md);
        authService.PostData("api/UserAccountsApi/Register", data).then(function (response) {
            console.log(response);
            if (response === "otp expire") {
                $scope.seccessMsg = "Please Enter Vaild OTP"
                demo.showNotificationError('Please Enter Vaild OTP');

            }
            else {


                sessionStorage.setItem("UserData", response);
                ctrl.ThankUser = true;
                ctrl.ShowOTPPanel = false;
                ctrl.regno = response.RegNO
                ctrl.pwd = response.Password

            }
            // $window.location.href = 'register-done.htm';
        }, function (x) {
            ctrl.loderscreen = false;
            $scope.errorMsg = data;
        });


    }




}]);





app.controller('CtrThanks', ['$http', '$scope', '$rootScope', 'authService', '$window', function ($http, $scope, $rootScope, authService, $window) {
    var ctrl = this;
    var md = {};
    ctrl.md = md;

    var UserId = localStorage.getItem('SessionID')
    console.log();

    if (UserId == null) {
        $window.location.href = 'register.html';
    }

    ctrl.Details = UserId;
    localStorage.removeItem('SessionID');
    //ctrl.SlotGetList = function () {
    //    var SearchForm = { UserID: UserId }
    //    authService.PostData("/API/ReportUserAPI/GetUserInformation", SearchForm).then(function (response) {
    //        if (response) {


    //        }
    //        else
    //            ctrl.Details = [];
    //    }, function (x) {
    //        console.log(x)
    //        x.Message;
    //    });
    //}
    //ctrl.SlotGetList();
}]);

