

$(document).ready(function () {
    GetAll();

});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:56584/api/Producto',
        success: function (result) { //200 OK
            $("#producto tbody").empty();
     
      
            $.each(result.Objects, function (i, producto) {

                var filas =
                    '<tr>'
                    + '<td class="text-center">'
                    + '<button class="btn btn-warning" onclick = "GetById(' + producto.IdProducto + ')">'
                    + '<span class="glyphicon glyphicon-pencil" style = "color:#FFFFFF" ></span>'
                    + '</button ></td>'
               
                    + "<td class='text-center'>" + producto.Nombre + "</td>"
                    + "<td class='text-center'>" + producto.Descripcion + "</td>"
                    + "<td class='text-center'>" + producto.PrecioUnitario + "</td>"
                    + "<td class='text-center'>" + producto.Stock + "</td>"
                    + "<td class='text-center'>" + producto.Departamento.Nombre + "</td>"
                    + "<td class='text-center'>" + producto.Departamento.Area.Nombre + "</td>"
                    + "<td class='text-center'>" + producto.Proveedor.Nombre + "</td>"


                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Delete(' + producto.IdProducto + ')">'
                    + '<span class="glyphicon glyphicon-trash" style = "color:#FFFFFF" ></span></button ></td>'
                    + "</tr>";
                $("#producto tbody").append(filas);

            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Delete(IdProducto) {
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:56584/api/Producto/' + IdProducto,
        success: function (result) {
            alert(result.correct + "Producto Eliminado");
            GetAll();
        },
        error: function (result) {
            alert('Error al eliminar.' + result.responseJSON.ErrorMessage);
        }
    });
};


function showForm() {
    $('#ModalUpdate').modal('show');

    $('#ModalUpdate').find('#formModal')[0].reset();   
    $('#btnUpdate').hide();
    $('#btnAdd').show();
   

    //$('.modal-backdrop').remove();
    //$('#modal').modal('hide');
    //$('#modal').modal('show');;
}
function hideForm() {
    $('#ModalUpdate').modal('hide');
    $(this).removeData('#ModalUpdate');
}


function GetById(IdProducto) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:56584/api/Producto/' + IdProducto,
        success: function (result) {
            $('#txtIdProducto').val(result.Object.IdProducto);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtDescripcion').val(result.Object.Descripcion);
            $('#txtPrecioUnitario').val(result.Object.PrecioUnitario);
            $('#txtStock').val(result.Object.Stock);
            $('#txtIdDepartamento').val(result.Object.Departamento.IdDepartamento);
            $('#txtIdProveedor').val(result.Object.Proveedor.IdProveedor);
            //Acceder al id Button Update Mostrar
            //Acceder al id Button Add Ocultar
            $('#ModalUpdate').modal('show');
          
            $('#btnAdd').hide();
            $('#btnUpdate').show();
            
        },
        error: function (result) {
            alert('Error en la consulta update.' + result.ErrorMessage);
        }


    });

}

function Update(producto) {
    var IdProducto = $('#txtIdProducto').val()
    var Nombre = $('#txtNombre').val()
    var Descripcion = $('#txtDescripcion').val()
    var PrecioUnitario = $('#txtPrecioUnitario').val()
    var Stock = $('#txtStock').val()
    var IdDepartamento = $('#txtIdDepartamento').val()
    var IdProveedor = $('#txtIdProveedor').val()

    var producto = {
        IdProducto: IdProducto,
        Nombre: Nombre,
        Descripcion: Descripcion,
        PrecioUnitario: PrecioUnitario,
        Stock: Stock,
        Departamento: {
            IdDepartamento: IdDepartamento,
        },
        Proveedor: {
            IdProveedor: IdProveedor
        }

    }

    $.ajax({
        type: 'PUT',
        url: 'http://localhost:56584/api/Producto/' + IdProducto,
        data: producto,
        success: function (result) {
            alert('Producto Actualizado')
            GetAll();
            hideForm();
            $('#ModalUpdate').find('#formModal')[0].reset();
         
        },
        error: function (result) {
            alert('Error en el boton update.' + result.ErrorMessage);
        }


    });

}
function Add(producto) {
    // var IdProducto = $('#txtIdProducto').val()
    var Nombre = $('#txtNombre').val()
    var Descripcion = $('#txtDescripcion').val()
    var PrecioUnitario = $('#txtPrecioUnitario').val()
    var Stock = $('#txtStock').val()
    var IdDepartamento = $('#txtIdDepartamento').val()
    var IdProveedor = $('#txtIdProveedor').val()

    var producto = {
        //  IdProducto: IdProducto,
        Nombre: Nombre,
        Descripcion: Descripcion,
        PrecioUnitario: PrecioUnitario,
        Stock: Stock,
        Departamento: {
            IdDepartamento: IdDepartamento,
        },
        Proveedor: {
            IdProveedor: IdProveedor
        }

    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:56584/api/Producto/',
        data: producto,
        success: function (result) {
            alert('Producto Agregado')
           
            GetAll();
            $('#ModalUpdate').find('#formModal')[0].reset();
            hideForm();
            
        },
        error: function (result) {
            alert('Error en el boton Agregado.' + result.ErrorMessage);
        }


    });

}

function SoloLetras(e,lbl) {
    tecla = (document.all) ? e.keyCode : e.which;
   
    // Patrón de entrada, en este caso solo acepta numeros y letras
    patron = /[A-Za-z ]/;
    tecla_final = String.fromCharCode(tecla);
    if (patron.test(tecla_final)) {
        document.getElementById(event.target.id).style.borderColor = '#008000';
       // $('#' + lbl.id).css('color', 'grey')
        $('#'+ lbl.id).text('')
       

    } else {

        document.getElementById(event.target.id).style.borderColor = '#f88067';
        tecla_final = tecla_final.replace(/[A-Za-z ]/g, '');
      
        $('#' + lbl.id).css('color', 'red')
        $('#' + lbl.id).text('Solo se aceptan letras')
    }
  
  
    return patron.test(tecla_final);
}
function SoloNumero(e,lbl) {
    tecla = (document.all) ? e.keyCode : e.which;
  
    // Patrón de entrada, en este caso solo acepta numeros
    patron = /[0-9.]/;
    tecla_final = String.fromCharCode(tecla);
 
    if (patron.test(tecla_final)) {
        document.getElementById(event.target.id).style.borderColor = '#008000';
        $('#' + lbl.id).css('color', 'green')
        //$('#' + lbl.id).css('color', 'green')
        $('#' + lbl.id).text(' ')
       
       
    } else {
        
     
        tecla_final = tecla_final.replace(/[^0-9.]/g, '');
        document.getElementById(event.target.id).style.borderColor = '#f88067';
       
       
        $('#' + lbl.id).css('color', 'red')
        $('#' + lbl.id).text('Solo se aceptan numeros')
    }
  
    return patron.test(tecla_final);

}




//function validarfor(event, lbl) {

//    var nombre = document.getElementsByName("#txtNombre").value;
//    var descripcion = document.getElementsByName("#txtDescripcion").value;
//    var precioUnitario = document.getElementsByName("#txtPrecioUnitario").value;
//    var stock = document.getElementsByName("#txtStock").value;
//    var idDepartamento = document.getElementsByName("txtIdDepartamento").value;
//    var idProveedor = document.getElementsByName("#txtIdProveedor").value;

//    var expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;


//    if (!expr.test(nombre)) {
//        $('#' + lbl.id).css('color', 'red')
//        $('#' + lbl.id).text('Ingresa un nombre')
//        return false;

//    }
//    else {
//        $('#' + lbl.id).text(' ')
//    }

//    if ((nombre == "") || (descripcion == "") || (precioUnitario == "") || (stock == "") || (idDepartamento == "") || (idProveedor == "")) {  //COMPRUEBA CAMPOS VACIOS
//        alert("Los campos no pueden quedar vacios");
//        return true;
//    }

// }


//function validaVacio(event, lbl) {
//    valor = valor.replace("&nbsp;", "");
//    valor = valor == undefined ? "" : valor;
//    if (!valor || 0 === valor.trim().length) {
//        return true;
//    }
//    else {
//        return false;
//    }
//}

function resetColor() {

}