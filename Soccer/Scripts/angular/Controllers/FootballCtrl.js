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

    $scope.addTeam = function () {
        console.log("Team =", $scope.new.teamName)
        $http.post('/team/add', {
            teamName: $scope.new.teamName,
            goalsFor: $scope.new.goalsFor,
            goalsAgainst: $scope.new.goalsAgainst
        });
    }
}

FootballCtrl.$inject = ['$scope', '$http'];