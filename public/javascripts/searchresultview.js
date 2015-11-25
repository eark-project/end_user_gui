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
            var pageLinks = $(
                '[class="pagination-container"] li:not([class]) a,' +
                '[class="pagination-container"] li[class="active"] a'
                );

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