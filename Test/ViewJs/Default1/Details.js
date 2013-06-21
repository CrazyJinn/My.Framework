
jQuery.validator.addMethod("regex",
       function (value, element, params) {
           var exp = new RegExp(params);
           return exp.test(value);
       },
       "格式错误");

$().ready(function () {
    $("#validateForm").validate({
        rules: {
            ID: {
                required: true,
            },
            string1: {
                minlength: 2,
                maxlength: 5,
            },
            string2: {
                required: true,
                regex: "\\d{3}",
            },
            date: {
                required: true,
            },
        },
        messages: {
            firstname: "It is required.",
        },
        errorElement: 'span',
        errorClass: 'help-block error',
        errorPlacement: function (error, element) {
            element.parents('.controls').append(error);
        },
        highlight: function (label) {
            $(label).closest('.control-group').removeClass('error success').addClass('error');
        },
        success: function (label) {
            label.addClass('valid').closest('.control-group').removeClass('error success').addClass('success');
        }
    });

});
