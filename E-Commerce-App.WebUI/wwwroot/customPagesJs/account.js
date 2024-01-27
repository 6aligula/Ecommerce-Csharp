$(document).ready(function () {
    toastr.options = {
        "positionClass": "toast-bottom-right",
    }

    $('#login-form').on('submit', function (event) {
        var formData = new FormData($('#login-form')[0]);
        $.ajax({
            type: 'POST',
            url: "/Account/Login",
            data: formData,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.success) {
                    toastr.success("Inicio de sesión correcto");
                    setTimeout(() => { window.location.href = res.redirectUrl; }, 1000);
                } else {
                    toastr.warning(res.message);
                }
            },
            error: function (err) {
                toastr.error("ocurrió un error inesperado");
            }
        });
        return false;
    });

    $('#register-form').on('submit', function (event) {
        var formData = new FormData($('#register-form')[0]);
        $.ajax({
            type: 'POST',
            url: "/Account/Register",
            data: formData,
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
                    Swal.fire(
                        'Error !',
                        `${res.message}`,
                        'error'
                    )
                }
            },
            error: function (err) {
                toastr.error("ocurrió un error inesperado");
            }
        });
        return false;
    });


    $(".sign-up").click(() => {
        window.location.href = "/account/register";
    });
    $(".frgt-pass").click(() => {
        window.location.href = "/account/forgotpassword";
    });

});

function show() {
    var p = document.getElementById('pwd');
    p.setAttribute('type', 'text');
}
function hide() {
    var p = document.getElementById('pwd');
    p.setAttribute('type', 'password');
}
var pwShown = 0;
document.getElementById("eye").addEventListener("click", function () {
    if (pwShown == 0) {
        pwShown = 1;
        show();
    } else {
        pwShown = 0;
        hide();
    }
}, false);