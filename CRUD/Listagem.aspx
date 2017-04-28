<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="CRUD.Listagem" %>

<!DOCTYPE html>

<html lang="pt-br" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Listagem de Produtos</title>
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
                                Data: <%=cadastro.ToLongDateString()%>  Hora: <%=cadastro.ToLongTimeString()%>
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

                        <h3 class="well">Listagem de Produtos</h3>
                        <br />
                        <div>
                            <a href="Logout.aspx">
                                <div class="btn btn-danger btn-lg">Logout</div>
                            </a>
                        </div>
                        <div>
                            <a href="Cadastro.aspx">
                                <div class="btn btn-success btn btn-lg">Criar novo...</div>
                            </a>
                        </div>
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover table table-condensed">
                                <thead>
                                    <tr>
                                        <th class="well">Tipo de Mercadoria</th>
                                        <th class="well">Nome</th>
                                        <th class="well">Quantidade</th>
                                        <th class="well">Preço</th>
                                        <th class="well">Tipo de Negócio</th>
                                        <th class="well">Valor Total de da cada Produto por unidade</th>
                                        <th class="well">Data de Cadastro</th>
                                        <th class="well">Data de Atualização</th>
                                    </tr>
                                    <%  int cont = 0;

                                        while (cont < produtos.Count)
                                        {
                                    %>
                                </thead>
                                <tbody class="listagem">
                                    <tr>
                                        <td class="listagem"><%=produtos[cont].TipoMercadoria %></td>
                                        <td class="listagem"><%=produtos[cont].Nome %></td>
                                        <td class="listagem"><%=produtos[cont].Quantidade %></td>
                                        <td class="listagem"><%=produtos[cont].PrecoStr %></td>
                                        <td class="listagem"><%=produtos[cont].TipoNegocio %></td>
                                        <!-- Chama o acessador SomaProdutosStr a partir da Classe Produto-->
                                        <td class="listagem"><%=produtos[cont].SomaProdutosStr%></td>
                                        <td class="listagem"><%=produtos[cont].DataCadastro %></td>
                                        <td class="listagem"><%=produtos[cont].DataAtualizacao %></td>

                                        <td><a href="Edicao.aspx?id=<%=produtos[cont].Id %>">
                                            <div class="btn btn-default btn-lg">Editar</div>
                                        </a></td>
                                        <td><a href="Exclusao.aspx?id=<%=produtos[cont].Id %>">
                                            <div class="btn btn-danger btn-lg">Excluir</div>
                                        </a></td>
                                    </tr>

                                    <%      cont = cont + 1;
                                        }
                                    %>
                                </tbody>
                            </table>
                        </div>
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover table table-condensed">
                                <tr>
                                    <th class="well">Quantidade de Produtos</th>
                                    <th class="well">Quantidade Total de Produtos</th>
                                    <th class="well">Valor Total de Produtos</th>
                                    <th class="well">Valor Total de Produtos por unidade</th>

                                </tr>
                                <tr>

                                    <td class="listagem"><%=cont %></td>
                                    <td class="listagem">R$ <%=somaQuantidade.ToString("N") %></td>
                                    <td class="listagem">R$ <%=somaValorproduto.ToString("N") %></td>
                                    <td class="listagem">R$ <%=somaValorprodutoUnidade.ToString("N") %></td>

                                </tr>


                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
