using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_suaxoaBDS : System.Web.UI.Page
{
    private bus_Admin admin = new bus_Admin();
    private bus_Danhmuc dm = new bus_Danhmuc();
    private int page = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string session;
        try
        {
             session = Session["user"].ToString();
        }
        catch {
            session = null;
        }
        if (session == null || session != "admin")
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {       
            if (!IsPostBack)
            {
                loadDM();
                laydsBDS(1);
                BindRepeater();
            }
            
        }
        
    }
    private void loadDM()
    {
        drlmakv.DataSource = dm.BUS_loadDM().Tables[0];
        drlmakv.DataTextField = "tenKV";
        drlmakv.DataValueField = "maKV";
        drlmakv.DataBind();
        drlmakv.Items.Insert(0, new ListItem("--Chọn khu vực--", "-1"));

        
        drlloaibds.DataSource = dm.BUS_loadDM().Tables[1];
        drlloaibds.DataTextField = "tenLoaiBDS";
        drlloaibds.DataValueField = "maLoaiBDS";
        drlloaibds.DataBind();
        drlloaibds.Items.Insert(0, new ListItem("--Chọn loại BĐS--", "-1"));

       

    }
    private void laydsBDS(int page)
    {
        DataTable dt = new DataTable();
        dt = admin.BUS_view_batdongsan(txtsearchTen.Text, Convert.ToInt32(drlmakv.SelectedItem.Value.ToString()), Convert.ToInt32(drlloaibds.SelectedItem.Value.ToString()), -1, page).Tables[0];
        GridSp.DataSource = dt;
        GridSp.DataBind();

        dt = admin.BUS_view_batdongsan(txtsearchTen.Text, Convert.ToInt32(drlmakv.SelectedItem.Value.ToString()), Convert.ToInt32(drlloaibds.SelectedItem.Value.ToString()), -1, -1).Tables[2];
        Session["sodong"] = dt.Rows[0]["sodong"];
    }
    protected void Viewedit_ItemCommand(object sender, FormViewCommandEventArgs e)
    {

    }
    protected void GridSp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string command = e.CommandArgument.ToString();

        if (e.CommandName == "Xoa")
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int tt = admin.BUS_delete_batdongsan(int.Parse(command));
                if (tt==1)
                {
                    int trang;
                    try
                    {
                        trang = Convert.ToInt32(Session["currPage"]);
                    }
                    catch { trang = 1; }
                    laydsBDS(trang);
                }
            }
        }
        else if (e.CommandName == "Sua")
        {
            //GridSp.Visible = false;
            //Viewedit.Visible = true;
            ////do du lieu vao viewedit
            //Viewedit.DataSource = admin.BUS_view_batdongsan("", -1, -1, int.Parse(command),-1);
            //Viewedit.DataBind();
        }
        else
        {
            page = int.Parse(command);
            laydsBDS(int.Parse(command));
        }
        
    }
    
    protected void btntimkiem_Click(object sender, EventArgs e)
    {
        try
        {
            //GridSp.Visible = true;
            //Viewedit.Visible = false;
            laydsBDS(1);
            BindRepeater();
        }
        catch { }
    }
    protected void GridSp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridSp.PageIndex = e.NewPageIndex;
        //page = e.NewPageIndex;
        //laydsBDS(1);
    }


    protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int PageNumber = Convert.ToInt32(e.CommandArgument);
        Session["currPage"] = PageNumber;
        laydsBDS(PageNumber);
        BindRepeater();
    }
    public int pagesize = 5;
    private void BindRepeater()
    {
        try
        {
            DataTable ptable = new DataTable("Paging");
            DataColumn pColumn = new DataColumn("stt", typeof(int));
            ptable.Columns.Add(pColumn);

            int rowcount = 1;
            try
            {
                rowcount = Convert.ToInt32(Session["sodong"]);
            }
            catch (Exception ex1)
            {
                rowcount = 1;
            }
            if (rowcount > 1)
            {
                rptPaging.Visible = true;
                int pagecount = (rowcount / pagesize) + 1;
                for (int i = 1; i <= pagecount; i++)
                {
                    DataRow pRow = ptable.NewRow();
                    pRow["stt"] = i;
                    ptable.Rows.Add(pRow);
                }
                rptPaging.DataSource = ptable;
                rptPaging.DataBind();
                int currpageindex = 1;
                try
                {
                    currpageindex = int.Parse(Session["currPage"].ToString());
                }
                catch (Exception ex)
                {
                    currpageindex = 1;
                }
                LinkButton lnkView = new LinkButton();
                lnkView = (LinkButton)rptPaging.Items[currpageindex - 1].FindControl("btnPage");
                if (lnkView != null)
                {
                    lnkView.Style.Remove("Background-color");
                    lnkView.Style.Add("Background-color", "#006699");
                }

            }
            else
            {
                rptPaging.Visible = false;
            }
        }
        catch { }
    }
}