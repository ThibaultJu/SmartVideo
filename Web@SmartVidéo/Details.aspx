<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Web_SmartVidéo.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<%foreach (Web_SmartVidéo.ServiceReference1.FilmDTO film in this.listFilms)
      { %>
        <div class="Film">
            <img src="http://image.tmdb.org/t/p/w185/<% =film.Posterpath %>" alt="Poster" >
            <h2 class="title"><a href="Details.aspx?titre=<%= film.Title %>"><%= film.Title %></a></h2><br / />
            <p> Titre original : <%=film.Original_title %></p><br />
            <p>Durée du film : <%= film.Runtime %> minutes.</p><br />
            <%int i = 0; %>
            <p>Acteurs : <%foreach (Web_SmartVidéo.ServiceReference1.ActeurDTO acteur in film.Acteurlist)
                            {
                                    if (i < 12)
                                    {%>
                                    <%=acteur.Name + "(" + acteur.Character + ")" + ", " %>
                                    <%i++; %>
                                    <%}
                            }%>
            </p><br />

        </div>
    <%} %>

</asp:Content>
