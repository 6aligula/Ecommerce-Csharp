$(document).ready(function () {

    $('#user-account-form').on('submit', function (event) {
        const REQUIRED_INPUT_MESSAGE = "Este campo es obligatorio completarlo."

        $('#user-account-form').validate({
            rules: {
                "FullName": {
                    required: true,
                    maxlength: 50,
                    minlength: 2
                },
                "NewPassword": {
                    maxlength: 30,
                    minlength: 8
                },
                "RePassword": {
                    maxlength: 30,
                    minlength: 8,
                    equalTo: "#password"
                },
            },
            messages: {
                "FullName": {
                    required: REQUIRED_INPUT_MESSAGE,
                    maxlength: "Este campo puede contener hasta 50 caracteres.",
                    minlength: "Este campo puede constar de al menos 2 caracteres.",
                },
                "NewPassword": {
                    maxlength: "Este campo puede contener hasta 30 caracteres.",
                    minlength: "Este campo puede tener al menos 8 caracteres.",
                },
                "RePassword": {
                    maxlength: "Este campo puede contener hasta 30 caracteres.",
                    minlength: "Este campo puede tener al menos 8 caracteres.",
                    equalTo: "Las contraseñas no coinciden"
                },

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

        if ($('#user-account-form').valid() === true) {
            var form = document.getElementById('user-account-form');
            var action = form.getAttribute("action");
            var formdata = new FormData($("#user-account-form")[0]);
            try {
                $.ajax({
                    type: 'POST',
                    url: action,
                    data: formdata,
                    contentType: false,
                    processData: false,
                    success: async function (res) {
                        if (res.success) {
                            await Swal.fire(
                                'Registro exitoso !',
                                `${res.message}`,
                                'success'
                            )
                            window.location.href = res.redirectUrl;
                        } else {
                            toastr.warning(res.message);
                            setTimeout(() => { window.location.href = res.redirectUrl; }, 2000);
                        }
                    },
                    error: function (err) {
                        Swal.fire('¡Error de registro!', 'error')
                    }
                })
                return false;
            } catch (ex) {
                Swal.fire('¡Error de registro!', 'error')
            }
        }
        return false;
    });
});