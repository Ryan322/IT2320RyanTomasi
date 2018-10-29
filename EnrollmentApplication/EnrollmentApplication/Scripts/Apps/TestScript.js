$("#search_form input[type='submit']").click(function() {
    input = $("#id_name").val();
    data = "text=" + input;

    $.ajax({
        type: "POST",
        url: "/user/search/",
        data: data,
        success: function(result) {
            $("#results_box").html(result).show();
        }
    });

    return false;
});