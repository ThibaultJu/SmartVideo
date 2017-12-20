<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_SmartVidéo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="RechercheFilm">
		<p> &nbsp;</p>
		<asp:Label ID="Label4" runat="server" Text="Nom à rechercher: "></asp:Label>
		<asp:TextBox ID="TextBoxIdFilm" runat="server"></asp:TextBox>
		<p> 
			&nbsp;</p>
		<asp:Button ID="ButtonRechercheFilm" runat="server" Text="Rechercher film" OnClick="ButtonRechercheFilm_Click" />
		<asp:Button ID="ButtonRechercheActor" runat="server" Text="Rechercher Acteur" OnClick="ButtonRechercheActeur_Click" />
	 </div>
	<div class="PaginationFilm">
		<p> &nbsp;</p>
		<asp:Label ID="Label1" runat="server" Text="Numéro de page: "></asp:Label>
		<asp:Label ID="LabelPage" runat="server" Text="1"></asp:Label>
		<asp:Label ID="Label2" runat="server" Text="Films par page : "></asp:Label>
		<asp:DropDownList ID="DropDownList1" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
			<asp:ListItem Text="5" Value="5" />
			<asp:ListItem Text="10" Value="10" />
			<asp:ListItem Text="25" Value="25" />
			<asp:ListItem Text="50" Value="50" />
		</asp:DropDownList>
		<p> &nbsp;</p>
		<asp:Button ID="Button1" runat="server" Text="Page précédente" OnClick="Button1_Click" />
		<asp:Button ID="Button2" runat="server" Text="Page suivante" OnClick="Button2_Click" />
	 </div>
	<%foreach (Web_SmartVidéo.ServiceReference1.FilmDTO film in this.listFilms)
      { %>
        <div class="Film">
			<h2 class="title"><a href="DetailsF.aspx?titre=<%= film.Id %>"><%= film.Title %>
				</a></h2><br / />
            <img src="http://image.tmdb.org/t/p/w185/<% =film.Posterpath %>" alt="Poster" >            
            <p></p><br />
			<p> Titre original : <%=film.Original_title %></p>
            <p>Durée du film : <%= film.Runtime %> minutes</p>
            <%int i = 0; %>
            <p>Genres : <%foreach (Web_SmartVidéo.ServiceReference1.GenreDTO genre in film.Genrelist)
                            {
                                    if (i > 0)
                                    {%>
										<%=", " %>
										
                                    <%}%>
								<%=genre.Name %><%           
								i++;
							}%>
            </p><br />

        </div>
    <%} %>
		<div class="PaginationFilm">
		<p> &nbsp;</p>
		<asp:Label ID="Label3" runat="server" Text="Numéro de page: "></asp:Label>
		<asp:Label ID="LabelPagebis" runat="server" Text="1"></asp:Label>
		<asp:Label ID="Label5" runat="server" Text="Films par page : "></asp:Label>
		<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
			<asp:ListItem Text="5" Value="5" />
			<asp:ListItem Text="10" Value="10" />
			<asp:ListItem Text="25" Value="25" />
			<asp:ListItem Text="50" Value="50" />
		</asp:DropDownList>
		<p> &nbsp;</p>
		<asp:Button ID="Button3" runat="server" Text="Page précédente" OnClick="Button1_Click" />
		<asp:Button ID="Button4" runat="server" Text="Page suivante" OnClick="Button2_Click" />
	 </div>
</asp:Content>
