$(document).ready(function (e) {

    $(document).on("change", "#ddlTiendas", function (e) {

        if (IsNullOrEmpty($(this).val())) {
            $("#render-productotienda").html("");

            return;
        }

        var codTienda = $(this).val();
        var codProducto = $("#txtIdProducto").val();
        Bitworks.Ventanas.mostrarLoading();

        $.ajax({
            type: "post",
            url: $("#UrlGetProductoTienda").val(),
            dataType: "json",
            data: { idTienda: codTienda, idProducto: codProducto },
            success: function (res) {
                if (res.success) {
                    $("#render-productotienda").html(res.html);

                    $.validator.unobtrusive.parse("#form-producto-tienda");
                    utilidadesBitworks.attachForm("form-producto-tienda");

                    InitIcheck();
                    Bitworks.Ventanas.ocultarLoading();

                } 

            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    });

    $(document).on("click", "#btn-cambia-estado-prodtienda", function (e) {
        var boton = $(this);
        var codProductoTienda = boton.data("cod");

        var url = $("#UrlCambiarEstadoProductoTienda").val();

        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "post",
            url: url,
            dataType: "json",
            data: { id: codProductoTienda},
            success: function (res) {

                if (res.success  == false){
                    swal("Ops!", res.errorMessage, "error");
                    return;
                }
                Bitworks.Ventanas.ocultarLoading();


                var activeClass = "fa-toggle-on";
                var inactiveClass = "fa-toggle-off";

                var li;
                if (res.activo == false) {

                    li = "<i class='fa " + inactiveClass +"'></i> Activar";
                    $("#aviso-productotienda-inactivo").fadeIn("slow");
                    boton.html(li);

                } else {
                    li = "<i class='fa " + activeClass + "'></i> Desactivar";
                    $("#aviso-productotienda-inactivo").fadeOut("slow");

                    boton.html(li);
                }
            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    });

    $(document).on("submit", "#form-producto-tienda", function (e) {
        e.preventDefault();
        var form = $(this);
        Bitworks.Ventanas.mostrarLoading();

        $.ajax({
            type: "post",
            url: form.attr('action'),
            dataType: "json",
            data: form.serialize(),
            success: function (res) {
                if (res.success) {
                    $("#render-productotienda").html(res.html);
                    swal("Exito!", res.successMessage, "success");

                } else {

                    if (res.errorMessage != null) {
                        swal("Ops!", res.errorMessage, "error");
                    }


                    if (res.errorList != null) {
                        var errors = [];
                        $.each(res.errorList, function (i, error) {
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

