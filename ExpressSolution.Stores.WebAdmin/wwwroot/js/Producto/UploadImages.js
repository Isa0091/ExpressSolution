Dropzone.autoDiscover = false;

$(document).ready(function () {

    //Actualizar el contenido de las imagenes
    var actualizarContenedorImagenes = function (html) {
        $("#ContenedorImagenes").html(html);
    };

    var htmlPreview = $("div#previewDropZone").html();

    var dropzoneGaleria = $("form#upload-widget")
        .dropzone({
            paramName: "file",
            uploadMultiple: false,
            previewTemplate: htmlPreview,
            parallelUploads: 20,
            acceptedFiles: "image/jpeg,image/pjpeg,image/png",
            autoProcessQueue: false,
            maxFiles: 20,
            init: function () {
                //aqui agregar los handlers de los diferentes eventos
                var myDropZonse = this;
                myDropZonse.on("sending", function (file, xhr, formdata) {
                    var inputCaption = $(file.previewElement).find("input[name=Caption]").val();
                    formdata.append("caption", inputCaption);
                });
                myDropZonse.on("queuecomplete", function () {
                    myDropZonse.removeAllFiles();
                    //cierro el modal de las fotos
                    $("#btnguardar").removeAttr('disabled');
                    $("#modal_nueva_foto").modal("hide");
                    //Bitworks.Ventanas.ocultarLoading();
                    swal("Confirmación", "Las fotos fueron guardadas exitosamente", "success");
                    //toastr.success('Las fotos fueron guardadas exitosamente');
                });

                //Evento que se ejecuta con cada imagen subida con exito
                myDropZonse.on("success", function (file, respServer) {
                    actualizarContenedorImagenes(respServer.html);
                    InitIcheck();
                });
            }
        })[0].dropzone;


    //accion  del boton que guarda las imagenes
    $(document).on("click", "#btnguardar", function (e) {
        e.preventDefault();

        $(this).attr('disabled', 'disabled');
        Bitworks.Ventanas.mostrarLoading();
        dropzoneGaleria.processQueue();

    });


    //Elimina una imagen de la categoria
    $(document).on("click", "#btn-eliminar", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var url = $(this).data("url");
        var codProducto = $("#txtIdProducto").val();
        var codMultimedia = $(this).data("cod");
        var boton = $(this);

        Swal.fire({
            title: 'Está seguro?',
            text: "La imagen se eliminará permanentemente",
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
                    data: { idProducto: codProducto, idMultimedia: codMultimedia },
                    success: function (res) {
                        if (res.success) {
                            boton.parents("li").remove();

                            swal("Exito!", res.message, "success");
                        } else {
                            swal("Ops!", res.message, "error");
                        }
                    },
                    error: function (er) {
                        swal("Ops!","Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde","error");
                    }
                });
            }
        });

    });

    //Seleccionar la imagen principal
    $(document).on("ifChanged", ".select-main-image", function (e) {

        var url = $("#UrlSelectMainImage").val();
        var codProducto = $("#txtIdProducto").val();
        var codMultimedia = $(this).data("cod");

        Bitworks.Ventanas.mostrarLoading();
        $.ajax({
            type: "post",
            url: url,
            dataType: "json",
            data: { idProducto: codProducto, idMultimedia: codMultimedia },
            success: function (res) {
                if (res.success === false) {
                    swal("Exito!", res.message, "success");
                }
                actualizarContenedorImagenes(res.html);
                InitIcheck();

                Bitworks.Ventanas.ocultarLoading();
            },
            error: function (er) {
                swal("Ops!", "Ocurrio un error al realizar esta operacion, por favor intentalo mas tarde", "error");
            }
        });

    });


});