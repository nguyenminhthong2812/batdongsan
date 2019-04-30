using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chitiet : System.Web.UI.Page
{
    private bus_Danhmuc dm = new bus_Danhmuc();
    protected void Page_Load(object sender, EventArgs e)
    {
        //int mabds = Convert.ToInt32(Request.QueryString["mabds"]);
        int mabds = RouteData.Values["mabds"] == null ? 0 : Convert.ToInt32(RouteData.Values["mabds"]);
        LoadTrangChiTiet(mabds);
    }

    protected void LoadTrangChiTiet(int mabds)
    {
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        ds = dm.BUS_LOAD_CHITIET_SANPHAM(mabds);
        dt1 = ds.Tables[0];
        dt2 = ds.Tables[1];
        // hiển thị nội dung lên tag html
        tieudesp.InnerHtml = dt1.Rows[0]["tenBDS"].ToString();
        diachisp.InnerHtml = dt1.Rows[0]["DiaChi"].ToString();
        giasp.InnerHtml = dt1.Rows[0]["Gia"].ToString();
        noidungsp.InnerHtml = dt1.Rows[0]["NoiDung"].ToString();
        // hiển thị slide
        string slide_html = "";
        int i = 0;
        foreach (DataRow dr in dt2.Rows)
        {
            if (i == 0)
                slide_html += "<div class=\"carousel-item active\">";
            else
                slide_html += "<div class=\"carousel-item\">";
            slide_html += "<img src=\"" + dr["hinhanh"].ToString() + "\"/></div>";
            i++;
        }
        slide_html += "<a href=\"#carousel-slider\" data-slide=\"prev\" class=\"carousel-control-prev\">";
        slide_html += "<i class=\"fa fa-angle-left slide-arrow\"></i></a>";
        slide_html += "<a href=\"#carousel-slider\" data-slide=\"next\" class=\"carousel-control-next\">";
        slide_html += "<i class=\"fa fa-angle-right slide-arrow\"></i></a>";
        slide.InnerHtml = slide_html;
    }
}