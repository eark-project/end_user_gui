define(['jquery'], function ($) {
    return {
        "attachEvents": function () {
            var divs = $('[name="package"]');
            $('[name="package"]').click(function () {
                var uuid = this.getAttribute('uuid');
                var div = $('#packageFiles_' + uuid)
                div.toggle();
            });
        }
    };
});