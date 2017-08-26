<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Northwind.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Northwind Traders</h1>
        
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Produtos</h2>
            <p>
                Aqui nós temos alguns produtos em nossa galeria
            </p>
            <p>
                <a class="btn btn-default" href="Produtos">Produtos &raquo;</a>
            </p>
        </div>

    </div>

</asp:Content>
