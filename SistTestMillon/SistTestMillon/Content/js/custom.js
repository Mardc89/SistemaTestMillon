﻿var validAjax;
var formAjax = $('.formAjax');
$("button.btnAjax").on('click', function (e) {
    e.preventDefault();
    validAjax = formAjax.validate({
        //== Validate only visible fields
        ignore: ":hidden",
        //== Display error  
        invalidHandler: function (event, validAjax) {
            swal({
                "title": "",
                "text": "Los datos capturados no son correctos.",
                "type": "error",
                "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
            });
        },
        //== Submit valid form
        submitHandler: function (form) {
        }
    });
    if (validAjax.form() == false) {
        $("#userSubs-error").hide();
        return;
    }
    $(".loadingAjax").show();
    formAjax.ajaxSubmit({
        success: function (response) {
            if (response.IsSuccess == true) {
                if (response.Id == -1) {
                    window.location.href = response.Message;
                } else {
                    swal({
                        "title": "",
                        "text": response.Message,
                        "type": "success",
                        "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
                    }).then(function () {
                        $(formAjax).find("input[type=text]").val("");
                        $(formAjax).find("select").val("");
                        $(".ocultarDespues").modal();
                        //$("#IdMod").val(response.Id);
                        //window.location = urlGeneral + "tramites";
                    });
                }
            }
            $(".loadingAjax").hide();
        },
        error: function (request, status, error) {
            swal({
                "title": "",
                "text": "No se puede conectar al servidor, intentelo más tarde!" + request.responseText,
                "type": "error",
                "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
            }).then(function () {
                //window.location = urlGeneral + "tramites";
            });
            $(".loadingAjax").hide();
        }
    });
});



//forms add
var validAjaxAdd;
var formAjaxAdd = $('.formAjaxAdd');
$("button.btnAjaxAdd").on('click', function (e) {
    e.preventDefault();
    validAjaxAdd = formAjaxAdd.validate({
        //== Validate only visible fields
        ignore: ":hidden",
        //== Display error  
        invalidHandler: function (event, validAjax) {
            swal({
                "title": "",
                "text": "Los datos capturados no son correctos.",
                "type": "error",
                "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
            });
        },
        //== Submit valid form
        submitHandler: function (form) {
        }
    });
    if (validAjaxAdd.form() == false) {
        $("#userSubs-error").hide();
        return;
    }
    $(".loadingAjaxAdd").show();
    formAjaxAdd.ajaxSubmit({
        success: function (response) {
            if (response.IsSuccess == true) {
                swal({
                    "title": "",
                    "text": response.Message,
                    "type": "success",
                    "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
                }).then(function () {
                    $(".ocultarDespues").modal('hide');
                    cargaTabla(strFiltro, strValOrder);
                    removeInfoForm(formAjaxAdd);

                    //$("#IdMod").val(response.Id);
                    //window.location = urlGeneral + "tramites";
                });
            }
            $(".loadingAjaxAdd").hide();
        },
        error: function (request, status, error) {
            swal({
                "title": "",
                "text": "No se puede conectar al servidor, intentelo más tarde!" + request.responseText,
                "type": "error",
                "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
            }).then(function () {
                //window.location = urlGeneral + "tramites";
            });
            $(".loadingAjaxAdd").hide();
        }
    });
});

function removeInfoForm(formAjaxAdd) {
    $(formAjaxAdd).find("input[type=text]").val("");
    $(formAjaxAdd).find("input[type=number]").val("");
    $(formAjaxAdd).find("input[type=number]")
    $("#modal-dropzone").find("input[type=file]").empty();
    $("#modal-dropzone").removeClass("dz-started");
    $(".dz-preview").remove();
    $(formAjaxAdd).find("select").val("");
}

function funProd(id, tipo, evt) {
    evt.preventDefault();
    if (tipo == 'E') {
        $.ajax({
            type: "POST",
            url: urlGeneral + "Historias/Eliminar",
            data: "{Id: " + id + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                swal({
                    "title": "",
                    "text": response.Message,
                    "type": "success",
                    "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
                }).then(function () {
                    $(".ocultarDespues").modal('hide');
                    cargaTabla(strFiltro, strValOrder);
                    
                });
                $(".loadingAjaxAdd").hide();
            },
            error: function (request, status, error) {
                swal({
                    "title": "",
                    "text": "No se puede conectar al servidor, intentelo más tarde!" + request.responseText,
                    "type": "error",
                    "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
                }).then(function () {
                    //window.location = urlGeneral + "tramites";
                });
                $(".loadingAjaxAdd").hide();
            }
        });
    } else {
        $("#modal8").modal("show");
        $.ajax({
            type: "POST",
            url: urlGeneral + "Historias/Get",
            data: "{Id: " + id + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.IsSuccess == true) {
                    $("#IdHistoria").val(response.Result.IdHistoria);
                    $("#CodigoDiagnostico").val(response.Result.CodigoDiagnostico);
                    $("#DniPsicologo").val(response.Result.DniPsicologo);
                    $("#textarea2").val(response.Result.Motivo);
                    $("#textarea3").val(response.Result.Tratamiento);
                    $("#textarea4").val(response.Result.Observacion);
                    removeInfoForm(formAjaxAdd);
                                       
                } else {
                    swal({
                        "title": "",
                        "text": response.Message,
                        "type": "error",
                        "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
                    }).then(function () {
                        //window.location = urlGeneral + "tramites";
                    });
                }
            },
            error: function (request, status, error) {
                swal({
                    "title": "",
                    "text": "No se puede conectar al servidor, intentelo más tarde!" + request.responseText,
                    "type": "error",
                    "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
                }).then(function () {
                    //window.location = urlGeneral + "tramites";
                });
                $(".loadingAjaxAdd").hide();
            }
        });
    }
}

function eliminarImagen(val, divEliminar) {
    $("#archivos").val($("#archivos").val().replace(val + "|", ""));
    $("#" + divEliminar).remove();
}

$('#modal8').on('hidden.bs.modal', function () {
    $("input").val("");
    $("#anexosUpload").empty();
});
