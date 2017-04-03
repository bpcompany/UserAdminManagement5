using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Web.Security;
using System.Configuration;
public partial class BPSLogin : System.Web.UI.Page
{
    LdapAuthentication adAuth = new LdapAuthentication(ConfigurationManager.AppSettings["ldap_Url"]);
    UserAdminModel userAdmin = new UserAdminModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnsignin.Click += new EventHandler(btnsignin_Click);
    }

    protected void btnsignin_Click(object sender, EventArgs e)
    {
        Session["user_authenticated"] = false;
        Session["AdminUser"] = false;
        string ldap_authentication = ConfigurationManager.AppSettings["ldap_authentication"];
        if (ldap_authentication.ToUpper() == "OFF")
        {
            XmlDocument userlist = new XmlDocument();
            string _xmlFilePath = Server.MapPath("~/xml/UserAuthentication.xml");
            userlist.Load(_xmlFilePath);
            XmlNodeList usernodelist = userlist.SelectNodes("/users/user");
            foreach (XmlNode usernode in usernodelist)
            {
                string username = usernode.Attributes["username"].Value.ToString().Trim();
                string password = usernode.Attributes["password"].Value.ToString().Trim();
                string full_name = usernode.Attributes["fullname"].Value.ToString().Trim();
                if (username.Equals(login_userid.Value, StringComparison.CurrentCultureIgnoreCase) && password.Equals(login_password.Value))
                {
                    Session["user_authenticated"] = true;
                    Session["username"] = username;
                    Session["full_name"] = full_name;
                }

            }
            if ((bool)Session["user_authenticated"])
            {
                Session["AdminUser"] = userAdmin.CheckAdminUserExistence(Session["username"].ToString());
            }
        }
        else if (adAuth.IsAuthenticated("bp", login_userid.Value, login_password.Value))
        {
            Session["user_authenticated"] = true;
            Session["username"] = login_userid.Value;
            Session["full_name"] = adAuth.RequestorFullName;
        }

        if ((bool)Session["user_authenticated"])
        {
            Response.Redirect("BPS Crashes.aspx");
        }
        else
        {
            string script = "ShowModal();";
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "ShowModal", getjQueryCode(script), true);

        }
    }

    private string getjQueryCode(string jsCodetoRun)
    {
        StringBuilder sb = new StringBuilder("");
        sb.AppendLine("$(document).ready(function() {");
        sb.AppendLine(jsCodetoRun);
        sb.AppendLine("});");
        return sb.ToString();
    }
}
