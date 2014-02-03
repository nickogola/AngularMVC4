app.controller('FootballCtrl', function ($scope, $http) {
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
            For: $scope.new.For,
            Against: $scope.new.Against,        
        }
        //team = { num: 0, name: 'Dylan' };
        console.log("Team =", team);
        $http.post('/teams/new', team).success(function (data) {
            console.log('Success', data);
        })
    }
})