
$(function () {
    $(".delete-team").on('click', function (e) {

        e.preventDefault();
        var id = $(this).data('id');
        var name = $(this).data('name');
        var el = $(this);

        var isDelete = confirm("Are you sure, you delete team " + name + "?");
        if (isDelete) {
            $.ajax({
                type: "POST",
                url: "/TeamCoach/Team/delete/" + id,
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response.isSuccess == true) {
                        el.closest('tr').remove();
                        alert('Message deleted successfully!');
                    }
                }
            });
        }
    });

});
