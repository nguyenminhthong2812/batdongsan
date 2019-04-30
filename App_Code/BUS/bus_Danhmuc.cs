using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using System.Data.Common;
/// <summary>
/// Summary description for bus_Danhmuc
/// </summary>
public class bus_Danhmuc
{
    private Database db;
    public bus_Danhmuc()
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
    public DataSet BUS_loadDM()
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand("loadDM");
            db.LoadDataSet(dbCommand, ds, "loadDM");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet BUS_LOAD_KHUVUC()
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand("LOAD_KHUVUC");
            db.LoadDataSet(dbCommand, ds, "LOAD_KHUVUC");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BUS_LOAD_LOAIBDS()
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand("LOAD_LOAIBDS");
            db.LoadDataSet(dbCommand, ds, "LOAD_LOAIBDS");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int BUS_DANGNHAP(string taikhoan, string matkhau)
    {
        try
        {
            DbCommand dbCommand = db.GetStoredProcCommand("KIEMTRA_DANGNHAP");
            db.AddInParameter(dbCommand, "@TAIKHOAN", DbType.String, taikhoan);
            db.AddInParameter(dbCommand, "@MATKHAU", DbType.String, matkhau);
            db.AddOutParameter(dbCommand, "@KQ", DbType.Int32, 100);
            db.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(db.GetParameterValue(dbCommand, "@KQ"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BUS_LOAD_DANHSACH_BDS(string khuvuc, string tenloai, int page)
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand("LOAD_DS_BDS");
            db.AddInParameter(dbCommand, "@KHUVUC", DbType.String, khuvuc);
            db.AddInParameter(dbCommand, "@TENLOAI", DbType.String, tenloai);
            db.AddInParameter(dbCommand, "@PAGE", DbType.Int32, page);
            db.LoadDataSet(dbCommand, ds, "LOAD_DS_BDS");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet BUS_LOAD_CHITIET_SANPHAM(int mabds)
    {
        try
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand("LOAD_CHITIET_SANPHAM");
            db.AddInParameter(dbCommand, "@MABDS", DbType.Int32, mabds);
            db.LoadDataSet(dbCommand, ds, "LOAD_CHITIET_SANPHAM");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}