<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Northwind.WebForms.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Northwind - Produtos</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <asp:Label Text="Pesquisar por:" runat="server" CssClass="label label-default" />
                <br />
                <asp:RadioButtonList runat="server" ID="criterioPesquisaRadioButtonList" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Categoria" Value="0" Selected="True" />
                    <asp:ListItem Text="Fornecedor" Value="1" />
                </asp:RadioButtonList>

                <asp:MultiView ActiveViewIndex="0" ID="criterioPesquisaMultiView" runat="server">
                    <asp:View ID="categoriaView" runat="server">
                        <asp:DropDownList ID="categoriaDropDownList" DataTextField="CategoryName" DataValueField="CategoryID" AppendDataBoundItems="true" DataSourceID="categoriaObjectDataSource" runat="server">
                            <asp:ListItem Text="Selecione uma categoria..." Value="0" />
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="categoriaObjectDataSource" TypeName="Northwind.Repositorios.SqlServer.Ado.CategoriaRepositorio" SelectMethod="Selecionar" runat="server" />
                    </asp:View>
                    <asp:View ID="fornecedorView" runat="server"></asp:View>
                </asp:MultiView>


            </div>
        </div>

    </div>
</asp:Content>
