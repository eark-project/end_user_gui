/**
 * Created by Beemen on 05/11/2015.
 */
define(["jquery", "bootstrap", "searchresultview"], function ($, b, c) {

    $(function(){

        $('#name').keyup(function(){
                c.callSearch();
        });

        $('#btnSearch').click(function(){
                c.callSearch();
        });

        c.setCartButtonEvents();
        c.callSearch();
    });
});


