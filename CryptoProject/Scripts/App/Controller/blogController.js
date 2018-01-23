(function () {
    'use strict';


    angular.module(CryptoProject).controller("blogController", BlogController);
    BlogController.$inject = ["$scope", "BlogService", "$sce"];

    function BlogController($scope, BlogService, $sce) {

        var vm = this;
        vm.$onInit = _init;
        vm.articleModel = {};
 

        function _init() {
           
            BlogService.ScrapeArticle()

                .then(function (data) {
                
                    vm.articleModel = data;
               
                    
                    console.log("testing scrape", vm.articleModel);


                    for (var i = 0; i < data.length; i++) {
                        vm.articleModel[i] = $sce.trustAsHtml(data[i]);
                    }

                })
                .catch(function (err) {
                    console.log("err", err);
                });

        }

    }

})();