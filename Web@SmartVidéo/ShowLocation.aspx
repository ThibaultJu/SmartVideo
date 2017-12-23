<%@ Page Title="ShowLocation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowLocation.aspx.cs" Inherits="Web_SmartVidéo.ShowLocation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Smart Vidéo</h3>

    <div class="Film">

        <p><%foreach (Web_SmartVidéo.ServiceReference1.LocationDTO loc in this.listLocations)
				{%>

					<%if (loc.DateFin.CompareTo(DateTime.Today) > 0)
					{ %>
						<%this.film = this.aC.GetFilm(loc.IdFilm); %>
						<img src="http://image.tmdb.org/t/p/w185/<% =film.Posterpath %>" alt="Mountain View" >
						<h2 class="title"><a href="DetailsFilms.aspx?titre=<%= film.Title %>"><%= film.Title %></a></h2><br / />
						<p>Location effectuée le : <%=loc.DateDebut.Date.ToShortDateString() %></p><br />
						<p>Ce film est disponible jusqu'au <%=loc.DateFin.Date.ToShortDateString() %></p><br />
						<br />
						<br />
						<br />
						<br />
					<%}      
				}%>
        </p>

    </div>
</asp:Content>
