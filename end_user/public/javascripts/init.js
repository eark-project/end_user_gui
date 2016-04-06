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

        $('a[searchTab="true"]').on('shown.bs.tab', function (e) {
            s.callSearch()
        });

        $('input[name="searchin"]').change(function (e) {
            s.callSearch()
        });
    });
});