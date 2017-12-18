<%@ Page Title="InfoUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoUser.aspx.cs" Inherits="Web_SmartVidéo.InfoUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
		&nbsp;</p>
	<p>
		Détails du profil:
		<br />
		<asp:Label ID="User" runat="server" Text="Email"></asp:Label>
	&nbsp;:
		<asp:TextBox ID="TextBoxEmail" type="text" runat="server"></asp:TextBox>
	</p>
	<p>
		<asp:Label ID="Label1" runat="server" Text="Pseudo"></asp:Label>
	&nbsp;:<asp:TextBox ID="TextBoxPseudo" type="text" runat="server"></asp:TextBox>
	</p>
	<p>
		<asp:Label ID="Password" type="password" runat="server" Text="Password"></asp:Label>
	&nbsp;:
		<asp:TextBox ID="TextBoxPassword" type="text" runat="server"></asp:TextBox>
	</p>
	<p>
		<asp:Label ID="Label2" runat="server" Text="Numéro de carte"></asp:Label>
&nbsp;:<asp:TextBox ID="TextBoxCarte" type="text" runat="server"></asp:TextBox>
	</p>
	<p>
		<asp:Button ID="ButtonDeco" runat="server" Text="Déconnexion" OnClick="Button1_Click" Width="111px" />
		<asp:Button ID="ButtonModif" runat="server" OnClick="ButtonModif_Click" Text="Modifier" Width="107px" />
	</p>
</asp:Content>
