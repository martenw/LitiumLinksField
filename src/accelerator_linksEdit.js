app.controller("accelerator_linksEdit",
    [
        "$scope", "$resource",
        function($scope, $resource) {
            "use strict";

            // Id for the current product is avalialbe in parent scope on model.
            // iterate parents until the id or systemid is found.
            function getParentModelIdRecursive(s) {
                // for Products id can be found on model
                if (s && s.model && s.model.id && s.model.id.length > 0)
                    return s.model.id;
                // For Categories systemid can be found on model
                if (s && s.model && s.model.systemId && s.model.systemId.length > 0)
                    return s.model.systemId;

                if (s.$parent)
                    return getParentModelIdRecursive(s.$parent);
                return null;
            }

            var id = getParentModelIdRecursive($scope);

            var service = $resource("/site/administration/api/urlinfo?id=" + id);
            service.query().$promise.then(function(response) {
                $scope.urls = response;
            });
        }
    ]
);