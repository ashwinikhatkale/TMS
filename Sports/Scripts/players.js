

$(function () {
    $('#select-all').on('click', function (event) {

        if (this.checked) {
            // Iterate each checkbox
            $(':checkbox').each(function () {
                this.checked = true;
            });
        } else {
            $(':checkbox').each(function () {
                this.checked = false;
            });
        }
    });

    $('#selectplayer').on('click', function (event) {
        var array = [];
        $('.players').find('input[type="checkbox"]').each(function () {

            var id = $(this).data('id');

            if ($(this).is(':checked')) {
                array.push(id);
            }
            else {
                array.unshift(id)
            }
           
            var teamId = $(this).data('team-id');
            var data = {
                teamId: teamId, playerIds: array
            }
            $.ajax({
                type: "POST",
                url: "/Caption/Players/SelectPlayers",
                data: JSON.stringify(data),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response.isSuccess == true && array.length > 0) {
                        alert('Players are selected successfully!');
                    }
                }
            });
        });
    });

});