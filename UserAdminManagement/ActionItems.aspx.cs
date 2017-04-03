using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ActionItems : System.Web.UI.Page
{
    UserAdminModel userAdminObj = new UserAdminModel();
    private void BindgvMyRequest()
    {
        gvMyRequest.DataSource = userAdminObj.GetMyRequestdata(lblusedid.Text, GlobalConstant.myRequest);
        gvMyRequest.DataBind();
    }

    private void BindgvActionedRequests()
    {
        gvActionedRequests.DataSource = userAdminObj.GetMyRequestdata(lblusedid.Text, GlobalConstant.actionedRequest);
        gvActionedRequests.DataBind();
    }

    private void BindgvActionRequired()
    {
        gvActionRequired.DataSource = userAdminObj.GetMyRequestdata(lblusedid.Text, GlobalConstant.actionRequired);
        gvActionRequired.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetInitialValues();
            BindgvMyRequest();
            BindgvActionedRequests();
            BindgvActionRequired();
            
                 
            
        }
    }

    protected void gvActionRequired_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = gvActionRequired.Rows[index];
        Label lblAppID = (Label)row.FindControl("lblAppID");
        Label lblRoleID = (Label)row.FindControl("lblRoleID");
        Label lblID = (Label)row.FindControl("lblID");
        Label lblUserNTID = (Label)row.FindControl("lblUserNTID");
        if (e.CommandName == GlobalConstant.Approve)
        {
            int result = userAdminObj.AddUserInApplication(Convert.ToInt16(lblAppID.Text), Convert.ToInt16(lblRoleID.Text), lblUserNTID.Text, Convert.ToInt16(lblID.Text));
            if (result > 0)
                showMessages((int)GlobalConstant.DrawControls.Success, "User Role Added Succesfully.", true);
            else
                showMessages((int)GlobalConstant.DrawControls.Error, "error msg", true);
        }
        else if (e.CommandName == GlobalConstant.Decline)
        {
            int result = userAdminObj.UpdateUserAppRoleRequestStatus(Convert.ToInt16(lblID.Text), Status.Denied , Action.Complete);
            if (result > 0)
                showMessages((int)GlobalConstant.DrawControls.Success, "User Role Declined Succesfully.", true);
            else
                showMessages((int)GlobalConstant.DrawControls.Error, "error msg", true);
        }

        BindgvMyRequest();
        BindgvActionedRequests();
        BindgvActionRequired();

        ActionrequiredID.Attributes.Add("class", "active");
        tab2actionrequired.Attributes.Add("class", "tab-pane fade in active");
        MyrequestsID.Attributes.Remove("class");
        tab1myrequestss.Attributes.Add("class", "tab-pane fade");
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
}