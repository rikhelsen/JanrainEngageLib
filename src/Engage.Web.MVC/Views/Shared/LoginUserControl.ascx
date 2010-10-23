<%@ Import Namespace="Engage.Web.MVC.Extensions"%>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("Sign Out", "SignOut", "EngageAuthentication")%> ]
<%
    }
    else {
%> 
        [ <a class="Engagenow" onclick="return false;" href="https://Engagetest.Engagenow.com/openid/v2/signin?token_url=<%=Html.EngageTokenUrl() %>">Sign In</a> ]
        <script src="https://Engagenow.com/openid/v2/widget" type="text/javascript"></script>
        <script type="text/javascript">
            EngageNOW.token_url = '<%=Html.EngageTokenUrl() %>';
            EngageNOW.realm = '<%=Html.EngageRealm() %>';
            EngageNOW.overlay = true;
        </script>
<%
    }
%>



