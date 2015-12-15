angular.module('clientApp').controller('HomeController', function ($scope) {
    $('.like').click(function () {
        $(this).toggleClass('active');
    });
});