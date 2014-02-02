function FootballCtrl($scope, $http) {
    $scope.teams = [];
    $scope.smallestDeficit = [];

    // Fetch the teams from the web api method
    $http.get('/teams')
    .success(function (data, status) {
        $scope.teams = data.Teams;

        
        $scope.smallestDeficit = data.Smallest;
        console.log('Data = ', data, status)
    })
    .error(function (data, status) {
        alert('Error occured')
    })
}

FootballCtrl.$inject = ['$scope', '$http'];