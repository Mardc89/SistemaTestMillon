var validAjax;
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


function funPsicolog(id, tipo, evt) {
    evt.preventDefault();
    if (tipo == 'E') {
        $.ajax({
            type: "POST",
            url: urlGeneral + "Psicologos/Eliminar",
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
            url: urlGeneral + "Psicologos/Get",
            data: "{Id: " + id + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.IsSuccess == true) {
                    $("#IdPsicologo").val(response.Result.IdPsicologo);
                    $("#Dni").val(response.Result.Dni);
                    $("#Nombres").val(response.Result.Nombres);
                    $("#Apaterno").val(response.Result.ApellidoPaterno);
                    $("#Amaterno").val(response.Result.ApellidoMaterno);
                    $("#Profesion").val(response.Result.Profesion);
                    $("#Direccion").val(response.Result.Direccion);
                    $("#Edad").val(response.Result.Edad);
                    $("#Sexo").val(response.Result.Sexo);
                    $("#telefono").val(response.Result.Telefono);
                    $("#FechaNacimiento").val(response.Result3.toLocaleString('en-GB'));
                    $("#Correo").val(response.Result.Correo);
                    $("#NombreUsu").val(response.Result2.NombreUsuario);
                    $("#TipoUsu").val(response.Result2.TipoUsuario);
                    $("#Contraseña").val(response.Result2.Contraseña);
                    $("#re-Contraseña").val(response.Result2.Contraseña);
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



function funPacientes(id, tipo, evt) {
    evt.preventDefault();
    if (tipo == 'E') {
        $.ajax({
            type: "POST",
            url: urlGeneral + "Pacientes/Eliminar",
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
            url: urlGeneral + "Pacientes/Get",
            data: "{Id: " + id + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.IsSuccess == true) {
                    $("#IdPaciente").val(response.Result.IdPaciente);
                    $("#Dni").val(response.Result.Dni);
                    $("#Nombres").val(response.Result.Nombres);
                    $("#Apaterno").val(response.Result.ApellidoPaterno);
                    $("#Amaterno").val(response.Result.ApellidoMaterno);
                    $("#Profesion").val(response.Result.Profesion);
                    $("#Direccion").val(response.Result.Direccion);
                    $("#Edad").val(response.Result.Edad);                    
                    $("#Sexo").val(response.Result.Sexo);                    
                    $("#telefono").val(response.Result.Telefono);
                    $("#FechaNacimiento").val(response.Result3.toLocaleString('en-GB'));
                    $("#Correo").val(response.Result.Correo);
                    $("#NombreUsu").val(response.Result2.NombreUsuario);
                    $("#TipoUsu").val(response.Result2.TipoUsuario);
                    $("#Contraseña").val(response.Result2.Contraseña);
                    $("#re-Contraseña").val(response.Result2.Contraseña);
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


function funUsuario(id, tipo, evt) {
    evt.preventDefault();
    if (tipo == 'E') {
        $.ajax({
            type: "POST",
            url: urlGeneral + "Users/Eliminar",
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
        document.getElementById("TipoUsu").disabled = true;
        $.ajax({
            type: "POST",
            url: urlGeneral + "Users/Get",
            data: "{Id: " + id + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.IsSuccess == true) {
                    $("#IdPaciente").val(response.Result.IdPaciente);
                    $("#Dni").val(response.Result.Dni);
                    $("#Nombres").val(response.Result.Nombres);
                    $("#Apaterno").val(response.Result.ApellidoPaterno);
                    $("#Amaterno").val(response.Result.ApellidoMaterno);
                    $("#Profesion").val(response.Result.Profesion);
                    $("#Direccion").val(response.Result.Direccion);
                    $("#Edad").val(response.Result.Edad);
                    $("#Sexo").val(response.Result.Sexo);
                    $("#telefono").val(response.Result.Telefono);
                    $("#FechaNacimiento").val(response.Result3.toLocaleString('en-GB'));
                    $("#Correo").val(response.Result.Correo);
                    $("#NombreUsu").val(response.Result2.NombreUsuario);
                    $("#TipoUsu").val(response.Result2.TipoUsuario);
                    $("#Contraseña").val(response.Result2.Contraseña);
                    $("#re-Contraseña").val(response.Result2.Contraseña);
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

function funDiag(id, tipo, evt) {
    evt.preventDefault();
    if (tipo == 'E') {
        $.ajax({
            type: "POST",
            url: urlGeneral + "Diagnostico/Eliminar",
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
        document.getElementById("DniPaciente").disabled = true;
        $.ajax({
            type: "POST",
            url: urlGeneral + "Diagnostico/Get",
            data: "{Id: " + id + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.IsSuccess == true) {
                    $("#IdDiagnostico").val(response.Result.IdDiagnostico);
                    $("#DniPaciente").val(response.Result.DniPaciente);
                    $("#Esquizoide").val(response.Result.Esquizoide);
                    $("#Evitativo").val(response.Result.Evitativo);
                    $("#Depresivo").val(response.Result.Depresivo);
                    $("#Dependiente").val(response.Result.Dependiente);
                    $("#Histriónico").val(response.Result.Histriónico);
                    $("#Narcisista").val(response.Result.Narcisista);
                    $("#Antisocial").val(response.Result.Antisocial);
                    $("#AgresivoSádico").val(response.Result.AgresivoSádico);
                    $("#Compulsivo").val(response.Result.Compulsivo);
                    $("#Negativista").val(response.Result.Negativista);
                    $("#Esquizotípica").val(response.Result.Esquizotípica);
                    $("#Límite").val(response.Result.Límite);
                    $("#Paranoide").val(response.Result.Paranoide);
                    $("#Ansiedad").val(response.Result.Ansiedad);
                    $("#Somatoformo").val(response.Result.Somatoformo);
                    $("#Bipolar").val(response.Result.Bipolar);
                    $("#Distímico").val(response.Result.Distímico);
                    $("#DependenciaAlcohol").val(response.Result.DependenciaAlcohol);
                    $("#DependenciaSustancias").val(response.Result.DependenciaSustancias);
                    $("#EstrésPostraumático").val(response.Result.EstrésPostraumático);
                    $("#DesordenPensamiento").val(response.Result.DesordenPensamiento);
                    $("#DepresiónMayor").val(response.Result.DepresiónMayor);
                    $("#DesordenDelusional").val(response.Result.DesordenDelusional);
                    $("#Sinceridad").val(response.Result.Sinceridad);
                    $("#DeseabilidadSocial").val(response.Result.DeseabilidadSocial);
                    $("#Devaluación").val(response.Result.Devaluación);
                    $("#Validez").val(response.Result.Validez);
                    $("#Autodestructiva").val(response.Result.Autodestructiva);
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
                    $("#textarea2").val(response.Result.Motivo);
                    $("#textarea3").val(response.Result.Tratamiento);
                    $("#textarea4").val(response.Result.Observacion);
                    $("#Diagnostico").val(response.Result.CodigoDiagnostico);
                    $("#DniPsicologo").val(response.Result.DniPsicologo);
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

