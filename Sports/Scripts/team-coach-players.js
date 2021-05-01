
$(function () {
    $(".radio-caption").on('click', function () {
        var id = $(this).data('id');
        var teamId = $(this).data('team-id');
        var name = $(this).data('name');

        var isSetCaption = confirm("Are you sure, you want to set player " + name + " as caption?");
        var data = { teamId: teamId, userId: id };

        if (isSetCaption) {
            $.ajax({
                type: "POST",
                url: "/TeamCoach/Players/SetAsCaption",
                data: JSON.stringify(data),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response.isSuccess == true) {
                        alert(name + ' is now caption!');
                    }
                }
            });
        }
    });

    $(".delete-player").on('click', function (e) {

        e.preventDefault();
        var id = $(this).data('id');
        var name = $(this).data('name');
        var el = $(this);

        var isDelete = confirm("Are you sure, you delete player " + name + "?");

        if (isDelete) {
            $.ajax({
                type: "POST",
                url: "/TeamCoach/Players/delete/" + id,
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