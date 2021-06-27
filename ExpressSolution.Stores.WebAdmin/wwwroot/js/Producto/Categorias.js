$(document).ready(function(e) {

    $(document).on("ifChanged", ".chkCategoria", function (e) {
        var selected = $(this).prop("checked");
        var codProducto = $("#txtIdProducto").val();
        var codCategoria = $(this).data("cod");
        var codCategoriaProducto = $(this).data("codcatprod");

        if (selected === true) {
            AddCategoriaProducto(codProducto, codCategoria, $(this));
        } else {
            DeleteCategoriaProducto(codCategoria, codCategoriaProducto);
        }
    });

    function AddCategoriaProducto(codProducto, codCategoria, boton) {
        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "post",
            url: $("#UrlAddCategoriaProducto").val(),
            dataType: "json",
            data: { idProducto: codProducto, idCategoria: codCategoria },
            success: function (res) {
                if (res.success === false) {
                    swal("Ops!", res.errorMessage, "error");
                } else {
                    Bitworks.Ventanas.ocultarLoading();
                    boton.data("codcatprod", res.idCategoriaProducto);
                }
            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    }

    function DeleteCategoriaProducto(idCategoria, idCategoriaProducto) {
        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "post",
            url: $("#UrlDeleteCategoriaProducto").val(),
            dataType: "json",
            data: { idCategoria: idCategoria, idCategoriaProducto: idCategoriaProducto },
            success: function (res) {
                if (res.success === false) {
                    swal("Ops!", res.errorMessage, "error");
                } else {
                    Bitworks.Ventanas.ocultarLoading();

                }
            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });
    }
});