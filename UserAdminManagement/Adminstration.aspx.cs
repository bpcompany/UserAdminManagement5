using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adminstration : System.Web.UI.Page
{
    private void BindApplicationDropdown()
    {
        var report = userAdminObj.GetAllApplications();
        ddlApp.DataSource = report;
        ddlApp.DataTextField = "AppName";
        ddlApp.DataValueField = "AppID";
        ddlApp.DataBind();
        ddlApp.Items.Insert(0, "Select");
    }
    private void BindDdllistRole(int ID, int AppID)
    {
        if (ID != 0)
            AppID = userAdminObj.GetAppID(ID);

        var result = userAdminObj.GetRole(AppID, GlobalConstant.NewAccess);
        var LstRoleID = userAdminObj.GetApprovalMatrixsRole(AppID);
        List<ApplicationRoles> appRolesList = new List<ApplicationRoles>();
        int count = 0;
        foreach (var item in result)
        {
            foreach (var item2 in LstRoleID)
            {
                if (item2.RoleID == item.RoleID)
                {
                    count = 1;
                }
            }
            if (count != 1)
            {
                ApplicationRoles appRole = new ApplicationRoles();
                appRole.RoleID = item.RoleID;
                appRole.RoleName = item.RoleName;
                appRolesList.Add(appRole);
            }
            count = 0;
        }
        if (ID != 0)
            ddlRole.DataSource = result.ToList();
        else
            ddlRole.DataSource = appRolesList.ToList();
        ddlRole.DataTextField = "RoleName";
        ddlRole.DataValueField = "RoleID";
        ddlRole.DataBind();
        if (LstRoleID.Count() == result.Count() && ID == 0)
        {
            showMessages((int)GlobalConstant.DrawControls.Warning, "Roles Already exist in Approval Matrix, Please Select \"Edit\" to modify the Approver.", true);
            btnUpdate.Visible = false;
        }

    }
    public string ParamID
    {
        get { return ViewState["paramID"] != null ? (string)ViewState["paramID"] : null; }
        set { ViewState["paramID"] = value; }
    }
    UserAdminModel userAdminObj = new UserAdminModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        clearMessages();
        if (!IsPostBack)
        {
            SetInitialValues();
            ParamID = Request.QueryString["param"];
            if (ParamID != null)
            {
                btnUpdate.Text = "Update";
                pnlApprovalUpdate.Visible = true;
                pnlAppMatrix.Visible = false;
                ddlApp.SelectedValue = userAdminObj.GetAllApplications(Convert.ToInt32(ParamID)).ToString();
                ddlApp.Enabled = false;
                ddlRole.SelectedValue = userAdminObj.GetAllApplications(Convert.ToInt32(ParamID), GlobalConstant.AppOrRole).ToString();
                ddlRole.Enabled = false;
                BindDdllistRole(Convert.ToInt32(ParamID), GlobalConstant.DefaultAppID);
                BindApplicationDropdown();
            }
            else
            {
                BindgvMyRequest();
                pnlApprovalUpdate.Visible = false;
            }
        }
    }
    private void BindgvMyRequest()
    {
        gvApprovalMatrix.DataSource = userAdminObj.GetApplicationMatrixdata(lblusedid.Text);
        gvApprovalMatrix.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ParamID = null;
            pnlAppMatrix.Visible = true;
            pnlApprovalUpdate.Visible = false;
            Response.Redirect("~/Adminstration.aspx", false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnUpdate.Text == "Update")
            {
                int Count = userAdminObj.UpdateApprovalMatrix(Convert.ToInt16(Request.QueryString["param"]), txtApprover.Text, txtApproverEmailID.Text);
                if (Count > 0)
                    showMessages((int)GlobalConstant.DrawControls.Success, "Approver NTID Updated Succesfully.", true);
                else
                    showMessages((int)GlobalConstant.DrawControls.Error, "Approver NTID not Updated Succesfully.", true);

            }
            else
            {
                int Count = userAdminObj.InsertApprovalMatrix(Convert.ToInt32(ddlApp.SelectedValue), Convert.ToInt32(ddlRole.SelectedValue), ddlRole.SelectedItem.Text, txtApprover.Text, txtApproverEmailID.Text);
                if (Count > 0)
                    showMessages((int)GlobalConstant.DrawControls.Success, "Approver NTID Added Succesfully.", true);
                else
                    showMessages((int)GlobalConstant.DrawControls.Error, "Approver NTID not Added Succesfully.", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnAddApprover_Click(object sender, EventArgs e)
    {
        btnUpdate.Text = "Add";
        pnlApprovalUpdate.Visible = true;
        pnlAppMatrix.Visible = false;
        BindApplicationDropdown();
        ddlRole.Items.Insert(0, "Select");
    }

    protected void ddlApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        int requestType = 0;
        if (ddlApp.SelectedItem.Text != "Select")
        {
            requestType = Convert.ToInt32(ddlApp.SelectedValue);
            BindDdllistRole(GlobalConstant.DefaultID, requestType);
            
        }
        else
            showMessages((int)GlobalConstant.DrawControls.Error, "Please select any Application from Application dropdown.", true);
        
    }

    private void SetInitialValues()
    {
        if (Session["username"] != null)
        {
            lblusedid.Text = Session["username"].ToString();
            lblname.Text = Session["full_name"].ToString();
            lblfullname.Text = Session["full_name"].ToString();
        }
        else
        {
            Response.Redirect("BPSLogin.aspx");
        }
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

    private void clearMessages()
    {
        //divError.Visible = false;

        //divInfo.Visible = false;

        //divSuccess.Visible = false;

        //divWarning.Visible = false;
    }

}