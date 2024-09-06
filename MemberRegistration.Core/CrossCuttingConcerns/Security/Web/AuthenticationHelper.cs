using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;

namespace MemberRegistration.Core.CrossCuttingConcerns.Security.Web
{
    // This class is used to create an authentication cookie for the user.
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id, string username, string email, DateTime expiration,
            string[] roles, bool rememberMe, string firstName, string lastName)
        {
            // This is the authentication ticket that will be used to create the authentication cookie.
            var authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, expiration, rememberMe,
                CreateAuthTags(email, roles, firstName, lastName, id));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder();//This is a string builder to create a string that will be used as the authentication tag.
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)//This loop is used to add the roles to the string.
            {
                stringBuilder.Append(roles[i]);
                if (i < roles.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            return stringBuilder.ToString();
        }
    }
}
