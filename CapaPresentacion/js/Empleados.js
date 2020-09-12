var tabla,data;
function addRowDT(data) {
    tabla = $("#tbl_Empleados").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].IdEmpleado,
            data[i].Nombre,
            data[i].Apellidos,
            data[i].NumeroDocumento,
            data[i].Sexo,
            data[i].Telefono,
            data[i].Direccion,
            data[i].Email,
            data[i].Estado
        ]);
        //tabla.row.Add({

        //})
        //o
        //fnAddData
    }
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "GestionarEmpleado.aspx/ListarEmpleados",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownerror) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownerror);
        },
        success: function (data) {
            console.log(data.d);
            addRowDT(data.d);
        }
    });
}

//LLAMANDO A LA FUNCION DE AJAX AL CARGAR EL DOCUMENTO
sendDataAjax();

