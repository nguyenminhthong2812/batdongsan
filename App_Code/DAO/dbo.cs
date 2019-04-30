using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for dbo
/// </summary>
public class dbo
{
    public string strConnectionString = "Data Source=" + WebConfigurationManager.AppSettings["svr"].ToString() + ";Initial Catalog=" + WebConfigurationManager.AppSettings["dbs"].ToString() + ";User ID=" + WebConfigurationManager.AppSettings["ur"].ToString() + ";Password=" + WebConfigurationManager.AppSettings["pw"].ToString();
    public string db = WebConfigurationManager.AppSettings["dbs"].ToString();
    public SqlConnection connection;
    public SqlDataAdapter adapter;
    public SqlCommand command;
	public dbo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void getConnectionString()
    {
        string ip = WebConfigurationManager.AppSettings["svr"].ToString();
        string ur = WebConfigurationManager.AppSettings["ur"].ToString();
        string pw = WebConfigurationManager.AppSettings["pw"].ToString();
        string dbs = WebConfigurationManager.AppSettings["dbs"].ToString();

        strConnectionString = "Data Source=" + ip + ";Initial Catalog=" + dbs + ";User ID=" + ur + ";Password=" + pw;
    }
    public void Connect()
    {
        getConnectionString();
        try
        {
            connection = new SqlConnection(strConnectionString);
            connection.Open();
        }
        catch (Exception ex)
        {
        }
    }    
    public void Disconnect()
    {
        try
        {

            connection.Close();
        }
        catch (Exception ex)
        {
        }

    }
}