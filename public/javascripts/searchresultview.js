define(['jquery'], function ($) {
    return {
        "attachEvents": function () {
            $('[name="package"]').click(function () {
                var uuid = this.getAttribute('uuid');
                var div = $('#packageFiles_' + uuid)
                div.toggle();
            });

            $('[name="gotopage"]').click(function () {
                var page = this.getAttribute('page');
                require(["cart"], function (c) {
                    c.callSearch(page);
                });
            });
        },

        "attachPagerEvents": function () {
            var pageLinks = $('#searchResults [class="pagination-container"] li a');

            pageLinks.each(function () {
                $(this).attr('page', $(this).attr('href'));
                $(this).attr('href', '#');
            });
            pageLinks.click(function () {
                var page = this.getAttribute('page');
                require(["cart"], function (c) {
                    c.callSearch(page);
                });
            });
        }
    };
});