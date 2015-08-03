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

    $('a[name=addToCartAnchor]').unbind('click');
    $('a[name=addToCartAnchor]').click(function(event){
        var uuid = event.target.getAttribute('uuid');
        addPersonToCart(uuid);
        return false;
    });

    $('a[name=removeFromCartAnchor]').unbind('click');
    $('a[name=removeFromCartAnchor]').click(function(event){
        var uuid = event.target.getAttribute('uuid');
        removePersonFromCart(uuid);
        return false;
    });

    $('a[name=clearCartAnchor]').unbind('click');
    $('a[name=clearCartAnchor]').click(function(event){
        emptyCart();
        return false;
    });
}