using System;
using System.Web.Mvc;

namespace Engage.Web.MVC.Extensions
{
    public static class EngageHtmlExtensions
    {
        public static string EngageTokenUrl(this HtmlHelper htmlHelper)
        {
            throw new Exception("You need to supply the full callback url. Localhost is fine for the example application, just remove this exception.");
            //TODO: Return the full url to the action that handles the Engage token response
            return "http://localhost:1291/EngageAuthentication/HandleResponse";
        }

        public static string EngageRealm(this HtmlHelper htmlHelper)
        {
            throw new Exception("Once you have set your realm value, this exception can then be removed.");
            //TODO: Get the realm value from your Engage account configuration - https://Engagenow.com/account
            return "your.Engage.realm";            
        }
    }
}