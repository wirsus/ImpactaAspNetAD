<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Northwind.WebForms.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Northwind - Produtos</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <asp:Label Text="Pesquisar por:" runat="server" CssClass="label label-default" />
                <br />
                <asp:RadioButtonList runat="server" ID="criterioPesquisaRadioButtonList" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="criterioPesquisaRadioButtonList_SelectedIndexChanged">
                    <asp:ListItem Text="Categoria" Value="0" Selected="True" />
                    <asp:ListItem Text="Fornecedor" Value="1" />
                </asp:RadioButtonList>
                <br />

                <asp:MultiView ActiveViewIndex="0" ID="criterioPesquisaMultiView" runat="server">
                    <asp:View ID="categoriaView" runat="server">
                        <asp:DropDownList ID="categoriaDropDownList" DataTextField="CategoryName" DataValueField="CategoryID" AppendDataBoundItems="true" DataSourceID="categoriaObjectDataSource" runat="server">
                            <asp:ListItem Text="Selecione uma categoria..." Value="0" />
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="categoriaObjectDataSource" TypeName="Northwind.Repositorios.SqlServer.Ado.CategoriaRepositorio" SelectMethod="Selecionar" runat="server" />
                    </asp:View>
                    <asp:View ID="fornecedorView" runat="server">
                        <asp:DropDownList ID="fornecedorDropDownList" DataTextField="CompanyName" DataValueField="SupplierID" AppendDataBoundItems="true" runat="server">
                            <asp:ListItem Text="Selecione um Fornecedor..." Value="0" />
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="fornecedorObjectDataSource" TypeName="Northwind.Repositorios.SqlServer.Ado.FornecedorRepositorio" SelectMethod="Selecionar" runat="server" />
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>


        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="produtosGridView" AutoGenerateColumns="false" Width="100%" runat="server">
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Nome" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Preço" />
                        <asp:BoundField DataField="UnitsInStock" HeaderText="Estoque" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="produtoPorCategoriaObjectDataSource" TypeName="Northwind.Repositorios.SqlServer.Ado.ProdutoRepositorio" SelectMethod="SelecionarPorCategoria" runat="server" >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="categoriaDropDownList" PropertyName="SelectedValue" Name="categoriaID" Type="Int32"/>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="produtoPorFornecedorObjectDataSource" TypeName="Northwind.Repositorios.SqlServer.Ado.ProdutoRepositorio" SelectMethod="SelecionarPorFornecedor" runat="server" >
                     <SelectParameters>
                        <asp:ControlParameter ControlID="fornecedorDropDownList" PropertyName="SelectedValue" Name="fornecedorID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>


            </div>
        </div>

    </div>
</asp:Content>
