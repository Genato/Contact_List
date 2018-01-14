jQuery(document).ready(function () {

    jQuery('#DeleteContact').click(function (event) {

        if (!confirm("Are you sure you want to delete contact")) {
            event.preventDefault();
        }
    });


    $("#TEST").click(function () {
        $("#contactsTable").empty();
        $(".pagination").remove();
    });

});