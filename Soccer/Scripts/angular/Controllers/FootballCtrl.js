function FootballCtrl($scope, $http) {
    $scope.teams = [];
    $scope.smallestDeficit = [];

    // Fetch the teams from the web api method
    $http.get('/teams')
        .success(function (data, status) {
            $scope.teams = data.Teams;
            $scope.smallestDeficit = data.Smallest;
        })
        .error(function (data, status) {
            alert('Error occured')
        })

    // Iitialise with test data
    $scope.new = { Name: 'Test', For: 15, Against: 4 };
    $scope.addTeam = function () {
        team = {
            Name: $scope.new.Name,
            Played: 0,
            Won: 0,
            Lost: 0,
            Draw: 0,
            Goals: $scope.new.For,
            Against: $scope.new.Against,        
            Points: 0,
            SmallestDiff: 0
        }
        console.log("Team =", team);
        $http({
            method: 'POST',
            url: '/api/team',
            data: JSON.stringify(team),
            headers: { 'Content-Type': 'application/json' }
        }).success( function (data) {
            alert('Success', data)
        })
    }
}

FootballCtrl.$inject = ['$scope', '$http'];