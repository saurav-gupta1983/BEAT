using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using DTO = BEAT.Common.DataTransferObjects;
using BEAT.Common;

namespace BEAT.DataLayer.Query
{
    /// <summary>
    /// QueryDAO
    /// </summary>
    public static class QueryDAO
    {
        #region Other Common Functions

        /// <summary>
        /// GetColumnNames
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetColumnNames(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT COLUMN_NAME FROM information_schema.COLUMNS ");
            query.Append(" WHERE (TABLE_NAME = '" + tableName + "')");

            return query.ToString();
        }

        /// <summary>
        /// BulkTableInsert
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="tableName"></param>
        /// <param name="columnList"></param>
        /// <returns></returns>
        public static string BulkTableInsert(DataRow dr, string tableName, string columnList)
        {
            StringBuilder query = new StringBuilder("Insert into ");

            query.Append(tableName);
            query.Append("(" + columnList.Trim(new char[] { ',' }) + ")");
            query.Append(" values (");

            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                query.Append("'" + dr[i].ToString().Replace("'", "''") + "',");
            }
            query.Append("'ADMIN',");
            query.Append("'" + System.DateTime.Now.ToString() + "'");
            query.Append(")");

            return query.ToString();
        }

        /// <summary>
        /// FormattedDate
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static string FormattedDate(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }

        /// <summary>
        /// FormattedDate
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        private static string FormattedDate(string dateString)
        {
            if (dateString != null || dateString != "")
            {
                DateTime date = DateTime.Parse(dateString);
                return date.Year + "-" + date.Month + "-" + date.Day;
            }

            return "";
        }

        #endregion
    }
}
