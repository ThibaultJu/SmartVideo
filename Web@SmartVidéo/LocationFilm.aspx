<%@ Page Title="DetailsF" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LocationFilm.aspx.cs" Inherits="Web_SmartVidéo.LocationFilm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%: Title %></h2>
    <h3>Smart Vidéo</h3>
	<p>
		<asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
	</p>
	<p>
		<asp:Label ID="Label2" runat="server" Text="Durée :"></asp:Label>
		<asp:TextBox ID="TextBoxDuree" runat="server" Text="3"></asp:TextBox>
		<asp:Label ID="Label3" runat="server" Text="mois"></asp:Label>
	</p>
	<p>
		<asp:Button ID="Button1" runat="server" Text="Louer film" OnClick="Button1_Click" />
	</p>

    </asp:Content>


