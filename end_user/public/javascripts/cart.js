
/**
 * Created by Beemen on 31/07/2015.
 */

// Object Module
// -------------

// The define method is passed a JavaScript anonymous function
define(["jquery", "jqueryui", "cart"], function ($, ui, c) {

    // Returns an object literal
    return {
        "openCartModal": function (event) {
            event.stopPropagation();
            $('#modalPopupSpan').load(
                '/cart/openadd/' + uuid + '/',
                null,
                function (data) {
                    require(["cart"], function (c) {
                        c.setCartButtonEvents();
                        $('#addToCartModal').modal('show');
                    });
                }
            )
        },

        "openAddToCartModal": function (uuid) {
            // Refresh div element
            $('#addToCartModalBody').load(
                '/cart/openadd/' + uuid + '/',
                null,
                function (data) {
                    require(["cart"], function (c) {
                        c.setCartButtonEvents();
                        $('#addToCartModal').modal('show');
                    });
                }
            )
            return false;
        },

        "addToCart": function (uuid, disUuid) {
            $.get(
                '/cart/add/' + uuid + '/' + disUuid + '/',
                function (data) {
                    require(["cart"], function (c) {
                        c.showMessage(data);
                        c.refreshCartContents();
                    });
                }
            );
        },

        "removeFromCart": function (uuid) {
            $.get(
                '/cart/remove/' + uuid + '/',
                function (data) {
                    require(["cart"], function (c) {
                        c.refreshCartContents();
                    });
                }
            );
        },

        "emptyCart": function () {
            $.get(
                '/cart/empty/',
                function (data) {
                    require(["cart"], function (c) {
                        c.refreshCartContents();
                    });
                }
            );
        },

        "submitCart": function () {
            $.get(
                '/cart/submit/',
                function (data) {
                    require(["cart"], function (c) {
                        $('#cartModal').modal('hide');
                        c.refreshCartContents();
                    });
                }
            );
        },

        "refreshCartContents": function () {
            // Refresh div element
            $('#cartViewModalBody').load(
                '/cart/view/',
                null,
                function (data) {
                    require(["cart"], function (c) {
                        c.setCartButtonEvents();
                    });
                }
            )
            // Refresh count
            $('span[name="cartCount"]').load(
                '/cart/count/'
            );
        },

        "showMessage": function (msgText, spnId) {
            if (!spnId)
                spnId = 'message'
            var msgSpan = $('#' + spnId);
            msgSpan.text(msgText);
        },

        "setCartButtonEvents": function () {
            var getUuid = function (event) {
                var maxIter = 3;
                var i = 0;
                var elm = event.target;
                var uuid = elm.getAttribute('uuid');

                while (!uuid && i < maxIter) {
                    elm = elm.parentElement;
                    uuid = elm.getAttribute('uuid');
                    i++;
                }
                return uuid;
            };

            $('[name=viewCartAnchor]').unbind('click');
            $('[name=viewCartAnchor]').click(function (event) {
                require(["cart"], function (c) {
                    c.openCartModal();
                });
            });

            $('[name=openAddToCartAnchor]').unbind('click');
            $('[name=openAddToCartAnchor]').click(function (event) {
                require(["cart"], function (c) {
                    var uuid = getUuid(event);
                    c.openAddToCartModal(uuid);
                    return false;
                });
            });

            $('[name=addToCartAnchor]').unbind('click');
            $('[name=addToCartAnchor]').click(function (event) {
                require(["cart"], function (c) {
                    var uuid = event.target.getAttribute('uuid');
                    var disUuid = event.target.getAttribute('disUuid');
                    c.addToCart(uuid, disUuid);
                    return false;
                });
            });

            $('[name=removeFromCartAnchor]').unbind('click');
            $('[name=removeFromCartAnchor]').click(function (event) {
                require(["cart"], function (c) {
                    var uuid = event.target.getAttribute('uuid');
                    c.removeFromCart(uuid);
                    return false;
                });
            });

            $('[name=clearCartAnchor]').unbind('click');
            $('[name=clearCartAnchor]').click(function (event) {
                require(["cart"], function (c) {
                    c.emptyCart();
                    return false;
                });
            });

            $('[name=submitCartAnchor]').unbind('click');
            $('[name=submitCartAnchor]').click(function (event) {
                require(["cart"], function (c) {
                    c.submitCart();
                    return false;
                });
            });
        }
    }
});
