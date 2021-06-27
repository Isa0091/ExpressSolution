$(document).ready(function(e) {
    

    $(document).on("change", "#file-productos-sugeridos", function () {
        $("#frm-producto-sugerido").submit();
    });

    $(document).on("click", ".paginado-sugeridos", function (e) {
        e.preventDefault();

        var url = $(this).attr('href');

        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "GET",
            url: url,
            success: function (res) {
                if (res.success === false) {
                    swal("Ops!", res.errorMessage, "error");
                    return;
                }

                $("#render-productosugeridos").html(res.html);
                Bitworks.Ventanas.ocultarLoading();

            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });

    });

    $(document).on("click", ".btn-delete-producto", function (e) {
        e.preventDefault();
        var boton = $(this);

        var idProductoSugerido = boton.data("cod");
        var codProducto = $("#txtIdProducto").val();

        Swal.fire({
            title: 'Está seguro?',
            text: "El producto sugerido se eliminará permanentemente",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            cancelButtonColor: '#CCC',
            confirmButtonText: 'Sí, eliminarlo!',
            cancelButtonText: "No, cancelar!",
            closeOnConfirm: false,
            closeOnCancel: true
        }).then(function (result) {
            if (result.value) {
                Bitworks.Ventanas.mostrarLoading();
                $.ajax({
                    type: "POST",
                    url: $("#UrlDeleteProductoSugerido").val(),
                    data: { idProducto: codProducto, idProductoSugerido: idProductoSugerido },
                    success: function (res) {

                        if (res.success) {
                            boton.parent().parent().remove();
                            swal("Exito!", res.successMessage, "success");

                        } else {
                            swal("Ops!", res.errorMessage, "error");
                        }

                    },
                    error: function (er) {
                        swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
                    }
                });
            }
        });

       
    });

    $(document).on("submit", "#frm-producto-sugerido", function (e) {
        e.preventDefault();
        var form = $(this);

        var data = new FormData($("#frm-producto-sugerido")[0]);

        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "POST",
            url: form.attr("action"),
            data: data,
            contentType: false,
            processData: false,
            success: function (res) {
            
                if (res.success) {
                    $("#render-productosugeridos").html(res.html);
                    swal("Exito!", res.successMessage, "success");

                } else {

                    if (res.errorMessage != null) {
                        swal("Ops!", res.errorMessage, "error");
                    }


                    if (res.validationErrors != null) {
                        var errors = [];
                        $.each(res.validationErrors, function (i, error) {
                            errors.push(error);
                        });

                        showErrorListFromArray(errors);
                    }
                }

            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    });
});