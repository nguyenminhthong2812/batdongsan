<%@ Application Language="C#" %>
<%@ Import Namespace="BDS" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %> 

<script runat="server">
    
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("khuvuc", "nha-dat-{khuvuc}-{page}", "~/Default.aspx");
        routes.MapPageRoute("noibat", "nha-dat-{page}", "~/Default.aspx");
        routes.MapPageRoute("Loai", "bat-dong-san-{tenloai}-{page}", "~/Default.aspx");
        routes.MapPageRoute("chitiet", "{tieu-de}-{mabds}", "~/chitiet.aspx");         
    }  

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes); 
        // Code that runs on application startup
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        AuthConfig.RegisterOpenAuth();
    }
    
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

</script>
