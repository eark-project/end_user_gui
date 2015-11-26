/**
 * Created by Beemen on 05/11/2015.
 */
define(["jquery", "bootstrap", "cart", "searchresultview"], function ($, b, c, s) {

    $(function(){

        $('#name').keyup(function(){
                s.callSearch();
        });

        $('#btnSearch').click(function(){
                s.callSearch();
        });

        s.callSearch();
        //c.setCartButtonEvents(); // implicit in callSearch()
    });
});


