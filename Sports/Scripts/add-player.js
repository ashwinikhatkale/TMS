$(function () {
    
    $('#submit').on('click', function () {
        var isValid = $('form').valid();

        if (isValid) {
            $(this).addClass('disabled');
        }
    });
});