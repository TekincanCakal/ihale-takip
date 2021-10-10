$(document).ready(function () {
    $(".comma-numbers").on("input", function (event) {
        let element = event.target;
        element.value = element.value.replace(/[^0-9\,]/g, '');
        if (element.value.split(',').length > 2)
            element.value = element.value.replace(/\,+$/, "");
    });
});