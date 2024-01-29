$(document).ready(function () {
    

    $(".qtyminus").on("click", function () {
        var now = parseInt($(".qty").val(), 10);
        //console.log("Minus clicked, current value is: ", now);
        if (now > 1) {
            now--;
            $(".qty").val(now);
            //console.log("New value is: ", now);
        }
    });

    $(".qtyplus").on("click", function () {
        var now = parseInt($(".qty").val(), 10);
        //console.log("Plus clicked, current value is: ", now);
        //console.log("Max quantity is: ", maxQuantity);
        if (now < maxQuantity) {
            now++;
            $(".qty").val(now);
        } else {
            Swal.fire(
                'Has excedido la cantidad maxima de stock !',
            )
        }
    });
    
    $('#imageGallery').lightSlider({
        gallery: true,
        item: 1,
        loop: true,
        slideMargin: 0,
        thumbItem: 9
    });

    // Submit form
    $('#product-detail-form').on('submit', function (event) {

        var form = document.getElementById('product-detail-form');
        var action = form.getAttribute("action");
        var formdata = new FormData($("#product-detail-form")[0]);

        try {
            $.ajax({
                type: 'POST',
                url: action,
                data: formdata,
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.success) {
                        Swal.fire(
                            'Registro exitoso !',
                            `${res.message}`,
                            'success'
                        )
                    }
                    else if (res.success == false) {
                        window.location.href = res.redirectUrl
                    }
                },
                error: function (err) {
                }
            });
        } catch (ex) {
            toastr.success("El producto no se pudo agregar al carrito.")
        }

        event.preventDefault();
        //return false;
    });

});
function getChecked() {
    var colorList = document.getElementsByName('color');
    for (i in colorList) {
        if (colorList[i].checked == true) {
            return Number.parseInt(i) + 1;
        }
    }
}
setTimeout(() => {
    getChecked();
}, 1000);

var colorList = document.getElementsByName('color');
if (colorList.length > 0) {
    colorList[0].checked = true;
}