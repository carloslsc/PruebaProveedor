var dataTable;

$(document).ready(
    function () {
        cargarDatatable();
    }
);

function cargarDatatable() {
    dataTable = $("#tblProductos").DataTable({
        "ajax": {
            "url": "/producto/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "codigo"},
            { "data": "descripcion"},
            { "data": "unidad"},
            { "data": "costo" },
            { "data": "idProveedorNavigation.razonSocial" }
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}