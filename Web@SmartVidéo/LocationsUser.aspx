<%@ Page Title="LocationsUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LocationsUser.aspx.cs" Inherits="Web_SmartVidéo.LocationsUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Smart Vidéo</h3>

    <div class="Film">
        <p>Genres : <%foreach (Web_SmartVidéo.ServiceReference1.LocationsFilm genre in listFilms)
                        {%>
							<%=genre.idFilm + genre.DateDébut.ToString() + genre.DateFin.ToString() %><%           
						}%>
        </p>
    </div>
</asp:Content>
