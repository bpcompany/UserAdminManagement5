using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
//using LDAP;

/// <summary>
/// Summary description for ClassMethods
/// </summary>
public class UserAdminModel
{

        string sqlconnectionstring = ConfigurationManager.ConnectionStrings["UserAdminConnectionString"].ToString();
        SqlConnection sqlconn;
        SqlCommand sqlcmd;
        public string RequestorName { get; set; }
        public string RequestorEmail { get; set; }
    /// <summary>
    /// Get All applications names
    /// </summary>
    /// <returns></returns>
        public IEnumerable<ApplicationMaster> GetAllApplications()
        {
            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetAllApplications;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            List<ApplicationMaster> Lstmenu = new List<ApplicationMaster>();
            while (returnLst.Read())
            {
                ApplicationMaster m = new ApplicationMaster();
                m.AppID = (int)returnLst["AppID"];
                m.AppName = returnLst["AppName"].ToString();
                Lstmenu.Add(m);
            }

            return (Lstmenu);

        }
    /// <summary>
    /// Get All Applications details
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
        public int GetAllApplications(int ID)
        {
            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetAllApplications;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            ApplicationMaster objAM = new ApplicationMaster();
            while (returnLst.Read())
            {
                objAM.AppID = Convert.ToInt16(returnLst["AppID"]);
            }
            sqlconn.Close();
            return objAM.AppID;
        }
        public int GetAppID(int ID)
        {
            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetAllApplications;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ID", ID);
            sqlcmd.Parameters.AddWithValue("@AppOrRole", GlobalConstant.GetAppID);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();

            int AppID = 0;
            while (returnLst.Read())
            {
                AppID = Convert.ToInt16(returnLst["AppID"]);
            }
            sqlconn.Close();
            return AppID;
        }
        public int GetAllApplications(int ID, int AppOrRole)
        {
            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetAllApplications;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ID", ID);
            sqlcmd.Parameters.AddWithValue("@AppOrRole", AppOrRole);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();

            int RoleID = 0;
            while (returnLst.Read())
            {
                RoleID = Convert.ToInt16(returnLst["RoleID"]);
            }
            sqlconn.Close();
            return RoleID;
        }
        /// <summary>
        /// Fetches the LADP details for current login user
        /// </summary>
        /// <returns></returns>
        //public bool GetUserDetailsFromLDAP()
        //{
            //LDAP.LDAP ldapConnection = new LDAP.LDAP();
            //string StampUserId = (Thread.CurrentPrincipal.Identity).Name;
            //int start = StampUserId.IndexOf("\\");
            //StampUserId = StampUserId.Substring(start + 1).ToString();
            //ldapConnection.SetLdapConnection(StampUserId, LDAPConfiguration.GetResourceName("LDAP_CONNECTION"));
            //this.RequestorName = ldapConnection.LastName + ", " + ldapConnection.GivenName;
            //this.RequestorEmail = ldapConnection.Email;
            //return true;
        //}
    /// <summary>
    /// Get Role  from the Application 
    /// </summary>
    /// <param name="AppID"></param>
    /// <returns></returns>
        public IEnumerable<ApplicationRoles> GetRole(int AppID, string NewAccess)
        {
            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetApplicationAccessDetails;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@AppID", AppID);
            sqlcmd.Parameters.AddWithValue("@RequestType", NewAccess);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            ConStringAndSP conStrSP = new ConStringAndSP();
            while (returnLst.Read())
            {
                conStrSP.ConnString = returnLst["ConnString"].ToString();
                conStrSP.StoredProcedure = returnLst["StoredProcedure"].ToString();
            }
            sqlconn.Close();
            sqlconn = new SqlConnection(conStrSP.ConnString);
            sqlconn.Open();
            string appSP = conStrSP.StoredProcedure;
            sqlcmd = new SqlCommand(appSP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader appRoleLst = sqlcmd.ExecuteReader();
            List<ApplicationRoles> Lstmenu = new List<ApplicationRoles>();
            while (appRoleLst.Read())
            {
                ApplicationRoles m = new ApplicationRoles();
                m.RoleID = (int)appRoleLst["RoleID"];
                m.AppID = AppID;
                m.RoleName = appRoleLst["RoleName"].ToString();
                Lstmenu.Add(m);
            }
            sqlconn.Close();
            return (Lstmenu);

        }
        public IEnumerable<ApplicationRoles> GetApprovalMatrixsRole(int AppID)
        {
            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetApprovalMatrixs;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@AppID", AppID);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            List<ApplicationRoles> Lstmenu = new List<ApplicationRoles>();
            while (returnLst.Read())
            {
                ApplicationRoles m = new ApplicationRoles();
                m.RoleID = (int)returnLst["RoleID"];
                Lstmenu.Add(m);
            }
            sqlconn.Close();
            return (Lstmenu);

        }
        public IEnumerable<ApplicationMatrix> GetApplicationMatrixdata(string NTID)
        {

            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetApprovalMatrixs;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@NTID", NTID);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            List<ApplicationMatrix> Lstmenu = new List<ApplicationMatrix>();
            while (returnLst.Read())
            {
                ApplicationMatrix m = new ApplicationMatrix();
                m.ID = (int)returnLst["ID"];
                m.AppID = (int)returnLst["AppID"];
                m.RoleID = (int)returnLst["RoleID"];
                m.AppName = returnLst["AppName"].ToString();
                m.RoleName = returnLst["RoleName"].ToString();
                m.ApproverNTID = returnLst["ApproverNTID"].ToString();
                m.ApproverName = returnLst["ApproverName"].ToString();
                m.ApproverEmail = returnLst["ApproverEmailID"].ToString();

                Lstmenu.Add(m);
            }

            return (Lstmenu);

        }

        public bool CheckUserAppRoleRequest(string userNTID, int appID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                string SP = GlobalConstant.USP_GetApplicationAccessDetails;
                sqlcmd = new SqlCommand(SP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@AppID", appID);
                sqlcmd.Parameters.AddWithValue("@RequestType", GlobalConstant.UserExist);
                sqlconn.Open();
                SqlDataReader returnLst = sqlcmd.ExecuteReader();
                ConStringAndSP conStrSP = new ConStringAndSP();
                while (returnLst.Read())
                {
                    conStrSP.ConnString = returnLst["ConnString"].ToString();
                    conStrSP.StoredProcedure = returnLst["StoredProcedure"].ToString();
                }
                sqlconn.Close();
                sqlconn = new SqlConnection(conStrSP.ConnString);
                string appSP = conStrSP.StoredProcedure;
                sqlcmd = new SqlCommand(appSP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@UserNTID", userNTID);
                sqlconn.Open();
                return (int)sqlcmd.ExecuteScalar() != 1 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUserExistence(string userNTID, int appID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string userExistSP = GlobalConstant.USP_CheckUserExistance;
                sqlcmd = new SqlCommand(userExistSP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@UserNTID", userNTID);
                sqlcmd.Parameters.AddWithValue("@AppID", appID);
                return (int)sqlcmd.ExecuteScalar() != 1 ? false : true;
               // if (result!=1)
               // {
               //   //  sqlconn.Close();
               //     string SP = GlobalConstant.USP_GetApplicationAccessDetails;
               //     sqlcmd = new SqlCommand(SP, sqlconn);
               //     sqlcmd.CommandType = CommandType.StoredProcedure;
               //     sqlcmd.Parameters.AddWithValue("@AppID", appID);
               //     sqlcmd.Parameters.AddWithValue("@RequestType", GlobalConstant.UserExist);
               //     sqlconn.Open();
               //     SqlDataReader returnLst = sqlcmd.ExecuteReader();
               //     ConStringAndSP conStrSP = new ConStringAndSP();
               //     while (returnLst.Read())
               //     {
               //         conStrSP.ConnString = returnLst["ConnString"].ToString();
               //         conStrSP.StoredProcedure = returnLst["StoredProcedure"].ToString();
               //     }
               //     sqlconn.Close();
               //     sqlconn = new SqlConnection(conStrSP.ConnString);
               //     string appSP = conStrSP.StoredProcedure;
               //     sqlcmd = new SqlCommand(appSP, sqlconn);
               //     sqlcmd.CommandType = CommandType.StoredProcedure;
               //     sqlcmd.Parameters.AddWithValue("@UserNTID", userNTID);
               //     sqlconn.Open();
               //     return (int)sqlcmd.ExecuteScalar()!=1?false:true;
               //// }
               //// return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CheckAdminUserExistence(string userNTID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string AdminUserExistSP = GlobalConstant.USP_CheckAdminUserExistance;
                sqlcmd = new SqlCommand(AdminUserExistSP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@UserNTID", userNTID);
                return (int)sqlcmd.ExecuteScalar() != 1 ? false : true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool DeleteUserRolesInApplication(int AppID, string roleIDList, string userNTID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string SP = GlobalConstant.USP_GetApplicationAccessDetails;
                sqlcmd = new SqlCommand(SP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@AppID", AppID);
                sqlcmd.Parameters.AddWithValue("@RequestType", GlobalConstant.DeleteAccess);
                SqlDataReader returnLst = sqlcmd.ExecuteReader();
                ConStringAndSP conStrSP = new ConStringAndSP();
                while (returnLst.Read())
                {
                    conStrSP.ConnString = returnLst["ConnString"].ToString();
                    conStrSP.StoredProcedure = returnLst["StoredProcedure"].ToString();
                }
                sqlconn.Close();
                sqlconn = new SqlConnection(conStrSP.ConnString);
                string appSP = conStrSP.StoredProcedure;
                sqlcmd = new SqlCommand(appSP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@lstRoleID", roleIDList);
                sqlcmd.Parameters.AddWithValue("@CreatedNTID", userNTID);
                sqlconn.Open();
                return (int)sqlcmd.ExecuteScalar() != 1 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int AddUserAppRole(int appID, string lstRoleID, string RoleNameLst, string CreatedNTID, int RequestType)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string insertSP = GlobalConstant.USP_InsertUserAppRoleRequest;
                sqlcmd = new SqlCommand(insertSP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@AppID", appID);
                sqlcmd.Parameters.AddWithValue("@lstRoleID", lstRoleID);
                sqlcmd.Parameters.AddWithValue("@RoleNameLst", RoleNameLst);
                sqlcmd.Parameters.AddWithValue("@CreatedNTID", CreatedNTID);
                return (int)sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
        /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        public IEnumerable<UserAppRoleRequest> GetMyRequestdata(string NTID ,int myRequest)
        {

            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetRequestdata;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@NTID", NTID);
            sqlcmd.Parameters.AddWithValue("@RequestType", myRequest);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            List<UserAppRoleRequest> Lstmenu = new List<UserAppRoleRequest>();
            while (returnLst.Read())
            {
                UserAppRoleRequest m = new UserAppRoleRequest();
                m.ID = (int)returnLst["ID"];
                m.UserNTID = returnLst["UserNTID"].ToString();
                m.AppID = (int)returnLst["AppID"];
                m.Application = returnLst["Application"].ToString();
                m.RoleID = (int)returnLst["RoleID"];
                m.Role = returnLst["Role"].ToString();
                m.Date = Convert.ToDateTime(returnLst["Date"]);
                m.Status = returnLst["Status"].ToString();
                m.AssignedTo = returnLst["ApproverEmailID"].ToString();
                m.CreatedNTID = returnLst["CreatedNTID"].ToString();
                m.Remarks = returnLst["Remarks"].ToString();
                Lstmenu.Add(m);
            }

            return (Lstmenu);

        }

        public List<int> GetUserAppRoleRequestData(int AppID , string NTID)
        {

            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetApplicationAccessDetails;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@AppID", AppID);
            sqlcmd.Parameters.AddWithValue("@RequestType",GlobalConstant.ModifyAccess);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            ConStringAndSP conStrSP = new ConStringAndSP();
            while (returnLst.Read())
            {
                conStrSP.ConnString = returnLst["ConnString"].ToString();
                conStrSP.StoredProcedure = returnLst["StoredProcedure"].ToString();
            }
            sqlconn.Close();
            sqlconn = new SqlConnection(conStrSP.ConnString);
            sqlconn.Open();
            string appSP = conStrSP.StoredProcedure;
            sqlcmd = new SqlCommand(appSP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@UserNTID", NTID);
            SqlDataReader appRoleLst = sqlcmd.ExecuteReader();
            List<int> Lstmenu = new List<int>();
            while (appRoleLst.Read())
            {
                int m ;
                m = (int)appRoleLst["RoleID"];
                Lstmenu.Add(m);
            }

            return (Lstmenu);

        }
        public List<int> GetUserRolesList(int AppID, string NTID)
        {

            sqlconn = new SqlConnection(sqlconnectionstring);
            sqlconn.Open();
            string SP = GlobalConstant.USP_GetRequestdata;
            sqlcmd = new SqlCommand(SP, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@AppID", AppID);
            sqlcmd.Parameters.AddWithValue("@CreatedNTID", NTID);
            SqlDataReader returnLst = sqlcmd.ExecuteReader();
            List<int> Lstmenu = new List<int>();
            while (returnLst.Read())
            {
                int m;
                m = (int)returnLst["RoleID"];
                Lstmenu.Add(m);
            }

            return (Lstmenu);

        }
        public int AddUserInApplication(int AppID, int roleID, string userNTID, int ID)
        {
            try
            {
                    sqlconn = new SqlConnection(sqlconnectionstring);
                    sqlconn.Open();
                    string SP = GlobalConstant.USP_GetApplicationAccessDetails;
                    sqlcmd = new SqlCommand(SP, sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@AppID", AppID);
                    sqlcmd.Parameters.AddWithValue("@RequestType", GlobalConstant.AddUser);
                    SqlDataReader returnLst = sqlcmd.ExecuteReader();
                    ConStringAndSP conStrSP = new ConStringAndSP();
                    while (returnLst.Read())
                    {
                        conStrSP.ConnString = returnLst["ConnString"].ToString();
                        conStrSP.StoredProcedure = returnLst["StoredProcedure"].ToString();
                    }
                    sqlconn.Close();
                    sqlconn = new SqlConnection(conStrSP.ConnString);
                    string appSP = conStrSP.StoredProcedure;
                    sqlcmd = new SqlCommand(appSP, sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@NTID", userNTID);
                    sqlcmd.Parameters.AddWithValue("@RoleID",roleID );
                    sqlcmd.Parameters.AddWithValue("@Operation", 1);
                    sqlconn.Open();
                    int result =(int) sqlcmd.ExecuteScalar();

                    if (result > 0)
                    {
                        return UpdateUserAppRoleRequestStatus(ID, Status.Approved, Action.Complete);
                    }
                    return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public int DeleteUserAppRoleRequestStatus(int AppID, string CreatedNTID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string insertSP = GlobalConstant.USP_DeleteUserAppRoleRequest;
                sqlcmd = new SqlCommand(insertSP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@AppID", AppID);
                sqlcmd.Parameters.AddWithValue("@CreatedNTID", CreatedNTID);
                return (int)sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int UpdateUserAppRoleRequestStatus(int ID, int StatusID,int ActionID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string insertSP = GlobalConstant.USP_UpdateUserAppRoleRequest;
                sqlcmd = new SqlCommand(insertSP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@ID", ID);
                sqlcmd.Parameters.AddWithValue("@StatusID", StatusID);
                sqlcmd.Parameters.AddWithValue("@ActionID", ActionID);
                return (int)sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateApprovalMatrix(int ID, string approverNTID, string approverEmailID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string SP = GlobalConstant.USP_UpdateApprovalMatrixs;
                sqlcmd = new SqlCommand(SP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@ID", ID);
                sqlcmd.Parameters.AddWithValue("@ApproverNTID", approverNTID);
                sqlcmd.Parameters.AddWithValue("@ApproverEmailID", approverEmailID);
                return (int)sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertApprovalMatrix(int AppID, int RoleID, string RoleName, string ApproverNTID, string ApproverEmailID)
        {
            try
            {
                sqlconn = new SqlConnection(sqlconnectionstring);
                sqlconn.Open();
                string SP = GlobalConstant.USP_InsertApprovalMatrixs;
                sqlcmd = new SqlCommand(SP, sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@AppID", AppID);
                sqlcmd.Parameters.AddWithValue("@RoleID", RoleID);
                sqlcmd.Parameters.AddWithValue("@RoleName", RoleName);
                sqlcmd.Parameters.AddWithValue("@ApproverNTID", ApproverNTID);
                sqlcmd.Parameters.AddWithValue("@ApproverEmailID", ApproverEmailID);
                return (int)sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
}
    /// <summary>
    ///  declare ApplicationMaster table
    /// </summary>

        public class ApplicationMatrix
        {
            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }
            private int _id;

            public int AppID
            {
                get { return _appID; }
                set { _appID = value; }
            }
            private int _appID;

            public int RoleID
            {
                get { return _roleID; }
                set { _roleID = value; }
            }
            private int _roleID;

            public string AppName
            {
                get { return _appName; }
                set { _appName = value; }
            }
            private string _appName;

            public string RoleName
            {
                get { return _roleName; }
                set { _roleName = value; }
            }
            private string _roleName;

            public string ApproverNTID
            {
                get { return _approverNTID; }
                set { _approverNTID = value; }
            }
            private string _approverNTID;

            public string ApproverName
            {
                get { return _approverName; }
                set { _approverName = value; }
            }
            private string _approverName;

            public string ApproverEmail
            {
                get { return _approverEmail; }
                set { _approverEmail = value; }
            }
            private string _approverEmail;

        }
        public class ApplicationMaster
        {
            public int AppID
            {
                get { return _appID; }
                set { _appID = value; }
            }
            private int _appID;

            public string AppName
            {
                get { return _appName; }
                set { _appName = value; }

            }
            private string _appName;

        }
       
        public class ApplicationRoles
        {
            public int RoleID
            {
                get { return _roleID; }
                set { _roleID = value; }
            }
            private int _roleID;
            public int AppID
            {
                get { return _appID; }
                set { _appID = value; }
            }
            private int _appID;

            public string RoleName
            {
                get { return _roleName; }
                set { _roleName = value; }

            }
            private string _roleName;

        }
        public class ConStringAndSP
        {
            public string ConnString
            {
                get { return _connString; }
                set { _connString = value; }
            }
            private string _connString;
            public string StoredProcedure
            {
                get { return _storedProcedure; }
                set { _storedProcedure = value; }
            }
            private string _storedProcedure;

        }
        public class UserAppRoleRequest
        {
            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }
            private int _id;
            public string UserNTID
            {
                get { return _userNTID; }
                set { _userNTID = value; }
            }
            private string _userNTID;
            
             public int AppID
            {
                get { return _appID; }
                set { _appID = value; }
            }
            private int _appID;
            public string Application
            {
                get { return _application; }
                set { _application = value; }
            }
            private string _application;
            public int RoleID
            {
                get { return _roleID; }
                set { _roleID = value; }
            }
            private int _roleID;
            public string Role
            {
                get { return _role; }
                set { _role = value; }
            }
            private string _role;
            public DateTime  Date
            {
                get { return _date; }
                set { _date = value; }
            }
            private DateTime _date;
            public string Remarks
            {
                get { return _remarks; }
                set { _remarks = value; }
            }
            private string _remarks;
            public string Status
            {
                get { return _status; }
                set { _status = value; }
            }
            private string _status;
            public string AssignedTo
            {
                get { return _assignedTo; }
                set { _assignedTo = value; }
            }
            private string _assignedTo;
            public string CreatedNTID
            {
                get { return _createdNTID; }
                set { _createdNTID = value; }
            }
            private string _createdNTID;
        }
    
