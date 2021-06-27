$(document).ready(function (e) {

    $(document).on("click", "#btn-reiniciar-fecha", function (e) {
        e.preventDefault();
        $("#txtFechaFin").val("");
    });

    $(document).on("click", "#btn-cambia-estado-producto", function (e) {
        var boton = $(this);
        var codProductoTienda = boton.data("cod");

        var url = $("#UrlCambiarEstadoProducto").val();

        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "post",
            url: url,
            dataType: "json",
            data: { id: codProductoTienda },
            success: function (res) {

                if (res.success == false) {
                    swal("Ops!", res.errorMessage, "error");
                    return;
                }
                Bitworks.Ventanas.ocultarLoading();


                var activeClass = "fa-toggle-on";
                var inactiveClass = "fa-toggle-off";

                var li;
                if (res.activo == false) {

                    li = "<i class='fa " + inactiveClass + "'></i> Activar";
                    $("#aviso-producto").fadeIn("slow");
                    boton.html(li);

                } else {
                    li = "<i class='fa " + activeClass + "'></i> Desactivar";
                    $("#aviso-producto").fadeOut("slow");

                    boton.html(li);
                }
            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    });

    $(document).on("click", ".btn-guardar-datosprod", function (e) {
        var boton = $(this);
        var codDato = boton.data("cod");
        var codProducto = $("#txtIdProducto").val();

        var url = $("#UrlGetDatoProducto").val();

        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "post",
            url: url,
            dataType: "json",
            data: { idDato: codDato, idProducto: codProducto },
            success: function (res) {

                if (res.success == false) {
                    swal("Ops!", res.errorMessage, "error");
                    return;
                }

                $("#det-datos").html(res.html);
                $.validator.unobtrusive.parse("#form-datos-productos");
                utilidadesBitworks.attachForm("form-datos-productos");
                Bitworks.Ventanas.ocultarLoading();

                $("#md-datos-producto").modal("show");

            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    });

    $(document).on("submit", "#form-datos-productos", function (e) {
        e.preventDefault();
        var form = $(this);

        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "post",
            url: form.attr('action'),
            dataType: "json",
            data: form.serialize(),
            success: function (res) {

                if (res.success == false) {
                    swal("Espera!", res.errorMessage, "info");
                    return;
                }
                $("#md-datos-producto").modal('toggle');

                swal("Exito!", "Sus datos se guardaron correctamente!", "success");

                $("#render-datos-producto").html(res.html);
            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    });

    $(document).on("click", ".btn-delete-dato", function (e) {
        var boton = $(this);
        var url = $("#UrlEliminarDatosProducto").val();
        var codigoDato = $(this).data("cod");
        var codProducto = $("#txtIdProducto").val();

        Swal.fire({
            title: 'Está seguro?',
            text: "El dato del producto se eliminará permanentemente",
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
                    type: "post",
                    url: url,
                    dataType: "json",
                    data: { idDato: codigoDato, idProducto: codProducto },
                    success: function (res) {

                        if (res.success == false) {
                            swal("Ops!", res.errorMessage, "error");
                            return;
                        }

                        boton.parent().parent().remove();

                        swal("Exito!", "El dato del producto se elimino correctamente", "success");
                    },
                    error: function (er) {
                        swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
                    }
                });

            }
        });
    });

});

