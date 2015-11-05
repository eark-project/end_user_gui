/**
 * Created by Beemen on 05/11/2015.
 */
// Configuration file
// ------------------
require.config({

    // Sets the js folder as the base directory for all futurerelative paths
    //baseUrl: "javascripts",

    // 3rd party script alias names
    "paths": {

        // Core Libraries
        // --------------

        // jQuery
        "jquery": "libs/jquery-1.11.1/jquery-1.11.1.min",

        // Plugins
        // -------

        // Twitter Bootstrap jQuery plugins
        "bootstrap": "libs/bootstrap-3.3.1-dist/dist/js/bootstrap.min",

        "jqueryui": "libs/jquery-ui-1.11.2.custom/jquery-ui",

        // Application Files
        // -----------------
        "cart": "cart",
        "init": "init"

    },

    // Sets the configuration for your scripts that are notAMD compatible
    shim: {

        // Twitter Bootstrap jQuery plugins depend on jQuery
        "bootstrap": ["jquery"],
        "jqueryui": ["jquery"],
    }
});

require(
    // Execute the logic in init module
    ["init"]
);