using System;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Configuration;
using BEAT.Common;
using DTO = BEAT.Common.DataTransferObjects;
using DAO = BEAT.DataLayer.DataAccessObjects;

namespace BEAT.BusinessLayer
{
    /// <summary>
    /// BusinessObjects
    /// </summary>
    public class BusinessObjects
    {
        #region Variables

        private string rsyncServerAddress = System.Configuration.ConfigurationManager.AppSettings["RSyncServerAddress"];

        #endregion

        //#region User Details

        ///// <summary>
        ///// GetUserID
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public static string GetUserID(string loginID)
        //{
        //    DTO.Users userData = new DTO.Users();
        //    userData.LoginID = loginID;

        //    DataTable dtUsers = DAO.DAObjects.GetUserDetails(loginID).Tables[0];
        //    DataRow[] drUser = dtUsers.Select(WebConstants.COL_LOGIN_ID + " = '" + loginID + "'");
        //    if (drUser.Length == 1)
        //        return drUser[0][WebConstants.COL_USER_ID].ToString();

        //    return "0";
        //}

        ///// <summary>
        ///// GetUserDetails
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public static DataSet GetUserDetails(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetUserDetails(userData);
        //}

        ///// <summary>
        ///// AddNewUser
        ///// </summary>
        ///// <param name="projectSearchDTO"></param>
        ///// <returns></returns>
        //public static string AddNewUser(string loginID)
        //{
        //    if (DAO.DAObjects.AddNewUser(loginID))
        //        return GetUserID(loginID);
        //    return "0";
        //}

        ///// <summary>
        ///// AddUpdateUserDetails
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateUserDetails(DTO.Users userData)
        //{
        //    if (userData.UserID == "")
        //    {
        //        return DAO.DAObjects.AddUserDetails(userData);
        //    }
        //    else
        //    {

        //        if (userData.LoginID == "")
        //        {
        //            return DAO.DAObjects.DeleteUserDetails(userData);
        //        }
        //        else
        //        {
        //            return DAO.DAObjects.UpdateUserDetails(userData);
        //        }
        //    }
        //}

        ///// <summary>
        ///// SaveUserDetails
        ///// </summary>
        ///// <param name="transferData"></param>
        //public static string SaveUserDetails(DTO.Users userData)
        //{
        //    if (!DAO.DAObjects.UpdateUserDetails(userData))
        //    {
        //        return "";
        //    }

        //    return GetUserID(userData.LoginID).ToString();
        //}

        ///// <summary>
        ///// UpdateProfileAndPreferences
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static bool UpdateProfileAndPreferences(DTO.Users userData)
        //{
        //    return DAO.DAObjects.UpdateProfileAndPreferences(userData);
        //}

        //#endregion

        //#region Products

        ///// <summary>
        ///// GetProduct
        ///// </summary>
        ///// <param name="productID"></param>
        ///// <returns></returns>
        //public static DataSet GetProducts(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetProducts(productData);
        //}

        ///// <summary>
        ///// GetProductUsers
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static DataSet GetProductUsers(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetProductUsers(productData);
        //}

        ///// <summary>
        ///// GetProductVersion
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static DataSet GetProductVersion(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetProductVersion(productData);
        //}

        ///// <summary>
        ///// GetUserProducts
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static DataSet GetUserProducts(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetUserProducts(productData);
        //}

        ///// <summary>
        ///// AddUpdateProductVersion
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateProductVersion(DTO.Product productData)
        //{
        //    if (productData.ProductVersionID == "")
        //        return DAO.DAObjects.AddProductVersion(productData);
        //    else
        //        return DAO.DAObjects.UpdateProductVersion(productData);
        //}

        ///// <summary>
        ///// CopyProductVersionData
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static bool CopyProductVersionData(DTO.Product productData)
        //{
        //    return DAO.DAObjects.CopyProductVersionData(productData);
        //}

        ///// <summary>
        ///// AddUpdateProductLinks
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateProductLinks(DTO.Product productData)
        //{
        //    if (productData.ProductLinkID == "")
        //        return DAO.DAObjects.AddProductLinks(productData);
        //    else if (productData.DocumentName != "")
        //        return DAO.DAObjects.UpdateProductLinks(productData);
        //    else
        //        return DAO.DAObjects.DeleteProductLinks(productData);
        //}

        //#endregion

        //#region Vendors

        ///// <summary>
        ///// GetProjectPhaseVendors
        ///// </summary>
        ///// <param name="phasesData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectPhaseVendors(DTO.ProjectPhases phasesData)
        //{
        //    return DAO.DAObjects.GetProjectPhaseVendors(phasesData);
        //}

        ///// <summary>
        ///// GetProjectPhaseVendorUsers
        ///// </summary>
        ///// <param name="phasesData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectPhaseVendorUsers(DTO.ProjectPhases phasesData)
        //{
        //    return DAO.DAObjects.GetProjectPhaseVendorUsers(phasesData);
        //}

        ///// <summary>
        ///// GetVendorEfforts
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public static DataSet GetVendorEfforts(DTO.WSRData wsrData)
        //{
        //    return DAO.DAObjects.GetVendorEfforts(wsrData);
        //}

        ///// <summary>
        ///// GetVendor
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public static DataSet GetVendorDetails(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetVendorDetails(userData);
        //}

        ///// <summary>
        ///// AddUpdateVendorEfforts
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public static bool AddUpdateVendorEfforts(DTO.WSRData wsrData)
        //{
        //    return DAO.DAObjects.AddUpdateVendorEfforts(wsrData);
        //}

        //#endregion

        //#region Week Data

        ///// <summary>
        ///// GetVendor
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public static DataSet GetWeeksInfo()
        //{
        //    return DAO.DAObjects.GetWeeksInfo();
        //}

        ///// <summary>
        ///// GetReportingWeek
        ///// </summary>
        ///// <param name="reportingType"></param>
        ///// <returns></returns>
        //public static DataSet GetReportingWeek(string reportingType)
        //{
        //    return DAO.DAObjects.GetReportingWeek(reportingType);
        //}

        //#endregion

        //#region WSR Data

        ///// <summary>
        ///// GetProductWsrParameters
        ///// </summary>
        ///// <param name="wsrParametersData"></param>
        ///// <returns></returns>
        //public static DataSet GetProductWSRParameters(DTO.WSRData wsrData)
        //{
        //    return DAO.DAObjects.GetProductWSRParameters(wsrData);
        //}

        /////// <summary>
        /////// GetWSRData
        /////// </summary>
        /////// <param name="userProductID"></param>
        /////// <param name="userVendorID"></param>
        /////// <param name="weekID"></param>
        /////// <returns></returns>
        ////public static DTO.WSRData GetWSRData(DTO.WSRData dtoWSRData)
        ////{
        ////    DataSet wsrData = DAO.UsersDAO.GetWSRData(dtoWSRData);

        ////    wsrData.Tables[0].TableName = "WSRData";

        ////    if (wsrData.Tables.Count > 0)
        ////    {
        ////        if (wsrData.Tables[0].Rows.Count > 0)
        ////        {
        ////            dtoWSRData.WsrDataID = wsrData.Tables[0].Rows[0]["WSRDataID"].ToString();
        ////            dtoWSRData.RedIssues = wsrData.Tables[0].Rows[0]["RedIssues"].ToString();
        ////            dtoWSRData.YellowIssues = wsrData.Tables[0].Rows[0]["YellowIssues"].ToString();
        ////            dtoWSRData.GreenAccom = wsrData.Tables[0].Rows[0]["GreenAccom"].ToString();
        ////            dtoWSRData.NewDeliverables = wsrData.Tables[0].Rows[0]["NextWeekDeliverables"].ToString();
        ////        }

        ////        try
        ////        {
        ////            DataSet prevWeekDeliverables = GetWSRDetails("OutstandingDeliverables", dtoWSRData);
        ////            prevWeekDeliverables.Tables[0].Rows.InsertAt(prevWeekDeliverables.Tables[0].NewRow(), prevWeekDeliverables.Tables[0].Rows.Count);
        ////            dtoWSRData.PrevWeekDeliverables = prevWeekDeliverables;
        ////        }
        ////        catch (Exception ex)
        ////        {

        ////        }
        ////    }

        ////    return dtoWSRData;
        ////}

        ///// <summary>
        ///// GetAllWSRData
        ///// </summary>
        ///// <param name="dtoWSRData"></param>
        ///// <returns></returns>
        //public static DTO.WSRData GetCombinedWSRData(DTO.WSRData dtoWSRData)
        //{
        //    DataSet wsrData = DAO.DAObjects.GetWSRData(dtoWSRData);

        //    wsrData.Tables[0].TableName = WebConstants.TBL_WSR_DATA;

        //    if (wsrData.Tables.Count > 0)
        //    {
        //        foreach (DataRow drWSRData in wsrData.Tables[0].Select())
        //        {
        //            dtoWSRData.WsrDataID = drWSRData[WebConstants.COL_WSR_DATA_ID].ToString();
        //            dtoWSRData.RedIssues = drWSRData[WebConstants.COL_WSR_RED_ISSUES].ToString();
        //            dtoWSRData.YellowIssues = drWSRData[WebConstants.COL_WSR_YELLOW_ISSUES].ToString();
        //            dtoWSRData.GreenAccom = drWSRData[WebConstants.COL_WSR_GREEN_ACCOMPLISHMENTS].ToString();
        //            dtoWSRData.NewDeliverables = drWSRData[WebConstants.COL_WSR_NEXT_WEEK_DELIVERABLES].ToString();

        //            try
        //            {
        //                DataSet prevWeekDeliverables = GetWSRDetails(WebConstants.TBL_WSR_OUTSTANDING_DELIVERABLES, dtoWSRData);
        //                prevWeekDeliverables.Tables[0].Rows.InsertAt(prevWeekDeliverables.Tables[0].NewRow(), prevWeekDeliverables.Tables[0].Rows.Count);
        //                dtoWSRData.PrevWeekDeliverables = prevWeekDeliverables;
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }
        //    }

        //    return dtoWSRData;

        //}

        ///// <summary>
        ///// GetWSRDetails
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <param name="dtoWSRData"></param>
        ///// <returns></returns>
        //public static DataSet GetWSRDetails(string tableName, DTO.WSRData dtoWSRData)
        //{
        //    return DAO.DAObjects.GetWSRDetails(tableName, dtoWSRData);
        //}

        ///// <summary>
        ///// GetWSRDetails
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <param name="dtoWSRData"></param>
        ///// <returns></returns>
        //public static DataSet GetWSRDetails(DTO.WSRData dtoWSRData)
        //{
        //    return DAO.DAObjects.GetWSRDetails(dtoWSRData);
        //}

        ///// <summary>
        ///// SaveWSRData
        ///// </summary>
        ///// <param name="dtoWSRData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateWSRData(DTO.WSRData dtoWSRData)
        //{
        //    if (DAO.DAObjects.AddUpdateWSRData(dtoWSRData))
        //    {
        //        if (dtoWSRData.WsrDataID == "")
        //        {
        //            dtoWSRData.WsrDataID = DAO.DAObjects.GetWSRData(dtoWSRData).Tables[0].Rows[0][0].ToString();
        //        }

        //        try
        //        {
        //            //SaveTestCasesData(dtoWSRData);
        //            //SaveBugsData(dtoWSRData);
        //            //SaveEffortsData(dtoWSRData);
        //            AddUpdateWSRDetails(dtoWSRData);
        //            SavePrevWeekPrioritiesData(dtoWSRData);
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //        return false;

        //    return true;
        //}

        ///// <summary>
        ///// SaveWSRDetails
        ///// </summary>
        ///// <param name="dtoWSRData"></param>
        //private static bool AddUpdateWSRDetails(DTO.WSRData dtoWSRData)
        //{
        //    return DAO.DAObjects.AddUpdateWSRDetails(dtoWSRData);
        //}

        ///// <summary>
        ///// UpdateProductWSRParameters
        ///// </summary>
        ///// <param name="wsrData"></param>
        ///// <returns></returns>
        //public static bool UpdateProductWSRParameters(DTO.WSRData dtoWSRData)
        //{
        //    return DAO.DAObjects.UpdateProductWSRParameters(dtoWSRData);
        //}

        ///// <summary>
        ///// SavePrevWeekPrioritiesData
        ///// </summary>
        ///// <param name="dtoWSRData"></param>
        //private static void SavePrevWeekPrioritiesData(DTO.WSRData dtoWSRData)
        //{
        //    dtoWSRData.PrevWeekDeliverables.Tables[0].Rows.RemoveAt(dtoWSRData.PrevWeekDeliverables.Tables[0].Rows.Count - 1);
        //    if (DAO.DAObjects.SavePrevWeekPrioritiesData(dtoWSRData))
        //    {
        //        dtoWSRData.PrevWeekDeliverables = DAO.DAObjects.GetWSRDetails("OutstandingDeliverables", dtoWSRData);
        //    }
        //}

        //#endregion

        //#region Project Roles

        ///// <summary>
        ///// GetUserRoles
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static DataSet GetUserRoles(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetUserRoles(userData);
        //}

        ///// <summary>
        ///// GetUserProducts
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static DataSet GetUserProducts(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetUserProducts(userData);
        //}

        ///// <summary>
        ///// GetUserProductRoles
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static DataSet GetUserProductRoles(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetUserProductRoles(userData);
        //}

        ///// <summary>
        ///// GetUserProjectRoles
        ///// </summary>
        ///// <param name="userID"></param>
        ///// <returns></returns>
        //public static DataSet GetUserProjectRoles(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetUserProjectRoles(userData);
        //}

        ///// <summary>
        ///// GetProjectRoles
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectRoles(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetProjectRoles(userData);
        //}

        ///// <summary>
        ///// GetUserProductsPreferred
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static DataSet GetUserProductsPreferred(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetUserProductsPreferred(userData);
        //}

        ///// <summary>
        ///// AddUpdateUserProjectRoles
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateUserProjectRoles(DTO.Users userData)
        //{
        //    return DAO.DAObjects.AddUpdateUserProjectRoles(userData);
        //}

        ///// <summary>
        ///// AddUpdateUserProducts
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateUserProducts(DTO.Users userData)
        //{
        //    if (userData.UserProductID == "")
        //    {
        //        return DAO.DAObjects.AddUserProducts(userData);
        //    }
        //    else
        //    {

        //        if (userData.UserProjectRoleID == "")
        //        {
        //            return DAO.DAObjects.DeleteUserProducts(userData);
        //        }
        //        else
        //        {
        //            return DAO.DAObjects.UpdateUserProducts(userData);
        //        }
        //    }
        //}

        //#endregion

        //#region MasterData Functions

        ///// <summary>
        ///// GetDetailsforMasterData
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <param name="columnNames"></param>
        ///// <returns></returns>
        //public static DataSet GetDetailsforMasterData(DTO.MasterData masterData)
        //{
        //    return DAO.DAObjects.GetDetailsforMasterData(masterData);
        //}

        ///// <summary>
        ///// GetMasterDataWithTypeDetails
        ///// </summary>
        //public static DataTable GetMasterDataWithTypeDetails(string tableName, bool isCode)
        //{
        //    DTO.MasterData masterData = new DTO.MasterData();
        //    masterData.TableName = tableName;

        //    DataTable typeDetailsDataTable = GetDetailsforMasterData(masterData).Tables[0];

        //    typeDetailsDataTable.Rows.RemoveAt(0);

        //    if (isCode)
        //        typeDetailsDataTable.Columns.RemoveAt(1);

        //    typeDetailsDataTable.Columns[0].ColumnName = WebConstants.COL_ID;
        //    typeDetailsDataTable.Columns[1].ColumnName = WebConstants.COL_DESCRIPTION;

        //    return typeDetailsDataTable;
        //}

        ///// <summary>
        ///// AddUpdateVendorDetailsforMasterData - To update records in Database
        ///// </summary>
        ///// <param name="masterData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateVendorDetailsforMasterData(DTO.MasterData masterData)
        //{
        //    if (masterData.MasterDataID == "")
        //    {
        //        return DAO.DAObjects.AddVendorDetailsforMasterData(masterData);
        //    }
        //    else
        //    {
        //        if (masterData.Description == "")
        //        {
        //            return DAO.DAObjects.DeleteDetailsforMasterData(masterData);
        //        }
        //        else
        //        {
        //            return DAO.DAObjects.UpdateVendorDetailsforMasterData(masterData);
        //        }
        //    }
        //}

        ///// <summary>
        ///// AddUpdateDetailsforMasterData - To update records in Database
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <param name="columnName"></param>
        ///// <param name="columnValue"></param>
        ///// <returns></returns>
        //public static bool AddUpdateDetailsforMasterData(DTO.MasterData masterData)
        //{
        //    if (masterData.MasterDataID == "")
        //    {
        //        return DAO.DAObjects.AddDetailsforMasterData(masterData);
        //    }
        //    else
        //    {
        //        if (masterData.Description == "")
        //        {
        //            return DAO.DAObjects.DeleteDetailsforMasterData(masterData);
        //        }
        //        else
        //        {
        //            return DAO.DAObjects.UpdateDetailsforMasterData(masterData);
        //        }
        //    }
        //}

        ///// <summary>
        ///// AddUpdateUserDetailsforMasterData
        ///// </summary>
        ///// <param name="masterData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateUserDetailsforMasterData(DTO.MasterData masterData)
        //{
        //    if (masterData.MasterDataID == "")
        //    {
        //        if (DAO.DAObjects.AddUserDetailsforMasterData(masterData))
        //        {
        //            DTO.MasterData vendorData = new DTO.MasterData();
        //            vendorData.TableName = WebConstants.TBL_USERS;
        //            vendorData.Code = GetUserID(masterData.Code).ToString();
        //            vendorData.Type = masterData.VendorID;

        //            return AddUpdateUserVendorAssociationsforMasterData(vendorData);
        //        }

        //    }
        //    else
        //    {
        //        DTO.MasterData vendorData = new DTO.MasterData();
        //        vendorData.TableName = WebConstants.TBL_USERS;
        //        vendorData.MasterDataID = masterData.UserVendorID == "" ? "-1" : masterData.UserVendorID;
        //        vendorData.ColumnNames = GetColumnNames(vendorData.TableName);

        //        if (AddUpdateUserVendorAssociationsforMasterData(vendorData))
        //        {
        //            if (masterData.Description == "")
        //            {
        //                return DAO.DAObjects.DeleteDetailsforMasterData(masterData);
        //            }
        //            else
        //            {
        //                if (DAO.DAObjects.UpdateUserDetailsforMasterData(masterData))
        //                {
        //                    vendorData.MasterDataID = "";
        //                    vendorData.Code = GetUserID(masterData.Code).ToString();
        //                    vendorData.Type = masterData.VendorID;
        //                    return AddUpdateUserVendorAssociationsforMasterData(vendorData);
        //                }
        //            }
        //        }
        //    }

        //    return false;
        //}

        ///// <summary>
        ///// GetUserVendorAssociations
        ///// </summary>
        ///// <param name="masterData"></param>
        ///// <returns></returns>
        //public static DataSet GetUserVendorAssociations(DTO.MasterData masterData)
        //{
        //    return DAO.DAObjects.GetUserVendorAssociations(masterData);
        //}

        ///// <summary>
        ///// AddUpdateUserVendorAssociationsforMasterData
        ///// </summary>
        ///// <param name="masterData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateUserVendorAssociationsforMasterData(DTO.MasterData masterData)
        //{
        //    if (masterData.MasterDataID == "")
        //    {
        //        return DAO.DAObjects.AddUserVendorAssociationsDetailsforMasterData(masterData);
        //    }
        //    else
        //    {
        //        if (masterData.Code == "")
        //        {
        //            return DAO.DAObjects.DeleteDetailsforMasterData(masterData);
        //        }
        //        else
        //        {
        //            return DAO.DAObjects.UpdateUserVendorAssociationsDetailsforMasterData(masterData);
        //        }
        //    }
        //}

        //#endregion

        //#region Product Version Details

        ///// <summary>
        ///// GetAllLocales
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetAllLocales()
        //{
        //    return DAO.DAObjects.GetAllLocales();
        //}

        ///// <summary>
        ///// GetProductVersionLocales
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static DataSet GetProductVersionLocales(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetProductVersionLocales(productData);
        //}

        ///// <summary>
        ///// GetAllPlatforms
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetAllPlatforms()
        //{
        //    return DAO.DAObjects.GetAllPlatforms();
        //}

        ///// <summary>
        ///// GetProductVersionPlatforms
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static DataSet GetProductVersionPlatforms(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetProductVersionPlatforms(productData);
        //}

        ///// <summary>
        ///// UpdateProductVersionLocalesAndPlatforms
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static bool UpdateProductVersionLocalesAndPlatforms(DTO.Product productData)
        //{
        //    return DAO.DAObjects.UpdateProductVersionLocalesAndPlatforms(productData);
        //}

        ///// <summary>
        ///// UpdateAboutProductDetails
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static bool UpdateAboutProductDetails(DTO.Product productData)
        //{
        //    return DAO.DAObjects.UpdateAboutProductDetails(productData);
        //}

        //#endregion

        //#region Project Phases

        ///// <summary>
        ///// GetProjectPhaseSummary
        ///// </summary>
        ///// <param name="projectPhasesData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectPhaseSummary(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.GetProjectPhaseSummary(projectPhaseData);
        //}

        ///// <summary>
        ///// GetProjectPhases
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectPhases(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.GetProjectPhases(projectPhaseData);
        //}

        ///// <summary>
        ///// GetProjectLocales
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectLocales(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.GetProjectLocales(projectPhaseData);
        //}

        ///// <summary>
        ///// GetProjectPlatforms
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectPlatforms(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.GetProjectPlatforms(projectPhaseData);
        //}

        ///// <summary>
        ///// GetPhaseCoverageDetails
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static DataSet GetPhaseCoverageDetails(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.GetPhaseCoverageDetails(projectPhaseData);
        //}

        ///// <summary>
        ///// GetPhaseExecutableTestCases
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static DataSet GetPhaseExecutableTestCases(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.GetPhaseExecutableTestCases(projectPhaseData);
        //}

        ///// <summary>
        ///// GetLocaleVsPlatformMatrixData
        ///// </summary>
        ///// <param name="projectPhasesData"></param>
        ///// <returns></returns>
        //public static DataSet GetLocaleVsPlatformMatrixData(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.GetLocaleVsPlatformMatrixData(projectPhaseData);
        //}

        ///// <summary>
        ///// AddUpdateProjectPhases
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateProjectPhases(DTO.ProjectPhases projectPhaseData)
        //{
        //    if (projectPhaseData.ProjectPhaseID == "")
        //    {
        //        return DAO.DAObjects.AddProjectPhase(projectPhaseData);
        //    }
        //    else
        //    {
        //        return DAO.DAObjects.UpdateProjectPhase(projectPhaseData);
        //    }
        //}

        ///// <summary>
        ///// CopyProjectPhasesData
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static bool CopyProjectPhasesData(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.CopyProjectPhasesData(projectPhaseData);
        //}

        ///// <summary>
        ///// UpdateProjectPhaseDetails
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static bool UpdateProjectPhaseDetails(DTO.ProjectPhases projectPhaseData)
        //{
        //    if (AddUpdateProjectPhases(projectPhaseData))
        //    {
        //        return DAO.DAObjects.UpdateProjectLocalesVsPlatforms(projectPhaseData);
        //    }

        //    return false;
        //}

        ///// <summary>
        ///// AddUpdateProjectPhaseCoverages
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateProjectPhaseCoverages(DTO.ProjectPhases projectPhaseData)
        //{
        //    if (projectPhaseData.CoverageDetailID == "")
        //    {
        //        return DAO.DAObjects.AddProjectPhaseCoverages(projectPhaseData);
        //    }
        //    else
        //    {
        //        if (projectPhaseData.ProjectPhaseCoverage != "")
        //            return DAO.DAObjects.UpdateProjectPhaseCoverages(projectPhaseData);
        //        else
        //            return DAO.DAObjects.DeleteProjectPhaseCoverages(projectPhaseData);
        //    }
        //}

        ///// <summary>
        ///// UpdateProjectLocalesVsPlatformsMatrix
        ///// </summary>
        ///// <param name="projectPhaseData"></param>
        ///// <returns></returns>
        //public static bool UpdateProjectLocalesVsPlatformsMatrix(DTO.ProjectPhases projectPhaseData)
        //{
        //    return DAO.DAObjects.UpdateProjectLocalesVsPlatformsMatrix(projectPhaseData);
        //}

        //#endregion

        //#region Product WindUp

        ///// <summary>
        ///// GetProjectWindUpDetails
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectWindUpDetails(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetProjectWindUpDetails(productData);
        //}

        ///// <summary>
        ///// GetProjectGMDetails
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static DataSet GetProjectGMDetails(DTO.Product productData)
        //{
        //    return DAO.DAObjects.GetProjectGMDetails(productData);
        //}

        ///// <summary>
        ///// AddUpdateWindUpDetails
        ///// </summary>
        ///// <param name="productData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateWindUpDetails(DTO.Product productData)
        //{
        //    if (productData.WindUpId == "")
        //    {
        //        return DAO.DAObjects.AddProjectWindUpDetails(productData);
        //    }
        //    else
        //    {
        //        return DAO.DAObjects.UpdateProjectWindUpDetails(productData);
        //    }
        //}

        ///// <summary>
        ///// AddUpdateProjectGMDetails
        ///// </summary>
        ///// <param name="productdata"></param>
        ///// <returns></returns>
        //public static bool AddUpdateProjectGMDetails(DTO.Product productData)
        //{
        //    if (productData.WindUpId == "")
        //    {
        //        if (AddUpdateWindUpDetails(productData))
        //        {
        //            productData.WindUpId = GetProjectWindUpDetails(productData).Tables[0].Rows[0][WebConstants.COL_PROJECT_WIND_UP_ID].ToString();
        //        }
        //        else
        //            return false;
        //    }

        //    if (productData.ProjectGMDetailID == "")
        //    {
        //        return DAO.DAObjects.AddProjectGMDetails(productData);
        //    }
        //    else
        //    {
        //        return DAO.DAObjects.UpdateProjectGMDetails(productData);
        //    }
        //}

        //#endregion

        //#region Holidays

        ///// <summary>
        ///// GetHolidaysWeek
        ///// </summary>
        ///// <param name="holidayData"></param>
        ///// <returns></returns>
        //public static DataSet GetHolidaysDate(DTO.Holidays holidayData)
        //{
        //    return DAO.DAObjects.GetHolidaysDate(holidayData);
        //}

        ///// <summary>
        ///// GetHolidaysList
        ///// </summary>
        ///// <param name="holidayData"></param>
        ///// <returns></returns>
        //public static DataSet GetHolidaysList(DTO.Holidays holidayData)
        //{
        //    return DAO.DAObjects.GetHolidaysList(holidayData);
        //}

        ///// <summary>
        ///// AddUpdateHolidaysList
        ///// </summary>
        ///// <param name="holidayData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateHolidaysListData(DTO.Holidays holidayData)
        //{
        //    if (holidayData.HolidayID == "")
        //    {
        //        return DAO.DAObjects.AddHolidaysListData(holidayData);
        //    }
        //    else
        //    {
        //        if (holidayData.HolidayReason == "")
        //        {
        //            return DAO.DAObjects.DeleteHolidaysListData(holidayData);
        //        }
        //        else
        //        {
        //            return DAO.DAObjects.UpdateHolidaysListData(holidayData);
        //        }
        //    }
        //}

        //#endregion

        //#region Screens

        ///// <summary>
        ///// GetUserScreenAccess
        ///// </summary>
        ///// <param name="userData"></param>
        ///// <returns></returns>
        //public static DataSet GetUserScreenAccess(DTO.Users userData)
        //{
        //    return DAO.DAObjects.GetUserScreenAccess(userData);
        //}

        ///// <summary>
        ///// GetScreensDetails
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetScreensDetails(DTO.Screens screenData)
        //{
        //    return DAO.DAObjects.GetScreensDetails(screenData);
        //}

        ///// <summary>
        ///// GetMasterScreensDetails
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetMasterScreensDetails(DTO.Screens screenData)
        //{
        //    return DAO.DAObjects.GetMasterScreensDetails(screenData);
        //}

        ///// <summary>
        ///// GetScreensData
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetScreensData()
        //{
        //    return DAO.DAObjects.GetScreensData();
        //}

        ///// <summary>
        ///// GetScreenLocalizedLabels
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetScreenLocalizedLabels(DTO.Screens screenData)
        //{
        //    return DAO.DAObjects.GetScreenLocalizedLabels(screenData);
        //}

        ///// <summary>
        ///// AddUpdateScreensDetails
        ///// </summary>
        ///// <param name="screensData"></param>
        ///// <returns></returns>
        //public static bool AddUpdateScreensDetails(DTO.Screens screensData)
        //{
        //    if (screensData.ScreenID == "")
        //    {
        //        return DAO.DAObjects.AddScreensDetails(screensData);
        //    }
        //    else
        //    {
        //        if (screensData.ScreenIdentifier == "")
        //        {
        //            return DAO.DAObjects.DeleteScreensDetails(screensData);
        //        }
        //        else
        //        {
        //            return DAO.DAObjects.UpdateScreensDetails(screensData);
        //        }
        //    }
        //}

        ///// <summary>
        ///// AddUpdateScreensAccessDetails
        ///// </summary>
        ///// <param name="accessList"></param>
        ///// <returns></returns>
        //public static bool AddUpdateScreensAccessDetails(ArrayList accessList)
        //{
        //    return DAO.DAObjects.AddUpdateScreensAccessDetails(accessList);
        //}

        ///// <summary>
        ///// UpdateScreenLocalizedValues
        ///// </summary>
        ///// <param name="screenData"></param>
        ///// <returns></returns>
        //public static bool UpdateScreenLocalizedValues(DTO.Screens screenData)
        //{
        //    return DAO.DAObjects.UpdateScreenLocalizedValues(screenData);
        //}

        //#endregion

        //#region Other Common Functions

        ///// <summary>
        ///// GetColumnNames
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <returns></returns>
        //public static ArrayList GetColumnNames(string tableName)
        //{
        //    DataSet columnsDataSet = DAO.DAObjects.GetColumnNames(tableName);
        //    ArrayList columnNames = new ArrayList();

        //    foreach (DataRow row in columnsDataSet.Tables[0].Rows)
        //    {
        //        columnNames.Add(row[0]);
        //    }

        //    return columnNames;
        //}

        ///// <summary>
        ///// Takes a dataset and creates a OPENXML script dynamically around it for 
        ///// bulk inserts 
        ///// </summary> 
        ///// <remarks>The DataSet must have at least one primary key, otherwise it'll wipe 
        ///// out the entire table, then insert the dataset. Multiple Primary Keys are okay. 
        ///// The dataset's columns must match the target table's columns EXACTLY. A 
        ///// dataset column "democd" does not work for the sql column
        ///// "DemoCD". Any missing or incorrect data is assumed NULL (default).
        ///// </remarks>
        ///// <param name="objDS">Dataset containing target DataTable.
        ///// <param name="objCon">Open Connection to the database.
        ///// <param name="tablename">Name of table to save.
        //public static void BulkTableInsert(DataTable objDS, string tableName)
        //{
        //    //Change the column mapping first.
        //    objDS.TableName = tableName;
        //    DAO.DAObjects.BulkTableInsert(objDS, GetColumnNames(tableName));
        //    //http://www.codeproject.com/KB/database/generic_OpenXml.aspx
        //}

        ///// <summary>
        ///// GetDataFromXLSM
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="p"></param>
        ///// <returns></returns>
        //public static DataSet GetDataFromXLSM(string fileName, string sheetName)
        //{
        //    return DAO.DAObjects.GetDataFromXLSM(fileName, sheetName);
        //}

        //#endregion

        /// <summary>
        /// GetRSyncProducts
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRSyncProducts()
        {
            //string[] lines = File.ReadAllLines(String.Format("\\\\{0}\\system\\rsync.cfn", rsyncServerAddress));

            //foreach (string line in lines)
            //{
            //    string[] productInfo = line.Split(new string[] { "::::" }, StringSplitOptions.None);

            //    if (productInfo[0] == productName)
            //    {
            //        productCode = productInfo[1];
            //        break;
            //    }
            //}
            return null;
        }
    }
}
