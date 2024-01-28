$(document).ready(function () {
    $("#products-table").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["excel", "csv"]
    }).buttons().container().appendTo('#products-table_wrapper .col-md-6:eq(0)');
});

function removeProduct(id) {
    Swal.fire({
        title: "¿Estas seguro que quieres borrarlo?",
        text: '¡Los datos eliminados no se pueden recuperar!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'SI !',
        cancelButtonText: 'NO !'
    }).then((data) => {
        console.log(data);
        try {
            if (data.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    url: "/Admin/Product/DeleteProduct/" + id,
                    data: "{id:'" + id + "'}",
                    contentType: false,
                    processData: false,
                    success: async function (res) {
                        console.log(res);
                        await Swal.fire(
                            '¡Eliminación exitosa!',
                            `${res.message}`,
                            'success'
                        )
                        window.location.reload();
                    },
                    error: function (err) {
                        console.log(err.responseText);
                        Swal.fire(
                            '¡Error de eliminación!',
                            `${err}`,
                            'error'
                        )
                    }
                })
            }
        } catch (ex) {
        }
    });
}