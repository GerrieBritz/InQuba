var EmailApp = angular.module('EmailApp', []);

EmailApp.controller('emailController', ['$scope','$http','$filter', function($scope,$http,$filter) {

    $scope.username = 'Gerhard';

    $http.get('/api/Mail')
         .then(function (data) {
             $scope.emails = data.data.Data;
             console.log(data.data.Data);
         }, function myError(response) {
             $scope.error = response.statusText;
         });

    $scope.locationName = 'Inbox';

    $http.get('/api/MailCount/' + $scope.locationName)
         .then(function (data) {
             $scope.InboxCount = data.data.Data;
             console.log(data.data.Data);
         }, function myError(response) {
             $scope.error = response.statusText;
         });

    //$http.get('/api/Mail')
    //    .filter('LocationId', function () {
    //        var arr = [];
    //        angular.forEach(data, function (v) {
    //            if (v.LocationNameLocationId === ) {
    //                arr.push(v);
    //            }
    //        })

    //        return arr;
    //    })

        
}]);

