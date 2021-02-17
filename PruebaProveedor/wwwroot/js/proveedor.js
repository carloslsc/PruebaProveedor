var dataTable;

$(document).ready(
    function () {
        cargarDatatable();
    }
);

function cargarDatatable() {
    dataTable = $("#tblProveedores").DataTable({
        "ajax": {
            "url": "/Proveedor/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "codigo", "width": "5%" },
            { "data": "razonSocial", "width": "50%" },
            { "data": "rfc", "width": "20%" },
            {
                "data": "idProveedor",
                "render": function (data) {
                    return `<div class='text-center'>
                                <a href='/Proveedor/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='fas fa-edit'></i> Editar
                                </a>
                                &nbsp;
                                <a onclick='Delete("/Proveedor/Delete/${data}")' class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-trash-alt'></i> Borrar
                                </a>
                            </div>
                    `;
                },
                "width": "30%"
            },
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}

function Delete(url) {
    $.ajax({
        type: "POST",
        url: "/Proveedor/VerificacionDelete/" + url.substring(18),
        success: function (data) {
            if (data.success) {
                $.ajax({
                    type: "DELETE",
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            dataTable.ajax.reload();
                        }
                        else{
                            toastr.error(data.message);
                        }
                    }
                });
            }
            else {
                swal({
                    title: "¿Esta seguro de borrar?",
                    text: "Este contenido no se puede recuperar!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6855",
                    confirmButtonText: "Si, ¡borrar!",
                    closeOnconfirm: true
                }, function () {
                    $.ajax({
                        type: "DELETE",
                        url: url,
                        success: function (data) {
                            if (data.success) {
                                toastr.success(data.message);
                                dataTable.ajax.reload();
                            }
                            else {
                                toastr.error(data.message);
                            }
                        }
                    });
                });
                
            }
        }
    });
}