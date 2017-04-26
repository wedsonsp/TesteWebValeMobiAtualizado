<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exclusao.aspx.cs" Inherits="CRUD.Exclusao" %>

<!DOCTYPE html>

<html lang="pt-br" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Excluir</title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="CSS/estilo.css" />
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
                <div>
                    <div>
                        <asp:Label Text="" runat="server" ID="lblMsg" />
                    </div>
                    <div>
                        <asp:Button Text="Sim" runat="server" ID="btnSim" OnClick="btnSim_Click" Class="btn btn-danger btn-lg" />
                        <asp:Button Text="Não" runat="server" ID="btnNao" OnClick="btnNao_Click" Class="btn btn-warning btn-lg" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
