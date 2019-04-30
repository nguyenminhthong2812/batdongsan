using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using System.Data.Common;
using BDS.OBJE;

/// <summary>
/// Summary description for bus_Admin
/// </summary>
public class bus_Admin
{
    private Database db;
	public bus_Admin()
	{
        try
        {
            dbo d = new dbo();
            d.getConnectionString();
            db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(d.strConnectionString);
            //db = DatabaseFactory.CreateDatabase();
        }
        catch (Exception ex)
        {
            throw ex;
        }
	}
    public int BUS_ql_batdongsan(obj_BDS obj,int opt,string anhct)
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand("ql_batdongsan");
            db.AddInParameter(dbCommand, "@opt", DbType.Int32, opt);
            db.AddInParameter(dbCommand, "@mabds", DbType.Int32, obj.maBDS);
            db.AddInParameter(dbCommand, "@tenBDS", DbType.String, obj.tenBDS);
            db.AddInParameter(dbCommand, "@diachi", DbType.String, obj.diachi);
            db.AddInParameter(dbCommand, "@gia", DbType.String, obj.gia);
            db.AddInParameter(dbCommand, "@noidung", DbType.String, obj.noidung);
            db.AddInParameter(dbCommand, "@ghichu", DbType.String, obj.ghichu);
            db.AddInParameter(dbCommand, "@daban", DbType.Boolean, obj.daban);
            db.AddInParameter(dbCommand, "@makv", DbType.Int32, obj.maKV);
            db.AddInParameter(dbCommand, "@maloaibds", DbType.Int32, obj.maLoaiBDS);
            db.AddInParameter(dbCommand, "@noibat", DbType.Boolean, obj.noibat);
            db.AddInParameter(dbCommand, "@anhdaidien", DbType.String, obj.hinhanh);
            db.AddInParameter(dbCommand, "@anhchitiet", DbType.String, anhct);
            db.AddOutParameter(dbCommand, "@tt", DbType.Int32, 100);
            db.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(db.GetParameterValue(dbCommand, "@tt"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet BUS_view_batdongsan(string tenBDS, int makv, int maloaibds,int maBDS,int page)
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbcommand = db.GetStoredProcCommand("view_batdongsan");
            db.AddInParameter(dbcommand, "@tenBDS", DbType.String, tenBDS);
            db.AddInParameter(dbcommand, "@maKV", DbType.Int32, makv);
            db.AddInParameter(dbcommand, "@maLoaiBDS", DbType.Int32, maloaibds);
            db.AddInParameter(dbcommand, "@maBDS", DbType.Int32, maBDS);
            db.AddInParameter(dbcommand, "@page", DbType.Int32, page);
            db.LoadDataSet(dbcommand, ds, "view_batdongsan");
            return ds;         
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int BUS_delete_batdongsan(int mabds)
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand("delete_batdongsan");
            db.AddInParameter(dbCommand, "@mabds", DbType.Int32, mabds);
            db.AddOutParameter(dbCommand, "@tt", DbType.Int32, 100);
            db.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(db.GetParameterValue(dbCommand, "@tt"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}