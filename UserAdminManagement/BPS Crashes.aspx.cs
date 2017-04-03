using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class BPS_Crashes : System.Web.UI.Page
{
    UserAdminModel userAdminObj = new UserAdminModel();
    /// <summary>
    /// Bind ddlApplication dropdown
    /// </summary>
    private List<int> listAppUsersobj
    {
        get { return Session["listAppUsers"] != null ? (List<int>)Session["listAppUsers"] : null; }
        set { Session["listAppUsers"] = value; }
    }
    private void BindApplicationDropdown()
    {
        var report = userAdminObj.GetAllApplications();
        ddlApplication.DataSource = report;
        ddlApplication.DataTextField = "AppName";
        ddlApplication.DataValueField = "AppID";
        ddlApplication.DataBind();


    }
    /// <summary>
    /// Bind ddlRequestType Dropdown
    /// </summary>
    private void BindRequestTypeDropdown()
    {
        ddlRequestType.Items.Clear();
        ddlRequestType.DataValueField = "ID";
        ddlRequestType.DataTextField = "Description";
        ddlRequestType.Items.Add("Select");
        ddlRequestType.Items.Add(GlobalConstant.NewAccess);
        ddlRequestType.Items.Add(GlobalConstant.ModifyAccess);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetInitialValues();
            BindApplicationDropdown();
            BindRequestTypeDropdown();
            
        }
        pnlAccess.Visible = false;
    }
    private void SetInitialValues()
    {
        if (Session["username"] != null)
        {
            lblusedid.Text = Session["username"].ToString();
            lblname.Text = Session["full_name"].ToString();
            lblfullname.Text = Session["full_name"].ToString();
            txtNTID.Text = Session["username"].ToString();
            txtNTID.Text = Session["username"].ToString();
        }
        else
        {
            Response.Redirect("BPSLogin.aspx");
        }
    }
   
    private void BindchkBoxlistRole(int ApplicationID,int requestType)
    {
        if (requestType == RequestType.NewRequest)
        {
            BindchkBoxlistRole(ApplicationID);
            
        }
        else
        {
            List<int> listAppUsers = userAdminObj.GetUserAppRoleRequestData(Convert.ToInt32(ddlApplication.SelectedValue), txtNTID.Text).ToList();
            listAppUsersobj = listAppUsers;
            BindchkBoxlistRole(ApplicationID);                    
            for (int i = 0; i < chkBoxlistRole.Items.Count; i++)
            {
                foreach (var item in listAppUsers)
                {
                    if (Convert.ToInt16(chkBoxlistRole.Items[i].Value) == item)
                    {
                        chkBoxlistRole.Items[i].Selected = true;
                    }
                }
            }

         }
            
        
    }
    private void BindchkBoxlistRole(int ApplicationID)
    {
        var result = userAdminObj.GetRole(ApplicationID, GlobalConstant.NewAccess);
        chkBoxlistRole.DataSource = result.ToList();
        chkBoxlistRole.DataTextField = "RoleName";
        chkBoxlistRole.DataValueField = "RoleID";
        chkBoxlistRole.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
           // int userID = clsMethod.GetUserID(txtNTID.Text);
            if (btnSubmit.Text == GlobalConstant.Submit)
            {
                bool chkValidation = false;

                for (int i = 0; i < chkBoxlistRole.Items.Count; i++)
                {
                    if (chkBoxlistRole.Items[i].Selected)
                    {
                        chkValidation = true;
                    }
                }
                if (chkValidation)
                {
                    //bool userExistence = userAdminObj.CheckUserExistence(txtNTID.Text, Convert.ToInt16(ddlApplication.SelectedValue));
                    //    if (!userExistence)
                    //    {
                            int result = AddUserAppRoleRequest(RequestType.NewRequest);
                            if (result > 0)
                                showMessages((int)GlobalConstant.DrawControls.Success, "Add Roles - Request Submitted Succesfully for " + ddlApplication.SelectedItem.Text + " Application.", true);
                            else
                                showMessages((int)GlobalConstant.DrawControls.Error, "Add Roles - Error occured during request submission, Try again!.", true);
                        //}
                        //else
                        //    showMessages((int)GlobalConstant.DrawControls.Warning, "User already exists in the " + ddlApplication.SelectedItem.Text + " Application, Please select \"Modify Access Request\" to proceed further.", true);

                }
                else
                {
                    showMessages((int)GlobalConstant.DrawControls.Warning, "Please select a Role.", true);
                }
            }

            else if (btnSubmit.Text == GlobalConstant.Update)
            {
                    int resultAdd = AddUserAppRoleRequest(RequestType.NewRequest);
                    if (resultAdd > 0)
                        showMessages((int)GlobalConstant.DrawControls.Success, "User request submited succesfully.", true);
                    else
                        showMessages((int)GlobalConstant.DrawControls.Error, "Error occured during request submission, Try again!.", true);
            }
            BindRequestTypeDropdown();
           
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }


   

    private int AddUserAppRoleRequest(int RequestType)
    {
        string RoleIDLst = string.Empty;
        string RoleNameLst = string.Empty;
        string RoleIDLstRemove = string.Empty;
        for (int i = 0; i < chkBoxlistRole.Items.Count; i++)
        {
            if (chkBoxlistRole.Items[i].Selected)
            {
                if (listAppUsersobj != null)
                {
                    if (!listAppUsersobj.Contains(Convert.ToInt16(chkBoxlistRole.Items[i].Value)))
                    {
                        RoleIDLst = RoleIDLst + ',' + chkBoxlistRole.Items[i].Value;
                        RoleNameLst = RoleNameLst + ',' + chkBoxlistRole.Items[i].Text;
                    }
                }
                else
                {
                    RoleIDLst = RoleIDLst + ',' + Convert.ToInt32(chkBoxlistRole.Items[i].Value);
                    RoleNameLst = RoleNameLst + ',' + chkBoxlistRole.Items[i].Text;
                }

            }
            else
            {
                if (listAppUsersobj != null)
                {
                    if (listAppUsersobj.Contains(Convert.ToInt16(chkBoxlistRole.Items[i].Value)))
                    {
                        RoleIDLstRemove = RoleIDLstRemove + ',' + chkBoxlistRole.Items[i].Value;
                    }
                }

            }
        }
        listAppUsersobj = null;
        if (RoleIDLstRemove != string.Empty)
        {
            userAdminObj.DeleteUserRolesInApplication(Convert.ToInt16(ddlApplication.SelectedValue), RoleIDLstRemove, txtNTID.Text);
        }
        return userAdminObj.AddUserAppRole(Convert.ToInt16(ddlApplication.SelectedValue), RoleIDLst, RoleNameLst, txtNTID.Text, RequestType);
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/BPS Crashes.aspx", true);
    }
   
    private void showMessages(int DrawControl, string DisplayText, bool Visibility)
    {
        string errortype = "";

        switch (DrawControl)
        {
            case (int)GlobalConstant.DrawControls.Error:
                errortype = "Error";
                break;
            case (int)GlobalConstant.DrawControls.Success:
                errortype = "Success";
                break;
            case (int)GlobalConstant.DrawControls.Warning:
                errortype = "Warning";
                break;

        }


        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + DisplayText + "','" + errortype + "');", true);
    

    }
    
    protected void singlebutton_Click(object sender, EventArgs e)
    {
        int request = Convert.ToInt32(ddlApplication.SelectedIndex);
        int requestType = Convert.ToInt32(ddlRequestType.SelectedIndex);
        if (requestType == RequestType.NewRequest)
        {
            btnSubmit.Text = GlobalConstant.Submit;
            
            // trChkbox.Visible = true;
            if (userAdminObj.CheckUserAppRoleRequest(txtNTID.Text, Convert.ToInt16(ddlApplication.SelectedValue)))
            {
                showMessages((int)GlobalConstant.DrawControls.Warning, "User Already exists in application, Please Select \"Modify Request\".", true);
            }
            else
            {
                
                if (userAdminObj.CheckUserExistence(txtNTID.Text, Convert.ToInt16(ddlApplication.SelectedValue)))
                {
                    showMessages((int)GlobalConstant.DrawControls.Warning, "Pending Requests exists on your name, please wait till it actioned or Contact Administrator to delete the same.", true);
                }
                else
                {
                    pnlAccess.Visible = true;
                    BindchkBoxlistRole(Convert.ToInt32(ddlApplication.SelectedValue), RequestType.NewRequest);
                }
            }
        }
        else 
        {
                if (userAdminObj.CheckUserAppRoleRequest(txtNTID.Text, Convert.ToInt16(ddlApplication.SelectedValue)))
                {
                    btnSubmit.Text = GlobalConstant.Update;
                    pnlAccess.Visible = true;
                    btnCancel.Visible = false;
                    BindchkBoxlistRole(Convert.ToInt32(ddlApplication.SelectedValue), RequestType.ModifyRequest);
                }
                else
                {
                    showMessages((int)GlobalConstant.DrawControls.Warning, "User doesn't exists in application, Please select \"New Access Request\".", true);
                    pnlAccess.Visible = false;
                }
            
        }
    }
}
