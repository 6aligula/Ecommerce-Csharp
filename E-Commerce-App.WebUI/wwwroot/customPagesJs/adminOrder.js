$(document).ready(function () {
    $('#form-order-state').on('submit', function (event) {
        var formData = new FormData($('#form-order-state')[0]);
        $.ajax({
            type: 'POST',
            url: "/Admin/Order/EditOrderState",
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
                        '¡Error de registro!',
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
});