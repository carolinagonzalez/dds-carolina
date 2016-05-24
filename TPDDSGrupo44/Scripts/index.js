$(document).ready(function () {

    $("input[name='palabraClave']").on("keyup", function () {
        if ($(this).val()) {
            $("button").addClass("call-to-action");
        } else {
            $("button").removeClass("call-to-action");
        }
    });

})