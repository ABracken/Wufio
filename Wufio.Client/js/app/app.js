angular.module('clientApp', ['ui.router', 'ngResource', 'LocalStorageModule']).config(function ($httpProvider, $stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/login');

    $stateProvider
        .state('login', { url: '/login', templateUrl: '/templates/auth/login/login.html', controller: 'LoginController' })
        .state('register', { url: '/register', templateUrl: '/templates/auth/register/register.html', controller: 'RegisterController' })

        .state('app', { url: '/app', templateUrl: '/templates/app/app.html', controller: 'AppController', authenticate: true })
            .state('app.home', { url: '/home', templateUrl: '/templates/app/home/home.html', controller: 'HomeController', authenticate: true })
            .state('app.settings', { url: '/settings:id', templateUrl: '/templates/app/settings/settings.html', controller: 'SettingsController', authenticate:true})
});

angular.module('clientApp').value('apiUrl', 'http://localhost:3400/api/')
angular.module('clientApp').value('serviceBase', 'http://localhost:3400/');

angular.module('clientApp').run(function ($rootScope, authService, $state) {
    authService.fillAuthData();

    $rootScope.$on("$stateChangeStart", function (event, toState, toParams, fromState, fromParams) {
        if (toState.authenticate && !authService.authentication.isAuth) {
            $state.go('login');
            event.preventDefault();
        }
    });
});

angular.module('clientApp').config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});