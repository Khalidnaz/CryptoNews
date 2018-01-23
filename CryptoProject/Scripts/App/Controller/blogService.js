(function () {

    'use strict';

    angular.module(CryptoProject).factory("BlogService", BlogService);
    BlogService.$inject = ["$http", "$q"];

    function BlogService($http, $q) {
        var srv = {
           
            ScrapeArticle: _scrapeArticle
         

        }
        return srv;


        function _scrapeArticle() {
            return $http.post("/api/blog/articles/")
                .then(function (response) {
                    console.log("article service.js check");
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                    console.log("article service error");
                });

        }

       
    }

})();