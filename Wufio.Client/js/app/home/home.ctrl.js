angular.module("clientApp").controller("HomeController", function ($scope) {

    $scope.likeAnimal = function(animal) {
        $scope.data.favoriteAnimals.push(animal);
        animal.liked = true;
    };

    $scope.unlikeAnimal = function(animal) {
        $scope.data.favoriteAnimals.splice($scope.data.favoriteAnimals.indexOf(animal), 1);
        animal.liked = false;
    }

    $scope.data = {
        favoriteAnimals: [],
        allAnimals: [
            {
                image: "../../../img/o-ASHAMED-DOG-facebook_edited.jpg",
                name: "Steve",
                age: "1-2 years",
                gender: true,
                about: "Steve loves a nice walk in the park but not as much as a good tail chase, dislikes cats",
                liked: false
            },
            {
                image: "../../../img/339432-dogs-music-dog.jpg",
                name: "Payden",
                age: "Under 1 year",
                gender: false,
                about: "Likes kids and other animals as long as she has her jams, potty trained",
                liked: false
            },
            {
                image: "../../../img/72329aba84cd96e749e904b19b0b1f14.jpg",
                name: "Chewie and Han",
                age: "Under 1 year",
                gender: true,
                about: "Chewie and Han are a bonded pair, must be adopted together",
                liked: false
            },
            {
                image: "../../../img/canaan-dog.jpg",
                name: "Dylan",
                age: "1-2 years",
                gender: true,
                about: "Skiddish of kids, likes other dogs, a lot. High energy just loves life",
                liked: false
            },
            {
                image: "../../../img/dog-breed-selector-australian-shepherd.jpg",
                name: "Bella",
                age: "5-6 years",
                gender: false,
                about: "Better as the only animal, high energy and very smart, likes kids, aggressive towards cats",
                liked: false
            }
        ]
    };
});