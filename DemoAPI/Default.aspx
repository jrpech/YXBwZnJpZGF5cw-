<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoAPI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pruebas</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server" class="container">
        <div class="row">
            <div class="col-sm-3">
                <label for="txtNombre">Nombre</label>
                <input type="text" name="txtNombre" id="txtNombre" class="form-control input-sm" />
            </div>
            <div class="col-sm-3">
                <label for="txtFechaNac">Fecha Nacimiento</label>
                <input type="text" name="txtFechaNac" id="txtFechaNac" class="form-control input-sm" />
            </div>
            <div class="col-sm-3">
                <label for="txtCorreo">Correo</label>
                <input type="text" name="txtCorreo" id="txtCorreo" class="form-control input-sm" />
            </div>
            <div class="col-sm-3">
                <label for="txtPass">Contraseña</label>
                <input type="text" name="txtPass" id="txtPass" class="form-control input-sm" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-1">
                <input type="button" id="btnGuardar" value="Guardar" class="btn btn-sm btn-block btn-primary" />
            </div>
        </div>
    </form>
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            function CreateUser(r) {

                var usuario = new Object();
                usuario.nombre = $('#txtNombre').val();
                usuario.correo = $('#txtCorreo').val();
                usuario.Password = $('#txtPass').val();
                usuario.FechaNacimiento = $('#txtFechaNac').val();
                var user = JSON.stringify(person);

                var url = '/acceso/usuario';
                $.ajax({
                    url: url,
                    type: 'POST',
                    data: user,
                    contentType: "application/json;chartset=utf-8",
                    statusCode: {
                        201: function () {
                            alert('Person was updated');
                        },
                        400: function () {
                            ClearForm();
                            alert('Error');
                        }
                    }
                });
            }
        }
    </script>
</body>
</html>
