define(['jquery'], function ($) {
    return {
        "callSearch": function (page) {
            if (!page)
                page = 1;
            $('#searchResults').load(
                '/search',
                {
                    name: $('#name').val(),
                    //description: $('#description').val(),
                    meta: $('#metadataSearch').attr('class').split(' ').indexOf('active') > -1,
                    searchintitle: $('#searchintitle').is(':checked'),
                    searchindescription: $('#searchindescription').is(':checked'),
                    page: page
                },
                function (data) {
                    require(["cart"], function (c) {
                        c.setCartButtonEvents();
                    });

                }
            )
        },

        "attachEvents": function () {
            $('[name="expandPackage"]').click(function () {
                var uuid = this.getAttribute('uuid');
                var div = $('#packageFiles_' + uuid)
                var url = div.attr('url');
                if (div.is(":hidden"))
                    $.ajax(url)
                        .done(function (data) {
                            div.html(data);
                            div.show();
                        });
                else
                    div.hide();
            });

            $('[name="gotopage"]').click(function () {
                var page = this.getAttribute('page');
                require(["searchresultview"], function (c) {
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
                require(["searchresultview"], function (c) {
                    c.callSearch(page);
                });
            });
        }
    };
});