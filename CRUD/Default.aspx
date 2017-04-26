<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD.Default" %>

<!DOCTYPE html>

<html lang="pt-br" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Sistema para Cadastro de Mercadorias</title>
    <link type="text/css" rel="stylesheet" href="Content/bootstrap.css" />
    <link type="text/css" rel="stylesheet" href="CSS/estilo.css" />
    <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" /> 
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>   
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="well">
                <table>
                    <tr class="logo">
                        <div class="data">
                            <p>
                                Data: <%=data.ToLongDateString()%>  Hora: <%=data.ToLongTimeString()%>
                            </p>
                        </div>
                        <div class="criador">
                            Criado por: Wedson Souza
                        </div>
                    </tr>
                    <tr class="logo2">
                    </tr>
                </table>
                <div class="span10 offset1">
                    <div class="row">
                        <div>
                            <h3 class="well">Faça o seu login no Sistema</h3>
                            <br />
                            <label for="txtUser">Usuário</label>
                            <asp:TextBox runat="server" ID="txtUser" />
                        </div>
                        <div>
                            <label for="txtPass">Senha</label>
                            <asp:TextBox runat="server" ID="txtPass" TextMode="Password" />
                        </div>
                        <div>
                            <asp:Label Text="" runat="server" ID="lblMsg" />
                        </div>
                        <div>
                            <asp:Button Text="Login" runat="server" ID="btnLogin" OnClick="btnLogin_Click" Class="btn btn-success btn btn-lg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
