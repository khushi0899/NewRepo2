$(document).ready(function () {
    alert("okk");
    GetCategory();
    alert("after");
});

function GetCategory() {
    $.ajax({
        type: 'Get',
        url: '/Cascade/Category',
        dataType: 'JSON',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Category').append('<Option value=' + data.id + '>' + data.name + '</Option>');
                alter("Success");
            });
        }
    });
}