$(document).ready(function () {

    // Initialize payment card
    var card = new Card({
        form: '#payment-form',
        container: '.credit-card',
        formSelectors: {
            numberInput: 'input#number',
            expiryInput: 'input#expiry',
            cvcInput: 'input#cvc',
            nameInput: 'input#name'
        },
        placeholders: {
            number: '•••• •••• •••• ••••',
            name: 'Adolfo',
            expiry: '••/••',
            cvc: '•••'
        }
    });

    $('#expiry').keyup(function () {
        var expiry = $("#expiry").val();
        var arr = expiry.split("/");
        $("#expiry-month").val(arr[0].trim());
        $("#expiry-year").val(arr[1].trim());
    });

    // Cargar provincias desde el archivo JSON
    $.getJSON("/json/prov-ciudades.json", function (result) {
        $.each(result, function (index, value) {
            var row = '<option value="' + value.provincia + '">' + value.provincia.toUpperCase() + '</option>';
            $("#provincia").append(row);
        });
    });

    // Cargar ciudades después de que se selecciona una provincia
    $("#provincia").on("change", function () {
        var provinciaSeleccionada = $(this).val();
        $("#ciudad").attr("disabled", false).html("<option value=''>Elegir...</option>");
        $.getJSON("/json/prov-ciudades.json", function (result) {
            $.each(result, function (index, value) {
                if (value.provincia == provinciaSeleccionada) {
                    $.each(value.ciudades, function (ciudadIndex, ciudad) {
                        var row = '<option value="' + ciudad + '">' + ciudad.toUpperCase() + '</option>';
                        $("#ciudad").append(row);
                    });
                }
            });
        });
    });

    // Validate Payment Form
    const REQUIRED_INPUT_MESSAGE = "Este campo es obligatorio completarlo.";
    $('#payment-form').validate({
        rules: {
            "OrderDto.FirstName": {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            "OrderDto.LastName": {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            "OrderDto.Phone": {
                required: true,
                minlength: 10,
                maxlength: 10
            },
            "OrderDto.City": {
                required: true,
            },
            "OrderDto.Address": {
                required: true,
                minlength: 10,
                maxlength: 120
            },
            "CardNumber": {
                required: true,
                minlength: 16,
                maxlength: 19
            },
            "CardHolderName": {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            "expiry": {
                required: true,
            },
            "Cvc": {
                required: true,
            },
            "contract": {
                required: true,
            },
        },
        messages: {
            "OrderDto.FirstName": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "2",
                maxlength: "50"
            },
            "OrderDto.LastName": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "2",
                maxlength: "50"
            },
            "OrderDto.Phone": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "10",
                maxlength: "10"
            },
            "OrderDto.City": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "OrderDto.Address": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "10",
                maxlength: "120"
            },
            "CardNumber": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "16",
                maxlength: "19"
            },
            "CardHolderName": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "3",
                maxlength: "20"
            },
            "expiry": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "Cvc": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "contract": {
                required: REQUIRED_INPUT_MESSAGE,
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });

    // Submit Payment Form
    $('#payment-form').on('submit', function (event) {
        var formData = new FormData();
        var serializedArr = $("#payment-form").serializeArray();
        serializedArr.forEach((d) => {
            formData.append(d.name, d.value);
            console.log(d.name + " " + d.value);
        });
        if ($('#payment-form').valid() === true) {
            var formData = new FormData();
            var serializedArr = $("#payment-form").serializeArray();
            serializedArr.forEach((d) => {
                formData.append(d.name, d.value);
                console.log(d.name + " " + d.value);
            });
            $.ajax({
                type: 'POST',
                url: "/Order/Checkout",
                data: formData,
                contentType: false,
                processData: false,
                success: async function (res) {
                    if (res.success) {
                        await Swal.fire(
                            '¡Orden exitosa!',
                            `${res.message}`,
                            'success'
                        )
                        window.location.href = "/";
                    }
                    else
                        Swal.fire(
                            '¡Error de registro!',
                            `${res.message}`,
                            'error'
                        )
                },
                error: function (err) {
                }
            });
            return false;
        }
        else {
            event.preventDefault();
            toastr.warning("Por favor llene los campos requeridos.")
        }
    });


});

