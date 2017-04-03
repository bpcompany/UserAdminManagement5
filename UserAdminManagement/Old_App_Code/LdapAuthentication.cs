using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

/// <summary>
/// Summary description for LdapAuthentication
/// </summary>
public class LdapAuthentication
{
    private string _path;
    public string RequestorFullName { get; set; }
	public LdapAuthentication( string path)
	{
        _path = path;
	}
    public bool IsAuthenticated(string domain, string username, string pwd)
    {
        string domainAndUsername = domain + @"\" + username;
        DirectoryEntry entry = new DirectoryEntry(_path,
                                                   domainAndUsername,
                                                     pwd);
        try
        {
            // Bind to the native AdsObject to force authentication.
            //Object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null != result)
            {
                _path = result.Path;
                this.RequestorFullName = (String)result.Properties["cn"][0];
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
        
    }
    
}