(function () {
    'use strict';


    angular.module(CryptoProject).controller("blogController", BlogController);
    BlogController.$inject = ["$scope", "BlogService", "$sce", "$timeout"];

    function BlogController($scope, BlogService, $sce, $timeout) {

        var vm = this;
        vm.$onInit = _init;
        vm.articleModel = {};
        vm.prices = {};
    
        function _init() {

           
            BlogService.ScrapeArticle()

                .then(function (data) {
                
                    vm.articleModel = data;
               
                    
                    //console.log("testing scrape", vm.articleModel);


                    for (var i = 0; i < data.length; i++) {
                        vm.articleModel[i] = $sce.trustAsHtml(data[i]);
                    }

                })
                .catch(function (err) {
                    console.log("err", err);
                });


            BlogService.GetPrices()
                .then(function (data) {
                    var array = JSON.parse(JSON.stringify(data || null));
                    vm.prices = array;
                    console.log(vm.prices);
                })
                .catch(function (data) {
                    console.log(data);
                });

            setInterval(function () {
                vm.$onInit();
            }, 60000)
     
        }

    }

})();