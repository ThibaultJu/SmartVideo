<%@ Page Title="Statistiques" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Statistiques.aspx.cs" Inherits="Web_SmartVidéo.Statistiques" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Smart Vidéo</h3>

    <div class="Film">

        <p><%foreach (Web_SmartVidéo.ServiceReference1.StatistiquesDTO stats in this.listStatistiques)
				{%>

					<%if (stats.Type.Equals("Film    "))
						{ %>
						<%this.film = this.aC.GetFilm(stats.IdRequete); %>
						<img src="http://image.tmdb.org/t/p/w185/<% =film.Posterpath %>" alt="Mountain View" >
						<h2 class="title"><a href="DetailsFilms.aspx?titre=<%= film.Title %>"><%= film.Title %></a></h2><br / />
						<p>Nombre de recherches effectuées : <%=stats.NbRecherche %></p><br />
						<br />
						<br />
						<br />
						<br />
					<%}
						else
						{%>
								<%this.actor = this.aC.RechercheActorByID(stats.IdRequete); %>
								<p>Acteur : <%=actor.Name %></p><br />
								<p>Nombre de recherches effectuées : <%=stats.NbRecherche %></p><br />
								<br />
								<br />
								<br />
								<br />
						<%}
				}%>
        </p>

    </div>
</asp:Content>
