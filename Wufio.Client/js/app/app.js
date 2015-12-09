angular.module('clientApp', ['ui.router', 'ngResource', 'LocalStorageModule']).config(function ($httpProvider, $stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/login');

    $stateProvider
        .state('login', { url: '/login', templateUrl: '/templates/auth/login/login.html', controller: 'LoginController' })
        .state('register', { url: '/register', templateUrl: '/templates/auth/register.html', controller: 'RegisterController' })

        .state('app', { url: '/app', templateUrl: '/templates/app/app.html', authenticate: true })

        .state('app.home', { abstract: true, url: '/home', template: '<ui-view/>', authenticate: true })
            .state('app.home.view', { url: '/view', templateUrl: '/templates/app/home/home.html', controller: 'HomeController', authenticate: true });
});

angular.module('clientApp').value('apiUrl', 'http://localhost:60414/api/')
angular.module('clientApp').value('serviceBase', 'http://localhost:60414/');

angular.module('clientApp').run(function ($rootScope, authService, $state) {
    authService.fillAuthData();


});