/// <reference path="../jquery-1.9.0.min.js" />
/// <reference path="../utilidades.js" />
/// <reference path="../jquery.history.js" />

//Extension jquery para poder serializar el form a JSON
(function ($) {
    $.fn.serializeFormJSON = function () {

        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
})(jQuery);

(function (window) {
    window.Component = (typeof (window.Component) === "undefined") ? {} : window.Component;




    $(document).ready(function () {
        Component.Navigation.Init("divActualizar");
        //VentanasHelper.showError("lorem ipsum dolor sit amet");


        //Pruebas para poner los eventos
        Component.Navigation.Ready("test1", function () {
            alert("Ejecutando Evento Ready de la Pagina de prueba 1");
        });

        Component.Navigation.Ready("test2", function () {
            alert("Ejecutando Evento Ready de la pagina de prueba 2");
        });
    });

    Component.Navigation = function () {
        var divContenedor = null;
        var flagTrabajando = false;
        var History = null, StateActual = null, DomViejo = null;
        var idViewCambio = null;
        var arrEventosReady = new Array();
        //Funciones privadas para el manejo de eventos ready
        var BuscarObjEventById = function (strIdBuscar) {
            var objReady = null;
            for (var i = 0; i < arrEventosReady.length; i++) {
                var objActual = arrEventosReady[i];
                if (objActual.strId.toLowerCase() === strIdBuscar.toLowerCase()) {
                    objReady = objActual;
                    break;
                }
            }
            return objReady;
        }; //Estructura del objeto que va a tener los eventos ready que la mara suscriba   
        function objReadyEvent() {
            this.strId = null;
            this.ArrCallbacks = new Array();
            this.urlAccion = "";
        }
        objReadyEvent.prototype.AddEventReady = function (objfunc) {
            var me = this;
            me.ArrCallbacks.push(objfunc);
        };
        objReadyEvent.prototype.EjecutarCallbacks = function () {
            var me = this;
            for (var i = 0; i < me.ArrCallbacks.length; i++) {
                var callbackActual = me.ArrCallbacks[i];
                callbackActual();
            }
        };
        var onReady = function (strId, objfunc) {
            var objNuevo = BuscarObjEventById(strId);
            if (objNuevo != null) objNuevo.AddEventReady(objfunc);
            else {
                objNuevo = new objReadyEvent();
                objNuevo.strId = strId;
                objNuevo.AddEventReady(objfunc);
                arrEventosReady.push(objNuevo);
            }
        };

        //FIN del manejo de eventos ready

        var inicializar = function (strIdDivContainer) {
            //Configuro los eventos
            divContenedor = $("#" + strIdDivContainer).get(0);
            configLinkClick();
            ConfigurarHistory();
        }; //Metodos Privados
        var configLinkClick = function () {
            $(document).on("click", "a.ajaxNav", function (event) {
                event.preventDefault();
                var Titulo = $(this).data("nombre");
                var url = $(this).attr("href");
                //var idView = $(this).data("idview");
                //idViewCambio = idView;
                cambiarPagina(url, Titulo);
            });
        };
        var cambiarPagina = function (url, titulo, forceUpdate) {
            //idViewCambio = idview;
            History.pushState(null, titulo, url);
            //str.substring(1, 4)
            var root = History.getRootUrl().substring(0, History.getRootUrl().length - 1);
            var urlComparar = root + url;
            if (urlComparar === StateActual.url && forceUpdate) {
                History.Adapter.trigger(window, "statechange");
            }
        };
        var ConfigurarHistory = function () {
            History = window.History;
            StateActual = History.getState();

            //Evento para el stateChanage
            History.Adapter.bind(window, 'statechange', function (x, y, z) {
                var State = History.getState();
                console.log("Evento change");
                // if (State.url != StateActual.url) {

                getHtmlAjax(State.url);
                //}
                //History.log('statechange:', State.data, State.title, State.url);
            });
        };
        var getHtmlAjax = function (urlLlamar) {
            if (flagTrabajando === false) {
                flagTrabajando = true;
                //DomViejo = $(divContenedor).contents().detach();
                //$(divContenedor).empty();
                Component.Ventanas.mostrarLoading("Espere...");

                setTimeout(function () {
                    utilidadesBitworks.getAjaxHTML(urlLlamar, function (data) { getExitoso(data, idViewCambio); }, getFallido);
                }, 200);
            }
        };

        //Callbacks
        var getExitoso = function (data, IdView) {
            flagTrabajando = false;
            //DomViejo = $(divContenedor).contents().detach();
            if (Component.FusionChart) {
                Component.FusionChart.DisposeGraficos();
                Component.FusionChart.Configurar();
            }
            $(divContenedor).empty();
            $(divContenedor).html(data);
            StateActual = History.getState();
            //diseno.RedimensionesDespuesDeAjax();

            if ($.validator) {
                $.validator.unobtrusive.parse("form");
            }

            Component.Ajax.configCmdAjax();
            utilidadesBitworks.ConfigVal(true);
            Component.Ventanas.ocultarLoading();
            //Ejecuto los Callbacks de ready
            if (IdView) {
                var objEvents = BuscarObjEventById(IdView);
                if (objEvents != null) objEvents.EjecutarCallbacks();
            }
            //startPaging();
        };

        var getFallido = function (error) {
            flagTrabajando = false;
            //History.back()
            //$(divContenedor).append(DomViejo);
            //alert("hubo un error en la llamada ajax");
            Component.Ventanas.ocultarLoading();
            Component.Ventanas.mensajeError("Hubo un error cargando el nuevo contenido. Vuelva a intentarlo.", 10000);

        };

        return {
            Init: inicializar,
            cargarHtmlFromUrl: cambiarPagina,
            Ready: onReady
        };

    }();



    Component.Ajax = function () {

        $(document).ready(function () {
            ConfigurarCmdAjax();
        });

        var ConfigurarCmdAjax = function () {
            $(document).on("change", "select[data-ajaxcmd]", function () {
                var url = $(this).data("url");
                var cmdAfectar = $(this).data("cmdresultado");
                var datavalue = $(this).val();
                var $select = $("#" + cmdAfectar).empty();
                var mensajeDefault = $select.data("parentempty");
                var callBackDefault = function (objRespuesta) {
                    for (var i = 0; i < objRespuesta.Data.length; i++) {
                        var objActual = objRespuesta.Data[i];
                        $option = $("<option></option>");
                        $option.attr("value", objActual.Valor).text(objActual.Nombre);
                        $select.append($option);
                    }
                };
                var customCallBack = window[$(this).data("customcallback")];
                customCallBack && (customCallBack.select = $select);

                $select.append("<option value=''>" + mensajeDefault + "</option>");
                if (datavalue !== "") {
                    hacerLlamadaJsonAjax(url, { valor: datavalue }, customCallBack || callBackDefault);
                }
            });
        };


        //Metodos Privados
        var succesAjax = function (data, callbackCliente) {
            Component.Ventanas.ocultarLoading();
            var objRetorno = data;
            if (objRetorno.Estado === 0 || objRetorno.Estado === 3) {
                callbackCliente(objRetorno);
            } else if (objRetorno.Estado === 2) {
                if (objRetorno.Mensaje && objRetorno.Mensaje.length > 0) {
                    Component.Ventanas.alertaError("Permisos", objRetorno.Mensaje);
                } else {
                    Component.Ventanas.alertaError("Permisos", "No tiene permisos para ejecutar esta accion");
                }
            } else if (objRetorno.Estado === 1) {
                if (objRetorno.ListadoErrores && objRetorno.ListadoErrores.length > 0) {
                    //Entra aqui si viene varios error Tipo El model state
                    /*var $ul = $("<ul></ul>");
                    for (var i = 0; i < objRetorno.ListadoErrores.length; i++) {
                        var errorActual = objRetorno.ListadoErrores[i];
                        $ul.append("<li>" + errorActual + "</li>");
                    }*/

                    Component.Ventanas.listaErrores(objRetorno.ListadoErrores);


                } else if (objRetorno.Mensaje && objRetorno.Mensaje.length > 0) {
                    Component.Ventanas.ocultarLoading();
                    Component.Ventanas.alertaError(null, objRetorno.Mensaje);
                } else {
                    Component.Ventanas.alertaError("Server Error", "Hubo un error porfavor vuelva a intentarlo.");
                }
            };
        };
        var onAjaxError = function (objError, errCallback) {
            Component.Ventanas.ocultarLoading();
            if (objError != null && objError.message.length > 0) {
                Component.Ventanas.alertaError("Server Error", objError.message);
            } else {
                Component.Ventanas.alertaError("Server Error", "Hubo un error en el servidor, o no tiene una conexion a internet. Vuelva a intentarlo");
            }
            if (errCallback) errCallback(objError);
        };

        //METODOS PUBLICOS
        var hacerLlamadaJsonAjax = function (url, data, callback, errCallback) {
            utilidadesBitworks.getAjaxJson(url, data, function (respuesta) {
                succesAjax(respuesta, callback);
            }, function (objError) {
                onAjaxError(objError, errCallback);
            });
        };

        var llamadaAjaxGet = function (url, callback, errCallback) {
            utilidadesBitworks.getAjaxJsonWithGet(url, function (respuesta) {
                succesAjax(respuesta, callback);
            }, function (objError) {
                onAjaxError(objError, errCallback);
            });
        };

        var postAjaxForm = function (objForm, callback, errCallback) {
            var urlForm = $(objForm).attr("action");
            var data = $(objForm).serialize();
            //hacerLlamadaAjax(urlForm, data, callback);
            utilidadesBitworks.PostAjaxFormValues(urlForm, data, function (respuesta) {
                succesAjax(respuesta, callback);
            }, function (objError) {
                onAjaxError(objError, errCallback);
            });
        };


        return {
            callJsonPost: hacerLlamadaJsonAjax, // Llamada POST (le mandas los parametros manualmente)
            callGetJsonWithGet: llamadaAjaxGet, // Llamada GET 
            configCmdAjax: ConfigurarCmdAjax, // Combos dinámicos (NO USARLA)
            AjaxForm: postAjaxForm // Formulario POST (con ajax)

            // succesAjax (regresa objeto armado)
            // onAjaxError 
        };
    }();
})(window);