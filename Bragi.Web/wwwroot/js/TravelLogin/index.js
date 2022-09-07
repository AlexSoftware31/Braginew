/**tabs*/

$(document).ready(function () {
    $('.tabs').tabs();

    $("#AcompanyNumber").on("contextmenu paste", function (e) {
        e.preventDefault();
        return false;
    });

    $('#AcompanyNumber').keyup((e) => {
        const value = e.target.value;

        if (value.length > 1) {
            e.target.value = value.replace(/^0+(?=\d)/, '')
        }
        if (value > 6) {
            e.target.value = 6;
            return;
        }
        if (value < 0) {
            e.target.value = 0;
            return;
        }
    });




});

/*end tabs*/

