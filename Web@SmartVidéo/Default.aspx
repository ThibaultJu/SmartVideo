<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_SmartVidéo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="RechercheFilm">
		<p> </p>
	 </div>
	<%foreach (Web_SmartVidéo.ServiceReference1.FilmDTO film in this.listFilms)
      { %>
        <div class="Film">
			<h2 class="title"><a href="DetailsF.aspx?titre=<%= film.Title %>"><%= film.Title %></a></h2><br / />
            <img src="http://image.tmdb.org/t/p/w185/<% =film.Posterpath %>" alt="Poster" >            
            <p></p><br />
			<p> Titre original : <%=film.Original_title %></p>
            <p>Durée du film : <%= film.Runtime %> minutes.</p>
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

</asp:Content>
