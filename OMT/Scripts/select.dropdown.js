function containerSpanId(elm) {
    var span = elm;
    while (span.tagName.toLowerCase() != 'span')
        span = span.parentElement;
    elementId = span.getAttribute('id');
    return elementId;
}

function updateSelectSaveLink(select, column) {

    var elementId = containerSpanId(select)
    var a = $('#' + elementId + ' a[save]');
    if (!a.attr('orgHref')) {
        a.attr('orgHref', a.attr('href'));
    }
    a.attr(
        'href',
        a.attr('orgHref') + '&' + column + '=' + select.value + '&set=true'
    );
}