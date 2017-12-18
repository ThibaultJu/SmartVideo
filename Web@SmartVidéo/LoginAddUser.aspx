<%@ Page Title="LoginAddUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginAddUser.aspx.cs" Inherits="Web_SmartVidéo.LoginAddUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
		<br />
		<asp:Label ID="User" runat="server" Text="Login"></asp:Label>
	</p>
	<p>
		<asp:TextBox ID="TextBoxLogin" type="text" runat="server"></asp:TextBox>
	</p>
	<p>
		<asp:Label ID="Password" type="password" runat="server" Text="Password"></asp:Label>
	</p>
	<p>
		<input id="Password1" type="password" runat="server" /></p>
	<p>
		<asp:Label ID="Label1" runat="server" Text="Pseudo"></asp:Label>
	</p>
	<p>
		<asp:TextBox ID="TextBoxPseudo" runat="server"></asp:TextBox>
	</p>
	<p>
		<asp:Label ID="Label2" runat="server" Text="Carte"></asp:Label>
	</p>
	<p>
		<asp:TextBox ID="TextBoxCarte" runat="server"></asp:TextBox>
	</p>
	<p>
		&nbsp;</p>
	<p>
		<asp:Button ID="ButtonAdd" runat="server" Text="Ajouter utilisateur" OnClick="ButtonAdd_Click" />
	</p>
</asp:Content>
