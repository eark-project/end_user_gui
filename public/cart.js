/**
 * Created by Beemen on 31/07/2015.
 */

function openAddToCartModal(uuid) {
    // Refresh div element
    $('#modalPopupSpan').load(
        '/cart/openadd/' + uuid + '/',
        null,
        function(data){
            setCartButtonEvents();
            $('#addToCartModal').modal('show');
        }
    )
}
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

function submitCart(){
    $.get(
        '/cart/submit/',
        function(data){
            $('#cartModal').modal('hide');
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
        //addToCart(uuid)
        openAddToCartModal(uuid);
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

    $('[name=submitCartAnchor]').unbind('click');
    $('[name=submitCartAnchor]').click(function(event){
        submitCart();
        return false;
    });

}