$(document).ready(function () {
        $('#dvOutput').hide();
        $('#Salary').on('input', function () {
            this.value = this.value.match(/^\d+\.?\d{0,2}/);
        });

        $('#btnSubmit').click(function () {
            $('.validation-summary-errors').show();
            clearFields();
            if ($("#frmAKQA").valid()) {
                $('.validation-summary-errors').hide();
                $('#dvOutput').show();
                formData = {
                    Name: $('#Name').val(),
                    Salary: parseFloat($('#Salary').val())
                };
                $.ajax({
                    url: '/API/FormatNumberAPI',
                    type: 'post',
                    data: JSON.stringify(formData),
                    contentType:'application/json',
                    success: function (data) {
                        $('#spName').text(data.name.toUpperCase());
                        $('#spNumberinWords').text(data.salaryString);
                    },
                    error: function (jqXHR) {
                        console.log(jqXHR.statusText);
                    }
                })
            }
        });
    });
    var clearFields = function () {
        $('#dvOutput').hide();
        $('#spName').text('');
        $('#spNumberinWords').text('');
    }