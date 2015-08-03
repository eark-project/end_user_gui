/**
 * Created by Beemen on 31/07/2015.
 */

function addToCart (uuid) {
    $.get(
        '/cart/add/' + uuid + '/',
        function(data){
            showMessage(data);
            refreshCartContents();
        }
    );
}

function removeFromCart(uuid){
    $.get(
        '/cart/remove/' + uuid + '/',
        function(data){
            refreshCartContents();
        }
    );
}

function emptyCart() {
    $.get(
        '/cart/empty/',
        function(data){
            refreshCartContents();
        }
    );
}

function refreshCartContents()
{
    // Refresh div element
    $('#cartViewModalBody').load(
        '/cart/view/',
        null,
        function(data){
            setCartButtonEvents();
        }
    )
    // Refresh count
    $('span[name="cartCount"]').load(
        '/cart/count/'
    );
}

function showMessage(msgText, spnId){
    if(!spnId)
        spnId = 'message'
    var msgSpan= $('#' + spnId);
    msgSpan.text(msgText);
}

function setCartButtonEvents(){

    $('[name=addToCartAnchor]').unbind('click');
    $('[name=addToCartAnchor]').click(function(event){
        var uuid = event.target.getAttribute('uuid');
        addToCart(uuid)
        return false;
    });

    $('[name=removeFromCartAnchor]').unbind('click');
    $('[name=removeFromCartAnchor]').click(function(event){
        var uuid = event.target.getAttribute('uuid');
        removeFromCart(uuid);
        return false;
    });

    $('[name=clearCartAnchor]').unbind('click');
    $('[name=clearCartAnchor]').click(function(event){
        emptyCart();
        return false;
    });
}