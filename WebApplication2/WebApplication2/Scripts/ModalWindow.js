$(function() {
    $.ajaxSetup({ cache: false });
    $(".scriptItem")
        .click(function(e) {
            e.preventDefault();
            $.get(this.href,
                function(data) {
                    $('#dialogContent').html(data);
                    $('#modDialog').modal('show');
                });
        });
})