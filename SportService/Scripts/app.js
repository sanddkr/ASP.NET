var ViewModel = function () {
    var self = this;
    self.athletes = ko.observableArray();
    self.teams = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    var teamsUri = '/api/teams/';
    var athletesUri = '/api/athletes/';
    var athletesByTeamUri = '/api/athletes?team=';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllAthletes() {
        ajaxHelper(athletesUri, 'GET').done(function (data) {
            self.athletes(data);
        });
    }

    self.getAthleteDetail = function (item) {
        ajaxHelper(athletesUri + item.student_number, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    function getTeams() {
        ajaxHelper(teamsUri, 'GET').done(function (data) {
            self.teams(data);
        });
    }

    self.getTeamAthletes = function (item) {
        ajaxHelper(athletesByTeamUri + item.type_of_sport, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    getAllAthletes();
    getTeams();
};

ko.applyBindings(new ViewModel());