namespace Bustop.Hanlders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Web.Script.Serialization;
    using System.Web.SessionState;
    using System.Collections;
    using System.IO;
    using CargoManagementSystem;
    using System.Net;
    using System.Net.Mail;
    using System.Globalization;
    using System.Diagnostics;
    /// <summary>
    /// Summary description for Bus
    /// </summary>
    public class Bus : IHttpHandler, IRequiresSessionState
    {
        string username = "";

        public bool IsReusable
        {
            get { return true; }
        }

        public class vehiclesclass
        {
            public string vehicleno { get; set; }
            public string vehicletype { get; set; }
        }

        public class Groupsclass
        {
            public string groupname { get; set; }
            public List<string> vehicleno { get; set; }
        }
        ////{"op":"Product_SyncData","BranchID":"orderdetail","":{"SNo":4,"Product":"BMILK200","ProductSno":"99","Returnqty":"5","Status":"Delivered","IndentNo":"7726","hdnSno":4,"HdnIndentSno":"7726","orderunitRate":"18","LeakQty":"1","RemainQty":"1","BranchID":"274"}}

        class orderdetail
        {
            public string SNo { set; get; }
            public string Product { set; get; }
            public string Productsno { set; get; }
            public string Qty { set; get; }
            public string Rate { set; get; }
            public string Total { set; get; }
            public string ReturnQty { set; get; }
            public string ExtraQty { set; get; }
            public string Status { set; get; }
            public string Unitsqty { set; get; }
            public string UnitCost { set; get; }
            public string IndentNo { set; get; }
            public string hdnSno { set; get; }
            public string orderunitRate { set; get; }
            public string HdnIndentSno { set; get; }
            public string LeakQty { set; get; }
            public string RemainQty { set; get; }
            public string ShortQty { set; get; }
            public string FreeMilk { set; get; }
            public string BranchID { set; get; }
            public string DelDate { set; get; }
            public string IndentType { set; get; }
            public string end { set; get; }
            
        }
        class OfferDeliveryData
        {
            public string SNo { set; get; }
            public string Product { set; get; }
            public string Productsno { set; get; }
            public string Qty { set; get; }
            public string Rate { set; get; }
            public string Total { set; get; }
            public string ReturnQty { set; get; }
            public string ExtraQty { set; get; }
            public string Status { set; get; }
            public string Unitsqty { set; get; }
            public string UnitCost { set; get; }
            public string IndentNo { set; get; }
            public string hdnSno { set; get; }
            public string orderunitRate { set; get; }
            public string HdnIndentSno { set; get; }
            public string LeakQty { set; get; }
            public string RemainQty { set; get; }
            public string ShortQty { set; get; }
            public string FreeMilk { set; get; }
            public string BranchID { set; get; }
            public string DelDate { set; get; }
            public string IndentType { set; get; }
            public string end { set; get; }
        }
        class NextIndentdetail
        {
            public string SNo { set; get; }
            public string Product { set; get; }
            public string Productsno { set; get; }
            public string Qty { set; get; }
            public string Rate { set; get; }
            public string Total { set; get; }
            public string ReturnQty { set; get; }
            public string ExtraQty { set; get; }
            public string Status { set; get; }
            public string Unitsqty { set; get; }
            public string UnitCost { set; get; }
            public string IndentNo { set; get; }
            public string hdnSno { set; get; }
            public string orderunitRate { set; get; }
            public string HdnIndentSno { set; get; }
            public string LeakQty { set; get; }
            public string RemainQty { set; get; }
            public string ShortQty { set; get; }
            public string FreeMilk { set; get; }
            public string BranchID { set; get; }
            public string DelDate { set; get; }
            public string IndentType { set; get; }
            public string end { set; get; }


        }
        class OfferNextIndentdetail
        {
            public string SNo { set; get; }
            public string Product { set; get; }
            public string Productsno { set; get; }
            public string Qty { set; get; }
            public string Rate { set; get; }
            public string Total { set; get; }
            public string ReturnQty { set; get; }
            public string ExtraQty { set; get; }
            public string Status { set; get; }
            public string Unitsqty { set; get; }
            public string UnitCost { set; get; }
            public string IndentNo { set; get; }
            public string hdnSno { set; get; }
            public string orderunitRate { set; get; }
            public string HdnIndentSno { set; get; }
            public string LeakQty { set; get; }
            public string RemainQty { set; get; }
            public string ShortQty { set; get; }
            public string FreeMilk { set; get; }
            public string BranchID { set; get; }
            public string DelDate { set; get; }
            public string IndentType { set; get; }
            public string end { set; get; }
        }
        class Inventorydetail
        {
            public string SNo { set; get; }
            public string InvSno { set; get; }
            public string GivenQty { set; get; }
            public string ReceivedQty { set; get; }
            public string BalanceQty { set; get; }
            public string BrancID { set; get; }
            public string DInvDate { set; get; }
            public string CInvDate { set; get; }
        }
        class CInventorydetail
        {
            public string SNo { set; get; }
            public string InvSno { set; get; }
            public string GivenQty { set; get; }
            public string ReceivedQty { set; get; }
            public string BalanceQty { set; get; }
            public string BrancID { set; get; }
            public string DInvDate { set; get; }
            public string CInvDate { set; get; }
        }
        class Amountdetail
        {
            public string BrancID { set; get; }
            public string Amount { set; get; }
            public string PayType { set; get; }
            public string TodayAmount { set; get; }
            public string checkNo { set; get; }
            public string BalanceAmount { set; get; }
            public string Coldate { set; get; }
            public string ReturnDenomonation { set; get; }
        }
        class InvDatails
        {
            public string SNo { set; get; }
            public string Qty { set; get; }
            public string TripID { set; get; }
        }
        class Leakagedetail
        {
            public string SNo { set; get; }
            public string ProductID { set; get; }
            public string LeakageQty { set; get; }
            public string DeductionAmount { set; get; }

            public string Product { set; get; }
            public string Productsno { set; get; }
            public string Qty { set; get; }
            public string Rate { set; get; }
            public string Total { set; get; }
            public string ReturnQty { set; get; }
            public string ExtraQty { set; get; }
            public string Status { set; get; }
            public string Unitsqty { set; get; }
            public string UnitCost { set; get; }
            public string IndentNo { set; get; }
            public string hdnSno { set; get; }
            public string orderunitRate { set; get; }
            public string HdnIndentSno { set; get; }
            public string LeakQty { set; get; }
            public string RemainQty { set; get; }
            public string ShortQty { set; get; }
            public string FreeMilk { set; get; }
            public string BranchID { set; get; }
            public string DelDate { set; get; }
            public string IndentType { set; get; }
            public string end { set; get; }
        }
        class RouteLeakdetails
        {
            public string SNo { set; get; }
            public string ProductID { set; get; }
            public string LeaksQty { set; get; }
            public string ReturnsQty { set; get; }
            public string TripID { set; get; }
        }
        class branchsignature
        {
            public string SNo { set; get; }
            public string BrancID { set; get; }
            public string Sign { set; get; }
        }
        class Orders
        {
            public string op { set; get; }
            public string BranchID { set; get; }
            public List<orderdetail> data { set; get; }
            public List<OfferDeliveryData> OfferDeliveryData { set; get; }
            public List<Inventorydetail> Inventorydetails { set; get; }
            public List<CInventorydetail> CInventorydetail { set; get; }
            public List<Amountdetail> Amountdetail { set; get; }
            public List<branchsignature> Signaturedetail { set; get; }
            public branchsignature Signature_detail { set; get; }
            public List<Leakagedetail> Leakagedetails { set; get; }
            public List<RouteLeakdetails> RouteLeakdetails { set; get; }
            public List<InvDatails> InvDatails { set; get; }
            public List<NextIndentdetail> NextIndentdetail { set; get; }
            public List<OfferNextIndentdetail> OfferNextIndentdetail { set; get; }

            public orderdetail order_detail { get; set; }
            public Inventorydetail Inventory_detail { get; set; }
            public CInventorydetail CInventory_detail { get; set; }
            public Amountdetail Amount_detail { get; set; }

            public string totqty { set; get; }
            public string totrate { set; get; }
            public string totTotal { set; get; }
            public string Status { set; get; }
            public string IndentNo { set; get; }
            public string TotalPrice { set; get; }
            public string BalanceAmount { set; get; }
            public string PaidAmount { set; get; }
            public string TotalCost { set; get; }
            public string Remarks { set; get; }
            public string PaymentType { set; get; }
            public string Denominations { set; get; }
            public string ColAmount { set; get; }
            public string SubAmount { set; get; }
            public string IndentType { set; get; }
            public string EmpName { set; get; }
            public string RouteId { set; get; }
            public string SaveType { set; get; }
            public string DispDate { set; get; }
            public string end { set; get; }
        }
        public void ProcessRequest(HttpContext context)
        {
            string ErrMsg = "Default";
            try
            {
                string operation = context.Request["op"];
                string endchk = context.Request["end"];
                switch (operation)
                {
                    case "getBranchValues":
                        getBranchValues(context);
                        break;
                    case "getOrders_f_t_dates":
                        getOrders_f_t_dates(context);
                        break;
                    case "getBranchValuesamount":
                        getBranchValuesamount(context);
                        break;
                    case "getTodayDate":
                        getTodayDate(context);
                        break;
                    case "GetInventoryNames":
                        GetInventoryNames(context);
                        break;
                    case "GetProductNamechange":
                        GetProductNamechange(context);
                        break;
                    case "GetDeliverInventory":
                        GetDeliverInventory(context);
                        break;
                    case "getBranchLeakeges":
                        getBranchLeakeges(context);
                        break;
                    case "FillCategeoryname":
                        FillCategeoryname(context);
                        break;
                    case "get_product_subcategory_data":
                        get_product_subcategory_data(context);
                        break;
                    case "get_products_data":
                        get_products_data(context);
                        break;
                    case "AddBranchProducts":
                        AddBranchProducts(context);
                        break;
                    case "GetInvReport":
                        GetInvReport(context);
                        break;
                    case "getReportAmount":
                        getReportAmount(context);
                        break;
                    case "GetRouteNameChange":
                        GetRouteNameChange(context);
                        break;
                    case "CollectionReports":
                        CollectionReports(context);
                        break;
                    case "GetProductIndent":
                        GetProductIndent(context);
                        break;
                    case "GetIndentStatus":
                        GetIndentStatus(context);
                        break;
                    case "GetDispatchAgents":
                        GetDispatchAgents(context);
                        break;
                    case "GetDispatchBranch":
                        GetDispatchBranch(context);
                        break;
                    case "GetIndentType":
                        GetIndentType(context);
                        break;
                    case "GetCsodispatchRoutes":
                        GetCsodispatchRoutes(context);
                        break;
                    case "GetSOEmployeeNames":
                        GetSOEmployeeNames(context);
                        break;
                    case "GetDispProducts":
                        GetDispProducts(context);
                        break;
                    case "GetShortageProducts":
                        GetShortageProducts(context);
                        break;
                    case "GetCollectionStatus":
                        GetCollectionStatus(context);
                        break;
                    case "GetDispInventory":
                        GetDispInventory(context);
                        break;
                    case "GetTripNo":
                        GetTripNo(context);
                        break;
                    case "getOrderStatus":
                        getOrderStatus(context);
                        break;
                    case "GetVerifyInventory":
                        GetVerifyInventory(context);
                        break;
                    case "DeliverReportclick":
                        DeliverReportclick(context);
                        break;
                    case "GetReturnLeakReport":
                        GetReturnLeakReport(context);
                        break;
                    case "GetVerifyLeaks":
                        GetVerifyLeaks(context);
                        break;
                    case "GetVerifyReturns":
                        GetVerifyReturns(context);
                        break;
                    case "ValidateLogin":
                        ValidateLogin(context);
                        break;
                    case "GetPermissions":
                        GetPermissions(context);
                        break;
                    case "IndentReportSaveclick":
                        IndentReportSaveclick(context);
                        break;
                    case "getProductsData":
                        getProductsData(context);
                        break;
                    case "GetOffLineIndentData":
                        GetOffLineIndentData(context);
                        break;
                    case "GetOffLineInventoryData":
                        GetOffLineInventoryData(context);
                        break;
                    case "GetOfferProducts":
                        GetOfferProducts(context);
                        break;
                    case "GetOfferIndent":
                        GetOfferIndent(context);
                        break;
                    case "GetOfflineLogin":
                        GetOfflineLogin(context);
                        break;
                    case "GetOfflineCategeory":
                        GetOfflineCategeory(context);
                        break;
                    case "GetofflineSubCategory":
                        GetofflineSubCategory(context);
                        break;
                    case "GetOffLineTripSubData":
                        GetOffLineTripSubData(context);
                        break;
                    case "GetOffLineTripInvData":
                        GetOffLineTripInvData(context);
                        break;
                    case "getBranchProductsData":
                        getBranchProductsData(context);
                        break;
                    case "getSalesOfficeBranchProductsdata":
                        getSalesOfficeBranchProductsdata(context);
                        break;
                    case "GetVersionName":
                        GetVersionName(context);
                        break;
                    case "getdispatches":
                        getdispatches(context);
                        break;
                    case "getrouteindent":
                        getrouteindent(context);
                        break;
                    case "GetProductInformation":
                        GetProductInformation(context);
                        break;
                    case "GetDeliverInventoryInformation":
                        GetDeliverInventoryInformation(context);
                        break;
                    case "GetColInventoryInformation":
                        GetColInventoryInformation(context);
                        break;
                    case "GetColAmount":
                        GetColAmount(context);
                        break;
                    case "FinalSyncClick":
                        FinalSyncClick(context);
                        break;
                    case "Sendmail":
                        Sendmail(context);
                        break;
                    case "SendSms":
                        SendSms(context);
                        break;
                    case "sync_start":
                        List<orderdetail> indentlist = new List<orderdetail>();
                        context.Session["indent_syncData"] = indentlist;
                        List<Inventorydetail> Inventorylist = new List<Inventorydetail>();
                        context.Session["inventory_syncData"] = Inventorylist;

                        List<Amountdetail> Amountlist = new List<Amountdetail>();
                        context.Session["Amount_syncData"] = Amountlist;
                        List<CInventorydetail> CollectionInventorylist = new List<CInventorydetail>();
                        context.Session["Collection_inventory_syncData"] = CollectionInventorylist;

                        List<orderdetail> Nextindentlist = new List<orderdetail>();
                        context.Session["indent_Next_syncData"] = Nextindentlist;


                        string msg = "success";
                        string response = GetJson(msg);
                        context.Response.Write(response);
                        break;
                        string sync_end_msg = "";
                    case "sync_end":
                        break;

                    default:
                        var jsonString = String.Empty;
                        context.Request.InputStream.Position = 0;
                        using (var inputStream = new StreamReader(context.Request.InputStream))
                        {
                            jsonString = HttpUtility.UrlDecode(inputStream.ReadToEnd());
                        }
                        if (jsonString == "")
                        {

                        }
                        else
                        {
                            var js = new JavaScriptSerializer();
                            //var title1 = context.Request.Params[1];
                            Orders obj = js.Deserialize<Orders>(jsonString);
                            if (obj.op == "btnOrderSaveClick")
                            {
                                btnOrderSaveClick(context);
                            }
                            if (obj.op == "btnDeliversSaveClick")
                            {
                                btnDeliversSaveClick(context);
                            }
                            if (obj.op == "CollectionSaveClick")
                            {
                                CollectionSaveClick(context);
                            }
                            if (obj.op == "btnRemarksSaveClick")
                            {
                                btnRemarksSaveClick(jsonString, context);
                            }
                            if (obj.op == "btnDispatchSaveClick")
                            {
                                btnDispatchSaveClick(context);
                            }
                            if (obj.op == "btnShoratageSaveClick")
                            {
                                btnShoratageSaveClick(context);
                            }
                            if (obj.op == "btnReportingInventoryclick")
                            {
                                btnReportingInventoryclick(jsonString,context);
                            }
                            if (obj.op == "btnInventoryVerifySaveClick")
                            {
                                btnInventoryVerifySaveClick(context);
                            }
                            if (obj.op == "btnLeakVarifySaveClick")
                            {
                                btnLeakVarifySaveClick(context);
                            }
                            if (obj.op == "btnReturnsVarifySaveClick")
                            {
                                btnReturnsVarifySaveClick(context);
                            }
                            if (obj.op == "Product_SyncData")
                            {
                                //string msgs = context.Request["end"];// "Success";
                                ProductsSyncSaveClick(jsonString, context);
                                //context.Request["op"]
                            }
                            if (obj.op == "Inventory_SyncData")
                            {
                                InventorySaveClick(context, obj);
                            }
                            if (obj.op == "Amount_SyncData")
                            {
                                BranchAmount1SyncSaveClick(context, obj);
                            }
                            if (obj.op == "Collection_Inventory_SyncData")
                            {
                                CollectionInventorySaveClick(context, obj);
                            }
                            if (obj.op == "Agent_Signature_SyncData")
                            {
                                //Agent_Signature_SyncData(context, obj);
                                Agent_Signature_SyncData(jsonString, context);


                            }
                            if (obj.op == "NextIndent_SyncData")
                            {
                                //OfflineIndentSyncSaveClick(context, obj);
                                OfflineIndentSyncSaveClick(jsonString, context);
                                
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                string toAddress = "ravindra1507@gmail.com";
                string subject = "Vyshnavi Offline";
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();
                string body = "";
               // int linenum = 0;
                //linenum = Convert.ToInt32(ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')));

                if (context.Session["TripdataSno"] == null)
                {
                    //body = ex.ToString() + "ErrMsg" + ErrMsg + linenum;
                    body = ex.ToString() + "ErrMsg" + ErrMsg;
                }
                else
                {
                    //body = context.Session["TripdataSno"].ToString() + ex.ToString() + "ErrMsg" + ErrMsg + linenum;
                    body = context.Session["TripdataSno"].ToString() + ex.ToString() + "ErrMsg" + ErrMsg;
                }
                SendEmail(toAddress, subject, body);
            }
        }
        public class routeclass
        {
            public string sno { get; set; }
            public string routename { get; set; }
            public string agentname { get; set; }
            public string productsno { get; set; }
            public string ProductName { get; set; }
            public string unitQty { get; set; }
            public string UnitCost { get; set; }

        }
        private void GetColAmount(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<SyncInvewntory> SyncInvlist = new List<SyncInvewntory>();
                cmd = new MySqlCommand("SELECT SUM(AmountPaid) AS Amount FROM collections WHERE (tripId = @TripID)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                DataTable dtCol = vdm.SelectQuery(cmd).Tables[0];
                string Amount = "0";
                if (dtCol.Rows.Count > 0)
                {
                    Amount = dtCol.Rows[0]["Amount"].ToString();
                }
                string response = GetJson(Amount);
                context.Response.Write(response);
            }
            catch
            {

            }
        }
        private void GetColInventoryInformation(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<SyncInvewntory> SyncInvlist = new List<SyncInvewntory>();
                //cmd = new MySqlCommand("SELECT invmaster.sno, invmaster.InvName, SUM(invtransactions12.Qty) AS Qty FROM invmaster INNER JOIN invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno WHERE (invtransactions12.ToTran = @TripID) AND (invtransactions12.TransType = @TransType) GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                cmd = new MySqlCommand("SELECT SUM(invtransactions12.Qty) AS Qty FROM invmaster INNER JOIN invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno WHERE (invtransactions12.ToTran = @TripID) AND (invtransactions12.TransType = @TransType) AND (invtransactions12.FromTran <> @branchid)");

                cmd.Parameters.Add("@TransType", 3);
                cmd.Parameters.Add("@branchid", context.Session["BranchSno"].ToString());
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                DataTable dtDelInv = vdm.SelectQuery(cmd).Tables[0];
                //foreach (DataRow dr in dtDelInv.Rows)
                //{
                //    SyncInvewntory initializedata = new SyncInvewntory();
                //    initializedata.sno = dr["sno"].ToString();
                //    initializedata.InvName = dr["InvName"].ToString();
                //    initializedata.Qty = dr["Qty"].ToString();
                //    SyncInvlist.Add(initializedata);
                //}
                string Invcoll = "0";
                if (dtDelInv.Rows.Count > 0)
                {
                    Invcoll = dtDelInv.Rows[0]["Qty"].ToString();
                }
                string response = GetJson(Invcoll);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetDeliverInventoryInformation(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<SyncInvewntory> SyncInvlist = new List<SyncInvewntory>();
                // cmd = new MySqlCommand("SELECT invmaster.sno, invmaster.InvName, SUM(invtransactions12.Qty) AS Qty FROM invmaster INNER JOIN invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno WHERE (invtransactions12.FromTran = @TripID) AND (invtransactions12.TransType = @TransType) GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                cmd = new MySqlCommand("SELECT invmaster.sno, invmaster.InvName, SUM(invtransactions12.Qty) AS QTY, invtransactions12.FromTran, invtransactions12.ToTran FROM invmaster INNER JOIN invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno WHERE (invtransactions12.TransType = @TransType) AND (invtransactions12.FromTran = @TripID) AND (invtransactions12.ToTran <> @branchid)");
                cmd.Parameters.Add("@TransType", 2);
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@branchid", context.Session["BranchSno"].ToString());

                DataTable dtDelInv = vdm.SelectQuery(cmd).Tables[0];
                //foreach (DataRow dr in dtDelInv.Rows)
                //{
                //    SyncInvewntory initializedata = new SyncInvewntory();
                //    initializedata.sno = dr["sno"].ToString();
                //    initializedata.InvName = dr["InvName"].ToString();
                //    initializedata.Qty = dr["Qty"].ToString();
                //    SyncInvlist.Add(initializedata);
                //}
                string Invdell = "0";
                if (dtDelInv.Rows.Count > 0)
                {
                    Invdell = dtDelInv.Rows[0]["QTY"].ToString();
                }
                string response = GetJson(Invdell);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class SyncInvewntory
        {
            public string InvName { get; set; }
            public string Qty { get; set; }
            public string sno { get; set; }
        }
        private void GetProductInformation(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<SyncProducts> SyncProductslist = new List<SyncProducts>();

                cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS DeliveryQty, indents.Branch_id, indents_subtable.UnitCost FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo WHERE (indents_subtable.DTripId = @TripID) GROUP BY indents.Branch_id");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                DataTable dtAgentWiseSaleValue = vdm.SelectQuery(cmd).Tables[0];
                float totAmount = 0;
                float PrevAmount = 0;
                int BranchID = 0;
                foreach (DataRow dr in dtAgentWiseSaleValue.Rows)
                {
                    float.TryParse(dr["DeliveryQty"].ToString(), out totAmount);
                    int.TryParse(dr["Branch_id"].ToString(), out BranchID);

                    cmd = new MySqlCommand("SELECT BranchId, Amount, FineAmount, Dtripid, Ctripid, SaleValue FROM branchaccounts WHERE (Dtripid = @Dtripid) AND (BranchId = @BranchId)");
                    cmd.Parameters.Add("@BranchId", BranchID);
                    cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                    DataTable dtprevsalevalue = vdm.SelectQuery(cmd).Tables[0];
                    if (dtprevsalevalue.Rows.Count > 0)
                    {
                        //float.TryParse(dr["SaleValue"].ToString(), out PrevAmount);
                        float.TryParse(dtprevsalevalue.Rows[0]["SaleValue"].ToString(), out PrevAmount);
                        float diffamount = 0;
                        diffamount = PrevAmount - totAmount;
                        if (PrevAmount < totAmount)
                        {
                            cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount,Dtripid=@Dtripid,SaleValue=@SaleValue where BranchId=@BranchId");
                            cmd.Parameters.Add("@Amount", diffamount);
                            cmd.Parameters.Add("@BranchId", BranchID);
                            cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@SaleValue", totAmount);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId,Dtripid,SaleValue) values(@Amount,@BranchId,@Dtripid,@SaleValue)");
                                cmd.Parameters.Add("@Amount", diffamount);
                                cmd.Parameters.Add("@BranchId", BranchID);
                                cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@SaleValue", totAmount);
                                vdm.insert(cmd);
                            }
                        }
                        else
                        {
                            diffamount = Math.Abs(diffamount);
                            cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount,Dtripid=@Dtripid,SaleValue=@SaleValue where BranchId=@BranchId");
                            cmd.Parameters.Add("@Amount", diffamount);
                            cmd.Parameters.Add("@BranchId", BranchID);
                            cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@SaleValue", totAmount);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId,Dtripid,SaleValue) values(@Amount,@BranchId,@Dtripid,@SaleValue)");
                                cmd.Parameters.Add("@Amount", diffamount);
                                cmd.Parameters.Add("@BranchId", BranchID);
                                cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@SaleValue", totAmount);
                                vdm.insert(cmd);
                            }
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount,Dtripid=@Dtripid,SaleValue=@SaleValue where BranchId=@BranchId");
                        cmd.Parameters.Add("@Amount", totAmount);
                        cmd.Parameters.Add("@BranchId", BranchID);
                        cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                        cmd.Parameters.Add("@SaleValue", totAmount);
                        if (vdm.Update(cmd) == 0)
                        {
                            cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId,Dtripid,SaleValue) values(@Amount,@BranchId,@Dtripid,@SaleValue)");
                            cmd.Parameters.Add("@Amount", totAmount);
                            cmd.Parameters.Add("@BranchId", BranchID);
                            cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@SaleValue", totAmount);
                            vdm.insert(cmd);
                        }
                    }
                }
                cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty FROM indents_subtable INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents_subtable.DTripId = @TripID)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                DataTable dtProducts = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtProducts.Rows)
                {
                    SyncProducts initializedata = new SyncProducts();
                    initializedata.sno = dr["sno"].ToString();
                    initializedata.ProductName = dr["ProductName"].ToString();
                    initializedata.DeliveryQty = dr["DeliveryQty"].ToString();
                    SyncProductslist.Add(initializedata);
                }
                string productdelivery = "0";
                if (dtProducts.Rows.Count > 0)
                {
                    productdelivery = dtProducts.Rows[0]["DeliveryQty"].ToString();
                }
                string response = GetJson(productdelivery);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class SyncProducts
        {
            public string ProductName { get; set; }
            public string DeliveryQty { get; set; }
            public string sno { get; set; }
        }
        private void getdispatches(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                String UserName = context.Request["username"].ToString();// txtUserName.Text, 
                String PassWord = context.Request["password"].ToString(); //txtPassword.Text;
                List<routeclass> initializedatalist = new List<routeclass>();
                cmd = new MySqlCommand("SELECT dispatch.sno, dispatch.DispName FROM empmanage INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id WHERE (empmanage.UserName = @username) AND (empmanage.Password = @password)");
                cmd.Parameters.Add("@username", UserName);
                cmd.Parameters.Add("@password", PassWord);
                foreach (DataRow dr in vdm.SelectQuery(cmd).Tables[0].Rows)
                {
                    routeclass initializedata = new routeclass();
                    initializedata.sno = dr["sno"].ToString();
                    initializedata.routename = dr["DispName"].ToString();
                    initializedatalist.Add(initializedata);
                }
                if (initializedatalist != null)
                {
                    string response = GetJson(initializedatalist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        private void getrouteindent(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                String dispatchid = context.Request["dispatchid"].ToString();
                String indenttype = context.Request["indent"].ToString();
                List<routeclass> indentlist = new List<routeclass>();

                cmd = new MySqlCommand("SELECT MAX(indents.I_date) AS idate FROM dispatch INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id WHERE (dispatch.sno = @dispsno)");
                cmd.Parameters.Add("@dispsno", dispatchid);
                DataTable dtmaxdate = vdm.SelectQuery(cmd).Tables[0];
                string max_indentdate = dtmaxdate.Rows[0]["idate"].ToString();
                DateTime dtmaxindent = Convert.ToDateTime(max_indentdate);
                if (indenttype == "1")
                {
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno, indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.ProductName, indents_subtable.Product_sno FROM dispatch INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, TotalQty, TotalPrice, I_date, D_date, Status, UserData_sno, PaymentStatus, I_createdby, I_modifiedby, IndentType FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) inden ON branchdata.sno = inden.Branch_id INNER JOIN indents_subtable ON inden.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) GROUP BY branchdata.sno, indents_subtable.Product_sno");
                    cmd.Parameters.Add("@dispatchsno", dispatchid);
                    cmd.Parameters.Add("@d1", GetLowDate(dtmaxindent));
                    cmd.Parameters.Add("@d2", GetHighDate(dtmaxindent));
                    // DataTable dtindent = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in vdm.SelectQuery(cmd).Tables[0].Rows)
                    {
                        routeclass indent = new routeclass();
                        indent.sno = dr["sno"].ToString();
                        indent.agentname = dr["BranchName"].ToString();
                        indent.productsno = dr["Product_sno"].ToString();
                        indent.ProductName = dr["ProductName"].ToString();
                        indent.unitQty = dr["unitQty"].ToString();
                        indent.UnitCost = dr["UnitCost"].ToString();
                        indentlist.Add(indent);
                    }
                }
                else
                {
                    cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS orderqty, indents_subtable.UnitCost, productsdata.ProductName, indents_subtable.Product_sno FROM dispatch INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, TotalQty, TotalPrice, I_date, D_date, Status, UserData_sno, PaymentStatus, I_createdby, I_modifiedby, IndentType FROM  indents WHERE (I_date BETWEEN @d1 AND @d2)) inden ON branchdata.sno = inden.Branch_id INNER JOIN indents_subtable ON inden.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) GROUP BY indents_subtable.Product_sno");
                    cmd.Parameters.Add("@dispatchsno", dispatchid);
                    cmd.Parameters.Add("@d1", GetLowDate(dtmaxindent));
                    cmd.Parameters.Add("@d2", GetHighDate(dtmaxindent));
                    // DataTable dtindent = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in vdm.SelectQuery(cmd).Tables[0].Rows)
                    {
                        routeclass indent = new routeclass();
                        // indent.sno = dr["sno"].ToString();
                        //indent.agentname = dr["BranchName"].ToString();
                        indent.productsno = dr["Product_sno"].ToString();
                        indent.ProductName = dr["ProductName"].ToString();
                        double orderqty = 0;
                        double.TryParse(dr["orderqty"].ToString(), out orderqty);
                        indent.unitQty = Math.Round(orderqty, 2).ToString();
                        //indent.UnitCost = dr["UnitCost"].ToString();
                        indentlist.Add(indent);
                    }
                }
                if (indentlist != null)
                {
                    string response = GetJson(indentlist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        private DateTime GetLowDate(DateTime dt)
        {
            double Hour, Min, Sec;
            DateTime DT = DateTime.Now;
            DT = dt;
            Hour = -dt.Hour;
            Min = -dt.Minute;
            Sec = -dt.Second;
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            return DT;
        }
        private DateTime GetHighDate(DateTime dt)
        {
            double Hour, Min, Sec;
            DateTime DT = DateTime.Now;
            Hour = 23 - dt.Hour;
            Min = 59 - dt.Minute;
            Sec = 59 - dt.Second;
            DT = dt;
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            return DT;
        }

        private void SendSms(HttpContext context)
        {
            string result = "Success";
            try
            {
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                string DispatchDate = context.Session["I_Date"].ToString();
                string DispType = context.Session["DispType"].ToString();
                cmd = new MySqlCommand("Update tripdata set Status=@Status,SyncStatus=@syncstatus where sno=@sno");
                int syncstatus = 1;//properly synced and 0 indicates not synced properly
                string tripstatus = "P";
                cmd.Parameters.Add("@Status", tripstatus);
                cmd.Parameters.Add("@syncstatus", syncstatus);
                cmd.Parameters.Add("@sno", context.Session["TripdataSno"].ToString());
                vdm.Update(cmd);
                result = "Trip End Done";
                if (DispType == "SO")
                {

                }
                else
                {

                    DateTime dtdispDate = Convert.ToDateTime(DispatchDate);
                    string routeid = "";
                    string routeitype = "";
                    cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                    cmd.Parameters.Add("@dispsno", context.Session["RouteId"].ToString());
                    DataTable dtrouteindenttype = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow drrouteitype in dtrouteindenttype.Rows)
                    {
                        routeid = drrouteitype["Route_id"].ToString();
                        routeitype = drrouteitype["IndentType"].ToString();
                    }
                    ////cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName,indents_subtable.IndentNo, indents_subtable.DeliveryQty, productsdata.ProductName, indents_subtable.UnitCost FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutesubtable ON dispatch_sub.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (dispatch.sno = @dispatchSno) GROUP BY productsdata.ProductName, branchdata.BranchName, productsdata.sno, indents_subtable.UnitCost ORDER BY branchdata.sno");
                    //Changed By Ravindra 01/02/2017
                    cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName, indents_subtable.IndentNo, indents_subtable.DeliveryQty, productsdata.ProductName, indents_subtable.UnitCost FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM indents WHERE (I_date BETWEEN @starttime AND @endtime)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @starttime) OR  (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate > @starttime) AND (modifiedroutesubtable.CDate <= @starttime) GROUP BY productsdata.ProductName, branchdata.BranchName, productsdata.sno, indents_subtable.UnitCost");
                    cmd.Parameters.Add("@TripID", routeid);
                    cmd.Parameters.Add("@itype", routeitype);
                    cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtdispDate));
                    cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtdispDate));
                    DataTable dtSMS = vdm.SelectQuery(cmd).Tables[0];
                    DataView view = new DataView(dtSMS);
                    DataTable distincttable = view.ToTable(true, "BranchName", "sno", "IndentNo");
                    foreach (DataRow branch in distincttable.Rows)
                    {
                        string ProductName = "";
                        string InvName = "";
                        double Totalamount = 0;
                        if (branch["IndentNo"].ToString() == "")
                        {
                            cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.phonenumber, invmaster.InvName, inventory_monitor.Qty FROM branchdata INNER JOIN inventory_monitor ON branchdata.sno = inventory_monitor.BranchId INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (branchdata.sno = @sno) AND (branchdata.flag = 1)");
                            cmd.Parameters.Add("@sno", branch["sno"].ToString());
                            DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                            if (dtBranchName.Rows.Count > 0)
                            {
                                string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                                string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();
                                foreach (DataRow dr in dtBranchName.Rows)
                                {
                                    InvName += dr["InvName"].ToString() + "=" + dr["Qty"].ToString() + ";";
                                }
                                string CollectionAmount = "0";
                                double CollAmount = 0;
                                string Branch_id = branch["sno"].ToString();
                                cmd = new MySqlCommand("SELECT Branchid, AmountPaid FROM collections WHERE (Branchid = @BranchID) AND (tripId = @TripID)");
                                cmd.Parameters.Add("@BranchID", branch["sno"].ToString());
                                cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                                DataTable dtCollections = vdm.SelectQuery(cmd).Tables[0];
                                if (dtCollections.Rows.Count > 0)
                                {
                                    CollectionAmount = dtCollections.Rows[0]["AmountPaid"].ToString();
                                    double.TryParse(dtCollections.Rows[0]["AmountPaid"].ToString(), out CollAmount);
                                }
                                if (phonenumber.Length == 10)
                                {
                                    DateTime ReportDate = VehicleDBMgr.GetTime(vdm.conn);
                                    string Date = ReportDate.ToString("dd/MM/yyyy");
                                    WebClient client = new WebClient();
                                    string BranchSno = context.Session["BranchSno"].ToString();
                                    if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                                    {
                                        //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";

                                        string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "Amount Collected For Date:" + Date + "%20Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + "&sender=VYSNVI&type=1&route=2";

                                        //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "Amount Collected For Date:" + Date + "%20Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";
                                        Stream data = client.OpenRead(baseurl);
                                        StreamReader reader = new StreamReader(data);
                                        string ResponseID = reader.ReadToEnd();
                                        data.Close();
                                        reader.Close();
                                    }
                                    else
                                    {

                                        string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "Amount Collected For Date:" + Date + "%20Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + "&sender=VYSNVI&type=1&route=2";


                                        //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "Amount Collected For Date:" + Date + "%20Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";
                                        Stream data = client.OpenRead(baseurl);
                                        StreamReader reader = new StreamReader(data);
                                        string ResponseID = reader.ReadToEnd();
                                        data.Close();
                                        reader.Close();
                                    }

                                    string message = "Dear " + BranchName + "Amount Collected For Date:" + Date + " Col Amount =" + CollectionAmount + " With Bal Inventory " + InvName + "";
                                    // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                                    cmd = new MySqlCommand("insert into smsinfo (agentid,branchid,msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                                    cmd.Parameters.Add("@agentid", Branch_id);
                                    cmd.Parameters.Add("@branchid", context.Session["BranchSno"].ToString());
                                    cmd.Parameters.Add("@msg", message);
                                    cmd.Parameters.Add("@mobileno", phonenumber);
                                    cmd.Parameters.Add("@msgtype", "OfflineCollection");
                                    cmd.Parameters.Add("@branchname", BranchName);
                                    cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                                    vdm.insert(cmd);
                                }
                            }
                        }
                        else
                        {
                            int DcNo = 0;
                            cmd = new MySqlCommand("Select DcNo from Agentdc where BranchId=@BranchId and IndDate=@IDate");
                            cmd.Parameters.Add("@BranchId", branch["sno"].ToString());
                            cmd.Parameters.Add("@IDate", dtdispDate);
                            DataTable dtAgentDc = vdm.SelectQuery(cmd).Tables[0];
                            if (dtAgentDc.Rows.Count > 0)
                            {
                                int.TryParse(dtAgentDc.Rows[0]["DcNo"].ToString(), out DcNo);
                            }
                            cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.phonenumber, invmaster.InvName, inventory_monitor.Qty FROM branchdata INNER JOIN inventory_monitor ON branchdata.sno = inventory_monitor.BranchId INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (branchdata.sno = @sno) AND (branchdata.flag = 1)");
                            cmd.Parameters.Add("@sno", branch["sno"].ToString());
                            DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                            if (dtBranchName.Rows.Count > 0)
                            {
                                string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                                string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();


                                foreach (DataRow dr in dtSMS.Rows)
                                {
                                    if (branch["BranchName"].ToString() == dr["BranchName"].ToString())
                                    {
                                        ProductName += dr["ProductName"].ToString() + "=" + dr["DeliveryQty"].ToString() + ";";
                                        double UnitCost = 0;
                                        double.TryParse(dr["UnitCost"].ToString(), out UnitCost);
                                        double DeliveryQty = 0;
                                        double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                                        Totalamount += DeliveryQty * UnitCost;
                                        Totalamount = Math.Round(Totalamount, 2);
                                    }
                                }
                                foreach (DataRow dr in dtBranchName.Rows)
                                {
                                    InvName += dr["InvName"].ToString() + "=" + dr["Qty"].ToString() + ";";
                                }
                                string CollectionAmount = "";
                                double CollAmount = 0;
                               string Branch_id= branch["sno"].ToString();
                                cmd = new MySqlCommand("SELECT Branchid, AmountPaid FROM collections WHERE (Branchid = @BranchID) AND (tripId = @TripID)");
                                cmd.Parameters.Add("@BranchID", branch["sno"].ToString());
                                cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                                DataTable dtCollections = vdm.SelectQuery(cmd).Tables[0];
                                if (dtCollections.Rows.Count > 0)
                                {
                                    CollectionAmount = dtCollections.Rows[0]["AmountPaid"].ToString();
                                    double.TryParse(dtCollections.Rows[0]["AmountPaid"].ToString(), out CollAmount);
                                }
                                if (phonenumber.Length == 10)
                                {
                                    DateTime ReportDate = VehicleDBMgr.GetTime(vdm.conn);
                                    string Date = ReportDate.ToString("dd/MM/yyyy");
                                    string companyname = "Powered By Vyshnavi";
                                    InvName += "\r\n" + companyname;
                                    WebClient client = new WebClient();
                                    //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                                    string BranchSno = context.Session["BranchSno"].ToString();
                                    if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                                    {
                                        //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Sale Value =" + Totalamount + "Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";

                                        string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Sale Value =" + Totalamount + "Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + " &sender=VYSNVI&type=1&route=2";
                                        
                                        Stream data = client.OpenRead(baseurl);
                                        StreamReader reader = new StreamReader(data);
                                        string ResponseID = reader.ReadToEnd();
                                        data.Close();
                                        reader.Close();
                                    }
                                    else
                                    {
                                       // string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Sale Value =" + Totalamount + "Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";
                                        string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Sale Value =" + Totalamount + "Col Amount =" + CollectionAmount + "%20With%20Bal%20Inventory%20" + InvName + "&sender=VYSNVI&type=1&route=2";
                                        
                                        Stream data = client.OpenRead(baseurl);
                                        StreamReader reader = new StreamReader(data);
                                        string ResponseID = reader.ReadToEnd();
                                        data.Close();
                                        reader.Close();
                                    }

                                    string message = "Dear " + BranchName + " DCNO: " + DcNo + " Your indent  delivery  for  today" + Date + "  ,  " + ProductName + "Sale Value =" + Totalamount + "Col Amount =" + CollectionAmount + " With  Bal Inventory " + InvName + " ";
                                    // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                                    cmd = new MySqlCommand("insert into smsinfo (agentid,branchid,msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                                    cmd.Parameters.Add("@agentid", Branch_id);
                                    cmd.Parameters.Add("@branchid", context.Session["BranchSno"].ToString());
                                    cmd.Parameters.Add("@msg", message);
                                    cmd.Parameters.Add("@mobileno", phonenumber);
                                    cmd.Parameters.Add("@msgtype", "Delivery");
                                    cmd.Parameters.Add("@branchname", BranchName);
                                    cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }
                    //sendmesg = "True";
                }
            }
            catch (Exception ex)
            {
                if (result == "Trip End Done")
                {
                    result = "Success";
                }
                else
                {
                    result = "Error sending data please try again";
                }
            }
            string response = GetJson(result);
            context.Response.Write(response);
        }
        private void Agent_Signature_SyncData(string jsonString,HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
               // branchsignature o = obj.Signature_detail;
                //List<branchsignature> signaturedet_list = (List<branchsignature>)context.Session["AgentSign_syncData"];
                //signaturedet_list.Add(o);
               // context.Session["AgentSign_syncData"] = signaturedet_list;
                var js = new JavaScriptSerializer();
                Orders obj = js.Deserialize<Orders>(jsonString);
                ////foreach (branchsignature o in obj.Signaturedetail)
                ////{
                ////    cmd = new MySqlCommand("update agent_trip_signs set sign=@sign where tripid=@tripid and branchid=@branchid");
                ////    cmd.Parameters.Add("@sign", o.Sign);
                ////    cmd.Parameters.Add("@tripid", context.Session["TripdataSno"].ToString());
                ////    cmd.Parameters.Add("@BranchId", o.BrancID);
                ////    if (vdm.Update(cmd) == 0)
                ////    {
                ////        cmd = new MySqlCommand("Insert into agent_trip_signs (tripid,branchid,sign) values(@tripid,@branchid,@sign)");
                ////        cmd.Parameters.Add("@tripid", context.Session["TripdataSno"].ToString());
                ////        cmd.Parameters.Add("@branchid", o.BrancID);
                ////        cmd.Parameters.Add("@sign", o.Sign);
                ////        vdm.insert(cmd);
                ////    }
                ////}
                string msg = obj.end;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "signature");
                vdm.insert(cmd);
                string msg = "fail";
                string response = GetJson(msg);
                context.Response.Write(response);
            }

        }
        private void Sendmail(HttpContext context)
        {
            string toAddress = "ravindra1507@gmail.com";
            string subject = "Vyshnavi Offline";
            string result = "Success";

            string body = "";
            string Errormessage = context.Request["errmsg"];
            if (context.Session["TripdataSno"] == null)
            {
                body = context.Session["RouteId"].ToString() + "ErrMsg" + Errormessage;
            }
            else
            {
                body = context.Session["TripdataSno"].ToString() + context.Session["DispatchName"].ToString() + "ErrMsg" + Errormessage + "UserName:" + context.Session["UserName"].ToString();
            }
            string senderID = "vyshnavidairyinfo@gmail.com";// use sender's email id here..
            const string senderPassword = "vyshnavi123"; // sender password here...
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here...
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending data please try again.!!!";
            }
            //SendEmail(toAddress, subject, body);
            string response = GetJson(result);
            context.Response.Write(response);
        }
        protected string SendEmail(string toAddress, string subject, string body)
        {
            string result = "Data Sent Successfully..!!";
            //  string senderID = "info.asntech@gmail.com";// use sender's email id here..
            string senderID = "vyshnavidairyinfo@gmail.com";// use sender's email id here..
            const string senderPassword = "vyshnavi123"; // sender password here...
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here...
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };

                MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending data please try again.!!!";
            }
            return result;
        }
        private void OfflineIndentSyncSaveClick(string jsonString, HttpContext context)
        {
            try
            {
                var js = new JavaScriptSerializer();
                Orders obj = js.Deserialize<Orders>(jsonString);
                string sync_end_msg = "";
                string ErrMsg = "Default";
                vdm = new VehicleDBMgr();
                DateTime dtDel = VehicleDBMgr.GetTime(vdm.conn);
                context.Session["indent_Next_syncData"] = obj.NextIndentdetail;
                context.Session["Offer_indent_Next_syncData"] = obj.OfferNextIndentdetail;
                int Usernamesno = 1;
                //context.Session["indent_Next_syncData"] = Product_list;
                List<NextIndentdetail> Indent_Product_list = (List<NextIndentdetail>)context.Session["indent_Next_syncData"];
                List<OfferNextIndentdetail> Offer_Indent_Product_list = (List<OfferNextIndentdetail>)context.Session["Offer_indent_Next_syncData"];


                if (Indent_Product_list == null)
                {
                }
                else
                {
                    string DispDat = context.Session["I_Date"].ToString();
                    DateTime ServerDateCurrentdat = Convert.ToDateTime(DispDat).AddDays(1);
                    foreach (NextIndentdetail o in Indent_Product_list)
                    {
                        string IndentType = o.IndentType;
                        if (IndentType == "")
                        {
                            IndentType = "Indent1";
                        }
                        if (IndentType == null)
                        {
                            IndentType = "Indent1";
                        }
                        if (o.Productsno != null)
                        {
                            cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                            cmd.Parameters.Add("@Branch_id", o.BranchID);
                            cmd.Parameters.Add("@IndentType", IndentType);
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdat));
                            DataTable dtIndentsNo = vdm.SelectQuery(cmd).Tables[0];
                            long IndentNo = 0;
                            if (dtIndentsNo.Rows.Count == 0)
                            {
                                cmd = new MySqlCommand("insert into indents (Branch_id,I_date,UserData_sno,Status,PaymentStatus,IndentType)values(@Branch_id,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                                cmd.Parameters.Add("@Branch_id", o.BranchID);
                                //cmd.Parameters.Add("@TotalQty", Qty);
                                //cmd.Parameters.Add("@TotalPrice", Price);
                                cmd.Parameters.Add("@I_date", ServerDateCurrentdat);
                                cmd.Parameters.Add("@UserData_sno", Usernamesno);
                                cmd.Parameters.Add("@Status", "O");
                                cmd.Parameters.Add("@PaymentStatus", 'A');
                                cmd.Parameters.Add("@IndentType", IndentType);
                                IndentNo = vdm.insertScalar(cmd);
                            }

                            cmd = new MySqlCommand("SELECT branchproducts.unitprice, branchproducts.product_sno, productsdata.Qty, productsdata.Units FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) and (branchproducts.product_sno=@sno) ");
                            cmd.Parameters.Add("@sno", o.Productsno);
                            cmd.Parameters.Add("@BranchID", o.BranchID);
                            DataTable dtBranchProduct = vdm.SelectQuery(cmd).Tables[0];
                            string AunitPrice = "0";

                            //float price = 0;
                            float ProductRate = 0;

                            if (dtBranchProduct.Rows.Count > 0)
                            {
                                AunitPrice = dtBranchProduct.Rows[0]["unitprice"].ToString();
                            }
                            if (AunitPrice == "0")
                            {
                                cmd = new MySqlCommand("SELECT productsdata.UnitPrice,productsdata.Qty, productsdata.Units, branchproducts.product_sno, branchproducts.unitprice AS Bunitprice , productsdata.ProductName FROM productsdata INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch WHERE (branchmappingtable.SubBranch = @BranchID) AND (branchproducts.product_sno = @Sno)");
                                cmd.Parameters.Add("@sno", o.Productsno);
                                cmd.Parameters.Add("@BranchID", o.BranchID);
                                DataTable dtProduct = vdm.SelectQuery(cmd).Tables[0];
                                string unitprice = "0";
                                string BUnitPrice = "0";
                                if (dtProduct.Rows.Count > 0)
                                {
                                    unitprice = dtProduct.Rows[0]["UnitPrice"].ToString();
                                    BUnitPrice = dtProduct.Rows[0]["BUnitPrice"].ToString();
                                    //float UnitCost = 0;

                                }
                                if (BUnitPrice != "0")
                                {
                                    if (dtProduct.Rows.Count > 0)
                                    {
                                        ProductRate = (float)dtProduct.Rows[0]["BUnitPrice"];
                                    }
                                    else
                                    {
                                        float.TryParse(BUnitPrice, out ProductRate);
                                    }
                                    //price = ProductRate;

                                }
                                else
                                {
                                    if (dtProduct.Rows.Count > 0)
                                    {
                                        ProductRate = (float)dtProduct.Rows[0]["UnitPrice"];
                                    }
                                    else
                                    {
                                        float.TryParse(unitprice, out ProductRate);
                                    }
                                    //price = ProductRate;
                                }
                            }
                            if (AunitPrice != "0")
                            {
                                //float unitamt = 0;
                                float.TryParse(AunitPrice, out ProductRate);
                                //price = unitamt;

                            }
                            cmd = new MySqlCommand("Update indents_subtable set unitQty=@unitQty,OTripId=@OTripId,UnitCost=@UnitCost,Status=@Status where IndentNo=@IndentNo and Product_sno=@Product_sno");
                            if (dtIndentsNo.Rows.Count == 0)
                            {
                                cmd.Parameters.Add("@IndentNo", IndentNo);
                            }
                            else
                            {
                                string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                cmd.Parameters.Add("@IndentNo", strIndentsNo);
                            }
                            cmd.Parameters.Add("@Product_sno", o.Productsno);
                            cmd.Parameters.Add("@UnitCost", ProductRate);
                            float unitQty = 0;
                            float.TryParse(o.Unitsqty, out unitQty);
                            cmd.Parameters.Add("@unitQty", unitQty);
                            cmd.Parameters.Add("@Status", "Ordered");
                            cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,OTripId)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@OTripId)");
                                if (dtIndentsNo.Rows.Count == 0)
                                {
                                    cmd.Parameters.Add("@IndentNo", IndentNo);
                                }
                                else
                                {
                                    string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                    cmd.Parameters.Add("@IndentNo", strIndentsNo);
                                }
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                //float.TryParse(o.UnitCost, out UnitCost);
                                cmd.Parameters.Add("@UnitCost", ProductRate);
                                float.TryParse(o.Unitsqty, out unitQty);
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@Status", "Ordered");
                                cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                vdm.insert(cmd);
                            }
                        }
                    }
                    foreach (OfferNextIndentdetail o in Offer_Indent_Product_list)
                    {
                        string IndentType = o.IndentType;
                        if (IndentType == "")
                        {
                            IndentType = "Indent1";
                        }
                        if (IndentType == null)
                        {
                            IndentType = "Indent1";
                        }
                        cmd = new MySqlCommand("SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType FROM offer_indents WHERE (agent_id = @Branch_id) AND (IndentType = @IndentType) AND (indent_date BETWEEN @d1 AND @d2)");
                        cmd.Parameters.Add("@Branch_id", o.BranchID);
                        cmd.Parameters.Add("@IndentType", IndentType);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdat));
                        DataTable dt_offerIndent = vdm.SelectQuery(cmd).Tables[0];

                        //long IndentNo = 0;
                        if (dt_offerIndent.Rows.Count == 0)
                        {
                            cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from,offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.offer_from >= @d1) OR (offers_assignment.status = 1) AND (offers_assignment.offer_to <= @d1)");
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                            DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                            DataView view = new DataView(dtoffers);
                            DataTable distincttable = view.ToTable(true, "idoffers_assignment", "offers_assignment_name");

                            string idoffers_assignment = "0";
                            long offer_indent_no = 0;
                            if (dtoffers.Rows.Count > 0)
                            {

                                idoffers_assignment = distincttable.Rows[0]["idoffers_assignment"].ToString();

                                cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                                cmd.Parameters.Add("@Branch_id", o.BranchID);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdat));
                                DataTable dtRegularIndentsNo = vdm.SelectQuery(cmd).Tables[0];
                                if (dtRegularIndentsNo.Rows.Count > 0)
                                {
                                    string IndentNo = dtRegularIndentsNo.Rows[0]["IndentNo"].ToString();

                                    cmd = new MySqlCommand("INSERT INTO offer_indents (idoffers_assignment, salesoffice_id, agent_id, indent_date, indents_id,IndentType) VALUES (@idoffers_assignment, @salesoffice_id, @agent_id, @indent_date, @indents_id,@IndentType)");
                                    cmd.Parameters.Add("@idoffers_assignment", idoffers_assignment);
                                    cmd.Parameters.Add("@salesoffice_id", context.Session["CsoNo"].ToString());
                                    cmd.Parameters.Add("@agent_id", o.BranchID);
                                    cmd.Parameters.Add("@indent_date", ServerDateCurrentdat);
                                    cmd.Parameters.Add("@indents_id", IndentNo);
                                    cmd.Parameters.Add("@IndentType", IndentType);
                                    long offerindentno = vdm.insertScalar(cmd);
                                    offer_indent_no = offerindentno;

                                    double unitQty = 0;
                                    double.TryParse(o.Unitsqty, out unitQty);
                                    unitQty = Math.Round(unitQty, 2);
                                    double UnitCost = 0;
                                    double.TryParse(o.UnitCost, out UnitCost);
                                    UnitCost = Math.Round(UnitCost, 2);
                                    cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                    cmd.Parameters.Add("idoffer_indents", offer_indent_no);
                                    cmd.Parameters.Add("product_id", o.Productsno);
                                    //cmd.Parameters.Add("unit_price", UnitCost);
                                    cmd.Parameters.Add("unit_price", UnitCost);
                                    cmd.Parameters.Add("offer_indent_qty", unitQty);
                                    cmd.Parameters.Add("offer_delivered_qty", "0");
                                    if (unitQty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                }


                            }
                        }
                        else
                        {
                            string IndentNo = dt_offerIndent.Rows[0]["idoffer_indents"].ToString();
                            double unitQty = 0;
                            double.TryParse(o.Unitsqty, out unitQty);
                            unitQty = Math.Round(unitQty, 2);
                            cmd = new MySqlCommand("UPDATE offer_indents_sub SET offer_indent_qty = @offer_indent_qty WHERE (idoffer_indents = @idoffer_indents) AND (product_id = @product_id)");
                            cmd.Parameters.Add("@offer_indent_qty", unitQty);
                            cmd.Parameters.Add("@idoffer_indents", IndentNo);
                            cmd.Parameters.Add("@product_id", o.Productsno);
                            if (vdm.Update(cmd) == 0)
                            {
                                double UnitCost = 0;
                                double.TryParse(o.UnitCost, out UnitCost);
                                UnitCost = Math.Round(UnitCost, 2);

                                cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                cmd.Parameters.Add("idoffer_indents", IndentNo);
                                cmd.Parameters.Add("product_id", o.Productsno);
                                //cmd.Parameters.Add("unit_price", UnitCost);
                                cmd.Parameters.Add("unit_price", UnitCost);
                                cmd.Parameters.Add("offer_indent_qty", unitQty);
                                cmd.Parameters.Add("offer_delivered_qty", "0");
                                if (unitQty != 0.0)
                                {
                                    vdm.insert(cmd);
                                }
                            }

                        }
                    }

                }


                string msg = "Success";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "OffIndent");
                vdm.insert(cmd);
                string msg = "fail";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }

        private void GetVersionName(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT VersionName from versions");
                DataTable DtVersionName = vdm.SelectQuery(cmd).Tables[0];
                string VersionName = DtVersionName.Rows[0]["VersionName"].ToString();
                string response = GetJson(VersionName);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string toAddress = "ravindra1507@gmail.com";
                string subject = "Get Version Name";
                string body = context.Session["TripdataSno"].ToString() + ex.ToString();
                SendEmail(toAddress, subject, body);
            }
        }
        private void getBranchProductsData(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                //cmd = new MySqlCommand("SELECT branchroutesubtable.BranchID, branchproducts.unitprice, productsdata.sno, productsdata.ProductName FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchproducts ON branchroutesubtable.BranchID = branchproducts.branch_sno INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) and (branchproducts.unitprice<>'0')");
                cmd = new MySqlCommand("SELECT result.BranchID, result.unitprice, result.ProductName, result.sno,result.Branch_Id, branchproducts_1.Rank FROM (SELECT branchroutesubtable.BranchID, branchproducts.unitprice, productsdata.sno, productsdata.ProductName, dispatch.Branch_Id FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchproducts ON branchroutesubtable.BranchID = branchproducts.branch_sno INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) AND (branchproducts.unitprice <> '0')) result INNER JOIN branchproducts branchproducts_1 ON result.sno = branchproducts_1.product_sno AND result.Branch_Id = branchproducts_1.branch_sno");
                cmd.Parameters.Add("@dispatchsno", context.Session["RouteId"].ToString());
                DataTable DtBranchProducts = vdm.SelectQuery(cmd).Tables[0];
                List<OfflineBranchProdusts> OfflineBranchProdustslist = new List<OfflineBranchProdusts>();
                if (DtBranchProducts.Rows.Count > 0)
                {
                    foreach (DataRow dr in DtBranchProducts.Rows)
                    {
                        OfflineBranchProdusts GetOffLineBranchProdusts = new OfflineBranchProdusts();
                        GetOffLineBranchProdusts.BranchID = dr["BranchID"].ToString();
                        GetOffLineBranchProdusts.ProductId = dr["sno"].ToString();
                        GetOffLineBranchProdusts.ProductName = dr["ProductName"].ToString();
                        GetOffLineBranchProdusts.UnitPrice = dr["unitprice"].ToString();
                        GetOffLineBranchProdusts.rank = dr["Rank"].ToString();
                        OfflineBranchProdustslist.Add(GetOffLineBranchProdusts);
                    }
                }
                string response = GetJson(OfflineBranchProdustslist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string Msg = ex.ToString();
                string response = GetJson(Msg);
                context.Response.Write(response);
            }
        }
        public class OfflineBranchProdusts
        {
            public string BranchID = "";
            public string ProductId = "";
            public string ProductName = "";
            public string UnitPrice = "";
            public string rank = "";
        }
        public class OfflineSOBranchProdusts
        {
            public string BranchSno = "";
            public string ProductId = "";
            public string ProductName = "";
            public string UnitPrice = "";
            public string rank = "";
        }
        private void getSalesOfficeBranchProductsdata(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                //cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.sno, branchproducts.branch_sno, branchproducts.unitprice FROM branchproducts INNER JOIN  productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @branchID)");
                cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.sno, branchproducts.branch_sno, branchproducts.unitprice, branchproducts.Rank FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @branchID) ORDER BY branchproducts.Rank");
                cmd.Parameters.Add("@branchID", context.Session["BranchSno"].ToString());
                DataTable DtBranchProducts = vdm.SelectQuery(cmd).Tables[0];
                List<OfflineSOBranchProdusts> OfflineSoBranchProdustslist = new List<OfflineSOBranchProdusts>();
                if (DtBranchProducts.Rows.Count > 0)
                {
                    foreach (DataRow dr in DtBranchProducts.Rows)
                    {
                        OfflineSOBranchProdusts GetOffLineBranchProdusts = new OfflineSOBranchProdusts();
                        string unitprice = dr["unitprice"].ToString();
                        if (unitprice != "0")
                        {
                            GetOffLineBranchProdusts.BranchSno = dr["branch_sno"].ToString();
                            GetOffLineBranchProdusts.ProductId = dr["sno"].ToString();
                            GetOffLineBranchProdusts.ProductName = dr["ProductName"].ToString();
                            GetOffLineBranchProdusts.UnitPrice = dr["unitprice"].ToString();
                            GetOffLineBranchProdusts.rank = dr["Rank"].ToString();
                            OfflineSoBranchProdustslist.Add(GetOffLineBranchProdusts);
                        }
                    }
                }
                string response = GetJson(OfflineSoBranchProdustslist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string Msg = ex.Message;
                string response = GetJson(Msg);
                context.Response.Write(response);
            }
        }

        public class OffLineTripSubData
        {
            public string ProductId = "";
            public string ProductName = "";
            public string Qty = "";
            public string DeliverQty = "";
            public string rank = "";
        }
        private void GetOffLineTripSubData(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                //cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, tripsubdata.Qty, tripsubdata.DeliverQty FROM tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (tripsubdata.Tripdata_sno = @tripId) GROUP BY productsdata.ProductName");
                cmd = new MySqlCommand("SELECT tripsubdata.ProductId, tripsubdata.Qty, tripsubdata.DeliverQty, tripdata.BranchID, branchproducts.Rank, branchproducts.product_sno,productsdata.ProductName FROM tripsubdata INNER JOIN tripdata ON tripsubdata.Tripdata_sno = tripdata.Sno INNER JOIN branchproducts ON tripdata.BranchID = branchproducts.branch_sno AND tripsubdata.ProductId = branchproducts.product_sno INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (tripsubdata.Tripdata_sno = @tripId) GROUP BY productsdata.ProductName ORDER BY branchproducts.Rank");
                cmd.Parameters.Add("@tripId", context.Session["TripID"].ToString());
                DataTable dtSubData = vdm.SelectQuery(cmd).Tables[0];
                List<OffLineTripSubData> OffLineTripSubDatalist = new List<OffLineTripSubData>();
                if (dtSubData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubData.Rows)
                    {
                        OffLineTripSubData GetOffLineTrip = new OffLineTripSubData();
                        GetOffLineTrip.ProductId = dr["ProductId"].ToString();
                        GetOffLineTrip.ProductName = dr["ProductName"].ToString();
                        GetOffLineTrip.Qty = dr["Qty"].ToString();
                        GetOffLineTrip.DeliverQty = dr["DeliverQty"].ToString();
                        GetOffLineTrip.rank = dr["Rank"].ToString();
                        OffLineTripSubDatalist.Add(GetOffLineTrip);
                    }
                }
                string response = GetJson(OffLineTripSubDatalist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string Msg = ex.ToString();
                string response = GetJson(Msg);
                context.Response.Write(response);
            }
        }
        public class GetOffLineInvData
        {
            public string InvId = "";
            public string InvName = "";
            public string Qty = "";
            public string RemainQty = "";
        }
        private void GetOffLineTripInvData(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT tripinvdata.invid, invmaster.InvName, tripinvdata.Qty, tripinvdata.Remaining FROM tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE  (tripinvdata.Tripdata_sno = @tripId) GROUP BY invmaster.InvName");
                cmd.Parameters.Add("@tripId", context.Session["TripID"].ToString());
                DataTable dtInvData = vdm.SelectQuery(cmd).Tables[0];
                List<GetOffLineInvData> GetOffLineInvDatalist = new List<GetOffLineInvData>();
                if (dtInvData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInvData.Rows)
                    {
                        GetOffLineInvData GetOffLineTrip = new GetOffLineInvData();
                        GetOffLineTrip.InvId = dr["invid"].ToString();
                        GetOffLineTrip.InvName = dr["InvName"].ToString();
                        GetOffLineTrip.Qty = dr["Qty"].ToString();
                        GetOffLineTrip.RemainQty = dr["Remaining"].ToString();
                        GetOffLineInvDatalist.Add(GetOffLineTrip);
                    }
                }
                string response = GetJson(GetOffLineInvDatalist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string Msg = ex.Message;
                string response = GetJson(Msg);
                context.Response.Write(response);
            }
        }
        private void CollectionInventorySaveClick(HttpContext context, Orders obj)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                Inventorydetail o = obj.Inventory_detail;
                List<Inventorydetail> Inventory_list = (List<Inventorydetail>)context.Session["Collection_inventory_syncData"];
                Inventory_list.Add(o);
                context.Session["Collection_inventory_syncData"] = Inventory_list;
                string msg = obj.end;
                string response = GetJson(msg);
                context.Response.Write(response);

            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "CollectionInv");
                vdm.insert(cmd);
                string msg = "fail";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void BranchAmount1SyncSaveClick(HttpContext context, Orders obj)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime dtCdate = VehicleDBMgr.GetTime(vdm.conn);
                Amountdetail o = obj.Amount_detail;
                List<Amountdetail> Amount_list = (List<Amountdetail>)context.Session["Amount_syncData"];
                Amount_list.Add(o);
                context.Session["Amount_syncData"] = Amount_list;
                cmd = new MySqlCommand("Insert Into synclog(BranchID,tripid,times,Salevalue,Collection) values(@BranchID,@tripid,@times,@Salevalue,@Collection)");
                cmd.Parameters.Add("@BranchID", o.BrancID);
                cmd.Parameters.Add("@tripid", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@times", dtCdate);
                cmd.Parameters.Add("@Salevalue", o.Amount);
                cmd.Parameters.Add("@Collection", o.TodayAmount);
                vdm.insert(cmd);
                string msg = obj.end;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "Collections");
                vdm.insert(cmd);
                string msg = "fail";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        double totsaleqty = 0;

        //private void ProductsSyncSaveClick(HttpContext context, Orders obj)
        private void ProductsSyncSaveClick(string jsonString, HttpContext context)
        {
            try
            {
                var js = new JavaScriptSerializer();
                Orders obj = js.Deserialize<Orders>(jsonString);
                string sync_end_msg = "";
                string ErrMsg = "Default";
                vdm = new VehicleDBMgr();
                DateTime dtDel = VehicleDBMgr.GetTime(vdm.conn);
                //orderdetail o = obj.order_detail;
                ////  List<orderdetail> Product_list = new List<orderdetail>();
                //List<orderdetail> Product_list = (List<orderdetail>)context.Session["indent_syncData"];
                //Product_list.Add(o);
                context.Session["indent_syncData"] = obj.data;
                context.Session["Offer_Delivery_syncData"] = obj.OfferDeliveryData;


                //Inventorydetail inv = obj.Inventory_detail;
                //List<Inventorydetail> Inventorydet_list = (List<Inventorydetail>)context.Session["inventory_syncData"];
                //Inventorydet_list.Add(inv);
                context.Session["inventory_syncData"] = obj.Inventorydetails;


                //Amountdetail amt = obj.Amount_detail;
                //List<Amountdetail> Amount_list = (List<Amountdetail>)context.Session["Amount_syncData"];
                //Amount_list.Add(amt);
                context.Session["Amount_syncData"] =obj.Amountdetail;

                //CInventorydetail CInv = obj.CInventory_detail;
                //List<CInventorydetail> CInventory_list = (List<CInventorydetail>)context.Session["Collection_inventory_syncData"];
                //CInventory_list.Add(CInv);
                context.Session["Collection_inventory_syncData"] = obj.CInventorydetail;

                //List<orderdetail> LeaksList = obj.data;

                context.Session["LeaksList_syncData"] = obj.Leakagedetails;

                //List<orderdetail> Product_list = (List<orderdetail>)context.Session["indent_Next_syncData"];
                //Product_list.Add(o);
                context.Session["indent_Next_syncData"] = obj.NextIndentdetail;
                context.Session["Offer_indent_Next_syncData"] = obj.OfferNextIndentdetail;

                //double saleqty = 0;
                //double.TryParse(o.ReturnQty, out saleqty);
                //totsaleqty += saleqty;

               // List<InvDatails> InvDatailstlist = obj.InvDatails;
                context.Session["InvDatailstlist_sync"] = obj.InvDatails;
                //List<RouteLeakdetails> RouteLeakslist = obj.RouteLeakdetails;
                context.Session["RouteLeakslist_sync"] = obj.RouteLeakdetails;

                string Remarksss = obj.Remarks;
                string Denominationsss = obj.Denominations;
                context.Session["Remarks"] = Remarksss;
                context.Session["Denominations"] = Denominationsss;
                context.Session["colAmount"] = obj.ColAmount;
                context.Session["SubAmount"] = obj.SubAmount;
                DataTable report = new DataTable();
                DataTable taxdummytable = new DataTable();
                DataTable nontaxdummytable = new DataTable();
                nontaxdummytable.Columns.Add("BranchId");
                nontaxdummytable.Columns.Add("soid");
                nontaxdummytable.Columns.Add("productid");

                taxdummytable.Columns.Add("BranchId");
                taxdummytable.Columns.Add("soid");
                taxdummytable.Columns.Add("productid");


                try
                {
                    int Usernamesno = 1;
                    string sendmesg = "false";
                    if (context.Session["indent_syncData"] == null)
                    {
                    }
                    else
                    {
                        List<orderdetail> Product_list = (List<orderdetail>)context.Session["indent_syncData"];
                        List<OfferDeliveryData> Offer_Delivery_Product_list = (List<OfferDeliveryData>)context.Session["Offer_Delivery_syncData"];
                        ErrMsg = "Products";
                        vdm = new VehicleDBMgr();
                        #region Product_Sync_Code
                        if (Product_list == null)
                        {
                            sync_end_msg = "Fail";
                            ErrMsg = "ProductListNULL";
                            string toAddress = "ravindra1507@gmail.com";
                            string subject = "Vyshnavi Offline";
                            string body = "";
                            if (context.Session["TripdataSno"] == null)
                            {
                                body = "ErrMsg" + ErrMsg;
                            }
                            else
                            {
                                body = context.Session["TripdataSno"].ToString() + "ErrMsg" + ErrMsg;
                            }
                            SendEmail(toAddress, subject, body);
                        }
                        else
                        {
                            //DateTime dtDel = VehicleDBMgr.GetTime(vdm.conn);
                            cmd = new MySqlCommand("SELECT indents_subtable.Product_sno, indents_subtable.DeliveryQty, indents_subtable.unitQty, indents_subtable.UnitCost, indents.Branch_id FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo WHERE (indents_subtable.DTripId = @DtripID) ");
                            cmd.Parameters.Add("@DtripID", context.Session["TripdataSno"].ToString());
                            //cmd.Parameters.Add("@ProductID", Productsno);
                            //cmd.Parameters.Add("@BranchID", BranchID);
                            DataTable dtTotalIndent = vdm.SelectQuery(cmd).Tables[0];
                            //DataTable dtTotalIndent = new DataTable();
                            foreach (orderdetail o in Product_list)
                            {
                                if (o.Productsno != null)
                                {

                                    //if (o.ReturnQty != "0")
                                    //{

                                    //    DataRow[] drbranchids = nontaxdummytable.Select("BranchID=" + o.BranchID + "");
                                    //    if (drbranchids.Length > 0)
                                    //    {
                                    //        cmd = new MySqlCommand("SELECT   sno, SubCat_sno, ProductName, Qty, Units, UnitPrice, Flag, UserData_sno, Rank, Inventorysno, VatPercent, Product_type, tproduct, sangam_flag, Itemcode, images,specification, materialtype, packtype, hsncode, igst, cgst, sgst, gsttaxcategory, pieces, invqty, description, ifdflag FROM productsdata WHERE (sno = @productsno)");
                                    //        cmd.Parameters.Add("@productsno", o.Productsno);
                                    //        DataTable dtproduct = vdm.SelectQuery(cmd).Tables[0];
                                    //        if (dtproduct.Rows[0]["igst"].ToString() == "0")
                                    //        {
                                    //            DataRow newrow = nontaxdummytable.NewRow();
                                    //            newrow["BranchId"] = o.BranchID;
                                    //            newrow["soid"] = context.Session["BranchSno"].ToString();
                                    //            newrow["productid"] = o.Productsno;
                                    //            nontaxdummytable.Rows.Add(newrow);
                                    //        }
                                    //        else
                                    //        {
                                    //            DataRow newrow = taxdummytable.NewRow();
                                    //            newrow["BranchId"] = o.BranchID;
                                    //            newrow["soid"] = context.Session["BranchSno"].ToString();
                                    //            newrow["productid"] = o.Productsno;
                                    //            taxdummytable.Rows.Add(newrow);
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        cmd = new MySqlCommand("SELECT   sno, SubCat_sno, ProductName, Qty, Units, UnitPrice, Flag, UserData_sno, Rank, Inventorysno, VatPercent, Product_type, tproduct, sangam_flag, Itemcode, images,specification, materialtype, packtype, hsncode, igst, cgst, sgst, gsttaxcategory, pieces, invqty, description, ifdflag FROM productsdata WHERE (sno = @productsno)");
                                    //        cmd.Parameters.Add("@productsno", o.Productsno);
                                    //        DataTable dtproduct = vdm.SelectQuery(cmd).Tables[0];
                                    //        if (dtproduct.Rows[0]["igst"].ToString() == "0")
                                    //        {
                                    //            DataRow newrow = nontaxdummytable.NewRow();
                                    //            newrow["BranchId"] = o.BranchID;
                                    //            newrow["soid"] = context.Session["BranchSno"].ToString();
                                    //            newrow["productid"] = o.Productsno;
                                    //            nontaxdummytable.Rows.Add(newrow);
                                    //        }
                                    //        else
                                    //        {
                                    //            DataRow newrow = taxdummytable.NewRow();
                                    //            newrow["BranchId"] = o.BranchID;
                                    //            newrow["soid"] = context.Session["BranchSno"].ToString();
                                    //            newrow["productid"] = o.Productsno;
                                    //            taxdummytable.Rows.Add(newrow);
                                    //        }
                                    //    }
                                    //}
                                    double UnitCost = 0;
                                    double.TryParse(o.orderunitRate, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out UnitCost);
                                    float Returnqty = 0;
                                    float.TryParse(o.ReturnQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Returnqty);
                                    double totAmount = UnitCost * Returnqty;
                                    totAmount = Math.Round(totAmount, 2);
                                    int Productsno = 0;
                                    int.TryParse(o.Productsno, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Productsno);
                                    int BranchID = 0;
                                    int.TryParse(o.BranchID, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out BranchID);
                                    string ind = "0";
                                    ind = o.IndentNo;




                                    if (o.IndentNo == "")
                                    {
                                        ind = "0";
                                    }
                                    if (ind != "0")
                                    {
                                        cmd = new MySqlCommand("UPDATE  indents_subtable set DeliveryQty=@DeliveryQty,LeakQty=@LeakQty,D_date=@D_date,DTripId=@DTripId,Status=@Status,UnitCost=@UnitCost,DelTime=@DelTime where Product_sno=@Product_sno and IndentNo=@IndentNo");
                                        int IndentNo = 0;
                                        int.TryParse(o.IndentNo, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out IndentNo);
                                        cmd.Parameters.Add("@IndentNo", IndentNo);
                                        cmd.Parameters.Add("@Product_sno", Productsno);
                                        cmd.Parameters.Add("@UnitCost", UnitCost);
                                        cmd.Parameters.Add("@DeliveryQty", Returnqty);
                                        cmd.Parameters.Add("@DelTime", o.DelDate);
                                        float Leak = 0;
                                        float.TryParse(o.LeakQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Leak);
                                        cmd.Parameters.Add("@LeakQty", Leak);
                                        cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                        cmd.Parameters.Add("@Status", o.Status);
                                        cmd.Parameters.Add("@D_date", dtDel);
                                        if (vdm.Update(cmd) == 0)
                                        {
                                            cmd = new MySqlCommand("insert into indents_subtable (DeliveryQty,D_date,IndentNo,Product_sno,Status,UnitCost,LeakQty,DTripId,unitQty)values (@DeliveryQty,@D_date,@IndentNo,@Product_sno,@Status,@UnitCost,@LeakQty,@DTripId,@unitQty)");
                                            int.TryParse(o.IndentNo, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out IndentNo);
                                            cmd.Parameters.Add("@IndentNo", IndentNo);
                                            int.TryParse(o.Productsno, out Productsno);
                                            cmd.Parameters.Add("@Product_sno", Productsno);
                                            cmd.Parameters.Add("@UnitCost", UnitCost);
                                            cmd.Parameters.Add("@DeliveryQty", Returnqty);
                                            float.TryParse(o.LeakQty, out Leak);
                                            cmd.Parameters.Add("@LeakQty", Leak);
                                            float unitQty = 0;
                                            cmd.Parameters.Add("@unitQty", unitQty);
                                            cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                            cmd.Parameters.Add("@Status", o.Status);
                                            cmd.Parameters.Add("@D_date", dtDel);
                                            vdm.insert(cmd);
                                        }
                                    }
                                    else
                                    {

                                        if (ind == "0")
                                        {
                                            string DispDate = context.Session["I_Date"].ToString();
                                            DateTime dtdispDate = Convert.ToDateTime(DispDate);
                                            string IndentType = "";
                                            IndentType = context.Session["IndentType"].ToString();
                                            if (IndentType == "")
                                            {
                                                IndentType = "Indent1";
                                            }
                                            long IndentsNo = 0;
                                            cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                                            cmd.Parameters.Add("@Branch_id", BranchID);
                                            cmd.Parameters.Add("@IndentType", IndentType);
                                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                            DataTable dtIndentsNo = vdm.SelectQuery(cmd).Tables[0];
                                            if (dtIndentsNo.Rows.Count == 0)
                                            {
                                                cmd = new MySqlCommand("insert into indents (Branch_id,I_date,UserData_sno,Status,PaymentStatus,IndentType)values(@Branch_id,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                                                cmd.Parameters.Add("@Branch_id", BranchID);
                                                cmd.Parameters.Add("@I_date", dtdispDate);
                                                cmd.Parameters.Add("@UserData_sno", Usernamesno);
                                                cmd.Parameters.Add("@Status", "O");
                                                cmd.Parameters.Add("@PaymentStatus", 'A');
                                                cmd.Parameters.Add("@IndentType", IndentType);
                                                IndentsNo = vdm.insertScalar(cmd);
                                            }
                                            cmd = new MySqlCommand("UPDATE  indents_subtable set DeliveryQty=@DeliveryQty,LeakQty=@LeakQty,D_date=@D_date,DTripId=@DTripId,Status=@Status,UnitCost=@UnitCost,DelTime=@DelTime where Product_sno=@Product_sno and IndentNo=@IndentNo");
                                            cmd.Parameters.Add("@DeliveryQty", Returnqty);
                                            cmd.Parameters.Add("@D_date", dtDel);
                                            float Leak = 0;
                                            float.TryParse(o.LeakQty, out Leak);
                                            cmd.Parameters.Add("@LeakQty", Leak);
                                            cmd.Parameters.Add("@Status", "Delivered");
                                            cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                            cmd.Parameters.Add("@UnitCost", UnitCost);
                                            cmd.Parameters.Add("@DelTime", o.DelDate);
                                            cmd.Parameters.Add("@Product_sno", o.Productsno);
                                            if (dtIndentsNo.Rows.Count == 0)
                                            {
                                                cmd.Parameters.Add("@IndentNo", IndentsNo);
                                            }
                                            else
                                            {
                                                string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                                cmd.Parameters.Add("@IndentNo", strIndentsNo);
                                            }
                                            if (vdm.Update(cmd) == 0)
                                            {
                                                cmd = new MySqlCommand("insert into indents_subtable (DeliveryQty,D_date,IndentNo,Product_sno,Status,unitQty,UnitCost,LeakQty,DTripId,DelTime)values(@DeliveryQty,@D_date,@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@LeakQty,@DTripId,@DelTime)");
                                                cmd.Parameters.Add("@DeliveryQty", Returnqty);
                                                cmd.Parameters.Add("@D_date", dtDel);
                                                if (dtIndentsNo.Rows.Count == 0)
                                                {
                                                    cmd.Parameters.Add("@IndentNo", IndentsNo);
                                                }
                                                else
                                                {
                                                    string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                                    cmd.Parameters.Add("@IndentNo", strIndentsNo);
                                                }
                                                cmd.Parameters.Add("@LeakQty", Leak);
                                                cmd.Parameters.Add("@DelTime", o.DelDate);
                                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                                cmd.Parameters.Add("@Status", "Delivered");
                                                float unitQty = 0;
                                                cmd.Parameters.Add("@unitQty", unitQty);
                                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                                cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                                vdm.insert(cmd);
                                            }
                                        }
                                        else
                                        {
                                            sync_end_msg = "Fail";
                                            ErrMsg = "IndentSnoNULL" + "Branchid" + BranchID;
                                            string toAddress = "ravindra1507@gmail.com";
                                            string subject = "Vyshnavi Offline";
                                            string body = "";
                                            if (context.Session["TripdataSno"] == null)
                                            {
                                                body = "ErrMsg" + ErrMsg;
                                            }
                                            else
                                            {
                                                body = context.Session["TripdataSno"].ToString() + "ErrMsg" + ErrMsg;
                                            }
                                            SendEmail(toAddress, subject, body);
                                        }
                                    }
                                    DataRow[] drIndentData = dtTotalIndent.Select("Product_sno=" + Productsno + " and Branch_id=" + BranchID);
                                    if (drIndentData.Count() > 0)
                                    {
                                        DataTable dtIndentData = drIndentData.CopyToDataTable();

                                        float Aqty = 0;
                                        string DeliveryQty = dtIndentData.Rows[0]["DeliveryQty"].ToString();
                                        if (DeliveryQty == "")
                                        {
                                            Aqty = 0;
                                        }
                                        else
                                        {
                                            float.TryParse(DeliveryQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Aqty);
                                        }
                                        float Eqty = 0;
                                        float.TryParse(o.ReturnQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Eqty);
                                        float Lqty = 0;
                                        float.TryParse(o.LeakQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Lqty);
                                        float TQty = Aqty - Eqty;
                                        //if (TQty >= 1)
                                        //{
                                        if (Aqty < Eqty)
                                        {
                                            double EditAmount = TQty * UnitCost;

                                            //Testing Starts
                                            //cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                            //cmd.Parameters.Add("@Amount", EditAmount);
                                            //cmd.Parameters.Add("@BranchId", BranchID);
                                            //if (vdm.Update(cmd) == 0)
                                            //{
                                            //    cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                            //    cmd.Parameters.Add("@Amount", EditAmount);
                                            //    cmd.Parameters.Add("@BranchId", BranchID);
                                            //    vdm.insert(cmd);
                                            //}

                                            //Testing Ends
                                            cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                                            cmd.Parameters.Add("@DeliverQty", TQty);
                                            int Prsno = 0;
                                            int.TryParse(o.Productsno, out Prsno);
                                            cmd.Parameters.Add("@ProductId", Prsno);
                                            int TripdataSno = 0;
                                            int.TryParse(context.Session["TripdataSno"].ToString(), out TripdataSno);
                                            cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                                            vdm.Update(cmd);
                                        }
                                        else
                                        {
                                            TQty = Math.Abs(TQty);
                                            double EditAmount = TQty * UnitCost;

                                            cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty-@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                                            cmd.Parameters.Add("@DeliverQty", TQty);
                                            int Prsno = 0;
                                            int.TryParse(o.Productsno, out Prsno);
                                            cmd.Parameters.Add("@ProductId", Prsno);
                                            int TripdataSno = 0;
                                            int.TryParse(context.Session["TripdataSno"].ToString(), out TripdataSno);
                                            cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                                            vdm.Update(cmd);
                                        }
                                    }
                                    else
                                    {

                                        cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                                        float deliverQty = 0;
                                        float.TryParse(o.ReturnQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out deliverQty);
                                        cmd.Parameters.Add("@DeliverQty", deliverQty);
                                        int Prsno = 0;
                                        int.TryParse(o.Productsno, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Prsno);
                                        cmd.Parameters.Add("@ProductId", Prsno);
                                        int TripdataSno = 0;
                                        int.TryParse(context.Session["TripdataSno"].ToString(), out TripdataSno);
                                        cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                                        vdm.Update(cmd);
                                    }

                                    //}
                                }
                                else
                                {
                                    sync_end_msg = "Fail";
                                    ErrMsg = "ProductSnoNULL";
                                    string toAddress = "ravindra1507@gmail.com";
                                    string subject = "Vyshnavi Offline";
                                    string body = "";
                                    if (context.Session["TripdataSno"] == null)
                                    {
                                        body = "ErrMsg" + ErrMsg;
                                    }
                                    else
                                    {
                                        body = context.Session["TripdataSno"].ToString() + "ErrMsg" + ErrMsg;
                                    }
                                    SendEmail(toAddress, subject, body);
                                }
                            }
                            //cmd = new MySqlCommand("SELECT idoffer_indents_sub, idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty, offer_delivered_date, DTripId FROM offer_indents_sub WHERE (DTripId = @DtripID)");
                            cmd = new MySqlCommand("SELECT offer_indents_sub.idoffer_indents_sub, offer_indents_sub.idoffer_indents, offer_indents_sub.product_id, offer_indents_sub.unit_price, offer_indents_sub.offer_indent_qty, offer_indents_sub.offer_delivered_qty, offer_indents_sub.offer_delivered_date, offer_indents_sub.DTripId, offer_indents.agent_id FROM offer_indents_sub INNER JOIN offer_indents ON offer_indents_sub.idoffer_indents = offer_indents.idoffer_indents WHERE (offer_indents_sub.DTripId = @DtripID)");
                            cmd.Parameters.Add("@DtripID", context.Session["TripdataSno"].ToString());
                            DataTable dtOfferIndent = vdm.SelectQuery(cmd).Tables[0];
                            string soid = context.Session["BranchSno"].ToString();
                            if (soid == "527" || soid == "4607")
                            {
                                soid = "174";
                            }
                            string DispDates = context.Session["I_Date"].ToString();
                            DateTime dtdispDates = Convert.ToDateTime(DispDates);
                            cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.salesoffice_id=@bsno) AND (offers_assignment.offer_from <= @d1) AND (offers_assignment.offer_to >= @d1) GROUP BY offers_sub.offer_product_id");
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDates));
                            cmd.Parameters.Add("@bsno", soid);
                            DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                            DataView view = new DataView(dtoffers);
                            DataTable distincttable = view.ToTable(true, "idoffers_assignment", "offers_assignment_name");
                            foreach (OfferDeliveryData o in Offer_Delivery_Product_list)
                            {
                                string IndentType = "";
                                IndentType = context.Session["IndentType"].ToString();
                                //string IndentType = o.IndentType;
                                if (IndentType == "")
                                {
                                    IndentType = "Indent1";
                                }
                                if (IndentType == null)
                                {
                                    IndentType = "Indent1";
                                }

                                cmd = new MySqlCommand("SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType FROM offer_indents WHERE (agent_id = @Branch_id) AND (IndentType = @IndentType) AND (indent_date BETWEEN @d1 AND @d2)");
                                cmd.Parameters.Add("@Branch_id", o.BranchID);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDates));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDates));
                                DataTable dt_offerIndent = vdm.SelectQuery(cmd).Tables[0];

                                if (dt_offerIndent.Rows.Count == 0)
                                {
                                    string idoffers_assignment = "0";
                                    long offer_indent_no = 0;
                                    if (dtoffers.Rows.Count > 0)
                                    {

                                        idoffers_assignment = distincttable.Rows[0]["idoffers_assignment"].ToString();

                                        cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                                        cmd.Parameters.Add("@Branch_id", o.BranchID);
                                        cmd.Parameters.Add("@IndentType", IndentType);
                                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDates));
                                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDates));
                                        DataTable dtRegularIndentsNo = vdm.SelectQuery(cmd).Tables[0];
                                        if (dtRegularIndentsNo.Rows.Count > 0)
                                        {
                                            string IndentNo = dtRegularIndentsNo.Rows[0]["IndentNo"].ToString();
                                            cmd = new MySqlCommand("INSERT INTO offer_indents (idoffers_assignment, salesoffice_id, agent_id, indent_date, indents_id,IndentType) VALUES (@idoffers_assignment, @salesoffice_id, @agent_id, @indent_date, @indents_id,@IndentType)");
                                            cmd.Parameters.Add("@idoffers_assignment", idoffers_assignment);
                                            cmd.Parameters.Add("@salesoffice_id", soid);
                                            cmd.Parameters.Add("@agent_id", o.BranchID);
                                            cmd.Parameters.Add("@indent_date", dtdispDates);
                                            cmd.Parameters.Add("@indents_id", IndentNo);
                                            cmd.Parameters.Add("@IndentType", IndentType);
                                            long offerindentno = vdm.insertScalar(cmd);
                                            offer_indent_no = offerindentno;
                                            double unitQty = 0;
                                            double offindqty = 0;
                                            double.TryParse(o.ReturnQty, out unitQty);
                                            unitQty = Math.Round(unitQty, 2);
                                            double UnitCost = 0;
                                            double.TryParse(o.orderunitRate, out UnitCost);
                                            UnitCost = Math.Round(UnitCost, 2);
                                            cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price,offer_indent_qty,offer_delivered_qty,offer_delivered_date,DTripId) VALUES (@idoffer_indents, @product_id, @unit_price,@offer_indent_qty,@offer_delivered_qty,@offer_delivered_date,@DTripId)");
                                            cmd.Parameters.Add("idoffer_indents", offer_indent_no);
                                            cmd.Parameters.Add("product_id", o.Productsno);
                                            //cmd.Parameters.Add("unit_price", UnitCost);
                                            cmd.Parameters.Add("unit_price", UnitCost);
                                            cmd.Parameters.Add("offer_indent_qty", offindqty);
                                            cmd.Parameters.Add("offer_delivered_qty", unitQty);
                                            cmd.Parameters.Add("@offer_delivered_date", dtDel);
                                            cmd.Parameters.Add("@DtripID", context.Session["TripdataSno"].ToString());
                                            if (unitQty != 0.0)
                                            {
                                                vdm.insert(cmd);
                                            }
                                        }


                                    }
                                }
                                else
                                {
                                    string IndentNo = dt_offerIndent.Rows[0]["idoffer_indents"].ToString();
                                    double unitQty = 0;
                                    double.TryParse(o.ReturnQty, out unitQty);
                                    unitQty = Math.Round(unitQty, 2);
                                    cmd = new MySqlCommand("UPDATE offer_indents_sub SET offer_delivered_qty = @offer_delivered_qty,offer_delivered_date=@offer_delivered_date,DTripId=@DTripId WHERE (idoffer_indents = @idoffer_indents) AND (product_id = @product_id)");
                                    cmd.Parameters.Add("@offer_delivered_qty", unitQty);
                                    cmd.Parameters.Add("@idoffer_indents", IndentNo);
                                    cmd.Parameters.Add("@product_id", o.Productsno);
                                    cmd.Parameters.Add("@offer_delivered_date", dtDel);
                                    cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());

                                    if (vdm.Update(cmd) == 0)
                                    {
                                        double UnitCost = 0;
                                        double.TryParse(o.orderunitRate, out UnitCost);
                                        UnitCost = Math.Round(UnitCost, 2);

                                        cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price,offer_indent_qty, offer_delivered_qty,offer_delivered_date,DtripID) VALUES (@idoffer_indents, @product_id, @unit_price,@offer_indent_qty, @offer_delivered_qty,@offer_delivered_date,@DtripID)");
                                        cmd.Parameters.Add("idoffer_indents", IndentNo);
                                        cmd.Parameters.Add("product_id", o.Productsno);
                                        //cmd.Parameters.Add("unit_price", UnitCost);
                                        cmd.Parameters.Add("unit_price", UnitCost);
                                        double offindqty = 0;

                                        cmd.Parameters.Add("offer_indent_qty", offindqty);
                                        cmd.Parameters.Add("offer_delivered_qty", unitQty);
                                        cmd.Parameters.Add("@offer_delivered_date", dtDel);

                                        cmd.Parameters.Add("@DtripID", context.Session["TripdataSno"].ToString());

                                        if (unitQty != 0.0)
                                        {
                                            vdm.insert(cmd);
                                        }
                                    }

                                }

                                DataRow[] drOfferIndentData = dtOfferIndent.Select("product_id=" + o.Productsno + " and agent_id=" + o.BranchID);
                                // DataRow[] drOfferIndentData = dtOfferIndent.Select("product_id='" + o.Productsno + "'");

                                if (drOfferIndentData.Count() > 0)
                                {
                                    DataTable dtIndentData = drOfferIndentData.CopyToDataTable();

                                    float Aqty = 0;
                                    string DeliveryQty = dtOfferIndent.Rows[0]["offer_delivered_qty"].ToString();
                                    if (DeliveryQty == "")
                                    {
                                        Aqty = 0;
                                    }
                                    else
                                    {
                                        float.TryParse(DeliveryQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Aqty);
                                    }
                                    float Eqty = 0;
                                    float.TryParse(o.ReturnQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Eqty);

                                    float TQty = Aqty - Eqty;
                                    //if (TQty >= 1)
                                    //{
                                    double UnitCost = 0;
                                    double.TryParse(o.orderunitRate, out UnitCost);
                                    UnitCost = Math.Round(UnitCost, 2);
                                    if (Aqty < Eqty)
                                    {
                                        double EditAmount = TQty * UnitCost;
                                        cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                                        cmd.Parameters.Add("@DeliverQty", TQty);
                                        int Prsno = 0;
                                        int.TryParse(o.Productsno, out Prsno);
                                        cmd.Parameters.Add("@ProductId", Prsno);
                                        int TripdataSno = 0;
                                        int.TryParse(context.Session["TripdataSno"].ToString(), out TripdataSno);
                                        cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                                        vdm.Update(cmd);
                                    }
                                    else
                                    {
                                        TQty = Math.Abs(TQty);
                                        double EditAmount = TQty * UnitCost;

                                        cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty-@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                                        cmd.Parameters.Add("@DeliverQty", TQty);
                                        int Prsno = 0;
                                        int.TryParse(o.Productsno, out Prsno);
                                        cmd.Parameters.Add("@ProductId", Prsno);
                                        int TripdataSno = 0;
                                        int.TryParse(context.Session["TripdataSno"].ToString(), out TripdataSno);
                                        cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                                        vdm.Update(cmd);
                                    }
                                }
                                else
                                {
                                    cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                                    float deliverQty = 0;
                                    float.TryParse(o.ReturnQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out deliverQty);
                                    cmd.Parameters.Add("@DeliverQty", deliverQty);
                                    int Prsno = 0;
                                    int.TryParse(o.Productsno, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Prsno);
                                    cmd.Parameters.Add("@ProductId", Prsno);
                                    int TripdataSno = 0;
                                    int.TryParse(context.Session["TripdataSno"].ToString(), out TripdataSno);
                                    cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                                    vdm.Update(cmd);
                                }
                            }
                        }
                        #endregion
                        #region Sync_Sale_value

                        cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS DeliveryQty, indents.Branch_id, indents_subtable.UnitCost FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo WHERE (indents_subtable.DTripId = @TripID) GROUP BY indents.Branch_id");
                        cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                        DataTable dtAgentWiseSaleValue = vdm.SelectQuery(cmd).Tables[0];
                        float totAmount_ = 0;
                        float PrevAmount = 0;
                        int BranchID_ = 0;
                        foreach (DataRow dr in dtAgentWiseSaleValue.Rows)
                        {
                            float.TryParse(dr["DeliveryQty"].ToString(), out totAmount_);
                            int.TryParse(dr["Branch_id"].ToString(), out BranchID_);
                            cmd = new MySqlCommand("SELECT BranchId, Amount, FineAmount, Dtripid, Ctripid, SaleValue FROM branchaccounts WHERE (Dtripid = @Dtripid) AND (BranchId = @BranchId)");
                            cmd.Parameters.Add("@BranchId", BranchID_);
                            cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                            DataTable dtprevsalevalue = vdm.SelectQuery(cmd).Tables[0];
                            if (dtprevsalevalue.Rows.Count > 0)
                            {
                                //float.TryParse(dr["SaleValue"].ToString(), out PrevAmount);
                                float.TryParse(dtprevsalevalue.Rows[0]["SaleValue"].ToString(), out PrevAmount);
                                float diffamount_ = 0;
                                diffamount_ = PrevAmount - totAmount_;
                                if (PrevAmount < totAmount_)
                                {
                                    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount,Dtripid=@Dtripid,SaleValue=@SaleValue where BranchId=@BranchId");
                                    cmd.Parameters.Add("@Amount", diffamount_);
                                    cmd.Parameters.Add("@BranchId", BranchID_);
                                    cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                    cmd.Parameters.Add("@SaleValue", totAmount_);

                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId,Dtripid,SaleValue) values(@Amount,@BranchId,@Dtripid,@SaleValue)");
                                        cmd.Parameters.Add("@Amount", diffamount_);
                                        cmd.Parameters.Add("@BranchId", BranchID_);
                                        cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                        cmd.Parameters.Add("@SaleValue", totAmount_);
                                        vdm.insert(cmd);
                                    }
                                }
                                else
                                {
                                    diffamount_ = Math.Abs(diffamount_);
                                    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount,Dtripid=@Dtripid,SaleValue=@SaleValue where BranchId=@BranchId");
                                    cmd.Parameters.Add("@Amount", diffamount_);
                                    cmd.Parameters.Add("@BranchId", BranchID_);
                                    cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                    cmd.Parameters.Add("@SaleValue", totAmount_);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId,Dtripid,SaleValue) values(@Amount,@BranchId,@Dtripid,@SaleValue)");
                                        cmd.Parameters.Add("@Amount", diffamount_);
                                        cmd.Parameters.Add("@BranchId", BranchID_);
                                        cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                        cmd.Parameters.Add("@SaleValue", totAmount_);
                                        vdm.insert(cmd);
                                    }
                                }

                            }
                            else
                            {
                                cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount,Dtripid=@Dtripid,SaleValue=@SaleValue where BranchId=@BranchId");
                                cmd.Parameters.Add("@Amount", totAmount_);
                                cmd.Parameters.Add("@BranchId", BranchID_);
                                cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@SaleValue", totAmount_);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId,Dtripid,SaleValue) values(@Amount,@BranchId,@Dtripid,@SaleValue)");
                                    cmd.Parameters.Add("@Amount", totAmount_);
                                    cmd.Parameters.Add("@BranchId", BranchID_);
                                    cmd.Parameters.Add("@Dtripid", context.Session["TripdataSno"].ToString());
                                    cmd.Parameters.Add("@SaleValue", totAmount_);
                                    vdm.insert(cmd);
                                }
                            }
                        }

                        #endregion
                    }
                    List<Inventorydetail> ColInventory_list = (List<Inventorydetail>)context.Session["inventory_syncData"];
                    ErrMsg = "Deliver Inventory";

                    #region Inventory_Sync_Code
                    if (ColInventory_list == null)
                    {
                    }
                    else
                    {
                        DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                        cmd = new MySqlCommand("SELECT TransType, FromTran, ToTran, Qty,CBFromTran,B_inv_sno FROM invtransactions12 WHERE (TransType = @TransType)  AND (FromTran = @TripID) ");
                        cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                        //cmd.Parameters.Add("@BranchID", o.BrancID);
                        //cmd.Parameters.Add("@InvSno", o.InvSno);
                        cmd.Parameters.Add("@TransType", "2");
                        DataTable dtTotalInvData = vdm.SelectQuery(cmd).Tables[0];
                        foreach (Inventorydetail o in ColInventory_list)
                        {
                            //cmd = new MySqlCommand("SELECT TransType, FromTran, ToTran, Qty,CBFromTran FROM invtransactions12 WHERE (TransType = @TransType) AND (B_inv_sno = @InvSno) AND (FromTran = @TripID) AND (ToTran = @BranchID)");
                            //cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                            //cmd.Parameters.Add("@BranchID", o.BrancID);
                            //cmd.Parameters.Add("@InvSno", o.InvSno);
                            //cmd.Parameters.Add("@TransType", "2");

                            DataRow[] drInvData = dtTotalInvData.Select("ToTran=" + o.BrancID + " and B_inv_sno=" + o.InvSno);
                            if (drInvData.Count() > 0)
                            {
                                DataTable dtInvData = drInvData.CopyToDataTable();
                                int Aqty = 0;
                                string Qty = dtInvData.Rows[0]["Qty"].ToString();
                                string CBFromTran = dtInvData.Rows[0]["CBFromTran"].ToString();
                                if (Qty == "")
                                {
                                    Aqty = 0;
                                }
                                else
                                {
                                    int.TryParse(Qty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Aqty);
                                }
                                int Eqty = 0;
                                int.TryParse(o.GivenQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Eqty);
                                int TQty = Aqty - Eqty;
                                if (TQty >= 1)
                                {
                                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty-@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                    cmd.Parameters.Add("@Qty", TQty);
                                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                    cmd.Parameters.Add("@BranchId", o.BrancID);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                        cmd.Parameters.Add("@Qty", TQty);
                                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                        cmd.Parameters.Add("@BranchId", o.BrancID);
                                        vdm.insert(cmd);
                                    }
                                }
                                else
                                {
                                    TQty = Math.Abs(TQty);
                                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                    cmd.Parameters.Add("@Qty", TQty);
                                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                    cmd.Parameters.Add("@BranchId", o.BrancID);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                        cmd.Parameters.Add("@Qty", TQty);
                                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                        cmd.Parameters.Add("@BranchId", o.BrancID);
                                        vdm.insert(cmd);
                                    }
                                }
                            }
                            else
                            {
                                cmd = new MySqlCommand("SELECT BranchId, Inv_Sno, Qty, Sno, EmpId, lostQty, Indent_Date,Dtripid FROM inventory_monitor WHERE (Dtripid = @dtripid) AND (BranchId = @agentid) and (Inv_Sno = @Inv_Sno)");
                                cmd.Parameters.Add("@dtripid", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@agentid", o.BrancID);
                                cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                DataTable dtinvmonitor = vdm.SelectQuery(cmd).Tables[0];
                                if (dtinvmonitor.Rows.Count > 0)
                                {
                                    //sync_end_msg = "Inventory Delivered Double Time";
                                    ErrMsg = "Inventory Delivered Double Time" + o.BrancID;
                                    string toAddress = "ravindra1507@gmail.com";
                                    string subject = "Vyshnavi Offline";
                                    string body = "";
                                    if (context.Session["TripdataSno"] == null)
                                    {
                                        body = "ErrMsg" + ErrMsg;
                                    }
                                    else
                                    {
                                        body = context.Session["TripdataSno"].ToString() + "ErrMsg" + ErrMsg;
                                    }
                                    SendEmail(toAddress, subject, body);
                                }
                                else
                                {
                                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty,Dtripid=@dtripid where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                    cmd.Parameters.Add("@Qty", o.GivenQty);
                                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                    cmd.Parameters.Add("@BranchId", o.BrancID);
                                    cmd.Parameters.Add("@dtripid", context.Session["TripdataSno"].ToString());
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId,Dtripid) values(@Qty,@Inv_Sno,@BranchId,@dtripid)");
                                        cmd.Parameters.Add("@Qty", o.GivenQty);
                                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                        cmd.Parameters.Add("@BranchId", o.BrancID);
                                        cmd.Parameters.Add("@dtripid", context.Session["TripdataSno"].ToString());
                                        vdm.insert(cmd);
                                    }
                                }

                            }
                            cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE,DeliveryTime=@deliverytime where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                            cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                            cmd.Parameters.Add("@Qty", o.GivenQty);
                            cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                            cmd.Parameters.Add("@deliverytime", o.DInvDate);
                            cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@TransType", "2");
                            cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                            cmd.Parameters.Add("@To", o.BrancID);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,DeliveryTime) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@deliverytime)");
                                cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                                cmd.Parameters.Add("@Qty", o.GivenQty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@deliverytime", o.DInvDate);
                                cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@TransType", "2");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", o.BrancID);
                                vdm.insert(cmd);
                            }
                        }
                    }
                    #endregion

                    List<Amountdetail> Amount_list = (List<Amountdetail>)context.Session["Amount_syncData"];
                    ErrMsg = "Amounts";

                    #region Amount_syncData
                    if (Amount_list == null)
                    {
                    }
                    else
                    {
                        DateTime dtCdate = VehicleDBMgr.GetTime(vdm.conn);
                        DateTime dtapril = new DateTime();
                        DateTime dtmarch = new DateTime();
                        int currentyear = dtCdate.Year;
                        int nextyear = dtCdate.Year + 1;
                        if (dtCdate.Month > 3)
                        {
                            string apr = "4/1/" + currentyear;
                            dtapril = DateTime.Parse(apr);
                            string march = "3/31/" + nextyear;
                            dtmarch = DateTime.Parse(march);
                        }
                        if (dtCdate.Month <= 3)
                        {
                            string apr = "4/1/" + (currentyear - 1);
                            dtapril = DateTime.Parse(apr);
                            string march = "3/31/" + (nextyear - 1);
                            dtmarch = DateTime.Parse(march);
                        }
                        foreach (Amountdetail o in Amount_list)
                        {
                            string Paytime = o.Coldate;
                            float TodayAmount = 0;
                            float.TryParse(o.TodayAmount, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out TodayAmount);
                            int BranchID = 0;
                            int.TryParse(o.BrancID, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out BranchID);
                            cmd = new MySqlCommand("SELECT Branchid, AmountPaid FROM collections WHERE (tripId = @tripID) AND (Branchid = @BranchID)");
                            cmd.Parameters.Add("@tripID", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@BranchID", BranchID);
                            DataTable dtCollections = vdm.SelectQuery(cmd).Tables[0];
                            if (dtCollections.Rows.Count > 0)
                            {
                                float AAmount = 0;
                                string AmountPaid = dtCollections.Rows[0]["AmountPaid"].ToString();
                                if (AmountPaid == "")
                                {
                                    AAmount = 0;
                                }
                                else
                                {
                                    float.TryParse(AmountPaid, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out AAmount);
                                }
                                float EAmount = 0;
                                float.TryParse(o.TodayAmount, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out EAmount);
                                float TAmount = AAmount - EAmount;
                                if (AAmount > EAmount)
                                {
                                    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                    cmd.Parameters.Add("@Amount", TAmount);
                                    cmd.Parameters.Add("@BranchId", BranchID);
                                    vdm.Update(cmd);
                                }
                                else
                                {
                                    TAmount = Math.Abs(TAmount);
                                    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount where BranchId=@BranchId");
                                    cmd.Parameters.Add("@Amount", TAmount);
                                    cmd.Parameters.Add("@BranchId", BranchID);
                                    vdm.Update(cmd);
                                }
                            }
                            else
                            {
                                //string DispType = context.Session["DispType"].ToString();
                                //if (DispType == "SO")
                                //{
                                cmd = new MySqlCommand("SELECT BranchId, Amount, Ctripid FROM branchaccounts WHERE (BranchId = @BranchId) AND (Ctripid = @ctripid)");
                                cmd.Parameters.Add("@BranchId", BranchID);
                                cmd.Parameters.Add("@ctripid", context.Session["TripdataSno"].ToString());
                                DataTable amountcollection = vdm.SelectQuery(cmd).Tables[0];
                                if (amountcollection.Rows.Count > 0)
                                {
                                    ErrMsg = "Amount Collection Double Time" + BranchID;
                                    string toAddress = "ravindra1507@gmail.com";
                                    string subject = "Vyshnavi Offline";
                                    string body = "";
                                    if (context.Session["TripdataSno"] == null)
                                    {
                                        body = "ErrMsg" + ErrMsg;
                                    }
                                    else
                                    {
                                        body = context.Session["TripdataSno"].ToString() + "ErrMsg" + ErrMsg;
                                    }
                                    SendEmail(toAddress, subject, body);
                                }
                                else
                                {
                                    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount,Ctripid=@ctripid where BranchId=@BranchId");
                                    cmd.Parameters.Add("@Amount", TodayAmount);
                                    cmd.Parameters.Add("@BranchId", BranchID);
                                    cmd.Parameters.Add("@ctripid", context.Session["TripdataSno"].ToString());
                                    vdm.Update(cmd);
                                    //if (vdm.Update(cmd) == 0)
                                    //{
                                    //    cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId,Ctripid) values(@Amount,@BranchId,@ctripid)");
                                    //    cmd.Parameters.Add("@Amount", TodayAmount);
                                    //    cmd.Parameters.Add("@BranchId", BranchID);
                                    //    cmd.Parameters.Add("@ctripid", context.Session["TripdataSno"].ToString());
                                    //    vdm.insert(cmd);
                                    //}
                                }



                                //}
                                //else
                                //{
                                //    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                //    float amount = 0;
                                //    float.TryParse(o.Amount, out amount);
                                //    float Today = 0;
                                //    float.TryParse(o.TodayAmount, out Today);
                                //    float BalAmount = amount - Today;
                                //    cmd.Parameters.Add("@Amount", BalAmount);
                                //    cmd.Parameters.Add("@BranchId", BranchID);
                                //    vdm.Update(cmd);
                                //    //cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount where BranchId=@BranchId");
                                //    //cmd.Parameters.Add("@Amount", TodayAmount);
                                //    //cmd.Parameters.Add("@BranchId", BranchID);
                                //    //vdm.Update(cmd);
                                //}
                                string BranchSno = context.Session["BranchSno"].ToString();
                                if (BranchSno == "457" || BranchSno == "159" || BranchSno == "158" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "1839" || BranchSno == "2909" || BranchSno == "2749" || BranchSno == "1801")
                                {

                                    cmd = new MySqlCommand("Select IFNULL(MAX(Receipt),0)+1 as Sno  from cashreceipts where BranchID=@BranchID AND (DOE BETWEEN @d1 AND @d2)");
                                    if (BranchSno == "527" || BranchSno == "4607" || BranchSno == "285" || BranchSno == "2948")
                                    {
                                        if (BranchSno == "285" || BranchSno == "2948")
                                        {
                                            cmd.Parameters.Add("@BranchID", "285");
                                            BranchSno = "285";
                                        }
                                        else
                                        {
                                            cmd.Parameters.Add("@BranchID", "174");
                                            BranchSno = "174";
                                        }
                                    }
                                    else if (BranchSno == "1839")
                                    {
                                        cmd.Parameters.Add("@BranchID", "538");
                                        BranchSno = "538";
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@BranchID", context.Session["BranchSno"].ToString());

                                    }
                                    cmd.Parameters.Add("@d1", GetLowDate(dtapril));
                                    cmd.Parameters.Add("@d2", GetHighDate(dtmarch));
                                    DataTable dtReceipt = vdm.SelectQuery(cmd).Tables[0];
                                    string CashReceiptNo = dtReceipt.Rows[0]["Sno"].ToString();
                                    if (o.PayType == "Cheque")
                                    {
                                        cmd = new MySqlCommand("insert into cashreceipts (BranchId,ReceivedFrom,AgentID,AmountPaid,DOE,Create_by,Remarks,OppBal,Receipt,Paymentstatus,ChequeNo,Tripid) values (@BranchId,@ReceivedFrom,@AgentID,@AmountPaid,@DOE, @Create_by,@Remarks,@OppBal,@Receipt,@Paymentstatus,@ChequeNo,@Tripid)");
                                        cmd.Parameters.Add("@ChequeNo", o.checkNo);
                                        cmd.Parameters.Add("@Paymentstatus", "Cheque");
                                    }
                                    else
                                    {
                                        cmd = new MySqlCommand("insert into cashreceipts (BranchId,ReceivedFrom,AgentID,AmountPaid,DOE,Create_by,Remarks,OppBal,Receipt,Tripid,Paymentstatus) values (@BranchId,@ReceivedFrom,@AgentID,@AmountPaid,@DOE, @Create_by,@Remarks,@OppBal,@Receipt,@Tripid,@Paymentstatus)");
                                        cmd.Parameters.Add("@Paymentstatus", "Cash");
                                    }
                                    //cmd.Parameters.Add("@BranchId", context.Session["BranchSno"].ToString());
                                    cmd.Parameters.Add("@BranchId", BranchSno);
                                    cmd.Parameters.Add("@ReceivedFrom", "Agent");
                                    cmd.Parameters.Add("@AgentID", BranchID);
                                    cmd.Parameters.Add("@AmountPaid", TodayAmount);
                                    string ind_Date = context.Session["I_Date"].ToString();
                                    DateTime dtindDate = Convert.ToDateTime(ind_Date);
                                    cmd.Parameters.Add("DOE", dtindDate.AddDays(1));
                                    //cmd.Parameters.Add("DOE", dtCdate);

                                    cmd.Parameters.Add("@Create_by", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@Remarks", "Sale Of Milk");
                                    cmd.Parameters.Add("@OppBal", TodayAmount);
                                    cmd.Parameters.Add("@Receipt", CashReceiptNo);
                                    cmd.Parameters.Add("@Tripid", context.Session["TripdataSno"].ToString());
                                    if (TodayAmount != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                }
                            }
                            cmd = new MySqlCommand("Update  collections set  AmountPaid=@AmountPaid,PaymentType=@PaymentType,PaidDate=@PayDate where  Branchid=@Branchid and tripId=@tripId");
                            cmd.Parameters.Add("@Branchid", BranchID);
                            cmd.Parameters.Add("@tripId", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@AmountPaid", TodayAmount);
                            cmd.Parameters.Add("@PaymentType", o.PayType);
                            cmd.Parameters.Add("@PayDate", dtCdate);
                            if (vdm.Update(cmd) == 0)
                            {
                                if (o.PayType == "Cash")
                                {
                                    cmd = new MySqlCommand("insert into collections (Branchid,AmountPaid,Denominations,PaidDate,UserData_sno,PaymentType,tripId,ReturnDenomin,PayTime)values(@Branchid,@AmountPaid,@Denominations,@PaidDate,@UserData_sno,@PaymentType,@tripId,@ReturnDenomin,@PayTime)");
                                }
                                else
                                {
                                    cmd = new MySqlCommand("insert into collections (Branchid,AmountPaid,Denominations,PaidDate,UserData_sno,PaymentType,tripId,CheckStatus,ReturnDenomin,PayTime)values(@Branchid,@AmountPaid,@Denominations,@PaidDate,@UserData_sno,@PaymentType,@tripId,@CheckStatus,@ReturnDenomin,@PayTime)");
                                    cmd.Parameters.Add("@CheckStatus", 'P');
                                }
                                cmd.Parameters.Add("@Branchid", BranchID);
                                cmd.Parameters.Add("@AmountPaid", TodayAmount);
                                cmd.Parameters.Add("@Denominations", o.checkNo);
                                cmd.Parameters.Add("@PaidDate", dtCdate);
                                cmd.Parameters.Add("@UserData_sno", Usernamesno);
                                cmd.Parameters.Add("@PayTime", Paytime);
                                cmd.Parameters.Add("@PaymentType", o.PayType);
                                cmd.Parameters.Add("@ReturnDenomin", o.ReturnDenomonation);
                                cmd.Parameters.Add("@tripId", context.Session["TripdataSno"].ToString());
                                vdm.insert(cmd);
                                cmd = new MySqlCommand("Update empaccounts set Amount=Amount+@Amount where EmpID=@EmpID");
                                cmd.Parameters.Add("@Amount", TodayAmount);
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into empaccounts(Amount,EmpID) values(@Amount,@EmpID)");
                                    cmd.Parameters.Add("@Amount", TodayAmount);
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    vdm.insert(cmd);
                                }
                            }
                            else
                            {

                            }
                        }
                    }
                    #endregion
                    List<CInventorydetail> Col_Inventory_list = (List<CInventorydetail>)context.Session["Collection_inventory_syncData"];
                    ErrMsg = "Coll Inventory";

                    #region collection_inventory_syncdata
                    if (Col_Inventory_list == null)
                    {
                    }
                    else
                    {
                        DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                        cmd = new MySqlCommand("SELECT TransType, FromTran, ToTran, Qty,B_inv_sno FROM invtransactions12 WHERE (TransType = @TransType) AND  (ToTran = @TripID)");
                        cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                        //cmd.Parameters.Add("@BranchID", o.BrancID);
                        //cmd.Parameters.Add("@InvSno", o.InvSno);
                        cmd.Parameters.Add("@TransType", "3");
                        DataTable dtTotalCInvData = vdm.SelectQuery(cmd).Tables[0];
                        foreach (CInventorydetail o in Col_Inventory_list)
                        {
                            //cmd = new MySqlCommand("SELECT TransType, FromTran, ToTran, Qty FROM invtransactions12 WHERE (TransType = @TransType) AND (B_inv_sno = @InvSno) AND (FromTran = @BranchID) AND (ToTran = @TripID)");
                            //cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                            //cmd.Parameters.Add("@BranchID", o.BrancID);
                            //cmd.Parameters.Add("@InvSno", o.InvSno);
                            //cmd.Parameters.Add("@TransType", "3");
                            DataRow[] drInvData = dtTotalCInvData.Select("FromTran=" + o.BrancID + " and B_inv_sno=" + o.InvSno);
                            if (drInvData.Count() > 0)
                            {
                                DataTable dtInvData = drInvData.CopyToDataTable();
                                int Aqty = 0;
                                string Qty = dtInvData.Rows[0]["Qty"].ToString();
                                if (Qty == "")
                                {
                                    Aqty = 0;
                                }
                                else
                                {
                                    int.TryParse(Qty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Aqty);
                                }
                                int Eqty = 0;
                                int.TryParse(o.GivenQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Eqty);
                                int TQty = Aqty - Eqty;
                                if (TQty >= 1)
                                {
                                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty-@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                    cmd.Parameters.Add("@Qty", TQty);
                                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                    cmd.Parameters.Add("@BranchId", o.BrancID);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                        cmd.Parameters.Add("@Qty", TQty);
                                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                        cmd.Parameters.Add("@BranchId", o.BrancID);
                                        vdm.insert(cmd);
                                    }
                                }
                                else
                                {
                                    TQty = Math.Abs(TQty);
                                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                    cmd.Parameters.Add("@Qty", TQty);
                                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                    cmd.Parameters.Add("@BranchId", o.BrancID);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                        cmd.Parameters.Add("@Qty", TQty);
                                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                        cmd.Parameters.Add("@BranchId", o.BrancID);
                                        vdm.insert(cmd);
                                    }
                                }
                            }
                            else
                            {
                                cmd = new MySqlCommand("SELECT BranchId, Inv_Sno, Qty, Sno, EmpId, lostQty, Indent_Date,CTripid FROM inventory_monitor WHERE (CTripid = @ctripid) AND (BranchId = @agentid) and (Inv_Sno = @Inv_Sno)");
                                cmd.Parameters.Add("@ctripid", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@agentid", o.BrancID);
                                cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                DataTable dtinvmonitor_Collected = vdm.SelectQuery(cmd).Tables[0];
                                if (dtinvmonitor_Collected.Rows.Count > 0)
                                {
                                    ErrMsg = "Inventory Collection Double Time" + o.BrancID;
                                    string toAddress = "ravindra1507@gmail.com";
                                    string subject = "Vyshnavi Offline";
                                    string body = "";
                                    if (context.Session["TripdataSno"] == null)
                                    {
                                        body = "ErrMsg" + ErrMsg;
                                    }
                                    else
                                    {
                                        body = context.Session["TripdataSno"].ToString() + "ErrMsg" + ErrMsg;
                                    }
                                    SendEmail(toAddress, subject, body);
                                }
                                else
                                {
                                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty-@Qty,CTripid=@ctripid where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                    cmd.Parameters.Add("@Qty", o.GivenQty);
                                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                    cmd.Parameters.Add("@BranchId", o.BrancID);
                                    cmd.Parameters.Add("@ctripid", context.Session["TripdataSno"].ToString());
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId,CTripid) values(@Qty,@Inv_Sno,@BranchId,@ctripid)");
                                        cmd.Parameters.Add("@Qty", o.GivenQty);
                                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                        cmd.Parameters.Add("@BranchId", o.BrancID);
                                        cmd.Parameters.Add("@ctripid", context.Session["TripdataSno"].ToString());
                                        vdm.insert(cmd);
                                    }
                                }

                            }
                            cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE,CollectionTime=@collectiontime where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                            cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                            cmd.Parameters.Add("@Qty", o.GivenQty);
                            cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                            cmd.Parameters.Add("@collectiontime", o.CInvDate);
                            cmd.Parameters.Add("@From", o.BrancID);
                            cmd.Parameters.Add("@TransType", "3");
                            cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                            cmd.Parameters.Add("@To", context.Session["TripdataSno"].ToString());
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,CollectionTime) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@collectiontime)");
                                cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                                cmd.Parameters.Add("@Qty", o.GivenQty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@collectiontime", o.CInvDate);
                                cmd.Parameters.Add("@From", o.BrancID);
                                cmd.Parameters.Add("@TransType", "3");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", context.Session["TripdataSno"].ToString());
                                vdm.insert(cmd);
                            }
                        }
                    }
                    #endregion
                    List<Leakagedetail> LeaksList = (List<Leakagedetail>)context.Session["LeaksList_syncData"];
                    ErrMsg = "Leaks";

                    #region leakslist_syncData
                    if (LeaksList == null)
                    {
                    }
                    else
                    {
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        foreach (Leakagedetail o in LeaksList)
                        {
                            if (o.Productsno != null)
                            {
                                cmd = new MySqlCommand("update leakages set  EntryDate=@EntryDate,ShortQty=@ShortQty,LeakQty=@LeakQty,FreeMilk=@FreeMilk where (TripID=@TripID) and (ProductID=@ProductID) AND (VarifyStatus IS NULL) ");
                                cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                                cmd.Parameters.Add("@EntryDate", Currentdate);
                                cmd.Parameters.Add("@ProductID", o.Productsno);
                                float ShortQty = 0;
                                float.TryParse(o.ShortQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out ShortQty);
                                cmd.Parameters.Add("@ShortQty", ShortQty);
                                float LeakQty = 0;
                                float.TryParse(o.LeakQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out LeakQty);
                                cmd.Parameters.Add("@LeakQty", LeakQty);
                                float FreeMilk = 0;
                                float.TryParse(o.FreeMilk, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out FreeMilk);
                                cmd.Parameters.Add("@FreeMilk", FreeMilk);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("insert into leakages (TripID,EntryDate,ProductID,ShortQty,LeakQty,FreeMilk)values(@TripID,@EntryDate,@ProductID,@ShortQty,@LeakQty,@FreeMilk)");
                                    cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                                    cmd.Parameters.Add("@EntryDate", Currentdate);
                                    cmd.Parameters.Add("@ProductID", o.Productsno);
                                    float.TryParse(o.ShortQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out ShortQty);
                                    cmd.Parameters.Add("@ShortQty", ShortQty);
                                    float.TryParse(o.LeakQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out LeakQty);
                                    cmd.Parameters.Add("@LeakQty", LeakQty);
                                    cmd.Parameters.Add("@FreeMilk", FreeMilk);
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }

                    #endregion
                    List<InvDatails> InvDatailstlist = (List<InvDatails>)context.Session["InvDatailstlist_sync"];
                    List<RouteLeakdetails> RouteLeakslist = (List<RouteLeakdetails>)context.Session["RouteLeakslist_sync"];
                    ErrMsg = "Route Leaks";

                    #region invDatailstlist_sync

                    if (InvDatailstlist == null)
                    {
                    }
                    else
                    {
                        string Username = context.Session["userdata_sno"].ToString();
                        string LevelType = context.Session["LevelType"].ToString();
                        DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                        foreach (InvDatails o in InvDatailstlist)
                        {
                            if (o.SNo != null)
                            {
                                if (LevelType == "SODispatcher")
                                {
                                    cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                    cmd.Parameters.Add("@Qty", o.Qty);
                                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@From", context.Session["BranchSno"].ToString());
                                    cmd.Parameters.Add("@TransType", "3");
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@To", context.Session["ATripId"].ToString());
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,VarifyStatus) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@VarifyStatus)");
                                        cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                        cmd.Parameters.Add("@Qty", o.Qty);
                                        cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                        cmd.Parameters.Add("@From", context.Session["BranchSno"].ToString());
                                        cmd.Parameters.Add("@TransType", "3");
                                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                        cmd.Parameters.Add("@To", context.Session["ATripId"].ToString());
                                        cmd.Parameters.Add("@VarifyStatus", "p");
                                        int Qty = 0;
                                        int.TryParse(o.Qty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Qty);
                                        if (Qty != 0)
                                        {
                                            vdm.insert(cmd);
                                        }
                                    }
                                }
                                else
                                {
                                    cmd = new MySqlCommand("update tripinvdata set Remaining=@Remaining where Tripdata_sno=@TripID and invId=@invId");
                                    int GivenQty = 0;
                                    int.TryParse(o.Qty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out GivenQty);
                                    cmd.Parameters.Add("@Remaining", GivenQty);
                                    cmd.Parameters.Add("@invId", o.SNo);
                                    cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                        cmd.Parameters.Add("@Invid", o.SNo);
                                        int Qty = 0;
                                        cmd.Parameters.Add("@Qty", Qty);
                                        cmd.Parameters.Add("@Remaining", GivenQty);
                                        cmd.Parameters.Add("@Tripdata_sno", context.Session["TripdataSno"].ToString());
                                        vdm.insert(cmd);
                                    }
                                    cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                    cmd.Parameters.Add("@Qty", o.Qty);
                                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                    cmd.Parameters.Add("@TransType", "2");
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,VarifyStatus) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@VarifyStatus)");
                                        cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                        cmd.Parameters.Add("@Qty", o.Qty);
                                        cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                        cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                        cmd.Parameters.Add("@TransType", "2");
                                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                        cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                                        cmd.Parameters.Add("@VarifyStatus", "P");
                                        int Qty = 0;
                                        int.TryParse(o.Qty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Qty);
                                        if (Qty != 0)
                                        {
                                            vdm.insert(cmd);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (RouteLeakslist == null)
                    {
                    }
                    else
                    {
                        DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                        foreach (RouteLeakdetails o in RouteLeakslist)
                        {
                            cmd = new MySqlCommand("Update Leakages set ReturnQty=@ReturnQty,TotalLeaks=@TotalLeaks,EntryDate=@EntryDate  where ProductID=@ProductID and TripID=@TripID and VarifyStatus=@VarifyStatus and VarifyReturnStatus=@VarifyReturnStatus");
                            float ReturnQty = 0;
                            float.TryParse(o.ReturnsQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out ReturnQty);
                            if (ReturnQty < 0)
                            {
                                ReturnQty = 0;
                            }
                            cmd.Parameters.Add("@ReturnQty", ReturnQty);
                            float TotalLeaks = 0;
                            float.TryParse(o.LeaksQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out TotalLeaks);
                            cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                            cmd.Parameters.Add("@ProductID", o.ProductID);
                            cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                            cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@VarifyStatus", "P");
                            cmd.Parameters.Add("@VarifyReturnStatus", "P");
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into  Leakages(ReturnQty,TotalLeaks,ProductID,TripID,VarifyStatus,EntryDate,VarifyReturnStatus) Values (@ReturnQty,@TotalLeaks,@ProductID,@TripID,@VarifyStatus,@EntryDate,@VarifyReturnStatus)");
                                cmd.Parameters.Add("@ReturnQty", ReturnQty);
                                cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                                cmd.Parameters.Add("@ProductID", o.ProductID);
                                cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@VarifyStatus", "P");
                                cmd.Parameters.Add("@VarifyReturnStatus", "P");
                                string Status = "True";
                                if (ReturnQty < 0)
                                {
                                    ReturnQty = 0;
                                }
                                if (ReturnQty != 0.0)
                                {
                                    Status = "True";
                                }
                                if (TotalLeaks != 0.0)
                                {
                                    if (Status == "False")
                                    {
                                        Status = "True";
                                    }
                                }
                                if (Status == "True")
                                {
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }
                    #endregion
                    List<NextIndentdetail> Indent_Product_list = (List<NextIndentdetail>)context.Session["indent_Next_syncData"];
                    List<OfferNextIndentdetail> Offer_Indent_Product_list = (List<OfferNextIndentdetail>)context.Session["Offer_indent_Next_syncData"];

                    ErrMsg = "Offline Indent";

                    #region indent_syncData


                    if (Indent_Product_list == null)
                    {
                    }
                    else
                    {
                        string DispDat = context.Session["I_Date"].ToString();
                        DateTime ServerDateCurrentdat = Convert.ToDateTime(DispDat).AddDays(1);
                        foreach (NextIndentdetail o in Indent_Product_list)
                        {
                            string IndentType = o.IndentType;
                            if (IndentType == "")
                            {
                                IndentType = "Indent1";
                            }
                            if (IndentType == null)
                            {
                                IndentType = "Indent1";
                            }
                            if (o.Productsno != null)
                            {
                                cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                                cmd.Parameters.Add("@Branch_id", o.BranchID);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdat));
                                DataTable dtIndentsNo = vdm.SelectQuery(cmd).Tables[0];
                                long IndentNo = 0;
                                if (dtIndentsNo.Rows.Count == 0)
                                {
                                    cmd = new MySqlCommand("insert into indents (Branch_id,I_date,UserData_sno,Status,PaymentStatus,IndentType)values(@Branch_id,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                                    cmd.Parameters.Add("@Branch_id", o.BranchID);
                                    //cmd.Parameters.Add("@TotalQty", Qty);
                                    //cmd.Parameters.Add("@TotalPrice", Price);
                                    cmd.Parameters.Add("@I_date", ServerDateCurrentdat);
                                    cmd.Parameters.Add("@UserData_sno", Usernamesno);
                                    cmd.Parameters.Add("@Status", "O");
                                    cmd.Parameters.Add("@PaymentStatus", 'A');
                                    cmd.Parameters.Add("@IndentType", IndentType);
                                    IndentNo = vdm.insertScalar(cmd);
                                }

                                cmd = new MySqlCommand("SELECT branchproducts.unitprice, branchproducts.product_sno, productsdata.Qty, productsdata.Units FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) and (branchproducts.product_sno=@sno) ");
                                cmd.Parameters.Add("@sno", o.Productsno);
                                cmd.Parameters.Add("@BranchID", o.BranchID);
                                DataTable dtBranchProduct = vdm.SelectQuery(cmd).Tables[0];
                                string AunitPrice = "0";

                                //float price = 0;
                                float ProductRate = 0;

                                if (dtBranchProduct.Rows.Count > 0)
                                {
                                    AunitPrice = dtBranchProduct.Rows[0]["unitprice"].ToString();
                                }

                                if (AunitPrice == "0")
                                {
                                    cmd = new MySqlCommand("SELECT productsdata.UnitPrice,productsdata.Qty, productsdata.Units, branchproducts.product_sno, branchproducts.unitprice AS Bunitprice , productsdata.ProductName FROM productsdata INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch WHERE (branchmappingtable.SubBranch = @BranchID) AND (branchproducts.product_sno = @Sno)");
                                    cmd.Parameters.Add("@sno", o.Productsno);
                                    cmd.Parameters.Add("@BranchID", o.BranchID);
                                    DataTable dtProduct = vdm.SelectQuery(cmd).Tables[0];
                                    string unitprice = "0";
                                    string BUnitPrice = "0";
                                    if (dtProduct.Rows.Count > 0)
                                    {
                                        unitprice = dtProduct.Rows[0]["UnitPrice"].ToString();
                                        BUnitPrice = dtProduct.Rows[0]["BUnitPrice"].ToString();
                                        //float UnitCost = 0;

                                    }
                                    if (BUnitPrice != "0")
                                    {
                                        if (dtProduct.Rows.Count > 0)
                                        {
                                            ProductRate = (float)dtProduct.Rows[0]["BUnitPrice"];
                                        }
                                        else
                                        {
                                            float.TryParse(BUnitPrice, out ProductRate);
                                        }
                                        //price = ProductRate;

                                    }
                                    else
                                    {
                                        if (dtProduct.Rows.Count > 0)
                                        {
                                            ProductRate = (float)dtProduct.Rows[0]["UnitPrice"];
                                        }
                                        else
                                        {
                                            float.TryParse(unitprice, out ProductRate);
                                        }
                                        //price = ProductRate;

                                    }
                                }
                                if (AunitPrice != "0")
                                {
                                    //float unitamt = 0;
                                    float.TryParse(AunitPrice, out ProductRate);
                                    //price = unitamt;

                                }




                                cmd = new MySqlCommand("Update indents_subtable set unitQty=@unitQty,OTripId=@OTripId,UnitCost=@UnitCost,Status=@Status where IndentNo=@IndentNo and Product_sno=@Product_sno");
                                if (dtIndentsNo.Rows.Count == 0)
                                {
                                    cmd.Parameters.Add("@IndentNo", IndentNo);
                                }
                                else
                                {
                                    string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                    cmd.Parameters.Add("@IndentNo", strIndentsNo);
                                }
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                cmd.Parameters.Add("@UnitCost", ProductRate);
                                float unitQty = 0;
                                float.TryParse(o.Unitsqty, out unitQty);
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@Status", "Ordered");
                                cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,OTripId)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@OTripId)");
                                    if (dtIndentsNo.Rows.Count == 0)
                                    {
                                        cmd.Parameters.Add("@IndentNo", IndentNo);
                                    }
                                    else
                                    {
                                        string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                        cmd.Parameters.Add("@IndentNo", strIndentsNo);
                                    }
                                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                                    //float.TryParse(o.UnitCost, out UnitCost);
                                    cmd.Parameters.Add("@UnitCost", ProductRate);
                                    float.TryParse(o.Unitsqty, out unitQty);
                                    cmd.Parameters.Add("@unitQty", unitQty);
                                    cmd.Parameters.Add("@Status", "Ordered");
                                    cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                    vdm.insert(cmd);
                                }
                            }
                        }
                        foreach (OfferNextIndentdetail o in Offer_Indent_Product_list)
                        {
                            string IndentType = "";
                            IndentType = context.Session["IndentType"].ToString();

                            if (IndentType == "")
                            {
                                IndentType = "Indent1";
                            }
                            if (IndentType == null)
                            {
                                IndentType = "Indent1";
                            }
                            cmd = new MySqlCommand("SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType FROM offer_indents WHERE (agent_id = @Branch_id) AND (IndentType = @IndentType) AND (indent_date BETWEEN @d1 AND @d2)");
                            cmd.Parameters.Add("@Branch_id", o.BranchID);
                            cmd.Parameters.Add("@IndentType", IndentType);
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdat));
                            DataTable dt_offerIndent = vdm.SelectQuery(cmd).Tables[0];

                            //long IndentNo = 0;
                            if (dt_offerIndent.Rows.Count == 0)
                            {
                                string soid = context.Session["BranchSno"].ToString();

                                if (soid == "527" || soid == "4607")
                                {
                                    soid = "174";
                                }
                                //cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from,offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.offer_from >= @d1) OR (offers_assignment.status = 1) AND (offers_assignment.offer_to <= @d1)");
                                //cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                                //DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                                cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.salesoffice_id=@bsno) AND (offers_assignment.offer_from <= @d1) AND (offers_assignment.offer_to >= @d1) GROUP BY offers_sub.offer_product_id");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                                cmd.Parameters.Add("@bsno", soid);
                                DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                                DataView view = new DataView(dtoffers);
                                DataTable distincttable = view.ToTable(true, "idoffers_assignment", "offers_assignment_name");

                                string idoffers_assignment = "0";
                                long offer_indent_no = 0;
                                if (dtoffers.Rows.Count > 0)
                                {

                                    idoffers_assignment = distincttable.Rows[0]["idoffers_assignment"].ToString();

                                    cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                                    cmd.Parameters.Add("@Branch_id", o.BranchID);
                                    cmd.Parameters.Add("@IndentType", IndentType);
                                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdat));
                                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdat));
                                    DataTable dtRegularIndentsNo = vdm.SelectQuery(cmd).Tables[0];
                                    if (dtRegularIndentsNo.Rows.Count > 0)
                                    {
                                        string IndentNo = dtRegularIndentsNo.Rows[0]["IndentNo"].ToString();

                                        cmd = new MySqlCommand("INSERT INTO offer_indents (idoffers_assignment, salesoffice_id, agent_id, indent_date, indents_id,IndentType) VALUES (@idoffers_assignment, @salesoffice_id, @agent_id, @indent_date, @indents_id,@IndentType)");
                                        cmd.Parameters.Add("@idoffers_assignment", idoffers_assignment);
                                        cmd.Parameters.Add("@salesoffice_id", soid);
                                        cmd.Parameters.Add("@agent_id", o.BranchID);
                                        cmd.Parameters.Add("@indent_date", ServerDateCurrentdat);
                                        cmd.Parameters.Add("@indents_id", IndentNo);
                                        cmd.Parameters.Add("@IndentType", IndentType);
                                        long offerindentno = vdm.insertScalar(cmd);
                                        offer_indent_no = offerindentno;

                                        double unitQty = 0;
                                        double.TryParse(o.Unitsqty, out unitQty);
                                        unitQty = Math.Round(unitQty, 2);
                                        double UnitCost = 0;
                                        double.TryParse(o.UnitCost, out UnitCost);
                                        UnitCost = Math.Round(UnitCost, 2);
                                        cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                        cmd.Parameters.Add("idoffer_indents", offer_indent_no);
                                        cmd.Parameters.Add("product_id", o.Productsno);
                                        //cmd.Parameters.Add("unit_price", UnitCost);
                                        cmd.Parameters.Add("unit_price", UnitCost);
                                        cmd.Parameters.Add("offer_indent_qty", unitQty);
                                        cmd.Parameters.Add("offer_delivered_qty", "0");
                                        if (unitQty != 0.0)
                                        {
                                            vdm.insert(cmd);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                string IndentNo = dt_offerIndent.Rows[0]["idoffer_indents"].ToString();
                                double unitQty = 0;
                                double.TryParse(o.Unitsqty, out unitQty);
                                unitQty = Math.Round(unitQty, 2);
                                cmd = new MySqlCommand("UPDATE offer_indents_sub SET offer_indent_qty = @offer_indent_qty WHERE (idoffer_indents = @idoffer_indents) AND (product_id = @product_id)");
                                cmd.Parameters.Add("@offer_indent_qty", unitQty);
                                cmd.Parameters.Add("@idoffer_indents", IndentNo);
                                cmd.Parameters.Add("@product_id", o.Productsno);
                                if (vdm.Update(cmd) == 0)
                                {
                                    double UnitCost = 0;
                                    double.TryParse(o.UnitCost, out UnitCost);
                                    UnitCost = Math.Round(UnitCost, 2);

                                    cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                    cmd.Parameters.Add("idoffer_indents", IndentNo);
                                    cmd.Parameters.Add("product_id", o.Productsno);
                                    //cmd.Parameters.Add("unit_price", UnitCost);
                                    cmd.Parameters.Add("unit_price", UnitCost);
                                    cmd.Parameters.Add("offer_indent_qty", unitQty);
                                    cmd.Parameters.Add("offer_delivered_qty", "0");
                                    if (unitQty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                }

                            }
                        }


                    }
                    #endregion

                    ErrMsg = "Agent_signature";

                    #region Agent_signature

                    ////foreach (branchsignature o in obj.Signaturedetail)
                    ////{
                    ////    cmd = new MySqlCommand("update agent_trip_signs set sign=@sign where tripid=@tripid and branchid=@branchid");
                    ////    cmd.Parameters.Add("@sign", o.Sign);
                    ////    cmd.Parameters.Add("@tripid", context.Session["TripdataSno"].ToString());
                    ////    cmd.Parameters.Add("@BranchId", o.BrancID);
                    ////    if (vdm.Update(cmd) == 0)
                    ////    {
                    ////        cmd = new MySqlCommand("Insert into agent_trip_signs (tripid,branchid,sign) values(@tripid,@branchid,@sign)");
                    ////        cmd.Parameters.Add("@tripid", context.Session["TripdataSno"].ToString());
                    ////        cmd.Parameters.Add("@branchid", o.BrancID);
                    ////        cmd.Parameters.Add("@sign", o.Sign);
                    ////        vdm.insert(cmd);
                    ////    }
                    ////}

                    #endregion
                    ErrMsg = "Final Report";

                    #region Final Report

                    if (context.Session["indent_syncData"] == null)
                    {
                    }
                    else
                    {
                        List<orderdetail> Product_list = (List<orderdetail>)context.Session["indent_syncData"];
                        if (Product_list.Count > 1)
                        {
                            string socode = context.Session["BranchSno"].ToString();
                            string soid = context.Session["BranchSno"].ToString();
                            string Remarks = context.Session["Remarks"].ToString();
                            string Denominations = context.Session["Denominations"].ToString();
                            string CollectAmount = context.Session["colAmount"].ToString();
                            string SubmitAmount = context.Session["SubAmount"].ToString();
                            DateTime ReportDate = VehicleDBMgr.GetTime(vdm.conn);
                            DateTime dtapril = new DateTime();
                            DateTime dtmarch = new DateTime();
                            int currentyear = ReportDate.Year;
                            int nextyear = ReportDate.Year + 1;
                            if (ReportDate.Month > 3)
                            {
                                string apr = "4/1/" + currentyear;
                                dtapril = DateTime.Parse(apr);
                                string march = "3/31/" + nextyear;
                                dtmarch = DateTime.Parse(march);
                            }
                            if (ReportDate.Month <= 3)
                            {
                                string apr = "4/1/" + (currentyear - 1);
                                dtapril = DateTime.Parse(apr);
                                string march = "3/31/" + (nextyear - 1);
                                dtmarch = DateTime.Parse(march);
                            }
                            //cmd = new MySqlCommand("Update tripdata set Remarks=@Remarks,Status=@Status,Denominations=@Denominations,CollectedAmount=@CollectedAmount,SubmittedAmount=@SubmittedAmount,Cdate=@Cdate where sno=@sno");
                            cmd = new MySqlCommand("Update tripdata set Remarks=@Remarks,Denominations=@Denominations,CollectedAmount=@CollectedAmount,SubmittedAmount=@SubmittedAmount,Cdate=@Cdate where sno=@sno");
                            cmd.Parameters.Add("@Remarks", Remarks);
                            //if (socode == "174" || socode == "527")
                            //{
                            cmd.Parameters.Add("@Status", "A");
                            //}
                            //if (socode != "174" || socode != "527")
                            //{
                            //    cmd.Parameters.Add("@Status", "P");
                            //}
                            float colAmount = 0;
                            float.TryParse(CollectAmount, out colAmount);
                            cmd.Parameters.Add("@CollectedAmount", colAmount);
                            float SubAmount = 0;
                            float.TryParse(SubmitAmount, out SubAmount);
                            cmd.Parameters.Add("@SubmittedAmount", SubAmount);
                            cmd.Parameters.Add("@Cdate", ReportDate);
                            cmd.Parameters.Add("@Denominations", Denominations);
                            cmd.Parameters.Add("@sno", context.Session["TripdataSno"].ToString());
                            vdm.Update(cmd);

                            cmd = new MySqlCommand("Update empaccounts set Amount=Amount-@Amount where EmpID=@EmpID");
                            cmd.Parameters.Add("@Amount", SubAmount);
                            cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                            vdm.Update(cmd);

                            //if (sendmesg == "false")
                            //{

                            //}
                            string DispatchDate = context.Session["I_Date"].ToString();
                            string DispType = context.Session["DispType"].ToString();
                            if (DispType == "SO")
                            {

                            }
                            else
                            {
                                DateTime dtdispDate = Convert.ToDateTime(DispatchDate);
                                string routeid = "";
                                string routeitype = "";
                                cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                                cmd.Parameters.Add("@dispsno", context.Session["RouteId"].ToString());
                                DataTable dtrouteindenttype = vdm.SelectQuery(cmd).Tables[0];
                                foreach (DataRow drrouteitype in dtrouteindenttype.Rows)
                                {
                                    routeid = drrouteitype["Route_id"].ToString();
                                    routeitype = drrouteitype["IndentType"].ToString();
                                }
                                ////cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName,indents_subtable.IndentNo, indents_subtable.DeliveryQty, productsdata.ProductName, indents_subtable.UnitCost FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutesubtable ON dispatch_sub.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (dispatch.sno = @dispatchSno) GROUP BY productsdata.ProductName, branchdata.BranchName, productsdata.sno, indents_subtable.UnitCost ORDER BY branchdata.sno");
                                //Changed By Ravindra 01/02/2017
                                cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName, indents_subtable.IndentNo, indents_subtable.DeliveryQty, productsdata.ProductName, indents_subtable.UnitCost,productsdata.igst FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM indents WHERE (I_date BETWEEN @starttime AND @endtime)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @starttime) AND (indents_subtable.DeliveryQty > 0)  AND (productsdata.igst = '0') OR  (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate > @starttime) AND (modifiedroutesubtable.CDate <= @starttime) AND  (indents_subtable.DeliveryQty > 0) AND (productsdata.igst = '0')  GROUP BY productsdata.ProductName, branchdata.BranchName, productsdata.sno, indents_subtable.UnitCost");
                                cmd.Parameters.Add("@TripID", routeid);
                                cmd.Parameters.Add("@itype", routeitype);
                                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtdispDate));
                                //cmd.Parameters.Add("@igst", "0");
                                DataTable dtSMS = vdm.SelectQuery(cmd).Tables[0];
                                DataView view = new DataView(dtSMS);
                                DataTable distincttable = view.ToTable(true, "BranchName", "sno", "IndentNo", "ProductName", "igst");
                                string companycode = "";
                                string gststatecode = "";
                                cmd = new MySqlCommand("SELECT statemastar.gststatecode, branchdata.companycode FROM branchdata INNER JOIN statemastar ON branchdata.stateid = statemastar.sno WHERE (branchdata.sno = @BranchID)");
                                cmd.Parameters.Add("@BranchID", socode);
                                DataTable dt_GSTNo = vdm.SelectQuery(cmd).Tables[0];
                                if (dt_GSTNo.Rows.Count > 0)
                                {
                                    companycode = dt_GSTNo.Rows[0]["companycode"].ToString();
                                    gststatecode = dt_GSTNo.Rows[0]["gststatecode"].ToString();
                                }
                                foreach (DataRow branch in distincttable.Rows)
                                {
                                    cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.phonenumber, invmaster.InvName, inventory_monitor.Qty FROM branchdata INNER JOIN inventory_monitor ON branchdata.sno = inventory_monitor.BranchId INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (branchdata.sno = @sno)  ");
                                    cmd.Parameters.Add("@sno", branch["sno"].ToString());
                                    DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                                    if (dtBranchName.Rows.Count > 0)
                                    {
                                        string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                                        string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();
                                        cmd = new MySqlCommand("update Agentdc set IndDate=@IndDate where BranchId=@BranchId and IndDate=@IDate");
                                        cmd.Parameters.Add("@BranchId", branch["sno"].ToString());
                                        cmd.Parameters.Add("@IndDate", dtdispDate);
                                        cmd.Parameters.Add("@IDate", dtdispDate);
                                        long DcNo = 0;
                                        int moduleid = 1;
                                        //DataRow[] drcheckbranchid = nontaxdummytable.Select("BranchID=" + branch["sno"].ToString() + "");
                                        //if (drcheckbranchid.Length > 0)
                                        //{
                                        if (vdm.Update(cmd) == 0)
                                        {
                                            cmd = new MySqlCommand("SELECT agentdcno FROM  agentdc WHERE (BranchId = @BranchId) AND (IndDate BETWEEN @d1 AND @d2)");
                                            cmd.Parameters.Add("@BranchId", branch["sno"].ToString());
                                            cmd.Parameters.Add("@d1", GetLowDate(dtdispDate));
                                            cmd.Parameters.Add("@d2", GetHighDate(dtdispDate));
                                            DataTable dtDcnumber = vdm.SelectQuery(cmd).Tables[0];
                                            string agentdcNo = "";
                                            if (dtDcnumber.Rows.Count > 0)
                                            {
                                                agentdcNo = dtDcnumber.Rows[0]["agentdcno"].ToString();
                                            }
                                            else
                                            {

                                                //cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (soid = @BranchID)");
                                                //Ravi State Wsie  GST Numbers Unique 
                                                //cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (soid = @BranchID) AND (IndDate BETWEEN @d1 AND @d2)");
                                                //cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (stateid = @stateid) and (Companycode = @Companycode)  AND (IndDate BETWEEN @d1 AND @d2)");
                                                cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (soid = @BranchID) AND (IndDate BETWEEN @d1 AND @d2)");
                                                if (soid == "527" || soid == "2948" || soid == "282")
                                                {
                                                    //Hardcore this are the subbranches of sales offices.so for GST invoice purpose we need to maintain below processs
                                                    if (soid == "2948")
                                                    {
                                                        cmd.Parameters.Add("@BranchID", "285");
                                                        socode = "285";
                                                        //soid = "285";
                                                        cmd.Parameters.Add("@d1", GetLowDate(dtapril.AddDays(-1)));
                                                        cmd.Parameters.Add("@d2", GetHighDate(dtmarch.AddDays(-1)));
                                                    }
                                                    if (soid == "527")
                                                    {
                                                        cmd.Parameters.Add("@BranchID", "174");
                                                        socode = "174";
                                                        //soid = "174";
                                                        cmd.Parameters.Add("@d1", GetLowDate(dtapril.AddDays(-1)));
                                                        cmd.Parameters.Add("@d2", GetHighDate(dtmarch.AddDays(-1)));
                                                    }
                                                    if (soid == "282")
                                                    {
                                                        cmd.Parameters.Add("@BranchID", "172");
                                                        socode = "172";
                                                        //soid = "172";
                                                        cmd.Parameters.Add("@d1", GetLowDate(dtapril));
                                                        cmd.Parameters.Add("@d2", GetHighDate(dtmarch));
                                                    }
                                                }
                                                else
                                                {
                                                    cmd.Parameters.Add("@BranchID", socode);
                                                    cmd.Parameters.Add("@d1", GetLowDate(dtapril.AddDays(-1)));
                                                    cmd.Parameters.Add("@d2", GetHighDate(dtmarch.AddDays(-1)));
                                                }
                                                //cmd.Parameters.Add("@d1", GetLowDate(dtapril.AddDays(-1)));
                                                //cmd.Parameters.Add("@d2", GetHighDate(dtmarch.AddDays(-1)));
                                                DataTable dtadcno = vdm.SelectQuery(cmd).Tables[0];
                                                agentdcNo = dtadcno.Rows[0]["Sno"].ToString();
                                                string igst = branch["igst"].ToString();
                                                if (igst == "0")
                                                {
                                                    cmd = new MySqlCommand("Insert Into Agentdc (BranchId,IndDate,soid,agentdcno,stateid,Companycode,moduleid,doe,invoicetype,indentno) Values(@BranchId,@IndDate,@soid,@agentdcno,@stateid,@Companycode,@moduleid,@doe,@invoicetype,@indentno)");
                                                    cmd.Parameters.Add("@BranchId", branch["sno"].ToString());
                                                    cmd.Parameters.Add("@IndDate", dtdispDate);
                                                    cmd.Parameters.Add("@soid", socode);
                                                    cmd.Parameters.Add("@agentdcno", agentdcNo);
                                                    cmd.Parameters.Add("@stateid", gststatecode);
                                                    cmd.Parameters.Add("@Companycode", companycode);
                                                    cmd.Parameters.Add("@moduleid", moduleid);
                                                    cmd.Parameters.Add("@doe", ReportDate);
                                                    cmd.Parameters.Add("@invoicetype", "OffLine");
                                                    cmd.Parameters.Add("@indentno", branch["IndentNo"].ToString());
                                                    DcNo = vdm.insertScalar(cmd);
                                                    cmd = new MySqlCommand("Insert Into dcsubTable (DcNo,IndentNo) Values(@DcNo,@IndentNo)");
                                                    cmd.Parameters.Add("@DcNo", DcNo);
                                                    cmd.Parameters.Add("@IndentNo", branch["IndentNo"].ToString());
                                                    vdm.insert(cmd);
                                                }
                                                else
                                                {
                                                }
                                            }
                                        }
                                        else
                                        {
                                            cmd = new MySqlCommand("Select DcNo from Agentdc where BranchId=@BranchId and IndDate=@IDate");
                                            cmd.Parameters.Add("@BranchId", branch["sno"].ToString());
                                            cmd.Parameters.Add("@IDate", dtdispDate);
                                            DataTable dtAgentDc = vdm.SelectQuery(cmd).Tables[0];
                                            if (dtAgentDc.Rows.Count > 0)
                                            {
                                                long.TryParse(dtAgentDc.Rows[0]["DcNo"].ToString(), out DcNo);
                                            }
                                        }
                                        //}
                                    }
                                }
                                //sendmesg = "True";
                            }
                        }
                    }
                    #endregion Final Report
                    sync_end_msg = "Success";
                }
                catch (Exception ex)
                {
                    //int linenum = 0;
                    sync_end_msg = "Fail";
                    string toAddress = "ravindra1507@gmail.com";
                    string subject = "Vyshnavi Offline";
                    string body = "";
                    //linenum = Convert.ToInt32(ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')));
                    if (context.Session["TripdataSno"] == null)
                    {
                        // body = ex.ToString() + "ErrMsg" + ErrMsg + linenum;
                        body = ex.ToString() + "ErrMsg" + ErrMsg;
                    }
                    else
                    {
                        //body = context.Session["TripdataSno"].ToString() + ex.ToString() + "ErrMsg" + ErrMsg + linenum;
                        body = context.Session["TripdataSno"].ToString() + ex.ToString() + "ErrMsg" + ErrMsg;
                    }
                    SendEmail(toAddress, subject, body);
                }

                string msg = obj.end;// "Success";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "Deliver");
                vdm.insert(cmd);
                string msg = "fail";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void FinalSyncClick(HttpContext context)
        {
            try
            {
                var js = new JavaScriptSerializer();
                var title1 = context.Request.Params[1];
                Orders obj = js.Deserialize<Orders>(title1);
                vdm = new VehicleDBMgr();
                DateTime dtDel = VehicleDBMgr.GetTime(vdm.conn);
                orderdetail o = obj.order_detail;
                //  List<orderdetail> Product_list = new List<orderdetail>();
                List<orderdetail> Product_list = (List<orderdetail>)context.Session["indent_syncData"];
                Product_list.Add(o);
                context.Session["indent_syncData"] = Product_list;

                Inventorydetail inv = obj.Inventory_detail;
                List<Inventorydetail> Inventorydet_list = (List<Inventorydetail>)context.Session["inventory_syncData"];
                Inventorydet_list.Add(inv);
                context.Session["inventory_syncData"] = Inventorydet_list;


                Amountdetail amt = obj.Amount_detail;
                List<Amountdetail> Amount_list = (List<Amountdetail>)context.Session["Amount_syncData"];
                Amount_list.Add(amt);
                context.Session["Amount_syncData"] = Amount_list;

                CInventorydetail CInv = obj.CInventory_detail;
                List<CInventorydetail> CInventory_list = (List<CInventorydetail>)context.Session["Collection_inventory_syncData"];
                CInventory_list.Add(CInv);
                context.Session["Collection_inventory_syncData"] = CInventory_list;

                double saleqty = 0;
                double.TryParse(o.ReturnQty, out saleqty);
                totsaleqty += saleqty;
                string msg = obj.end;// "Success";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "Deliver");
                vdm.insert(cmd);
                string msg = "fail";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void InventorySaveClick(HttpContext context, Orders obj)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                Inventorydetail o = obj.Inventory_detail;
                List<Inventorydetail> Inventorydet_list = (List<Inventorydetail>)context.Session["inventory_syncData"];
                Inventorydet_list.Add(o);
                context.Session["inventory_syncData"] = Inventorydet_list;
                string msg = obj.end;
                string response = GetJson(msg);
                context.Response.Write(response);
                //cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                //cmd.Parameters.Add("@Qty", o.GivenQty);
                //cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                //cmd.Parameters.Add("@BranchId", o.BrancID);
                //if (vdm.Update(cmd) == 0)
                //{
                //    cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                //    cmd.Parameters.Add("@Qty", o.GivenQty);
                //    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                //    cmd.Parameters.Add("@BranchId", o.BrancID);
                //    vdm.insert(cmd);
                //}
                //cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                //cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                //cmd.Parameters.Add("@Qty", o.GivenQty);
                //cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                //cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                //cmd.Parameters.Add("@TransType", "2");
                //cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                //cmd.Parameters.Add("@To", o.BrancID);
                //if (vdm.Update(cmd) == 0)
                //{
                //    cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                //    cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                //    cmd.Parameters.Add("@Qty", o.GivenQty);
                //    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                //    cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                //    cmd.Parameters.Add("@TransType", "2");
                //    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                //    cmd.Parameters.Add("@To", o.BrancID);
                //    vdm.insert(cmd);
                //}
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "DeliverInv");
                vdm.insert(cmd);
                string msg = "fail";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void IndentReportSaveclick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                if (context.Session["BranchSno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string phonenumber = context.Request["MobNo"];
                    if (phonenumber.Length == 10)
                    {
                        cmd = new MySqlCommand("select BranchName from Branchdata where Sno=@BranchID ");
                        cmd.Parameters.Add("@BranchID", context.Session["BranchSno"].ToString());
                        DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                        string BranchName = dtBranch.Rows[0]["BranchName"].ToString();
                        string Date = DateTime.Now.ToString("dd/MM/yyyy");
                        WebClient client = new WebClient();

                       string BranchSno = context.Session["BranchSno"].ToString();
                       if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                       {

                           //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                           string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20,%20 + Indent%20Completed%20Successfully%20" + Date + "&sender=VYSNVI&type=1&route=2";
                           
                           //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20,%20 + Indent%20Completed%20Successfully%20" + Date + "&type=1";
                           Stream data = client.OpenRead(baseurl);
                           StreamReader reader = new StreamReader(data);
                           string ResponseID = reader.ReadToEnd();
                           data.Close();
                           reader.Close();
                       }
                       else
                       {
                           string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20,%20 + Indent%20Completed%20Successfully%20" + Date + "&sender=VYSNVI&type=1&route=2";
                           //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20,%20 + Indent%20Completed%20Successfully%20" + Date + "&type=1";
                           Stream data = client.OpenRead(baseurl);
                           StreamReader reader = new StreamReader(data);
                           string ResponseID = reader.ReadToEnd();
                           data.Close();
                           reader.Close();
                       }

                        string message = "Dear " + BranchName + "  ,  + Indent  Completed  Successfully  " + Date + "";
                        // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                        cmd = new MySqlCommand("insert into smsinfo (agentid,branchid,msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                        cmd.Parameters.Add("@agentid", context.Session["BranchSno"].ToString());
                        cmd.Parameters.Add("@branchid", context.Session["BranchSno"].ToString());
                        cmd.Parameters.Add("@msg", message);
                        cmd.Parameters.Add("@mobileno", phonenumber);
                        cmd.Parameters.Add("@msgtype", "IndentReport");
                        cmd.Parameters.Add("@branchname", BranchName);
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                        string errmsg = "Message Sent Successfully";
                        string errresponse = GetJson(errmsg);
                        context.Response.Write(errresponse);
                    }
                    else
                    {
                        string errmsg = "Please Engter 10 Digit Number";
                        string errresponse = GetJson(errmsg);
                        context.Response.Write(errresponse);
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = ex.ToString();
                string errresponse = GetJson(errmsg);
                context.Response.Write(errresponse);
            }
        }
        private void GetOffLineInventoryData(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT dispatch_sub.Route_id, branchdata.BranchName, branchroutesubtable.BranchID, invmaster.InvName, inventory_monitor.Inv_Sno, inventory_monitor.Qty FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN inventory_monitor ON branchdata.sno = inventory_monitor.BranchId INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (dispatch.sno = @dispatchSno) GROUP BY branchdata.BranchName, invmaster.InvName");
                cmd.Parameters.Add("@dispatchSno", context.Session["RouteId"].ToString());
                DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];
                List<offInventory> InventoryList = new List<offInventory>();
                
                    if (dtInventory.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtInventory.Rows)
                        {
                            offInventory getInventory = new offInventory();
                            getInventory.BranchID = dr["BranchID"].ToString();
                            getInventory.BranchName = dr["BranchName"].ToString();
                            getInventory.InvName = dr["InvName"].ToString();
                            getInventory.Inv_Sno = dr["Inv_Sno"].ToString();
                            getInventory.Qty = dr["Qty"].ToString();
                            InventoryList.Add(getInventory);
                        }
                    }
                
                string errresponse = GetJson(InventoryList);
                context.Response.Write(errresponse);
            }
            catch
            {
            }
        }
        private void GetOfferProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string i_date=context.Session["I_Date"].ToString();
                DateTime Currentdate=new DateTime();
                Currentdate=DateTime.Parse(i_date);
                string branchid = context.Session["BranchSno"].ToString();
                if (branchid == "527" || branchid == "4607")
                {
                    branchid = "174";
                }
                //cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.salesoffice_id=@bsno) AND (offers_assignment.offer_from <= @d1) AND (offers_assignment.offer_to >= @d1) GROUP BY offers_sub.offer_product_id");
                cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from,offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price, productsdata.ProductName FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers INNER JOIN productsdata ON offers_sub.offer_product_id = productsdata.sno WHERE (offers_assignment.status = 1) AND (offers_assignment.salesoffice_id = @bsno) AND (offers_assignment.offer_from <= @d1) AND (offers_assignment.offer_to >= @d1) GROUP BY offers_sub.offer_product_id");
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                cmd.Parameters.Add("@bsno", branchid);
                
                DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                List<Offerproducts> OfferproductList = new List<Offerproducts>();
                
                    if (dtoffers.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtoffers.Rows)
                        {
                            Offerproducts getofferprdts = new Offerproducts();
                            getofferprdts.idoffers_assignment = dr["idoffers_assignment"].ToString();
                            getofferprdts.productid = dr["offer_product_id"].ToString();
                            getofferprdts.productname = dr["ProductName"].ToString();
                            getofferprdts.branchid = branchid;

                            OfferproductList.Add(getofferprdts);
                        }
                    }

                    string errresponse = GetJson(OfferproductList);
                context.Response.Write(errresponse);
            }
            catch
            {

            }
        }
        private void GetOfferIndent(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string DispDate = context.Session["I_Date"].ToString();
                DateTime dtdispDate = Convert.ToDateTime(DispDate);
                List<IndentClass> IndentsList = new List<IndentClass>();
                string branchid = context.Session["BranchSno"].ToString();
                if (branchid == "527" || branchid == "4607")
                {
                    branchid = "174";
                }
                //cmd = new MySqlCommand("SELECT dispatch_sub.Route_id, branchroutesubtable.BranchID, branchdata.BranchName, offerindents.idoffer_indents, offer_indents_sub.product_id, offer_indents_sub.offer_indent_qty,offer_indents_sub.offer_delivered_qty, offer_indents_sub.unit_price, offerindents.indent_date,offerindents.IndentType, productsdata.ProductName FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutesubtable ON dispatch_sub.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType, I_modified_by FROM offer_indents WHERE (indent_date BETWEEN @starttime AND @endtime) AND (IndentType = @IndentType)) offerindents ON branchdata.sno = offerindents.agent_id INNER JOIN offer_indents_sub ON offerindents.idoffer_indents = offer_indents_sub.idoffer_indents INNER JOIN productsdata ON offer_indents_sub.product_id = productsdata.sno WHERE (dispatch.sno = @dispatchSno) GROUP BY branchdata.sno, productsdata.ProductName");
                cmd = new MySqlCommand("SELECT dispatch_sub.Route_id, branchroutesubtable.BranchID, branchdata.BranchName, offerindents.idoffer_indents, offer_indents_sub.product_id,offer_indents_sub.offer_indent_qty, offer_indents_sub.offer_delivered_qty, offer_indents_sub.unit_price, offerindents.indent_date, offerindents.IndentType, productsdata.ProductName FROM offer_indents_sub INNER JOIN (SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType, I_modified_by FROM offer_indents WHERE (indent_date BETWEEN @starttime AND @endtime) AND (IndentType = @IndentType)) offerindents ON offer_indents_sub.idoffer_indents = offerindents.idoffer_indents INNER JOIN productsdata ON offer_indents_sub.product_id = productsdata.sno RIGHT OUTER JOIN dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutesubtable ON dispatch_sub.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno ON offerindents.agent_id = branchdata.sno WHERE (dispatch.sno = @dispatchSno) GROUP BY branchdata.sno, productsdata.ProductName");
                cmd.Parameters.Add("@dispatchSno", context.Session["RouteId"].ToString());
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtdispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtdispDate));
                cmd.Parameters.Add("@IndentType", context.Session["IndentType"].ToString());
                DataTable dtIndentble = vdm.SelectQuery(cmd).Tables[0];

                cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price, productsdata.ProductName, brnchprdt.unitprice FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers INNER JOIN productsdata ON offers_sub.offer_product_id = productsdata.sno INNER JOIN (SELECT branch_sno, product_sno, unitprice, flag, userdata_sno, DTarget, WTarget, MTarget, BranchQty, LeakQty, Rank, VatPercent FROM branchproducts WHERE (branch_sno = @bsno)) brnchprdt ON productsdata.sno = brnchprdt.product_sno WHERE (offers_assignment.status = 1) AND (offers_assignment.salesoffice_id = @bsno) AND (offers_assignment.offer_from <= @d1) AND (offers_assignment.offer_to >= @d1) GROUP BY offers_sub.offer_product_id"); 
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                cmd.Parameters.Add("@bsno", branchid);
                DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];

                DataView view = new DataView(dtIndentble);
                DataTable branches = view.ToTable(true, "BranchID", "BranchName");

                DataTable dttotalprdts = new DataTable();
                dttotalprdts.Columns.Add("BranchName");
                dttotalprdts.Columns.Add("BranchID");
                dttotalprdts.Columns.Add("IndentType");
                dttotalprdts.Columns.Add("indent_date");
                dttotalprdts.Columns.Add("idoffer_indents");
                dttotalprdts.Columns.Add("product_id");
                dttotalprdts.Columns.Add("ProductName");
                dttotalprdts.Columns.Add("unit_price");
                dttotalprdts.Columns.Add("offer_indent_qty");
                dttotalprdts.Columns.Add("offer_delivered_qty");

                foreach (DataRow drbrnchs in branches.Rows)
                {
                    foreach (DataRow droffers in dtoffers.Rows)
                    {
                        DataRow newrow = dttotalprdts.NewRow();
                        newrow["BranchID"] = drbrnchs["BranchID"].ToString();
                        newrow["BranchName"] = drbrnchs["BranchName"].ToString();
                        newrow["IndentType"] = context.Session["IndentType"].ToString();
                        newrow["indent_date"] = DateConverter.GetLowDate(dtdispDate);
                        string idofferindents = "0";
                        string offerdeliveryqty = "0";
                        string offerindentqty = "0";
                        foreach (DataRow dtindents in dtIndentble.Select("product_id='" + droffers["offer_product_id"].ToString() + "' AND BranchID='" + drbrnchs["BranchID"].ToString() + "'"))
                        {
                            idofferindents = dtindents["idoffer_indents"].ToString();
                            offerdeliveryqty = dtindents["offer_delivered_qty"].ToString();
                            offerindentqty = dtindents["offer_indent_qty"].ToString();
                        }
                        newrow["idoffer_indents"] = idofferindents;
                        newrow["product_id"] = droffers["offer_product_id"].ToString();
                        newrow["ProductName"] = droffers["ProductName"].ToString();
                        newrow["unit_price"] = droffers["unitprice"].ToString();
                        newrow["offer_indent_qty"] = offerindentqty;
                        newrow["offer_delivered_qty"] = offerdeliveryqty;
                        dttotalprdts.Rows.Add(newrow);
                    }
                }

                if (dttotalprdts.Rows.Count > 0)
                {
                    foreach (DataRow dr in dttotalprdts.Rows)
                    {
                        IndentClass GetIndent = new IndentClass();
                        GetIndent.BranchName = dr["BranchName"].ToString();
                        GetIndent.IndentNo = dr["idoffer_indents"].ToString();
                        GetIndent.ProductId = dr["product_id"].ToString();
                        GetIndent.UnitQty = dr["offer_indent_qty"].ToString();
                        GetIndent.DeliverQty = dr["offer_delivered_qty"].ToString();

                        GetIndent.UnitCost = dr["unit_price"].ToString();
                        GetIndent.IDate = dr["indent_date"].ToString();
                        GetIndent.ProductName = dr["ProductName"].ToString();
                        GetIndent.BrancID = dr["BranchID"].ToString();
                        GetIndent.IndentType = dr["IndentType"].ToString();
                        IndentsList.Add(GetIndent);
                    }
                    string errresponse = GetJson(IndentsList);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {

            }
        }
        public class offInventory
        {
            public string BranchID = "";
            public string BranchName = "";
            public string InvName = "";
            public string Inv_Sno = "";
            public string Qty = "";
            public string TodayQty = "";
        }
        public class Offerproducts
        {
            public string productid = "";
            public string productname = "";
            public string idoffers_assignment = "";
            public string branchid = "";
        }
        private void GetOffLineIndentData(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string DispDate = context.Session["I_Date"].ToString();
                DateTime dtdispDate = Convert.ToDateTime(DispDate);
                List<IndentClass> IndentsList = new List<IndentClass>();
                string routeid = "";
                string routeitype = "";
                cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                cmd.Parameters.Add("@dispsno", context.Session["RouteId"].ToString());
                DataTable dtrouteindenttype = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow drrouteitype in dtrouteindenttype.Rows)
                {
                    routeid = drrouteitype["Route_id"].ToString();
                    routeitype = drrouteitype["IndentType"].ToString();
                }
                ////cmd = new MySqlCommand("SELECT dispatch_sub.Route_id, branchdata.BranchName, indents_subtable.IndentNo, indents_subtable.Product_sno, indents_subtable.unitQty, indents_subtable.UnitCost, indents.I_date, productsdata.ProductName, indents_subtable.Status, indents_subtable.DeliveryQty, indents_subtable.LeakQty, indents_subtable.DTripId, indents.IndentType, branchroutesubtable.BranchID, indents_subtable.D_date FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON productsdata.sno = indents_subtable.Product_sno WHERE (dispatch.sno = @dispatchSno) AND (indents.I_date BETWEEN @starttime AND @endtime) AND (indents.IndentType = @IndentType) AND (branchdata.flag = 1) GROUP BY productsdata.ProductName, branchdata.BranchName");
                //Changed By Ravindra 01/02/2017
                cmd = new MySqlCommand("SELECT branchdata.BranchName, indents_subtable.IndentNo, indents_subtable.Product_sno, indents_subtable.unitQty, indents_subtable.UnitCost, indent.I_date, productsdata.ProductName, indents_subtable.Status, indents_subtable.DeliveryQty, indents_subtable.LeakQty, indents_subtable.DTripId, indent.IndentType, modifiedroutesubtable.BranchID, indents_subtable.D_date, modifiedroutes.Sno AS Route_id FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM indents WHERE (I_date BETWEEN @starttime AND @endtime)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @starttime) OR (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate > @starttime) AND (modifiedroutesubtable.CDate <= @starttime) GROUP BY productsdata.ProductName, branchdata.BranchName");
                cmd.Parameters.Add("@TripID", routeid);
                cmd.Parameters.Add("@itype", routeitype);
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtdispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtdispDate));
                DataTable dtIndentble = vdm.SelectQuery(cmd).Tables[0];
                if (dtIndentble.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtIndentble.Rows)
                    {
                        IndentClass GetIndent = new IndentClass();
                        GetIndent.UserID = context.Session["UserSno"].ToString();
                        GetIndent.BranchName = dr["BranchName"].ToString();
                        GetIndent.IndentNo = dr["IndentNo"].ToString();
                        GetIndent.ProductId = dr["Product_sno"].ToString();
                        GetIndent.UnitQty = dr["unitQty"].ToString();
                        GetIndent.UnitCost = dr["UnitCost"].ToString();
                        GetIndent.IDate = dr["I_date"].ToString();
                        GetIndent.ProductName = dr["ProductName"].ToString();
                        //GetIndent.Categoryname = dr["Categoryname"].ToString();
                        GetIndent.Categoryname = "";
                        GetIndent.Status = dr["Status"].ToString();
                        GetIndent.DeliverQty = dr["DeliveryQty"].ToString();
                        GetIndent.LeakQty = dr["LeakQty"].ToString();
                        GetIndent.DtripID = dr["DTripId"].ToString();
                        GetIndent.Ddate = dr["D_date"].ToString();
                        GetIndent.BrancID = dr["BranchID"].ToString();
                        GetIndent.IndentType = dr["IndentType"].ToString();
                        //GetIndent.Rank = dr["Rank"].ToString();
                        IndentsList.Add(GetIndent);
                    }
                    string errresponse = GetJson(IndentsList);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        public class IndentClass
        {
            public string UserID = "";
            public string BranchName = "";
            public string BrancID = "";
            public string IndentType = "";
            public string ProductId = "";
            public string ProductName = "";
            public string Categoryname = "";
            public string UnitQty = "";
            public string UnitCost = "";
            public string DeliverQty = "";
            public string Status = "";
            public string DtripID = "";
            public string IDate = "";
            public string Ddate = "";
            public string LeakQty = "";
            public string IndentNo = "";
            public string Rank = "";
        }
        private void GetOfflineCategeory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT sno, Categoryname FROM products_category");
                DataTable dtcategory = vdm.SelectQuery(cmd).Tables[0];
                List<Categoryclass> categoryList = new List<Categoryclass>();
                foreach (DataRow dr in dtcategory.Rows)
                {
                    Categoryclass getCatgeory = new Categoryclass();
                    getCatgeory.sno = dr["sno"].ToString();
                    getCatgeory.categoryname = dr["Categoryname"].ToString();
                    categoryList.Add(getCatgeory);
                }
                string errresponse = GetJson(categoryList);
                context.Response.Write(errresponse);
            }
            catch
            {
            }
        }
        private void GetofflineSubCategory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT sno, category_sno, SubCatName FROM products_subcategory");
                DataTable dtSubcategory = vdm.SelectQuery(cmd).Tables[0];
                List<subCategoryclass> subcategoryList = new List<subCategoryclass>();
                foreach (DataRow dr in dtSubcategory.Rows)
                {
                    subCategoryclass getsubCatgeory = new subCategoryclass();
                    getsubCatgeory.sno = dr["sno"].ToString();
                    getsubCatgeory.CatSno = dr["category_sno"].ToString();
                    getsubCatgeory.subcategorynames = dr["SubCatName"].ToString();
                    subcategoryList.Add(getsubCatgeory);
                }
                string errresponse = GetJson(subcategoryList);
                context.Response.Write(errresponse);
            }
            catch
            {
            }
        }
        private void getProductsData(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT sno, ProductName, UnitPrice, Rank, Units, SubCat_sno FROM productsdata");
                DataTable dtProd = vdm.SelectQuery(cmd).Tables[0];
                List<OFFProducts> ProductsList = new List<OFFProducts>();
                foreach (DataRow dr in dtProd.Rows)
                {
                    OFFProducts getProducts = new OFFProducts();
                    getProducts.sno = dr["sno"].ToString();
                    getProducts.ProductName = dr["ProductName"].ToString();
                    getProducts.UnitPrice = dr["UnitPrice"].ToString();
                    getProducts.Rank = dr["Rank"].ToString();
                    getProducts.Units = dr["Units"].ToString();
                    getProducts.SubCatSno = dr["SubCat_sno"].ToString();
                    ProductsList.Add(getProducts);
                }
                string errresponse = GetJson(ProductsList);
                context.Response.Write(errresponse);
            }
            catch
            {
            }
        }
        public class OFFProducts
        {
            public string sno = "";
            public string ProductName = "";
            public string UnitPrice = "";
            public string Rank = "";
            public string Units = "";
            public string SubCatSno = "";
        }

        //private void logout(HttpContext context)
        //{
        //    string msg = "Success";
        //    context.Session.Abandon();
        //    context.Session["UserName"] = null;
        //    context.Session["userdata_sno"] = null;
        //    //Response.Redirect("login.aspx");
        //    string errresponse = GetJson(msg);
        //    context.Response.Write(errresponse);
        //}
        //........................Get Permission for USER......../////////////////
        private void GetPermissions(HttpContext context)
        {
            List<UserPermission> GetList = new List<UserPermission>();
            UserPermission GetPermission = new UserPermission();
            if (context.Session["Permissions"] == null)
            {
                string errmsg = "Session Expired";
                string errresponse = GetJson(errmsg);
                context.Response.Write(errresponse);
            }
            else
            {
                //context.Session["DispatchName"]
                GetPermission.UserName = context.Session["UserName"].ToString();
                GetPermission.DispatchName = context.Session["DispatchName"].ToString();
                GetPermission.Permision = context.Session["Permissions"].ToString();
                GetPermission.Count = context.Session["count"].ToString();
                GetList.Add(GetPermission);
                string errresponse = GetJson(GetList);
                context.Response.Write(errresponse);
            }
        }
        public class UserPermission
        {
            public string UserName { get; set; }
            public string Count { get; set; }
            public string Permision { get; set; }
            public string DispatchName { get; set; }
        }
        //........................Login Details......../////////////////
        public class ValidateResult
        {
            public string PlantEmpId = "";
            public string PlantDispSno = "";
            public string UserName = "";
            public string Password = "";
            public string LevelType = "";
            public string UserData_sno = "";
            public string DispDate = "";
            public string Permissions = "";
            public string CsoNo = "";


            public string Sno = "";
            public string UserSno = "";
            public string AssignDate = "";
            public string I_Date = "";
            public string count = "";
            public string[] routearray { get; set; }
            public string TripdataSno = "";
            public string TripID = "";
            public string Salestype = "";
            public string BranchSno = "";
            public string RouteId = "";

        }

        private void GetOfflineLogin(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string UserName = context.Request["UserName"];
                string tpid = context.Request["TripID"];
                //cmd = new MySqlCommand(" SELECT tripdata.Status, tripdata.AssignDate, tripdata.I_Date,tripdata.ATripId, tripdata.Sno, tripdata.AssignDate AS Expr1, tripdata.Permissions, tripdata.EmpId, empmanage.Sno AS EmpSno, empmanage.UserName,dispatch.DispType, branchdata.sno AS BranchSno, empmanage.Userdata_sno, empmanage.LevelType, empmanage.Branch, salestypemanagement.salestype, triproutes.RouteID, dispatch_sub.IndentType FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (empmanage.UserName = @UN) AND (tripdata.Status = 'A')");
                cmd = new MySqlCommand(" SELECT tripdata.Status, tripdata.AssignDate, tripdata.I_Date,tripdata.ATripId, tripdata.Sno, tripdata.AssignDate AS Expr1, tripdata.Permissions, tripdata.EmpId, empmanage.Sno AS EmpSno, empmanage.UserName,dispatch.DispType, branchdata.sno AS BranchSno, empmanage.Userdata_sno, empmanage.LevelType, empmanage.Branch, salestypemanagement.salestype, triproutes.RouteID, dispatch_sub.IndentType FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE  (tripdata.Sno = @UN) AND (tripdata.Status = 'A')");
                cmd.Parameters.Add("@UN", tpid);
                DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    context.Session["UserName"] = context.Request["UserName"];
                    context.Session["userdata_sno"] = context.Request["UserData_sno"];
                    context.Session["UserSno"] = context.Request["UserSno"];
                    context.Session["LevelType"] = context.Request["LevelType"];
                    context.Session["AssignDate"] = context.Request["AssignDate"];
                    context.Session["I_Date"] = context.Request["I_Date"];
                    context.Session["count"] = context.Request["count"];
                    //context.Session["routearray"] = routearray;
                    context.Session["RouteId"] = context.Request["RouteId"];
                    context.Session["TripdataSno"] = context.Request["TripdataSno"];
                    context.Session["TripID"] = context.Request["TripID"];
                    context.Session["Permissions"] = context.Request["Permissions"];
                    context.Session["Salestype"] = context.Request["Salestype"];
                    context.Session["BranchSno"] = context.Request["BranchSno"];
                    context.Session["IndentType"] = dt.Rows[0]["IndentType"].ToString(); //context.Request[""];
                    context.Session["DispType"] = dt.Rows[0]["DispType"].ToString();
                    context.Session["ATripId"] = dt.Rows[0]["ATripId"].ToString();
                    //context.Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                    string msg = "Success";
                    string errresponse = GetJson(msg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string msg = "Failed";
                    string errresponse = GetJson(msg);
                    context.Response.Write(errresponse);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string errresponse = GetJson(msg);
                context.Response.Write(errresponse);
            }
        }
        private void ValidateLogin(HttpContext context)
        {
            string msg = "Success";
            try
            {
                ValidateResult vresult = new ValidateResult();
                VehicleDBMgr vdm = new VehicleDBMgr();
                String UN = "";
                //lbl_validation.Text = "";
                String UserName = context.Request["UID"].ToString();// txtUserName.Text, 
                String PassWord = context.Request["PWD"].ToString(); //txtPassword.Text;
                cmd = new MySqlCommand("select * from empmanage where UserName=@UN and Password=@Pwd");
                cmd.Parameters.Add("@UN", UserName);
                cmd.Parameters.Add("@Pwd", PassWord);
                DataTable dtemp = vdm.SelectQuery(cmd).Tables[0];
                if (dtemp.Rows.Count > 0)
                {
                    string LevelType = dtemp.Rows[0]["LevelType"].ToString();
                    if (LevelType == "Dispatcher")
                    {
                        //cmd = new MySqlCommand("SELECT branchroutes.BranchID, tripdata.Sno, tripdata.I_Date, dispatch_sub.IndentType FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno WHERE (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId) GROUP BY dispatch.DispName");
                        ////cmd = new MySqlCommand("SELECT branchroutes.BranchID, tripdata.Sno,tripdata.I_Date FROM  tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno WHERE (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId)GROUP BY dispatch.DispName");
                        //cmd.Parameters.Add("@EmpId", dtemp.Rows[0]["Sno"].ToString());
                        //DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                        //if (dt.Rows.Count > 0)
                        //{
                        //    context.Session["UserName"] = "";
                        //    context.Session["userdata_sno"] = "";
                        //    context.Session["UserSno"] = "";
                        //    context.Session["count"] = "";
                        //    context.Session["routearray"] = "";
                        //    context.Session["RouteId"] = "";
                        //    context.Session["TripdataSno"] = "";
                        //    context.Session["TripID"] = "";
                        //    context.Session["Permissions"] = "";
                        //    context.Session["Salestype"] = "";
                        //    context.Session["BranchSno"] = "";
                        //    context.Session["LevelType"] = dtemp.Rows[0]["LevelType"].ToString();
                        //    context.Session["PlantEmpId"] = dtemp.Rows[0]["Sno"].ToString();
                        //    context.Session["PlantDispSno"] = dt.Rows[0]["Sno"].ToString();
                        //    context.Session["DispDate"] = dt.Rows[0]["I_Date"].ToString();
                        //    context.Session["userdata_sno"] = dtemp.Rows[0]["UserData_sno"].ToString();
                        //    context.Session["UserName"] = dtemp.Rows[0]["UserName"].ToString();
                        //    context.Session["Permissions"] = dtemp.Rows[0]["LevelType"].ToString();
                        //    context.Session["CsoNo"] = dt.Rows[0]["BranchID"].ToString();
                        //    context.Session["IndentType"] = dt.Rows[0]["IndentType"].ToString();

                        //    vresult.LevelType = dtemp.Rows[0]["LevelType"].ToString();
                        //    vresult.PlantEmpId = dtemp.Rows[0]["Sno"].ToString();
                        //    vresult.PlantDispSno = dt.Rows[0]["Sno"].ToString();
                        //    vresult.DispDate = dt.Rows[0]["I_Date"].ToString();
                        //    vresult.UserData_sno = dtemp.Rows[0]["UserData_sno"].ToString();
                        //    vresult.UserName = dtemp.Rows[0]["UserName"].ToString();
                        //    vresult.Permissions = dtemp.Rows[0]["LevelType"].ToString();
                        //    vresult.CsoNo = dt.Rows[0]["BranchID"].ToString();
                        //    string response = GetJson(vresult);
                        //    context.Response.Write(response);
                        //}
                        //else
                        //{
                        msg = "Sorry,Please login with Client.Vyshnavi.co.in";
                        string errresponse = GetJson(msg);
                        context.Response.Write(errresponse);
                        //}
                        //Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT tripdata.Status, dispatch.DispName,tripdata.AssignDate, tripdata.I_Date,tripdata.ATripId, tripdata.Sno, tripdata.AssignDate AS Expr1, tripdata.Permissions, tripdata.EmpId, empmanage.Sno AS EmpSno,dispatch.DispType, empmanage.UserName, branchdata.sno AS BranchSno, empmanage.Userdata_sno, empmanage.LevelType, empmanage.Branch, salestypemanagement.salestype, triproutes.RouteID, dispatch_sub.IndentType FROM  tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (tripdata.Status = 'A') AND (empmanage.UserName = @UN) AND (empmanage.Password = @Pwd)");
                        //cmd = new MySqlCommand("SELECT   tripdata.Status, dispatch.DispName, tripdata.AssignDate, tripdata.I_Date, tripdata.ATripid, tripdata.Sno, tripdata.AssignDate AS Expr1, tripdata.Permissions, tripdata.EmpId, empmanage.Sno AS EmpSno,dispatch.DispType, empmanage.UserName, branchdata.sno AS BranchSno, empmanage.Userdata_sno, empmanage.LevelType, empmanage.Branch, salestypemanagement.salestype, triproutes.RouteID FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE  (tripdata.Status = 'A') AND (empmanage.UserName = @UN) AND (empmanage.Password = @Pwd)");
                        cmd.Parameters.Add("@UN", UserName);
                        cmd.Parameters.Add("@Pwd", PassWord);
                        DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                        int i = 1;
                        if (dt.Rows.Count > 0)
                        {
                            string Permissions = dt.Rows[0]["Permissions"].ToString();
                            if (Permissions == "O")
                            {
                                msg = "Sorry,Please Login Online Application Client.vyshnavi.co.in";
                                string errresponse = GetJson(msg);
                                context.Response.Write(errresponse);
                            }
                            else
                            {
                                context.Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                                context.Session["DispatchName"] = dt.Rows[0]["DispName"].ToString();
                                context.Session["userdata_sno"] = dt.Rows[0]["UserData_sno"].ToString();
                                context.Session["UserSno"] = dt.Rows[0]["EmpSno"].ToString();
                                context.Session["LevelType"] = dt.Rows[0]["LevelType"].ToString();
                                context.Session["AssignDate"] = dt.Rows[0]["AssignDate"].ToString();
                                context.Session["I_Date"] = dt.Rows[0]["I_Date"].ToString();
                                int count = 0;
                                string Routes = "";
                                string[] routearray = new String[0] { };
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dt.Rows.Count > 1)
                                    {
                                        string RouteId = dr["RouteId"].ToString();
                                        if (RouteId != "")
                                        {
                                            Routes += dr["RouteId"].ToString() + "@";
                                            count++;
                                        }
                                    }
                                }
                                routearray = Routes.Split('@');
                                context.Session["count"] = count;
                                context.Session["routearray"] = routearray;
                                context.Session["RouteId"] = dt.Rows[0]["RouteId"].ToString();
                                context.Session["TripdataSno"] = dt.Rows[0]["Sno"].ToString();
                                context.Session["TripID"] = dt.Rows[0]["Sno"].ToString();
                                context.Session["Permissions"] = dt.Rows[0]["Permissions"].ToString();
                                context.Session["Salestype"] = dt.Rows[0]["salestype"].ToString();
                                context.Session["BranchSno"] = dt.Rows[0]["BranchSno"].ToString();
                                context.Session["IndentType"] = dt.Rows[0]["IndentType"].ToString();
                                //context.Session["IndentType"] = "Indent1";

                                context.Session["DispType"] = dt.Rows[0]["DispType"].ToString();
                                vresult.UserName = dtemp.Rows[0]["UserName"].ToString();
                                vresult.UserData_sno = dtemp.Rows[0]["UserData_sno"].ToString();
                                vresult.UserSno = dt.Rows[0]["EmpSno"].ToString();
                                vresult.LevelType = dt.Rows[0]["LevelType"].ToString();
                                vresult.Permissions = dt.Rows[0]["Permissions"].ToString();
                                vresult.AssignDate = dt.Rows[0]["AssignDate"].ToString();
                                vresult.I_Date = dt.Rows[0]["I_Date"].ToString();
                                vresult.count = count.ToString();
                                vresult.routearray = routearray;
                                vresult.RouteId = dt.Rows[0]["RouteId"].ToString();
                                vresult.TripdataSno = dt.Rows[0]["Sno"].ToString();
                                vresult.TripID = dt.Rows[0]["Sno"].ToString();
                                vresult.Salestype = dt.Rows[0]["salestype"].ToString();
                                vresult.BranchSno = dt.Rows[0]["BranchSno"].ToString();
                                vresult.Sno = i++.ToString();
                                context.Session["ATripId"] = dt.Rows[0]["ATripId"].ToString();

                                //vresult.PlantDispSno = dt.Rows[0]["Sno"].ToString();
                                //vresult.DispDate = dt.Rows[0]["I_Date"].ToString();
                                //vresult.CsoNo = dt.Rows[0]["BranchID"].ToString();
                                // Response.Redirect("Default.aspx", false);
                                string response = GetJson(vresult);
                                context.Response.Write(response);
                            }
                        }
                        else
                        {
                            msg = "Trip Not Assigned on this UserName";
                            string errresponse = GetJson(msg);
                            context.Response.Write(errresponse);
                        }
                    }
                }
                else
                {
                    msg = "Invalid UserName and Password";
                    string errresponse = GetJson(msg);
                    context.Response.Write(errresponse);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                string errresponse = GetJson(msg);
                context.Response.Write(errresponse);
            }
        }
        //........................Return Details......../////////////////
        private void btnReturnsVarifySaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    foreach (RouteLeakdetails o in obj.RouteLeakdetails)
                    {
                        if (o.ProductID != null)
                        {
                            cmd = new MySqlCommand("Update Leakages set Vreturns=@Vreturns,VarifyReturnStatus=@VarifyReturnStatus,VTripID=@VTripID  where ProductID=@ProductID and TripID=@TripID and VarifyReturnStatus=@VRS");
                            float ReturnQty = 0;
                            float.TryParse(o.ReturnsQty, out ReturnQty);
                            cmd.Parameters.Add("@Vreturns", ReturnQty);
                            //float TotalLeaks = 0;
                            //float.TryParse(o.LeaksQty, out TotalLeaks);
                            //cmd.Parameters.Add("@VLeaks", TotalLeaks);
                            cmd.Parameters.Add("@ProductID", o.ProductID);
                            cmd.Parameters.Add("@TripID", o.TripID);
                            cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                            cmd.Parameters.Add("@VarifyReturnStatus", 'V');
                            cmd.Parameters.Add("@VRS", 'P');
                            if (ReturnQty != 0.0)
                            {
                                vdm.Update(cmd);
                            }
                        }
                    }
                    string Msg = "Returns Successfully Updated";
                    string response = GetJson(Msg);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        //........................Leaks Details......../////////////////
        private void btnLeakVarifySaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    foreach (RouteLeakdetails o in obj.RouteLeakdetails)
                    {
                        if (o.ProductID != null)
                        {
                            cmd = new MySqlCommand("Update Leakages set VLeaks=@VLeaks,VarifyStatus=@VarifyStatus,VTripID=@VTripID  where ProductID=@ProductID and TripID=@TripID and VarifyStatus=@VS");
                            //float ReturnQty = 0;
                            //float.TryParse(o.ReturnsQty, out ReturnQty);
                            //cmd.Parameters.Add("@Vreturns", ReturnQty);
                            float TotalLeaks = 0;
                            float.TryParse(o.LeaksQty, out TotalLeaks);
                            cmd.Parameters.Add("@VLeaks", TotalLeaks);
                            cmd.Parameters.Add("@ProductID", o.ProductID);
                            cmd.Parameters.Add("@TripID", o.TripID);
                            cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                            cmd.Parameters.Add("@VarifyStatus", 'V');
                            cmd.Parameters.Add("@VS", 'P');
                            if (TotalLeaks != 0.0)
                            {
                                vdm.Update(cmd);
                            }
                        }
                    }
                    string Msg = "Leaks Successfully Updated";
                    string response = GetJson(Msg);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetVerifyReturns(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteSno = context.Request["RouteSno"];
                    List<VarifyReturnLeak> GetVarifyReturnLeaklist = new List<VarifyReturnLeak>();
                    cmd = new MySqlCommand("SELECT tripdata.Sno, leakages.ReturnQty,  leakages.ProductID, productsdata.ProductName, dispatch.DispName  FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN leakages ON tripdata.Sno = leakages.TripID INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VarifyReturnStatus = @VarifyReturnStatus) AND (dispatch.sno = @dispatchsno) AND (tripdata.ATripid = @ATripid)");
                    cmd.Parameters.Add("@dispatchsno", RouteSno);
                    cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                    cmd.Parameters.Add("@VarifyReturnStatus", 'P');
                    DataTable dtVarifyReturns = vdm.SelectQuery(cmd).Tables[0];
                    //cmd = new MySqlCommand("SELECT tripdata.Sno, leakages.ReturnQty, leakages.TotalLeaks, leakages.ProductID, productsdata.ProductName, empmanage.UserName FROM leakages INNER JOIN tripdata ON leakages.TripID = tripdata.Sno INNER JOIN productsdata ON leakages.ProductID = productsdata.sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno WHERE (leakages.VarifyStatus = @VarifyStatus)");
                    ////cmd = new MySqlCommand("SELECT tripdata.Sno, leakages.ReturnQty,  leakages.ProductID, productsdata.ProductName, dispatch.DispName FROM leakages INNER JOIN tripdata ON leakages.TripID = tripdata.Sno INNER JOIN productsdata ON leakages.ProductID = productsdata.sno INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE (leakages.VarifyStatus = @VarifyStatus) AND (dispatch.sno = @dispatchsno)");
                    ////cmd.Parameters.Add("@dispatchsno", RouteSno);
                    ////cmd.Parameters.Add("@VarifyReturnStatus", 'P');
                    ////DataTable dtVarifyLeaks = vdm.SelectQuery(cmd).Tables[0];
                    if (dtVarifyReturns.Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in dtVarifyReturns.Rows)
                        {
                            VarifyReturnLeak GetVarifyReturnLeak = new VarifyReturnLeak();
                            GetVarifyReturnLeak.Sno = i++.ToString();
                            GetVarifyReturnLeak.ProdId = dr["ProductID"].ToString();
                            GetVarifyReturnLeak.ProdName = dr["ProductName"].ToString();
                            float ReturnQty = 0;
                            float.TryParse(dr["ReturnQty"].ToString(), out ReturnQty);
                            GetVarifyReturnLeak.Returns = ReturnQty.ToString();
                            GetVarifyReturnLeak.Trip = dr["Sno"].ToString();
                            GetVarifyReturnLeak.EmpName = dr["DispName"].ToString();
                            if (ReturnQty != 0.0)
                            {
                                GetVarifyReturnLeaklist.Add(GetVarifyReturnLeak);
                            }
                        }
                    }
                    string response = GetJson(GetVarifyReturnLeaklist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetVerifyLeaks(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteSno = context.Request["RouteSno"];
                    List<VarifyReturnLeak> GetVarifyReturnLeaklist = new List<VarifyReturnLeak>();
                    cmd = new MySqlCommand("SELECT tripdata.Sno, leakages.TotalLeaks, productsdata.ProductName, dispatch.DispName, leakages.ProductID  FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN leakages ON tripdata.Sno = leakages.TripID INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VarifyStatus = @VarifyStatus) AND (dispatch.sno = @dispatchsno) AND (tripdata.ATripid = @ATripid)");
                    cmd.Parameters.Add("@dispatchsno", RouteSno);
                    cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                    cmd.Parameters.Add("@VarifyStatus", 'P');
                    DataTable dtVarifyLeaks = vdm.SelectQuery(cmd).Tables[0];
                    //cmd = new MySqlCommand("SELECT tripdata.Sno, leakages.ReturnQty, leakages.TotalLeaks, leakages.ProductID, productsdata.ProductName, empmanage.UserName FROM leakages INNER JOIN tripdata ON leakages.TripID = tripdata.Sno INNER JOIN productsdata ON leakages.ProductID = productsdata.sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno WHERE (leakages.VarifyStatus = @VarifyStatus)");
                    ////cmd = new MySqlCommand("SELECT tripdata.Sno,  leakages.TotalLeaks, leakages.ProductID, productsdata.ProductName, dispatch.DispName FROM leakages INNER JOIN tripdata ON leakages.TripID = tripdata.Sno INNER JOIN productsdata ON leakages.ProductID = productsdata.sno INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE (leakages.VarifyStatus = @VarifyStatus) AND (dispatch.sno = @dispatchsno)");
                    ////cmd.Parameters.Add("@dispatchsno", RouteSno);
                    ////cmd.Parameters.Add("@VarifyStatus", 'P');
                    ////DataTable dtVarifyLeaks = vdm.SelectQuery(cmd).Tables[0];
                    if (dtVarifyLeaks.Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in dtVarifyLeaks.Rows)
                        {
                            VarifyReturnLeak GetVarifyReturnLeak = new VarifyReturnLeak();
                            GetVarifyReturnLeak.Sno = i++.ToString();
                            GetVarifyReturnLeak.ProdId = dr["ProductID"].ToString();
                            GetVarifyReturnLeak.ProdName = dr["ProductName"].ToString();
                            GetVarifyReturnLeak.Leaks = dr["TotalLeaks"].ToString();
                            GetVarifyReturnLeak.Trip = dr["Sno"].ToString();
                            GetVarifyReturnLeak.EmpName = dr["DispName"].ToString();
                            GetVarifyReturnLeaklist.Add(GetVarifyReturnLeak);
                        }
                    }
                    string response = GetJson(GetVarifyReturnLeaklist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class VarifyReturnLeak
        {
            public string Sno { get; set; }
            public string ProdId { get; set; }
            public string ProdName { get; set; }
            public string Returns { get; set; }
            public string Leaks { get; set; }
            public string Trip { get; set; }
            public string EmpName { get; set; }
        }
        private void GetReturnLeakReport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    List<ReturnLeakClass> ReturnLeaklist = new List<ReturnLeakClass>();
                    string LevelType = context.Session["LevelType"].ToString();
                    if (LevelType == "Dispatcher")
                    {
                        cmd = new MySqlCommand("SELECT ROUND(SUM(leakages.VLeaks), 2) AS VLeaks, ROUND(SUM(leakages.VReturns), 2) AS VReturns, productsdata.ProductName, leakages.ProductID,leakages.VarifyReturnStatus, leakages.VarifyStatus FROM leakages INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VTripID = @VTripID) GROUP BY productsdata.ProductName, leakages.VTripID ORDER BY productsdata.sno");
                        cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                        DataTable dtPuffLeak = vdm.SelectQuery(cmd).Tables[0];
                        if (dtPuffLeak.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow drPufLeak in dtPuffLeak.Rows)
                            {
                                ReturnLeakClass GetReturnLeak = new ReturnLeakClass();
                                GetReturnLeak.Sno = i++.ToString();
                                GetReturnLeak.ProdId = drPufLeak["ProductID"].ToString();
                                GetReturnLeak.ProdName = drPufLeak["ProductName"].ToString();
                                GetReturnLeak.Returns = drPufLeak["VReturns"].ToString();
                                GetReturnLeak.Leaks = drPufLeak["VLeaks"].ToString();
                                ReturnLeaklist.Add(GetReturnLeak);
                            }
                        }
                    }
                    else
                    {
                        DataTable dtLeakProducts = new DataTable();
                        DataTable dtRouteProducts = new DataTable();
                        DataTable dtproductsdata = new DataTable();
                        if (context.Session["dtproductsdata"] == null)
                        {
                            cmd = new MySqlCommand("SELECT sno, ProductName FROM productsdata ORDER BY sno");
                            dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                        }
                        else
                        {
                            dtproductsdata = (DataTable)context.Session["dtproductsdata"];
                        }
                        dtLeakProducts.Columns.Add("sno");
                        dtLeakProducts.Columns.Add("ProductName");
                        dtLeakProducts.Columns.Add("LeakQty");
                        dtLeakProducts.Columns.Add("DeliveryQty");
                        foreach (DataRow dr in dtproductsdata.Rows)
                        {
                            DataRow newRow = dtLeakProducts.NewRow();
                            newRow["sno"] = dr["sno"].ToString();
                            newRow["ProductName"] = dr["ProductName"].ToString();
                            newRow["LeakQty"] = "0";
                            newRow["DeliveryQty"] = "0";
                            dtLeakProducts.Rows.Add(newRow);
                        }
                        dtRouteProducts.Columns.Add("sno");
                        dtRouteProducts.Columns.Add("ProductName");
                        dtRouteProducts.Columns.Add("LeakQty");
                        dtRouteProducts.Columns.Add("DeliveryQty");
                        dtRouteProducts.Columns.Add("ShortQty");
                        dtRouteProducts.Columns.Add("FreeMilk");
                        foreach (DataRow dr in dtproductsdata.Rows)
                        {
                            DataRow newRow = dtRouteProducts.NewRow();
                            newRow["sno"] = dr["sno"].ToString();
                            newRow["ProductName"] = dr["ProductName"].ToString();
                            newRow["LeakQty"] = "0";
                            newRow["DeliveryQty"] = "0";
                            newRow["ShortQty"] = "0";
                            newRow["FreeMilk"] = "0";
                            dtRouteProducts.Rows.Add(newRow);
                        }
                        cmd = new MySqlCommand("SELECT indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.LeakQty),2) AS LeakQty FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo RIGHT OUTER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents_subtable.DTripId = @TripID)  GROUP BY productsdata.ProductName order by Product_sno");
                        cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                        DataTable dtAgentLeak = vdm.SelectQuery(cmd).Tables[0];
                        if (dtAgentLeak.Rows.Count > 0)
                        {
                            foreach (DataRow drAgent in dtAgentLeak.Rows)
                            {
                                foreach (DataRow drtotprod in dtLeakProducts.Rows)
                                {

                                    if (drAgent["Product_sno"].ToString() == drtotprod["sno"].ToString())
                                    {
                                        float ALeak = 0;
                                        float.TryParse(drAgent["LeakQty"].ToString(), out ALeak);
                                        float Rleak = 0;
                                        float.TryParse(drtotprod["LeakQty"].ToString(), out Rleak);
                                        float totalqty = ALeak + Rleak;
                                        float ADel = 0;
                                        float.TryParse(drAgent["DeliveryQty"].ToString(), out ADel);
                                        float RDel = 0;
                                        float.TryParse(drtotprod["DeliveryQty"].ToString(), out RDel);
                                        float totDel = ADel + RDel;
                                        drtotprod["LeakQty"] = totalqty;
                                        drtotprod["DeliveryQty"] = totDel;
                                    }
                                }
                            }
                        }
                        DataTable dtRouteLeaks = new DataTable();
                        cmd = new MySqlCommand("select LeakQty,ShortQty,FreeMilk,ProductID from Leakages where TripId=@TripId and VarifyStatus is NULL order by ProductID");
                        cmd.Parameters.Add("@TripId", context.Session["TripID"].ToString());
                        dtRouteLeaks = vdm.SelectQuery(cmd).Tables[0];
                        if (dtRouteLeaks.Rows.Count > 0)
                        {
                            foreach (DataRow drAgent in dtRouteLeaks.Rows)
                            {
                                foreach (DataRow drtotprod in dtRouteProducts.Rows)
                                {

                                    if (drAgent["ProductID"].ToString() == drtotprod["sno"].ToString())
                                    {
                                        float ALeak = 0;
                                        float.TryParse(drAgent["LeakQty"].ToString(), out ALeak);
                                        float Rleak = 0;
                                        float.TryParse(drtotprod["LeakQty"].ToString(), out Rleak);
                                        float totalqty = ALeak + Rleak;
                                        float AShort = 0;
                                        float.TryParse(drAgent["ShortQty"].ToString(), out AShort);
                                        float RShort = 0;
                                        float.TryParse(drtotprod["ShortQty"].ToString(), out RShort);
                                        float totalRShort = AShort + RShort;
                                        float AFreeMilk = 0;
                                        float.TryParse(drAgent["FreeMilk"].ToString(), out AFreeMilk);
                                        float RAFreeMilk = 0;
                                        float.TryParse(drtotprod["FreeMilk"].ToString(), out RAFreeMilk);
                                        float totalRAFreeMilk = AFreeMilk + RAFreeMilk;
                                        drtotprod["LeakQty"] = totalqty;
                                        drtotprod["ShortQty"] = totalRShort;
                                        drtotprod["FreeMilk"] = totalRAFreeMilk;
                                    }
                                }
                            }
                        }
                        int i = 1;
                        if (dtRouteLeaks.Rows.Count > 0)
                        {
                            foreach (DataRow drAgentLeak in dtLeakProducts.Rows)
                            {
                                foreach (DataRow drRouteLeaks in dtRouteProducts.Rows)
                                {
                                    if (drAgentLeak["sno"].ToString() == drRouteLeaks["sno"].ToString())
                                    {
                                        float DelQty = 0;
                                        float.TryParse(drAgentLeak["DeliveryQty"].ToString(), out DelQty);
                                        float AgentLeak = 0;
                                        float.TryParse(drAgentLeak["LeakQty"].ToString(), out AgentLeak);
                                        float RouteLeak = 0;
                                        float.TryParse(drRouteLeaks["LeakQty"].ToString(), out RouteLeak);
                                        float FreeMilk = 0;
                                        float.TryParse(drRouteLeaks["FreeMilk"].ToString(), out FreeMilk);
                                        float Short = 0;
                                        float.TryParse(drRouteLeaks["ShortQty"].ToString(), out Short);
                                        float TotalLeaks = AgentLeak + RouteLeak + FreeMilk + Short + DelQty;
                                        cmd = new MySqlCommand("SELECT tripsubdata.Qty AS DispQty, productsdata.ProductName, productsdata.sno FROM productsdata INNER JOIN tripsubdata ON productsdata.sno = tripsubdata.ProductId WHERE (tripsubdata.Tripdata_sno = @Tripid) AND (productsdata.sno = @ProductID) ");
                                        cmd.Parameters.Add("@Tripid", context.Session["TripID"].ToString());
                                        cmd.Parameters.Add("@ProductID", drRouteLeaks["sno"].ToString());
                                        DataTable dtSubdata = vdm.SelectQuery(cmd).Tables[0];
                                        foreach (DataRow drSubData in dtSubdata.Rows)
                                        {
                                            float SubQty = 0;
                                            float.TryParse(drSubData["DispQty"].ToString(), out SubQty);
                                            float Return = 0;
                                            Return = SubQty - TotalLeaks;
                                            ReturnLeakClass GetReturnLeak = new ReturnLeakClass();
                                            GetReturnLeak.Sno = i++.ToString();
                                            GetReturnLeak.ProdId = drSubData["sno"].ToString();
                                            GetReturnLeak.ProdName = drSubData["ProductName"].ToString();
                                            GetReturnLeak.Returns = Return.ToString();
                                            float Leaks = 0;
                                            Leaks = AgentLeak + RouteLeak;
                                            GetReturnLeak.Leaks = Leaks.ToString();
                                            if (Leaks != 0.0 || Return != 0.0)
                                            {
                                                ReturnLeaklist.Add(GetReturnLeak);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow drAgentLeak in dtAgentLeak.Rows)
                            {
                                cmd = new MySqlCommand("SELECT tripsubdata.Qty AS DispQty, productsdata.ProductName, productsdata.sno FROM productsdata INNER JOIN tripsubdata ON productsdata.sno = tripsubdata.ProductId WHERE (tripsubdata.Tripdata_sno = @Tripid) AND (productsdata.sno = @ProductID) ");
                                cmd.Parameters.Add("@Tripid", context.Session["TripID"].ToString());
                                cmd.Parameters.Add("@ProductID", drAgentLeak["Product_sno"].ToString());
                                DataTable dtSubdata = vdm.SelectQuery(cmd).Tables[0];
                                float DelQty = 0;
                                float.TryParse(drAgentLeak["DeliveryQty"].ToString(), out DelQty);
                                float AgentLeak = 0;
                                float.TryParse(drAgentLeak["LeakQty"].ToString(), out AgentLeak);
                                float RouteLeak = 0;
                                float TotalLeaks = AgentLeak + RouteLeak + DelQty;
                                foreach (DataRow drSubData in dtSubdata.Rows)
                                {
                                    float SubQty = 0;
                                    float.TryParse(drSubData["DispQty"].ToString(), out SubQty);
                                    float Return = 0;
                                    Return = SubQty - TotalLeaks;
                                    ReturnLeakClass GetReturnLeak = new ReturnLeakClass();
                                    GetReturnLeak.Sno = i++.ToString();
                                    GetReturnLeak.ProdId = drSubData["sno"].ToString();
                                    GetReturnLeak.ProdName = drSubData["ProductName"].ToString();
                                    GetReturnLeak.Returns = Return.ToString();
                                    float Leaks = 0;
                                    Leaks = AgentLeak + RouteLeak;
                                    GetReturnLeak.Leaks = Leaks.ToString();
                                    if (Leaks != 0.0 || Return != 0.0)
                                    {
                                        ReturnLeaklist.Add(GetReturnLeak);
                                    }
                                }
                            }
                        }
                    }
                    string errresponse = GetJson(ReturnLeaklist);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        class ReturnLeakClass
        {
            public string Sno { get; set; }
            public string ProdId { get; set; }
            public string ProdName { get; set; }
            public string Returns { get; set; }
            public string Leaks { get; set; }
        }
        private void DeliverReportclick(HttpContext context)
        {
            try
            {
                DataTable Report = new DataTable();
                vdm = new VehicleDBMgr();
                string IndentDate = context.Session["I_Date"].ToString();
                string RouteId = context.Session["RouteId"].ToString();
                DateTime dtDispDate = Convert.ToDateTime(IndentDate);
                cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.LeakQty), 2) AS LeakQty, indents_subtable.UnitCost, indents.IndentNo, indents.Branch_id, ROUND(SUM(indents_subtable.UnitCost * indents_subtable.DeliveryQty), 2) AS Total FROM  dispatch RIGHT OUTER JOIN branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno ON dispatch.Route_id = branchroutes.Sno LEFT OUTER JOIN indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo RIGHT OUTER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno ON branchdata.sno = indents.Branch_id WHERE (indents.I_date between @starttime AND  @endtime) AND (dispatch.sno = @dispatchSno) GROUP BY productsdata.ProductName");
                // cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty),2) AS unitQty, indents_subtable.Product_sno, productsdata.ProductName, branchroutes.Sno,ROUND(SUM(indents_subtable.DeliveryQty),2) AS DeliveryQty, ROUND(SUM(indents_subtable.LeakQty),2) AS LeakQty, indents_subtable.UnitCost, indents.IndentNo, indents.Branch_id,ROUND(SUM(indents_subtable.UnitCost * indents_subtable.DeliveryQty),2) AS Total FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo RIGHT OUTER JOIN  productsdata ON indents_subtable.Product_sno = productsdata.sno LEFT OUTER JOIN branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno ON indents.Branch_id = branchdata.sno WHERE(branchroutes.Sno = @TripID) AND (indents.I_date >= @starttime) AND (indents.I_date < @endtime) GROUP BY productsdata.ProductName");
                cmd.Parameters.Add("@dispatchSno", RouteId);
                //cmd.Parameters.Add("@EmpSno", 27);
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtDispDate));
                DataTable dtble = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.Branchid, collections.AmountPaid, indents_subtable.DeliveryQty * indents_subtable.UnitCost AS totalamount, collections.PaidDate, indents_subtable.D_date FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON indents.Branch_id = collections.Branchid INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN dispatch ON branchroutes.Sno = dispatch.Route_id WHERE (indents.I_date between @starttime AND  @endtime) AND (collections.PaidDate >= @Paidstime) AND (collections.PaidDate < @Paidetime) AND (dispatch.sno = @dispatchSno)GROUP BY branchdata.BranchName, indents_subtable.DeliveryQty, indents_subtable.UnitCost, collections.PaidDate, indents_subtable.D_date");
                // cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.Branchid, collections.AmountPaid,indents_subtable.DeliveryQty * indents_subtable.UnitCost AS totalamount, collections.PaidDate, indents_subtable.D_date FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN  branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON indents.Branch_id = collections.Branchid INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE (branchroutes.Sno = @TripID) AND (indents.I_date > @starttime) AND (indents.I_date < @endtime) AND (collections.PaidDate >= @Paidstime) and (collections.PaidDate < @Paidetime)GROUP BY branchdata.BranchName, indents_subtable.DeliveryQty, indents_subtable.UnitCost, collections.PaidDate, indents_subtable.D_date");
                cmd.Parameters.Add("@dispatchSno", RouteId);
                //cmd.Parameters.Add("@EmpSno", 27);
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtDispDate));
                cmd.Parameters.Add("@Paidstime", DateConverter.GetLowDate(dtDispDate.AddDays(1)));
                cmd.Parameters.Add("@Paidetime", DateConverter.GetHighDate(dtDispDate.AddDays(1)));
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                //cmd = new MySqlCommand("SELECT tripdata.Denominations, tripdata.Remarks, tripdata.CollectedAmount FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno WHERE (triproutes.RouteID = @TripID) AND (tripdata.Status = 'P')");
                //cmd = new MySqlCommand("SELECT tripdata.Denominations, tripdata.Remarks, tripdata.SubmittedAmount, tripdata.Cdate, empmanage.EmpName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno WHERE (tripdata.Cdate > @starttime) AND (tripdata.Cdate < @endtime) AND (dispatch.sno = @dispatchSno)");
                //cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtDispDate));
                //cmd.Parameters.Add("@endtime", GetHighDate(fromdate));//.ToString("MM/dd/yyyy HH:mm:ss tt"));
                //cmd.Parameters.Add("@dispatchSno", ddlRouteName.SelectedValue);
                //DataTable dtDenomin = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT tripsubdata.Tripdata_sno, tripsubdata.Qty as DispQty, productsdata.ProductName,productsdata.sno FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN triproutes ON triproutes.Tripdata_sno = tripsubdata.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (tripdata.I_Date BETWEEN @starttime AND @endtime) AND (dispatch.sno = @dispatchsno)");
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtDispDate));
                cmd.Parameters.Add("@dispatchSno", RouteId);
                DataTable dtSubData = vdm.SelectQuery(cmd).Tables[0];
                string Sno = dtSubData.Rows[0]["Tripdata_sno"].ToString();
                DataTable dtLeakages = new DataTable();
                cmd = new MySqlCommand("select LeakQty,ShortQty,FreeMilk,ProductID from Leakages where TripId=@TripId order by ProductID");
                cmd.Parameters.Add("@TripId", Sno);
                dtLeakages = vdm.SelectQuery(cmd).Tables[0];
                dtble.DefaultView.Sort = "Product_sno ASC";
                dtble = dtble.DefaultView.ToTable(true);
                if (dtble.Rows.Count > 0)
                {

                    Report = new DataTable();
                    //Report.
                    Report.Columns.Add("Variety");
                    Report.Columns.Add("Qty");
                    Report.Columns.Add("DispQty");
                    Report.Columns.Add("ReturnQty");
                    Report.Columns.Add("Leakage");
                    Report.Columns.Add("Short");
                    Report.Columns.Add("FreeMilk");
                    Report.Columns.Add("Sales");
                    Report.Columns.Add("Sales Value");
                    Report.Columns.Add("Agent Name");
                    Report.Columns.Add("Due Amount");
                    Report.Columns.Add("Amount");
                    //Report.Columns.Add("Denomin");
                    double totalqty = 0;
                    double Leakqty = 0;
                    double tDispqty = 0;
                    double tReturnqty = 0;
                    double delqty = 0;
                    double TotAmount = 0;
                    foreach (DataRow branch in dtble.Rows)
                    {
                        DataRow newrow = Report.NewRow();
                        newrow["Variety"] = branch["ProductName"].ToString();
                        newrow["Qty"] = branch["unitQty"].ToString();
                        float DispQty = 0;
                        float ReturnQty = 0;
                        foreach (DataRow drSubData in dtSubData.Rows)
                        {
                            if (branch["Product_sno"].ToString() == drSubData["sno"].ToString())
                            {
                                newrow["DispQty"] = drSubData["DispQty"].ToString();
                                float.TryParse(drSubData["DispQty"].ToString(), out DispQty);
                            }
                        }
                        float Leaks = 0;
                        float Totqty = 0;
                        if (dtLeakages.Rows.Count > 0)
                        {

                            string ProductID = branch["Product_sno"].ToString();
                            DataRow[] drleak = dtLeakages.Select("ProductID = '" + ProductID + "'");
                            if (drleak.Length != 0)
                            {
                                for (int i = 0; i < drleak.Length; i++)
                                {
                                    if (branch["Product_sno"].ToString() == drleak[i][3].ToString())
                                    {
                                        float Ileak = 0;
                                        float.TryParse(branch["LeakQty"].ToString(), out Ileak);
                                        float Rleak = 0;
                                        float.TryParse(drleak[i][0].ToString(), out Rleak);
                                        Leaks = Ileak + Rleak;
                                        newrow["Leakage"] = Math.Round(Leaks, 2);
                                        float ShortQty = 0;
                                        float.TryParse(drleak[i][1].ToString(), out ShortQty);
                                        newrow["Short"] = Math.Round(ShortQty, 2);
                                        float FreeMilk = 0;
                                        float.TryParse(drleak[i][2].ToString(), out FreeMilk);
                                        newrow["FreeMilk"] = Math.Round(FreeMilk, 2);
                                        float DeliveryQty = 0;
                                        float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                                        Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                                        ReturnQty = DispQty - Totqty;
                                        newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                                    }
                                    else
                                    {
                                        newrow["Leakage"] = branch["LeakQty"].ToString();
                                        float.TryParse(branch["LeakQty"].ToString(), out Leaks);
                                        float DeliveryQty = 0;
                                        float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                                        float ShortQty = 0;
                                        newrow["Short"] = ShortQty;
                                        float FreeMilk = 0;
                                        newrow["FreeMilk"] = FreeMilk;
                                        Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                                        ReturnQty = DispQty - Totqty;
                                        newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                                    }
                                    tReturnqty += Math.Round(ReturnQty, 2); ;
                                    tDispqty += DispQty;
                                    Leakqty += Leaks;
                                }
                            }
                            else
                            {
                                newrow["Leakage"] = branch["LeakQty"].ToString();
                                float.TryParse(branch["LeakQty"].ToString(), out Leaks);
                                float DeliveryQty = 0;
                                float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                                float ShortQty = 0;
                                newrow["Short"] = ShortQty;
                                float FreeMilk = 0;
                                newrow["FreeMilk"] = FreeMilk;
                                Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                                ReturnQty = DispQty - Totqty;
                                newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                                tReturnqty += Math.Round(ReturnQty, 2); ;
                                tDispqty += DispQty;
                                Leakqty += Leaks;
                            }
                        }
                        else
                        {
                            newrow["Leakage"] = branch["LeakQty"].ToString();
                            float.TryParse(branch["LeakQty"].ToString(), out Leaks);
                            float DeliveryQty = 0;
                            float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                            float ShortQty = 0;
                            newrow["Short"] = ShortQty;
                            float FreeMilk = 0;
                            newrow["FreeMilk"] = FreeMilk;
                            Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                            ReturnQty = DispQty - Totqty;
                            newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                            tReturnqty += Math.Round(ReturnQty, 2); ;
                            tDispqty += DispQty;
                            Leakqty += Leaks;
                        }
                        newrow["Sales"] = branch["DeliveryQty"].ToString();
                        //float LeakQty=0;
                        //float.TryParse(branch["LeakQty"].ToString(), out LeakQty);

                        newrow["Sales Value"] = branch["Total"].ToString();
                        double qtyvalue = 0;
                        double Leakqtyvalue = 0;
                        double delqtyvalue = 0;
                        double TotAmountvalue = 0;
                        double.TryParse(branch["unitQty"].ToString(), out qtyvalue);
                        totalqty += Math.Round(qtyvalue, 2);
                        //double.TryParse(branch["LeakQty"].ToString(), out Leakqtyvalue);
                        //Leakqty += Leakqtyvalue;
                        double.TryParse(branch["DeliveryQty"].ToString(), out delqtyvalue);
                        delqty += Math.Round(delqtyvalue, 2);
                        double.TryParse(branch["Total"].ToString(), out TotAmountvalue);
                        TotAmount += Math.Round(TotAmountvalue, 2);
                        //newrow["Denomin"] = "100";
                        Report.Rows.Add(newrow);
                    }
                    List<DeliveryClass> DeliveryList = new List<DeliveryClass>();
                    foreach (DataRow dr in Report.Rows)
                    {
                        DeliveryClass GetDQty = new DeliveryClass();
                        GetDQty.Variety = dr["Variety"].ToString();
                        GetDQty.Qty = dr["Qty"].ToString();
                        GetDQty.DispQty = dr["DispQty"].ToString();
                        GetDQty.ReturnQty = dr["ReturnQty"].ToString();
                        GetDQty.Shorts = dr["Short"].ToString();
                        GetDQty.Free = dr["FreeMilk"].ToString();
                        GetDQty.LeakQty = dr["Leakage"].ToString();
                        GetDQty.Sales = dr["Sales"].ToString();
                        DeliveryList.Add(GetDQty);
                    }
                    string errresponse = GetJson(DeliveryList);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        class DeliveryClass
        {
            public string Variety { get; set; }
            public string Qty { get; set; }
            public string DispQty { get; set; }
            public string ReturnQty { get; set; }
            public string Shorts { get; set; }
            public string LeakQty { get; set; }
            public string Free { get; set; }
            public string Sales { get; set; }
        }
        private void btnInventoryVerifySaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    foreach (InvDatails o in obj.InvDatails)
                    {
                        if (o.SNo != null)
                        {
                            DataTable dtInventory = new DataTable();
                            cmd = new MySqlCommand("update tripinvdata set Remaining=@Remaining where Tripdata_sno=@TripID and invId=@invId");
                            int GivenQty = 0;
                            int.TryParse(o.Qty, out GivenQty);
                            cmd.Parameters.Add("@Remaining", GivenQty);
                            cmd.Parameters.Add("@invId", o.SNo);
                            cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                cmd.Parameters.Add("@Invid", o.SNo);
                                int Qty = 0;
                                cmd.Parameters.Add("@Qty", Qty);
                                cmd.Parameters.Add("@Remaining", GivenQty);
                                cmd.Parameters.Add("@Tripdata_sno", context.Session["TripdataSno"].ToString());
                                vdm.insert(cmd);
                            }
                            cmd = new MySqlCommand("Update invtransactions set VarificationStatus=@VarificationStatus,VQty=@VQty,AempID=@AempID,VTripID=@VTripID where B_Inv_Sno=@B_Inv_Sno and  tripId=@tripId and VarificationStatus=@PStatus");
                            cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                            cmd.Parameters.Add("@VarificationStatus", "V");
                            cmd.Parameters.Add("@PStatus", "P");
                            cmd.Parameters.Add("@VQty", o.Qty);
                            cmd.Parameters.Add("@AempID", context.Session["PlantEmpId"].ToString());
                            cmd.Parameters.Add("@tripId", o.TripID);
                            cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                            vdm.Update(cmd);

                            string LevelType = context.Session["LevelType"].ToString();
                            //if (context.Session["dtVerifyInventory"] == null)
                            //{
                            //    string errmsg = "Session Expired";
                            //    string errresponse = GetJson(errmsg);
                            //    context.Response.Write(errresponse);
                            ////////cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, inventory_monitor.Qty FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno WHERE (inventory_monitor.EmpId = @EmpID)");
                            //////cmd = new MySqlCommand("SELECT empmanage.UserName,invtransactions.TripID,invtransactions.B_Inv_Sno, invmaster.InvName,invtransactions.Qty   FROM invtransactions INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno INNER JOIN empmanage ON invtransactions.EmpID = empmanage.Sno WHERE (empmanage.Branch = @BranchID) AND (invtransactions.VarificationStatus = @VarificationStatus) and(invtransactions.B_Inv_Sno=@InvSno) Group by empmanage.UserName,invmaster.InvName");
                            ////////cmd = new MySqlCommand("SELECT  tripinvdata.Tripdata_sno,tripinvdata.Remaining, empmanage.UserName,invmaster.sno, invmaster.InvName FROM tripinvdata INNER JOIN tripdata ON tripinvdata.Tripdata_sno = tripdata.Sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (empmanage.Branch = @BranchID) AND (tripinvdata.Status = @Status)Group by empmanage.UserName,invmaster.InvName");
                            //////cmd.Parameters.Add("@InvSno", o.SNo);
                            //////cmd.Parameters.Add("@VarificationStatus", 'P');
                            //////cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                            //////dtInventory = vdm.SelectQuery(cmd).Tables[0];
                            //}
                            //else
                            //{
                            //    dtInventory = (DataTable)context.Session["dtVerifyInventory"];
                            //}
                            if (dtInventory.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtInventory.Rows)
                                {
                                    string PInvSno = dr["B_Inv_Sno"].ToString();
                                    if (o.SNo == PInvSno)
                                    {
                                        int PInvQty = 0;
                                        int.TryParse(dr["Qty"].ToString(), out PInvQty);
                                        int InvQty = 0;
                                        int.TryParse(o.Qty, out InvQty);
                                        float TQty = InvQty - PInvQty;
                                        if (TQty >= 1)
                                        {
                                            cmd = new MySqlCommand("Update tripinvdata set Status=@Status,Remaining=Remaining-@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                            cmd.Parameters.Add("@Invid", o.SNo);
                                            cmd.Parameters.Add("@Tripdata_sno", o.TripID);
                                            cmd.Parameters.Add("@Remaining", TQty);
                                            cmd.Parameters.Add("@Status", 'V');
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining+@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                            cmd.Parameters.Add("@Invid", o.SNo);

                                            cmd.Parameters.Add("@Remaining", TQty);
                                            cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                            if (vdm.Update(cmd) == 0)
                                            {
                                                cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                                int Qty = 0;
                                                cmd.Parameters.Add("@Qty", Qty);
                                                cmd.Parameters.Add("@Invid", o.SNo);
                                                cmd.Parameters.Add("@Remaining", TQty);
                                                cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                                vdm.insert(cmd);
                                            }
                                        }
                                        else
                                        {
                                            TQty = Math.Abs(TQty);
                                            cmd = new MySqlCommand("Update tripinvdata set Status=@Status,Remaining=Remaining+@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                            cmd.Parameters.Add("@Invid", o.SNo);
                                            cmd.Parameters.Add("@Tripdata_sno", o.TripID);
                                            cmd.Parameters.Add("@Remaining", TQty);
                                            cmd.Parameters.Add("@Status", 'V');
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining-@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                            cmd.Parameters.Add("@Invid", o.SNo);
                                            cmd.Parameters.Add("@Remaining", TQty);
                                            cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                            if (vdm.Update(cmd) == 0)
                                            {
                                                cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                                cmd.Parameters.Add("@Invid", o.SNo);
                                                int Qty = 0;
                                                cmd.Parameters.Add("@Qty", Qty);
                                                cmd.Parameters.Add("@Remaining", TQty);
                                                cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                                vdm.insert(cmd);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //cmd = new MySqlCommand("Update tripinvdata set Status=@Status,Remaining=Remaining-@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                //cmd.Parameters.Add("@Invid", o.SNo);
                                //cmd.Parameters.Add("@Tripdata_sno", o.TripID);
                                //cmd.Parameters.Add("@Remaining", o.Qty);
                                //cmd.Parameters.Add("@Status", 'V');
                                //vdm.Update(cmd);
                                cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining+@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                cmd.Parameters.Add("@Invid", o.SNo);
                                cmd.Parameters.Add("@Remaining", o.Qty);
                                cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno) values(@Remaining,@Invid,@Tripdata_sno)");
                                    cmd.Parameters.Add("@Invid", o.SNo);
                                    cmd.Parameters.Add("@Remaining", o.Qty);
                                    cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                    vdm.insert(cmd);
                                }
                            }

                        }
                    }

                    string msg = "Data Saved Successfully";
                    string msgresponse = GetJson(msg);
                    context.Response.Write(msgresponse);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                string msgresponse = GetJson(msg);
                context.Response.Write(msgresponse);
            }
        }
        private void GetVerifyInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<DispatchInventory> Inventorylist = new List<DispatchInventory>();
                if (context.Session["CsoNo"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteSno = context.Request["RouteSno"];
                    cmd = new MySqlCommand(" SELECT invtransactions.B_Inv_Sno, invtransactions.TripID, invmaster.InvName, invtransactions.Qty, tripdata.Sno, dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN invtransactions ON tripdata.Sno = invtransactions.TripID INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno WHERE  (dispatch.sno = @dispatchsno) AND (tripdata.ATripid = @ATripid) AND (invtransactions.VarificationStatus = @VarificationStatus) GROUP BY invmaster.InvName ");
                    cmd.Parameters.Add("@dispatchsno", RouteSno);
                    cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                    cmd.Parameters.Add("@VarificationStatus", 'P');
                    //   cmd = new MySqlCommand("SELECT invtransactions.B_Inv_Sno,empmanage.UserName,invtransactions.TripID, invmaster.InvName,invtransactions.Qty   FROM invtransactions INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno INNER JOIN empmanage ON invtransactions.EmpID = empmanage.Sno WHERE (empmanage.Branch = @BranchID) AND (invtransactions.VarificationStatus = @VarificationStatus) Group by empmanage.UserName,invmaster.InvName");
                    // cmd = new MySqlCommand("SELECT invtransactions.B_Inv_Sno, invtransactions.TripID, invmaster.InvName, invtransactions.Qty, tripdata.Sno, dispatch.DispName FROM triproutes INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN invtransactions ON tripdata.Sno = invtransactions.TripID INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno WHERE (dispatch.sno = @dispatchsno) AND (invtransactions.VarificationStatus = @VarificationStatus) GROUP BY invmaster.InvName,invtransactions.TripID");
                    //cmd.Parameters.Add("@VarificationStatus", 'P');
                    //cmd.Parameters.Add("@dispatchsno", RouteSno);
                    DataTable DtReport = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["dtVerifyInventory"] = DtReport;
                    if (DtReport.Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in DtReport.Rows)
                        {
                            DispatchInventory GetInventory = new DispatchInventory();
                            GetInventory.Sno = i++.ToString();
                            GetInventory.InvName = dr["InvName"].ToString();
                            GetInventory.InvSno = dr["B_Inv_Sno"].ToString();
                            GetInventory.EmpName = dr["DispName"].ToString();
                            GetInventory.Invqty = dr["Qty"].ToString();
                            GetInventory.TripId = dr["TripID"].ToString();
                            Inventorylist.Add(GetInventory);
                        }
                    }
                    string response = GetJson(Inventorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class DispatchInventory
        {
            public string Sno { get; set; }
            public string InvSno { get; set; }
            public string InvName { get; set; }
            public string EmpName { get; set; }
            public string Invqty { get; set; }
            public string TripId { get; set; }
        }
        private void btnReportingInventoryclick(string jsonString, HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    string LevelType = context.Session["LevelType"].ToString();
                    //var js = new JavaScriptSerializer();
                    //var title1 = context.Request.Params[1];
                    //Orders obj = js.Deserialize<Orders>(title1);
                    var js = new JavaScriptSerializer();
                    Orders obj = js.Deserialize<Orders>(jsonString);
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    List<InvDatails> InvDatailstlist = obj.InvDatails;
                    context.Session["InvDatailstlist_sync"] = InvDatailstlist;
                    List<RouteLeakdetails> RouteLeakslist = obj.RouteLeakdetails;
                    context.Session["RouteLeakslist_sync"] = RouteLeakslist;
                    foreach (InvDatails o in obj.InvDatails)
                    {
                        if (o.SNo != null)
                        {
                            if (LevelType == "SODispatcher")
                            {
                                cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                                cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                cmd.Parameters.Add("@Qty", o.Qty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@From", context.Session["BranchSno"].ToString());
                                cmd.Parameters.Add("@TransType", "3");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", context.Session["ATripId"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,VarifyStatus) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@VarifyStatus)");
                                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                    cmd.Parameters.Add("@Qty", o.Qty);
                                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@From", context.Session["BranchSno"].ToString());
                                    cmd.Parameters.Add("@TransType", "3");
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@To", context.Session["ATripId"].ToString());
                                    cmd.Parameters.Add("@VarifyStatus", "p");
                                    vdm.insert(cmd);
                                }
                            }
                            else
                            {
                                cmd = new MySqlCommand("update tripinvdata set Remaining=@Remaining where Tripdata_sno=@TripID and invId=@invId");
                                int GivenQty = 0;
                                int.TryParse(o.Qty, out GivenQty);
                                cmd.Parameters.Add("@Remaining", GivenQty);
                                cmd.Parameters.Add("@invId", o.SNo);
                                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                    cmd.Parameters.Add("@Invid", o.SNo);
                                    int Qty = 0;
                                    cmd.Parameters.Add("@Qty", Qty);
                                    cmd.Parameters.Add("@Remaining", GivenQty);
                                    cmd.Parameters.Add("@Tripdata_sno", context.Session["TripdataSno"].ToString());
                                    vdm.insert(cmd);
                                }
                                cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                                cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                cmd.Parameters.Add("@Qty", o.Qty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@TransType", "2");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,VarifyStatus) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@VarifyStatus)");
                                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                    cmd.Parameters.Add("@Qty", o.Qty);
                                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                    cmd.Parameters.Add("@TransType", "2");
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                                    cmd.Parameters.Add("@VarifyStatus", "P");
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }
                    foreach (RouteLeakdetails o in obj.RouteLeakdetails)
                    {
                        cmd = new MySqlCommand("Update Leakages set ReturnQty=@ReturnQty,TotalLeaks=@TotalLeaks,EntryDate=@EntryDate  where ProductID=@ProductID and TripID=@TripID and VarifyStatus=@VarifyStatus and VarifyReturnStatus=@VarifyReturnStatus");
                        float ReturnQty = 0;
                        float.TryParse(o.ReturnsQty, out ReturnQty);
                        cmd.Parameters.Add("@ReturnQty", ReturnQty);
                        float TotalLeaks = 0;
                        float.TryParse(o.LeaksQty, out TotalLeaks);
                        cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                        cmd.Parameters.Add("@ProductID", o.ProductID);
                        cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                        cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                        cmd.Parameters.Add("@VarifyStatus", "P");
                        cmd.Parameters.Add("@VarifyReturnStatus", "P");
                        if (vdm.Update(cmd) == 0)
                        {
                            cmd = new MySqlCommand("Insert into  Leakages(ReturnQty,TotalLeaks,ProductID,TripID,VarifyStatus,EntryDate,VarifyReturnStatus) Values (@ReturnQty,@TotalLeaks,@ProductID,@TripID,@VarifyStatus,@EntryDate,@VarifyReturnStatus)");
                            cmd.Parameters.Add("@ReturnQty", ReturnQty);
                            cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                            cmd.Parameters.Add("@ProductID", o.ProductID);
                            cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                            cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@VarifyStatus", "P");
                            cmd.Parameters.Add("@VarifyReturnStatus", "P");
                            vdm.insert(cmd);
                        }
                    }
                    string msg = "Y";
                    string msgresponse = GetJson(msg);
                    context.Response.Write(msgresponse);
                }
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand("insert into  Excepcetions (Name,TripID,Status) values(@Name,@TripID,@Status)");
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@Name", ex.ToString());
                cmd.Parameters.Add("@Status", "InvReporting");
                vdm.insert(cmd);
            }
        }
        private void getOrderStatus(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string BranchID = context.Request["Bid"];
                string IndentType = context.Request["IndentType"];
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                cmd.Parameters.Add("@Branch_id", BranchID);
                cmd.Parameters.Add("@IndentType", IndentType);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                if (dtIndent.Rows.Count > 0)
                {
                    string msg = "Indent Completed";
                    string errresponse = GetJson(msg);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        private void GetTripNo(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                string EmpID = context.Request["EmpID"];
                string DispDate = context.Session["DispDate"].ToString();
                DateTime dtDispDate = Convert.ToDateTime(DispDate);
                cmd = new MySqlCommand("SELECT Sno FROM tripdata where I_Date between @d1 and @d2 and EmpID=@EmpID and Status=@Status");
                cmd.Parameters.Add("@Status", 'A');
                cmd.Parameters.Add("@EmpID", EmpID);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtDispDate));
                DataTable dtTripID = vdm.SelectQuery(cmd).Tables[0];
                String TripID = "";
                if (dtTripID.Rows.Count > 0)
                {
                    TripID = dtTripID.Rows[0]["Sno"].ToString();
                    context.Session["DispTripSno"] = dtTripID.Rows[0]["Sno"].ToString();
                }
                else
                {
                    context.Session["DispTripSno"] = null;
                }
                string response = GetJson(TripID);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetDispInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Inventory> Inventorylist = new List<Inventory>();
                string DispTripSno = "";
                if (context.Session["DispTripSno"] != null)
                {
                    DispTripSno = context.Session["DispTripSno"].ToString();
                }
                cmd = new MySqlCommand("SELECT tripinvdata.invid,invmaster.sno, invmaster.InvName,tripinvdata.Remaining, tripinvdata.Qty FROM  tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno where  tripinvdata.Tripdata_sno=@Tripdata_sno");
                cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                DataTable dtInvData = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT tripinvdata.invid,invmaster.sno, invmaster.InvName, tripinvdata.Qty FROM  tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno where  tripinvdata.Tripdata_sno=@Tripdata_sno");
                cmd.Parameters.Add("@Tripdata_sno", DispTripSno);
                DataTable dtPrevInventory = vdm.SelectQuery(cmd).Tables[0];
                if (dtPrevInventory.Rows.Count == 0)
                {
                    context.Session["dtPrevInventory"] = "";
                    DataTable dtInventory = new DataTable();
                    if (context.Session["dtInventory"] == null)
                    {
                        cmd = new MySqlCommand("SELECT sno,InvName FROM invmaster");
                        dtInventory = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtInventory = (DataTable)context.Session["dtInventory"];
                    }
                    int i = 1;
                    foreach (DataRow dr in dtInventory.Rows)
                    {
                        foreach (DataRow drsubInv in dtInvData.Rows)
                        {
                            if (dr["sno"].ToString() == drsubInv["sno"].ToString())
                            {
                                Inventory GetInventory = new Inventory();
                                GetInventory.Sno = i++.ToString();
                                GetInventory.InvSno = dr["sno"].ToString();
                                GetInventory.InvName = dr["InvName"].ToString();
                                GetInventory.Invqty = "";
                                GetInventory.RemainQty = drsubInv["Remaining"].ToString();
                                Inventorylist.Add(GetInventory);
                            }
                        }
                    }
                    string response = GetJson(Inventorylist);
                    context.Response.Write(response);
                }
                else
                {
                    context.Session["dtPrevInventory"] = dtPrevInventory;
                    DataTable DtTotalInv = new DataTable();
                    DataTable dtInventory = new DataTable();
                    if (context.Session["dtInventory"] == null)
                    {
                        cmd = new MySqlCommand("SELECT sno,InvName FROM invmaster");
                        dtInventory = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtInventory = (DataTable)context.Session["dtInventory"];
                    }
                    DtTotalInv.Columns.Add("sno");
                    DtTotalInv.Columns.Add("InvName");
                    DtTotalInv.Columns.Add("Qty");
                    foreach (DataRow dr in dtInventory.Rows)
                    {
                        DataRow newRow = DtTotalInv.NewRow();
                        newRow["sno"] = dr["sno"].ToString();
                        newRow["InvName"] = dr["InvName"].ToString();
                        newRow["Qty"] = "0";
                        DtTotalInv.Rows.Add(newRow);
                    }
                    foreach (DataRow drDisp in dtPrevInventory.Rows)
                    {
                        foreach (DataRow drtotprod in DtTotalInv.Rows)
                        {

                            if (drDisp["sno"].ToString() == drtotprod["sno"].ToString())
                            {

                                //foreach (DataRow dr in dtPrevInventory.Rows)
                                //{
                                float qty = 0;
                                float.TryParse(drDisp["Qty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drtotprod["Qty"].ToString(), out qtycpy);

                                float totalqty = qty + qtycpy;
                                //float total = 0;
                                //float.TryParse(drprdt["TotalQty"].ToString(), out total);
                                //float totqty = total + totalqty;
                                drtotprod["Qty"] = Math.Round(totalqty, 2);

                                //}
                            }
                        }
                    }
                    int i = 1;
                    foreach (DataRow drtotprod in DtTotalInv.Rows)
                    {
                        foreach (DataRow drsubInv in dtInvData.Rows)
                        {
                            if (drtotprod["sno"].ToString() == drsubInv["sno"].ToString())
                            {
                                Inventory GetInventory = new Inventory();
                                GetInventory.Sno = i++.ToString();
                                GetInventory.InvSno = drtotprod["sno"].ToString();
                                GetInventory.InvName = drtotprod["InvName"].ToString();
                                GetInventory.Invqty = drtotprod["Qty"].ToString();
                                int Qty = 0;
                                int.TryParse(drtotprod["Qty"].ToString(), out Qty);
                                int Remaining = 0;
                                int.TryParse(drsubInv["Remaining"].ToString(), out Remaining);
                                GetInventory.RemainQty = Remaining.ToString();
                                Inventorylist.Add(GetInventory);
                            }
                        }
                    }
                    string response = GetJson(Inventorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class Inventory
        {
            public string Sno { get; set; }
            public string InvSno { get; set; }
            public string InvName { get; set; }
            public string Invqty { get; set; }
            public string RemainQty { get; set; }
        }
        private void GetCollectionStatus(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string TodayAmount = "0";
                string BranchID = context.Request["BranchID"];
                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd = new MySqlCommand("SELECT AmountPaid FROM collections where BranchID=@BranchID and PaidDate between @d1 and @d2");
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                DataTable dtTodayAmount = vdm.SelectQuery(cmd).Tables[0];
                if (dtTodayAmount.Rows.Count > 0)
                {
                    TodayAmount = dtTodayAmount.Rows[0]["AmountPaid"].ToString();
                    context.Session["AmountPaid"] = dtTodayAmount.Rows[0]["AmountPaid"].ToString();
                }
                string response = GetJson(TodayAmount);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void btnShoratageSaveClick(HttpContext context)
        {
            try
            {
                if (context.Session["TripID"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                    List<orderdetail> LeaksList = obj.data;

                    context.Session["LeaksList_syncData"] = LeaksList;

                    string msg = "Y";
                    string response = GetJson(msg);
                    context.Response.Write(response);


                    //foreach (orderdetail o in obj.data)
                    //{
                    //    if (o.Productsno != null)
                    //    {
                    //        //cmd = new MySqlCommand("update leakages set  EntryDate=@EntryDate,ShortQty=@ShortQty,LeakQty=@LeakQty,FreeMilk=@FreeMilk where TripID=@TripID and ProductID=@ProductID");
                    //        //cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                    //        //cmd.Parameters.Add("@EntryDate", Currentdate);
                    //        //cmd.Parameters.Add("@ProductID", o.Productsno);
                    //        float ShortQty = 0;
                    //        float.TryParse(o.ShortQty, out ShortQty);
                    //        //cmd.Parameters.Add("@ShortQty", ShortQty);
                    //        float LeakQty = 0;
                    //        float.TryParse(o.LeakQty, out LeakQty);
                    //        //cmd.Parameters.Add("@LeakQty", LeakQty);
                    //        float FreeMilk = 0;
                    //        float.TryParse(o.FreeMilk, out FreeMilk);
                    //        //cmd.Parameters.Add("@FreeMilk", FreeMilk);
                    //        //if (vdm.Update(cmd) == 0)
                    //        //{
                    //            cmd = new MySqlCommand("insert into leakages (TripID,EntryDate,ProductID,ShortQty,LeakQty,FreeMilk)values(@TripID,@EntryDate,@ProductID,@ShortQty,@LeakQty,@FreeMilk)");
                    //            cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                    //            cmd.Parameters.Add("@EntryDate", Currentdate);
                    //            cmd.Parameters.Add("@ProductID", o.Productsno);
                    //            float.TryParse(o.ShortQty, out ShortQty);
                    //            cmd.Parameters.Add("@ShortQty", ShortQty);
                    //            float.TryParse(o.LeakQty, out LeakQty);
                    //            cmd.Parameters.Add("@LeakQty", LeakQty);
                    //            cmd.Parameters.Add("@FreeMilk", FreeMilk);
                    //            vdm.insert(cmd);
                    //        //}
                    //    }
                    //}
                    //string msg = "Data Successfully Saved";
                    //string response = GetJson(msg);
                    //context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void GetShortageProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Products> Productlist = new List<Products>();
                string TripID = "";
                if (context.Session["DispTripSno"] != null)
                {
                    TripID = context.Session["DispTripSno"].ToString();
                }
                else
                {
                    if (context.Session["TripdataSno"] != null)
                    {
                        TripID = context.Session["TripdataSno"].ToString();
                    }
                    else
                    {
                        TripID = "";
                    }
                }
                cmd = new MySqlCommand("SELECT productsdata.ProductName, leakages.ShortQty, leakages.LeakQty,leakages.FreeMilk, productsdata.sno FROM leakages INNER JOIN productsdata ON leakages.ProductID = productsdata.sno where leakages.TripID=@TripID Group by productsdata.ProductName  ORDER BY productsdata.sno");
                cmd.Parameters.Add("@TripID", TripID);
                DataTable dtPrevdata = vdm.SelectQuery(cmd).Tables[0];
                if (dtPrevdata.Rows.Count == 0)
                {
                    DataTable dtproductsdata = new DataTable();
                    if (context.Session["dtproductsdata"] == null)
                    {
                        cmd = new MySqlCommand("SELECT sno, ProductName FROM productsdata ORDER BY sno");
                        dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtproductsdata = (DataTable)context.Session["dtproductsdata"];
                    }
                    int i = 1;
                    foreach (DataRow dr in dtproductsdata.Rows)
                    {
                        Products GetProducts = new Products();
                        GetProducts.sno = i++.ToString();
                        GetProducts.Productsno = dr["sno"].ToString();
                        GetProducts.ProductCode = dr["ProductName"].ToString();
                        GetProducts.ShortQty = "";
                        GetProducts.LeakQty = "";
                        GetProducts.FreeMilk = "";
                        Productlist.Add(GetProducts);
                    }
                    string response = GetJson(Productlist);
                    context.Response.Write(response);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.sno, tripsubdata.ProductId, tripsubdata.DeliverQty FROM productsdata INNER JOIN tripsubdata ON productsdata.sno = tripsubdata.ProductId WHERE (tripsubdata.Tripdata_sno = @TripID)ORDER BY productsdata.sno");
                    cmd.Parameters.Add("@TripID", TripID);
                    DataTable dtSubData = vdm.SelectQuery(cmd).Tables[0];
                    DataTable dtallProducts = new DataTable();
                    dtallProducts.Columns.Add("sno");
                    dtallProducts.Columns.Add("ProductName");
                    dtallProducts.Columns.Add("ShortQty");
                    dtallProducts.Columns.Add("LeakQty");
                    dtallProducts.Columns.Add("FreeMilk");
                    foreach (DataRow dr in dtSubData.Rows)
                    {
                        DataRow newRow = dtallProducts.NewRow();
                        newRow["sno"] = dr["sno"].ToString();
                        newRow["ProductName"] = dr["ProductName"].ToString();
                        newRow["ShortQty"] = "0";
                        newRow["LeakQty"] = "0";
                        newRow["FreeMilk"] = "0";
                        dtallProducts.Rows.Add(newRow);
                    }
                    int i = 1;
                    foreach (DataRow drSub in dtallProducts.Rows)
                    {
                        foreach (DataRow dr in dtPrevdata.Rows)
                        {
                            if (drSub["sno"].ToString() == dr["sno"].ToString())
                            {
                                drSub["ShortQty"] = dr["ShortQty"].ToString();
                                drSub["LeakQty"] = dr["LeakQty"].ToString();
                                drSub["FreeMilk"] = dr["FreeMilk"].ToString();

                            }
                        }
                    }
                    foreach (DataRow dr in dtallProducts.Rows)
                    {
                        Products GetProducts = new Products();
                        GetProducts.sno = i++.ToString();
                        GetProducts.Productsno = dr["sno"].ToString();
                        GetProducts.ProductCode = dr["ProductName"].ToString();
                        GetProducts.ShortQty = dr["ShortQty"].ToString();
                        GetProducts.LeakQty = dr["LeakQty"].ToString();
                        GetProducts.FreeMilk = dr["FreeMilk"].ToString();
                        Productlist.Add(GetProducts);
                    }
                    string response = GetJson(Productlist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class Products
        {
            public string sno { get; set; }
            public string ProductCode { get; set; }
            public string Productsno { get; set; }
            public string ShortQty { get; set; }
            public string LeakQty { get; set; }
            public string ReturnQty { get; set; }
            public string FreeMilk { get; set; }

        }
        private void btnDispatchSaveClick(HttpContext context)
        {
            try
            {
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    string EmpID = obj.EmpName;
                    string RouteId = obj.RouteId;
                    string DispDate = context.Session["DispDate"].ToString();
                    DateTime dtDispDate = Convert.ToDateTime(DispDate);
                    string VehicleNo = "";
                    DataTable dtTotalProducts = new DataTable();
                    DataTable dtPrevInventory = new DataTable();

                    cmd = new MySqlCommand("SELECT Sno FROM tripdata where I_Date between @d1 and @d2 and EmpID=@EmpID and Status=@Status and ATripid=@ATripid");
                    cmd.Parameters.Add("@Status", 'A');
                    cmd.Parameters.Add("@EmpID", EmpID);
                    cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtDispDate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtDispDate));
                    DataTable dtTripID = vdm.SelectQuery(cmd).Tables[0];
                    if (dtTripID.Rows.Count > 0)
                    {
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        if (context.Session["dtTripSubData"] == null)
                        {
                            cmd = new MySqlCommand("SELECT productsdata.ProductName, tripsubdata.Qty, productsdata.sno FROM tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN tripdata ON tripsubdata.Tripdata_sno = tripdata.Sno where tripsubdata.Tripdata_sno=@Tripdata_sno and tripdata.Status=@Status and tripdata.I_Date between @d1 and @d2 and tripdata.EmpId=@EmpId");
                            cmd.Parameters.Add("@Tripdata_sno", dtTripID.Rows[0]["Sno"].ToString());
                            cmd.Parameters.Add("@Status", 'A');
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtDispDate));
                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtDispDate));
                            cmd.Parameters.Add("@EmpId", EmpID);
                            dtTotalProducts = vdm.SelectQuery(cmd).Tables[0];
                            context.Session["dtTripSubData"] = dtTotalProducts;
                        }
                        else
                        {
                            dtTotalProducts = (DataTable)context.Session["dtTripSubData"];
                        }
                        if (context.Session["dtPrevInventory"] == null)
                        {
                            cmd = new MySqlCommand("SELECT tripinvdata.invid,invmaster.sno, invmaster.InvName, tripinvdata.Qty FROM  tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno where  tripinvdata.Tripdata_sno=@Tripdata_sno");
                            cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                            dtPrevInventory = vdm.SelectQuery(cmd).Tables[0];
                            context.Session["dtPrevInventory"] = dtPrevInventory;
                        }
                        else
                        {
                            dtPrevInventory = (DataTable)context.Session["dtPrevInventory"];
                        }
                        cmd = new MySqlCommand("Update  tripdata set  AssignDate=@AssignDate,Status=@Status,I_Date=@I_Date,DEmpId=@DEmpId where EmpId=@EmpId and Sno=@Sno and ATripid=@ATripid");
                        cmd.Parameters.Add("@Sno", dtTripID.Rows[0]["Sno"].ToString());
                        cmd.Parameters.Add("@Permissions", "D;C");
                        cmd.Parameters.Add("@EmpId", EmpID);
                        cmd.Parameters.Add("@AssignDate", Currentdate);
                        cmd.Parameters.Add("@I_Date", dtDispDate);
                        cmd.Parameters.Add("@DEmpId", context.Session["PlantEmpId"].ToString());
                        cmd.Parameters.Add("@status", "A");
                        cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                        vdm.Update(cmd);
                        foreach (orderdetail o in obj.data)
                        {
                            if (o.Productsno != null)
                            {
                                cmd = new MySqlCommand("Update tripsubdata set Qty=@Qty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                float Dispqty = 0;
                                float.TryParse(o.RemainQty, out Dispqty);
                                cmd.Parameters.Add("@Qty", Dispqty);
                                if (Dispqty != 0.0)
                                {
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("insert into tripsubdata (Tripdata_Sno,ProductId,Qty,DeliverQty)values(@Tripdata_Sno,@ProductId,@Qty,@DeliverQty)");
                                        cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                        cmd.Parameters.Add("@ProductId", o.Productsno);
                                        float.TryParse(o.RemainQty, out Dispqty);
                                        cmd.Parameters.Add("@Qty", Dispqty);
                                        cmd.Parameters.Add("@DeliverQty", 0);

                                        vdm.insert(cmd);
                                    }
                                }
                                foreach (DataRow dr in dtTotalProducts.Rows)
                                {
                                    string ProduSno = o.Productsno;
                                    string Psno = dr["sno"].ToString();
                                    if (ProduSno == Psno)
                                    {
                                        float PQty = 0;
                                        float.TryParse(dr["Qty"].ToString(), out PQty);
                                        float DQty = 0;
                                        float.TryParse(o.RemainQty, out DQty);
                                        float TQty = DQty - PQty;
                                        if (TQty >= 1)
                                        {
                                            cmd = new MySqlCommand("Update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                            cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                            cmd.Parameters.Add("@ProductId", o.Productsno);
                                            cmd.Parameters.Add("@DeliverQty", TQty);
                                            vdm.Update(cmd);
                                        }
                                        else
                                        {
                                            TQty = Math.Abs(TQty);
                                            cmd = new MySqlCommand("Update tripsubdata set DeliverQty=DeliverQty-@DeliverQty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                            cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                            cmd.Parameters.Add("@ProductId", o.Productsno);
                                            cmd.Parameters.Add("@DeliverQty", TQty);
                                            vdm.Update(cmd);
                                        }
                                    }
                                }
                                //cmd = new MySqlCommand("update branchproducts set manufact_remaining_qty=@manuftreming_qty where branch_sno=@bnchsno and product_sno=@pdtsno");
                                //cmd.Parameters.Add("@manuftreming_qty", Dispqty);
                                //cmd.Parameters.Add("@bnchsno", context.Session["CsoNo"].ToString());
                                //cmd.Parameters.Add("@pdtsno", o.Productsno);
                                //vdm.Update(cmd);
                            }
                        }
                        foreach (Inventorydetail o in obj.Inventorydetails)
                        {
                            if (o.InvSno != null)
                            {
                                cmd = new MySqlCommand("Update tripinvdata set Qty=@Qty,Remaining=@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                cmd.Parameters.Add("@invid", o.InvSno);
                                cmd.Parameters.Add("@Qty", o.ReceivedQty);
                                cmd.Parameters.Add("@Remaining", o.ReceivedQty);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert Into tripinvdata(Tripdata_Sno,invid,Qty,Remaining) values(@Tripdata_Sno,@invid,@Qty,@Remaining)");
                                    cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                    cmd.Parameters.Add("@invid", o.InvSno);
                                    int ReceivedQty = 0;
                                    int.TryParse(o.ReceivedQty, out ReceivedQty);
                                    cmd.Parameters.Add("@Qty", ReceivedQty);
                                    cmd.Parameters.Add("@Remaining", ReceivedQty);
                                    vdm.insert(cmd);
                                }
                                foreach (DataRow dr in dtPrevInventory.Rows)
                                {
                                    string invSno = o.InvSno;
                                    string pInvsno = dr["sno"].ToString();
                                    if (pInvsno == invSno)
                                    {
                                        float PIQty = 0;
                                        float.TryParse(dr["Qty"].ToString(), out PIQty);
                                        float DIQty = 0;
                                        float.TryParse(o.ReceivedQty, out DIQty);
                                        float TIQty = DIQty - PIQty;
                                        if (TIQty >= 1)
                                        {
                                            cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining+@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                            cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                            cmd.Parameters.Add("@invid", o.InvSno);
                                            cmd.Parameters.Add("@Remaining", TIQty);
                                            vdm.Update(cmd);
                                        }
                                        else
                                        {
                                            TIQty = Math.Abs(TIQty);
                                            cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining-@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                            cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                            cmd.Parameters.Add("@invid", o.InvSno);
                                            cmd.Parameters.Add("@Remaining", TIQty);
                                            vdm.Update(cmd);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("update tripdata set Status=@status where Status=@St  and  EmpId='" + EmpID + "'");
                        cmd.Parameters.Add("@status", 'C');
                        cmd.Parameters.Add("@St", 'A');
                        vdm.Update(cmd);
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        cmd = new MySqlCommand("insert into tripdata (EmpId,AssignDate,Status,Userdata_sno,Permissions,VehicleNo,I_Date,DEmpId,ATripid)values(@EmpId,@AssignDate,@status,@Userdata_sno,@Permissions,@VehicleNo,@I_Date,@DEmpId,@ATripid)");
                        //cmd.Parameters.Add("@Branch_id", BranchID);
                        //cmd.Parameters.Add("@TotalQty", Qty);
                        cmd.Parameters.Add("@Permissions", "D;C");
                        // cmd.Parameters.Add("@RouteId", RouteID);
                        //cmd.Parameters.Add("@RouteId", obj.routename);
                        cmd.Parameters.Add("@EmpId", EmpID);
                        cmd.Parameters.Add("@AssignDate", Currentdate);
                        cmd.Parameters.Add("@I_Date", dtDispDate);
                        cmd.Parameters.Add("@DEmpId", context.Session["PlantEmpId"].ToString());
                        cmd.Parameters.Add("@status", "A");
                        cmd.Parameters.Add("@VehicleNo", VehicleNo);
                        cmd.Parameters.Add("@Userdata_sno", context.Session["userdata_sno"]);
                        cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                        long Tripdata_Sno = vdm.insertScalar(cmd);
                        context.Session["TripIDSno"] = Tripdata_Sno;
                        //foreach (string word in words)
                        //{
                        cmd = new MySqlCommand("insert into triproutes(Tripdata_sno,RouteID)values(@tripdata_sno,@routeid) ");
                        cmd.Parameters.Add("@tripdata_sno", Tripdata_Sno);
                        cmd.Parameters.Add("@routeid", RouteId);
                        vdm.insert(cmd);

                        //}
                        foreach (orderdetail o in obj.data)
                        {
                            if (o.Productsno != null)
                            {
                                cmd = new MySqlCommand("insert into tripsubdata (Tripdata_Sno,ProductId,Qty,DeliverQty)values(@Tripdata_Sno,@ProductId,@Qty,@DeliverQty)");
                                cmd.Parameters.Add("@Tripdata_Sno", Tripdata_Sno);
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                float Dispqty = 0;
                                float.TryParse(o.RemainQty, out Dispqty);
                                cmd.Parameters.Add("@Qty", Dispqty);
                                float dispQty = 0;
                                cmd.Parameters.Add("@DeliverQty", dispQty);

                                if (Dispqty != 0.0)
                                {
                                    vdm.insert(cmd);
                                }
                                //cmd = new MySqlCommand("update branchproducts set manufact_remaining_qty=@manuftreming_qty where branch_sno=@bnchsno and product_sno=@pdtsno");
                                //cmd.Parameters.Add("@manuftreming_qty", Dispqty);
                                //cmd.Parameters.Add("@bnchsno", context.Session["CsoNo"].ToString());
                                //cmd.Parameters.Add("@pdtsno", o.Productsno);
                                //vdm.Update(cmd);
                                cmd = new MySqlCommand("Update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                cmd.Parameters.Add("@DeliverQty", Dispqty);
                                vdm.Update(cmd);
                            }
                        }
                        foreach (Inventorydetail o in obj.Inventorydetails)
                        {
                            if (o.InvSno != null)
                            {
                                cmd = new MySqlCommand("Insert Into tripinvdata(Tripdata_Sno,invid,Qty,Remaining) values(@Tripdata_Sno,@invid,@Qty,@Remaining)");
                                cmd.Parameters.Add("@Tripdata_Sno", Tripdata_Sno);
                                cmd.Parameters.Add("@invid", o.InvSno);
                                int ReceivedQty = 0;
                                int.TryParse(o.ReceivedQty, out ReceivedQty);
                                cmd.Parameters.Add("@Qty", ReceivedQty);
                                cmd.Parameters.Add("@Remaining", ReceivedQty);
                                vdm.insert(cmd);
                                cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining-@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@invid", o.InvSno);
                                cmd.Parameters.Add("@Remaining", o.ReceivedQty);
                                vdm.Update(cmd);
                            }
                        }
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    List<string> MsgList = new List<string>();
                    string msg = "Data Successfully Saved";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void GetDispProducts(HttpContext context)
        {
            try
            {
                DataTable dtTotalProducts = new DataTable();
                vdm = new VehicleDBMgr();
                string RouteId = context.Request["RouteId"];
                string IndentType = context.Request["IndentType"];
                if (IndentType == "")
                {
                    IndentType = "Indent1";
                }
                string txtDispDate = context.Session["DispDate"].ToString();
                DateTime Currentdate = Convert.ToDateTime(txtDispDate);
                string EmpID = context.Request["EmpID"];
                DataTable dtproductsdata = new DataTable();
                if (context.Session["dtproductsdata"] == null)
                {
                    cmd = new MySqlCommand("SELECT sno, ProductName FROM productsdata ORDER BY sno");
                    dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    dtproductsdata = (DataTable)context.Session["dtproductsdata"];
                }
                dtTotalProducts.Columns.Add("sno");
                dtTotalProducts.Columns.Add("ProductName");
                dtTotalProducts.Columns.Add("TotalQty");
                dtTotalProducts.Columns.Add("DispQty");
                foreach (DataRow dr in dtproductsdata.Rows)
                {
                    DataRow newRow = dtTotalProducts.NewRow();
                    newRow["sno"] = dr["sno"].ToString();
                    newRow["ProductName"] = dr["ProductName"].ToString();
                    newRow["TotalQty"] = "0";
                    newRow["DispQty"] = "0";
                    dtTotalProducts.Rows.Add(newRow);
                }
                cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName ,ROUND(tripsubdata.Qty,2) as subdataQty,ROUND(tripsubdata.DeliverQty,2) as DeliverQty  FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (triproutes.Tripdata_sno = @Tripdata_sno) AND (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId) GROUP BY productsdata.ProductName");
                cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                cmd.Parameters.Add("@EmpId", context.Session["PlantEmpId"].ToString());
                DataTable dtsubtrip = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT Sno FROM tripdata where I_Date between @d1 and @d2 and EmpID=@EmpID and Status=@Status");
                cmd.Parameters.Add("@Status", 'A');
                cmd.Parameters.Add("@EmpID", EmpID);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                DataTable dtTripID = vdm.SelectQuery(cmd).Tables[0];
                if (dtTripID.Rows.Count > 0)
                {
                    //if (context.Session["DispTripSno"] != null)
                    //{
                    //string  DispDate = context.Request["DispDate"];
                    //DateTime dtDispDate = Convert.ToDateTime(DispDate);

                    //cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.Qty, productsdata.sno FROM tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno where tripsubdata.Tripdata_sno=@Tripdata_sno");
                    cmd = new MySqlCommand("SELECT productsdata.ProductName, tripsubdata.Qty, productsdata.sno FROM tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN tripdata ON tripsubdata.Tripdata_sno = tripdata.Sno where tripsubdata.Tripdata_sno=@Tripdata_sno and tripdata.Status=@Status and tripdata.I_Date between @d1 and @d2 and tripdata.EmpId=@EmpId");
                    cmd.Parameters.Add("@Tripdata_sno", dtTripID.Rows[0]["Sno"].ToString());
                    cmd.Parameters.Add("@Status", 'A');
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                    cmd.Parameters.Add("@EmpId", EmpID);
                    DataTable dtTripSubData = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["dtTripSubData"] = dtTripSubData;
                    cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS TotalQty, productsdata.sno, indents_subtable.UnitCost, productsdata.ProductName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno WHERE (indents.I_date between @d1 AND @d2) AND (indents.IndentType = @IndentType) AND (dispatch.sno = @RouteID) GROUP BY productsdata.ProductName ORDER BY TotalQty");
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                    cmd.Parameters.Add("@RouteID", RouteId);
                    cmd.Parameters.Add("@IndentType", IndentType);
                    DataTable dtDispProducts = vdm.SelectQuery(cmd).Tables[0];
                    dtDispProducts.DefaultView.Sort = "sno ASC";
                    dtDispProducts = dtDispProducts.DefaultView.ToTable(true);
                    foreach (DataRow drDisp in dtDispProducts.Rows)
                    {
                        foreach (DataRow drtotprod in dtTotalProducts.Rows)
                        {

                            if (drDisp["sno"].ToString() == drtotprod["sno"].ToString())
                            {
                                float qty = 0;
                                float.TryParse(drDisp["TotalQty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drtotprod["TotalQty"].ToString(), out qtycpy);

                                float totalqty = qty + qtycpy;
                                //float total = 0;
                                //float.TryParse(drprdt["TotalQty"].ToString(), out total);
                                //float totqty = total + totalqty;
                                drtotprod["TotalQty"] = totalqty;
                            }
                            else
                            {
                            }
                        }
                    }

                    dtTotalProducts.DefaultView.Sort = "sno ASC";
                    dtTotalProducts = dtTotalProducts.DefaultView.ToTable(true);
                    foreach (DataRow drDisp in dtTotalProducts.Rows)
                    {
                        foreach (DataRow drtotprod in dtTripSubData.Rows)
                        {
                            if (drDisp["sno"].ToString() == drtotprod["sno"].ToString())
                            {
                                string dispqty = "";
                                dispqty = drtotprod["Qty"].ToString();
                                if (dispqty == "0")
                                {
                                    dispqty = "";
                                }
                                drDisp["DispQty"] = dispqty;
                            }
                            else
                            {
                            }
                        }
                    }

                    List<dispProducts> Displist = new List<dispProducts>();
                    int i = 1;
                    dtTotalProducts.DefaultView.Sort = "sno ASC";
                    dtTotalProducts = dtTotalProducts.DefaultView.ToTable(true);
                    dtsubtrip.DefaultView.Sort = "ProductId ASC";
                    dtsubtrip = dtsubtrip.DefaultView.ToTable(true);
                    foreach (DataRow dr in dtTotalProducts.Rows)
                    {
                        foreach (DataRow drsub in dtsubtrip.Rows)
                        {
                            if (dr["sno"].ToString() == drsub["ProductId"].ToString())
                            {
                                dispProducts getdispProducts = new dispProducts();
                                getdispProducts.sno = i++.ToString();
                                getdispProducts.ProductCode = dr["ProductName"].ToString();
                                getdispProducts.Productsno = dr["sno"].ToString();
                                getdispProducts.Qty = dr["TotalQty"].ToString();
                                float Qty = 0;
                                float.TryParse(dr["TotalQty"].ToString(), out Qty);
                                float subdataQty = 0;
                                float.TryParse(drsub["subdataQty"].ToString(), out subdataQty);
                                float DeliverQty = 0;
                                float.TryParse(drsub["DeliverQty"].ToString(), out DeliverQty);
                                float RemainQty = subdataQty - DeliverQty;
                                getdispProducts.RemainQty = RemainQty.ToString();
                                getdispProducts.DispQty = dr["DispQty"].ToString();
                                Displist.Add(getdispProducts);
                            }
                        }
                    }
                    string response = GetJson(Displist);
                    context.Response.Write(response);
                }
                else
                {
                    //cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty),2) AS TotalQty, productsdata.sno, indents_subtable.UnitCost, productsdata.ProductName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchroutes.Sno = @RouteID) and (indents.IndentType = @IndentType) GROUP BY productsdata.ProductName");
                    cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS TotalQty, productsdata.sno, indents_subtable.UnitCost, productsdata.ProductName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno WHERE (indents.I_date between @d1 AND @d2) AND (indents.IndentType = @IndentType) AND (dispatch.sno = @RouteID) GROUP BY productsdata.ProductName ORDER BY TotalQty");
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                    cmd.Parameters.Add("@RouteID", RouteId);
                    cmd.Parameters.Add("@IndentType", IndentType);
                    DataTable dtDispProducts = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow drDisp in dtDispProducts.Rows)
                    {
                        foreach (DataRow drtotprod in dtTotalProducts.Rows)
                        {

                            if (drDisp["sno"].ToString() == drtotprod["sno"].ToString())
                            {
                                float qty = 0;
                                float.TryParse(drDisp["TotalQty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drtotprod["TotalQty"].ToString(), out qtycpy);

                                float totalqty = qty + qtycpy;
                                //float total = 0;
                                //float.TryParse(drprdt["TotalQty"].ToString(), out total);
                                //float totqty = total + totalqty;
                                drtotprod["TotalQty"] = totalqty;
                            }
                            else
                            {
                            }
                        }
                    }
                    List<dispProducts> Displist = new List<dispProducts>();
                    int i = 1;
                    dtTotalProducts.DefaultView.Sort = "TotalQty desc";
                    dtTotalProducts = dtTotalProducts.DefaultView.ToTable(true);
                    context.Session["dtTripSubData"] = "";
                    foreach (DataRow dr in dtTotalProducts.Rows)
                    {
                        foreach (DataRow drsub in dtsubtrip.Rows)
                        {
                            if (dr["sno"].ToString() == drsub["ProductId"].ToString())
                            {
                                dispProducts getdispProducts = new dispProducts();
                                getdispProducts.sno = i++.ToString();
                                getdispProducts.ProductCode = dr["ProductName"].ToString();
                                getdispProducts.Productsno = dr["sno"].ToString();
                                getdispProducts.Qty = dr["TotalQty"].ToString();
                                float Qty = 0;
                                float.TryParse(dr["TotalQty"].ToString(), out Qty);
                                float subdataQty = 0;
                                float.TryParse(drsub["subdataQty"].ToString(), out subdataQty);
                                float DeliverQty = 0;
                                float.TryParse(drsub["DeliverQty"].ToString(), out DeliverQty);
                                float RemainQty = subdataQty - DeliverQty;
                                RemainQty = RemainQty - Qty;
                                getdispProducts.RemainQty = RemainQty.ToString();
                                string DispQty = "";
                                DispQty = dr["TotalQty"].ToString();
                                if (DispQty == "0")
                                {
                                    DispQty = "";
                                }
                                getdispProducts.DispQty = DispQty;
                                Displist.Add(getdispProducts);
                            }
                        }
                    }
                    string response = GetJson(Displist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        public class dispProducts
        {
            public string sno { get; set; }
            public string ProductCode { get; set; }
            public string RemainQty { get; set; }
            public string Productsno { get; set; }
            public string Qty { get; set; }
            public string DispQty { get; set; }
        }
        private void GetCsodispatchRoutes(HttpContext context)
        {
            try
            {
                if (context.Session["CsoNo"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    //cmd = new MySqlCommand("SELECT RouteName, Sno FROM branchroutes WHERE (BranchID = @BranchID) GROUP BY RouteName");
                    //cmd = new MySqlCommand("SELECT DispName, sno FROM dispatch WHERE (Branch_Id = @Branch_Id) GROUP BY DispName");
                    DataTable dtBranch = new DataTable();
                    if (context.Session["dtBranch"] == null)
                    {
                        cmd = new MySqlCommand("SELECT DispName, sno FROM dispatch WHERE (Branch_Id = @Branch_Id) GROUP BY DispName");
                        cmd.Parameters.Add("@Branch_Id", context.Session["CsoNo"].ToString());
                        dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtBranch = (DataTable)context.Session["dtBranch"];
                    }
                    List<Route> Routelist = new List<Route>();
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Route b = new Route() { rid = dr["sno"].ToString(), RouteName = dr["DispName"].ToString() };
                        Routelist.Add(b);
                    }
                    string response = GetJson(Routelist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetSOEmployeeNames(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DataTable dtEmployee = new DataTable();
                if (context.Session["dtBranch"] == null)
                {
                    cmd = new MySqlCommand("SELECT Sno, UserName FROM empmanage WHERE (Branch = @BranchID) and (Leveltype='Opperations')");
                    cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                    dtEmployee = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    dtEmployee = (DataTable)context.Session["dtBranch"];
                }
                List<Employee> Employeelist = new List<Employee>();
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    Employee b = new Employee() { Sno = dr["Sno"].ToString(), UserName = dr["UserName"].ToString() };
                    Employeelist.Add(b);
                }
                string response = GetJson(Employeelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class Employee
        {
            public string Sno { get; set; }
            public string UserName { get; set; }
        }
        private void GetIndentType(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string RouteId = "";
                if (context.Request["RouteId"] != "")
                {
                    RouteId = context.Request["RouteId"];
                }
                else
                {
                    RouteId = context.Session["RouteId"].ToString();
                }

                List<IndentClas> Indentlist = new List<IndentClas>();
                string leveltype = context.Session["Permissions"].ToString();
                if (leveltype == "Dispatcher")
                {
                    cmd = new MySqlCommand("SELECT dispatch_sub.IndentType FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch.sno = @sno) group by dispatch_sub.IndentType");
                    cmd.Parameters.Add("@sno", RouteId);
                    DataTable dtIndentType = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtIndentType.Rows)
                    {
                        string indent = dr["IndentType"].ToString();
                        if (indent != "")
                        {
                            IndentClas getIndentType = new IndentClas();
                            getIndentType.IndentType = dr["IndentType"].ToString();
                            Indentlist.Add(getIndentType);
                        }
                    }
                }
                else
                {
                    if (context.Session["routearray"] != null)
                    {
                        string[] routearray = (string[])context.Session["routearray"];

                        if (routearray != null)
                        {
                            if (routearray.Length > 1)
                            {

                                cmd = new MySqlCommand("SELECT dispatch_sub.IndentType FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch.Route_id = @Route_id) group by dispatch_sub.IndentType");
                                cmd.Parameters.Add("@Route_id", RouteId);
                                DataTable dtIndentType = vdm.SelectQuery(cmd).Tables[0];
                                foreach (DataRow dr in dtIndentType.Rows)
                                {
                                    string indent = dr["IndentType"].ToString();
                                    if (indent != "")
                                    {
                                        IndentClas getIndentType = new IndentClas();
                                        getIndentType.IndentType = dr["IndentType"].ToString();
                                        Indentlist.Add(getIndentType);
                                    }
                                }
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT dispatch_sub.IndentType FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch.sno = @dispatchSno) group by dispatch_sub.IndentType");
                            cmd.Parameters.Add("@dispatchSno", RouteId);
                            DataTable dtIndentType = vdm.SelectQuery(cmd).Tables[0];
                            foreach (DataRow dr in dtIndentType.Rows)
                            {
                                IndentClas getIndentType = new IndentClas();
                                getIndentType.IndentType = dr["IndentType"].ToString();
                                Indentlist.Add(getIndentType);
                            }
                        }
                    }
                }
                string response = GetJson(Indentlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class IndentClas
        {
            public string IndentType { get; set; }
        }

        private void GetDispatchBranch(HttpContext context)
        {
            try
            {
                if (context.Session["RouteId"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    string DispType = context.Session["DispType"].ToString();
                    if (DispType == "YES")
                    {
                        cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchdata.flag = @flag) and (branchmappingtable.SuperBranch=@BranchID)GROUP BY branchdata.BranchName");
                        cmd.Parameters.Add("@flag", 1);
                        cmd.Parameters.Add("@BranchID", context.Session["BranchSno"].ToString());
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch_sub.dispatch_sno = @dispatch_sno) and (branchdata.flag=@flag) GROUP BY branchdata.BranchName");
                        //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN  branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (triproutes.Tripdata_sno = @TripId) GROUP BY branchdata.BranchName");
                        //cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                        cmd.Parameters.Add("@flag", 1);
                        cmd.Parameters.Add("@dispatch_sno", context.Session["RouteId"].ToString());
                    }
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    List<Branch> brnch = new List<Branch>();
                    var i = 1;
                    foreach (DataRow dr in dtBranch.Rows)
                    {

                        Branch b = new Branch() { BrancID = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString(), Rank = i };
                        brnch.Add(b);
                        i++;
                    }
                    string response = GetJson(brnch);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        private void GetDispatchAgents(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string[] routearray = (string[])context.Session["routearray"];
                List<Route> Routelist = new List<Route>();
                if (routearray.Length > 1)
                {
                    string querycond = "";
                    for (int i = 0; i < routearray.Length; i++)
                    {
                        if (routearray[i] != "")
                        {
                            querycond += " dispatch.sno=" + routearray[i] + " or";
                        }
                    }
                    querycond = querycond.Substring(0, querycond.Length - 3);
                    cmd = new MySqlCommand("SELECT branchroutes.RouteName, branchroutes.Sno  FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutes ON dispatch.Route_id = branchroutes.Sno WHERE (triproutes.Tripdata_sno = @TripId) and (" + querycond + ")  GROUP BY branchroutes.RouteName");
                    cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                    //  cmd.Parameters.Add("@dispatchsno", querycond);
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Route b = new Route() { rid = dr["Sno"].ToString(), RouteName = dr["RouteName"].ToString() };
                        Routelist.Add(b);
                    }
                    string response = GetJson(Routelist);
                    context.Response.Write(response);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN  branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (triproutes.Tripdata_sno = @TripId) GROUP BY branchdata.BranchName");
                    cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    List<Branch> brnch = new List<Branch>();
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Branch b = new Branch() { BrancID = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString() };
                        brnch.Add(b);
                    }
                    string response = GetJson(brnch);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetIndentStatus(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                if (context.Session["RouteId"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteId = "";
                    if (context.Request["RouteId"] != "")
                    {
                        RouteId = context.Request["RouteId"];
                    }
                    else
                    {
                        RouteId = context.Session["RouteId"].ToString();
                    }
                    List<BranchStatus> BList = new List<BranchStatus>();
                    DataTable dtbranches = new DataTable();
                    string[] routearray = (string[])context.Session["routearray"];
                    List<Route> Routelist = new List<Route>();
                    if (routearray.Length > 1)
                    {
                        cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno, indents.IndentNo, indents.I_date FROM  branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id WHERE (branchroutes.Sno = @RouteId) AND (indents.I_date between @d1 AND  @d2)");
                        cmd.Parameters.Add("@RouteId", RouteId);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                        dtbranches = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {

                        cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName, indents.IndentNo FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN indents ON branchdata.sno = indents.Branch_id WHERE (triproutes.Tripdata_sno = @TripId) AND (dispatch_sub.dispatch_sno = @dispatch_sno) AND (indents.I_date between @d1 AND  @d2)GROUP BY branchdata.BranchName");
                        //cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno, indents.IndentNo, indents.I_date FROM  branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id WHERE (branchroutes.Sno = @RouteId) AND (indents.I_date > @d1) AND (indents.I_date < @d2)");
                        cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                        cmd.Parameters.Add("@dispatch_sno", RouteId);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                        dtbranches = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (dtbranches.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbranches.Rows)
                        {
                            //BranchStatus GetBranch = new BranchStatus();
                            //GetBranch.bid = dr["sno"].ToString();
                            //GetBranch.BName = dr["BranchName"].ToString();
                            BranchStatus b = new BranchStatus() { bid = dr["sno"].ToString(), BName = dr["BranchName"].ToString() };
                            BList.Add(b);
                        }
                        string response = GetJson(BList);
                        context.Response.Write(response);
                    }
                }
            }
            catch
            {
            }
        }
        class BranchStatus
        {
            public string bid { get; set; }
            public string BName { get; set; }
        }
        private void GetProductIndent(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string ProductId = context.Request["ProductSno"];
                cmd = new MySqlCommand("SELECT tripsubdata.Qty FROM triproutes INNER JOIN tripsubdata ON triproutes.Tripdata_sno = tripsubdata.Tripdata_sno where triproutes.RouteID=@RouteID and tripsubdata.ProductId=@ProductId");
                cmd.Parameters.Add("@RouteID", context.Session["RouteId"].ToString());
                cmd.Parameters.Add("@ProductId", ProductId);
                DataTable dtqty = vdm.SelectQuery(cmd).Tables[0];
                if (dtqty.Rows.Count > 0)
                {
                    string Indentqty = dtqty.Rows[0]["Qty"].ToString();
                    string response = GetJson(Indentqty);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void CollectionReports(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                //cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.AmountPaid FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON collections.Branchid = indents.Branch_id WHERE (branchroutes.Sno = @RouteId) AND (collections.PaidDate >= @starttime) AND (collections.PaidDate < @endtime) GROUP BY branchdata.BranchName");
                cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.AmountPaid, branchroutes.Sno FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON collections.Branchid = indents.Branch_id INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id WHERE (collections.tripid =@tripid) AND (dispatch_sub.dispatch_sno = @dispatch_sno) GROUP BY branchdata.BranchName, branchroutes.Sno, dispatch_sub.dispatch_sno");
                cmd.Parameters.Add("@dispatch_sno", context.Session["RouteId"].ToString());
                //cmd.Parameters.Add("@EmpSno", 27);
                cmd.Parameters.Add("@tripid", context.Session["TripID"].ToString());
                DataTable dtColectionBranchs = vdm.SelectQuery(cmd).Tables[0];
                List<BranchColection> BranchColectionlist = new List<BranchColection>();
                if (dtColectionBranchs.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtColectionBranchs.Rows)
                    {
                        BranchColection GetBranchColection = new BranchColection();
                        GetBranchColection.Sno = i++.ToString();
                        GetBranchColection.BranchName = dr["BranchName"].ToString();
                        GetBranchColection.BranchSno = dr["Branch_id"].ToString();
                        GetBranchColection.Amount = dr["AmountPaid"].ToString();
                        BranchColectionlist.Add(GetBranchColection);
                    }
                    string response = GetJson(BranchColectionlist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class BranchColection
        {
            public string Sno { get; set; }
            public string BranchName { get; set; }
            public string BranchSno { get; set; }
            public string Amount { get; set; }
        }
        private void getTodayDate(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);

                string bid = context.Request["bid"];
                cmd = new MySqlCommand("select I_date from Indents where Branch_id=@Branch_id and indents.I_date > @d1");
                cmd.Parameters.Add("@Branch_id", bid);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                DataTable indentDate = vdm.SelectQuery(cmd).Tables[0];
                DateTime date = (DateTime)indentDate.Rows[0]["I_date"];
                string IndentDate = date.ToString("dd/MM/yyyy");
                string Currentdate = GetTime(vdm.conn).ToString("dd/MM/yyyy");
                if (IndentDate == Currentdate)
                {
                    string IDate = IndentDate;
                    string response = GetJson(IDate);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        public static DateTime GetTime(MySqlConnection conn)
        {

            DataSet ds = new DataSet();
            DateTime dt = DateTime.Now;
            MySqlCommand cmd = new MySqlCommand("SELECT NOW()");
            cmd.Connection = conn;
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            conn.Open();
            //cmd.ExecuteNonQuery();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(ds, "Table");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = (DateTime)ds.Tables[0].Rows[0][0];
            }
            return dt;

        }
        private void getReportAmount(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["UserSno"] == null)
                {
                    string errmsg = "Session Expired";
                    MsgList.Add(errmsg);
                    string errresponse = GetJson(MsgList);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string EmpID = context.Session["UserSno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    //cmd = new MySqlCommand("SELECT collections.AmountPaid,branchData.branchName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN collections ON branchdata.sno = collections.Branchid WHERE (branchroutes.Sno = @RouteId) and(collections.Paiddate >= @starttime) AND (collections.Paiddate  < @endtime) GROUP BY branchdata.BranchName, collections.AmountPaid");
                    cmd = new MySqlCommand(" SELECT collections.AmountPaid, branchdata.BranchName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN collections ON branchdata.sno = collections.Branchid INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id WHERE (collections.PaidDate >= @starttime) AND (collections.PaidDate < @endtime) AND (dispatch_sub.dispatch_sno= @dispatch_sno)GROUP BY branchdata.BranchName, collections.AmountPaid");
                    cmd.Parameters.Add("@dispatch_sno", context.Session["RouteId"].ToString());
                    cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(ServerDateCurrentdate));
                    cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(ServerDateCurrentdate));
                    DataTable dtAmount = vdm.SelectQuery(cmd).Tables[0];
                    double Amount = 0;
                    if (dtAmount.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtAmount.Rows)
                        {
                            float Deliverytotal = 0;
                            float.TryParse(dr["AmountPaid"].ToString(), out Deliverytotal);
                            Amount += Math.Round(Deliverytotal, 2);
                        }
                    }
                    string response = GetJson(Amount);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetInvReport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["UserSno"] == null)
                {
                    string errmsg = "Session Expired";
                    MsgList.Add(errmsg);
                    string errresponse = GetJson(MsgList);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string EmpID = context.Session["UserSno"].ToString();
                    string LevelType = context.Session["LevelType"].ToString();

                    List<Inventoryclass> InventoryList = new List<Inventoryclass>();
                    if (LevelType == "Dispatcher")
                    {
                        //cmd = new MySqlCommand("SELECT invmaster.InvName,invmaster.sno,  SUM(invtransactions.TodayQty) AS Qty FROM  tripdata INNER JOIN invtransactions ON tripdata.Sno = invtransactions.TripID INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno WHERE (tripdata.Sno = @TripId)  GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                        cmd = new MySqlCommand("SELECT tripinvdata.invid, invmaster.InvName,tripinvdata.Qty, tripinvdata.Remaining FROM tripdata INNER JOIN tripinvdata ON tripdata.Sno = tripinvdata.Tripdata_sno INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (tripdata.Sno = @TripId)");
                        //cmd = new MySqlCommand("SELECT SUM(invtransactions.VQty) AS VQty, invtransactions.VarificationStatus, invtransactions.B_Inv_Sno, invmaster.InvName FROM invtransactions INNER JOIN tripdata ON invtransactions.VTripID = tripdata.Sno INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno WHERE  (invtransactions.VarificationStatus = 'V') AND (tripdata.Sno = @tripdataSno) GROUP BY invmaster.InvName, invtransactions.VTripID ORDER BY invmaster.sno");
                        cmd.Parameters.Add("@TripId", context.Session["PlantDispSno"].ToString());
                        DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];
                        DataTable dtCInventory = vdm.SelectQuery(cmd).Tables[0];
                        if (dtInventory.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in dtInventory.Rows)
                            {
                                foreach (DataRow drC in dtCInventory.Rows)
                                {
                                    if (dr["invid"].ToString() == drC["invid"].ToString())
                                    {
                                        Inventoryclass GetInventory = new Inventoryclass();
                                        GetInventory.Sno = i++.ToString();
                                        GetInventory.InventoryName = dr["InvName"].ToString();
                                        GetInventory.InventorySno = dr["invid"].ToString();
                                        GetInventory.Qty = dr["Remaining"].ToString();
                                        GetInventory.DispQty = dr["Qty"].ToString();
                                        GetInventory.DelQty = drC["Qty"].ToString();
                                        InventoryList.Add(GetInventory);
                                    }
                                }
                            }
                            string response = GetJson(InventoryList);
                            context.Response.Write(response);
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT tripinvdata.invid, invmaster.InvName,tripinvdata.Qty, tripinvdata.Remaining FROM tripdata INNER JOIN tripinvdata ON tripdata.Sno = tripinvdata.Tripdata_sno INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (tripdata.Sno = @TripId)");
                        cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                        DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];

                        DataTable dtCInventory = vdm.SelectQuery(cmd).Tables[0];
                        if (dtInventory.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in dtInventory.Rows)
                            {
                                foreach (DataRow drC in dtCInventory.Rows)
                                {
                                    if (dr["invid"].ToString() == drC["invid"].ToString())
                                    {
                                        Inventoryclass GetInventory = new Inventoryclass();
                                        GetInventory.Sno = i++.ToString();
                                        GetInventory.InventoryName = dr["InvName"].ToString();
                                        GetInventory.InventorySno = dr["invid"].ToString();
                                        GetInventory.Qty = dr["Remaining"].ToString();
                                        GetInventory.DispQty = dr["Qty"].ToString();
                                        GetInventory.DelQty = drC["Qty"].ToString();
                                        InventoryList.Add(GetInventory);
                                    }
                                }
                            }
                            string response = GetJson(InventoryList);
                            context.Response.Write(response);
                        }
                        //cmd = new MySqlCommand("SELECT invmaster.InvName,invmaster.sno, SUM(invtransactions.Qty) AS Qty FROM  tripdata INNER JOIN invtransactions ON tripdata.Sno = invtransactions.TripID INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno WHERE (tripdata.Sno = @TripId) AND (invtransactions.Status = @Status) GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                        //cmd.Parameters.Add("@Status", 'C');
                        //cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                        //DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];
                        //if (dtInventory.Rows.Count > 0)
                        //{
                        //    int i = 1;
                        //    foreach (DataRow dr in dtInventory.Rows)
                        //    {
                        //        Inventoryclass GetInventory = new Inventoryclass();
                        //        GetInventory.Sno = i++.ToString();
                        //        GetInventory.InventoryName = dr["InvName"].ToString();
                        //        GetInventory.InventorySno = dr["sno"].ToString();
                        //        GetInventory.Qty = dr["Qty"].ToString();
                        //        InventoryList.Add(GetInventory);
                        //    }
                        //    string response = GetJson(InventoryList);
                        //    context.Response.Write(response);
                        //}
                    }

                }
            }
            catch
            {
            }
        }
        private void AddBranchProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string ProductSno = context.Request["ProductSno"];
                string Rate = context.Request["Rate"];
                string bid = context.Request["bid"];
                cmd = new MySqlCommand("insert into branchproducts (branch_sno,product_sno,unitprice,flag,userdata_sno) values(@branch_sno,@product_sno,@unitprice,@flag,@userdata_sno)");
                cmd.Parameters.AddWithValue("@branch_sno", bid);
                cmd.Parameters.AddWithValue("@product_sno", ProductSno);
                float UnitPrice = 0;
                float.TryParse(Rate, out UnitPrice);
                cmd.Parameters.AddWithValue("@unitprice", UnitPrice);
                cmd.Parameters.AddWithValue("@flag", 1);
                cmd.Parameters.AddWithValue("@userdata_sno", 1);
                vdm.insert(cmd);
            }
            catch
            {
            }
        }
        private void FillCategeoryname(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    MsgList.Add(errmsg);
                    string errresponse = GetJson(MsgList);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string username = context.Session["userdata_sno"].ToString();
                    cmd = new MySqlCommand("select sno,Categoryname from products_category where flag=@flag and userdata_sno=@username");
                    cmd.Parameters.Add("@username", username);
                    cmd.Parameters.Add("@flag", "1");
                    List<Categoryclass> Categorylist = new List<Categoryclass>();
                    foreach (DataRow dr in vdm.SelectQuery(cmd).Tables[0].Rows)
                    {
                        Categoryclass getCategory = new Categoryclass();
                        getCategory.sno = dr["sno"].ToString();
                        getCategory.categoryname = dr["Categoryname"].ToString();
                        Categorylist.Add(getCategory);
                    }
                    if (context.Session["getbranchcategorynames"] == null)
                    {
                        cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno,products_subcategory.sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username");
                        cmd.Parameters.Add("@username", username);
                        DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["getbranchcategorynames"] = dt;
                    }
                    if (context.Session["getproductsnames"] == null)
                    {
                        cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.SubCat_sno, productsdata.ProductName, productsdata.Qty, productsdata.Units, productsdata.UnitPrice, productsdata.Flag, productsdata.UserData_sno, products_subcategory.SubCatName FROM products_subcategory RIGHT OUTER JOIN productsdata ON products_subcategory.sno = productsdata.SubCat_sno WHERE (products_subcategory.Flag <> 0) AND productsdata.UserData_sno=@username");
                        //cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username AND products_subcategory.userdata_sno=@username AND productsdata.UserData_sno=@username");
                        cmd.Parameters.Add("@username", username);
                        DataTable dt1 = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["getproductsnames"] = dt1;
                    }
                    string response = GetJson(Categorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class Categoryclass
        {
            public string sno { set; get; }
            public string categoryname { set; get; }
        }
        private void get_product_subcategory_data(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<subCategoryclass> subCategorylist = new List<subCategoryclass>();
                string username = context.Session["userdata_sno"].ToString();
                string catgryname = context.Request["cmbcatgryname"];
                DataTable categorys = new DataTable();
                if (context.Session["getbranchcategorynames"] == null)
                {
                    cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno,products_subcategory.sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username");
                    cmd.Parameters.Add("@username", username);
                    DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["getbranchcategorynames"] = dt;
                }
                else
                {
                    categorys = (DataTable)context.Session["getbranchcategorynames"];
                }
                DataTable subcatgrynames = categorys.DefaultView.ToTable(true, "category_sno", "SubCatName", "sno");
                DataRow[] subcatgry = subcatgrynames.Select("category_sno=" + catgryname + "");
                foreach (DataRow dr in subcatgry)
                {
                    subCategoryclass GetsubCategory = new subCategoryclass();
                    GetsubCategory.sno = dr["sno"].ToString();
                    GetsubCategory.subcategorynames = dr["SubCatName"].ToString();
                    subCategorylist.Add(GetsubCategory);
                }
                if (subCategorylist != null)
                {
                    string response = GetJson(subCategorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        class subCategoryclass
        {
            public string sno { set; get; }
            public string subcategorynames { set; get; }
            public string CatSno { set; get; }
        }
        private void get_products_data(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<ProductNames> ProductNamesList = new List<ProductNames>();
                string username = context.Session["userdata_sno"].ToString();
                string subcatname = context.Request["cmbsubcatgryname"];
                DataTable subcategorys = new DataTable();
                if (context.Session["getproductsnames"] == null)
                {
                    cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.SubCat_sno, productsdata.ProductName, productsdata.Qty, productsdata.Units, productsdata.UnitPrice, productsdata.Flag, productsdata.UserData_sno, products_subcategory.SubCatName FROM products_subcategory RIGHT OUTER JOIN productsdata ON products_subcategory.sno = productsdata.SubCat_sno WHERE (products_subcategory.Flag <> 0) AND productsdata.UserData_sno=@username");
                    cmd.Parameters.Add("@username", username);
                    DataTable dt1 = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["getproductsnames"] = dt1;
                }
                else
                {
                    subcategorys = (DataTable)context.Session["getproductsnames"];
                }
                DataTable productnames = subcategorys.DefaultView.ToTable(true, "SubCat_sno", "ProductName", "sno");
                DataRow[] products = productnames.Select("SubCat_sno=" + subcatname + "");
                foreach (DataRow dr in products)
                {
                    ProductNames GetProduct = new ProductNames();
                    GetProduct.productName = dr["ProductName"].ToString();
                    GetProduct.Sno = dr["sno"].ToString();
                    ProductNamesList.Add(GetProduct);
                }
                if (ProductNamesList != null)
                {
                    string response = GetJson(ProductNamesList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        public class ProductNames
        {
            public string productName { get; set; }
            public string Qty { get; set; }
            public string Sno { get; set; }
        }
        private void getBranchLeakeges(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string BranchID = context.Request["bid"];
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    MsgList.Add(errmsg);
                    string errresponse = GetJson(MsgList);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    List<Orderclass> OrderList = new List<Orderclass>();
                    cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno,indents_subtable.LeakQty, indents_subtable.unitQty,indents_subtable.UnitCost,indents_subtable.DeliveryQty, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND @d2) ");

                    //cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno,indents_subtable.LeakQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno,sum(indents_subtable.UnitCost*indents_subtable.unitQty) as Total, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date > @d1) AND (indents.I_date < @d2) ");
                    cmd.Parameters.Add("@UserName", Username);
                    //cmd.Parameters.Add("@IndentNo", IndentNo);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate.AddDays(-1)));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate.AddDays(-1)));
                    cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["Delivers"] = dtBranch;
                    int i = 1;
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Orderclass getOrderValue = new Orderclass();
                        getOrderValue.sno = i++.ToString();
                        getOrderValue.HdnSno = dr["Sno"].ToString();
                        getOrderValue.ProductCode = dr["ProductName"].ToString();
                        getOrderValue.IndentNo = dr["IndentNo"].ToString();
                        getOrderValue.Productsno = (int)dr["Product_sno"];
                        double qty = 0;
                        double.TryParse(dr["unitQty"].ToString(), out qty);
                        getOrderValue.Qty = Math.Round(qty, 2);
                        getOrderValue.Rate = (float)dr["UnitCost"];
                        string LeakQty = dr["LeakQty"].ToString();
                        if (LeakQty != "")
                        {
                            float Leak = 0;
                            float.TryParse(LeakQty, out Leak);
                            getOrderValue.LeakQty = Math.Round(Leak, 2);
                        }
                        else
                        {
                            getOrderValue.LeakQty = 0;
                        }
                        getOrderValue.Status = dr["Status"].ToString();
                        double Dqty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out Dqty);
                        double total = Dqty * (float)dr["UnitCost"];
                        getOrderValue.Total = Math.Round(total, 2);
                        float DelQty = 0;
                        float.TryParse(dr["DeliveryQty"].ToString(), out DelQty);
                        getOrderValue.DQty = Math.Round(DelQty, 2);
                        getOrderValue.orderunitRate = (float)dr["UnitCost"];
                        OrderList.Add(getOrderValue);
                    }
                    string respnceString = GetJson(OrderList);
                    context.Response.Write(respnceString);
                }
            }
            catch
            {
            }
        }

        private void GetInventoryNames(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Inventoryclass> InventoryList = new List<Inventoryclass>();
                DataTable dtInvMaster = new DataTable();
                if (context.Session["dtInvMaster"] == null)
                {
                    cmd = new MySqlCommand("SELECT InvName,sno from invmaster");
                    dtInvMaster = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    dtInvMaster = (DataTable)context.Session["dtInvMaster"];
                }
                if (dtInvMaster.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtInvMaster.Rows)
                    {
                        Inventoryclass GetInventory = new Inventoryclass();
                        GetInventory.Sno = i++.ToString();
                        GetInventory.InventoryName = dr["InvName"].ToString();
                        GetInventory.InventorySno = dr["sno"].ToString();
                        GetInventory.Qty = "";
                        InventoryList.Add(GetInventory);
                    }
                    string response = GetJson(InventoryList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetDeliverInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string BranchID = context.Request["bid"];
                string DairyStatus = context.Request["DairyStatus"];
                List<Inventoryclass> InventoryList = new List<Inventoryclass>();
                cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, invtransactions.Qty,invtransactions.TodayQty, inventory_monitor.Qty AS BranchQty FROM invmaster INNER JOIN invtransactions ON invmaster.sno = invtransactions.B_Inv_Sno INNER JOIN inventory_monitor ON invtransactions.BranchId = inventory_monitor.BranchId WHERE (inventory_monitor.BranchId = @BranchId) AND (invtransactions.Status =@Status)  AND (invtransactions.TripID = @TripID)GROUP BY invmaster.InvName,invtransactions.Status");
                // cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, invtransactions.Qty, invtransactions.TodayQty, inventory_monitor.Qty AS BranchQty, invtransactions.B_Inv_Sno FROM invmaster INNER JOIN invtransactions ON invmaster.sno = invtransactions.B_Inv_Sno INNER JOIN inventory_monitor ON invtransactions.B_Inv_Sno = inventory_monitor.Inv_Sno WHERE (inventory_monitor.BranchId = @BranchId) AND (invtransactions.Status = @Status) AND (invtransactions.TripID = @TripID) GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                if (DairyStatus == "Delivers")
                {
                    cmd.Parameters.Add("@Status", 'D');
                }
                else
                {
                    cmd.Parameters.Add("@Status", 'C');
                }
                cmd.Parameters.Add("@BranchId", BranchID);
                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                DataTable dtPrevInventory = vdm.SelectQuery(cmd).Tables[0];
                if (dtPrevInventory.Rows.Count > 0)
                {

                    dtPrevInventory.DefaultView.Sort = "sno ASC";
                    dtPrevInventory = dtPrevInventory.DefaultView.ToTable(true);
                    context.Session["dtPrevInventory"] = dtPrevInventory;
                    int i = 1;
                    foreach (DataRow dr in dtPrevInventory.Rows)
                    {
                        Inventoryclass Inventoryget = new Inventoryclass();
                        Inventoryget.Sno = i++.ToString();
                        Inventoryget.InventorySno = dr["sno"].ToString();
                        Inventoryget.InventoryName = dr["InvName"].ToString();
                        if (DairyStatus == "Delivers")
                        {
                            int TodayQty = 0;
                            int.TryParse(dr["TodayQty"].ToString(), out TodayQty);
                            int qty = 0;
                            int.TryParse(dr["Qty"].ToString(), out qty);
                            int ToadayQty = qty - TodayQty;
                            Inventoryget.Qty = ToadayQty.ToString();
                            Inventoryget.ToadayQty = dr["TodayQty"].ToString();
                        }
                        else
                        {
                            int qty = 0;
                            int.TryParse(dr["TodayQty"].ToString(), out qty);
                            int Bqty = 0;
                            int.TryParse(dr["BranchQty"].ToString(), out Bqty);
                            Bqty = Math.Abs(Bqty);
                            int ToadayQty = Bqty + qty;
                            Inventoryget.Qty = ToadayQty.ToString();
                            Inventoryget.ToadayQty = dr["TodayQty"].ToString();
                        }
                        InventoryList.Add(Inventoryget);
                    }
                    string response = GetJson(InventoryList);
                    context.Response.Write(response);
                }
                else
                {
                    context.Session["dtPrevInventory"] = null;
                    cmd = new MySqlCommand("SELECT invmaster.InvName, inventory_monitor.Qty, inventory_monitor.Sno, inventory_monitor.Inv_Sno FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno WHERE (inventory_monitor.BranchId = @BranchId)");
                    cmd.Parameters.Add("@BranchId", BranchID);
                    DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];

                    if (dtInventory.Rows.Count == 0)
                    {
                        if (context.Session["dtInventory"] == null)
                        {
                            cmd = new MySqlCommand("SELECT sno,InvName FROM invmaster");
                            dtInventory = vdm.SelectQuery(cmd).Tables[0];
                        }
                        else
                        {
                            dtInventory = (DataTable)context.Session["dtInventory"];
                        }
                        int i = 1;
                        foreach (DataRow dr in dtInventory.Rows)
                        {
                            Inventoryclass Inventoryget = new Inventoryclass();
                            Inventoryget.Sno = i++.ToString();
                            Inventoryget.InventorySno = dr["sno"].ToString();
                            Inventoryget.InventoryName = dr["InvName"].ToString();
                            Inventoryget.Qty = "0";
                            Inventoryget.ToadayQty = "";
                            InventoryList.Add(Inventoryget);
                        }
                        string response = GetJson(InventoryList);
                        context.Response.Write(response);
                    }
                    else
                    {
                        int i = 1;
                        foreach (DataRow dr in dtInventory.Rows)
                        {
                            Inventoryclass GetInventory = new Inventoryclass();
                            GetInventory.Sno = i++.ToString();
                            GetInventory.InventoryName = dr["InvName"].ToString();
                            GetInventory.InventorySno = dr["Inv_Sno"].ToString();
                            GetInventory.Qty = dr["Qty"].ToString();
                            GetInventory.ToadayQty = "";
                            InventoryList.Add(GetInventory);
                        }
                        string response = GetJson(InventoryList);
                        context.Response.Write(response);
                    }
                }
            }
            catch
            {
            }
        }
        public class Inventoryclass
        {
            public string Sno { get; set; }
            public string InventoryName { get; set; }
            public string InventorySno { get; set; }
            public string Qty { get; set; }
            public string DispQty { get; set; }
            public string DelQty { get; set; }
            public string ToadayQty { get; set; }
        }
        private void GetProductNamechange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string Sno = context.Request["ProductSno"];
                string BranchID = context.Request["BranchID"];
                List<ProductUnit> ProductList = new List<ProductUnit>();
                cmd = new MySqlCommand("SELECT branchproducts.unitprice, branchproducts.product_sno, productsdata.Qty, productsdata.Units FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) and (branchproducts.product_sno=@sno)");
                cmd.Parameters.Add("@sno", Sno);
                cmd.Parameters.Add("@BranchID", BranchID);
                DataTable dtBranchProduct = vdm.SelectQuery(cmd).Tables[0];
                string AunitPrice = "0";
                if (dtBranchProduct.Rows.Count > 0)
                {
                    AunitPrice = dtBranchProduct.Rows[0]["unitprice"].ToString();
                }
                if (AunitPrice == "0")
                {
                    cmd = new MySqlCommand("SELECT productsdata.UnitPrice,productsdata.Qty, productsdata.Units, branchproducts.product_sno, branchproducts.unitprice AS Bunitprice , productsdata.ProductName FROM productsdata INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch WHERE (branchmappingtable.SubBranch = @BranchID) AND (branchproducts.product_sno = @Sno)");
                    cmd.Parameters.Add("@sno", Sno);
                    cmd.Parameters.Add("@BranchID", BranchID);
                    DataTable dtProduct = vdm.SelectQuery(cmd).Tables[0];
                    ProductUnit GetProduct = new ProductUnit();
                    GetProduct.UnitPrice = dtProduct.Rows[0]["UnitPrice"].ToString();
                    GetProduct.Unitqty = dtProduct.Rows[0]["Qty"].ToString();
                    GetProduct.Units = dtProduct.Rows[0]["Units"].ToString();
                    string BranchUnitPrice = dtProduct.Rows[0]["BUnitPrice"].ToString();
                    float Rate = 0;
                    if (BranchUnitPrice != "0")
                    {
                        Rate = (float)dtProduct.Rows[0]["BUnitPrice"];
                    }
                    else
                    {
                        Rate = (float)dtProduct.Rows[0]["UnitPrice"];
                    }
                    //float Rate = (float)dtProduct.Rows[0]["UnitPrice"];
                    float Unitqty = (float)dtProduct.Rows[0]["Qty"];
                    float TotalRate = 0;
                    if (dtProduct.Rows[0]["Units"].ToString() == "ml")
                    {
                        TotalRate = Rate;
                    }
                    if (dtProduct.Rows[0]["Units"].ToString() == "ltr")
                    {
                        TotalRate = Rate;
                    }
                    if (dtProduct.Rows[0]["Units"].ToString() == "gms")
                    {
                        TotalRate = Rate;
                    }
                    if (dtProduct.Rows[0]["Units"].ToString() == "kgs")
                    {
                        TotalRate = Rate;
                    }
                    if (dtProduct.Rows[0]["Units"].ToString() == "ml" || dtProduct.Rows[0]["Units"].ToString() == "ltr")
                    {
                        GetProduct.Desciption = "Ltrs";
                    }
                    else
                    {
                        GetProduct.Desciption = "Kgs";
                    }
                    //getOrderValue.Rate = (float)Rate;
                    GetProduct.orderunitRate = (float)TotalRate;
                    ProductList.Add(GetProduct);
                    string response = GetJson(ProductList);
                    context.Response.Write(response);
                }
                else
                {
                    ProductUnit GetProduct = new ProductUnit();
                    GetProduct.UnitPrice = dtBranchProduct.Rows[0]["UnitPrice"].ToString();
                    GetProduct.Unitqty = dtBranchProduct.Rows[0]["Qty"].ToString();
                    GetProduct.Units = dtBranchProduct.Rows[0]["Units"].ToString();
                    float Rate = (float)dtBranchProduct.Rows[0]["UnitPrice"];
                    float Unitqty = (float)dtBranchProduct.Rows[0]["Qty"];
                    float TotalRate = 0;
                    if (dtBranchProduct.Rows[0]["Units"].ToString() == "ml")
                    {
                        TotalRate = Rate;
                    }
                    if (dtBranchProduct.Rows[0]["Units"].ToString() == "ltr")
                    {
                        TotalRate = Rate;
                    }
                    if (dtBranchProduct.Rows[0]["Units"].ToString() == "gms")
                    {
                        TotalRate = Rate;
                    }
                    if (dtBranchProduct.Rows[0]["Units"].ToString() == "kgs")
                    {
                        TotalRate = Rate;
                    }
                    if (dtBranchProduct.Rows[0]["Units"].ToString() == "ml" || dtBranchProduct.Rows[0]["Units"].ToString() == "ltr")
                    {
                        GetProduct.Desciption = "Ltrs";
                    }
                    else
                    {
                        GetProduct.Desciption = "Kgs";
                    }
                    //getOrderValue.Rate = (float)Rate;
                    GetProduct.orderunitRate = (float)TotalRate;
                    ProductList.Add(GetProduct);
                    string response = GetJson(ProductList);
                    context.Response.Write(response);
                }
                //}
            }
            catch
            {
            }
        }
        public class ProductUnit
        {
            public string UnitPrice { get; set; }
            public string Unitqty { get; set; }
            public string Units { get; set; }
            public float orderunitRate { get; set; }
            public string Desciption { get; set; }

        }

        private void getBranchValuesamount(HttpContext context)
        {
        }
        public class AmontClass
        {
            public string IndentNo { get; set; }
            public double TodayAmount { get; set; }
            public string TotalAmount { get; set; }
        }
        private void btnRemarksSaveClick(string jsonString, HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    MsgList.Add(errmsg);
                    string errresponse = GetJson(MsgList);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    //var js = new JavaScriptSerializer();
                    //var title1 = context.Request.Params[1];
                    //Orders obj = js.Deserialize<Orders>(title1);

                    var js = new JavaScriptSerializer();
                    Orders obj = js.Deserialize<Orders>(jsonString);
                    //List<Orders> Reportlist = new List<Orders>();
                    string Remarks = obj.Remarks;
                    string Denominations = obj.Denominations;
                    context.Session["Remarks"] = Remarks;
                    context.Session["Denominations"] = Denominations;
                    context.Session["colAmount"] = obj.ColAmount;
                    context.Session["SubAmount"] = obj.SubAmount;

                    //SendSMS(context);
                    string msg = "Reporting Submitted";
                    string response = GetJson(msg);
                    context.Response.Write(response);

                }
            }
            catch
            {
            }
        }
        //private void SendSMS(HttpContext context)
        //{
        //    try
        //    {
        //        vdm = new VehicleDBMgr();

        //    }
        //    catch
        //    {

        //    }
        //}
        private void CollectionSaveClick(HttpContext context)
        {

        }
        private void btnOrderSaveClick(HttpContext context)
        {

        }
        private void btnDeliversSaveClick(HttpContext context)
        {

        }
        class ReportResult
        {
            public string sno { set; get; }
            public string BranchName { set; get; }
            public string IndentNo { set; get; }
            public string TotalQty { set; get; }
            public string TotalPrice { set; get; }
            public string IndentDate { set; get; }
            public string Status { set; get; }
            public string DeliveryDate { set; get; }
        }
        private void getOrders_f_t_dates(HttpContext context)
        {
            List<ReportResult> rr = new List<ReportResult>();
            vdm = new VehicleDBMgr();
            List<string> MsgList = new List<string>();
            if (context.Session["userdata_sno"] == null)
            {
                string errmsg = "Session Expired";
                MsgList.Add(errmsg);
                string errresponse = GetJson(MsgList);
                context.Response.Write(errresponse);
            }
            else
            {
                string Username = context.Session["userdata_sno"].ToString();
                string FromDate = context.Request["fdate"];
                string ToDate = context.Request["tdate"];
                string BranchId = context.Request["bid"];
                cmd = new MySqlCommand("SELECT branchdata.BranchName, indents.IndentNo, indents.TotalQty, indents.TotalPrice, indents.I_date AS IndentDate, indents.Status, indents.D_date  FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno WHERE (indents.UserData_sno = @udsno) AND (indents.I_date between @d1 AND  @d2) and(branchdata.sno=@BranchId)");
                // cmd = new MySqlCommand("SELECT branchdata.BranchName, indents.IndentNo, indents.TotalQty, indents.TotalPrice, indents.I_date AS IndentDate, indents.Status, indents_subtable.D_date FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE (indents.UserData_sno = @udsno) AND (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchdata.sno = @BranchId)");
                cmd.Parameters.Add("@udsno", Username);
                cmd.Parameters.Add("@d1", FromDate);
                cmd.Parameters.Add("@d2", ToDate);
                cmd.Parameters.Add("@BranchId", BranchId);
                DataTable result = vdm.SelectQuery(cmd).Tables[0];
                int i = 1;
                foreach (DataRow dr in result.Rows)
                {
                    ReportResult r_result = new ReportResult();
                    r_result.sno = i++.ToString();
                    r_result.BranchName = dr["BranchName"].ToString();
                    r_result.IndentNo = dr["IndentNo"].ToString();
                    r_result.TotalQty = dr["TotalQty"].ToString();
                    r_result.TotalPrice = dr["TotalPrice"].ToString();
                    r_result.IndentDate = dr["IndentDate"].ToString();
                    if (dr["status"].ToString() == "o")
                        r_result.Status = "Orderd";
                    else
                        r_result.Status = "Delivered";

                    r_result.DeliveryDate = dr["D_date"].ToString();
                    rr.Add(r_result);
                }
                string response = GetJson(rr);
                context.Response.Write(response);
            }
        }

        VehicleDBMgr vdm;
        MySqlCommand cmd;


        class Branch
        {
            public string BrancID { set; get; }
            public string BranchName { set; get; }
            public int Rank { set; get; }
        }
        class Route
        {
            public string rid { set; get; }
            public string RouteName { set; get; }
        }


        private void GetRouteNameChange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Branch> brnch = new List<Branch>();
                string TripID = context.Request["TripId"];
                context.Session["TripID"] = TripID;
                //cmd = new MySqlCommand("select sno, BranchName from branchdata where userdata_sno=@UserName");
                //string LevelType = context.Session["LevelType"].ToString();
                //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM empmanage INNER JOIN branchmappingtable ON empmanage.Branch = branchmappingtable.SuperBranch INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno WHERE (empmanage.Sno = @UserSno)");
                cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (branchroutes.Sno = @TripID)");
                cmd.Parameters.Add("@TripID", TripID);
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtBranch.Rows)
                {
                    Branch b = new Branch() { BrancID = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString() };
                    brnch.Add(b);
                }
                string response = GetJson(brnch);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void getBranchValues(HttpContext context)
        {

        }

        public class Orderclass
        {
            public string HdnSno { set; get; }
            public string sno { set; get; }
            public string ProductCode { set; get; }
            public int Productsno { set; get; }
            public double Qty { set; get; }
            public float Rate { set; get; }
            public double Total { set; get; }
            public string Status { set; get; }
            public string IndentNo { set; get; }
            public string Units { set; get; }
            public string Unitqty { set; get; }
            public string Desciption { set; get; }
            public string orderunitqty { set; get; }
            public float orderunitRate { set; get; }
            public double LeakQty { set; get; }
            public double DQty { set; get; }
            public double RQty { set; get; }
            public double TRQty { set; get; }
            public double PrevQty { set; get; }
        }
        public class redirecturl
        {
            public string responseurl { set; get; }
        }

        private static string GetJson(object obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(obj);
        }
    }
}