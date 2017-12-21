<%@ Page Title="DetailsF" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailsF.aspx.cs" Inherits="Web_SmartVidéo.DetailsF" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Smart Vidéo</h3>

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
		<%i = 0; %>
		<p>Acteurs : <%foreach (Web_SmartVidéo.ServiceReference1.ActeurDTO acteur in film.Acteurlist)
                        {
                                if (i > 0)
                                {%>
									<%=", " %>
										
                                <%}%>
							<%=acteur.Name %><%           
							i++;
						}%>
        </p><br />
				<%i = 0; %>
		<p>Realisateurs : <%foreach (Web_SmartVidéo.ServiceReference1.RealisateurDTO rea in film.Realisateurlist)
                        {
                                if (i > 0)
                                {%>
									<%=", " %>
										
                                <%}%>
							<%=rea.Name %><%           
							i++;
						}%>
        </p>
		<asp:Button ID="ButtonTrailer" runat="server" Text="Voir trailer" OnClick="ButtonTrailer_Click" />
		<asp:Button ID="ButtonLocationFilm" runat="server" Text="Location du Film" OnClick="ButtonLocationFilm_Click"/>
		<br />

    </div>
</asp:Content>
