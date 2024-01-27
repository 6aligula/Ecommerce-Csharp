$(document).ready(function () {
    $("#categoriesTable").DataTable();
});

removeCategory = form => {
    Swal.fire({
        title: "¿Estas seguro que quieres borrarlo?",
        text: '¡Los datos eliminados no se pueden recuperar!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil !',
        cancelButtonText: 'İptal !'
    }).then((data) => {
        console.log(data);
        try {
            if (data.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: async function (res) {
                        $('#view-all').html(res.html);
                        await Swal.fire(
                            '¡Eliminación exitosa!',
                            `${res.message}`,
                            'success'
                        )
                        window.location.reload();
                    },
                    error: function (err) {
                    }
                })
            }
        } catch (ex) {
        }
    });
    return false;
}