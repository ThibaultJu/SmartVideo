<%@ Page Title="Disconect" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disconect.aspx.cs" Inherits="Web_SmartVidéo.Disconect" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
		<br />
		<asp:Label ID="User" runat="server" Text="Login"></asp:Label>
	</p>
	<p>
		<asp:TextBox ID="TextBox1" type="text" runat="server"></asp:TextBox>
	</p>
	<p>
		<asp:Label ID="Password" type="password" runat="server" Text="Password"></asp:Label>
	</p>
	<p>
		<input id="Password1" type="password" runat="server" /></p>
	<p>
		<asp:Button ID="Button1" runat="server" Text="Connexion" OnClick="Button1_Click" />
	</p>
</asp:Content>
