using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttenUploadWpf
{
    public class GetData
    {
        public SqlConnection m_Conn;
        private string dbCon = (string)null;

        public GetData(string str) => this.dbCon = str;

        private DataSet GetDataSet(SqlCommand cmd)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(this.dbCon);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                cmd.Connection = sqlConnection;
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlConnection.Close();
                return dataSet;
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog("Can not open connection ! " + ex.Message.ToString());
                return new DataSet();
            }
        }

        public DataSet GetDataSetResult(SQLParams pap)
        {
            DataSet dataSet = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = pap.ProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Comp1", (object)pap.ComCod));
            cmd.Parameters.Add(new SqlParameter("@CallType", (object)pap.Segment));
            cmd.Parameters.Add(new SqlParameter("@Dbin01", (object)pap.varBin01));
            cmd.Parameters.Add("@Dxml01", SqlDbType.Xml).Value = pap.varXml01 == null ? (object)(string)null : (object)pap.varXml01.GetXml();
            cmd.Parameters.Add("@Dxml02", SqlDbType.Xml).Value = pap.varXml02 == null ? (object)(string)null : (object)pap.varXml02.GetXml();
            cmd.Parameters.Add(new SqlParameter("@Desc1", (object)pap.var01));
            cmd.Parameters.Add(new SqlParameter("@Desc2", (object)pap.var02));
            cmd.Parameters.Add(new SqlParameter("@Desc3", (object)pap.var03));
            cmd.Parameters.Add(new SqlParameter("@Desc4", (object)pap.var04));
            cmd.Parameters.Add(new SqlParameter("@Desc5", (object)pap.var05));
            cmd.Parameters.Add(new SqlParameter("@Desc6", (object)pap.var06));
            cmd.Parameters.Add(new SqlParameter("@Desc7", (object)pap.var07));
            cmd.Parameters.Add(new SqlParameter("@Desc8", (object)pap.var08));
            cmd.Parameters.Add(new SqlParameter("@Desc9", (object)pap.var09));
            cmd.Parameters.Add(new SqlParameter("@Desc10", (object)pap.var10));
            cmd.Parameters.Add(new SqlParameter("@Desc11", (object)pap.var11));
            cmd.Parameters.Add(new SqlParameter("@Desc12", (object)pap.var12));
            cmd.Parameters.Add(new SqlParameter("@Desc13", (object)pap.var13));
            cmd.Parameters.Add(new SqlParameter("@Desc14", (object)pap.var14));
            cmd.Parameters.Add(new SqlParameter("@Desc15", (object)pap.var15));
            cmd.Parameters.Add(new SqlParameter("@Desc16", (object)pap.var16));
            cmd.Parameters.Add(new SqlParameter("@Desc17", (object)pap.var17));
            cmd.Parameters.Add(new SqlParameter("@Desc18", (object)pap.var18));
            cmd.Parameters.Add(new SqlParameter("@Desc19", (object)pap.var19));
            cmd.Parameters.Add(new SqlParameter("@Desc20", (object)pap.var20));
            cmd.Parameters.Add(new SqlParameter("@Desc21", (object)pap.var21));
            cmd.Parameters.Add(new SqlParameter("@Desc22", (object)pap.var22));
            cmd.Parameters.Add(new SqlParameter("@UserID", (object)""));
            return this.GetDataSet(cmd);
        }
    }
}
