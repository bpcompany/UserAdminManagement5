using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobalConstant
/// </summary>
public static class GlobalConstant
{

    public const int AppOrRole = 1;
    public const int GetAppID = 2;
    public const string AccessDenied = "~/AccessDenied.aspx";
    public const string UserRole = "UserRole";
    public const string UserNTID = "UserNTID";
    public const string findUser = "find User";
    public const string Submit = "Submit Request";
    public const string Update = "Update";
    public const string Delete = "Delete";
    public const string NewAccess="New Access Request";
    public const string ModifyAccess = "Modify Access Request";
    public const string DeleteAccess = "Delete Access Request";
    public const string UserExist = "UserExist";
    public const string AddUser = "AddUser";
    public const string Approve = "Approve";
    public const string Decline = "Decline";

    public const int myRequest = 0;
    public const int actionRequired = 1;
    public const int actionedRequest = 2;
    public const int DefaultAppID = 0;
    public const int DefaultID = 0;
    #region Stored Procedures
    public const string USP_UpdateUserAppRoleRequest = "USP_UpdateUserAppRoleRequest";
    public const string USP_GetRequestdata = "USP_GetRequestdata";
    public const string USP_GetAllApplications = "USP_GetAllApplications";
    public const string USP_GetApplicationAccessDetails = "USP_GetApplicationAccessDetails";
    public const string USP_CheckUserExistance = "USP_CheckUserExistance";
    public const string USP_InsertUserAppRoleRequest = "USP_InsertUserAppRoleRequest";
    public const string USP_DeleteUserAppRoleRequest = "USP_DeleteUserAppRoleRequest";
    public const string USP_GetApprovalMatrixs = "USP_GetApprovalMatrixs";
    public const string USP_UpdateApprovalMatrixs = "USP_UpdateApprovalMatrixs";
    public const string USP_InsertApprovalMatrixs = "USP_InsertApprovalMatrixs";
    public const string USP_CheckAdminUserExistance = "USP_CheckAdminUserExistance";
    #endregion
    
    #region Error Contols
    public enum DrawControls
    {
        Information = 1,
        Success,
        Warning,
        Error
    }


    #endregion
}

public static class RequestType
{
    public const int NewRequest = 1;
    public const int ModifyRequest = 2;
    public const int DeleteRequest = 3;
}
public static class Status
{
    public const int Approved = 1;
    public const int Denied = 2;
   
}
public static class Action
{
    public const int Complete = 1;
}