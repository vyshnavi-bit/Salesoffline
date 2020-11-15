<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" manifest="Cache85.manifest">
<head id="Head1" runat="server">
    <title>Vyshnavi Dairy</title>
    <link rel="icon" href="Images/VLogo.png" type="image/x-icon" title="Vyshnavi.net" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="mobile-web-app-capable" content="yes">
    <meta name="HandheldFriendly" content="True" />
   <%-- <script src="Js/jquery.js" type="text/javascript"></script>--%>
    <script src="Js/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="Js/JTemplate.js" type="text/javascript"></script>
    <script src="Js/jquery.blockUI.js" type="text/javascript"></script>
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <link href="Css/VyshnaviStyles.css" rel="stylesheet" type="text/css" />
    <link href="MobileCss/Scripts/default.css" rel="stylesheet" type="text/css" />
    <link href="MobileCss/Scripts/style.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery.blockUI.js" type="text/javascript"></script>
    <link href="MobileCss/Styles/Mobile.css" rel="stylesheet" type="text/css" />
    <link href="MobileCss/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Styles/Style.css" />
    <script src="Js/date.format.js" type="text/javascript"></script>
    <script src="Js/jSignature.js" type="text/javascript"></script>
    <script src="Js/jSignature.CompressorBase30.js" type="text/javascript"></script>
    <script src="Js/jSignature.CompressorSVG.js" type="text/javascript"></script>
    <script src="Js/jSignature.UndoButton.js" type="text/javascript"></script>
    <script src="Js/signhere/jSignature.SignHere.js" type="text/javascript"></script>
    <%--<script src="Js/modernizr.js" type="text/javascript"></script>--%>


    <style type="text/css">
        
        input[type=number]::-webkit-inner-spin-button, input[type=number]::-webkit-outer-spin-button
        {
            -webkit-appearance: none;
            margin: 0;
        }
        .divselectedclass
        {
            border: 1px solid gray;
            padding-top: 2px;
            padding-bottom: 2px;
        }
        .back-red
        {
            background-color: #ffffcc;
        }
        .back-white
        {
            background-color: #ffffff;
        }
        .btnUp
        {
            height: 41px;
            width: 41px;
            background-image: url(Images/Up.png);
            background-repeat: no-repeat;
        }
        .btnDown
        {
            height: 41px;
            width: 41px;
            background-image: url(Images/Down.png);
            background-repeat: no-repeat;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var myVar = setInterval(function () { checkInternet() }, 2000);
            LoadLogin();
            OfflineTest();
        });
    </script>
    <script type="text/javascript">
        function checkInternet() {
            var online = window.navigator.onLine;
            if (!online) {
                document.getElementById('txtInternet').innerHTML = "Please check your internet connection and try again";
                $('#txtInternet').css('color', 'Red');
            }
            else {
                document.getElementById('txtInternet').innerHTML = "Internet connection available";
                $('#txtInternet').css('color', 'Green');
            }
        }
        function ClearData() {
            if (!confirm("Do you want clear data")) {
                return false;
            }
            if (!confirm("Data will be deleted")) {
                return false;
            }
            document.getElementById('txtUserName').disabled = false;
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('DROP  Table IndentData1');                            
                tx.executeSql('DROP  Table OrderOffline1');                      
                tx.executeSql('DROP  Table Inventory');                          
                tx.executeSql('DROP  Table ReturnInventory1');                   
                tx.executeSql('DROP  Table BranchAmount2');                      
                tx.executeSql('DROP  Table LoginDetails');                       
                tx.executeSql('DROP Table branchdata1');                         
                tx.executeSql('DROP  Table branchroutes');                       
                tx.executeSql('DROP Table dispatch');                            
                tx.executeSql('DROP Table empmanage');                           
                tx.executeSql('DROP Table invmaster');                           
                tx.executeSql('DROP Table leakages');                            
                tx.executeSql('DROP Table products_category');                   
                tx.executeSql('DROP Table products_subcategory');                
                tx.executeSql('DROP Table productsdata');                        
                tx.executeSql('DROP Table tripdata1');                           
                tx.executeSql('DROP Table tripsubdata1');                        
                tx.executeSql('DROP Table tripinvdata');                         
                tx.executeSql('DROP Table branchproducts1');                     
                tx.executeSql('DROP Table SalesOfficebranchproducts1');          
                tx.executeSql('DROP Table Leakreport');                          
                tx.executeSql('DROP Table InventoryReport1');                    
                tx.executeSql('DROP Table StatusTable');                         
                tx.executeSql('DROP Table OfferProducts');                       
                tx.executeSql('DROP Table OfferIndent');                         
                tx.executeSql('DROP Table OfferIndentOffline');

                                                      
                                                                                 
                loginStatus = "";
                document.getElementById('txtUserName').value = "";
                document.getElementById('lblOfflineMsg').innerHTML = "Please Login Online";
                $('#lblOfflineMsg').css('color', 'Red');
                //                OfflineTest();
                window.location.reload();
            });
        }
    </script>
    <script type="text/javascript">
        var loginStatus = "";
        function OfflineTest() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = ""; 
                        document.getElementById('txtUserName').value = "";
                        document.getElementById('txtroutename').value = "";
                        document.getElementById('lblOfflineMsg').innerHTML = "Please Login Online";
                        $('#lblOfflineMsg').css('color', 'Red');
                    }
                    else {
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            UserName = obj.UserName;
                            Permissions = obj.Permissions;
                            count = obj.count;
                        }
                        if (UserName == "") {
                            loginStatus = "";
                            document.getElementById('txtUserName').value = "";
                            document.getElementById('txtroutename').value = "";
                            document.getElementById('lblOfflineMsg').innerHTML = "Please Login Online";
                            $('#lblOfflineMsg').css('color', 'Red');
                        }
                        else {
                            loginStatus = "OFFLINE";
                            document.getElementById('txtUserName').value = UserName;
                            document.getElementById('lblOfflineMsg').innerHTML = "Ready to work offline";
                            $('#lblOfflineMsg').css('color', 'Green');
                            document.getElementById('txtUserName').disabled = true;
                        }
                    }
                });
            });
        }
        function LoadLogin() {
            $('#divback').css('display', 'none');
            $('#divHide').css('display', 'none');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            $('#divLogOut').css('display', 'none');
            $('#divWelcome').css('display', 'none');
            $('#divFillScreen').removeTemplate();
            $('#divFillScreen').setTemplateURL('Login92.htm');
            $('#divFillScreen').processTemplate();
        }
        var db = null;
        function createtable() {
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (t) {
                    t.executeSql('DROP TABLE IF EXISTS IndentData1');                              
                    t.executeSql('DROP TABLE IF EXISTS OrderOffline1');                            
                    t.executeSql('DROP TABLE IF EXISTS Inventory');                                
                    t.executeSql('DROP TABLE IF EXISTS ReturnInventory1');                         
                    t.executeSql('DROP TABLE IF EXISTS BranchAmount');                             
                    t.executeSql('DROP TABLE IF EXISTS BranchAmount2');                            
                    t.executeSql('DROP TABLE IF EXISTS LoginDetails');                             
                    t.executeSql('DROP TABLE IF EXISTS branchdata1');                              
                    t.executeSql('DROP TABLE IF EXISTS branchroutes');                             
                    t.executeSql('DROP TABLE IF EXISTS dispatch');                                 
                    t.executeSql('DROP TABLE IF EXISTS empmanage');                                
                    t.executeSql('DROP TABLE IF EXISTS invmaster');                                
                    t.executeSql('DROP TABLE IF EXISTS leakages');                                 
                    t.executeSql('DROP TABLE IF EXISTS products_category');                        
                    t.executeSql('DROP TABLE IF EXISTS products_subcategory');                     
                    t.executeSql('DROP TABLE IF EXISTS productsdata');                             
                    t.executeSql('DROP TABLE IF EXISTS tripdata1');                                
                    t.executeSql('DROP TABLE IF EXISTS tripsubdata1');                             
                    t.executeSql('DROP TABLE IF EXISTS tripinvdata');                              
                    t.executeSql('DROP TABLE IF EXISTS branchproducts1');                          
                    t.executeSql('DROP TABLE IF EXISTS SalesOfficebranchproducts1');               
                    t.executeSql('DROP TABLE IF EXISTS Leakreport');                               
                    t.executeSql('DROP TABLE IF EXISTS InventoryReport1');                         
                    t.executeSql('DROP TABLE IF EXISTS StatusTable');                              
                    t.executeSql('DROP TABLE IF EXISTS OfferProducts');                            
                    t.executeSql('DROP TABLE IF EXISTS OfferIndent');                              
                    t.executeSql('DROP TABLE IF EXISTS OfferIndentOffline');

                    t.executeSql('DROP TABLE IF EXISTS IndentData1');
                    t.executeSql('DROP TABLE IF EXISTS OrderOffline1');
                    t.executeSql('DROP TABLE IF EXISTS Inventory');
                    t.executeSql('DROP TABLE IF EXISTS ReturnInventory1');
                    t.executeSql('DROP TABLE IF EXISTS BranchAmount');
                    t.executeSql('DROP TABLE IF EXISTS BranchAmount2');
                    t.executeSql('DROP TABLE IF EXISTS LoginDetails');
                    t.executeSql('DROP TABLE IF EXISTS branchdata1');
                    t.executeSql('DROP TABLE IF EXISTS branchroutes');
                    t.executeSql('DROP TABLE IF EXISTS dispatch');
                    t.executeSql('DROP TABLE IF EXISTS empmanage');
                    t.executeSql('DROP TABLE IF EXISTS invmaster');
                    t.executeSql('DROP TABLE IF EXISTS leakages');
                    t.executeSql('DROP TABLE IF EXISTS products_category');
                    t.executeSql('DROP TABLE IF EXISTS products_subcategory');
                    t.executeSql('DROP TABLE IF EXISTS productsdata');
                    t.executeSql('DROP TABLE IF EXISTS tripdata1');
                    t.executeSql('DROP TABLE IF EXISTS tripsubdata1');
                    t.executeSql('DROP TABLE IF EXISTS tripinvdata');
                    t.executeSql('DROP TABLE IF EXISTS branchproducts1');
                    t.executeSql('DROP TABLE IF EXISTS SalesOfficebranchproducts1');
                    t.executeSql('DROP TABLE IF EXISTS Leakreport');
                    t.executeSql('DROP TABLE IF EXISTS InventoryReport1');
                    t.executeSql('DROP TABLE IF EXISTS StatusTable');
                    t.executeSql('DROP TABLE IF EXISTS OfferProducts');
                    t.executeSql('DROP TABLE IF EXISTS OfferIndent');
                    t.executeSql('DROP TABLE IF EXISTS OfferIndentOffline');

                    t.executeSql('CREATE TABLE IF NOT EXISTS IndentData1 (UserID TEXT,BranchName Text,BrancID TEXT,IndentType Text, ProductId TEXT,ProductName Text,Categoryname Text, UnitQty TEXT,UnitCost TEXT, DeliverQty TEXT, Status TEXT,DtripID TEXT,IDate TEXT,Ddate TEXT ,LeakQty TEXT,IndentNo TEXT,Rank INT,EditMode TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS OrderOffline1 (BrancID TEXT,IndentType Text, ProductId TEXT,ProductName Text, UnitQty TEXT,UnitCost TEXT,OrderQty TEXT,SyncStatus TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS Inventory (InventorySno TEXT,InventoryName Text,Qty TEXT,ToadayQty Text, BrancID TEXT,Status TEXT,EditMode TEXT,DInvDate TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS ReturnInventory1 (InventorySno TEXT,InventoryName Text,Qty TEXT,ToadayQty Text, BrancID TEXT,EditM TEXT,Status TEXT,CInvDate TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS BranchAmount2 (BrancID TEXT,Amount TEXT,PayType TEXT,TodayAmount TEXT,checkNo TEXT,BalanceAmount TEXT,Cdate TEXT,ReturnDenomonation TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS LoginDetails (PlantEmpId TEXT,PlantDispSno  TEXT,DispDate Text,Permissions TEXT,Salestype TEXT,BranchSno TEXT, CsoNo INTEGER,TripID INTEGER,RouteId  INTEGER,Sno  TEXT, UserSno TEXT,TripdataSno TEXT, AssignDate TEXT,I_Date TEXT ,count TEXT, UserName TEXT,Password TEXT,LevelType TEXT,UserData_sno TEXT,Date TEXT,SyncStatus TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS branchdata1 (Sno TEXT,BranchName TEXT,Rank TEXT,Sign TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS branchroutes (Sno TEXT, RouteName TEXT, BranchID TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS dispatch (sno TEXT, DispName TEXT ,Branch_Id TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS empmanage (Sno TEXT, UserName TEXT, Password TEXT, LevelType TEXT, Branch TEXT, EmpName TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS invmaster (sno INTEGER, InvName TEXT ,Userdata_sno INTEGER ,flag TEXT, Qty REAL)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS leakages (Sno TEXT, ShortQty TEXT, ProductID TEXT, LeakQty TEXT, ReturnQty TEXT, FreeMilk TEXT,ProductName TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS products_category (sno TEXT, categoryname TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS products_subcategory (sno TEXT, category_sno TEXT, subcategorynames TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS productsdata (sno TEXT, SubCat_sno TEXT, ProductName TEXT, Units TEXT, UnitPrice TEXT, Rank TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS tripdata1 (Sno TEXT,Remarks TEXT, Denominations TEXT, CollectedAmount TEXT, SubmittedAmount TEXT,AmountStatus TEXT )');
                    t.executeSql('CREATE TABLE IF NOT EXISTS tripsubdata1 (ProductId TEXT, Qty TEXT, DeliverQty TEXT,ProductName TEXT,Rank INT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS tripinvdata (invid TEXT, Qty TEXT, Remaining TEXT, InvName TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS branchproducts1 (branch_sno TEXT, product_sno TEXT, unitprice TEXT,ProductName TEXT,Rank TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS SalesOfficebranchproducts1 (branch_sno TEXT, product_sno TEXT, unitprice TEXT,ProductName TEXT,Rank TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS Leakreport (product_sno TEXT, ReturnQty TEXT,LeakQty TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS InventoryReport1 (InvId TEXT, SubQty TEXT,InventoryStatus TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS StatusTable (BranchID TEXT,Indent TEXT,Delivery TEXT,Collection TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS OfferProducts (BranchID TEXT,ProductId TEXT,ProductName Text,IDOffersAssignment Text)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS OfferIndent (BranchID TEXT,IndentType Text,IndentNo TEXT,UnitPrice TEXT,ProductId TEXT,ProductName Text,Indent TEXT,Delivery TEXT)');
                    t.executeSql('CREATE TABLE IF NOT EXISTS OfferIndentOffline (BranchID TEXT,IndentType Text,Productid TEXT,ProductName TEXT,IndentQty TEXT,UnitPrice TEXT,OrderQty TEXT,SyncStatus TEXT)');
                });
            }
        }
        function Authenticate() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (t) {
                online = window.navigator.onLine;
                if (!online) {
                }
                else {
                    if (loginStatus != "OFFLINE") {
                        createtable();
                    }
                }
            });
            LoginDetails();
            ChangeBackColortripdata();
            ChangeBackColorInventoryReport();
        }
        function BingOffBranch() {
            var Branches = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM branchdata1 Order by Rank', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        Branches.push({ BrancID: obj.Sno, BranchName: obj.BranchName, Rank: obj.Rank });
                    }
                    Branches.sort(function (a, b) { return a.Rank - b.Rank });
                    BindBranchName(Branches);
                });
            });
        }
        var BackColortripdata = "true";
        var BtnBackColor = "true";
        function ChangeBackColortripdata() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM tripdata1', [], function (tx, results) {
                    var len = results.rows.length;
                    if (BackColortripdata == "true") {
                        document.getElementById("btnReporting").style.backgroundColor = "#59FA87";
                        document.getElementById("btnAgentOrder").style.backgroundColor = "#59FA87";
                        document.getElementById("btnOfflineIndent").style.backgroundColor = "#59FA87";
                        if (len == "0") {
                            document.getElementById("btnSynctoDB").style.backgroundColor = "#FA7E75";
                            document.getElementById("btnSynctoDB").disabled = true;
                            document.getElementById("btndeliveries").disabled = false;
                            document.getElementById("btncollections").disabled = false;
                            document.getElementById("btnShortage").disabled = false;
                            document.getElementById("btndeliveries").style.backgroundColor = "#59FA87";
                            document.getElementById("btncollections").style.backgroundColor = "#59FA87";
                            document.getElementById("btnShortage").style.backgroundColor = "#59FA87";
                            document.getElementById("ddlBranchName").disabled = false;
                            BackColortripdata = "true";
                            BtnBackColor = "false";
                            ChangeBackColorInventoryReport();
                            return false;
                        }
                        else {
                            document.getElementById("btnSynctoDB").style.backgroundColor = "#59FA87";
                            document.getElementById("btnSynctoDB").disabled = false;
                            document.getElementById("btndeliveries").disabled = true;
                            document.getElementById("btncollections").disabled = true;
                            document.getElementById("btnShortage").disabled = true;
                            document.getElementById("btndeliveries").style.backgroundColor = "#FA7E75";
                            document.getElementById("btncollections").style.backgroundColor = "#FA7E75";
                            document.getElementById("btnShortage").style.backgroundColor = "#FA7E75";
                            document.getElementById("ddlBranchName").disabled = true;
                            BackColortripdata = "false";
                            BtnBackColor = "true";
                            ChangeBackColorInventoryReport();
                            return false;
                        }

                    }
                    else {
                        return false;
                        BtnBackColor = "false";
                    }
                });
            });
        }
        //Green=#59FA87 //Red=#FA7E75
        function ChangeBackColorInventoryReport() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM InventoryReport1', [], function (tx, results) {
                    var len = results.rows.length;
                    document.getElementById("btnReporting").style.backgroundColor = "#59FA87";
                    document.getElementById("btnAgentOrder").style.backgroundColor = "#59FA87";
                    document.getElementById("btnOfflineIndent").style.backgroundColor = "#59FA87";
                    if (len == "0") {
                        document.getElementById("btnSynctoDB").style.backgroundColor = "#FA7E75";
                        document.getElementById("btnSynctoDB").disabled = true;
                        document.getElementById("btndeliveries").disabled = false;
                        document.getElementById("btncollections").disabled = false;
                        document.getElementById("btnShortage").disabled = false;
                        document.getElementById("btndeliveries").style.backgroundColor = "#59FA87";
                        document.getElementById("btncollections").style.backgroundColor = "#59FA87";
                        document.getElementById("btnShortage").style.backgroundColor = "#59FA87";
                        document.getElementById("ddlBranchName").disabled = false;
                        BackColortripdata = "false";
                        BtnBackColor = "false";
                        return false;
                    }
                    else {
                        if (BtnBackColor == "false") {
                            document.getElementById("btnSynctoDB").style.backgroundColor = "#FA7E75";
                            document.getElementById("btnSynctoDB").disabled = true;
                        }
                        else {
                            document.getElementById("btnSynctoDB").style.backgroundColor = "#59FA87";
                            document.getElementById("btnSynctoDB").disabled = false;
                        }
                        document.getElementById("btndeliveries").disabled = true;
                        document.getElementById("btncollections").disabled = true;
                        document.getElementById("btnShortage").disabled = true;
                        document.getElementById("btndeliveries").style.backgroundColor = "#FA7E75";
                        document.getElementById("btncollections").style.backgroundColor = "#FA7E75";
                        document.getElementById("btnShortage").style.backgroundColor = "#FA7E75";
                        document.getElementById("ddlBranchName").disabled = true;
                        BackColortripdata = "false";
                        BtnBackColor = "true";
                        return false;
                    }
                });
            });
        }
        function divSyncDeliversclick() {
            var online = window.navigator.onLine;
            if (!online) {
                //                alert("Please Connect To Internet");
                $('#divMsgAlert').css('display', 'block');
                document.getElementById('lblAlertMsg').innerHTML = "Please Connect To Internet";
                document.getElementById("imgAlert").src = "Images/Alert.png";
                document.getElementById("lblAlertMsg").style.color = '#FA7E75';
            }
            else {
                if (!confirm("Do you want to Syncdata Online")) {
                    return false;
                }
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            UserName = obj.UserName;
                            Permissions = obj.Permissions;
                            count = obj.count;
                            var UserData_sno = obj.count;
                            var UserSno = obj.UserSno;
                            var LevelType = obj.LevelType;
                            var AssignDate = obj.AssignDate;
                            var I_Date = obj.I_Date;
                            var RouteId = obj.RouteId;
                            var TripdataSno = obj.TripdataSno;
                            var TripID = obj.TripID;
                            var Salestype = obj.Salestype;
                            var BranchSno = obj.BranchSno;
                            var data = { 'op': 'GetOfflineLogin', 'UserName': UserName, 'UserData_sno': UserData_sno, 'UserSno': UserSno, 'LevelType': LevelType, 'AssignDate': AssignDate, 'I_Date': I_Date, 'count': count, 'RouteId': RouteId, 'TripdataSno': TripdataSno, 'TripID': TripID, 'Permissions': Permissions, 'Salestype': Salestype, 'BranchSno': BranchSno };
                            var s = function (msg) {
                                if (msg) {
                                    if (msg == "Success") {
                                        DeliversOfflineSaveclick();
                                    }
                                    else {
                                        $('#divMsgAlert').css('display', 'block');
                                        document.getElementById('lblAlertMsg').innerHTML = msg;
                                        document.getElementById("imgAlert").src = "Images/Alert.png";
                                        document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                                    }
                                }
                                else {
                                }
                            };
                            var e = function (x, h, e) {
                            };
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                            callHandler(data, s, e);
                        }
                    });
                });
            }
        }

        function DeliversOfflineSaveclick() {
            var SyncStatus = "";
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM tripdata1', [], function (tx, results) {
                    var Tripdata_len = results.rows.length;
                    if (Tripdata_len == "0") {
                        alert("Please Submitt Amount Reporting");
                        return false;
                    }
                    else {
                        for (var amt = 0; amt < Tripdata_len; amt++) {
                            var obj = results.rows.item(amt);
                            var AmountStatus = obj.AmountStatus;
                            if (AmountStatus == "N") {
                                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                                db.transaction(function (tx) {
                                    tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                                        var Login_len = results.rows.length;
                                        for (var LD = 0; LD < Login_len; LD++) {
                                            var objstats = results.rows.item(LD);
                                            SyncStatus = objstats.SyncStatus;
                                            if (SyncStatus == "S") {
                                                alert("Data already Sync");
                                                return false;
                                            }
                                            else {
                                                var Deliverdetails = [];
                                                var OfferDeliverdetails = [];
                                                var Inventorydetails = [];
                                                var Amountdetails = [];
                                                var CollectedInventorydetails = [];
                                                var Dispdetails = [];
                                                var OrderDetails = [];
                                                var RouteLeakdetails = [];
                                                var InvDatails = [];
                                                var Agentsigdetails = [];
                                                var OfferOrderDatails = [];

                                                online = window.navigator.onLine;
                                                if (!online) {
                                                }
                                                else {
                                                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                                                    db.transaction(function (tx) {//Deliverdetails db start
                                                        tx.executeSql('SELECT * FROM IndentData1', [], function (tx, results) {//Deliverdetails tx start
                                                            var indlen = results.rows.length;
                                                            for (var idt = 0; idt < indlen; idt++) {
                                                                var idtresult = results.rows.item(idt);
                                                                if (idtresult.Status == "Delivered") {
                                                                    Deliverdetails.push({ SNo: idt + 1, Product: idtresult.ProductName, ProductSno: idtresult.ProductId, Returnqty: idtresult.DeliverQty, Status: idtresult.Status, IndentNo: idtresult.IndentNo, hdnSno: idt + 1, HdnIndentSno: idtresult.IndentNo, orderunitRate: idtresult.UnitCost, LeakQty: idtresult.LeakQty, RemainQty: idtresult.LeakQty, BranchID: idtresult.BrancID, DelDate: idtresult.Ddate });
                                                                }
                                                            }

                                                            db.transaction(function (tx) {//OfferDeliverdetails db start
                                                                tx.executeSql('SELECT * FROM OfferIndent', [], function (tx, results) {//OfferDeliverdetails tx start
                                                                    var indlen = results.rows.length;
                                                                    for (var idt = 0; idt < indlen; idt++) {
                                                                        var idtresult = results.rows.item(idt);
                                                                        OfferDeliverdetails.push({ SNo: idt + 1, Product: idtresult.ProductName, Productsno: idtresult.ProductId, ReturnQty: idtresult.Delivery, IndentNo: idtresult.IndentNo, orderunitRate: idtresult.UnitPrice, BranchID: idtresult.BranchID });
                                                                    }

                                                                    db.transaction(function (tx) {//Inventorydetails db start
                                                                        tx.executeSql('SELECT * FROM Inventory', [], function (tx, results) {//Inventorydetails tx start
                                                                            var len = results.rows.length;
                                                                            for (var i = 0; i < len; ++i) {
                                                                                var obj = results.rows.item(i);
                                                                                if (obj.Status == "D") {
                                                                                    if (obj.ToadayQty != "") {
                                                                                        Inventorydetails.push({ SNo: i + 1, InvSno: obj.InventorySno, GivenQty: obj.ToadayQty, BalanceQty: obj.Qty, BrancID: obj.BrancID, DInvDate: obj.DInvDate });
                                                                                    }
                                                                                }
                                                                            } //for ends


                                                                            db.transaction(function (tx) {//Amountdetails db start
                                                                                tx.executeSql('SELECT * FROM BranchAmount2', [], function (tx, results) {//Amountdetails tx start
                                                                                    var len = results.rows.length;
                                                                                    for (var i = 0; i < len; i++) {
                                                                                        var obj = results.rows.item(i);
                                                                                        Amountdetails.push({ SNo: i + 1, BrancID: obj.BrancID, Amount: obj.Amount, PayType: obj.PayType, TodayAmount: obj.TodayAmount, checkNo: obj.checkNo, BalanceAmount: obj.BalanceAmount, Coldate: obj.Cdate, ReturnDenomonation: obj.ReturnDenomonation });
                                                                                    }

                                                                                    db.transaction(function (tx) {//collectedinventory db start
                                                                                        tx.executeSql('SELECT * FROM ReturnInventory1', [], function (tx, results) {//collectedinventory tx start
                                                                                            var len = results.rows.length;
                                                                                            for (var i = 0; i < len; ++i) {
                                                                                                var obj = results.rows.item(i);
                                                                                                if (obj.Status == "C") {
                                                                                                    if (obj.ToadayQty != "") {
                                                                                                        CollectedInventorydetails.push({ SNo: i + 1, InvSno: obj.InventorySno, GivenQty: obj.ToadayQty, BalanceQty: obj.Qty, BrancID: obj.BrancID, CInvDate: obj.CInvDate });
                                                                                                    }
                                                                                                }
                                                                                            }

                                                                                            db.transaction(function (tx) {//Leak Details db start
                                                                                                tx.executeSql('SELECT * FROM leakages', [], function (tx, results) {//Leak Details tx start
                                                                                                    var len = results.rows.length;
                                                                                                    for (var i = 0; i < len; i++) {
                                                                                                        var obj = results.rows.item(i);
                                                                                                        var LeakQty = obj.LeakQty;
                                                                                                        var ShortQty = obj.ShortQty;
                                                                                                        var FreeMilk = obj.FreeMilk;
                                                                                                        if (LeakQty == "0" && ShortQty == "0" && FreeMilk == "0") {
                                                                                                        }
                                                                                                        else {
                                                                                                            Dispdetails.push({ SNo: i + 1, Productsno: obj.ProductID, LeakQty: obj.LeakQty, ShortQty: obj.ShortQty, FreeMilk: obj.FreeMilk });
                                                                                                        }
                                                                                                    }

                                                                                                    db.transaction(function (tx) {//indent Details db start
                                                                                                        tx.executeSql('SELECT * FROM OrderOffline1 ', [], function (tx, results) {//indent Details tx start
                                                                                                            var len = results.rows.length;
                                                                                                            for (var i = 0; i < len; ++i) {
                                                                                                                var obj = results.rows.item(i);
                                                                                                                var OrderQty = obj.OrderQty;
                                                                                                                if (OrderQty == "" || OrderQty == null) {
                                                                                                                    OrderQty = "0";
                                                                                                                }
                                                                                                                if (OrderQty == "0") {
                                                                                                                }
                                                                                                                else {
                                                                                                                    OrderDetails.push({ Productsno: obj.ProductId, Unitsqty: obj.OrderQty, BranchID: obj.BrancID, IndentType: obj.IndentType, UnitCost: obj.UnitCost });
                                                                                                                }
                                                                                                            }

                                                                                                            db.transaction(function (tx) {//Offer indent Details db start
                                                                                                                var OfferSyncStatus = 0;

                                                                                                                tx.executeSql('SELECT * FROM OfferIndentOffline where SyncStatus= "' + OfferSyncStatus + '" ', [], function (tx, results) {//Offer indent Details tx start
                                                                                                                    var len = results.rows.length;
                                                                                                                    for (var i = 0; i < len; ++i) {
                                                                                                                        var obj = results.rows.item(i);
                                                                                                                        var OrderQty = obj.OrderQty;
                                                                                                                        if (OrderQty == "" || OrderQty == null) {
                                                                                                                            OrderQty = "0";
                                                                                                                        }
                                                                                                                        if (OrderQty == "0") {
                                                                                                                        }
                                                                                                                        else {
                                                                                                                            OfferOrderDatails.push({ Productsno: obj.Productid, Unitsqty: obj.OrderQty, BranchID: obj.BranchID, IndentType: obj.IndentType, UnitCost: obj.UnitCost });
                                                                                                                            OfferSyncStatus = 1;
                                                                                                                            tx.executeSql('UPDATE OfferIndentOffline SET SyncStatus="' + OfferSyncStatus + '" where  Productid = "' + obj.Productid + '" and BranchID="' + obj.BranchID + '" ');
                                                                                                                        }
                                                                                                                    }

                                                                                                                    db.transaction(function (tx) {//RouteLeak Details db start
                                                                                                                        tx.executeSql('SELECT * FROM Leakreport', [], function (tx, results) {//RouteLeak Details tx start
                                                                                                                            var len = results.rows.length;
                                                                                                                            for (var i = 0; i < len; i++) {
                                                                                                                                var obj = results.rows.item(i);
                                                                                                                                RouteLeakdetails.push({ ProductID: obj.product_sno, ReturnsQty: obj.ReturnQty, LeaksQty: obj.LeakQty });
                                                                                                                            }

                                                                                                                            db.transaction(function (tx) {//ReturnInventory details db start
                                                                                                                                tx.executeSql('SELECT * FROM InventoryReport1', [], function (tx, results) {//ReturnInventory details tx start
                                                                                                                                    var len = results.rows.length;
                                                                                                                                    for (var i = 0; i < len; i++) {
                                                                                                                                        var obj = results.rows.item(i);
                                                                                                                                        InvDatails.push({ SNo: obj.InvId, Qty: obj.SubQty });
                                                                                                                                    }
                                                                                                                                    var Remarks = "";
                                                                                                                                    var Denominations = "";
                                                                                                                                    var ColAmount = "";
                                                                                                                                    var SubAmount = "";
                                                                                                                                    db.transaction(function (tx) {//final tripend details db start
                                                                                                                                        tx.executeSql('SELECT * FROM tripdata1', [], function (tx, results) {//final tripend details tx start
                                                                                                                                            var len = results.rows.length;
                                                                                                                                            for (var i = 0; i < len; i++) {
                                                                                                                                                var obj = results.rows.item(i);
                                                                                                                                                Remarks = obj.Remarks;
                                                                                                                                                Denominations = obj.Denominations;
                                                                                                                                                ColAmount = obj.CollectedAmount;
                                                                                                                                                SubAmount = obj.SubmittedAmount;

                                                                                                                                            }

                                                                                                                                            db.transaction(function (tx) {//AgentSignature details db start
                                                                                                                                                tx.executeSql('SELECT * FROM branchdata1', [], function (tx, results) {//AgentSignature details tx start
                                                                                                                                                    var len = results.rows.length;
                                                                                                                                                    for (var i = 0; i < len; ++i) {
                                                                                                                                                        var obj = results.rows.item(i);
                                                                                                                                                        Agentsigdetails.push({ SNo: i + 1, BrancID: obj.Sno, Sign: obj.Sign });

                                                                                                                                                    }

                                                                                                                                                    var Branch = "";
                                                                                                                                                    var Data = { 'op': 'Product_SyncData', 'BranchID': Branch, 'data': Deliverdetails, 'OfferDeliveryData': OfferDeliverdetails, 'Inventorydetails': Inventorydetails, 'Amountdetail': Amountdetails, 'CInventorydetail': CollectedInventorydetails, 'Leakagedetails': Dispdetails, 'NextIndentdetail': OrderDetails, 'OfferNextIndentdetail': OfferOrderDatails, 'InvDatails': InvDatails, 'RouteLeakdetails': RouteLeakdetails, 'Remarks': Remarks, 'Denominations': Denominations, 'ColAmount': ColAmount, 'SubAmount': SubAmount, 'Signaturedetail': Agentsigdetails, 'end': 'Y' };
                                                                                                                                                    var s = function (ProductSyncmsg) {
                                                                                                                                                        CompareProducts();
                                                                                                                                                    };
                                                                                                                                                    var e = function (x, h, e) {
                                                                                                                                                        synccomplete();
                                                                                                                                                    };
                                                                                                                                                    CallHandlerUsingJson_POST(Data, s, e);

                                                                                                                                                }); //AgentSignature details tx end
                                                                                                                                            }); //AgentSignature details db end

                                                                                                                                        }); //final tripend details tx end
                                                                                                                                    }); //final tripend details db end

                                                                                                                                }); //ReturnInventory details tx end
                                                                                                                            }); //ReturnInventory details db end


                                                                                                                        }); //RouteLeak Details tx end
                                                                                                                    }); //RouteLeak Details db end

                                                                                                                }); //Offer indent Details tx end
                                                                                                            }); //Offer indent Details db end
                                                                                                        }); //indent Details tx end
                                                                                                    }); //indent Details db end


                                                                                                }); //Leak Details tx end
                                                                                            }); //Leak Details db end

                                                                                        }); //collectedinventory tx end
                                                                                    }); //collectedinventory db end

                                                                                }); //Amountdetails tx end
                                                                            }); //Amountdetails db end


                                                                        }); //Inventorydetails tx end
                                                                    }); //Inventorydetails db end

                                                                }); //OfferDeliverdetails tx end
                                                            }); //OfferDeliverdetails db end

                                                        }); //Deliverdetails tx end
                                                    }); //Deliverdetails db end


                                                } //else condition ends
                                            }
                                        } //for loop ends 
                                    }); //tx.executesql LoginDetails Ends
                                }); //db LoginDetails Ends
                            } //if condition AmountStatus==N Ends
                            else {
                                alert("Please Submitt Amount Reporting");
                                return false;
                            }
                        } //for loop ends
                    } //Else End
                });
            });
        }
        
        function DeliveryInventorySyncclick() {
            var Inventorydetails = [];
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM Inventory', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            if (obj.Status == "D") {
                                if (obj.ToadayQty != "") {
                                    Inventorydetails.push({ SNo: i + 1, InvSno: obj.InventorySno, GivenQty: obj.ToadayQty, BalanceQty: obj.Qty, BrancID: obj.BrancID, DInvDate: obj.DInvDate });
                                }
                            }
                        } //for ends
                        var Branch = "";

                        if (Inventorydetails.length > 0) {
                            for (var k = 0; k < Inventorydetails.length; k++) {
                                var Data = { 'op': 'Inventory_SyncData', 'BranchID': Branch, 'Inventory_detail': Inventorydetails[k], 'end': 'N' };
                                if (k == Inventorydetails.length - 1) {
                                    Data = { 'op': 'Inventory_SyncData', 'BranchID': Branch, 'Inventory_detail': Inventorydetails[k], 'end': 'Y' };
                                }
                                var s = function (msg) {
                                    if (msg == 'Y') {
                                        divSyncCollectionsclick();
                                    }
                                };
                                var e = function (x, h, e) {
                                };
                                CallHandlerUsingJson(Data, s, e);
                            }
                        }
                        else {
                            divSyncCollectionsclick();
                        }
                    }); //db.executesql ends
                }); //db.transaction ends
            } //else end
        }

        function divSyncCollectionsclick() {
            var Amountdetails = [];
            //var CollectedInventorydetails = [];
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM BranchAmount2', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; i++) {
                            var obj = results.rows.item(i);
                            Amountdetails.push({ SNo: i + 1, BrancID: obj.BrancID, Amount: obj.Amount, PayType: obj.PayType, TodayAmount: obj.TodayAmount, checkNo: obj.checkNo, BalanceAmount: obj.BalanceAmount, Coldate: obj.Cdate, ReturnDenomonation: obj.ReturnDenomonation });
                        }


                        var Branch = "";
                        if (Amountdetails.length > 0) {
                            for (var b = 0; b < Amountdetails.length; b++) {
                                var Data = { 'op': 'Amount_SyncData', 'BranchID': Branch, 'Amount_detail': Amountdetails[b], 'end': 'N' };
                                if (b == Amountdetails.length - 1) {
                                    Data = { 'op': 'Amount_SyncData', 'BranchID': Branch, 'Amount_detail': Amountdetails[b], 'end': 'Y' };
                                }
                                var s = function (msg) {
                                    if (msg == 'Y') {
                                        divSyncInventoryCollection();
                                    }

                                };
                                var e = function (x, h, e) {
                                };
                                CallHandlerUsingJson(Data, s, e);
                            }
                        }
                        else {
                            divSyncInventoryCollection();
                        }
                    });
                });
            }
        }
        
        function divSyncInventoryCollection() {
            var CollectedInventorydetails = [];
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM ReturnInventory1', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            if (obj.Status == "C") {
                                if (obj.ToadayQty != "") {
                                    CollectedInventorydetails.push({ SNo: i + 1, InvSno: obj.InventorySno, GivenQty: obj.ToadayQty, BalanceQty: obj.Qty, BrancID: obj.BrancID, CInvDate: obj.CInvDate });
                                }
                            }
                        }
                        var Branch = "";
                        if (CollectedInventorydetails.length > 0) {
                            for (var k = 0; k < CollectedInventorydetails.length; k++) {
                                var Data = { 'op': 'Collection_Inventory_SyncData', 'BranchID': Branch, 'Inventory_detail': CollectedInventorydetails[k], 'end': 'N' };
                                if (k == CollectedInventorydetails.length - 1) {
                                    Data = { 'op': 'Collection_Inventory_SyncData', 'BranchID': Branch, 'Inventory_detail': CollectedInventorydetails[k], 'end': 'Y' };
                                }
                                var s = function (msg) {
                                    if (msg == 'Y') {
                                        SaveofflineLeaks();
                                    }
                                };
                                var e = function (x, h, e) {
                                };
                                CallHandlerUsingJson(Data, s, e);
                            }
                        }
                        else {
                            SaveofflineLeaks();
                        }
                    });
                });
            }
        }

        function SaveofflineLeaks() {
            var Dispdetails = new Array();
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM leakages', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var LeakQty = obj.LeakQty;
                        var ShortQty = obj.ShortQty;
                        var FreeMilk = obj.FreeMilk;
                        if (LeakQty == "0" && ShortQty == "0" && FreeMilk == "0") {
                        }
                        else {
                            Dispdetails.push({ SNo: i + 1, Productsno: obj.ProductID, LeakQty: obj.LeakQty, ShortQty: obj.ShortQty, FreeMilk: obj.FreeMilk });
                        }
                    }
                    if (Dispdetails.length > 0) {
                        var Data = { 'op': 'btnShoratageSaveClick', 'data': Dispdetails, 'end': 'N' };
                        var s = function (msg) {
                            if (msg == 'Y') {
                                SaveofflineReturnleakReport();
                            }
                            else {
                            }
                        };
                        var e = function (x, h, e) {
                        };
                        $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                        //CallHandlerUsingJson(Data, s, e);
                        CallHandlerUsingJson_POST(Data, s, e);

                    }
                    else {
                        SaveofflineReturnleakReport();
                    }
                });
            });
        }

        function SaveofflineReturnleakReport() {
            var RouteLeakdetails = [];
            var InvDatails = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM Leakreport', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        RouteLeakdetails.push({ ProductID: obj.product_sno, ReturnsQty: obj.ReturnQty, LeaksQty: obj.LeakQty });
                    }

                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        tx.executeSql('SELECT * FROM InventoryReport1', [], function (tx, results) {
                            var len = results.rows.length;
                            for (var i = 0; i < len; i++) {
                                var obj = results.rows.item(i);
                                InvDatails.push({ SNo: obj.InvId, Qty: obj.SubQty });
                            }

                            var data = { 'op': 'btnReportingInventoryclick', 'InvDatails': InvDatails, 'RouteLeakdetails': RouteLeakdetails, 'end': 'N' };
                            var s = function (msg) {
                                if (msg == 'Y') {
                                    FinalReport();
                                }
                                else {
                                }
                            };
                            var e = function (x, h, e) {
                            };
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                           // CallHandlerUsingJson(data, s, e);
                            CallHandlerUsingJson_POST(Data, s, e);

                        });
                    });
                }); //tx.executesql leakreport ends
            });
        }

        function FinalReport() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM tripdata1', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var data = { 'op': 'btnRemarksSaveClick', 'Remarks': obj.Remarks, 'Denominations': obj.Denominations, 'ColAmount': obj.CollectedAmount, 'SubAmount': obj.SubmittedAmount };
                        var s = function (msg) {
                            if (msg) {

                                if (msg == "Session Expired") {
                                    $('#divMsgAlert').css('display', 'block');
                                    document.getElementById('lblAlertMsg').innerHTML = "Session Expired";
                                    document.getElementById("imgAlert").src = "Images/Alert.png";
                                    document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                                    db.transaction(function (tx) {
                                        tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                                            var len = results.rows.length;
                                            for (var i = 0; i < len; ++i) {
                                                var obj = results.rows.item(i);
                                                UserName = obj.UserName;
                                                Permissions = obj.Permissions;
                                                count = obj.count;
                                                var UserData_sno = obj.count;
                                                var UserSno = obj.UserSno;
                                                var LevelType = obj.LevelType;
                                                var AssignDate = obj.AssignDate;
                                                var I_Date = obj.I_Date;
                                                var RouteId = obj.RouteId;
                                                var TripdataSno = obj.TripdataSno;
                                                var TripID = obj.TripID;
                                                var Salestype = obj.Salestype;
                                                var BranchSno = obj.BranchSno;
                                                var data = { 'op': 'GetOfflineLogin', 'UserName': UserName, 'UserData_sno': UserData_sno, 'UserSno': UserSno, 'LevelType': LevelType, 'AssignDate': AssignDate, 'I_Date': I_Date, 'count': count, 'RouteId': RouteId, 'TripdataSno': TripdataSno, 'TripID': TripID, 'Permissions': Permissions, 'Salestype': Salestype, 'BranchSno': BranchSno };
                                                var s = function (msg) {
                                                    if (msg) {
                                                        LogOutClick();
                                                    }
                                                    else {
                                                    }
                                                };
                                                var e = function (x, h, e) {
                                                };
                                                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                                                callHandler(data, s, e);
                                            }
                                        });
                                    });
                                }
                                else {
                                    //SaveOffIndentData();
                                    finalsync_end();
                                }
                            }
                            else {
                            }
                        };
                        var e = function (x, h, e) {
                        };
                        $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                        //CallHandlerUsingJson(data, s, e);
                        CallHandlerUsingJson_POST(Data, s, e);

                    }
                });
            });
        }

        function finalsync_end() {
            var Data = { 'op': 'sync_end' };
            var s = function (msg) {
                if (msg) {
                    if (msg == 'Success') {
                        CompareProducts();
                    }
                    else {
                        $('#divMsgAlert').css('display', 'block');
                        document.getElementById('lblAlertMsg').innerHTML = "Failed Sync_End";
                        document.getElementById("imgAlert").src = "Images/Alert.png";
                        document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                    }
                }
            }
            var e = function (x, h, e) {
                var errsg = "Sync Failed.....!" + x.responseText + e.responseText;
                sendmail(errsg);
            };
            callHandler(Data, s, e);

        }
        function SaveOffIndentData() {


            var OrderDatails = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM OrderOffline1 ', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; ++i) {
                        var obj = results.rows.item(i);
                        var OrderQty = obj.OrderQty;
                        if (OrderQty == "" || OrderQty == null) {
                            OrderQty = "0";
                        }
                        if (OrderQty == "0") {
                        }
                        else {
                            OrderDatails.push({ Productsno: obj.ProductId, Unitsqty: obj.OrderQty, BranchID: obj.BrancID, IndentType: obj.IndentType, UnitCost: obj.UnitCost });
                        }
                    }

                    if (OrderDatails.length > 0) {
                        for (var i = 0; i < OrderDatails.length; i++) {
                            var Data = { 'op': 'NextIndent_SyncData', 'order_detail': OrderDatails[i], 'end': 'N' };

                            if (i == OrderDatails.length - 1) {
                                Data = { 'op': 'NextIndent_SyncData', 'order_detail': OrderDatails[i], 'end': 'Y' };
                            }

                            var s = function (msg) {
                                if (msg == 'Y') {
                                    var Data = { 'op': 'sync_end' };
                                    var s = function (msg) {
                                        if (msg) {
                                            if (msg == 'Success') {
                                                CompareProducts();
                                            }
                                            else {
                                                $('#divMsgAlert').css('display', 'block');
                                                document.getElementById('lblAlertMsg').innerHTML = "failed";
                                                document.getElementById("imgAlert").src = "Images/Alert.png";
                                                document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                                            }
                                        }
                                    }
                                    var e = function (x, h, e) {
                                    };
                                    callHandler(Data, s, e);
                                }
                            }
                            var e = function (x, h, e) {
                            };
                            //CallHandlerUsingJson(Data, s, e);
                            CallHandlerUsingJson_POST(Data, s, e);

                        }
                    }
                    else {
                        var Data = { 'op': 'sync_end' };
                        var s = function (msg) {
                            if (msg) {
                                if (msg == 'Success') {
                                    CompareProducts();

                                }
                                else {
                                    $('#divMsgAlert').css('display', 'block');
                                    document.getElementById('lblAlertMsg').innerHTML = "Sync Failed";
                                    document.getElementById("imgAlert").src = "Images/Alert.png";
                                    document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                                }
                            }
                        }
                        var e = function (x, h, e) {
                        };
                        callHandler(Data, s, e);
                    }
                });
            });
        }

        function divAgentorderclick() {
            $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divHide').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'none');
            $('#DivIndentType').css('display', 'none');
            $('#divOrders').css('display', 'none');
            $('#divIndentReporting').css('display', 'none');
            $('#divSync').css('display', 'none');
            $('#divDelivers').css('display', 'none');
            $('#divCollections').css('display', 'none');
            $('#divReports').css('display', 'none');
            $('#divDispatch').css('display', 'none');
            $('#divShortage').css('display', 'none');
            $('#divCollectionReport').css('display', 'none');
            $('#divReporting').css('display', 'none');
            $('#divInvReporting').css('display', 'none');
            $('#divAmountReporting').css('display', 'none');
            $('#divVerifyInventory').css('display', 'none');
            $('#tableEmployee').css('display', 'none');
            $('#divOrderReport').css('display', 'none');
            $('#divDeliverReport').css('display', 'none');
            $('#divAgent').css('display', 'block');
            $('#divInventoryReport').css('display', 'none');
            $('#divstatus').css('display', 'none');
            $('#divNextDayIndentReport').css('display', 'none');
            $('#divOfflineIndent').css('display', 'none');
            //            divAgentRanking
            $('#divAgentRanking').css('display', 'none');
            bindagentorder();
        }
        function bindagentorder() {
            var Branches = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM branchdata1 ORDER BY Rank', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        Branches.push({ BrancID: obj.Sno, BranchName: obj.BranchName, Rank: obj.Rank });

                    }
                    Branches.sort(function (a, b) { return a.Rank - b.Rank });
                    //                    var Branchesaaa = Branches.unique();
                    //BindBranchName(Branches);
                    bindagentstodiv(Branches);
                });
            });
        }
        function bindagentstodiv(msg) {
            document.getElementById('divselected').innerHTML = "";
            for (var j = 0; j < msg.length; j++) {
                var div = document.getElementById('divselected');
                var divs = div.getElementsByTagName('div');
                var i = divs.length;
                var Selected = msg[j].BranchName;
                var Selectedid = i + 1;
                var branchid = msg[j].BrancID;
                var label = document.createElement("div");
                label.id = branchid;
                label.innerHTML = Selected;
                label.className = 'divselectedclass';
                label.onclick = function () { divonclick(this); }
                document.getElementById('divselected').appendChild(label);
            }
        }
        function divonclick(selected) {
            selectedindex = selected;
            if (selectedindex != "") {
                $('.divselectedclass').each(function () {
                    $(this).css('background-color', '#ffffff');
                });
                $(selected).css('background-color', '#59FA87');
            }
            else {
                $('.divselectedclass').each(function () {
                    $(this).css('background-color', '#ffffff');
                });
                //                $(selected).css('background-color', '#ffffcc');
            }
        }
        function btnUpClick() {
            $(selectedindex).insertBefore($(selectedindex).prev());
        }
        function btnDownClick() {
            $(selectedindex).insertAfter($(selectedindex).next());
        }




        function sendmail(errormsg) {
            var Data = { 'op': 'Sendmail', 'errmsg': errormsg };
            var s = function (msg) {
                if (msg == "Success") {
                    DeliversOfflineSaveclick();
                }
                else {
                    DeliversOfflineSaveclick();
                }

            };
            var e = function (x, h, e) {
            };
            callHandler(Data, s, e);
        }
        function CompareProducts() {
            var Data = { 'op': 'GetProductInformation' };
            var s = function (msg) {
                if (msg) {
                    BindCompareProducts(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(Data, s, e);
        }
        function BindCompareProducts(msg) {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT ProductId,ProductName,ROUND(SUM(DeliverQty), 2) AS DeliverQty  FROM IndentData1', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var DeliverQty = msg;
                        var DQty = obj.DeliverQty;
                        if (DeliverQty != DQty) {
                            var errmsg = "ProductsDelivery" + DeliverQty + "-->" + DQty;
                            sendmail(errmsg);
                        }
                        else {
                            compareDelInventory();
                        }
                    }
                });
            });
        }
        function compareDelInventory() {
            var Data = { 'op': 'GetDeliverInventoryInformation' };
            var s = function (msg) {
                if (msg) {
                    BindcompareDelInventory(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(Data, s, e);
        }
        function BindcompareDelInventory(msg) {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT InventorySno,InventoryName,ROUND(SUM(ToadayQty), 2) AS Qty  FROM Inventory', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var InvQty = msg;
                        var IQty = obj.Qty;
                        if (IQty != InvQty) {
                            var error = "InventoryDelivery";
                            sendmail(error);
                        }
                        else {
                            ComparecolInventory();
                        }
                    }
                });
            });
        }
        function ComparecolInventory() {
            var Data = { 'op': 'GetColInventoryInformation' };
            var s = function (msg) {
                if (msg) {
                    BindcompareColInventory(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(Data, s, e);
        }
        function BindcompareColInventory(msg) {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT InventorySno,InventoryName,ROUND(SUM(ToadayQty), 2) AS Qty  FROM ReturnInventory1', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var InvQty = msg;
                        var IQty = obj.Qty;
                        if (IQty != InvQty) {
                            var errsg = "InventoryCollection";
                            sendmail(errsg);
                        }
                        else {
                            CompareAmount();
                        }
                    }
                });
            });
        }
        function CompareAmount() {
            var Data = { 'op': 'GetColAmount' };
            var s = function (msg) {
                if (msg) {
                    BindcompareAmount(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(Data, s, e);
        }
        function BindcompareAmount(msg) {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT ROUND(SUM(TodayAmount), 2) AS Amount  FROM BranchAmount2', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var ColAmount = obj.Amount;
                        var Amount = msg;
                        if (Amount != ColAmount) {
                            var errrmsg = "AmountCollection";
                            sendmail(errrmsg);
                        }
                        else {
                            //divSyncAgentsig();
                            synccomplete();
                        }
                    }

                });
            });
        }
        function divSyncAgentsig() {
            var Agentsigdetails = [];
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM branchdata1', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            Agentsigdetails.push({ SNo: i + 1, BrancID: obj.Sno, Sign: obj.Sign });

                        }
                        var Branch = "";
                        if (Agentsigdetails.length > 0) {
                            //for (var k = 0; k < Agentsigdetails.length; k++) {
                            //var Data = { 'op': 'Agent_Signature_SyncData', 'BranchID': Branch, 'Signaturedetail': Agentsigdetails[k], 'end': 'Y' };
                            var Data = { 'op': 'Agent_Signature_SyncData', 'BranchID': Branch, 'Signaturedetail': Agentsigdetails, 'end': 'Y' };
                               // if (k == Agentsigdetails.length - 1) {
                                 //   Data = { 'op': 'Agent_Signature_SyncData', 'BranchID': Branch, 'Signature_detail': Agentsigdetails[k], 'end': 'Y' };
                                //}
                                var s = function (msg) {
                                    if (msg == 'Y') {
                                        synccomplete();
                                    }
                                };
                                var e = function (x, h, e) {
                                };
                                //CallHandlerUsingJson(Data, s, e);
                                CallHandlerUsingJson_POST(Data, s, e);

                            //}
                        }
                        else {
                            synccomplete();
                        }
                    });
                });
            }
        }
        function synccomplete() {
            var Data = { 'op': 'SendSms' };
            var s = function (msg) {
                if (msg == "Error sending data please try again") {

                    $('#divMsgAlert').css('display', 'block');
                    document.getElementById('lblAlertMsg').innerHTML = "FAILED_SENDING_SMS";
                    document.getElementById("imgAlert").src = "Images/Alert.png";
                    document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                }
                else {
                    $('#divMsgAlert').css('display', 'block');
                    document.getElementById('lblAlertMsg').innerHTML = "Reporting Submitted";
                    document.getElementById("imgAlert").src = "Images/Success.png";
                    document.getElementById("lblAlertMsg").style.color = '#59FA87';
                    var SyncStatus = "S";
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        tx.executeSql('UPDATE LoginDetails SET SyncStatus="' + SyncStatus + '" ');
                        deletedata();
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    });

                }
                
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(Data, s, e);

        }
        function deletedata() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('DROP  Table IndentData1');
                tx.executeSql('DROP  Table OrderOffline1');
                tx.executeSql('DROP  Table Inventory');
                tx.executeSql('DROP  Table ReturnInventory1');
                tx.executeSql('DROP  Table BranchAmount2');
                tx.executeSql('DROP  Table LoginDetails');
                tx.executeSql('DROP Table branchdata1');
                tx.executeSql('DROP  Table branchroutes');
                tx.executeSql('DROP Table dispatch');
                tx.executeSql('DROP Table empmanage');
                tx.executeSql('DROP Table invmaster');
                tx.executeSql('DROP Table leakages');
                tx.executeSql('DROP Table products_category');
                tx.executeSql('DROP Table products_subcategory');
                tx.executeSql('DROP Table productsdata');
                tx.executeSql('DROP Table tripdata1');
                tx.executeSql('DROP Table tripsubdata1');
                tx.executeSql('DROP Table tripinvdata');
                tx.executeSql('DROP Table branchproducts1');
                tx.executeSql('DROP Table SalesOfficebranchproducts1');
                tx.executeSql('DROP Table Leakreport');
                tx.executeSql('DROP Table InventoryReport1');
                tx.executeSql('DROP Table StatusTable');
            });
        }
       
        function GetInventoryData() {
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                if (loginStatus != "OFFLINE") {
                    var data = { 'op': 'GetOffLineInventoryData' };
                    var s = function (msg) {
                        if (msg) {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                for (var i = 0; i < msg.length; i++) {
                                    tx.executeSql('INSERT INTO Inventory (InventorySno,InventoryName,Qty,ToadayQty, BrancID) VALUES ("' + msg[i].Inv_Sno + '","' + msg[i].InvName + '","' + msg[i].Qty + '","' + msg[i].TodayQty + '","' + msg[i].BranchID + '")');
                                    tx.executeSql('INSERT INTO ReturnInventory1 (InventorySno,InventoryName,Qty,ToadayQty, BrancID) VALUES ("' + msg[i].Inv_Sno + '","' + msg[i].InvName + '","' + msg[i].Qty + '","' + msg[i].TodayQty + '","' + msg[i].BranchID + '")');
                                }
                                fillOfferProducts();
                            });
                        }
                        else {
                            fillOfferProducts();
                        }

                    };
                    var e = function (x, h, e) {
                    };
                    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                    callHandler(data, s, e);
                }
            }
        }
        function fillOfferProducts() {

            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                if (loginStatus != "OFFLINE") {
                    var data = { 'op': 'GetOfferProducts' };
                    var s = function (msg) {
                        if (msg) {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                for (var i = 0; i < msg.length; i++) {

                                    tx.executeSql('INSERT INTO OfferProducts (BranchID,ProductId,ProductName, IDOffersAssignment) VALUES ("' + msg[i].branchid + '","' + msg[i].productid + '","' + msg[i].productname + '","' + msg[i].idoffers_assignment + '")');
                                    // tx.executeSql('INSERT INTO ReturnInventory1 (InventorySno,InventoryName,Qty,ToadayQty, BrancID) VALUES ("' + msg[i].Inv_Sno + '","' + msg[i].InvName + '","' + msg[i].Qty + '","' + msg[i].TodayQty + '","' + msg[i].BranchID + '")');
                                }
                                fillOfferindent();
                            });
                        }
                        else {
                            fillOfferindent();
                        }

                    };
                    var e = function (x, h, e) {
                    };
                    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                    callHandler(data, s, e);
                }
            }
        }
        function fillOfferindent() {
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                if (loginStatus != "OFFLINE") {
                    var data = { 'op': 'GetOfferIndent' };
                    var s = function (msg) {
                        if (msg) {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                for (var i = 0; i < msg.length; i++) {
                                    var UnitQty = msg[i].UnitQty;
                                    var DeliverQty = msg[i].DeliverQty;
                                    if (DeliverQty == "") {
                                        DeliverQty = "0";
                                    }
                                    tx.executeSql('INSERT INTO OfferIndent (BranchID,IndentType,ProductId,ProductName,IndentNo,UnitPrice,Indent,Delivery) VALUES ("' + msg[i].BrancID + '","' + msg[i].IndentType + '","' + msg[i].ProductId + '","' + msg[i].ProductName + '","' + msg[i].IndentNo + '","' + msg[i].UnitCost + '","' + msg[i].UnitQty + '","' + msg[i].DeliverQty + '" )');
                                    var SyncStatus = 0;
                                    tx.executeSql('INSERT INTO OfferIndentOffline (BranchID,IndentType, Productid,ProductName, IndentQty,UnitPrice,SyncStatus) VALUES ("' + msg[i].BrancID + '","' + msg[i].IndentType + '","' + msg[i].ProductId + '","' + msg[i].ProductName + '","' + msg[i].UnitQty + '","' + msg[i].UnitCost + '","' + SyncStatus + '")');

//                                    if (UnitQty == "0" && DeliverQty == "0") {
//                                    }
//                                    else {
//                                        var UnitQty = msg[i].UnitQty;
//                                        if (UnitQty == "0") {
//                                        }
//                                        else {
//                                           
//                                        }
//                                    }
                                }
                            });
                        }
                        else {
                        }

                    };
                    
                    var e = function (x, h, e) {
                    };
                    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                    callHandler(data, s, e);
                }
            }

        }
        function GetIndentData() {
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                if (loginStatus != "OFFLINE") {
                    var data = { 'op': 'GetOffLineIndentData' };
                    var s = function (msg) {
                        if (msg) {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                for (var i = 0; i < msg.length; i++) {
                                    var UnitQty = msg[i].UnitQty;
                                    var DeliverQty = msg[i].DeliverQty;
                                    if (DeliverQty == "") {
                                        DeliverQty = "0";
                                    }
                                    if (UnitQty == "0" && DeliverQty == "0") {
                                    }
                                    else {
                                        tx.executeSql('INSERT INTO IndentData1 (UserID,BranchName,BrancID,IndentType, ProductId,ProductName,Categoryname, UnitQty,UnitCost, DeliverQty, Status,DtripID,IDate,Ddate ,LeakQty,IndentNo,Rank) VALUES ("' + msg[i].UserID + '","' + msg[i].BranchName + '","' + msg[i].BrancID + '","' + msg[i].IndentType + '","' + msg[i].ProductId + '","' + msg[i].ProductName + '", "' + msg[i].Categoryname + '","' + msg[i].UnitQty + '","' + msg[i].UnitCost + '","' + msg[i].DeliverQty + '","' + msg[i].Status + '","' + msg[i].DtripID + '","' + msg[i].IDate + '","' + msg[i].Ddate + '","' + msg[i].LeakQty + '","' + msg[i].IndentNo + '","' + msg[i].Rank + '" )');
                                        var UnitQty = msg[i].UnitQty;
                                        if (UnitQty == "0") {
                                        }
                                        else {
                                            var SyncStatus = 0;
                                            tx.executeSql('INSERT INTO OrderOffline1 (BrancID,IndentType, ProductId,ProductName, UnitQty,UnitCost,SyncStatus) VALUES ("' + msg[i].BrancID + '","' + msg[i].IndentType + '","' + msg[i].ProductId + '","' + msg[i].ProductName + '","' + msg[i].UnitQty + '","' + msg[i].UnitCost + '","' + SyncStatus + '")');
                                        }
                                    }
                                }
                                GetInventoryData();
                            });
                        }
                        else {
                        }

                    };
                    //                    var e = function (x, h, e) {
                    //                    };
                    //                   // $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                    //                    callHandler(data, s, e);
                    var e = function (x, h, e) {
                    };
                    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                    callHandler(data, s, e);
                }
            }
        }
        function GetTripSubdata() {
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                if (loginStatus != "OFFLINE") {
                    var data = { 'op': 'GetOffLineTripSubData' };
                    var s = function (msg) {
                        if (msg) {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                for (var i = 0; i < msg.length; i++) {
                                    tx.executeSql('INSERT INTO tripsubdata1 (ProductId,Qty,DeliverQty,ProductName,Rank) VALUES ("' + msg[i].ProductId + '","' + msg[i].Qty + '","' + msg[i].DeliverQty + '","' + msg[i].ProductName + '","' + msg[i].rank + '")');
                                    var leak = "0";
                                    var short1 = "0";
                                    var free = "0";
                                    tx.executeSql('INSERT INTO leakages (ProductID,ProductName,ShortQty,LeakQty,FreeMilk) VALUES ("' + msg[i].ProductId + '","' + msg[i].ProductName + '","' + leak + '","' + short1 + '","' + free + '")');
                                }
                            });
                        }
                        else {
                        }

                    };
                    var e = function (x, h, e) {
                    };
                    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                    callHandler(data, s, e);
                }
            }
        }
        function GetTripInvData() {
            online = window.navigator.onLine;
            if (!online) {
            }
            else {
                if (loginStatus != "OFFLINE") {
                    var data = { 'op': 'GetOffLineTripInvData' };
                    var s = function (msg) {
                        if (msg) {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                for (var i = 0; i < msg.length; i++) {
                                    tx.executeSql('INSERT INTO tripinvdata (invid,Qty,Remaining, InvName) VALUES ("' + msg[i].InvId + '","' + msg[i].Qty + '","' + msg[i].RemainQty + '","' + msg[i].InvName + '")');
                                }
                            });
                        }
                        else {
                        }

                    };
                    var e = function (x, h, e) {
                    };
                    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                    callHandler(data, s, e);
                }
            }
        }
        function BranchData() {
            var data = { 'op': 'GetDispatchBranch' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO branchdata1 (Sno,BranchName) VALUES ("' + msg[i].BrancID + '","' + msg[i].BranchName + '")');
                            tx.executeSql('INSERT INTO StatusTable (BranchID) VALUES ("' + msg[i].BrancID + '")');
                        }
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function ProductsData() {
            var data = { 'op': 'getProductsData' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO productsdata (sno, SubCat_sno, ProductName, Units, UnitPrice, Rank,SubCat_sno) VALUES ("' + msg[i].sno + '","' + msg[i].SubCatSno + '","' + msg[i].ProductName + '","' + msg[i].Units + '","' + msg[i].UnitPrice + '","' + msg[i].Rank + '","' + msg[i].SubCatSno + '" )');
                        }
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BranchProducts() {
            var data = { 'op': 'getBranchProductsData' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO branchproducts1 (branch_sno, product_sno, ProductName,unitprice,Rank) VALUES ("' + msg[i].BranchID + '","' + msg[i].ProductId + '","' + msg[i].ProductName + '","' + msg[i].UnitPrice + '","' + msg[i].rank + '")');
                        }
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function SalesOfficeBranchProducts() {
            var data = { 'op': 'getSalesOfficeBranchProductsdata' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO SalesOfficebranchproducts1 (branch_sno, product_sno, ProductName,unitprice,Rank) VALUES ("' + msg[i].BranchSno + '","' + msg[i].ProductId + '","' + msg[i].ProductName + '","' + msg[i].UnitPrice + '","' + msg[i].rank + '")');
                        }
                        BranchProducts();
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function GetCategeory() {
            var data = { 'op': 'GetOfflineCategeory' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO products_category (sno, categoryname) VALUES ("' + msg[i].sno + '","' + msg[i].categoryname + '" )');
                        }
                        ProductsData();
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function GetSubCategory() {
            var data = { 'op': 'GetofflineSubCategory' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO products_subcategory (sno, category_sno, subcategorynames) VALUES ("' + msg[i].sno + '","' + msg[i].CatSno + '","' + msg[i].subcategorynames + '" )');
                        }
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function GetProducts() {
            var data = { 'op': 'getProductsData' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO productsdata (sno, productName, Units, UnitPrice, Rank,SubCatSno) VALUES ("' + msg[i].sno + '","' + msg[i].ProductName + '","' + msg[i].Units + '","' + msg[i].UnitPrice + '","' + msg[i].Rank + '","' + msg[i].SubCat_sno + '" )');
                        }
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function InvMaster() {
            var data = { 'op': 'getInvMaster' };
            var s = function (msg) {
                if (msg) {
                    for (var i = 0; i < msg.length; i++) {
                        db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                        db.transaction(function (tx) {
                            tx.executeSql('INSERT INTO dispatch (sno, InvName ,Userdata_sno ,flag, Qty) VALUES (' + msg[i].sno + ',"' + msg[i].InvName + '",' + msg[i].Userdata_sno + ',' + msg[i].flag + ',' + msg[i].Qty + ' )');
                        });
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function FillEmployee() {
            var data = { 'op': 'GetSOEmployeeNames' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO empmanage (Sno, UserName, LevelType, Branch, EmpName) VALUES ("' + msg[i].Sno + '","' + msg[i].UserName + '","' + msg[i].LevelType + '","' + msg[i].Branch + '","' + msg[i].EmpName + '" )');
                        }
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindBranchRoutes() {
            var data = { 'op': 'GetDispatchAgents' };
            var s = function (msg) {
                if (msg) {
                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                    db.transaction(function (tx) {
                        for (var i = 0; i < msg.length; i++) {
                            tx.executeSql('INSERT INTO branchroutes (Sno,RouteName, BranchID) VALUES ("' + msg[i].rid + '","' + msg[i].RouteName + '","' + msg[i].BranchID + '")');
                        }
                    });
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function filldispatchname() {
            var username = document.getElementById('txtUserName').value;
            var password = document.getElementById('txtPassword').value;
            var data = { 'op': 'getdispatches', 'username': username, 'password': password };
            var s = function (msg) {
                if (msg) {
                    binddispatches(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);

        }
        function binddispatches(msg) {
            var dispname = document.getElementById('ddlRouteName');
            var length = dispname.options.length;
            document.getElementById("ddlRouteName").options.length = null;
            //    for (i = 0; i < length; i++) {
            //        productcategory.options[i] = null;
            //    }
            var opt = document.createElement('option');
            opt.innerHTML = "Select";
            dispname.appendChild(opt);
            for (var i = 0; i < msg.length; i++) {
                if (msg[i].routename != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].routename;
                    opt.value = msg[i].sno;
                    dispname.appendChild(opt);
                }
            }
        }
         var indent="";
        var dtonlineIndent = [];
        function divindentclick() {
            DairyStatus = "AgentIndent";
            dtonlineIndent = [];
            var Route = document.getElementById('ddlRouteName');
            var dispatchid = Route.options[Route.selectedIndex].value;
            var dispatchName = Route.options[Route.selectedIndex].text;
            document.getElementById('txtroutename').innerHTML = dispatchName;
            document.getElementById('txtUser').innerHTML = UserID;
            indent = 1;
            var data = { 'op': 'getrouteindent', 'dispatchid': dispatchid, 'indent': indent };
            var s = function (msg) {
                if (msg) {
                    var BranchName = "";
                    for (var i = 0; i < msg.length; i++) {
                        var ProductName = msg[i].ProductName;
                        var UnitQty = msg[i].unitQty;
                        var DeliverQty = msg[i].DeliverQty;
                        if (msg[i].agentname != BranchName) {
                            BranchName = msg[i].agentname;
                            dtonlineIndent.push({ BranchName: BranchName, ProductName: ProductName, UnitQty: UnitQty, DeliverQty: DeliverQty });
                        }
                        else {
                            var Agent = "";
                            dtonlineIndent.push({ BranchName: Agent, ProductName: ProductName, UnitQty: UnitQty, DeliverQty: DeliverQty });
                        }
                    }
                    $('#divFillScreen').css('display', 'block');
                    $('#divonlineindent').css('display', 'none');
                    $('#divtotalindent').css('display', 'none');
                    $('#divback').css('display', 'block');
                    //                    $('#divindentback').css('display', 'block');
                    $('#divRouteOrder').css('display', 'none');
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('OrderReport1.htm');
                    $('#divFillScreen').processTemplate(dtonlineIndent);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        var dttotalIndent = [];
        function divtotalindentclick() {
            DairyStatus = "TotalIndent";
            dttotalIndent = [];
            indent = 2;
            var Route = document.getElementById('ddlRouteName');
            var dispatchid = Route.options[Route.selectedIndex].value;
            var dispatchName = Route.options[Route.selectedIndex].text;
//            var dispatchid = document.getElementById('ddlRouteName').value;
            document.getElementById('txtroutename').innerHTML = dispatchName;
            document.getElementById('txtUser').innerHTML = UserID;
            var data = { 'op': 'getrouteindent', 'dispatchid': dispatchid,'indent':indent };
            var s = function (msg) {
                if (msg) {
                    var BranchName = "";
                    for (var i = 0; i < msg.length; i++) {
                        var ProductName = msg[i].ProductName;
                        var UnitQty = msg[i].unitQty;
                        var DeliverQty = msg[i].DeliverQty;
                         var Agent = "";
                         dttotalIndent.push({ BranchName: Agent, ProductName: ProductName, UnitQty: UnitQty, DeliverQty: DeliverQty });
                    }
                    $('#divFillScreen').css('display', 'block');
                    $('#divonlineindent').css('display', 'none');
                    $('#divtotalindent').css('display', 'none');
                    $('#divback').css('display', 'block');
                    //                    $('#divindentback').css('display', 'block');
                    $('#divRouteOrder').css('display', 'none');
                    var skillsSelect = document.getElementById("ddlRouteName");
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('TotalIndent1.htm');
                    $('#divFillScreen').processTemplate(dttotalIndent);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        var UserID = "";
        function LoginDetails() {
            online = window.navigator.onLine;
            if (loginStatus == "OFFLINE") {
                var uid = document.getElementById('txtUserName').value;
                var pwd = document.getElementById('txtPassword').value;
                if (uid == "") {
                    alert("Enter UseName");
                    return false;
                }
                if (pwd == "") {
                    alert("Enter Password");
                    return false;
                }
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            UserName = obj.UserName;
                            Permissions = obj.Permissions;
                            count = obj.count;
                            $('#divFillScreen').css('display', 'none');
                            $('#divLogOut').css('display', 'block');
                            $('#divWelcome').css('display', 'block');
                            $('#divback').css('display', 'none');
                            $('#divHide').css('display', 'block');
                            GetValues();
                            GetIndentData();
                            GetTripSubdata();
                            GetTripInvData();
                            loginStatus = "OFFLINE";
                        }
                    });
                });
            }
            else {
                var uid = document.getElementById('txtUserName').value;
                var pwd = document.getElementById('txtPassword').value;
                if (uid == "") {
                    alert("Enter UseName");
                    return false;
                }
                if (pwd == "") {
                    alert("Enter Password");
                    return false;
                }
                UserID = uid;
                document.getElementById('txtUser').innerHTML = UserID;
                var data = { 'op': 'GetVersionName' };
                var s = function (msg) {
                    if (msg) {
                        var txtVersion = document.getElementById('txtVersion').innerHTML;
                        if (msg == txtVersion) {
                            var data = { 'op': 'ValidateLogin', 'UID': uid, 'PWD': pwd };
                            var s = function (msg) {
                                if (msg) {
                                    if (msg == "Trip Not Assigned on this UserName") {
                                        //alert(msg);
                                       
                                        $('#divFillScreen').css('display', 'none');
                                        $('#divLogOut').css('display', 'block');
                                        $('#divWelcome').css('display', 'block');
                                        $('#divHide').css('display', 'block');
                                        $('#divback').css('display', 'none');
                                        $('#divRouteOrder').css('display', 'block');
                                        $('#divReporting').css('display', 'none');
                                        $('#divReports').css('display', 'none');
                                        $('#divShortage').css('display', 'none');
                                        $('#divAgentRanking').css('display', 'none');
                                        $('#divOfflineIndent').css('display', 'none');
                                        $('#tableEmployee').css('display', 'none');
                                        $('#tableOrder').css('display', 'none');
                                        $('#divonlineindent').css('display', 'block');
                                        $('#divtotalindent').css('display', 'block');
                                        filldispatchname();
                                        return false;
                                    }
                                    if (msg == "Invalid UserName and Password") {
                                        alert(msg);
                                        return false;
                                    }
                                    if (msg == "Sorry,Please Login Online Application Client.vyshnavi.net") {
                                        alert(msg);
                                        return false;
                                    }
                                    else
                                        if (!confirm("Do you want to Syncdata to OFFLINE")) {
                                            return false;
                                        }
                                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                                    db.transaction(function (tx) {
                                        tx.executeSql('INSERT INTO LoginDetails (PlantEmpId ,PlantDispSno ,DispDate ,Permissions ,Salestype ,BranchSno ,CsoNo ,TripID,RouteId,UserSno,TripdataSno, AssignDate,I_Date ,count,Sno, UserName,Password,LevelType,UserData_sno,Date) VALUES ("' + msg.PlantEmpId + '","' + msg.PlantDispSno + '","' + msg.DispDate + '" ,"' + msg.Permissions + '" ,"' + msg.Salestype + '" ,"' + msg.BranchSno + '","' + msg.CsoNo + '" ,"' + msg.TripID + '","' + msg.RouteId + '","' + msg.UserSno + '","' + msg.TripdataSno + '", "' + msg.AssignDate + '", "' + msg.I_Date + '" , "' + msg.count + '", "' + msg.Sno + '",  "' + msg.UserName + '", "' + msg.Password + '", "' + msg.LevelType + '", "' + msg.UserData_sno + '", "' + msg.Date + '")');
                                        $('#divFillScreen').css('display', 'none');
                                        $('#divLogOut').css('display', 'block');
                                        $('#divWelcome').css('display', 'block');
                                        $('#divback').css('display', 'none');
                                        $('#divHide').css('display', 'block');
                                        $('#divonlineindent').css('display', 'none');
                                        $('#divtotalindent').css('display', 'none');
                                        GetPermissions();
                                        GetIndentData();
                                        GetTripSubdata();
                                        GetTripInvData();
                                        loginStatus = "";
                                    });
                                }
                                else {
                                }
                            };
                            var e = function (x, h, e) {
                            };
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                            callHandler(data, s, e);
                        }
                        else {
                            alert("found new version!");
                            window.location.reload();
                            //                            window.location.href = "Default.aspx";
                        }
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
        }
        var UserName = "";
        var Permissions = "";
        var dispatchname = "";
        var datatab;
        function GetPermissions() {
            var data = { 'op': 'GetPermissions' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    else {
                        UserName = msg[0].UserName;
                        Permissions = msg[0].Permision;
                        count = msg[0].Count;
                        dispatchname = msg[0].DispatchName;
                        GetValues();
                        datatab = msg;
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
                alert(e);

            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        var count = 0;
        var StatusDropDown = "";
        function GetValues() {
            window.history.forward(1);
            document.getElementById('txtUser').innerHTML = UserName;
            document.getElementById('txtroutename').innerHTML = dispatchname;
            Permissions = Permissions;
            var Permns = [];
            Permns = Permissions.split(';');
            for (var i = 0; i < Permns.length; i++) {
                switch (Permns[i]) {
                    case "O":
                        $('#divOrders').css('display', 'block');
                        $('#divIndentReporting').css('display', 'block');
                        StatusDropDown = "Order";
                        if (count > 1) {
                            $('#divRouteOrder').css('display', 'block');
                            $('#tableEmployee').css('display', 'none');
                            $('#divReporting').css('display', 'none');
                            $('#divShortage').css('display', 'none');
                            FillDispatchRoutes();
                            BindBranchRoutes();
                        }
                        else {
                            $('#divRouteOrder').css('display', 'none');
                            $('#tableEmployee').css('display', 'none');
                            $('#divReporting').css('display', 'none');
                            $('#divShortage').css('display', 'none');
                            online = window.navigator.onLine;
                            if (loginStatus == "OFFLINE") {
                                BingOffBranch();
                            }
                            else {
                                FillDispatchBrach();
                                BranchData();
                                GetCategeory();
                                GetSubCategory();

                                //                                GetProducts();
                            }
                        }
                        break;
                    case "D":
                        $('#divDelivers').css('display', 'block');
                        StatusDropDown = "Deliver";
                        if (count > 1) {
                            $('#divRouteOrder').css('display', 'block');
                            $('#tableEmployee').css('display', 'none');
                            $('#divDeliverReport').css('display', 'none');
                            $('#divInventoryReport').css('display', 'none');
                            
                            FillDispatchRoutes();
                        }
                        else {
                            $('#tableOrder').css('display', 'block');
                            $('#divFillScreen').css('display', 'none');
                            $('#divHide').css('display', 'block');
                            $('#divOrders').css('display', 'none');
                            $('#divIndentReporting').css('display', 'none');
                            $('#divDelivers').css('display', 'block');
                            $('#divReports').css('display', 'none');
                            $('#divDispatch').css('display', 'none');
                            $('#divShortage').css('display', 'block');
                            $('#divCollectionReport').css('display', 'none');
                            $('#divReporting').css('display', 'block');
                            $('#divReports').css('display', 'block');
                            $('#divstatus').css('display', 'none');
                            $('#divNextDayIndentReport').css('display', 'none');
                            $('#divInvReporting').css('display', 'none');
                            $('#divAmountReporting').css('display', 'none');
                            $('#divSync').css('display', 'block');
                            $('#divDeliverReport').css('display', 'none');
                            $('#divInventoryReport').css('display', 'none');
                            $('#divOrderReport').css('display', 'none');
                            $('#divAgentRanking').css('display', 'block');
                            $('#divOfflineIndent').css('display', 'block');
                            $('#divAgent').css('display', 'none');
                            $('#tableEmployee').css('display', 'none');
                            
                            if (loginStatus == "OFFLINE") {
                                BingOffBranch();
                            }
                            else {
                                FillDispatchBrach();
                                BranchData();
                                GetCategeory();
                                GetSubCategory();
                                SalesOfficeBranchProducts();
                                GetProducts();
                            }
                        }
                        break;
                    case "C":
                        $('#divCollections').css('display', 'block');
                        $('#divCollectionReport').css('display', 'none');
                        $('#tableEmployee').css('display', 'none');
                        break;
                    case "Dispatcher":
                        $('#divOrders').css('display', 'none');
                        $('#divIndentReporting').css('display', 'none');

                        $('#divDelivers').css('display', 'none');
                        $('#divCollections').css('display', 'none');
                        $('#divCollectionReport').css('display', 'none');
                        $('#divReports').css('display', 'none');
                        $('#divReporting').css('display', 'block');
                        $('#divDispatch').css('display', 'block');
                        $('#tableEmployee').css('display', 'block');
                        $('#tableOrder').css('display', 'none');
                        $('#divVerifyInventory').css('display', 'block');
                        fillcsoroutes();
                        fillEmployeeName();
                        DispatchData();
                        FillEmployee();
                        break;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function GetBranchStatus(RouteId) {
            var data = { 'op': 'GetIndentStatus', 'RouteId': RouteId };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    ColorChangeDropdown(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function fillEmployeeName() {
            var data = { 'op': 'GetSOEmployeeNames' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindEmployeeName(msg);

                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindEmployeeName(msg) {
            var ddlEmployee = document.getElementById('ddlEmployee');
            var length = ddlEmployee.options.length;
            ddlEmployee.options.length = null;
            var opt = document.createElement('option');
            opt.innerHTML = "select";
            ddlEmployee.appendChild(opt);
            for (var i = 0; i < msg.length; i++) {
                if (msg[i].UserName != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].UserName;
                    opt.value = msg[i].Sno;
                    ddlEmployee.appendChild(opt);
                }
            }
        }
        function fillcsoroutes() {
            var data = { 'op': 'GetCsodispatchRoutes' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindRouteName(msg);

                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function fillIndentType(RouteId) {
            //            $('#DivIndentType').css('display', 'none');
            var data = { 'op': 'GetIndentType', 'RouteId': RouteId };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    if (msg.length >= 1) {
                        $('#DivIndentType').css('display', 'block');
                        BindIndentType(msg);
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindIndentType(msg) {
            var ddlIndentType = document.getElementById('ddlIndentType');
            var length = ddlIndentType.options.length;
            ddlIndentType.options.length = null;
            var opt = document.createElement('option');
            for (var i = 0; i < msg.length; i++) {
                if (msg[i].IndentType != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].IndentType;
                    opt.value = msg[i].IndentType;
                    ddlIndentType.appendChild(opt);
                }
            }
        }
        function FillDispatchRoutes() {
            var data = { 'op': 'GetDispatchAgents' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindRouteName(msg);
                    var routeID = document.getElementById('ddlRouteName').value;
                    fillIndentType();
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function FillDispatchBrach() {
            var data = { 'op': 'GetDispatchBranch' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindBranchName(msg);
                    if (StatusDropDown == "Order") {
                        if (count > 1) {
                        }
                        else {
                            var id = "";
                            GetBranchStatus(id);
                            fillIndentType(id);
                        }
                    }

                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function ColorChangeDropdown(data) {
            var select = document.getElementById('ddlBranchName');
            for (var i = 0; i < data.length; i++) {
                var Branchid = data[i].bid;
                for (var j = 0; j < select.options.length; j++) {
                    var Sbid = select.options[j].value;
                    if (Branchid == Sbid) {
                        select.options[j].style.backgroundColor = 'Gray';
                    }
                }
            }
        }
        function FillCategeoryname() {
            var data = { 'op': 'FillCategeoryname' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindCategeoryname(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        };
        function BindCategeoryname(msg) {
            var brnchprdtcatgryname = document.getElementById('cmb_brchprdt_Catgry_name');
            var length = brnchprdtcatgryname.options.length;
            brnchprdtcatgryname.options.length = null;
            var opt = document.createElement('option');
            opt.innerHTML = "select";
            brnchprdtcatgryname.appendChild(opt);
            for (var i = 0; i < msg.length; i++) {
                if (msg[i].categoryname != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].categoryname;
                    opt.value = msg[i].sno;
                    brnchprdtcatgryname.appendChild(opt);
                }
            }
        }
        function BindOffSubCategeoryname() {
            var cmbcatgryname = document.getElementById("cmb_brchprdt_Catgry_name").value;
            var subcategories = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM products_subcategory where category_sno="' + cmbcatgryname + '" ', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        subcategories.push({ sno: obj.sno, subcategorynames: obj.subcategorynames });
                    }
                    fillproductsdata_subcatgry(subcategories);
                });
            });
        }
        function productsdata_categoryname_onchange() {
            online = window.navigator.onLine;
            if (loginStatus == "OFFLINE") {
                BindOffSubCategeoryname();
            }
            else {
                var cmbcatgryname = document.getElementById("cmb_brchprdt_Catgry_name").value;
                var data = { 'op': 'get_product_subcategory_data', 'cmbcatgryname': cmbcatgryname };
                var s = function (msg) {
                    if (msg) {
                        fillproductsdata_subcatgry(msg);
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
            //AscCallHandler(data, s, e);
        };
        function fillproductsdata_subcatgry(msg) {
            var brnchsubcategory = document.getElementById('cmb__brnch_subcatgry');
            var length = brnchsubcategory.options.length;
            document.getElementById("cmb__brnch_subcatgry").options.length = null;
            document.getElementById("cmb__brnch_subcatgry").value = "select";
            //        for (i = 0; i < length; i++) {
            //            prdtsubcategory.options[i] = null;
            //        } 
            var opt = document.createElement('option');
            opt.innerHTML = "Select";
            brnchsubcategory.appendChild(opt);

            for (var i = 0; i < msg.length; i++) {
                if (msg[i].subcategorynames != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].subcategorynames;
                    opt.value = msg[i].sno;
                    brnchsubcategory.appendChild(opt);
                }
            }
        }
        function BindOffProductsname() {
            var cmbsubcatgryname = document.getElementById("cmb__brnch_subcatgry").value;
            var Products = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM productsdata where SubCat_sno="' + cmbsubcatgryname + '"', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        Products.push({ Sno: obj.sno, productName: obj.ProductName });
                    }
                    fillproductsdata_products(Products);
                });
            });
        }
        function productsdata_subcategory_onchange() {
            online = window.navigator.onLine;
            if (loginStatus == "OFFLINE") {
                BindOffProductsname();
            }
            else {
                var cmbsubcatgryname = document.getElementById("cmb__brnch_subcatgry").value;
                //    var e = document.getElementById("cmb__brnch_subcatgry");
                //    var cmbsubcatgryname = e.options[e.selectedIndex].value;
                var data = { 'op': 'get_products_data', 'cmbsubcatgryname': cmbsubcatgryname };
                var s = function (msg) {
                    if (msg) {
                        fillproductsdata_products(msg);
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
                // AscCallHandler(data, s, e);
            }
        }
        function fillproductsdata_products(msg) {
            var cmbprdtname = document.getElementById('cmb_productname');
            var length = cmbprdtname.options.length;
            document.getElementById("cmb_productname").options.length = null;
            document.getElementById("cmb_productname").value = "select";
            //    for (i = 0; i < length; i++) {
            //        cmbprdtname.options[i] = null;
            //    }
            var opt = document.createElement('option');
            opt.innerHTML = "Select";
            cmbprdtname.appendChild(opt);
            for (var i = 0; i < msg.length; i++) {
                if (msg[i].productName != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].productName;
                    opt.value = msg[i].Sno;
                    cmbprdtname.appendChild(opt);
                }
            }
        }
        var DairyStatus = "";
        function divOrdersclick() {
            var BranchName = document.getElementById('ddlBranchName').value;
            if (BranchName == "Select Agent" || BranchName == "") {
                alert("Please Select Agent Name");
                return false;
            }
            DairyStatus = "Orders";
            $('#tableOrder').css('display', 'block');
            $('#divback').css('display', 'block');
            $('#divHide').css('display', 'none');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            $('#divFillScreen').setTemplateURL('Orders12.htm');
            $('#divFillScreen').processTemplate();
            if (bid != "") {
                BranchChane();
                GetOrderStatus();
            }
        }
        function divOfflineIndentclick() {
            var BranchName = document.getElementById('ddlBranchName').value;
            if (BranchName == "Select Agent" || BranchName == "") {
                alert("Please Select Agent Name");
                return false;
            }
            DairyStatus = "Orders";
            $('#tableOrder').css('display', 'block');
            $('#divback').css('display', 'block');
            
            $('#divHide').css('display', 'none');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            $('#divFillScreen').setTemplateURL('Orders12.htm');
            $('#divFillScreen').processTemplate();
            
            BindOfflineOrdersData();
        }
        var offlineindent_state = "";
        function BindOfflineOrdersData() {
            var BranchName = document.getElementById('ddlBranchName').value;
            if (BranchName == "Select Agent" || BranchName == "") {
                alert("Please Select Agent Name");
                return false;
            }
            var OrderData = [];
            var orderState = "";
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM OrderOffline1 WHERE (BrancID="' + BranchName + '")', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var Qty = "0";
                        var OrderQty = obj.OrderQty;
                        var UnitCost = obj.UnitCost;
                        if (OrderQty == "0" || OrderQty == null || OrderQty == "") {
                            OrderQty = "0";
                        }
                        else {
                            orderState = "Edit";
                            offlineindent_state = "Edit";
                        }
                        var Total = 0;
                        Total = UnitCost * OrderQty;
                        OrderData.push({ sno: i + 1, ProductCode: obj.ProductName, Productsno: obj.ProductId, PrevQty: obj.UnitQty, Rate: obj.UnitCost, orderunitqty: Qty, Total: Total, orderunitqty: OrderQty });
                    }
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('Orders12.htm');
                    $('#divFillScreen').processTemplate(OrderData);

                    calcTot();

//                    if (orderState == "Edit") {
//                        $(".Unitqtyclass").attr("disabled", true);
//                        // $(".OfferUnitqtyclass").attr("disabled", true);

//                        document.getElementById('BtnSave').value = "Edit";
//                    }
                    BindOffline_OffersOrdersData();
                });
            });
        }
        function BindOffline_OffersOrdersData() {
            var BranchName = document.getElementById('ddlBranchName').value;
            if (BranchName == "Select Agent" || BranchName == "") {
                alert("Please Select Agent Name");
                return false;
            }
            var OrderData = [];
            var OfferProducts = [];
            var orderState = "";
           // t.executeSql('CREATE TABLE IF NOT EXISTS OfferProducts (BranchID TEXT,ProductId TEXT,ProductName Text,IDOffersAssignment Text)');

            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {

                tx.executeSql('SELECT * FROM OfferIndentOffline WHERE (BranchID="' + BranchName + '")', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var Qty = "0";
                        var OrderQty = obj.OrderQty;
                        var UnitCost = obj.UnitPrice;
                        if (OrderQty == "0" || OrderQty == null || OrderQty == "") {
                            OrderQty = "0";
                        }
                        else {
                            orderState = "Edit";
                        }
                        var Total = 0;
                        Total = UnitCost * OrderQty;
                        OrderData.push({ sno: i + 1, ProductCode: obj.ProductName, Productsno: obj.Productid, PrevQty: obj.IndentQty, Rate: obj.UnitPrice, orderunitqty: Qty, Total: Total, orderunitqty: OrderQty });
                    }
                    $('#divOfferindentOffline').removeTemplate();
                    $('#divOfferindentOffline').setTemplateURL('OfferOrders.htm');
                    $('#divOfferindentOffline').processTemplate(OrderData);

                    offercalcTot();

                    if (offlineindent_state == "Edit") {
                        $(".Unitqtyclass").attr("disabled", true);
                        $(".OfferUnitqtyclass").attr("disabled", true);

                        document.getElementById('BtnSave').value = "Edit";
                    }
                });
            });



            

        }
        var FinalAmount;
        var OfferFinalAmount;
        function calcTot() {
            var qty = 0.0;
            var rate = 0;
            var total = 0;
            var cnt = 0;
            $('.Unitqtyclass').each(function (i, obj) {
                var qtyclass = $(this).val();
                if (qtyclass == "" || qtyclass == "0") {
                }
                else {
                    cnt++;
                }
            });

            document.getElementById('txt_totqty').innerHTML = cnt;
            $('.rateclass').each(function (i, obj) {
                rate += parseInt($(this).text());
            });
            document.getElementById('txt_totRate').innerHTML = rate;
            $('.totalclass').each(function (i, obj) {
                total += parseInt($(this).text());
            });
            document.getElementById('txt_total').innerHTML = total;
            FinalAmount = total;
        }
        function offercalcTot() {
            var qty = 0.0;
            var rate = 0;
            var total = 0;
            var cnt = 0;
            $('.OfferUnitqtyclass').each(function (i, obj) {
                var qtyclass = $(this).val();
                if (qtyclass == "" || qtyclass == "0") {
                }
                else {
                    cnt++;
                }
            });

            document.getElementById('txt_offer_ordertotqty').innerHTML = cnt;
            $('.offerrateclass').each(function (i, obj) {
                rate += parseInt($(this).text());
            });
            document.getElementById('txt_offer_ordertotRate').innerHTML = rate;
            $('.offertotalclass').each(function (i, obj) {
                total += parseInt($(this).text());
            });
            document.getElementById('txt_offer_ordertotal').innerHTML = total;
            OfferFinalAmount = total;
        }
        function OfferOrderUnitChange(UnitQty) {
            var totalqty;
            var qty = 0.0;
            var Rate = 0;
            var rate = 0;
            var total = 0;
            var TotalRate = 0;
            var cnt = 0;
            if (UnitQty.value == "") {
                $(UnitQty).closest("tr").find("#txtOrderTotal").text(total);
                $('.OfferUnitqtyclass').each(function (i, obj) {
                    var qtyclass = $(this).val();
                    if (qtyclass == "" || qtyclass == "0") {
                    }
                    else {
                        cnt++;
                    }
                });
                document.getElementById('txt_offer_ordertotqty').innerHTML = cnt;
                $('.offerrateclass').each(function (i, obj) {
                    rate += parseInt($(this).text());
                });
                var Floatrate = rate.toFixed(2)
                document.getElementById('txt_offer_ordertotRate').innerHTML = Floatrate;
                $('.offertotalclass').each(function (i, obj) {
                    total += parseInt($(this).text());
                });
                document.getElementById('txt_offer_ordertotal').innerHTML = total;
                return false;
            }
            var Qty = $(UnitQty).closest("tr").find("#hdnUnitQty").val();
            var Units = $(UnitQty).closest("tr").find("#hdnUnits").val();
            Rate = $(UnitQty).closest("tr").find("#txtOrderRate").text();
            var Units = $(UnitQty).closest("tr").find("#hdnUnits").val();
            if (Units == "ml") {
                totalqty = parseFloat(UnitQty.value);
            }
            if (Units == "ltr") {
                totalqty = parseInt(UnitQty.value);
            }
            if (Units == "gms") {
                totalqty = parseFloat(UnitQty.value);
            }
            if (Units == "kgs") {
                totalqty = parseInt(UnitQty.value);
            }
            $(UnitQty).closest("tr").find("#hdnQty").val(totalqty)
            var FinalRate = 0;
            FinalRate = UnitQty.value * Rate;
            $(UnitQty).closest("tr").find("#txtOrderTotal").text(FinalRate);
            cnt = 0;
            $('.OfferUnitqtyclass').each(function (i, obj) {
                var qtyclass = $(this).val();
                if (qtyclass == "" || qtyclass == "0") {
                }
                else {
                    cnt++;
                }
            });
            document.getElementById('txt_offer_ordertotqty').innerHTML = cnt;
            rate = 0;
            $('.offerrateclass').each(function (i, obj) {
                rate += parseInt($(this).text());
            });
            document.getElementById('txt_offer_ordertotRate').innerHTML = rate;
            total = 0;
            $('.offertotalclass').each(function (i, obj) {
                total += parseInt($(this).text());
            });
            document.getElementById('txt_offer_ordertotal').innerHTML = total;
        }
        function CalcDeliveryqty() {
            var Deliveryqty = 0;
            $('.Returnqtyclass').each(function (i, obj) {
                Deliveryqty += parseFloat($(this).val());
                var TIqty = $(this).closest("tr").find("#txtRemainingQty").text();
                var Dqty = $(this).val();
                var TotalIndentQty = parseFloat(TIqty).toFixed(2) - parseFloat(Dqty);
                $(this).closest("tr").find("#txtRemainingQty").text(TotalIndentQty.toFixed(2));
            });
            document.getElementById('txt_RetunQty').innerHTML = parseFloat(Deliveryqty).toFixed(2);
        }
        function BindRouteName(msg) {
            document.getElementById('ddlRouteName').options.length = "";

            var veh = document.getElementById('ddlRouteName');
            var length = veh.options.length;
            for (i = length - 1; i >= 0; i--) {
                veh.options[i] = null;
            }
            var opt = document.createElement('option');
            opt.innerHTML = "Select Route";
            opt.value = "";
            veh.appendChild(opt);
            for (var i = 0; i < msg.length; i++) {
                if (msg[i] != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].RouteName;
                    opt.value = msg[i].rid;
                    veh.appendChild(opt);
                }
            }

        }
        var RouteSno = 0;
        function ddlRouteNameChange(Id) {
            RouteSno = Id.value;
            if (Permissions == "Dispatcher") {
                $('#tableOrder').css('display', 'none');
                //                $('#DivDispDate').css('display', 'block');
                $('#tableEmployee').css('display', 'block');
                fillIndentType(Id.value);
            }
            else {
                var data = { 'op': 'GetRouteNameChange', 'TripId': Id.value };
                var s = function (msg) {
                    if (msg) {
                        BindBranchName(msg);
                        if (StatusDropDown == "Order") {
                            GetBranchStatus(Id.value);
                            fillIndentType(Id.value);
                        }
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
        }
        function BindBranchName(msg) {
            document.getElementById('ddlBranchName').options.length = "";

            var veh = document.getElementById('ddlBranchName');
            var length = veh.options.length;
            for (i = length - 1; i >= 0; i--) {
                veh.options[i] = null;
            }
            var opt = document.createElement('option');
            opt.innerHTML = "Select Agent";
            opt.value = "";
            veh.appendChild(opt);
            for (var i = 0; i < msg.length; i++) {
                if (msg[i] != null || msg[i].BranchName != "" || msg[i].BranchName != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].BranchName;
                    opt.value = msg[i].BrancID;
                    veh.appendChild(opt);
                }
            }

        }
        var bid = "";
        var HdnIndentNo;
        function ddlBranchNameChange(bname) {
            bid = bname.options[bname.selectedIndex].value;
            document.getElementById('lblBranch').innerHTML = bname.options[bname.selectedIndex].text;
        }
        function BranchChane() {
            ChangebtnText();
            var bid = document.getElementById('ddlBranchName').value;
            var IndentType = document.getElementById('ddlIndentType').value;
            if (DairyStatus != "Collections") {
                var data = { 'op': 'getBranchValues', 'bid': bid, 'DairyStatus': DairyStatus, 'IndentType': IndentType };
                var s = function (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    if (msg) {
                        if (DairyStatus == "Orders") {
                            BindOrdersclick(msg);
                            calcTot();
                        }
                        if (DairyStatus == "Delivers") {
                            BindDeliversclick(msg);
                            CalcDeliveryqty();
                        }
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
            else {
                var data = { 'op': 'getBranchValuesamount', 'bid': bid };
                var s = function (msg) {
                    if (msg) {
                        if (msg == "Session Expired") {
                            alert(msg);
                            $('#divback').css('display', 'none');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divLogOut').css('display', 'none');
                            $('#divWelcome').css('display', 'none');
                            $('#divFillScreen').removeTemplate();
                            $('#divFillScreen').setTemplateURL('Login92.htm');
                            $('#divFillScreen').processTemplate();
                        }
                        BindLeakeges();
                        var txtAmountPayable = msg[0].TotalAmount;
                        var txtTodayAmont = msg[0].TodayAmount;
                        HdnIndentNo = msg[0].IndentNo;
                        var rr = $('#hdnIndentNo').val(msg[0].IndentNo);

                        var PayAmount = 0;
                        //                        if (msg[0].TotalAmount == 0) {
                        PayAmount = parseFloat(msg[0].TotalAmount);
                        //                        }
                        //                        else {
                        //                            PayAmount = parseFloat(msg[0].TotalAmount);
                        //                        }
                        document.getElementById('txtAmountPayable').innerHTML = parseFloat(PayAmount).toFixed(2);
                        document.getElementById('txtTodayAmont').innerHTML = parseFloat(txtTodayAmont).toFixed(2);
                        document.getElementById('txtDeductions').innerHTML = 0;
                        var TotAmount = parseFloat(PayAmount) + parseFloat(txtTodayAmont);
                        document.getElementById('txtTotalAmount').innerHTML = parseFloat(TotAmount).toFixed(2);
                        var tot = parseFloat(TotAmount) - parseFloat(txtTodayAmont);
                        document.getElementById('txtBalanceAmount').innerHTML = parseFloat(tot).toFixed(2);
                        BindDeliverInventory();
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
        }
        var Changebutton = "";
        function ChangebtnText() {
            var data = { 'op': 'getTodayDate', 'bid': bid };
            var s = function (msg) {
                if (msg) {
                    if (msg != null) {
                        Changebutton = "Edit";
                    }
                    else {
                        Changebutton = "Save";
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindLeakeges() {

            var data = { 'op': 'getBranchLeakeges', 'bid': bid };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    $('#divleakes').setTemplateURL('Leakages11.htm');
                    $('#divleakes').processTemplate(msg);
                    CollectionCal();
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);

        }
        function DeliverCal() {
            $('.GivenQtyclass').each(function (i, obj) {
                var Qty = $(this).closest("tr").find('.InvQtyClass').text();
                if (Qty == "" || Qty == "0") {
                }
                else {
                    var GivenQty = $(this).val();
                    if (GivenQty == "0" || GivenQty == "") {
                        GivenQty = 0;
                        var balanceQty = parseInt(Qty) + parseInt(GivenQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(balanceQty);
                    }
                    else {
                        var balanceQty = parseInt(Qty) + parseInt(GivenQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(balanceQty);
                    }
                }
            });
        }
        function DeliverOffCal() {
            $('.GivenQtyclass').each(function (i, obj) {
                var Qty = $(this).closest("tr").find('.InvQtyClass').text();
                if (Qty == "") {
                }
                else {
                    var GivenQty = $(this).val();
                    if (GivenQty == "0" || GivenQty == "") {
                        GivenQty = 0;
                        $(this).closest("tr").find('.InvQtyClass').text(Qty);
                        $(this).closest("tr").find('.GivenQtyclass').val(GivenQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(Qty);
                    }
                    else {
                        var balanceQty = parseInt(Qty) - parseInt(GivenQty);
                        $(this).closest("tr").find('.InvQtyClass').text(balanceQty);
                        var qty = parseInt(balanceQty) + parseInt(GivenQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(qty);
                    }
                }
            });
        }
        function colInventoryCal() {
            $('.ReceivedQtyclass').each(function (i, obj) {
                var Qty = $(this).closest("tr").find('.InvQtyClass').text();
                if (Qty == "") {
                }
                else {
                    var GivenQty = $(this).val();
                    if (GivenQty == "0" || GivenQty == "") {
                        GivenQty = 0;
                        $(this).closest("tr").find('.InvQtyClass').text(Qty);
                        $(this).closest("tr").find('.ReceivedQtyclass').val(GivenQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(Qty);
                    }
                    else {
                        var balanceQty = parseInt(Qty);
                        var qty = parseInt(balanceQty) - parseInt(GivenQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(qty);
                    }
                }
            });
        }
        function InvenCal() {
            $('.ReceivedQtyclass').each(function (i, obj) {
                var InvQtyClass = $(this).closest("tr").find('.InvQtyClass').text();
                if (InvQtyClass == "" || InvQtyClass == "0") {
                }
                else {
                    var Qty = $(this).closest("tr").find('.InvQtyClass').text();
                    var ReceivedQty = $(this).val();
                    if (ReceivedQty == "0" || ReceivedQty == "") {
                        ReceivedQty = 0;
                        var balanceQty = parseInt(Qty) - parseInt(ReceivedQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(balanceQty);
                    }
                    else {
                        var balanceQty = parseInt(Qty) - parseInt(ReceivedQty);
                        $(this).closest("tr").find('.ClassbalanceQty').text(balanceQty);
                    }
                }
            });
        }
        function CollectionCal() {
            var TotRate = 0.0;
            $('.TotalRateClass').each(function (i, obj) {
                if ($(this).text() == "") {
                }
                else {
                    TotRate += parseFloat($(this).text());
                }
            });
            document.getElementById('TotRate').innerHTML = parseFloat(TotRate).toFixed(2);
        }
        function CountChange(count) {
            var TotalCash = 0;
            var Total = 0;
            if (count.value == "") {
                $(count).closest("tr").find(".TotalClass").text(Total);
                document.getElementById('txtSubmittedAmount').value = Total;
                return false;
            }
            var Cash = $(count).closest("tr").find(".CashClass").text();
            if (Cash == "Vouchers") {
                Cash = 1;
            }
            Total = parseInt(count.value) * parseInt(Cash);
            $(count).closest("tr").find(".TotalClass").text(Total);
            $('.TotalClass').each(function (i, obj) {
                TotalCash += parseInt($(this).text());
            });
            document.getElementById('txt_Total').innerHTML = TotalCash;
            document.getElementById('txtSubmittedAmount').value = TotalCash;
            var totCash = document.getElementById('txtAmount').innerHTML;
            var BalCash = totCash - TotalCash;
            document.getElementById('txtBalanceAmount').innerHTML = parseFloat(BalCash).toFixed(2);
        }
        function ColCountChange(count) {
            var TotalCash = 0;
            var Total = 0;
            if (count.value == "") {
                $(count).closest("tr").find(".TotalClass").text(Total);
                $('.TotalClass').each(function (i, obj) {
                    var Amount = $(this).text();
                    if (Amount == "") {
                        Amount = 0.0;
                    }
                    TotalCash += parseFloat(Amount);
                });
                document.getElementById('txtAmont').innerHTML = parseFloat(TotalCash).toFixed(2);
                var Amount = document.getElementById('txtAmont').innerHTML;
                var ReturnAmount = document.getElementById('txtreturnAmount').innerHTML;
                var Total = parseFloat(Amount) - parseFloat(ReturnAmount);
                document.getElementById('txtCTotAmount').innerHTML = Total;
                return false;
            }
            else {
                var Cash = $(count).closest("tr").find(".CashClass").text();
                Total = parseFloat(count.value) * parseFloat(Cash);
                $(count).closest("tr").find(".TotalClass").text(Total);
                $('.TotalClass').each(function (i, obj) {
                    var Amount = $(this).text();
                    if (Amount == "") {
                        Amount = 0.0;
                    }
                    TotalCash += parseFloat(Amount);
                });
                document.getElementById('txtAmont').innerHTML = parseFloat(TotalCash).toFixed(2);
                var Amount = document.getElementById('txtAmont').innerHTML;
                var ReturnAmount = document.getElementById('txtreturnAmount').innerHTML;
                var Total = parseFloat(Amount) - parseFloat(ReturnAmount);
                document.getElementById('txtCTotAmount').innerHTML = Total;
            }
        }
        function ReturnCountChange(count) {
            var TotalCash = 0;
            var Total = 0;
            if (count.value == "") {
                $(count).closest("tr").find(".ReturnAmountClass").text(Total);
                $('.ReturnAmountClass').each(function (i, obj) {
                    var Amount = $(this).text();
                    if (Amount == "") {
                        Amount = 0.0;
                    }
                    TotalCash += parseFloat(Amount);
                });
                document.getElementById('txtreturnAmount').innerHTML = parseFloat(TotalCash).toFixed(2);
                var Amount = document.getElementById('txtAmont').innerHTML;
                var ReturnAmount = document.getElementById('txtreturnAmount').innerHTML;
                var Total = parseFloat(Amount) - parseFloat(ReturnAmount);
                document.getElementById('txtCTotAmount').innerHTML = Total;
                return false;
            }
            else {
                var Cash = $(count).closest("tr").find(".CashClass").text();
                Total = parseFloat(count.value) * parseFloat(Cash);
                $(count).closest("tr").find(".ReturnAmountClass").text(Total);
                $('.ReturnAmountClass').each(function (i, obj) {
                    var Amount = $(this).text();
                    if (Amount == "") {
                        Amount = 0.0;
                    }
                    TotalCash += parseFloat(Amount);
                });
                document.getElementById('txtreturnAmount').innerHTML = parseFloat(TotalCash).toFixed(2);
                var Amount = document.getElementById('txtAmont').innerHTML;
                var ReturnAmount = document.getElementById('txtreturnAmount').innerHTML;
                var Total = parseFloat(Amount) - parseFloat(ReturnAmount);
                document.getElementById('txtCTotAmount').innerHTML = Total;
            }
           
        }
        function OrderUnitChange(UnitQty) {
            var totalqty;
            var qty = 0.0;
            var Rate = 0;
            var rate = 0;
            var total = 0;
            var TotalRate = 0;
            var cnt = 0;
            if (UnitQty.value == "") {
                $(UnitQty).closest("tr").find("#txtOrderTotal").text(total);
                $('.Unitqtyclass').each(function (i, obj) {
                    var qtyclass = $(this).val();
                    if (qtyclass == "" || qtyclass == "0") {
                    }
                    else {
                        cnt++;
                    }
                });
                document.getElementById('txt_totqty').innerHTML = cnt;
                $('.rateclass').each(function (i, obj) {
                    rate += parseInt($(this).text());
                });
                var Floatrate = rate.toFixed(2)
                document.getElementById('txt_totRate').innerHTML = Floatrate;
                $('.totalclass').each(function (i, obj) {
                    total += parseInt($(this).text());
                });
                document.getElementById('txt_total').innerHTML = total;
                return false;
            }
            var Qty = $(UnitQty).closest("tr").find("#hdnUnitQty").val();
            var Units = $(UnitQty).closest("tr").find("#hdnUnits").val();
            Rate = $(UnitQty).closest("tr").find("#txtOrderRate").text();
            var Units = $(UnitQty).closest("tr").find("#hdnUnits").val();
            if (Units == "ml") {
                totalqty = parseFloat(UnitQty.value);
            }
            if (Units == "ltr") {
                totalqty = parseInt(UnitQty.value);
            }
            if (Units == "gms") {
                totalqty = parseFloat(UnitQty.value);
            }
            if (Units == "kgs") {
                totalqty = parseInt(UnitQty.value);
            }
            $(UnitQty).closest("tr").find("#hdnQty").val(totalqty)
            var FinalRate = 0;
            FinalRate = UnitQty.value * Rate;
            $(UnitQty).closest("tr").find("#txtOrderTotal").text(FinalRate);
            cnt = 0;
            $('.Unitqtyclass').each(function (i, obj) {
                var qtyclass = $(this).val();
                if (qtyclass == "" || qtyclass == "0") {
                }
                else {
                    cnt++;
                }
            });
            document.getElementById('txt_totqty').innerHTML = cnt;
            rate = 0;
            $('.rateclass').each(function (i, obj) {
                rate += parseInt($(this).text());
            });
            document.getElementById('txt_totRate').innerHTML = rate;
            total = 0;
            $('.totalclass').each(function (i, obj) {
                total += parseInt($(this).text());
            });
            document.getElementById('txt_total').innerHTML = total;
        }
        function FillInventory() {
            var data = { 'op': 'GetInventoryNames' };
            var s = function (msg) {
                if (msg) {
                    BindInventoryName(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindInventoryName(msg) {
            document.getElementById('cmb_Inventory').options.length = "";
            var veh = document.getElementById('cmb_Inventory');
            var length = veh.options.length;
            for (i = length - 1; i >= 0; i--) {
                veh.options[i] = null;
            }
            var opt = document.createElement('option');
            opt.innerHTML = "Select Inventory";
            opt.value = "";
            veh.appendChild(opt);
            for (var i = 0; i < msg.length; i++) {
                if (msg[i] != null) {
                    var opt = document.createElement('option');
                    opt.innerHTML = msg[i].InventoryName;
                    opt.value = msg[i].InventorySno;
                    veh.appendChild(opt);
                }
            }
        }
        function AddInventory() {
            FillInventory();
            $('#divMainAddNewRow').css('display', 'block');
        }
        var InventoryTable = [];
        function AddInventoryRows() {
            InventoryTable = [];
            var txtsno = 0;
            var txtInvName = "";
            var txtInvSno = "";
            var txtInvqty = "";
            var txtbalanceQty = "";
            var txtGivenQty = "";
            var rows = $("#tableInventory tr:gt(0)");
            var Inventory = document.getElementById('cmb_Inventory');
            var InventorySno = Inventory.options[Inventory.selectedIndex].value;
            var InventoryName = Inventory.options[Inventory.selectedIndex].text;
            var Checkexist = false;
            $('.InventoryClass').each(function (i, obj) {
                var IName = $(this).text();
                if (IName == InventoryName) {
                    alert("Inventory Already Added");
                    Checkexist = true;
                }
            });
            if (Checkexist == true) {
                return;
            }
            $(rows).each(function (i, obj) {
                if ($(this).find('#txtSno').text() != "") {
                    txtsno = $(this).find('#txtSno').text();
                    txtInvName = $(this).find('#txtInvName').text();
                    txtInvSno = $(this).find('#hdnInvSno').val();
                    txtGivenQty = $(this).find('#txtGivenQty').val();
                    txtInvqty = $(this).find('#txtInvqty').text();
                    txtbalanceQty = $(this).find('#txtbalanceQty').text();
                    InventoryTable.push({ Sno: txtsno, InventoryName: txtInvName, InventorySno: txtInvSno, Qty: txtInvqty,  ToadayQty: txtGivenQty });
                }
            });
            var Sno = parseInt(txtsno) + 1;
            var txtInvqty = 0;
            var Todayqty = 0;
            InventoryTable.push({ Sno: Sno, InventoryName: InventoryName, InventorySno: InventorySno, Qty: txtInvqty, ToadayQty: Todayqty });
            $('#divInventory').setTemplateURL('DeliverInventory9.htm');
            $('#divInventory').processTemplate(InventoryTable);
            if (DairyStatus == "Delivers") {
                DeliverCal();
            }
            else {
                DeliverOffCal();
            }
             db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
             db.transaction(function (tx) {
                 var EditMode = "Edit";
                 var BranchID = document.getElementById('ddlBranchName').value;
                 tx.executeSql('INSERT INTO Inventory (InventorySno,InventoryName,Qty,ToadayQty, BrancID,EditMode) VALUES ("' + InventorySno + '","' + InventoryName + '","' + txtInvqty + '","' + txtInvqty + '","' + BranchID + '","' + EditMode + '")');
                 tx.executeSql('INSERT INTO ReturnInventory1 (InventorySno,InventoryName,Qty,ToadayQty, BrancID,EditM) VALUES ("' + InventorySno + '","' + InventoryName + '","' + txtInvqty + '","' + txtInvqty + '","' + BranchID + '","' + EditMode + '")');
             });
         }
         function DeliverCal() {
             $('.GivenQtyclass').each(function (i, obj) {
                 var Qty = $(this).closest("tr").find('.InvQtyClass').text();
                 if (Qty == "") {
                 }
                 else {
                     var GivenQty = $(this).val();
                     if (GivenQty == "0" || GivenQty == "") {
                         GivenQty = 0;
                         $(this).closest("tr").find('.InvQtyClass').text(Qty);
                         $(this).closest("tr").find('.GivenQtyclass').val(GivenQty);
                         $(this).closest("tr").find('.ClassbalanceQty').text(Qty);
                     }
                     else {
                         var balanceQty = parseInt(GivenQty);
                         $(this).closest("tr").find('.InvQtyClass').text(Qty);
                         var qty = parseInt(balanceQty);
                         $(this).closest("tr").find('.ClassbalanceQty').text(qty);
                     }
                 }
             });
         }
        function btnInventoryAddClick() {
            var InventoryName = document.getElementById('cmb_Inventory').value;
            if (InventoryName == "select Inventory" || InventoryName == "") {
                alert("Select Inventory Name");
                return false;
            }
            AddInventoryRows();
        }
        function CollectionLeakQtyQtyChange(Leakageqty) {
            if (Leakageqty.value == "") {
                var AQty = $(Leakageqty).closest("tr").find("#txtqty").text();
                var DQty = parseFloat(AQty) - parseFloat(0);
                $(Leakageqty).closest("tr").find("#txtReturnqty").val(DQty);
                var Rate = $(Leakageqty).closest("tr").find("#hdnCost").val();
                var TotRate = parseFloat(DQty) * parseFloat(Rate);
                $(Leakageqty).closest("tr").find("#txtTotal").text(TotRate);
                return false;
            }
            var AQty = $(Leakageqty).closest("tr").find("#txtqty").text();
            var DQty = parseFloat(AQty) - parseFloat(Leakageqty.value);
            $(Leakageqty).closest("tr").find("#txtReturnqty").val(DQty);
            var Rate = $(Leakageqty).closest("tr").find("#hdnCost").val();
            var TotRate = parseFloat(DQty) * parseFloat(Rate);
            $(Leakageqty).closest("tr").find("#txtTotal").text(TotRate);
            var TotRate = 0.0;
            $('.TotalRateClass').each(function (i, obj) {
                if ($(this).text() == "") {
                }
                else {
                    TotRate += parseFloat($(this).text());
                }
            });
            document.getElementById('TotRate').innerHTML = TotRate;
            var hdnDqty = $(Leakageqty).closest("tr").find("#hdnDelQty").val();
            var ChangeDqty = $(Leakageqty).closest("tr").find("#txtReturnqty").val();
            var totDqty = hdnDqty - ChangeDqty;
            var Rate = $(Leakageqty).closest("tr").find("#hdnCost").val();
            var DelRate = parseFloat(totDqty) * parseFloat(Rate)
            var AmountPayable = document.getElementById('txtAmountPayable').innerHTML;
            $(Leakageqty).closest("tr").find("#hdnTotChange").text(DelRate);
            var TotChange = 0;
            $('.hdnTotChangeClass').each(function (i, obj) {
                if ($(this).text() == "") {
                }
                else {
                    TotChange += parseFloat($(this).text());
                }
            });
            document.getElementById('hdnqty').innerHTML = TotChange;
            document.getElementById('txtTodayAmont').innerHTML = TotChange;
            var TotalAmount = parseFloat(AmountPayable) - parseFloat(TotChange);
            document.getElementById('txtTotalAmount').innerHTML = TotalAmount;
        }
        function CollectionReturnQtyChange(Leakageqty) {
            if (Leakageqty.value == "") {
                //                var AQty = $(Leakageqty).closest("tr").find("#txtqty").text();
                var DQty = 0;
                var Rate = $(Leakageqty).closest("tr").find("#hdnCost").val();
                var TotRate = parseFloat(DQty) * parseFloat(Rate);
                $(Leakageqty).closest("tr").find("#txtTotal").text(TotRate);
                return false;
            }
            //            var AQty = $(Leakageqty).closest("tr").find("#txtqty").text();
            var DQty = parseFloat(Leakageqty.value);
            var Rate = $(Leakageqty).closest("tr").find("#hdnCost").val();
            var TotRate = parseFloat(DQty) * parseFloat(Rate);
            $(Leakageqty).closest("tr").find("#txtTotal").text(TotRate);
            var TotRate = 0.0;
            $('.TotalRateClass').each(function (i, obj) {
                if ($(this).text() == "") {
                }
                else {
                    TotRate += parseFloat($(this).text());
                }
            });
            document.getElementById('TotRate').innerHTML = TotRate;
            var hdnDqty = $(Leakageqty).closest("tr").find("#hdnDelQty").val();
            var ChangeDqty = Leakageqty.value;
            var totDqty = hdnDqty - ChangeDqty;
            var Rate = $(Leakageqty).closest("tr").find("#hdnCost").val();
            var DelRate = parseFloat(totDqty) * parseFloat(Rate)
            var AmountPayable = document.getElementById('txtAmountPayable').innerHTML;
            $(Leakageqty).closest("tr").find("#hdnTotChange").text(DelRate);
            var TotChange = 0;
            $('.hdnTotChangeClass').each(function (i, obj) {
                if ($(this).text() == "") {
                }
                else {
                    TotChange += parseFloat($(this).text());
                }
            });
            document.getElementById('hdnqty').innerHTML = TotChange;
            //            document.getElementById('txtTodayAmont').innerHTML = TotChange;
            //            var TotalAmount = parseFloat(AmountPayable) - parseFloat(TotChange);
            document.getElementById('txtTodayAmont').innerHTML = document.getElementById('TotRate').innerHTML;
            var PayAmount = document.getElementById('txtAmountPayable').innerHTML;
            var txtTodayAmont = document.getElementById('txtTodayAmont').innerHTML;
            var TotAmount = parseFloat(PayAmount) + parseFloat(txtTodayAmont);
            document.getElementById('txtTotalAmount').innerHTML = TotAmount;
            var PaidAmount = document.getElementById('txtPaidAmount').value;
            if (PaidAmount == "") {
                PaidAmount = 0;
            }
            document.getElementById('txtBalanceAmount').innerHTML = parseFloat(TotAmount) - parseFloat(PaidAmount);
        }
        function DeliverReturnQtyChange(Qty) {
            var Returnqty = 0;
            var LQty = 0;
            var cqty = 0;
            if (Qty.value == "") {
                LQty = $(Qty).closest("tr").find("#txtLeakQty").val();
                cqty = 0;
                var IndentQty = parseFloat(LQty) + parseFloat(0);
                var Totalqty = $(Qty).closest("tr").find("#hdnRemainingQty").val();
                var Indqty = $(Qty).closest("tr").find("#txtqty").text();
                var lQty = parseFloat(Indqty) - parseFloat(cqty);
                var TotalIndent = 0;
                if (lQty > 0) {
                    TotalIndent = parseFloat(Totalqty) + parseFloat(lQty);
                }
                else {
                    lQty = Math.abs(lQty);
                    TotalIndent = parseFloat(Totalqty) - parseFloat(lQty);
                }
                $(Qty).closest("tr").find("#txtRemainingQty").text(TotalIndent.toFixed(2));
                $('.Returnqtyclass').each(function (i, obj) {
                    if ($(this).val() == "") {
                    }
                    else {
                        Returnqty += parseFloat($(this).val());
                    }
                });
                document.getElementById('txt_RetunQty').innerHTML = Returnqty;
                return false;
            }
            else {
                LQty = $(Qty).closest("tr").find("#txtLeakQty").val();
                cqty = Qty.value;
                //              if (parseFloat(AQty) <parseFloat(cqty)) {
                var IndentQty = parseFloat(LQty) + parseFloat(Qty.value);
                var Totalqty = $(Qty).closest("tr").find("#hdnRemainingQty").val();
                if (Totalqty == "") {
                    Totalqty = "0";
                }
                var Indqty = $(Qty).closest("tr").find("#txtqty").text();
                var lQty = parseFloat(Indqty) - parseFloat(cqty);
                var TotalIndent = 0;
                if (lQty > 0) {
                    TotalIndent = parseFloat(Totalqty) + parseFloat(lQty);
                }
                else {
                    lQty = Math.abs(lQty);
                    TotalIndent = parseFloat(Totalqty) - parseFloat(lQty);
                }
                $(Qty).closest("tr").find("#txtRemainingQty").text(TotalIndent.toFixed(2));
                //              }
                $('.Returnqtyclass').each(function (i, obj) {
                    Returnqty += parseFloat($(this).val());
                });
                document.getElementById('txt_RetunQty').innerHTML = Returnqty;
            }
        }
        function OfferDeliverReturnQtyChange(Qty) {
            var Returnqty = 0;
            var LQty = 0;
            var cqty = 0;
            if (Qty.value == "") {
                LQty = $(Qty).closest("tr").find("#txtLeakQty").val();
                cqty = 0;
                var IndentQty = parseFloat(LQty) + parseFloat(0);
                var Totalqty = $(Qty).closest("tr").find("#hdnRemainingQty").val();
                var Indqty = $(Qty).closest("tr").find("#txtqty").text();
                var lQty = parseFloat(Indqty) - parseFloat(cqty);
                var TotalIndent = 0;
                if (lQty > 0) {
                    TotalIndent = parseFloat(Totalqty) + parseFloat(lQty);
                }
                else {
                    lQty = Math.abs(lQty);
                    TotalIndent = parseFloat(Totalqty) - parseFloat(lQty);
                }
                $(Qty).closest("tr").find("#txtRemainingQty").text(TotalIndent.toFixed(2));
                $('.OfferReturnqtyclass').each(function (i, obj) {
                    if ($(this).val() == "") {
                    }
                    else {
                        Returnqty += parseFloat($(this).val());
                    }
                });
                document.getElementById('txt_OfferRetunQty').innerHTML = Returnqty;
                return false;
            }
            else {
                //LQty = $(Qty).closest("tr").find("#txtLeakQty").val();
                cqty = Qty.value;
                //              if (parseFloat(AQty) <parseFloat(cqty)) {
                var IndentQty = parseFloat(LQty) + parseFloat(Qty.value);
                var Totalqty = $(Qty).closest("tr").find("#hdnRemainingQty").val();
                if (Totalqty == "") {
                    Totalqty = "0";
                }
                var Indqty = $(Qty).closest("tr").find("#txtqty").text();
                var lQty = parseFloat(Indqty) - parseFloat(cqty);
                var TotalIndent = 0;
                if (lQty > 0) {
                    TotalIndent = parseFloat(Totalqty) + parseFloat(lQty);
                }
                else {
                    lQty = Math.abs(lQty);
                    TotalIndent = parseFloat(Totalqty) - parseFloat(lQty);
                }
                $(Qty).closest("tr").find("#txtRemainingQty").text(TotalIndent.toFixed(2));
                //              }
                $('.OfferReturnqtyclass').each(function (i, obj) {
                    Returnqty += parseFloat($(this).val());
                });
                document.getElementById('txt_OfferRetunQty').innerHTML = Returnqty;
            }
        }
        function LeakQtyQtyChange(Qty) {
            var Leakqty = 0;
            if (Qty.value == "") {
                var AQty = $(Qty).closest("tr").find("#txtqty").text();
                var DQty = parseFloat(AQty) - parseFloat(0);
                $(Qty).closest("tr").find("#txtReturnqty").val(DQty);
                var IndentQty = parseFloat(0);
                var Totalqty = $(Qty).closest("tr").find("#hdnRemainingQty").val();
                var TotalIndent = parseFloat(Totalqty) - parseFloat(IndentQty);
                $(Qty).closest("tr").find("#txtRemainingQty").text(TotalIndent.toFixed(2));
                return false;
            }
            var AQty = $(Qty).closest("tr").find("#txtqty").text();
            var DQty = parseFloat(AQty) - parseFloat(Qty.value);
            $(Qty).closest("tr").find("#txtReturnqty").val(DQty);
            var dcQty = parseFloat(Qty.value) + parseFloat(DQty);
            var IndentQty = parseFloat(dcQty);
            var Totalqty = $(Qty).closest("tr").find("#hdnRemainingQty").val();
            var TotalIndent = parseFloat(Totalqty) - parseFloat(IndentQty);
            $(Qty).closest("tr").find("#txtRemainingQty").text(TotalIndent.toFixed(2));
        }
        function CallHandlerUsingJson_POST(d, s, e) {
            d = JSON.stringify(d);
            //    d = d.replace(/&/g, '\uFF06');
            //    d = d.replace(/#/g, '\uFF03');
            //    d = d.replace(/\+/g, '\uFF0B');
            //    d = d.replace(/\=/g, '\uFF1D');
            d = encodeURIComponent(d);
            $.ajax({
                type: "POST",
                url: "Bus.axd",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: d,
                async: true,
                cache: true,
                success: s,
                error: e
            });
        }
        function CallHandlerUsingJson(d, s, e) {
            $.ajax({
                type: "GET",
                url: "Bus.axd?json=",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(d),
                async: true,
                cache: true,
                success: s,
                error: e
            });
        }
        function callHandler(d, s, e) {
            $.ajax({
                url: 'Bus.axd',
                data: d,
                type: 'GET',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: true,
                success: s,
                error: e
            });
        }
        function numberOnlyExample() {
            if ((event.keyCode < 48) || (event.keyCode > 57))
                return false;
        }

        function divReportsclick() {
         $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divHide').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'none');
            $('#DivIndentType').css('display', 'none');
            $('#divOrders').css('display', 'none');
            $('#divIndentReporting').css('display', 'none');
            $('#divSync').css('display', 'none');
            $('#divDelivers').css('display', 'none');
            $('#divCollections').css('display', 'none');
            $('#divReports').css('display', 'none');
            $('#divDispatch').css('display', 'none');
            $('#divShortage').css('display', 'none');
            $('#divReporting').css('display', 'none');
            $('#divInvReporting').css('display', 'none');
            $('#divAmountReporting').css('display', 'none');
            $('#divVerifyInventory').css('display', 'none');
            $('#tableEmployee').css('display', 'none');
            $('#divCollectionReport').css('display', 'block');
            $('#divInventoryReport').css('display', 'block');
            $('#divDeliverReport').css('display', 'block');
            $('#divOrderReport').css('display', 'block');
            $('#divstatus').css('display', 'block');
            $('#divNextDayIndentReport').css('display', 'block');
            $('#divAgentRanking').css('display', 'none');
            $('#divOfflineIndent').css('display', 'none');
        }
        $(document).ready(function () {
            $("#divback").hide();
        });
        function BindOrdersclick(data) {
            $('#divFillScreen').processTemplate(data);
            if (data[0].IndentNo != "") {
                $('#hdnIndentNo').val(data[0].IndentNo);
            }
            OrderRefresh();
        }
        //////////////////Inventory//////////////////////
        function BindDeliverInventory() {
            var data = { 'op': 'GetDeliverInventory', 'bid': bid, 'DairyStatus': DairyStatus };
            var s = function (msg) {
                if (msg) {
                    //                    CollectionCal();
                    if (DairyStatus == "Delivers") {
                        $('#divInventory').setTemplateURL('DeliverInventory9.htm');
                        $('#divInventory').processTemplate(msg);
                        DeliverCal();
                    }
                    if (DairyStatus == "Collections") {
                        $('#divInventory').setTemplateURL('CollectionInventory9.htm');
                        $('#divInventory').processTemplate(msg);
                        InvenCal();
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        var TotalInvqty = 0;
        function GivenQtyChange(Givenqty) {
            var Qty = $(Givenqty).closest("tr").find("#txtInvqty").text();
            if (Givenqty.value == "") {
                TotalInvqty = parseInt(Qty) + parseInt(0);
                $(Givenqty).closest("tr").find("#txtbalanceQty").text(TotalInvqty);
                return false;
            }
            TotalInvqty = parseInt(Qty) + parseInt(Givenqty.value);
            $(Givenqty).closest("tr").find("#txtbalanceQty").text(TotalInvqty);
        }
        function ReceivedQtyChange(ReceivedQty) {
            var Qty = $(ReceivedQty).closest("tr").find("#txtInvqty").text()
            if (ReceivedQty.value == "") {
                $(ReceivedQty).closest("tr").find("#txtbalanceQty").text(Qty);
                return false;
            }
            TotalInvqty = parseInt(Qty) - parseInt(ReceivedQty.value);
            $(ReceivedQty).closest("tr").find("#txtbalanceQty").text(TotalInvqty);
        }
        var DeliveryProductData = [];
        var OfferDeliveryProductData = [];
        var DeliveryInventoryData = [];
        var ReportDelStatus = "";
        function divDeliveryclick() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT AmountStatus FROM tripdata1', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        if (obj.AmountStatus == "N") {
                            alert("Reporting already Submited");
                            ReportDelStatus = "true";
                            return false;
                        }
                    }
                });
                tx.executeSql('SELECT InventoryStatus FROM InventoryReport1', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        if (obj.InventoryStatus == "N") {
                            alert("Reporting already Submited");
                            ReportDelStatus = "true";
                            return false;
                        }
                    }
                });
            });

            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = "";
                    }
                    else {
                        loginStatus = "OFFLINE";
                        if (loginStatus == "OFFLINE") {

                            var BranchName = document.getElementById('ddlBranchName').value;
                            if (BranchName == "Select Agent" || BranchName == "") {
                                alert("Please Select Agent Name");
                                return false;
                            }
                            if (ReportDelStatus == "true") {
                                return false;
                            }
                            DairyStatus = "Delivers";
                            var BranchIndent = [];
                            var OfferIndent = [];
                            var TripSubData = [];
                            var DelStatus = "";
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                tx.executeSql('SELECT * FROM tripsubdata1  order by Rank ASC', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        var ProductId = obj.ProductId;
                                        var Qty = obj.Qty;
                                        var DeliverQty = obj.DeliverQty;
                                        var ProductName = obj.ProductName;
                                        TripSubData.push({ ProductId: ProductId, Qty: Qty, DeliverQty: DeliverQty, ProductName: ProductName });
                                    }
                                });
                            });
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                tx.executeSql('SELECT * FROM IndentData1 WHERE (BrancID="' + BranchName + '") order by Rank ASC', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        var DelQty = obj.DeliverQty;
                                        DelStatus = obj.Status;
                                        var Dqty = 0;
                                        var Deqty = 0;
                                        if (DelQty == "") {
                                            DelQty = "0";
                                            Deqty = 0; 
                                            Dqty = obj.UnitQty;
                                        }
                                        else {
                                            Dqty = parseFloat(obj.DeliverQty);
                                            Deqty = parseFloat(obj.DeliverQty);
                                        }
                                        var LeakQty = obj.LeakQty;
                                        if (LeakQty == "") {
                                            LeakQty = "0";
                                        }
                                        else {
                                            LeakQty = parseFloat(obj.LeakQty);
                                        }
                                        var UnitQty = obj.UnitQty;
                                        if (UnitQty == "0" && DelQty == "0") {
                                        }
                                        else {
                                            for (var k = 0; k < TripSubData.length; k++) {
                                                if (TripSubData[k].ProductId == obj.ProductId) {
                                                    var DeliverQty = parseFloat(TripSubData[k].DeliverQty);
                                                    var Qty = parseFloat(TripSubData[k].Qty);
                                                    var RQty = 0;
                                                    RQty = parseFloat(Qty) - parseFloat(DeliverQty);
                                                    RQty = parseFloat(RQty) - parseFloat(Dqty);
                                                    RQty = parseFloat(RQty).toFixed(2);
                                                    BranchIndent.push({ sno: i + 1, ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, RQty: RQty, TRQty: obj.UnitQty, LeakQty: LeakQty, Qty: obj.UnitQty, DQty: Dqty, orderunitRate: obj.UnitCost, Edit: obj.EditMode });
                                                }
                                            }
                                        }
                                    }
                                    $('#divback').css('display', 'block');
                                    $('#divHide').css('display', 'none');
                                    $('#divRouteOrder').css('display', 'none');
                                    $('#divFillScreen').css('display', 'block');
                                    $('#divFillScreen').setTemplateURL('Delivers15.htm');
                                    $('#divFillScreen').processTemplate(BranchIndent);
//                                    $('#divOfferindent').setTemplateURL('OfferDelivery.htm');
//                                    $('#divOfferindent').processTemplate(BranchIndent);
                                    
                                    var Returnqty = 0;
                                    $('.Returnqtyclass').each(function (i, obj) {
                                        if ($(this).val() == "") {
                                        }
                                        else {
                                            Returnqty += parseFloat($(this).val());
                                        }
                                    });
                                    document.getElementById('txt_RetunQty').innerHTML = Returnqty;
                                    //                                    DeliveryProductData = BranchIndent;
                                });
                            });




                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {

                                tx.executeSql('SELECT * FROM OfferIndent WHERE (BranchID="' + BranchName + '") ', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var a = 0; a < len; a++) {
                                        var obj = results.rows.item(a);
                                        var DelQty = obj.Delivery;
                                        var Dqty = 0;
                                        var Deqty = 0;
                                        if (DelQty == "") {
                                            DelQty = "0";
                                            Deqty = 0;
                                            Dqty = obj.Indent;
                                        }
                                        else {
                                            Dqty = parseFloat(obj.Delivery);
                                            Deqty = parseFloat(obj.Delivery);
                                        }

                                        var UnitQty = obj.Indent;
                                       // if (UnitQty == "0" && DelQty == "0") {
                                        //}
                                        //else {
                                            for (var k = 0; k < TripSubData.length; k++) {
                                                if (TripSubData[k].ProductId == obj.ProductId) {
                                                    var DeliverQty = parseFloat(TripSubData[k].DeliverQty);
                                                    var Qty = parseFloat(TripSubData[k].Qty);
                                                    var RQty = 0;
                                                    RQty = parseFloat(Qty) - parseFloat(DeliverQty);
                                                    RQty = parseFloat(RQty) - parseFloat(Dqty);
                                                    RQty = parseFloat(RQty).toFixed(2);
                                                    OfferIndent.push({ sno: a , ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, RQty: RQty, TRQty: obj.Indent, Qty: obj.Indent, DQty: Dqty });
                                                }
                                            }
                                        //}
                                    }
//                                    $('#divback').css('display', 'block');
//                                    $('#divHide').css('display', 'none');
//                                    $('#divRouteOrder').css('display', 'none');
//                                    $('#divFillScreen').css('display', 'block');
//                                    $('#divFillScreen').setTemplateURL('Delivers15.htm');
//                                    $('#divFillScreen').processTemplate(BranchIndent);
                                    $('#divOfferindent').setTemplateURL('OfferDelivery.htm');
                                    $('#divOfferindent').processTemplate(OfferIndent);

                                    var Returnqty = 0;
                                    $('.OfferReturnqtyclass').each(function (i, obj) {
                                        if ($(this).val() == "") {
                                        }
                                        else {
                                            Returnqty += parseFloat($(this).val());
                                        }
                                    });
                                    document.getElementById('txt_OfferRetunQty').innerHTML = Returnqty;
                                    //                                    DeliveryProductData = BranchIndent;
                                });
                            });






                            var BranchInventory = [];
                            db.transaction(function (tx) {
                                tx.executeSql('SELECT * FROM Inventory WHERE (BrancID="' + BranchName + '") order by InventorySno', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; ++i) {
                                        var obj = results.rows.item(i);
                                        BranchInventory.push({ Sno: i + 1, InventoryName: obj.InventoryName, InventorySno: obj.InventorySno, Qty: obj.Qty, ToadayQty: obj.ToadayQty, Edit: obj.EditMode });
                                    }
                                    $('#divInventory').setTemplateURL('DeliverInventory9.htm');
                                    $('#divInventory').processTemplate(BranchInventory);
                                    //                                    DeliveryInventoryData = BranchInventory;
                                    DeliverOffCal();
                                    if (DelStatus == "Delivered") {
                                        $(".Returnqtyclass").attr("disabled", true);
                                        $(".GivenQtyclass").attr("disabled", true);
                                        $(".OfferReturnqtyclass").attr("disabled", true);
                                        
                                        document.getElementById('BtnSave').value = "Edit";
                                    }
                                });
                            });

                            //            $('#tableOrder').css('display', 'block');

                            //            if (bid != "") {
                            //                BranchChane();
                            ////                BindDeliverInventory();
                            //            }
                        }
                        else {
                            var BranchName = document.getElementById('ddlBranchName').value;
                            if (BranchName == "Select Agent" || BranchName == "") {
                                alert("Please Select Agent Name");
                                return false;
                            }
                            DairyStatus = "Delivers";
                            //            $('#tableOrder').css('display', 'block');
                            $('#divback').css('display', 'block');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divFillScreen').setTemplateURL('Delivers15.htm');
                            $('#divFillScreen').processTemplate();
                            if (bid != "") {
                                BranchChane();
                                //                BindDeliverInventory();
                            }
                        }
                    }
                });
            });
        }
        function divDispatchclick() {
            $('#divback').css('display', 'block');
            var EmpID = document.getElementById('ddlEmployee').value;
            //            var DispDate = document.getElementById('datepicker').value;
            if (EmpID == "select") {
                alert("Please Select Emp Name");
                return false;
            }
            //            if (DispDate == "" || DispDate=="mm/dd/yyyy") {
            //                alert("Please Select Date");
            //                return false;
            //            }
            GetTripNo();

            $('#divback').css('display', 'block');
            $('#divHide').css('display', 'none');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            bindDispProductRoute();

        }
        function DispatchQtyChange(Qty) {
            if (Qty.Value == "") {
                var RemainQty = $(Qty).closest("tr").find("#hdnRemainQty").val();
                var PDispQty = $(Qty).closest("tr").find("#hdnDispQty").val();
                var DispQty = 0;
                var TDispQty = DispQty - PDispQty;
                var Total = parseFloat(RemainQty) - parseFloat(DispQty);
                $(Qty).closest("tr").find("#txtRemainQty").text(Total);
            }
            else {
                var RemainQty = $(Qty).closest("tr").find("#hdnRemainQty").val();
                var PDispQty = $(Qty).closest("tr").find("#hdnDispQty").val();
                var DispQty = Qty.value;
                var TDispQty = DispQty - PDispQty;
                var Total = parseFloat(RemainQty) - parseFloat(TDispQty);
                $(Qty).closest("tr").find("#txtRemainQty").text(Total);
            }
        }
        function DispatchInventoryChange(Qty) {
            if (Qty.Value == "") {
                var RemainQty = $(Qty).closest("tr").find("#hdnInvRemainQty").val();
                var PDispQty = $(Qty).closest("tr").find("#hdnDispInvQty").val();
                var DispQty = 0;
                var TDispQty = DispQty - PDispQty;
                var Total = parseFloat(RemainQty) - parseFloat(TDispQty)
                $(Qty).closest("tr").find("#txtInvRemainQty").text(Total);
            }
            else {
                var RemainQty = $(Qty).closest("tr").find("#hdnInvRemainQty").val();
                var PDispQty = $(Qty).closest("tr").find("#hdnDispInvQty").val();
                var DispQty = Qty.value;
                var TDispQty = DispQty - PDispQty;
                var Total = parseFloat(RemainQty) - parseFloat(TDispQty)
                $(Qty).closest("tr").find("#txtInvRemainQty").text(Total);
            }
        }
        function BindVerifyInventory() {
            var ddlRouteName = document.getElementById('ddlRouteName').value;
            if (ddlRouteName == "") {
                alert("Please Select Route");
                return false;
            }
            else {
                var data = { 'op': 'GetVerifyInventory', 'RouteSno': ddlRouteName };
                var s = function (msg) {
                    if (msg) {
                        if (msg == "Session Expired") {
                            alert(msg);
                            $('#divback').css('display', 'none');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divLogOut').css('display', 'none');
                            $('#divWelcome').css('display', 'none');
                            $('#divFillScreen').removeTemplate();
                            $('#divFillScreen').setTemplateURL('Login92.htm');
                            $('#divFillScreen').processTemplate();
                        }
                        $('#divFillScreen').setTemplateURL('InventoryVerify9.htm');
                        $('#divFillScreen').processTemplate(msg);
                        BindLeakReporting();
                        BindReturnReporting();
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
        }
        function BindLeakReporting() {
            var ddlRouteName = document.getElementById('ddlRouteName').value;
            if (ddlRouteName == "") {
                alert("Please Select Route");
                return false;
            }
            var data = { 'op': 'GetVerifyLeaks', 'RouteSno': ddlRouteName };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    $('#LeakReporting').removeTemplate();
                    $('#LeakReporting').setTemplateURL('VerifyLeaks10.htm');
                    $('#LeakReporting').processTemplate(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindReturnReporting() {
            var ddlRouteName = document.getElementById('ddlRouteName').value;
            if (ddlRouteName == "") {
                alert("Please Select Route");
                return false;
            }
            var data = { 'op': 'GetVerifyReturns', 'RouteSno': ddlRouteName };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    $('#ReturnReporting').removeTemplate();
                    $('#ReturnReporting').setTemplateURL('VarifyReturns10.htm');
                    $('#ReturnReporting').processTemplate(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function btnReturnsVarifySaveClick() {
            if (!confirm("Do you want to Save")) {
                return false;
            }
            var rowsVarifyReturndetails = $("#VarifyReturndetails tr:gt(0)");
            var VarifyReturndetails = new Array();
            $(rowsVarifyReturndetails).each(function (i, obj) {
                if ($(this).find('#txtsno').text() != "") {
                    VarifyReturndetails.push({ ProductID: $(this).find('#hdnProductSno').val(), ReturnsQty: $(this).find('#txtReturnsQty').val(), TripID: $(this).find('#hdnTripID').val() });
                }
            });
            var data = { 'op': 'btnReturnsVarifySaveClick', 'RouteLeakdetails': VarifyReturndetails };
            var s = function (msg) {
                if (msg) {
                    alert(msg);
                    if (msg == "Session Expired") {
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindReturnReporting();
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            CallHandlerUsingJson(data, s, e);
        }
        function btnLeakVarifySaveClick() {
            if (!confirm("Do you want to Save")) {
                return false;
            }
            var rowsVarifyRouteLeakdetails = $("#VarifyLeakdetails tr:gt(0)");
            var VarifyRouteLeakdetails = new Array();
            $(rowsVarifyRouteLeakdetails).each(function (i, obj) {
                if ($(this).find('#txtsno').text() != "") {
                    VarifyRouteLeakdetails.push({ ProductID: $(this).find('#hdnProductSno').val(), LeaksQty: $(this).find('#txtLeaksQty').val(), TripID: $(this).find('#hdnTripID').val() });
                }
            });
            var data = { 'op': 'btnLeakVarifySaveClick', 'RouteLeakdetails': VarifyRouteLeakdetails };
            var s = function (msg) {
                if (msg) {
                    alert(msg);
                    if (msg == "Session Expired") {
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindLeakReporting();
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            CallHandlerUsingJson(data, s, e);
        }
        function btnInventoryVerifySaveClick() {
            if (!confirm("Do you want to Save")) {
                return false;
            }
            //            var tripID = $(id).closest("tr").find('#hdntripID').val();
            //            var InvSno = $(id).closest("tr").find('#hdnInvSno').val();
            //            var SubmittQty = $(id).closest("tr").find('#txtSubmittQty').val();
            var rows = $("#tableInventoryVerify tr:gt(0)");
            var InvDatails = new Array();
            $(rows).each(function (i, obj) {
                if ($(this).find('#txtSno').text() != "" || $(this).find('#txtSubmittQty').val() != "") {
                    InvDatails.push({ SNo: $(this).find('#hdnInvSno').val(), Qty: $(this).find('#txtSubmittQty').val(), TripID: $(this).find('#hdntripID').val() });
                }
            });
            var rowsVarifyRouteLeakdetails = $("#VarifyRouteLeakdetails tr:gt(0)");
            var VarifyRouteLeakdetails = new Array();
            $(rowsVarifyRouteLeakdetails).each(function (i, obj) {
                if ($(this).find('#txtsno').text() != "" || $(this).find('#txtSubmittQty').val() != "") {
                    VarifyRouteLeakdetails.push({ ProductID: $(this).find('#hdnProductSno').val(), ReturnsQty: $(this).find('#txtReturnsQty').val(), LeaksQty: $(this).find('#txtLeaksQty').val(), TripID: $(this).find('#hdnTripID').val() });
                }
            });
            var data = { 'op': 'btnInventoryVerifySaveClick', 'InvDatails': InvDatails, 'RouteLeakdetails': VarifyRouteLeakdetails };
            var s = function (msg) {
                if (msg) {
                    alert(msg);
                    if (msg == "Session Expired") {
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindVerifyInventory();
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            CallHandlerUsingJson(data, s, e);
        }
        function divVerifyInventoryclick() {
            var ddlRouteName = document.getElementById('ddlRouteName').value;
            if (ddlRouteName == "") {
                alert("Please Select Route");
                return false;
            }
            else {
                $('#divback').css('display', 'block');
                $('#divHide').css('display', 'none');
                $('#divRouteOrder').css('display', 'none');
                $('#divFillScreen').css('display', 'block');

                BindVerifyInventory();
                $('#divFillScreen').setTemplateURL('InventoryVerify9.htm');
                $('#divFillScreen').processTemplate();
            }
        }
        var TripId = "";
        function GetTripNo() {
            var EmpID = document.getElementById('ddlEmployee').value;
            //            var DispDate = document.getElementById('datepicker').value;
            //            if (EmpID == "select") {
            //                alert("Please Select Emp Name");
            //                return false;
            //            }
            var data = { 'op': 'GetTripNo', 'EmpID': EmpID };
            var s = function (msg) {
                if (msg == "") {
                    TripId = "";
                }
                else {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    else {
                        TripId = msg;
                    }
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function bindDispProductRoute() {
            var IndentType = document.getElementById('ddlIndentType').value;
            var EmpID = document.getElementById('ddlEmployee').value;
            var data = { 'op': 'GetDispProducts', 'RouteId': RouteSno, 'IndentType': IndentType, 'EmpID': EmpID };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    $('#divFillScreen').setTemplateURL('Dipatch9.htm');
                    $('#divFillScreen').processTemplate(msg);
                    BindInventory();
                    if (TripId == "") {
                        $(".DispQtyclass").attr("disabled", false);
                        document.getElementById('BtnSave').value = "Save";
                    }
                    else {
                        $(".DispQtyclass").attr("disabled", true);
                        document.getElementById('BtnSave').value = "Edit";
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindInventory() {
            var data = { 'op': 'GetDispInventory' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    $('#DivDispatchInverntory').removeTemplate();
                    $('#DivDispatchInverntory').setTemplateURL('DispatchInventory9.htm');
                    $('#DivDispatchInverntory').processTemplate(msg);
                    if (TripId == "") {
                        $(".dispInvQtyclass").attr("disabled", false);
                    }
                    else {
                        $(".dispInvQtyclass").attr("disabled", true);
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function btnDispatchSaveClick() {
            var BtnSave = document.getElementById('BtnSave').value;
            //            var DispDate = document.getElementById('datepicker').value;
            if (BtnSave == "Edit") {
                if (!confirm("Do you want to Edit")) {
                    return false;
                }
                $(".DispQtyclass").attr("disabled", false);
                $(".dispInvQtyclass").attr("disabled", false);
                document.getElementById('BtnSave').value = "Save";
                return false;
            }
            if (!confirm("Do you want to Save")) {
                return false;
            }
            var rows = $("#tableDispdetails tr:gt(0)"); // skip the header row
            var Dispdetails = new Array();
            $(rows).each(function (i, obj) {
                if ($(this).find('#txtsno').text() == "") {
                }
                else {
                    if ($(this).find('#txtDispQty').val() == "") {
                    }
                    else {
                        Dispdetails.push({ SNo: $(this).find('#txtsno').text(), ProductSno: $(this).find('#hdnProductSno').val(), Product: $(this).find('#txtproduct').text(), RemainQty: $(this).find('#txtDispQty').val() });
                    }
                }
            });
            var rowsInventory = $("#tableDispInventorydetails tr:gt(0)"); // skip the header row
            var tableDispInventorydetails = new Array();
            $(rowsInventory).each(function (i, obj) {
                if ($(this).find('#txtsno').text() == "") {
                }
                else {
                    if ($(this).find('#txtDispInvQty').val() == "" || $(this).find('#txtDispInvQty').val() == "0") {
                    }
                    else {
                        tableDispInventorydetails.push({ SNo: $(this).find('#txtsno').text(), InvSno: $(this).find('#hdnInvSno').val(), ReceivedQty: $(this).find('#txtDispInvQty').val() });
                    }
                }
            });
            if (tableDispInventorydetails.length == 0) {
                alert("Please Fill  Inventory Qty");
                return false;
            }
            var EmpName = document.getElementById('ddlEmployee').value;
            var Data = { 'op': 'btnDispatchSaveClick', 'data': Dispdetails, 'EmpName': EmpName, 'RouteId': RouteSno, 'Inventorydetails': tableDispInventorydetails };
            var s = function (msg) {
                if (msg) {
                    alert(msg);
                    if (msg == "Session Expired") {
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    $(".DispQtyclass").attr("disabled", true);
                    $(".dispInvQtyclass").attr("disabled", true);
                    document.getElementById('BtnSave').value = "Edit";
                }
                else {
                    alert(msg);
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            CallHandlerUsingJson(Data, s, e);
        }
        var ShortStatus = "";
        function btnShoratageSaveClick() {
            if (loginStatus == "OFFLINE") {
                var BtnSave = document.getElementById('BtnSave').value;
                if (BtnSave == "Edit") {
                    ShortStatus = "Edit";
                    if (!confirm("Do you want to Edit")) {
                        return false;
                    }
                    $(".LeakQtyclass").attr("disabled", false);
                    $(".ShortQtyclass").attr("disabled", false);
                    $(".FreeMilkQtyclass").attr("disabled", false);
                    document.getElementById('BtnSave').value = "Save";
                    return false;
                }
                var rows = $("#tableShortagedetails tr:gt(0)"); // skip the header row
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                db.transaction(function (tx) {
                    var Dispdetails = new Array();
                    $(rows).each(function (i, obj) {
                        if ($(this).find('#txtsno').text() == "") {
                        }
                        else {
                            if ($(this).find('#txtLeakQty').val() == "" && $(this).find('#txtShortQty').val() == "" && $(this).find('#txtFreeMilkQty').val() == "") {
                            }
                            else {
                                var ShortQty = $(this).find('#txtShortQty').val();
                                var LeakQty = $(this).find('#txtLeakQty').val();
                                var FreeMilk = $(this).find('#txtFreeMilkQty').val();
                                var ProductID = $(this).find('#hdnProductSno').val();
                                if (ShortStatus == "Edit") {
                                    tx.executeSql('Update leakages set ShortQty="' + ShortQty + '",LeakQty="' + LeakQty + '",FreeMilk="' + FreeMilk + '"  where ProductID="' + ProductID + '"');
                                }
                                else {
                                    if (ShortQty == "0" && LeakQty == "0" && FreeMilk == "0") {
                                    }
                                    else {
                                        tx.executeSql('Update leakages set ShortQty="' + ShortQty + '",LeakQty="' + LeakQty + '",FreeMilk="' + FreeMilk + '"  where ProductID="' + ProductID + '"');
                                    }
                                }
                            }
                        }
                    });
//                    alert("Data Saved Successfully");
                    $(".LeakQtyclass").attr("disabled", true);
                    $(".ShortQtyclass").attr("disabled", true);
                    $(".FreeMilkQtyclass").attr("disabled", true);
                    document.getElementById('BtnSave').value = "Edit";
                    $('#divMsgAlert').css('display', 'block');
                    document.getElementById('lblAlertMsg').innerHTML = "Data Saved Successfully";
                    document.getElementById("imgAlert").src = "Images/Success.png";
                    document.getElementById("lblAlertMsg").style.color = '#59FA87';
                });
            }
            else {
                var BtnSave = document.getElementById('BtnSave').value;
                if (BtnSave == "Edit") {
                    $(".LeakQtyclass").attr("disabled", false);
                    $(".ShortQtyclass").attr("disabled", false);
                    $(".FreeMilkQtyclass").attr("disabled", false);
                    document.getElementById('BtnSave').value = "Save";
                    return false;
                }
                if (!confirm("Do you want to Save")) {
                    return false;
                }
                var rows = $("#tableShortagedetails tr:gt(0)"); // skip the header row
                var Dispdetails = new Array();
                $(rows).each(function (i, obj) {
                    if ($(this).find('#txtsno').text() == "") {
                    }
                    else {
                        if ($(this).find('#txtLeakQty').val() == "" && $(this).find('#txtShortQty').val() == "" && $(this).find('#txtFreeMilkQty').val() == "") {
                        }
                        else {
                            Dispdetails.push({ SNo: $(this).find('#txtsno').text(), ProductSno: $(this).find('#hdnProductSno').val(), Product: $(this).find('#txtproduct').text(), LeakQty: $(this).find('#txtLeakQty').val(), ShortQty: $(this).find('#txtShortQty').val(), FreeMilk: $(this).find('#txtFreeMilkQty').val() });
                        }
                    }
                });
                var Data = { 'op': 'btnShoratageSaveClick', 'data': Dispdetails };
                var s = function (msg) {
                    if (msg) {
                        alert(msg);
                        $(".LeakQtyclass").attr("disabled", true);
                        $(".ShortQtyclass").attr("disabled", true);
                        $(".FreeMilkQtyclass").attr("disabled", true);
                        document.getElementById('BtnSave').value = "Edit";
                        if (msg == "Session Expired") {
                            $('#divback').css('display', 'none');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divLogOut').css('display', 'none');
                            $('#divWelcome').css('display', 'none');
                            $('#divFillScreen').removeTemplate();
                            $('#divFillScreen').setTemplateURL('Login92.htm');
                            $('#divFillScreen').processTemplate();
                        }
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                CallHandlerUsingJson(Data, s, e);
            }
        }
        function BindDeliversclick(data) {
            $('#divFillScreen').processTemplate(data);
            $('#divInventory').setTemplateURL('DeliverInventory9.htm');
            $('#divInventory').processTemplate();
            BindDeliverInventory();
        }
        function GetCollectionStatus() {
            var data = { 'op': 'GetCollectionStatus', 'BranchID': bid };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    if (msg == "0") {
                        document.getElementById('txtPaidAmount').value = "0";
                        document.getElementById('txtPaidAmount').disabled = false;
                        $(".ReceivedQtyclass").attr("disabled", false);
                        $(".Returnqtyclass").attr("disabled", false);
                        $(".LeakQtyclass").attr("disabled", false);
                        document.getElementById('BtnSave').value = "Save";
                    }
                    else {
                        $(".ReceivedQtyclass").attr("disabled", true);
                        $(".Returnqtyclass").attr("disabled", true);
                        $(".LeakQtyclass").attr("disabled", true);
                        document.getElementById('BtnSave').value = "Edit";
                        document.getElementById('txtPaidAmount').value = msg;
                        document.getElementById('BtnSave').value = "Edit";
                        document.getElementById('txtPaidAmount').disabled = true;
                    }
                    //                    BindReporting(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function GetOfflineCollection() {
        }
        var ReturnInventory1 = [];
        var ReportColStatus = "";

        function divCollectionsclick() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT AmountStatus FROM tripdata1', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        if (obj.AmountStatus == "N") {
                            alert("Reporting already Submited");
                            ReportColStatus = "true";
                            return false;
                        }
                    }
                });
                tx.executeSql('SELECT InventoryStatus FROM InventoryReport1', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        if (obj.InventoryStatus == "N") {
                            alert("Reporting already Submited");
                            ReportColStatus = "true";
                            return false;
                        }
                    }
                });
            });
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = "";
                    }
                    else {
                        loginStatus = "OFFLINE";
                        if (loginStatus == "OFFLINE") {

                            var BranchName = document.getElementById('ddlBranchName').value;
                            if (BranchName == "Select Agent" || BranchName == "") {
                                alert("Please Select Agent Name");
                                return false;
                            }
                            if (ReportColStatus == "true") {
                                return false;
                            }
                            var PayMentStatus = "";
                            var TodayAmount = 0;
                            //                            BranchAmount2 (BrancID TEXT,Amount TEXT,PayType TEXT,TodayAmount TEXT,checkNo TEXT,BalanceAmount TEXT)
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                tx.executeSql('SELECT * FROM BranchAmount2 where BrancID="' + BranchName + '" group by  BrancID', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        TodayAmount = parseFloat(obj.TodayAmount);
                                        if (TodayAmount != "") {
                                            PayMentStatus = "true";
                                        }
                                    }
                                });
                            });
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                var Amount = 0;
                                var BranchID = document.getElementById('ddlBranchName').value;
                                tx.executeSql('SELECT * FROM IndentData1 WHERE (BrancID="' + BranchID + '")', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        var DQty = obj.DeliverQty;
                                        if (DQty == "") {
                                            DQty = "0";
                                        }
                                        var UnitCost = obj.UnitCost;
                                        if (UnitCost == "") {
                                            UnitCost = "0";
                                        }
                                        Amount += parseFloat(DQty) * parseFloat(UnitCost);
                                    }
                                    DairyStatus = "Collections";
                                    $('#tableOrder').css('display', 'block');
                                    $('#divback').css('display', 'block');
                                    $('#divHide').css('display', 'none');
                                    $('#divRouteOrder').css('display', 'none');
                                    $('#divFillScreen').css('display', 'block');
                                    $('#divFillScreen').setTemplateURL('Collections11.htm');
                                    $('#divFillScreen').processTemplate();
                                    document.getElementById('txtAmountPayable').innerHTML = 0;
                                    document.getElementById('txtTodayAmont').innerHTML = parseFloat(Amount).toFixed(2);
                                    document.getElementById('txtDeductions').innerHTML = 0;
                                    document.getElementById('txtTotalAmount').innerHTML = parseFloat(Amount).toFixed(2);
                                    document.getElementById('txtBalanceAmount').innerHTML = parseFloat(Amount).toFixed(2);

                                    var BranchIndent = [];
                                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                                    db.transaction(function (tx) {
                                        tx.executeSql('SELECT * FROM IndentData1 WHERE (BrancID="' + BranchName + '") ', [], function (tx, results) {
                                            var len = results.rows.length;
                                            for (var i = 0; i < len; i++) {
                                                var obj = results.rows.item(i);
                                                var DelQty = obj.DeliverQty;
                                                var Deqty = 0;
                                                var Dqty = 0;
                                                if (DelQty == "") {
                                                    //                                                    Dqty = obj.UnitQty;
                                                    Deqty = 0;
                                                }
                                                else {
                                                    //                                                    Dqty = parseFloat(obj.DeliverQty);
                                                    Deqty = parseFloat(obj.DeliverQty);
                                                }
                                                var LeakQty = obj.LeakQty;
                                                if (LeakQty == "") {
                                                    LeakQty = "0";
                                                }
                                                else {
                                                    LeakQty = parseFloat(obj.LeakQty);
                                                }
                                                var UCost = parseFloat(obj.UnitCost);
                                                var total = parseFloat(Deqty * UCost).toFixed(2);
                                                var UnitQty = obj.UnitQty;
                                                if (UnitQty == "0" && DelQty == "0") {
                                                }
                                                else {
                                                    BranchIndent.push({ sno: i + 1, ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, Qty: obj.UnitQty, LeakQty: LeakQty, DQty: Deqty, orderunitRate: obj.UnitCost, Total: total });
                                                }
                                            }
                                            $('#divleakes').setTemplateURL('Leakages11.htm');
                                            $('#divleakes').processTemplate(BranchIndent);
                                            CollectionCal();
                                        });
                                    });
                                    var BranchInventory = [];
                                    var CollectionStatus = "";
                                    db.transaction(function (tx) {
                                        //                                    Inventory (InventorySno TEXT,InventoryName Text,Qty TEXT,ToadayQty Text, BrancID TEXT,Status TEXT,EditMode TEXT)');
                                        //                                    ReturnInventory1 (InventorySno TEXT,InventoryName Text,Qty TEXT,ToadayQty Text, BrancID TEXT,Status TEXT)');
                                        tx.executeSql('SELECT Inventory.Qty,Inventory.InventorySno,Inventory.InventoryName,ReturnInventory1.ToadayQty,ReturnInventory1.EditM FROM ReturnInventory1 INNER JOIN Inventory ON Inventory.InventorySno = ReturnInventory1.InventorySno and Inventory.BrancID = ReturnInventory1.BrancID  WHERE (ReturnInventory1.BrancID="' + BranchName + '") Group By  Inventory.InventoryName Order by Inventory.InventorySno', [], function (tx, results) {
                                            var len = results.rows.length;
                                            for (var i = 0; i < len; ++i) {
                                                var obj = results.rows.item(i);
                                                var ToadayQty = obj.ToadayQty;
                                                if (ToadayQty == "") {
                                                    ToadayQty = "0";
                                                }
                                                BranchInventory.push({ Sno: i + 1, InventoryName: obj.InventoryName, InventorySno: obj.InventorySno, Qty: obj.Qty, ToadayQty: ToadayQty, Edit: obj.EditM });
                                            }
                                            $('#divInventory').setTemplateURL('CollectionInventory9.htm');
                                            $('#divInventory').processTemplate(BranchInventory);
                                            //                                            ReturnInventory1 = BranchInventory;
                                            if (PayMentStatus == "true") {
                                                document.getElementById('txtPaidAmount').value = parseFloat(TodayAmount).toFixed(2);
                                                var TotalAmount = document.getElementById('txtTotalAmount').innerHTML;
                                                var BalanceAmount = TotalAmount - TodayAmount;
                                                document.getElementById('txtBalanceAmount').innerHTML = parseFloat(BalanceAmount).toFixed(2);
                                                document.getElementById('txtPaidAmount').disabled = true;
                                                $(".ReceivedQtyclass").attr("disabled", true);
                                                $(".Returnqtyclass").attr("disabled", true);
                                                $(".LeakQtyclass").attr("disabled", true);
                                                document.getElementById('BtnSave').value = "Edit";
                                            }
                                            colInventoryCal();
                                            btnsignatureclick();

                                        });
                                    });
                                });
                            });

                        }
                        else {
                            var BranchName = document.getElementById('ddlBranchName').value;
                            if (BranchName == "Select Agent" || BranchName == "") {
                                alert("Please Select Agent Name");
                                return false;
                            }
                            DairyStatus = "Collections";
                            $('#tableOrder').css('display', 'block');
                            $('#divback').css('display', 'block');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divFillScreen').setTemplateURL('Collections11.htm');
                            $('#divFillScreen').processTemplate();
                            //            FillBranch();
                            if (bid != "") {
                                BranchChane();
                                $('#divInventory').setTemplateURL('CollectionInventory9.htm');
                                $('#divInventory').processTemplate();
                            }
                            GetCollectionStatus();
                        }
                    }
                });
            });

        }
        function BindReturnLeakReport() {
            var data = { 'op': 'GetReturnLeakReport' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    ReturnLeakReport(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function ReturnLeakReport(msg) {
            $('#RouteRetunLeak').removeTemplate();
            $('#RouteRetunLeak').setTemplateURL('RouteReturnLeak12.htm');
            $('#RouteRetunLeak').processTemplate(msg);
        }
        function BindInvReporting() {
            var data = { 'op': 'GetInvReport' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindReporting(msg);
                    BindReturnLeakReport();
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function BindReporting(data) {
            $('#divFillScreen').setTemplateURL('ReportingInventory12.htm');
            $('#divFillScreen').processTemplate(data);
        }
        function bindReportAmount() {
            var data = { 'op': 'getReportAmount' };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    document.getElementById('txtAmount').innerHTML = msg;
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function divReportingclick() {
            ////            BindInvReporting();
            ////            bindReportAmount();
            $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divHide').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'none');
            $('#DivIndentType').css('display', 'none');
            $('#divOrders').css('display', 'none');
            $('#divIndentReporting').css('display', 'none');
            $('#divSync').css('display', 'none');
            $('#divDelivers').css('display', 'none');
            $('#divCollections').css('display', 'none');
            $('#divReports').css('display', 'none');
            $('#divDispatch').css('display', 'none');
            $('#divShortage').css('display', 'none');
            $('#divCollectionReport').css('display', 'none');
            $('#divReporting').css('display', 'none');
            $('#divInvReporting').css('display', 'block');
            $('#divAmountReporting').css('display', 'block');
            $('#divVerifyInventory').css('display', 'none');
            $('#tableEmployee').css('display', 'none');
            $('#divAgentRanking').css('display', 'none');
            $('#divOfflineIndent').css('display', 'none');
            $('#divDeliverReport').css('display', 'none');
            $('#divInventoryReport').css('display', 'none');
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM InventoryReport1', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == "0") {
                        document.getElementById("btnAmount").style.backgroundColor = "#FA7E75";
                        document.getElementById("btnAmount").disabled = true;
                        document.getElementById("btnInvReporting").style.backgroundColor = "#59FA87";
                        document.getElementById("btnInvReporting").disabled = false;
                    }
                    else {
                        document.getElementById("btnAmount").style.backgroundColor = "#59FA87";
                        document.getElementById("btnAmount").disabled = false;
                        document.getElementById("btnInvReporting").style.backgroundColor = "#FA7E75";
                        document.getElementById("btnInvReporting").disabled = true;
                    }
                });
            });
        }
        function divInvReportingclick() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = "";
                    }
                    else {
                        loginStatus = "OFFLINE";
                        var Aleak = 0;
                        var RLeak = 0;
                        var Total = 0;
                        var totLeaks = 0;
                        var Leaks = [];
                        var TripLeaks = [];
                        if (loginStatus == "OFFLINE") {
                            $('#divFillScreen').css('display', 'block');
                            $('#divInvReporting').css('display', 'none');
                            $('#divAmountReporting').css('display', 'none');
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                var TripInventory = [];
                                tx.executeSql('SELECT * FROM tripinvdata order by invid', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        TripInventory.push({ Sno: i + 1, InventoryName: obj.InvName, InventorySno: obj.invid, DispQty: obj.Qty, DelQty: obj.Qty, Qty: obj.Remaining });
                                    }
                                    $('#divFillScreen').setTemplateURL('ReportingInventory12.htm');
                                    $('#divFillScreen').processTemplate(TripInventory);
                                });
                            });
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {

                                tx.executeSql('SELECT leakages.FreeMilk,leakages.ShortQty,leakages.ProductID,leakages.LeakQty,productsdata.ProductName FROM leakages INNER JOIN productsdata ON leakages.ProductID = productsdata.sno Group by productsdata.ProductName order by productsdata.sno', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        // var ALeakQty = obj.ALeakQty;
                                        var ALeakQty = 0;
                                        //if (ALeakQty == "") {
                                        //  ALeakQty = 0;
                                        //}
                                        var LeakQty = obj.LeakQty;
                                        if (LeakQty == "") {
                                            LeakQty = 0;
                                        }
                                        //Aleak = parseFloat(ALeakQty);
                                        RLeak = parseFloat(LeakQty);
                                        totLeaks = parseFloat(Aleak) + parseFloat(RLeak);
                                        Total = totLeaks + parseFloat(obj.FreeMilk) + parseFloat(obj.ShortQty);
                                        Leaks.push({ ProductID: obj.ProductID, Total: Total, totLeaks: totLeaks });
                                    }
                                });
                            });
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (ts) {
                                ts.executeSql('SELECT * from tripsubdata1 order by Rank', [], function (ts, tsresults) {
                                    var Sublen = tsresults.rows.length;
                                    for (var i = 0; i < Sublen; i++) {
                                        var obj = tsresults.rows.item(i);
                                        for (var k = 0; k < Leaks.length; k++) {
                                            if (Leaks[k].ProductID == obj.ProductId) {
                                                var DQty = 0;
                                                DQty = parseFloat(obj.DeliverQty);
                                                var TotDel = parseFloat(DQty) + parseFloat(Leaks[k].Total);
                                                var Qty = 0;
                                                Qty = parseFloat(obj.Qty);
                                                var ReturnQty = 0;
                                                ReturnQty = parseFloat(Qty) - parseFloat(TotDel);
                                                var ReportLeak = Leaks[k].totLeaks;
                                                var ReportReturn = ReturnQty;
                                                if (ReportLeak == 0 && ReportReturn == 0) {
                                                }
                                                else {
                                                    TripLeaks.push({ Sno: i + 1, ProdName: obj.ProductName, ProdId: obj.ProductId, Returns: ReturnQty, Leaks: Leaks[k].totLeaks });
                                                }
                                            }
                                        }
                                    }
                                    $('#RouteRetunLeak').removeTemplate();
                                    $('#RouteRetunLeak').setTemplateURL('RouteReturnLeak12.htm');
                                    $('#RouteRetunLeak').processTemplate(TripLeaks);
                                });
                            });
                        }
                        else {
                            $('#divFillScreen').css('display', 'block');
                            $('#divInvReporting').css('display', 'none');
                            $('#divAmountReporting').css('display', 'none');
                            $('#divSync').css('display', 'block');
                            //            BindReturnLeakReport();
                            BindInvReporting();
                        }
                    }
                });
            });
        }
        function ChangeAmountColor() {
         db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
         db.transaction(function (tx) {
             tx.executeSql('SELECT * FROM InventoryReport1', [], function (tx, results) {
                 var len = results.rows.length;
                 if (len == "0") {
                     document.getElementById("btnAmount").style.backgroundColor = "Red";
                     document.getElementById("btnAmount").disabled = true;
                     document.getElementById("btnInvReporting").style.backgroundColor = "Green";
                     document.getElementById("btnInvReporting").disabled = false;
                 }
                 else {
                     document.getElementById("btnAmount").style.backgroundColor = "Green";
                     document.getElementById("btnAmount").disabled = false;
                     document.getElementById("btnInvReporting").style.backgroundColor = "Red";
                     document.getElementById("btnInvReporting").disabled = true;
                 }
             });
         });
        }
        function btnReportingInventoryclick() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = "";

                    }
                    else {
                        loginStatus = "OFFLINE";
                        if (loginStatus == "OFFLINE") {
                            var BtnSave = document.getElementById('BtnSave').value;
                            if (BtnSave == "Edit") {
                                if (!confirm("Do you want to Edit")) {
                                    return false;
                                }
                                $(".SubmittQtyClass").attr("disabled", false);
                                $(".ShortQtyclass").attr("disabled", false);
                                $(".FreeMilkQtyclass").attr("disabled", false);
                                document.getElementById('BtnSave').value = "Save";
                                return false;
                            }
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                var rowsRouteLeakdetails = $("#tableRouteLeakdetails tr:gt(0)");
                                var RouteLeakdetails = new Array();
                                $(rowsRouteLeakdetails).each(function (i, obj) {
                                    if ($(this).find('#txtsno').text() != "") {
                                        tx.executeSql('INSERT INTO Leakreport (product_sno,ReturnQty,LeakQty) VALUES ("' + $(this).find('#hdnProductSno').val() + '","' + $(this).find('#txtReturnsQty').val() + '","' + $(this).find('#txtLeaksQty').val() + '")');
                                    }
                                });
                            });
                            db.transaction(function (tx) {
                                var rows = $("#tableInventory tr:gt(0)");
                                var InvDatails = new Array();
                                $(rows).each(function (i, obj) {
                                    if ($(this).find('#txtSno').text() != "" || $(this).find('#txtSubmittQty').val() != "") {
                                        var InventoryStatus = "N";
                                        tx.executeSql('INSERT INTO InventoryReport1 (InvId,SubQty,InventoryStatus) VALUES ("' + $(this).find('#hdnInvSno').val() + '","' + $(this).find('#txtSubmittQty').val() + '","' + InventoryStatus + '")');
                                    }
                                });
//                                alert("Data Successfully saved");
                                $(".SubmittQtyClass").attr("disabled", true);
                                $(".ShortQtyclass").attr("disabled", true);
                                $(".FreeMilkQtyclass").attr("disabled", true);
                                document.getElementById('BtnSave').value = "Edit";
                                ChangeAmountColor();
                                $('#divMsgAlert').css('display', 'block');
                                document.getElementById('lblAlertMsg').innerHTML = "Data Successfully saved";
                                document.getElementById("imgAlert").src = "Images/Success.png";
                                document.getElementById("lblAlertMsg").style.color = '#59FA87';
                                //                                tripdata1 (Sno TEXT,Remarks TEXT, Denominations TEXT, CollectedAmount TEXT, SubmittedAmount TEXT ,InventoryStatus TEXT
                                //                                tx.executeSql('update  InventoryReport1 set InventoryStatus="' + InventoryStatus + '"');
                            });
                            //                         Leakreport (product_sno TEXT, ReturnQty TEXT,LeakQty TEXT)');
                            //                         InventoryReport1 (InvId TEXT, SubQty TEXT)');
                        }
                        else {
                            var BtnSave = document.getElementById('BtnSave').value;
                            if (BtnSave == "Edit") {
                                if (!confirm("Do you want to Edit")) {
                                    return false;
                                }
                                $(".SubmittQtyClass").attr("disabled", false);
                                document.getElementById('BtnSave').value = "Save";
                                return false;
                            }
                            if (!confirm("Do you want to Save")) {
                                return false;
                            }
                            var rows = $("#tableInventory tr:gt(0)");
                            var InvDatails = new Array();
                            $(rows).each(function (i, obj) {
                                if ($(this).find('#txtSno').text() != "" || $(this).find('#txtSubmittQty').val() != "") {
                                    InvDatails.push({ SNo: $(this).find('#hdnInvSno').val(), Qty: $(this).find('#txtSubmittQty').val() });
                                }
                            });
                            var rowsRouteLeakdetails = $("#tableRouteLeakdetails tr:gt(0)");
                            var RouteLeakdetails = new Array();
                            $(rowsRouteLeakdetails).each(function (i, obj) {
                                if ($(this).find('#txtsno').text() != "") {
                                    RouteLeakdetails.push({ ProductID: $(this).find('#hdnProductSno').val(), ReturnsQty: $(this).find('#txtReturnsQty').val(), LeaksQty: $(this).find('#txtLeaksQty').val() });
                                }
                            });
                            var data = { 'op': 'btnReportingInventoryclick', 'InvDatails': InvDatails, 'RouteLeakdetails': RouteLeakdetails };
                            var s = function (msg) {
                                if (msg) {
                                    alert(msg);
                                    if (msg == "Session Expired") {
                                        $('#divback').css('display', 'none');
                                        $('#divHide').css('display', 'none');
                                        $('#divRouteOrder').css('display', 'none');
                                        $('#divFillScreen').css('display', 'block');
                                        $('#divLogOut').css('display', 'none');
                                        $('#divWelcome').css('display', 'none');
                                        $('#divFillScreen').removeTemplate();
                                        $('#divFillScreen').setTemplateURL('Login92.htm');
                                        $('#divFillScreen').processTemplate();
                                    }
                                    $(".SubmittQtyClass").attr("disabled", true);
                                    document.getElementById('BtnSave').value = "Edit";
                                }
                                else {
                                }
                            };
                            var e = function (x, h, e) {
                            };
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                            CallHandlerUsingJson(data, s, e);
                        }
                    }
                });
            });

        }
        function divAmountReportingclick() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = "";
                    }
                    else {
                        loginStatus = "OFFLINE";
                        if (loginStatus == "OFFLINE") {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                var TotalAmount = 0;
                                tx.executeSql('SELECT * FROM BranchAmount2 ', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        var PayType = obj.PayType;
                                        var Amount = "";
                                        if (PayType == "Cash") {
                                            Amount = obj.TodayAmount;
                                        }
                                        else {
                                            Amount = "0";
                                        }
                                        TotalAmount += parseFloat(Amount);
                                        //                                    Amountdetails.push({ SNo: i + 1, BrancID: obj.BrancID, Amount: obj.Amount, PayType: obj.PayType, TodayAmount: obj.TodayAmount, checkNo: obj.checkNo, BalanceAmount: obj.BalanceAmount });
                                    }
                                    $('#divFillScreen').setTemplateURL('Reporting13.htm');
                                    $('#divFillScreen').processTemplate();
                                    document.getElementById('txtAmount').innerHTML = parseFloat(TotalAmount).toFixed(2);
                                    $('#tableOrder').css('display', 'none');
                                    $('#divback').css('display', 'block');
                                    $('#divHide').css('display', 'none');
                                    $('#divRouteOrder').css('display', 'none');
                                    $('#divFillScreen').css('display', 'block');
                                });
                            });
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                tx.executeSql('SELECT * FROM tripdata1', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        var Denominations = obj.Denominations;
                                        document.getElementById('txt_Total').innerHTML = obj.CollectedAmount;
                                        document.getElementById('txtSubmittedAmount').value = obj.CollectedAmount;
                                        $(".qtyclass").attr("disabled", true);
                                        document.getElementById('btn_reporting_show').value = "Edit";
                                        var strdenmn = Denominations.split("+");
                                        for (i = 0; i < strdenmn.length; i++) {
                                            var rowsdenominations = $("#tableReportingDetails tr:gt(0)");
                                            var DenominationString = "";
                                            $(rowsdenominations).each(function (i, obj) {
                                                var cash = strdenmn[i].split("x");
                                                if ($(this).closest("tr").find(".CashClass").text() == cash[0]) {
                                                    var Cash = cash[0];
                                                    if (Cash != "") {
                                                        if (cash[0] == "Vouchers") {
                                                            cash[0] = "1";
                                                        }
                                                        $(this).closest("tr").find(".qtyclass").val(cash[1]);
                                                        var amount = 0;
                                                        amount = parseFloat(cash[0]) * parseFloat(cash[1]);
                                                        $(this).closest("tr").find(".TotalClass").text(amount);
                                                    }
                                                }
                                            });
                                        }
                                    }
                                });
                            });
                        }
                        else {
                            bindReportAmount();
                            $('#tableOrder').css('display', 'none');
                            $('#divback').css('display', 'block');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divFillScreen').setTemplateURL('Reporting13.htm');
                            $('#divFillScreen').processTemplate();
                        }
                    }
                });
            });
        }
        function divCollectionReportsclick() {
            online = window.navigator.onLine;
            if (loginStatus == "OFFLINE") {
                $('#tableOrder').css('display', 'none');
                $('#divback').css('display', 'block');
                $('#divRouteOrder').css('display', 'none');
                $('#divHide').css('display', 'none');
                $('#divFillScreen').css('display', 'block');
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                var CollectionData = [];
                var SaleData = [];
                var saleamt = "";
                db.transaction(function (tx) {
                    tx.executeSql('SELECT branchdata1.BranchName,BranchAmount2.TodayAmount,BranchAmount2.BrancID,BranchAmount2.PayType,ROUND(SUM(IndentData1.UnitCost*IndentData1.DeliverQty),2) AS totalamount FROM branchdata1 INNER JOIN BranchAmount2 ON branchdata1.Sno = BranchAmount2.BrancID INNER JOIN IndentData1 ON branchdata1.Sno = IndentData1.BrancID Group by branchdata1.BranchName', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; i++) {
                            var obj = results.rows.item(i);
                            var PayType = obj.PayType;
                            var Amount = "";
                            if (PayType == "Cash") {
                                Amount = obj.TodayAmount;
                            }
                            else {
                                Amount = "0";
                            }
                            CollectionData.push({ Sno: i + 1, BranchName: obj.BranchName, BranchSno: obj.BrancID, SaleAmount: obj.totalamount, Amount: Amount });
                        }
                        BindColletionReport(CollectionData);
                    });
                });
            }
            else {
                $('#tableOrder').css('display', 'none');
                $('#divback').css('display', 'block');
                $('#divRouteOrder').css('display', 'none');
                $('#divHide').css('display', 'none');
                $('#divFillScreen').css('display', 'block');
                var data = { 'op': 'CollectionReports' };
                var s = function (msg) {
                    if (msg) {
                        BindColletionReport(msg);
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
        }
        function divInventoryReportclick() {
            $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divHide').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            var Dinventory = [];
            var Cinventory = [];
            var CDinventoryCrates = [];
            var CDinventoryCans = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM Inventory group by InventoryName,BrancID order by InventorySno', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var Qty = obj.Qty;
                        var ToadayQty = obj.ToadayQty;
                        var OppQty = Qty - ToadayQty;
                        Dinventory.push({ InventorySno: obj.InventorySno, InventoryName: obj.InventoryName, OppQty: OppQty,Qty:Qty, ToadayQty: ToadayQty, BrancID: obj.BrancID, Status: obj.Status });
                    }
                });
            });
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                //            SELECT Inventory.Qty,Inventory.InventorySno,Inventory.InventoryName,ReturnInventory1.ToadayQty,ReturnInventory1.EditM FROM ReturnInventory1 INNER JOIN Inventory ON Inventory.BrancID = ReturnInventory1.BrancID
                tx.executeSql('SELECT ReturnInventory1.InventorySno,ReturnInventory1.InventoryName,ReturnInventory1.Qty,ReturnInventory1.ToadayQty,ReturnInventory1.BrancID,ReturnInventory1.Status,branchdata1.BranchName FROM ReturnInventory1 INNER JOIN Inventory ON Inventory.BrancID = ReturnInventory1.BrancID INNER JOIN branchdata1 ON branchdata1.Sno = ReturnInventory1.BrancID Group by ReturnInventory1.BrancID,ReturnInventory1.InventoryName order by ReturnInventory1.InventorySno', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var Qty = obj.Qty;
                        var ToadayQty = obj.ToadayQty;
                        Cinventory.push({ InventorySno: obj.InventorySno, InventoryName: obj.InventoryName, ToadayQty: ToadayQty, BrancID: obj.BrancID, Status: obj.Status, BranchName: obj.BranchName });
                    }
                    for (var k = 0; k < Dinventory.length; k++) {
                        for (var j = 0; j < Cinventory.length; j++) {
                            if (Dinventory[k].BrancID == Cinventory[j].BrancID) {
                                if (Dinventory[k].InventorySno == Cinventory[j].InventorySno) {
                                    var opQty = Dinventory[k].OppQty;
                                    var DQty = Dinventory[k].Qty;
                                    var Qty = Cinventory[j].ToadayQty;
                                    if (Qty == "") {
                                        Qty = "0";
                                    }
                                    var CloBal = parseFloat(DQty) - parseFloat(Qty);
                                    if (Cinventory[j].InventoryName == "CRATES") {
                                        CDinventoryCrates.push({ BranchName: Cinventory[j].BranchName, Opp_bal: Dinventory[k].OppQty, IssuedCrates: Dinventory[k].ToadayQty, ReceivedCrates: Cinventory[j].ToadayQty, CloBal: CloBal });
                                    }
                                    else {
                                        CDinventoryCans.push({ BranchName: Cinventory[j].BranchName, Opp_bal: Dinventory[k].OppQty, IssuedCrates: Dinventory[k].ToadayQty, ReceivedCrates: Cinventory[j].ToadayQty, CloBal: CloBal });
                                    }
                                }
                            }
                        }
                    }
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('ColInventoryReport1.htm');
                    $('#divFillScreen').processTemplate(CDinventoryCrates);
                    $('#divColCans').removeTemplate();
                    $('#divColCans').setTemplateURL('ColInventoryCans2.htm');
                    $('#divColCans').processTemplate(CDinventoryCans);
                    CalColInventoryReport();
                });
            });
        }
        function CalColInventoryReport() {
            var Oppbal = 0;
            var IssuedCrates = 0;
            var ReceivedCrates = 0;
            var CloBal = 0;
            $('.OppbalClass').each(function (i, obj) {
                var Oppqty = $(this).text();
                if (Oppqty == null || Oppqty == "") {
                    Oppqty = "0";
                }
                Oppbal += parseInt(Oppqty);
            });
            $('.IssuedCratesClass').each(function (i, obj) {
                var Issuedqty = $(this).text();
                if (Issuedqty == null || Issuedqty == "") {
                    Issuedqty = "0";
                }
                IssuedCrates += parseInt(Issuedqty);
            });
            $('.ReceivedCratesClass').each(function (i, obj) {
                var Receivedqty = $(this).text();
                if (Receivedqty == null || Receivedqty == "") {
                    Receivedqty = "0";
                }
                ReceivedCrates += parseInt(Receivedqty);
            });
            $('.CloBalClass').each(function (i, obj) {
                var CloBalqty = $(this).text();
                if (CloBalqty == null || CloBalqty == "") {
                    CloBalqty = "0";
                }
                CloBal += parseInt(CloBalqty);
            });
            document.getElementById('txtOpp_bal').innerHTML = parseInt(Oppbal);
            document.getElementById('txtIssuedCrates').innerHTML = parseInt(IssuedCrates);
            document.getElementById('txtReceivedCrates').innerHTML = parseInt(ReceivedCrates);
            document.getElementById('txtCloBal').innerHTML = parseInt(CloBal);
            var Oppbalcan = 0;
            var IssuedCratescan = 0;
            var ReceivedCratescan = 0;
            var CloBalcan = 0;
            $('.OppbalClasscan').each(function (i, obj) {
                var Oppqty = $(this).text();
                if (Oppqty == null || Oppqty == "") {
                    Oppqty = "0";
                }
                Oppbalcan += parseInt(Oppqty);
            });
            $('.IssuedCratesClasscan').each(function (i, obj) {
                var Issuedqty = $(this).text();
                if (Issuedqty == null || Issuedqty == "") {
                    Issuedqty = "0";
                }
                IssuedCratescan += parseInt(Issuedqty);
            });
            $('.ReceivedCratesClasscan').each(function (i, obj) {
                var Receivedqty = $(this).text();
                if (Receivedqty == null || Receivedqty == "") {
                    Receivedqty = "0";
                }
                ReceivedCratescan += parseInt(Receivedqty);
            });
            $('.CloBalClasscan').each(function (i, obj) {
                var CloBalqty = $(this).text();
                if (CloBalqty == null || CloBalqty == "") {
                    CloBalqty = "0";
                }
                CloBalcan += parseInt(CloBalqty);
            });
            document.getElementById('txtOpp_balcan').innerHTML = parseInt(Oppbalcan);
            document.getElementById('txtIssuedCratescan').innerHTML = parseInt(IssuedCratescan);
            document.getElementById('txtReceivedCratescan').innerHTML = parseInt(ReceivedCratescan);
            document.getElementById('txtCloBalcan').innerHTML = parseInt(CloBalcan);
        }
        function divNextDayIndentReportclick() {
            $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divHide').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            var dtIndent = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT branchdata1.BranchName,OrderOffline1.ProductName,OrderOffline1.OrderQty  FROM branchdata1 INNER JOIN OrderOffline1 ON branchdata1.Sno = OrderOffline1.BrancID Group by branchdata1.BranchName,OrderOffline1.ProductName', [], function (tx, results) {
                    var len = results.rows.length;
                    var BranchName = "";
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);

                        var ProductName = obj.ProductName;
                        var OrderQty = obj.OrderQty;
                        if (OrderQty == null || OrderQty == "") {
                            OrderQty = "0";
                        }
                        if (obj.BranchName != BranchName) {
                            BranchName = obj.BranchName;
                            dtIndent.push({ BranchName: BranchName, ProductName: ProductName, UnitQty: OrderQty });
                        }
                        else {
                            var Agent = "";
                            dtIndent.push({ BranchName: Agent, ProductName: ProductName, UnitQty: OrderQty });
                        }
                    }
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('OrderReport1.htm');
                    $('#divFillScreen').processTemplate(dtIndent);
                });
            });
        }
        function divOrderReportsclick() {
        $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divHide').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            var dtIndent = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT branchdata1.BranchName,IndentData1.ProductName,IndentData1.UnitQty,IndentData1.DeliverQty  FROM branchdata1 INNER JOIN IndentData1 ON branchdata1.Sno = IndentData1.BrancID Group by branchdata1.BranchName,IndentData1.ProductName', [], function (tx, results) {
                    var len = results.rows.length;
                    var BranchName = "";
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var ProductName = obj.ProductName;
                        var UnitQty = obj.UnitQty;
                        var DeliverQty = obj.DeliverQty;
                        if (obj.BranchName != BranchName) {
                            BranchName = obj.BranchName;
                            dtIndent.push({ BranchName: BranchName, ProductName: ProductName, UnitQty: UnitQty, DeliverQty: DeliverQty });
                        }
                        else {
                            var Agent = "";
                            dtIndent.push({ BranchName: Agent, ProductName: ProductName, UnitQty: UnitQty, DeliverQty: DeliverQty });
                        }
                    }
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('OrderReport1.htm');
                    $('#divFillScreen').processTemplate(dtIndent);
                });
            });
        }
        function divStatusReportclick() {
            $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divHide').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            var dtStatus = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT branchdata1.BranchName,StatusTable.Indent,StatusTable.Delivery,StatusTable.Collection FROM branchdata1 INNER JOIN StatusTable ON branchdata1.Sno = StatusTable.BranchID Group by branchdata1.BranchName', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var Indent = obj.Indent;
                        if (Indent == null) {
                            Indent = "No";
                        }
                        var Delivery = obj.Delivery;
                        if (Delivery == null) {
                            Delivery = "No";
                        }
                        var Collection = obj.Collection;
                        if (Collection == null) {
                            Collection = "No";
                        }
                        dtStatus.push({ BranchName: obj.BranchName, Indent: Indent, Delivery: Delivery, Collection: Collection });
                    }
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('StatusReport.htm');
                    $('#divFillScreen').processTemplate(dtStatus);
                });
            });
        }
        function divDeliverReportclick() {
            $('#tableOrder').css('display', 'none');
            $('#divback').css('display', 'block');
            $('#divRouteOrder').css('display', 'none');
            $('#divHide').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            online = window.navigator.onLine;
            var Aleak = 0;
            var RLeak = 0;
            var freemilk = 0;
            var shortmilk = 0;
            var Total = 0;
            var totLeaks = 0;
            var DelReportLeaks = [];
            var DelTripLeaks = [];
            var indentqty = [];
            var Offerindentqty = [];
            $('#divFillScreen').css('display', 'block');
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                //tx.executeSql('SELECT leakages.FreeMilk,leakages.ShortQty,leakages.ProductID,leakages.LeakQty,productsdata.ProductName,IndentData1.LeakQty as ALeakQty FROM leakages INNER JOIN productsdata ON leakages.ProductID = productsdata.sno INNER JOIN IndentData1  ON IndentData1.ProductId=productsdata.sno Group by productsdata.ProductName order by productsdata.sno', [], function (tx, results) {
                tx.executeSql('SELECT * FROM leakages ', [], function (tx, results) {

                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
//                        var ALeakQty = obj.ALeakQty;
//                        if (ALeakQty == "") {
//                            ALeakQty = 0;
//                        }
                        var LeakQty = obj.LeakQty;
                        if (LeakQty == "") {
                            LeakQty = 0;
                        }
                        var freemilk = obj.FreeMilk;
                        if (freemilk == "") {
                            freemilk = 0;
                        }
                        var shortmilk = obj.ShortQty;
                        if (shortmilk == "") {
                            shortmilk = 0;
                        }
                       // Aleak = parseFloat(ALeakQty).toFixed(2);
                        RLeak = parseFloat(LeakQty).toFixed(2);
                        freemilk = parseFloat(freemilk).toFixed(2);
                        shortmilk = parseFloat(shortmilk).toFixed(2);
                        //totLeaks = parseFloat(Aleak) + parseFloat(RLeak);
                        totLeaks = parseFloat(RLeak);
                        Total = totLeaks + parseFloat(obj.FreeMilk) + parseFloat(obj.ShortQty);
                        DelReportLeaks.push({ ProductID: obj.ProductID, Total: Total, totLeaks: totLeaks, freemilk: freemilk, shortmilk: shortmilk });
                    }
                });
            });
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT sum(UnitQty) as UnitQty,ProductName,ProductId,sum(DeliverQty) as DeliverQty  FROM IndentData1 Group  by ProductId', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        indentqty.push({ Product: obj.ProductName, ProductSno: obj.ProductId, indentq: obj.UnitQty, deliverqty: obj.DeliverQty });
                    }
                });
            });
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT sum(Indent) as UnitQty,ProductName,ProductId,sum(Delivery) as DeliverQty  FROM OfferIndent Group  by ProductId', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        Offerindentqty.push({ Product: obj.ProductName, ProductSno: obj.ProductId, indentq: obj.UnitQty, deliverqty: obj.DeliverQty });
                    }
                });
            });
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (ts) {
                ts.executeSql('SELECT * from tripsubdata1 Group  by ProductName order by Rank', [], function (ts, tsresults) {
                    var Sublen = tsresults.rows.length;
                    for (var i = 0; i < Sublen; i++) {
                        var obj = tsresults.rows.item(i);
                        var pid = obj.ProductId;
                        var indqty = 0;
                        var retqty = 0;
                        var supplyqty = 0;
                        var Lqty = 0;
                        var Sqty = 0;
                        var Fqty = 0;
                        var Schemeqty = 0;
                        var dispqty = parseFloat(obj.Qty).toFixed(2);
                        var count = 0;
                        var Leakcount = 0;
                        for (var k = 0; k < DelReportLeaks.length; k++) {
                            if (DelReportLeaks[k].ProductID == obj.ProductId) {
                                count = 1;
                                Lqty = DelReportLeaks[k].totLeaks;
                                Sqty = DelReportLeaks[k].shortmilk;
                                Fqty = DelReportLeaks[k].freemilk;
                                //var count = Offerindentqty.length;
                                for (var s = 0; s < Offerindentqty.length; s++) {
                                    if (Offerindentqty[s].ProductSno == obj.ProductId) {
                                        Schemeqty = Offerindentqty[s].deliverqty;
                                    }

                                }
                                var totfree = parseFloat(Fqty) + parseFloat(Schemeqty);
                                var indent = 0;
                                for (var ind = 0; ind < indentqty.length; ind++) {
                                    if (indentqty[ind].ProductSno == obj.ProductId) {
                                        Leakcount = 1;
                                        var DQty = 0;
                                        DQty = parseFloat(indentqty[ind].deliverqty);
                                        var Total = DelReportLeaks[k].Total;
                                        var TotDel = parseFloat(DQty) + parseFloat(Total) + parseFloat(Schemeqty);
                                        var Qty = 0;
                                        Qty = parseFloat(obj.Qty).toFixed(2);
                                        var ReturnQty = 0;
                                        ReturnQty = parseFloat(Qty) - parseFloat(TotDel);
                                        ReturnQty = parseFloat(ReturnQty).toFixed(2);
                                        var ReportLeak = DelReportLeaks[k].totLeaks;
                                        var ReportReturn = ReturnQty;
                                        indent = indentqty[ind].indentq;
                                        //DelTripLeaks.push({ Variety: obj.ProductName, Qty: indent, DispQty: Qty, ReturnQty: ReturnQty, Shorts: DelReportLeaks[k].shortmilk, Free: DelReportLeaks[k].freemilk, LeakQty: DelReportLeaks[k].totLeaks, Sales: DQty });
                                        DelTripLeaks.push({ Variety: obj.ProductName, Qty: indent, DispQty: Qty, ReturnQty: ReturnQty, Shorts: DelReportLeaks[k].shortmilk, Free: totfree, LeakQty: DelReportLeaks[k].totLeaks, Sales: DQty });
                                    }
                                }
                            }
                        }
                        if (count == 0 || Leakcount == 0) {
                            var retn = 0;
                            var totLSF = 0;
                            var totfree = 0;
                            var schemeqty = 0;
                            for (var s = 0; s < Offerindentqty.length; s++) {
                                if (Offerindentqty[s].ProductSno == obj.ProductId) {
                                    schemeqty = Offerindentqty[s].deliverqty;
                                }

                            }
                            totfree = parseFloat(Fqty) + parseFloat(schemeqty);
                            //totLSF = parseFloat(Lqty) + parseFloat(Sqty) + parseFloat(Fqty);
                            totLSF = parseFloat(Lqty) + parseFloat(Sqty) + parseFloat(totfree);
                            retn = dispqty - totLSF;
                            DelTripLeaks.push({ Variety: obj.ProductName, Qty: indqty, DispQty: dispqty, ReturnQty: retn, Shorts: Sqty, Free: totfree, LeakQty: Lqty, Sales: supplyqty });

                        }
                    }
                    $('#divFillScreen').removeTemplate();
                    $('#divFillScreen').setTemplateURL('DeliveryReport8.htm');
                    $('#divFillScreen').processTemplate(DelTripLeaks);
                });
            });
        }
        function BindColletionReport(msg) {
            $('#divFillScreen').setTemplateURL('CollectionReport9.htm');
            $('#divFillScreen').processTemplate(msg);
            var TotalAmount = 0;
            var SaleAmount = 0;
            $('.CollectionAmountClass').each(function (i, obj) {
                TotalAmount += parseFloat($(this).text());
            });
            $('.CollectionSaleClass').each(function (i, obj) {
                SaleAmount += parseFloat($(this).text());
            });
            document.getElementById('txt_totqty').innerHTML =parseFloat(TotalAmount).toFixed(2);
            document.getElementById('txt_totsale').innerHTML = parseFloat(SaleAmount).toFixed(2);
        }
        function btnReportingSaveClick() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = "";
                    }
                    else {
                        loginStatus = "OFFLINE";
                        if (loginStatus == "OFFLINE") {
                            var Remarks = document.getElementById('txtRemarks').value;
                            var BtnSave = document.getElementById('btn_reporting_show').value;
                            if (BtnSave == "Edit") {
                                if (!confirm("Do you want Edit")) {
                                    return false;
                                }
                                $(".qtyclass").attr("disabled", false);
                                document.getElementById('btn_reporting_show').value = "Save";
                                return false;
                            }
                            if (Remarks == "") {
                                alert("Enter Remarks");
                                return false;
                            }
                            var rowsdenominations = $("#tableReportingDetails tr:gt(0)");
                            var DenominationString = "";
                            $(rowsdenominations).each(function (i, obj) {
                                if ($(this).closest("tr").find(".CashClass").text() == "") {
                                }
                                else {
                                    DenominationString += $(this).closest("tr").find(".CashClass").text() + 'x' + $(this).closest("tr").find(".qtyclass").val() + "+";
                                }
                            });
                            var ColAmount = document.getElementById('txtAmount').innerHTML;
                            var SubAmount = document.getElementById('txtSubmittedAmount').value;
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                tx.executeSql('Delete From tripdata1');
                                var InventoryStatus = "N";
                                var AmountStatus = "N";
                                tx.executeSql('INSERT INTO tripdata1 (Remarks,Denominations,CollectedAmount,SubmittedAmount,AmountStatus) VALUES ("' + Remarks + '","' + DenominationString + '","' + ColAmount + '","' + SubAmount + '","'+AmountStatus+'")');
//                                alert("Amount submitted successfully");
                                document.getElementById('txtRemarks').value = "";
                                var AmountStatus = "R";
                                $(".qtyclass").attr("disabled", true);
                                document.getElementById('btn_reporting_show').value = "Edit";
                                $('#divMsgAlert').css('display', 'block');
                                document.getElementById('lblAlertMsg').innerHTML = "Amount submitted successfully";
                                document.getElementById("imgAlert").src = "Images/Success.png";
                                document.getElementById("lblAlertMsg").style.color = '#59FA87';
//                                InventoryStatus TEXT,AmountStatus TEXT
//                                tx.executeSql('update  tripdata1 set AmountStatus="' + AmountStatus + '"');
                            });
                        }
                        else {
                            var Remarks = document.getElementById('txtRemarks').value;
                            if (Remarks == "") {
                                alert("Enter Remarks");
                                return false;
                            }
                            if (!confirm("Do you want Save")) {
                                return false;
                            }
                            var rowsdenominations = $("#tableReportingDetails tr:gt(0)");
                            var DenominationString = "";
                            $(rowsdenominations).each(function (i, obj) {
                                if ($(this).closest("tr").find(".CashClass").text() == "") {
                                }
                                else {
                                    DenominationString += $(this).closest("tr").find(".CashClass").text() + 'x' + $(this).closest("tr").find(".qtyclass").val() + "+";
                                }
                            });
                            var ColAmount = document.getElementById('txtAmount').innerHTML;
                            var SubAmount = document.getElementById('txtSubmittedAmount').value;
                            var data = { 'op': 'btnRemarksSaveClick', 'Remarks': Remarks, 'Denominations': DenominationString, 'ColAmount': ColAmount, 'SubAmount': SubAmount };
                            var s = function (msg) {
                                if (msg) {
                                    alert(msg);
                                    if (msg == "Session Expired") {
                                        $('#divback').css('display', 'none');
                                        $('#divHide').css('display', 'none');
                                        $('#divRouteOrder').css('display', 'none');
                                        $('#divFillScreen').css('display', 'block');
                                        $('#divLogOut').css('display', 'none');
                                        $('#divWelcome').css('display', 'none');
                                        $('#divFillScreen').removeTemplate();
                                        $('#divFillScreen').setTemplateURL('Login92.htm');
                                        $('#divFillScreen').processTemplate();
                                    }
                                    document.getElementById('txtRemarks').value = "";
                                }
                                else {
                                }
                            };
                            var e = function (x, h, e) {
                            };
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                            CallHandlerUsingJson(data, s, e);
                        }
                    }
                });
            });
        }
        function Denominationsclick() {
            document.getElementById('txtDTotalAmount').innerHTML = document.getElementById('txtTotalAmount').innerHTML;
            var BranchName = document.getElementById('ddlBranchName').value;
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM BranchAmount2 where BrancID="' + BranchName + '"', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len > 0) {
                        for (var i = 0; i < len; i++) {
                            var obj = results.rows.item(i);
                            var Denominations = obj.checkNo;
                            $(".AmountClass").attr("disabled", true);
                            var strdenmn = Denominations.split("+");
                            for (i = 0; i < strdenmn.length; i++) {
                                var rowsdenominations = $("#tableCollectionDetails tr:gt(0)");
                                var DenominationString = "";
                                $(rowsdenominations).each(function (i, obj) {
                                    var cash = strdenmn[i].split("x");
                                    if ($(this).closest("tr").find(".CashClass").text() == cash[0]) {
                                        var Cash = cash[0].trim();
                                        if (cash[1] == "") {
                                            cash[1] = "0";
                                        }
                                        $(this).closest("tr").find(".AmountClass").val(cash[1]);
                                        var amount = 0;
                                        amount = parseFloat(Cash) * parseFloat(cash[1]);
                                        $(this).closest("tr").find(".TotalClass").text(amount);
                                    }
                                });
                            }
                            var ReturnDenomonation = obj.ReturnDenomonation;
                            $(".RAmountClass").attr("disabled", true);
                            var strReturnDenomonation = ReturnDenomonation.split("+");
                            for (i = 0; i < strReturnDenomonation.length; i++) {
                                var rowsdenominations = $("#tableCollectionDetails tr:gt(0)");
                                var DenominationString = "";
                                $(rowsdenominations).each(function (i, obj) {
                                    var cash = strReturnDenomonation[i].split("x");
                                    if ($(this).closest("tr").find(".CashClass").text() == cash[0]) {
                                        var Cash = cash[0].trim();
                                        if (cash[1] == "") {
                                            cash[1] = "0";
                                        }
                                        $(this).closest("tr").find(".RAmountClass").val(cash[1]);
                                        var amount = 0;
                                        amount = parseFloat(Cash) * parseFloat(cash[1]);
                                        $(this).closest("tr").find(".ReturnAmountClass").text(amount);
                                    }
                                });
                            }
                        }
                        var TotalCash = 0;
                        var TotalAmount = 0;
                        $('.TotalClass').each(function (i, obj) {
                            var Amount = $(this).text();
                            if (Amount == "") {
                                Amount = 0.0;
                            }
                            TotalCash += parseFloat(Amount);
                        });
                        $('.ReturnAmountClass').each(function (i, obj) {
                            var Amount = $(this).text();
                            if (Amount == "") {
                                Amount = 0.0;
                            }
                            TotalAmount += parseFloat(Amount);
                        });
                        document.getElementById('txtreturnAmount').innerHTML = parseFloat(TotalAmount).toFixed(2);
                        document.getElementById('txtAmont').innerHTML = parseFloat(TotalCash).toFixed(2);
                        var Total = parseFloat(TotalCash) - parseFloat(TotalAmount);
                        document.getElementById('txtCTotAmount').innerHTML = Total;
                        document.getElementById('btnOk').value = "Edit";
                    }
                });
            });
            $('#divMainCollections').css('display', 'block');
        }
        
        function btnbackclick() {
            if (Permissions == "Dispatcher") {
                $('#tableOrder').css('display', 'none');
                $('#divFillScreen').css('display', 'none');
                $('#divHide').css('display', 'block');
                $('#divback').css('display', 'none');
                $('#divRouteOrder').css('display', 'block');
                $('#divDispatch').css('display', 'block');
                $('#divReporting').css('display', 'block');
                $('#divInvReporting').css('display', 'none');
                $('#divAmountReporting').css('display', 'none');
                $('#divSync').css('display', 'none');
                $('#tableEmployee').css('display', 'block');
                //                $('#DivDispDate').css('display', 'block');
                $('#divVerifyInventory').css('display', 'block');
            }
            else {
                if (DairyStatus == "TotalIndent") {
                    $('#divtotalindent').css('display', 'block');
                    $('#divonlineindent').css('display', 'block');
                    $('#divFillScreen').css('display', 'none');
                    $('#divRouteOrder').css('display', 'block');
                    $('#divback').css('display', 'none');
                }
                else if (DairyStatus == "AgentIndent") {
                    $('#divtotalindent').css('display', 'block');
                    $('#divonlineindent').css('display', 'block');
                    $('#divFillScreen').css('display', 'none');
                    $('#divRouteOrder').css('display', 'block');
                    $('#divback').css('display', 'none');
                }
                else {
                    DairyStatus = "";
                    $('#tableOrder').css('display', 'block');
                    $('#divFillScreen').css('display', 'none');
                    $('#divHide').css('display', 'block');
                    $('#divOrders').css('display', 'none');
                    $('#divIndentReporting').css('display', 'none');
                    $('#divDelivers').css('display', 'block');
                    $('#divCollections').css('display', 'block');
                    $('#divReports').css('display', 'none');
                    $('#divDispatch').css('display', 'none');
                    $('#divShortage').css('display', 'block');
                    $('#divCollectionReport').css('display', 'none');
                    $('#divReporting').css('display', 'block');
                    $('#divReports').css('display', 'block');
                    $('#divstatus').css('display', 'none');
                    $('#divNextDayIndentReport').css('display', 'none');
                    $('#divInvReporting').css('display', 'none');
                    $('#divAmountReporting').css('display', 'none');
                    $('#divSync').css('display', 'block');
                    $('#divDeliverReport').css('display', 'none');
                    $('#divInventoryReport').css('display', 'none');
                    $('#divOrderReport').css('display', 'none');
                    $('#divAgentRanking').css('display', 'block');
                    $('#divOfflineIndent').css('display', 'block');
                    $('#divAgent').css('display', 'none');
                    if (count > 1) {
                        $('#divRouteOrder').css('display', 'block');
                    }
                    else {

                        $('#divRouteOrder').css('display', 'none');
                    }
                    $('#divback').css('display', 'none');
                    var ddlroute = "";
                    if (count > 1) {
                        ddlroute = document.getElementById('ddlRouteName').value;
                    }
                    if (StatusDropDown == "Order") {
                        $('#tableOrder').css('display', 'block');
                        $('#divFillScreen').css('display', 'none');
                        $('#divHide').css('display', 'block');
                        $('#divOrders').css('display', 'block');
                        $('#divIndentReporting').css('display', 'block');
                        $('#divDelivers').css('display', 'none');
                        $('#divCollections').css('display', 'none');
                        $('#divReports').css('display', 'none');
                        $('#divDispatch').css('display', 'none');
                        $('#divShortage').css('display', 'none');
                        $('#divCollectionReport').css('display', 'none');
                        $('#divReporting').css('display', 'none');
                        $('#divInvReporting').css('display', 'none');
                        $('#divAmountReporting').css('display', 'none');
                        $('#divSync').css('display', 'none');
                        $('#divDeliverReport').css('display', 'none');
                        $('#divInventoryReport').css('display', 'none');
                        GetBranchStatus(ddlroute);
                    }
                }
            }
            ChangeBackColorInventoryReport();
            ChangeBackColortripdata();
        }
        function btnordersRefreshClick() {
            if (!confirm("Do you want Refresh")) {
                return false;
            }
            document.getElementById('ddlBranchName').value = "Select Agent";
            document.getElementById('txt_totRate').innerHTML = "";
            document.getElementById('txt_totRate').value = "";
            document.getElementById('txt_total').innerHTML = "";
            document.getElementById('BtnSave').value = "Save";
            var rows = $("#tabledetails tr:gt(0)");
            $(rows).each(function (i, obj) {
                var nullValue = "0";
                $(this).remove();
            });
        }
        function divShortageclick() {
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        loginStatus = "";
                    }
                    else {
                        loginStatus = "OFFLINE";
                        if (loginStatus == "OFFLINE") {
                            $('#divback').css('display', 'block');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            var Products = [];
                            var LeakStatus = "";
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                tx.executeSql('SELECT * FROM leakages', [], function (tx, results) {
                                    var len = results.rows.length;
                                    for (var i = 0; i < len; i++) {
                                        var obj = results.rows.item(i);
                                        var LeakQty = obj.LeakQty;
                                        var ShortQty = obj.ShortQty;
                                        var FreeMilk = obj.FreeMilk;
                                        if (LeakQty != 0 || ShortQty != 0 || FreeMilk != 0) {
                                            LeakStatus = "Edit";
                                        }
                                        Products.push({ sno: i + 1, Productsno: obj.ProductID, ProductCode: obj.ProductName, LeakQty: LeakQty, ShortQty: ShortQty, FreeMilk: FreeMilk });
                                    }
                                    $('#divFillScreen').setTemplateURL('Shortages10.htm');
                                    $('#divFillScreen').processTemplate(Products);
                                    if (LeakStatus == "Edit") {
                                        $(".LeakQtyclass").attr("disabled", true);
                                        $(".ShortQtyclass").attr("disabled", true);
                                        $(".FreeMilkQtyclass").attr("disabled", true);
                                        document.getElementById('BtnSave').value = "Edit";
                                    }
                                    else {
                                        $(".LeakQtyclass").attr("disabled", false);
                                        $(".ShortQtyclass").attr("disabled", false);
                                        $(".FreeMilkQtyclass").attr("disabled", false);
                                        document.getElementById('BtnSave').value = "Save";
                                    }
                                });
                            });
                        }
                        else {
                            $('#divback').css('display', 'block');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            var data = { 'op': 'GetShortageProducts' };
                            var s = function (msg) {
                                if (msg) {
                                    if (msg == "Session Expired") {
                                        alert(msg);
                                        $('#divback').css('display', 'none');
                                        $('#divHide').css('display', 'none');
                                        $('#divRouteOrder').css('display', 'none');
                                        $('#divFillScreen').css('display', 'block');
                                        $('#divLogOut').css('display', 'none');
                                        $('#divWelcome').css('display', 'none');
                                        $('#divFillScreen').removeTemplate();
                                        $('#divFillScreen').setTemplateURL('Login92.htm');
                                        $('#divFillScreen').processTemplate();
                                    }
                                    $('#divFillScreen').setTemplateURL('Shortages10.htm');
                                    $('#divFillScreen').processTemplate(msg);
                                }
                                else {
                                }
                            };
                            var e = function (x, h, e) {
                            };
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                            callHandler(data, s, e);
                        }
                    }
                });
            });


        }
        function GetOrderStatus() {
            var IndentType = document.getElementById('ddlIndentType').value;
            var data = { 'op': 'getOrderStatus', 'Bid': bid, 'IndentType': IndentType };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Indent Completed") {
                        $(".Unitqtyclass").attr("disabled", true);
                        document.getElementById('BtnSave').value = "Edit";
                        return false;
                    }
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function btnorderssaveclick() {
            var BtnSave = document.getElementById('BtnSave').value;
            if (BtnSave == "Edit") {
                $(".Unitqtyclass").attr("disabled", false);
                $(".OfferUnitqtyclass").attr("disabled", false);

                document.getElementById('BtnSave').value = "Save";
                return false;
            }
            if (!confirm("Do you  want to Save")) {
                return false;
            }
            var BranchName = document.getElementById('ddlBranchName').value;
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            db.transaction(function (tx) {
                var totqty = document.getElementById('txt_totRate').innerHTML;
                var Indenttype = document.getElementById('ddlIndentType').value;
                //            var totrate = document.getElementById('txt_totRate').value;
                var totTotal = document.getElementById('txt_total').innerHTML;
                var IndentNo = $('#hdnIndentNo').val();
                var rows = $("#tabledetails tr:gt(0)");
                var Orderdetails = new Array();
                $(rows).each(function (i, obj) {
                    var txtsno = $(this).find('#txtsno').text();
                    var txtUnitQty = $(this).find('#txtUnitQty').val();
                    var txtPrvQty = $(this).find('#txtPrvQty').text();
                    var hdnProductSno = $(this).find('#hdnProductSno').val();
                    var ProductName = $(this).find('#txtproduct').text();
                    var Rate = $(this).find('#txtOrderRate').text();
                    if (txtsno == "" || txtUnitQty == "") {
                    }
                    else {
                        var SyncStatus = 0;
                        if (txtPrvQty == "0") {
                            SyncStatus = 0;
                            tx.executeSql('INSERT INTO OrderOffline1 (BrancID,IndentType, ProductId, ProductName, UnitQty,UnitCost,OrderQty,SyncStatus) VALUES ("' + BranchName + '","' + Indenttype + '","' + hdnProductSno + '","' + ProductName + '", "' + txtUnitQty + '","' + Rate + '","' + txtUnitQty + '","' + SyncStatus + '")');
                        }
                        else {
                            SyncStatus = 0;
                            tx.executeSql('UPDATE OrderOffline1 SET OrderQty = "' + txtUnitQty + '",SyncStatus="' + SyncStatus + '" where  ProductId = "' + hdnProductSno + '" and BrancID="' + BranchName + '" ');
                        }
                    }
                    var Indent = "Yes";
                    tx.executeSql('UPDATE StatusTable SET Indent = "' + Indent + '" where BranchID="' + BranchName + '" ');
                    $(".Unitqtyclass").attr("disabled", true);
                    document.getElementById('BtnSave').value = "Edit";
                    $('#divMsgAlert').css('display', 'block');
                    document.getElementById('lblAlertMsg').innerHTML = "Data Saved Successfully";
                    document.getElementById("imgAlert").src = "Images/Success.png";
                    document.getElementById("lblAlertMsg").style.color = '#59FA87';
                    //                    BindOfflineOrdersData();
                });
            });


            db.transaction(function (tx) {
                var totqty = document.getElementById('txt_offer_ordertotRate').innerHTML;
                var Indenttype = document.getElementById('ddlIndentType').value;
                var totTotal = document.getElementById('txt_offer_ordertotal').innerHTML;
                //var IndentNo = $('#hdnIndentNo').val();
                var IndentNo = "0";
                var rows = $("#tableOffline_Offer_Orderdetails tr:gt(0)");
                var Orderdetails = new Array();
                $(rows).each(function (i, obj) {
                    var txtsno = $(this).find('#txtsno').text();
                    var txtUnitQty = $(this).find('#txtUnitQty').val();
                    var txtPrvQty = $(this).find('#txtPrvQty').text();
                    var hdnProductSno = $(this).find('#hdnProductSno').val();
                    var ProductName = $(this).find('#txtproduct').text();
                    var Rate = $(this).find('#txtOrderRate').text();
                    if (txtsno == "" || txtUnitQty == "") {
                    }
                    else {
                        var SyncStatus = 0;
                        //if (txtPrvQty == "0") {
                          //  SyncStatus = 0;
                            //t.executeSql('CREATE TABLE IF NOT EXISTS OfferIndentOffline (BranchID TEXT,IndentType Text,Productid TEXT,ProductName TEXT,IndentQty TEXT,UnitPrice TEXT,OrderQty TEXT,SyncStatus TEXT)');
                            tx.executeSql('UPDATE OfferIndentOffline SET OrderQty = "' + txtUnitQty + '",SyncStatus="' + SyncStatus + '" where  Productid = "' + hdnProductSno + '" and BranchID="' + BranchName + '" ');

                           // tx.executeSql('INSERT INTO OfferIndentOffline (BranchID,IndentType, Productid, ProductName, IndentQty,UnitPrice,OrderQty,SyncStatus) VALUES ("' + BranchName + '","' + Indenttype + '","' + hdnProductSno + '","' + ProductName + '", "' + txtUnitQty + '","' + Rate + '","' + txtUnitQty + '","' + SyncStatus + '")');
                       // }
                        //else {
                            //SyncStatus = 0;
                            //tx.executeSql('UPDATE OfferIndentOffline SET OrderQty = "' + txtUnitQty + '",SyncStatus="' + SyncStatus + '" where  Productid = "' + hdnProductSno + '" and BranchID="' + BranchName + '" ');
                        //}
                    }
                    var Indent = "Yes";
                    tx.executeSql('UPDATE StatusTable SET Indent = "' + Indent + '" where BranchID="' + BranchName + '" ');
                    $(".Unitqtyclass").attr("disabled", true);
                    $(".OfferUnitqtyclass").attr("disabled", true);

                    document.getElementById('BtnSave').value = "Edit";
                    $('#divMsgAlert').css('display', 'block');
                    document.getElementById('lblAlertMsg').innerHTML = "Data Saved Successfully";
                    document.getElementById("imgAlert").src = "Images/Success.png";
                    document.getElementById("lblAlertMsg").style.color = '#59FA87';
                    //                    BindOfflineOrdersData();
                });
            });
        }
        function OrderRefresh() {
            if (Changebutton == "Edit") {
                //                $(".Unitqtyclass").attr("disabled", true);
            }
            if (Changebutton == "Save") {
                //                $(".Unitqtyclass").attr("disabled", false);
            }
        }
        function btnCollectionsRefreshClick() {
            if (!confirm("Do you want to Refresh")) {
                return false;
            }
            document.getElementById('ddlBranchName').value = "Select Agent";
            document.getElementById('txtPaidAmount').value = "";
            document.getElementById('txtAmountPayable').value = "";
        }
        var SaveType = "Save";
        var invcollsave = "Save";
        function btnCollectionssaveclick() {
            online = window.navigator.onLine;
            if (loginStatus == "OFFLINE") {
                var btnsave = document.getElementById('BtnSave').value;
                if (btnsave == "Edit") {
                    invcollsave = "Edit"
                    if (!confirm("Do you want to Edit")) {
                        return false;
                    }
                    $(".ReceivedQtyclass").attr("disabled", false);
                    $(".Returnqtyclass").attr("disabled", false);
                    $(".LeakQtyclass").attr("disabled", false);
                    document.getElementById('BtnSave').value = "Save";
                    SaveType = "Edit";
                    document.getElementById('txtPaidAmount').disabled = false;
                    return false;
                }
                else {
                    invcollsave = "Save";
                }
                var BranchName = document.getElementById('ddlBranchName').value;
                var ddlPayMentType = document.getElementById('ddlPaymntType').value;
                var txtchequeNo = "";
                if (ddlPayMentType == "Cheque") {
                    txtchequeNo = document.getElementById('txtchequeNo').value;
                }
                var BalanceAmount = document.getElementById('txtBalanceAmount').innerHTML;
                var txtTodayAmont = document.getElementById('txtTodayAmont').innerHTML;

                var PaidAmount = document.getElementById('txtPaidAmount').value;
                if (PaidAmount == "") {
                    alert("Enter Paid Amont");
                    return false;
                }
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('Delete From  BranchAmount2 where  BrancID="' + BranchName + '"');
                    var Collection = "Yes";
                    tx.executeSql('UPDATE StatusTable SET Collection = "' + Collection + '" where BranchID="' + BranchName + '" ');
                    var DenominationString = "";
                    var ReturnDenomination = "";
                    if (ddlPayMentType == "Cash") {
                        var rows = $("#tableCollectionDetails tr:gt(0)");
                        $(rows).each(function (i, obj) {
                            if ($(this).closest("tr").find(".CashClass").text() == "") {
                            }
                            else {
                                DenominationString += $(this).closest("tr").find(".CashClass").text() + 'x' + $(this).closest("tr").find(".AmountClass").val() + "+";
                                ReturnDenomination += $(this).closest("tr").find(".CashClass").text() + 'x' + $(this).closest("tr").find(".RAmountClass").val() + "+";
                            }
                        });
                    }
                    if (ddlPayMentType == "Cheque") {
                        DenominationString = document.getElementById('txtchequeNo').value;
                        ReturnDenomination = "0";
                    }
                    var Ddate = new Date();
                    var ColDate = Ddate.format("mm/dd/yyyy HH:MM:ss");
//                    var ColDate = month + "/" + day + "/" + year + " " + hours + ":" + Mins + ":" + Seconds + " " + mid;
                    //                                        sss// var ColDate = day + "" + month + "" + year + " " + hours + ":" + Mins;Denomination TEXT,ReturnDenomonation TEXT
                    tx.executeSql('INSERT INTO BranchAmount2 (BrancID,Amount,PayType,TodayAmount, checkNo,BalanceAmount,Cdate,ReturnDenomonation) VALUES ("' + BranchName + '","' + txtTodayAmont + '","' + ddlPayMentType + '","' + PaidAmount + '","' + DenominationString + '","' + BalanceAmount + '","' + ColDate + '","' + ReturnDenomination + '")');
                });
                ReturnInventory1 = [];
                var collinvstatus="0"
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT Inventory.Qty,Inventory.InventorySno,Inventory.InventoryName,ReturnInventory1.ToadayQty,ReturnInventory1.EditM FROM ReturnInventory1 INNER JOIN Inventory ON Inventory.BrancID = ReturnInventory1.BrancID and Inventory.InventorySno = ReturnInventory1.InventorySno  WHERE (ReturnInventory1.BrancID="' + BranchName + '") Group By  Inventory.InventoryName Order by ReturnInventory1.InventorySno', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            var ToadayQty = obj.ToadayQty;
                            if (ToadayQty == "") {
                                ToadayQty = "0";
                            }
                            ReturnInventory1.push({ Sno: i + 1, InventoryName: obj.InventoryName, InventorySno: obj.InventorySno, Qty: obj.Qty, ToadayQty: ToadayQty, Edit: obj.EditM });
                        }
                        var rowInventory = $("#tableInventory tr:gt(0)");
                        var Inventorydetails = new Array();
                        $(rowInventory).each(function (i, obj) {
                            if ($(this).find('#txtSno').text() == "" || $(this).find('#txtReceivedQty').val() == "") {
                            }
                            else {
                                var balanceQty = $(this).find('#txtbalanceQty').text();
                                var ReceivedQty = $(this).find('#txtReceivedQty').val();
                                var InvSno = 0;
                                InvSno = $(this).find('#hdnInvSno').val();
                                InvSno = parseInt(InvSno);
                                var InvName = $(this).find('#txtInvName').text();
                                var BranchID = 0;
                                BranchID = parseInt(BranchName);
                                var Status = "C";
                                var InvCdate = new Date();
                                var InvColDate = InvCdate.format("mm/dd/yyyy HH:MM:ss");
                                db.transaction(function (tx) {
                                    tx.executeSql('SELECT * FROM tripinvdata WHERE (invid="' + InvSno + '")', [], function (tx, results) {
                                        var len = results.rows.length;
                                        if (len == 0) {
                                            var Qty = 0;
                                            tx.executeSql('INSERT INTO tripinvdata (invid,Qty,Remaining, InvName) VALUES ("' + InvSno + '","' + Qty + '","' + ReceivedQty + '","' + InvName + '")');
                                        }
                                        else {
                                        }
                                    });
                                });
                                for (var i = 0; i < ReturnInventory1.length; i++) {
                                    if (ReturnInventory1[i].InventorySno == InvSno) {
                                        if (ReturnInventory1[i].Edit == "Edit") {
                                            var PIqty = 0;
                                            PIqty = parseInt(ReturnInventory1[i].ToadayQty);
                                            var Iqty = 0;
                                            Iqty = parseInt(ReceivedQty);
                                            var totDqty = 0;
                                            totDqty = parseInt(PIqty) - parseInt(Iqty);
                                            if (totDqty >= 1) {
                                                collinvstatus = "1";
                                                totDqty = Math.abs(totDqty);
                                                tx.executeSql('UPDATE tripinvdata SET Remaining=Remaining-(' + totDqty + ') where invid=' + InvSno + ' ');
                                            }
                                            else {
                                                totDqty = Math.abs(totDqty);
                                                if (totDqty > 0) {
                                                    collinvstatus = "1";
                                                }
                                                tx.executeSql('UPDATE tripinvdata SET Remaining=Remaining+(' + totDqty + ') where invid=' + InvSno + ' ');
                                            }
                                        }
                                        else {
                                            tx.executeSql('UPDATE tripinvdata SET Remaining=Remaining+("' + ReceivedQty + '") where invid=' + InvSno + ' ');
                                        }
                                    }
                                }
                                var EditMode = "Edit";
                                if (collinvstatus == "1") {
                                    tx.executeSql('UPDATE ReturnInventory1 SET Qty = "' + balanceQty + '",ToadayQty = "' + ReceivedQty + '",Status="' + Status + '",EditM="' + EditMode + '",CInvDate="' + InvColDate + '" WHERE InventorySno = ' + InvSno + ' and BrancID=' + BranchID + '');
                                }
                                else {
                                    if (invcollsave == "Edit") {
                                        tx.executeSql('UPDATE ReturnInventory1 SET Qty = "' + balanceQty + '",ToadayQty = "' + ReceivedQty + '",Status="' + Status + '",EditM="' + EditMode + '" WHERE InventorySno = ' + InvSno + ' and BrancID=' + BranchID + '');
                                    }
                                    else {
                                        tx.executeSql('UPDATE ReturnInventory1 SET Qty = "' + balanceQty + '",ToadayQty = "' + ReceivedQty + '",Status="' + Status + '",EditM="' + EditMode + '",CInvDate="' + InvColDate + '" WHERE InventorySno = ' + InvSno + ' and BrancID=' + BranchID + '');
                                    }
                                }
                                // tx.executeSql('UPDATE ReturnInventory1 SET Qty = "' + balanceQty + '",ToadayQty = "' + ReceivedQty + '",Status="' + Status + '",EditM="' + EditMode + '",CInvDate="' + InvColDate + '" WHERE InventorySno = ' + InvSno + ' and BrancID=' + BranchID + '');
                            }
                        });
                        //                        alert("Data Saved Successfully");
                        $(".ReceivedQtyclass").attr("disabled", true);
                        $(".Returnqtyclass").attr("disabled", true);
                        $(".LeakQtyclass").attr("disabled", true);
                        document.getElementById('txtPaidAmount').disabled = true;
                        document.getElementById('BtnSave').value = "Edit";
                        $('#divMsgAlert').css('display', 'block');
                        Btngetsignatureclick();
                        document.getElementById('lblAlertMsg').innerHTML = "Data Saved Successfully";
                        document.getElementById("imgAlert").src = "Images/Success.png";
                        document.getElementById("lblAlertMsg").style.color = '#59FA87';
                    });
                });
            }
            else {
                var btnsave = document.getElementById('BtnSave').value;
                if (btnsave == "Edit") {
                    if (!confirm("Do you want to Edit")) {
                        return false;
                    }
                    $(".ReceivedQtyclass").attr("disabled", false);
                    $(".Returnqtyclass").attr("disabled", false);
                    $(".LeakQtyclass").attr("disabled", false);
                    document.getElementById('BtnSave').value = "Save";
                    SaveType = "Edit";
                    document.getElementById('txtPaidAmount').disabled = false;
                    return false;
                }
                var PaidAmount = document.getElementById('txtPaidAmount').value;
                if (PaidAmount == "") {
                    alert("Enter Paid Amont");
                    $('#txtPaidAmount').focus();
                    return false;
                }
                if (!confirm("Do you want to Save")) {
                    return false;
                }
                var BranchName = document.getElementById('ddlBranchName').value;
                var ddlPayMentType = document.getElementById('ddlPaymntType').value;
                var IndentNo = HdnIndentNo;
                var BalanceAmount = document.getElementById('txtBalanceAmount').innerHTML;
                var rows = $("#tableCollectionDetails tr:gt(0)");
                var DenominationString = "";
                if (ddlPayMentType == "Cash") {
                    $(rows).each(function (i, obj) {
                        if ($(this).closest("tr").find(".CashClass").text() == "") {
                        }
                        else {
                            DenominationString += $(this).closest("tr").find(".CashClass").text() + 'x' + $(this).closest("tr").find(".qtyclass").val() + "+";
                        }
                    });
                }
                if (ddlPayMentType == "Cheque") {
                    DenominationString = document.getElementById('txtchequeNo').value;
                }
                //            var rowLeakage = $("#tableLeakagesdetails tr:gt(0)");
                var rows = $("#tableLeakagesdetails tr:gt(0)"); // skip the header row
                var Leakagedetails = new Array();
                $(rows).each(function (i, obj) {
                    if ($(this).find('#txtsno').text() == "" || $(this).find('#txtReturnqty').val() == "") {
                    }
                    else {
                        Leakagedetails.push({ SNo: $(this).find('#txtsno').text(), ProductSno: $(this).find('#hdnProductSno').val(), Product: $(this).find('#txtproduct').text(), Returnqty: $(this).find('#txtReturnqty').val(), Status: $(this).find('#ddlDelivered').val(), IndentNo: $(this).find('#hdnIndentNo').val(), hdnSno: $(this).find('#hdn_Sno').val(), HdnIndentSno: $(this).find('#HdnIndentSno').val(), orderunitRate: $(this).find('#hdnCost').val(), LeakQty: $(this).find('#txtLeakQty').val() });
                    }
                });
                var rowInventory = $("#tableInventory tr:gt(0)");
                var Inventorydetails = new Array();
                $(rowInventory).each(function (i, obj) {
                    if ($(this).find('#txtSno').text() == "" || $(this).find('#txtReceivedQty').val() == "") {
                    }
                    else {
                        Inventorydetails.push({ SNo: $(this).find('#txtSno').text(), InvSno: $(this).find('#hdnInvSno').val(), ReceivedQty: $(this).find('#txtReceivedQty').val(), BalanceQty: $(this).find('#txtbalanceQty').text() });
                    }
                });
                if (Inventorydetails.length == 0) {
                    alert("Please Fill Received Qty");
                    return false;
                }
                var data = { 'op': 'CollectionSaveClick', 'BranchID': BranchName, 'DenominationString': DenominationString, 'PaidAmount': PaidAmount, 'Inventorydetails': Inventorydetails, 'data': Leakagedetails, 'IndentNo': IndentNo, 'BalanceAmount': BalanceAmount, 'PaymentType': ddlPayMentType, 'SaveType': SaveType };
                var s = function (msg) {
                    if (msg) {
                        alert(msg);
                        document.getElementById('txtPaidAmount').disabled = true;
                        $(".ReceivedQtyclass").attr("disabled", true);
                        $(".Returnqtyclass").attr("disabled", true);
                        $(".LeakQtyclass").attr("disabled", true);
                        document.getElementById('BtnSave').value = "Edit";
                        if (msg == "Session Expired") {
                            $('#divback').css('display', 'none');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divLogOut').css('display', 'none');
                            $('#divWelcome').css('display', 'none');
                            $('#divFillScreen').removeTemplate();
                            $('#divFillScreen').setTemplateURL('Login92.htm');
                            $('#divFillScreen').processTemplate();
                        }
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                CallHandlerUsingJson(data, s, e);
            }
        }
        function BtnOKClick() {
            var BtnSave = document.getElementById('btnOk').value;
            if (BtnSave == "Edit") {
                if (!confirm("Do you want to Edit")) {
                    return false;
                }
                $(".AmountClass").attr("disabled", false);
                $(".RAmountClass").attr("disabled", false);
                document.getElementById('btnOk').value = "Ok";
                return false;
            }
            var Amount = document.getElementById('txtAmont').innerHTML;
            var ReturnAmount = document.getElementById('txtreturnAmount').innerHTML;
            var Total = parseFloat(Amount) - parseFloat(ReturnAmount);
            document.getElementById('txtPaidAmount').value = Total;
            var TotalAmount = document.getElementById('txtTotalAmount').innerHTML;
            var BalanceAmount = parseFloat(TotalAmount) - parseFloat(Total);
            document.getElementById('txtBalanceAmount').innerHTML = parseFloat(BalanceAmount).toFixed(2);
            $('#divMainCollections').css('display', 'none');
        }
        function CloseClick() {
            $('#divMainCollections').css('display', 'none');
            $('#divPopsig').css('display', 'none');
        }

        function PaidAmountChange(Paidamont) {
            if (Paidamont.value == "") {
                var TotalAmount = document.getElementById('txtTotalAmount').innerHTML;
                var BalanceAmount = parseFloat(TotalAmount) - parseFloat(0);
                document.getElementById('txtBalanceAmount').innerHTML = parseFloat(BalanceAmount).toFixed(2);
                return false;
            }
            var TotalAmount = document.getElementById('txtTotalAmount').innerHTML;
            if (TotalAmount != "") {
                var BalanceAmount = parseFloat(TotalAmount) - parseFloat(Paidamont.value);
            }
            else {
                var BalanceAmount = parseFloat(Paidamont.value);
            }
            document.getElementById('txtBalanceAmount').innerHTML = parseFloat(BalanceAmount).toFixed(2);
        }
        var DataTable;
        function addrowsOrders() {
            DataTable = [];
            var txtsno = 0;
            var txtProductName = "";
            var txtProductSno = "";
            var txtOrderQty = "";
            var txtOrderRate = "";
            var txtOrderTotal = "";
            var txtUnitqty = "";
            var txtUnits = "";
            var orderunitqty = "";
            var hndrate = "";
            var Qty = 0;
            var Rate = 0;
            var Total = 0;
            var txtPrvQty = 0;
            var txtDescription;
            var rows = $("#tabledetails tr:gt(0)");
            var Product = document.getElementById('cmb_productname');
            var ProductSno = Product.options[Product.selectedIndex].value;
            var ProductName = Product.options[Product.selectedIndex].text;
            var txt_totqty = document.getElementById('txt_totqty').innerHTML;
            var txt_totRate = document.getElementById('txt_totRate').innerHTML;
            var txt_total = document.getElementById('txt_total').innerHTML;
            var Checkexist = false;
            $('.ProductClass').each(function (i, obj) {
                var PName = $(this).text();
                if (PName == ProductName) {
                    alert("Product Already Added");
                    Checkexist = true;
                }
            });
            if (Checkexist == true) {
                return;
            }
            var IndentNo = $('#hdnIndentNo').val();
            $(rows).each(function (i, obj) {
                if ($(this).find('#txtsno').text() != "") {
                    txtsno = $(this).find('#txtsno').text();
                    txtProductName = $(this).find('#txtproduct').text();
                    txtProductSno = $(this).find('#hdnProductSno').val();
                    txtPrvQty = $(this).find('#txtPrvQty').text();
                    orderunitqty = $(this).find('#txtUnitQty').val();
                    txtorderunitRate = $(this).find('#txtOrderRate').text();
                    hndrate = $(this).find('#hdnRate').val();
                    txtOrderTotal = $(this).find('#txtOrderTotal').text();
                    DataTable.push({ sno: txtsno, ProductCode: txtProductName, Productsno: txtProductSno, Rate: txtorderunitRate, Total: txtOrderTotal, orderunitqty: orderunitqty, PrevQty: txtPrvQty });
                }
            });
            var Sno = parseInt(txtsno) + 1;
            var Prevqty = 0;
            DataTable.push({ sno: Sno, ProductCode: ProductName, Productsno: ProductSno, Rate: UnitPrice, Total: Total, orderunitqty: 0, PrevQty: Prevqty });
            $('#divFillScreen').setTemplateURL('Orders12.htm');
            $('#divFillScreen').processTemplate(DataTable);

            $('#hdnIndentNo').val(IndentNo);
            document.getElementById('txt_totqty').innerHTML = txt_totqty;
            document.getElementById('txt_totRate').innerHTML = txt_totRate;
            document.getElementById('txt_total').innerHTML = txt_total;
            BindOffline_OffersOrdersData();
        }
        var DeliverTable;
        function AddRowDelivers() {
            DeliverTable = [];
            var txtsno = 0;
            var txtProductName = "";
            var txtProductSno = "";
            var txthdnSno = "";
            var txtqty = "";
            var txtIndentNo = 0;
            var txtReturnqty = "";
            var ddlDelivered = "";
            var txtLeakqty = 0;
            var txtCost = 0;
            var HdnIndentSno = 0;
            var txtRemainingQty = 0;
            var TripSubData = [];
            var OfferIndent = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM tripsubdata1  order by Rank', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var ProductId = obj.ProductId;
                        var Qty = obj.Qty;
                        var DeliverQty = obj.DeliverQty;
                        var ProductName = obj.ProductName;
                        TripSubData.push({ ProductId: ProductId, Qty: Qty, DeliverQty: DeliverQty, ProductName: ProductName });
                    }
                });
            });
            var rows = $("#tabledetails tr:gt(0)");
            var Product = document.getElementById('cmb_productname');
            var ProductSno = Product.options[Product.selectedIndex].value;
            var ProductName = Product.options[Product.selectedIndex].text;
            var Checkexist = false;
            $('.ProductClass').each(function (i, obj) {
                var PName = $(this).text();
                if (PName == ProductName) {
                    alert("Product Already Added");
                    Checkexist = true;
                }
            });
            if (Checkexist == true) {
                return;
            }
            $('#hdnIndent').val(txtIndentNo);
            $(rows).each(function (i, obj) {
                if ($(this).find('#txtsno').text() != "") {
                    txtsno = $(this).find('#txtsno').text();
                    txtProductName = $(this).find('#txtproduct').text();
                    txtProductSno = $(this).find('#hdnProductSno').val();
                    txtIndentNo = $(this).find('#hdnIndentNo').val();
                    txthdnSno = $(this).find('#hdn_Sno').val();
                    txtqty = $(this).find('#txtqty').text();
                    txtRemainingQty = $(this).find('#txtRemainingQty').text()
                    txtLeakqty = $(this).find('#txtLeakQty').val();
                    txtReturnqty = $(this).find('#txtReturnqty').val();
                    ddlDelivered = $(this).find('#ddlDelivered').val();
                    txtCost = $(this).find('#hdnCost').val();
                    DeliverTable.push({ sno: txtsno, ProductCode: txtProductName, Productsno: txtProductSno, LeakQty: txtLeakqty, IndentNo: txtIndentNo, HdnSno: txthdnSno, Qty: txtqty, DQty: txtReturnqty, Status: ddlDelivered, orderunitRate: txtCost, HdnIndentSno: HdnIndentSno, RQty: txtRemainingQty });
                }
            });

            var Sno = parseInt(txtsno) + 1;
            var hdnISno = 0;
            var Delivered = "";
            var Qty = 0;
            var hdnISno = 0;
            var Cost = 0;
            var DIndentNo = 0;
            var leak = 0;
            var DQty = 0;
            var RQty = 0;
            var UnitCost = 0;
            var BranchID = document.getElementById('ddlBranchName').value;

            





            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM branchproducts1 where product_sno=' + ProductSno + ' and branch_sno="' + BranchID + '" ', [], function (tx, results) {
                    var len = results.rows.length;
                    if (len == 0) {
                        db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                        db.transaction(function (tx) {
                            tx.executeSql('SELECT * FROM SalesOfficebranchproducts1 where product_sno=' + ProductSno + ' ', [], function (tx, results) {
                                var SOlen = results.rows.length;
                                if (SOlen == 0) {
                                    db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                                    db.transaction(function (tx) {
                                        tx.executeSql('SELECT * FROM productsdata where sno=' + ProductSno + ' ', [], function (tx, results) {
                                            var Prolen = results.rows.length;
                                            for (var i = 0; i < Prolen; i++) {
                                                var obj = results.rows.item(i);
                                                UnitCost = obj.UnitPrice;
                                            }
                                            for (var i = 0; i < TripSubData.length; i++) {
                                                if (TripSubData[i].ProductId == ProductSno) {
                                                    var DeliverQty = parseFloat(TripSubData[i].DeliverQty);
                                                    var Qty = parseFloat(TripSubData[i].Qty);
                                                    var RQty = 0;
                                                    var unitQty = 0;
                                                    RQty = parseFloat(Qty) - parseFloat(DeliverQty);
                                                    RQty = parseFloat(RQty).toFixed(2);
                                                    DeliverTable.push({ sno: Sno, ProductCode: ProductName, Productsno: ProductSno, LeakQty: leak, HdnSno: hdnISno, IndentNo: txtIndentNo, Qty: unitQty, DQty: DQty, Status: Delivered, orderunitRate: UnitCost, HdnIndentSno: HdnIndentSno, RQty: RQty });
                                                    $('#divFillScreen').setTemplateURL('Delivers15.htm');
                                                    $('#divFillScreen').processTemplate(DeliverTable);
                                                    if (loginStatus == "OFFLINE") {
                                                        OfflineInv();
                                                    }
                                                    else {
                                                        BindDeliverInventory();
                                                    }
                                                    $('#hdnIndent').val(txtIndentNo);
                                                }
                                            }
                                        });
                                    });
                                }
                                else {
                                    for (var i = 0; i < SOlen; i++) {
                                        var obj = results.rows.item(i);
                                        UnitCost = obj.unitprice;
                                    }
                                    for (var i = 0; i < TripSubData.length; i++) {
                                        if (TripSubData[i].ProductId == ProductSno) {
                                            var DeliverQty = parseFloat(TripSubData[i].DeliverQty);
                                            var Qty = parseFloat(TripSubData[i].Qty);
                                            var RQty = 0;
                                            var unitQty = 0;
                                            RQty = parseFloat(Qty) - parseFloat(DeliverQty);
                                            RQty = parseFloat(RQty).toFixed(2);
                                            DeliverTable.push({ sno: Sno, ProductCode: ProductName, Productsno: ProductSno, LeakQty: leak, HdnSno: hdnISno, IndentNo: txtIndentNo, Qty: unitQty, DQty: DQty, Status: Delivered, orderunitRate: UnitCost, HdnIndentSno: HdnIndentSno, RQty: RQty });
                                            $('#divFillScreen').setTemplateURL('Delivers15.htm');
                                            $('#divFillScreen').processTemplate(DeliverTable);
                                            if (loginStatus == "OFFLINE") {
                                                OfflineInv();
                                            }
                                            else {
                                                BindDeliverInventory();
                                            }
                                            $('#hdnIndent').val(txtIndentNo);
                                        }
                                    }
                                }
                            });
                        });
                        db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                        db.transaction(function (tx) {

                            tx.executeSql('SELECT * FROM OfferIndent WHERE (BranchID="' + BranchID + '") ', [], function (tx, results) {
                                var len = results.rows.length;
                                for (var a = 0; a < len; a++) {
                                    var obj = results.rows.item(a);
                                    var DelQty = obj.Delivery;
                                    var Dqty = 0;
                                    var Deqty = 0;
                                    if (DelQty == "") {
                                        DelQty = "0";
                                        Deqty = 0;
                                        Dqty = obj.Indent;
                                    }
                                    else {
                                        Dqty = parseFloat(obj.Delivery);
                                        Deqty = parseFloat(obj.Delivery);
                                    }

                                    var UnitQty = obj.Indent;

                                    for (var k = 0; k < TripSubData.length; k++) {
                                        if (TripSubData[k].ProductId == obj.ProductId) {
                                            var DeliverQty = parseFloat(TripSubData[k].DeliverQty);
                                            var Qty = parseFloat(TripSubData[k].Qty);
                                            var RQty = 0;
                                            RQty = parseFloat(Qty) - parseFloat(DeliverQty);
                                            RQty = parseFloat(RQty) - parseFloat(Dqty);
                                            RQty = parseFloat(RQty).toFixed(2);
                                            OfferIndent.push({ sno: a, ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, RQty: RQty, TRQty: obj.Indent, Qty: obj.Indent, DQty: Dqty });
                                        }
                                    }

                                }

                                $('#divOfferindent').setTemplateURL('OfferDelivery.htm');
                                $('#divOfferindent').processTemplate(OfferIndent);

                                var Returnqty = 0;
                                $('.OfferReturnqtyclass').each(function (i, obj) {
                                    if ($(this).val() == "") {
                                    }
                                    else {
                                        Returnqty += parseFloat($(this).val());
                                    }
                                });
                                document.getElementById('txt_OfferRetunQty').innerHTML = Returnqty;
                                //                                    DeliveryProductData = BranchIndent;
                            });
                        });
                    }
                    else {
                        for (var i = 0; i < len; i++) {
                            var obj = results.rows.item(i);
                            UnitCost = obj.unitprice;
                        }
                        for (var i = 0; i < TripSubData.length; i++) {
                            if (TripSubData[i].ProductId == ProductSno) {
                                var DeliverQty = parseFloat(TripSubData[i].DeliverQty);
                                var Qty = parseFloat(TripSubData[i].Qty);
                                var RQty = 0;
                                var unitQty = 0;
                                RQty = parseFloat(Qty) - parseFloat(DeliverQty);
                                RQty = parseFloat(RQty).toFixed(2);
                                DeliverTable.push({ sno: Sno, ProductCode: ProductName, Productsno: ProductSno, LeakQty: leak, HdnSno: hdnISno, IndentNo: txtIndentNo, Qty: unitQty, DQty: DQty, Status: Delivered, orderunitRate: UnitCost, HdnIndentSno: HdnIndentSno, RQty: RQty });
                                $('#divFillScreen').setTemplateURL('Delivers15.htm');
                                $('#divFillScreen').processTemplate(DeliverTable);
                                if (loginStatus == "OFFLINE") {
                                    OfflineInv();
                                }
                                else {
                                    BindDeliverInventory();
                                }
                                $('#hdnIndent').val(txtIndentNo);
                            }
                        }
                        db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                        db.transaction(function (tx) {

                            tx.executeSql('SELECT * FROM OfferIndent WHERE (BranchID="' + BranchID + '") ', [], function (tx, results) {
                                var len = results.rows.length;
                                for (var a = 0; a < len; a++) {
                                    var obj = results.rows.item(a);
                                    var DelQty = obj.Delivery;
                                    var Dqty = 0;
                                    var Deqty = 0;
                                    if (DelQty == "") {
                                        DelQty = "0";
                                        Deqty = 0;
                                        Dqty = obj.Indent;
                                    }
                                    else {
                                        Dqty = parseFloat(obj.Delivery);
                                        Deqty = parseFloat(obj.Delivery);
                                    }

                                    var UnitQty = obj.Indent;

                                    for (var k = 0; k < TripSubData.length; k++) {
                                        if (TripSubData[k].ProductId == obj.ProductId) {
                                            var DeliverQty = parseFloat(TripSubData[k].DeliverQty);
                                            var Qty = parseFloat(TripSubData[k].Qty);
                                            var RQty = 0;
                                            RQty = parseFloat(Qty) - parseFloat(DeliverQty);
                                            RQty = parseFloat(RQty) - parseFloat(Dqty);
                                            RQty = parseFloat(RQty).toFixed(2);
                                            OfferIndent.push({ sno: a, ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, RQty: RQty, TRQty: obj.Indent, Qty: obj.Indent, DQty: Dqty });
                                        }
                                    }

                                }

                                $('#divOfferindent').setTemplateURL('OfferDelivery.htm');
                                $('#divOfferindent').processTemplate(OfferIndent);

                                var Returnqty = 0;
                                $('.OfferReturnqtyclass').each(function (i, obj) {
                                    if ($(this).val() == "") {
                                    }
                                    else {
                                        Returnqty += parseFloat($(this).val());
                                    }
                                });
                                document.getElementById('txt_OfferRetunQty').innerHTML = Returnqty;
                                //                                    DeliveryProductData = BranchIndent;
                            });
                        });
                    }
                });
            });


            
            
        }
        function OfflineInv() {
            var BranchName = document.getElementById('ddlBranchName').value;
          var BranchInventory = [];
          db.transaction(function (tx) {
              tx.executeSql('SELECT * FROM Inventory WHERE (BrancID="' + BranchName + '") order by InventorySno', [], function (tx, results) {
                  var len = results.rows.length;
                  for (var i = 0; i < len; ++i) {
                      var obj = results.rows.item(i);
                      BranchInventory.push({ Sno: i + 1, InventoryName: obj.InventoryName, InventorySno: obj.InventorySno, Qty: obj.Qty, ToadayQty: obj.ToadayQty, Edit: obj.EditMode });
                  }
                  $('#divInventory').setTemplateURL('DeliverInventory9.htm');
                  $('#divInventory').processTemplate(BranchInventory);
                  DeliverOffCal();
              });
          });
        }
        function BindOffCategeoryname() {
            var categories = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT * FROM products_category', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        categories.push({ sno: obj.sno, categoryname: obj.categoryname });
                    }
                    //                    var Branchesaaa = Branches.unique();
                    BindCategeoryname(categories);
                });
            });
        }
        function AddNewRowDelivers() {
            online = window.navigator.onLine;
            if (loginStatus == "OFFLINE") {
                $('#divDeliveryProducts').css('display', 'block');
                BindOffCategeoryname();
            }
            else {
                FillCategeoryname();
                $('#divDeliveryProducts').css('display', 'block');
            }
        }
        function AddNewRowOrders() {
            //            FillProductName();
            online = window.navigator.onLine;
            if (loginStatus == "OFFLINE") {
                $('#divMainAddNewRow').css('display', 'block');
                BindOffCategeoryname();
            }
            else {
                FillCategeoryname();
                $('#divMainAddNewRow').css('display', 'block');
            }
//            FillCategeoryname();
//            $('#divMainAddNewRow').css('display', 'block');
        }
        function OrdersCloseClick() {
            $('#divMainAddNewRow').css('display', 'none');
        }
        function DeliversCloseClick() {
            $('#divDeliveryProducts').css('display', 'none');
        }
        function btnDeliversAddClick() {
            var CategoryName = document.getElementById('cmb_brchprdt_Catgry_name').value;
            if (CategoryName == "select" || CategoryName == "") {
                alert("Select Category Name");
                return false;
            }
            var SubCategoryName = document.getElementById('cmb__brnch_subcatgry').value;
            if (SubCategoryName == "Select" || SubCategoryName == "") {
                alert("Select Sub Category Name");
                return false;
            }
            var productname = document.getElementById('cmb_productname').value;
            if (productname == "Select" || productname == "") {
                alert("Select product Name");
                return false;
            }
            AddRowDelivers();
        }
        function btnOrdersAddClick() {
            var CategoryName = document.getElementById('cmb_brchprdt_Catgry_name').value;
            if (CategoryName == "select" || CategoryName == "") {
                alert("Select Category Name");
                return false;
            }
            var SubCategoryName = document.getElementById('cmb__brnch_subcatgry').value;
            if (SubCategoryName == "Select" || SubCategoryName == "") {
                alert("Select Sub Category Name");
                return false;
            }
            var productname = document.getElementById('cmb_productname').value;
            if (productname == "Select" || productname == "") {
                alert("Select product Name");
                return false;
            }
            addrowsOrders();

        }
        var UnitPrice;
        var Units;
        var UnitQty;
        var QtyUnit;
        var orderunitRate;
        var Description;
        var ProductSno = 0;
        function ProductNameChane(sno) {
            ProductSno = sno.value;
            var BranchID = document.getElementById('ddlBranchName').value;
            if (loginStatus == "OFFLINE") {
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM branchproducts1 where product_sno=' + ProductSno + ' and branch_sno="' + BranchID + '" ', [], function (tx, results) {
                        var len = results.rows.length;
                        if (len == 0) {
                            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                            db.transaction(function (tx) {
                                tx.executeSql('SELECT * FROM SalesOfficebranchproducts1 where product_sno=' + ProductSno + ' ', [], function (tx, results) {
                                    var SOlen = results.rows.length;
                                    if (SOlen == 0) {
                                        db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                                        db.transaction(function (tx) {
                                            tx.executeSql('SELECT * FROM productsdata where sno=' + ProductSno + ' ', [], function (tx, results) {
                                                var Prolen = results.rows.length;
                                                for (var i = 0; i < Prolen; i++) {
                                                    var obj = results.rows.item(i);
                                                    UnitPrice = obj.UnitPrice;
                                                }
                                            });
                                        });
                                    }
                                    else {
                                        for (var i = 0; i < SOlen; i++) {
                                            var obj = results.rows.item(i);
                                            UnitPrice = obj.unitprice;
                                        }
                                    }
                                });
                            });
                        }
                        else {
                            for (var i = 0; i < len; i++) {
                                var obj = results.rows.item(i);
                                UnitPrice = obj.unitprice;
                            }
                        }
                    });
                });
            }
            else {
                var data = { 'op': 'GetProductNamechange', 'ProductSno': ProductSno, 'BranchID': BranchID };
                var s = function (msg) {
                    if (msg) {
                        UnitPrice = msg[0].UnitPrice;
                        UnitQty = msg[0].Unitqty;
                        QtyUnit = msg[0].Unitqty;
                        Units = msg[0].Units;
                        orderunitRate = msg[0].orderunitRate;
                        Description = msg[0].Desciption;
                        if (DairyStatus == "Delivers") {
                            getTotalIndentQty();
                        }
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                callHandler(data, s, e);
            }
        }
        var RemainQty = 0;
        function getTotalIndentQty() {
            var data = { 'op': 'GetProductIndent', 'ProductSno': ProductSno };
            var s = function (msg) {
                if (msg) {
                    RemainQty = msg;
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function Refresh() {
            document.getElementById('ddlBranchName').value = "";
            document.getElementById('txtAmountPayable').value = "";
            document.getElementById('txtPaidAmount').value = "";
            document.getElementById('txt_Total').value = "";
            var rows = $("#tableCollectionDetails tr:gt(0)");
            $(rows).each(function (i, obj) {
                if ($(this).closest("tr").find(".CashClass").text() == "") {
                }
                else {
                    var nullValue = "";
                    $(this).closest("tr").find(".qtyclass").val(nullValue);
                    $(this).closest("tr").find(".TotalClass").text(nullValue);
                }
            });
        }
        function btndeliversRefreshClick() {
            if (!confirm("Do you want to Refresh")) {
                return false;
            }
            document.getElementById('ddlBranchName').value = "Select Agent";
            document.getElementById('txt_RetunQty').value = "";
            var rows = $("#tabledetails tr:gt(0)");
            $(rows).each(function (i, obj) {
                var nullValue = "0";
                $(this).remove();
            });
            var rowInventory = $("#tableInventory tr:gt(0)");
            $(rowInventory).each(function (i, obj) {
                var nullValue = "0";
                $(this).remove();
            });
        }
        function OrderLeftToRight(id) {
            var PrevQty = $(id).closest("tr").find('#txtPrvQty').text();
            var Rate = $(id).closest("tr").find('#txtOrderRate').text();
            $(id).closest("tr").find('#txtUnitQty').val(PrevQty);
            var Total = parseFloat(PrevQty) * parseFloat(Rate);
            Total = parseFloat(Total).toFixed(2);
            $(id).closest("tr").find('#txtOrderTotal').text(Total);
            var cnt = 0;
            $('.Unitqtyclass').each(function (i, obj) {
                var qtyclass = $(this).val();
                if (qtyclass == "" || qtyclass == "0") {
                }
                else {
                    cnt++;
                }
            });
            document.getElementById('txt_totqty').innerHTML = cnt;
            rate = 0;
            $('.rateclass').each(function (i, obj) {
                rate += parseInt($(this).text());
            });
            document.getElementById('txt_totRate').innerHTML = rate;
            total = 0;
            $('.totalclass').each(function (i, obj) {
                total += parseInt($(this).text());
            });
            document.getElementById('txt_total').innerHTML = total;
        }
        var savebtn = "Save";
        function btndeliverssaveclick() {
            loginStatus = "OFFLINE";
            var editstatus = "0";
            if (loginStatus == "OFFLINE") {
                var BtnSave = document.getElementById('BtnSave').value;
                if (BtnSave == "Edit") {
                    savebtn = "Edit";
                    if (!confirm("Do you want to Edit")) {
                        return false;
                    }
                    $(".Returnqtyclass").attr("disabled", false);
                    $(".LeakQtyclass").attr("disabled", false);
                    $(".GivenQtyclass").attr("disabled", false);
                    $(".OfferReturnqtyclass").attr("disabled", false);

                    document.getElementById('BtnSave').value = "Save";
                    return false;
                }
                else {
                    savebtn = "Save";
                }
                var BranchName = document.getElementById('ddlBranchName').value;
                var EditMode = "Edit";
                DeliveryProductData = [];
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM IndentData1 WHERE (BrancID="' + BranchName + '")', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; i++) {
                            var obj = results.rows.item(i);
                            var DelQty = obj.DeliverQty;
                            var DelStatus = obj.Status;

                            var Dqty = 0;
                            if (DelQty == "") {
                                DelQty = "0";
                                Dqty = obj.UnitQty;
                            }
                            else {
                                Dqty = parseFloat(obj.DeliverQty);
                            }
                            var LeakQty = obj.LeakQty;
                            if (LeakQty == "") {
                                LeakQty = "0";
                            }
                            else {
                                LeakQty = parseFloat(obj.LeakQty);
                            }
                            var UnitQty = obj.UnitQty;
                            if (UnitQty == "0" && DelQty == "0") {
                            }
                            else {
                                DeliveryProductData.push({ sno: i + 1, ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, RQty: obj.UnitQty, TRQty: obj.UnitQty, LeakQty: LeakQty, Qty: obj.UnitQty, DQty: Dqty, orderunitRate: obj.UnitCost, Edit: obj.EditMode });
                            }
                        }
                        var rows = $("#tabledetails tr:gt(0)"); // skip the header row
                        var Deliverdetails = new Array();
                        $(rows).each(function (i, obj) {
                            if ($(this).find('#txtsno').text() == "" || $(this).find('#txtReturnqty').val() == "") {
                            }
                            else {
                                var DeliverQty = $(this).find('#txtReturnqty').val();
                                var LeakQty = $(this).find('#txtLeakQty').val();
                                var txtqty = $(this).find('#txtqty').text();
                                var IndentNo = 0;
                                IndentNo = $(this).find('#hdnIndentNo').val();
                                IndentNo = parseInt(IndentNo);
                                var ProdID = 0;
                                ProdID = $(this).find('#hdnProductSno').val();
                                var UnitPrice = 0;
                                UnitPrice = $(this).find('#hdnCost').val();
                                ProdID = parseInt(ProdID);
                                var BranchID = 0;
                                BranchID = parseInt(BranchName);
                                for (var i = 0; i < DeliveryProductData.length; i++) {
                                    if (DeliveryProductData[i].Productsno == ProdID) {
                                        if (DeliveryProductData[i].Edit == "Edit") {
                                            var PDqty = 0;
                                            PDqty = parseFloat(DeliveryProductData[i].DQty);
                                            var Dqty = 0;
                                            Dqty = parseFloat(DeliverQty);
                                            var totDqty = 0;
                                            totDqty = parseFloat(PDqty) - parseFloat(Dqty);
                                            if (totDqty >= 1) {
                                                editstatus = "1";
                                                totDqty = Math.abs(totDqty);
                                                tx.executeSql('UPDATE tripsubdata1 SET DeliverQty=DeliverQty-(' + totDqty + ') where ProductId=' + ProdID + ' ');
                                            }
                                            else {
                                                totDqty = Math.abs(totDqty);
                                                if (totDqty > 0) {
                                                    editstatus = "1";
                                                }
                                                tx.executeSql('UPDATE tripsubdata1 SET DeliverQty=DeliverQty+(' + totDqty + ') where ProductId=' + ProdID + ' ');
                                            }
                                        }
                                        else {
                                            tx.executeSql('UPDATE tripsubdata1 SET DeliverQty=DeliverQty+("' + DeliverQty + '") where ProductId=' + ProdID + ' ');
                                        }
                                    }
                                }
                                var Ddate = new Date();
                                var DelDate = Ddate.format("mm/dd/yyyy HH:MM:ss");
                                if (txtqty == "0") {
                                    var Status = "Delivered";
                                    var SyncStatus = "E";

                                    tx.executeSql('UPDATE LoginDetails SET SyncStatus="' + SyncStatus + '" ');
                                    var ProductName = $(this).find('#txtproduct').text();
                                    var UnitQty = $(this).find('#txtqty').text();
                                    var IndentNo = $(this).find('#hdnIndentNo').val();
                                    tx.executeSql('UPDATE tripsubdata1 SET DeliverQty=DeliverQty+("' + DeliverQty + '") where ProductId=' + ProdID + ' ');
                                    tx.executeSql('INSERT INTO IndentData1 (BrancID, ProductId, UnitCost, DeliverQty,LeakQty,Status,EditMode,ProductName,UnitQty,IndentNo,Ddate) VALUES ("' + BranchName + '","' + ProdID + '","' + UnitPrice + '","' + DeliverQty + '", "' + LeakQty + '","' + Status + '","' + EditMode + '","' + ProductName + '","' + DeliverQty + '","' + IndentNo + '","' + DelDate + '" )');
                                }
                                else {
                                    var Status = "Delivered";
                                    var SyncStatus = "E";
                                    tx.executeSql('UPDATE LoginDetails SET SyncStatus="' + SyncStatus + '" ');
                                    if (editstatus == "1") {
                                        tx.executeSql('UPDATE IndentData1 SET DeliverQty = "' + DeliverQty + '",EditMode="' + EditMode + '",LeakQty = "' + LeakQty + '",Status="' + Status + '",Ddate="' + DelDate + '" where IndentNo = ' + IndentNo + ' and ProductId = ' + ProdID + ' and BrancID=' + BranchID + ' ');
                                    }
                                    else {
                                        if (savebtn == "Edit") {
                                            tx.executeSql('UPDATE IndentData1 SET DeliverQty = "' + DeliverQty + '",EditMode="' + EditMode + '",LeakQty = "' + LeakQty + '",Status="' + Status + '" where IndentNo = ' + IndentNo + ' and ProductId = ' + ProdID + ' and BrancID=' + BranchID + ' ');
                                        }
                                        else {
                                            tx.executeSql('UPDATE IndentData1 SET DeliverQty = "' + DeliverQty + '",EditMode="' + EditMode + '",LeakQty = "' + LeakQty + '",Status="' + Status + '",Ddate="' + DelDate + '" where IndentNo = ' + IndentNo + ' and ProductId = ' + ProdID + ' and BrancID=' + BranchID + ' ');
                                        }
                                    }
                                }
                                var Delivery = "Yes";
                                tx.executeSql('UPDATE StatusTable SET Delivery = "' + Delivery + '" where BranchID="' + BranchName + '" ');
                            }
                        });
                        OfferDelivery_SaveClick();
                    });
                });
                DeliveryInventoryData = [];
                var Inveditstatus = "0";
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM Inventory WHERE (BrancID="' + BranchName + '") order by InventorySno', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            DeliveryInventoryData.push({ Sno: i + 1, InventoryName: obj.InventoryName, InventorySno: obj.InventorySno, Qty: obj.Qty, ToadayQty: obj.ToadayQty, Edit: obj.EditMode });
                        }
                        var rowInventory = $("#tableInventory tr:gt(0)");
                        var Inventorydetails = new Array();
                        $(rowInventory).each(function (i, obj) {
                            if ($(this).find('#txtSno').text() == "" || $(this).find('#txtGivenQty').val() == "") {
                            }
                            else {
                                var balanceQty = $(this).find('#txtbalanceQty').text();
                                var GivenQty = $(this).find('#txtGivenQty').val();
                                var InvSno = 0;
                                InvSno = $(this).find('#hdnInvSno').val();
                                InvSno = parseInt(InvSno);
                                var InvName = $(this).find('#txtInvName').text();
                                var BranchID = 0;
                                BranchID = parseInt(BranchName);
                                var Status = "D";
                                var SyncStatus = "E";
                                var InvDdate = new Date();
                                var InvDelDate = InvDdate.format("mm/dd/yyyy HH:MM:ss");
                                if (DeliveryInventoryData.length > 0) {
                                    for (var i = 0; i < DeliveryInventoryData.length; i++) {
                                        if (DeliveryInventoryData[i].InventorySno == InvSno) {
                                            if (DeliveryInventoryData[i].Edit == "Edit") {
                                                var PDqty = 0;
                                                PDqty = parseInt(DeliveryInventoryData[i].ToadayQty);
                                                var Iqty = 0;
                                                Iqty = parseInt(GivenQty);
                                                var totDqty = 0;
                                                totDqty = parseInt(PDqty) - parseInt(Iqty);
                                                if (totDqty >= 1) {
                                                    Inveditstatus = "1";
                                                    totDqty = Math.abs(totDqty);
                                                    tx.executeSql('UPDATE tripinvdata SET Remaining=Remaining+(' + totDqty + ') where invid=' + InvSno + ' ');
                                                }
                                                else {
                                                    totDqty = Math.abs(totDqty);
                                                    if (totDqty > 0) {
                                                        Inveditstatus = "1";
                                                    }
                                                    tx.executeSql('UPDATE tripinvdata SET Remaining=Remaining-(' + totDqty + ') where invid=' + InvSno + ' ');
                                                }
                                            }
                                            else {
                                                tx.executeSql('UPDATE tripinvdata SET Remaining=Remaining-("' + GivenQty + '") where invid=' + InvSno + ' ');
                                            }
                                        }
                                    }

                                    tx.executeSql('UPDATE LoginDetails SET SyncStatus="' + SyncStatus + '" ');
                                    if (Inveditstatus == "1") {
                                        tx.executeSql('UPDATE Inventory SET Qty = "' + balanceQty + '",ToadayQty = "' + GivenQty + '",Status="' + Status + '",EditMode="' + EditMode + '",DInvDate="' + InvDelDate + '" WHERE InventorySno = ' + InvSno + ' and BrancID=' + BranchID + '');
                                        tx.executeSql('UPDATE Inventory SET DInvDate="' + InvDelDate + '"  WHERE BrancID=' + BranchID + '');
                                    }
                                    else {
                                        if (savebtn == "Edit") {
                                            tx.executeSql('UPDATE Inventory SET Qty = "' + balanceQty + '",ToadayQty = "' + GivenQty + '",Status="' + Status + '",EditMode="' + EditMode + '" WHERE InventorySno = ' + InvSno + ' and BrancID=' + BranchID + '');
                                        }
                                        else {
                                            tx.executeSql('UPDATE Inventory SET Qty = "' + balanceQty + '",ToadayQty = "' + GivenQty + '",Status="' + Status + '",EditMode="' + EditMode + '",DInvDate="' + InvDelDate + '" WHERE InventorySno = ' + InvSno + ' and BrancID=' + BranchID + '');
                                        }
                                    }
                                }
                                else {
                                    tx.executeSql('UPDATE tripinvdata SET Remaining=Remaining-("' + GivenQty + '") where invid=' + InvSno + ' ');
                                    tx.executeSql('UPDATE LoginDetails SET SyncStatus="' + SyncStatus + '" ');
                                    tx.executeSql('INSERT INTO Inventory (InventorySno,InventoryName,Qty,ToadayQty, BrancID,EditMode,DInvDate) VALUES ("' + InvSno + '","' + InvName + '","' + GivenQty + '","' + GivenQty + '","' + BranchID + '","' + EditMode + '","' + InvDelDate + '")');
                                    tx.executeSql('INSERT INTO ReturnInventory1 (InventorySno,InventoryName,Qty,ToadayQty, BrancID,EditM) VALUES ("' + InvSno + '","' + InvName + '","' + GivenQty + '","' + GivenQty + '","' + BranchID + '","' + EditMode + '")');
                                }
                            }
                        });
                        //                        alert("Data Saved Successfully");
                        //                        divDeliveryProducts
                        $(".Returnqtyclass").attr("disabled", true);
                        $(".GivenQtyclass").attr("disabled", true);
                        $(".LeakQtyclass").attr("disabled", true);
                        $(".OfferReturnqtyclass").attr("disabled", true);
                        document.getElementById('BtnSave').value = "Edit";
                        $('#divMsgAlert').css('display', 'block');
                        document.getElementById('lblAlertMsg').innerHTML = "Data Saved Successfully";
                        document.getElementById("imgAlert").src = "Images/Success.png";
                        document.getElementById("lblAlertMsg").style.color = '#59FA87';

                    });
                    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

                });
            }
            else {
                var BtnSave = document.getElementById('BtnSave').value;
                if (BtnSave == "Edit") {
                    $(".Returnqtyclass").attr("disabled", false);
                    $(".GivenQtyclass").attr("disabled", false);
                    document.getElementById('BtnSave').value = "Save";
                    return false;
                }
                if (!confirm("Do you want to Save")) {
                    return false;
                }
                var BranchName = document.getElementById('ddlBranchName').value;
                //            var TotQty = document.getElementById('txt_TotQty').innerHTML;
                var RetunQty = document.getElementById('txt_RetunQty').value;
                //            var ExtraQty = document.getElementById('txt_ExtraQty').innerHTML;
                //            var chkDeliver = document.getElementById('chkDelivered').checked;
                //            if(chkDeliver==
                var TotalCost = 0;
                $('.Returnqtyclass').each(function (i, obj) {
                    var qty = $(this).val();
                    var Rate = $(this).closest("tr").find(".HdnRateClass").val();
                    TotalCost += parseFloat(qty) * parseFloat(Rate);
                });
                OrderRate: $(this).find('#hdnCost').val()
                var rows = $("#tabledetails tr:gt(0)"); // skip the header row
                var Deliverdetails = new Array();
                $(rows).each(function (i, obj) {
                    if ($(this).find('#txtsno').text() == "" || $(this).find('#txtReturnqty').val() == "") {
                    }
                    else {
                        Deliverdetails.push({ SNo: $(this).find('#txtsno').text(), ProductSno: $(this).find('#hdnProductSno').val(), Product: $(this).find('#txtproduct').text(), Returnqty: $(this).find('#txtReturnqty').val(), Status: $(this).find('#ddlDelivered').val(), IndentNo: $(this).find('#hdnIndentNo').val(), hdnSno: $(this).find('#hdn_Sno').val(), HdnIndentSno: $(this).find('#HdnIndentSno').val(), orderunitRate: $(this).find('#hdnCost').val(), LeakQty: $(this).find('#txtLeakQty').val(), RemainQty: $(this).find('#txtLeakQty').text() });
                    }
                });
                var rowInventory = $("#tableInventory tr:gt(0)");
                var Inventorydetails = new Array();
                $(rowInventory).each(function (i, obj) {
                    if ($(this).find('#txtSno').text() == "" || $(this).find('#txtGivenQty').val() == "") {
                    }
                    else {
                        Inventorydetails.push({ SNo: $(this).find('#txtSno').text(), InvSno: $(this).find('#hdnInvSno').val(), GivenQty: $(this).find('#txtGivenQty').val(), BalanceQty: $(this).find('#txtbalanceQty').text() });
                    }
                });
                if (Inventorydetails.length == 0) {
                    alert("Please Fill Given Qty");
                    return false;
                }
                var Indent = $('#hdnIndent').val();
                var Data = { 'op': 'btnDeliversSaveClick', 'BranchID': BranchName, 'Inventorydetails': Inventorydetails, 'data': Deliverdetails, 'RetunQty': RetunQty, 'TotalCost': TotalCost, 'IndentNo': Indent };
                var s = function (msg) {
                    if (msg) {
                        alert(msg);
                        $(".Returnqtyclass").attr("disabled", true);
                        $(".GivenQtyclass").attr("disabled", true);
                        document.getElementById('BtnSave').value = "Edit";
                        if (msg == "Session Expired") {
                            $('#divback').css('display', 'none');
                            $('#divHide').css('display', 'none');
                            $('#divRouteOrder').css('display', 'none');
                            $('#divFillScreen').css('display', 'block');
                            $('#divLogOut').css('display', 'none');
                            $('#divWelcome').css('display', 'none');
                            $('#divFillScreen').removeTemplate();
                            $('#divFillScreen').setTemplateURL('Login92.htm');
                            $('#divFillScreen').processTemplate();
                        }
                    }
                    else {
                    }
                };
                var e = function (x, h, e) {
                };
                CallHandlerUsingJson(Data, s, e);
            }
        }
        function OfferDelivery_SaveClick() {
            var BranchName = document.getElementById('ddlBranchName').value;
            var EditMode = "Edit";
            OfferDeliveryProductData = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            db.transaction(function (tx) {

                tx.executeSql('SELECT * FROM OfferIndent WHERE (BranchID="' + BranchName + '")', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);
                        var DelQty = obj.Delivery;
                        //var DelStatus = obj.Status;

                        var Dqty = 0;
                        if (DelQty == "") {
                            DelQty = "0";
                            Dqty = "0";
                        }
                        else {
                            Dqty = parseFloat(obj.Delivery);
                        }

                        var UnitQty = obj.Indent;
//                        if (UnitQty == "0" && DelQty == "0") {
//                        }
//                        else {
                            //OfferDeliveryProductData.push({ sno: i + 1, ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, RQty: obj.Indent, TRQty: obj.Indent, Qty: obj.Indent, DQty: Dqty, orderunitRate: obj.UnitCost });
                            OfferDeliveryProductData.push({ sno: i + 1, ProductCode: obj.ProductName, Productsno: obj.ProductId, IndentNo: obj.IndentNo, HdnIndentSno: obj.IndentNo, HdnSno: obj.ProductId, RQty: obj.Indent, TRQty: obj.Indent, Qty: obj.Indent, DQty: Dqty });
                       // }
                    }
                    var rows = $("#tableOfferdetails tr:gt(0)"); // skip the header row
                    var Deliverdetails = new Array();
                    $(rows).each(function (i, obj) {
                        if ($(this).find('#txtsno').text() == "" || $(this).find('#txtReturnqty').val() == "") {
                        }
                        else {
                            var DeliverQty = $(this).find('#txtReturnqty').val();
                            // var LeakQty = $(this).find('#txtLeakQty').val();
                            var txtqty = $(this).find('#txtqty').text();
                            //var IndentNo = 0;
                            //IndentNo = $(this).find('#hdnIndentNo').val();
                            //IndentNo = parseInt(IndentNo);
                            var ProdID = 0;
                            ProdID = $(this).find('#hdnProductSno').val();
                            //var UnitPrice = 0;
                            //UnitPrice = $(this).find('#hdnCost').val();
                            ProdID = parseInt(ProdID);
                            var BranchID = 0;
                            BranchID = parseInt(BranchName);
                            for (var i = 0; i < OfferDeliveryProductData.length; i++) {
                                if (OfferDeliveryProductData[i].Productsno == ProdID) {
                                    var PDqty = 0;
                                    PDqty = parseFloat(OfferDeliveryProductData[i].DQty);
                                    var Dqty = 0;
                                    Dqty = parseFloat(DeliverQty);
                                    var totDqty = 0;
                                    totDqty = parseFloat(PDqty) - parseFloat(Dqty);
                                    if (totDqty >= 1) {
                                        totDqty = Math.abs(totDqty);
                                        tx.executeSql('UPDATE tripsubdata1 SET DeliverQty=DeliverQty-(' + totDqty + ') where ProductId=' + ProdID + ' ');
                                    }
                                    else {
                                        totDqty = Math.abs(totDqty);

                                        tx.executeSql('UPDATE tripsubdata1 SET DeliverQty=DeliverQty+(' + totDqty + ') where ProductId=' + ProdID + ' ');
                                    }
                                }
                            }
                            //var Ddate = new Date();
                            //var DelDate = Ddate.format("mm/dd/yyyy HH:MM:ss");
                            //                            if (txtqty == "0") {
                            //                                var ProductName = $(this).find('#txtproduct').text();
                            //                                var UnitQty = $(this).find('#txtqty').text();
                            //                                var IndentNo = $(this).find('#hdnIndentNo').val();
                            //                                // t.executeSql('CREATE TABLE IF NOT EXISTS OfferIndent (BranchID TEXT,IndentType Text,IndentNo TEXT,ProductId TEXT,ProductName Text,Indent TEXT,Delivery TEXT)');
                            //                                var indentqty = "0";
                            //                                tx.executeSql('UPDATE tripsubdata1 SET DeliverQty=DeliverQty+("' + DeliverQty + '") where ProductId=' + ProdID + ' ');
                            //                                tx.executeSql('INSERT INTO OfferIndent (BranchID, ProductId, ProductName, Indent,Delivery) VALUES ("' + BranchName + '","' + ProdID + '","' + ProductName + '","' + UnitPrice + '","' + DeliverQty + '", "' + LeakQty + '","' + Status + '","' + EditMode + '","' + DeliverQty + '","' + IndentNo + '","' + DelDate + '" )');
                            //                            }
                            //                            else {
                            tx.executeSql('UPDATE OfferIndent SET Delivery = "' + DeliverQty + '" where ProductId = ' + ProdID + ' and BranchID=' + BranchID + ' ');
                            //}
                        }
                    });
                });
            });
        }
        function btnAlertOKClick() {
            $('#divMsgAlert').css('display', 'none');
            document.getElementById('lblAlertMsg').innerHTML = "";
            document.getElementById("imgAlert").src = "";
        }
        function get_OrdersInfo() {
            var FromDate = document.getElementById('fdate').value;
            var ToDate = document.getElementById('tdate').value;
            if (FromDate == "") {
                alert("Select From Date");
                return false;
            }
            if (ToDate == "") {
                alert("Select To Date");
                return false;
            }

            //alert($("#fdate").val() + " " + $("#tdate").val());
            var data = { 'op': 'getOrders_f_t_dates', 'fdate': FromDate, 'tdate': ToDate, 'bid': bid };
            var s = function (msg) {
                if (msg) {
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    BindOrders_fd_td(msg);
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
            //  getOrders_f_t_dates

        }
        function numberOnlyExample() {
            if ((event.keyCode < 48) || (event.keyCode > 57))
                return false;
        }
        function BindOrders_fd_td(msg) {
            $('#ReportDataViewer').setTemplateURL('ReportDataViewer8.htm');
            $('#ReportDataViewer').processTemplate(msg);
        }
        function btnCollectionsRefreshClick() {
            Refresh();
        }
        function LogOutClick() {
            $('#divback').css('display', 'none');
            $('#divHide').css('display', 'none');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            $('#divLogOut').css('display', 'none');
            $('#divWelcome').css('display', 'none');
            $('#divFillScreen').removeTemplate();
            $('#divFillScreen').setTemplateURL('Login92.htm');
            $('#divFillScreen').processTemplate();
            OfflineTest();
            //            window.location.href = "LogOut.aspx";
        }
        function ddlPaymntTypeChange(PayMentType) {
            if (PayMentType == "Cash") {
                $('#lblChequeNo').css('display', 'none');
                $('#divChequeNo').css('display', 'none');
            }
            if (PayMentType == "Cheque") {
                $('#lblChequeNo').css('display', 'block');
                $('#divChequeNo').css('display', 'block');
            }
        }
        function divIndentReportingclick() {
            $('#tableOrder').css('display', 'block');
            $('#divback').css('display', 'block');
            $('#divHide').css('display', 'none');
            $('#divRouteOrder').css('display', 'none');
            $('#divFillScreen').css('display', 'block');
            $('#divFillScreen').setTemplateURL('IndentReport.htm');
            $('#divFillScreen').processTemplate();
        }
        function btnIndentReportSaveclick() {
            var MobNo = document.getElementById('txtMobNo').value;
            if (MobNo == "") {
                alert("Please Enter Mobile No");
                return false;
            }
            var data = { 'op': 'IndentReportSaveclick', 'MobNo': MobNo };
            var s = function (msg) {
                if (msg) {
                    alert(msg);
                    if (msg == "Session Expired") {
                        alert(msg);
                        $('#divback').css('display', 'none');
                        $('#divHide').css('display', 'none');
                        $('#divRouteOrder').css('display', 'none');
                        $('#divFillScreen').css('display', 'block');
                        $('#divLogOut').css('display', 'none');
                        $('#divWelcome').css('display', 'none');
                        $('#divFillScreen').removeTemplate();
                        $('#divFillScreen').setTemplateURL('Login92.htm');
                        $('#divFillScreen').processTemplate();
                    }
                    document.getElementById('txtMobNo').value = "";
                }
                else {
                }
            };
            var e = function (x, h, e) {
            };
            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
            callHandler(data, s, e);
        }
        function btnSaveAgentOrderClick() {
            var div = document.getElementById('divselected');
            var divs = div.getElementsByTagName('div');
            var divArray = [];
            var j = 1;
            for (var i = 0; i < divs.length; i += 1) {

                divArray.push({ BrancID: divs[i].id, BranchName: divs[i].innerHTML, Rank: j++ });
            }
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                for (var k = 0; k < divArray.length; k++) {
                    tx.executeSql('update branchdata1 set Rank="' + divArray[k].Rank + '" WHERE Sno="' + divArray[k].BrancID + '" ', [], function (tx, results) {
                    });
                }
                $('#divMsgAlert').css('display', 'block');
                document.getElementById('lblAlertMsg').innerHTML = "Order Successfully";
                document.getElementById("imgAlert").src = "Images/Success.png";
                document.getElementById("lblAlertMsg").style.color = '#59FA87';
                bindagentorder();
                BingOffBranch();
            });
        }
        function divSyncIndentclick() {
            var online = window.navigator.onLine;
            if (!online) {
                //                alert("Please Connect To Internet");
                $('#divMsgAlert').css('display', 'block');
                document.getElementById('lblAlertMsg').innerHTML = "Please Connect To Internet";
                document.getElementById("imgAlert").src = "Images/Alert.png";
                document.getElementById("lblAlertMsg").style.color = '#FA7E75';
            }
            else {
                if (!confirm("Do you want to Syncdata Online")) {
                    return false;
                }
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {
                    tx.executeSql('SELECT * FROM LoginDetails ', [], function (tx, results) {
                        var len = results.rows.length;
                        for (var i = 0; i < len; ++i) {
                            var obj = results.rows.item(i);
                            UserName = obj.UserName;
                            Permissions = obj.Permissions;
                            count = obj.count;
                            var UserData_sno = obj.count;
                            var UserSno = obj.UserSno;
                            var LevelType = obj.LevelType;
                            var AssignDate = obj.AssignDate;
                            var I_Date = obj.I_Date;
                            var RouteId = obj.RouteId;
                            var TripdataSno = obj.TripdataSno;
                            var TripID = obj.TripID;
                            var Salestype = obj.Salestype;
                            var BranchSno = obj.BranchSno;
                            var data = { 'op': 'GetOfflineLogin', 'UserName': UserName, 'UserData_sno': UserData_sno, 'UserSno': UserSno, 'LevelType': LevelType, 'AssignDate': AssignDate, 'I_Date': I_Date, 'count': count, 'RouteId': RouteId, 'TripdataSno': TripdataSno, 'TripID': TripID, 'Permissions': Permissions, 'Salestype': Salestype, 'BranchSno': BranchSno };
                            var s = function (msg) {
                                if (msg) {
                                    if (msg == "Success") {
                                        SyncOfflineIndent();
                                    }
                                    else {
                                        $('#divMsgAlert').css('display', 'block');
                                        document.getElementById('lblAlertMsg').innerHTML = msg;
                                        document.getElementById("imgAlert").src = "Images/Alert.png";
                                        document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                                    }
                                }
                                else {
                                }
                            };
                            var e = function (x, h, e) {
                            };
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                            callHandler(data, s, e);
                        }
                    });
                });
            }
        }
        function SyncOfflineIndent() {
            var OrderDatails = [];
            var OfferOrderDatails = [];
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                var SyncStatus = 0;
                tx.executeSql('SELECT * FROM OrderOffline1 where SyncStatus= "' + SyncStatus + '" ', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; ++i) {
                        var obj = results.rows.item(i);
                        var OrderQty = obj.OrderQty;
                        if (OrderQty == "" || OrderQty == null) {
                            OrderQty = "0";
                        }
                        if (OrderQty == "0") {
                        }
                        else {
                            OrderDatails.push({ Productsno: obj.ProductId, Unitsqty: obj.OrderQty, BranchID: obj.BrancID, IndentType: obj.IndentType, UnitCost: obj.UnitCost });
                            SyncStatus = 1;
                            tx.executeSql('UPDATE OrderOffline1 SET SyncStatus="' + SyncStatus + '" where  ProductId = "' + obj.ProductId + '" and BrancID="' + obj.BrancID + '" ');
                        }
                    }


                    db.transaction(function (tx) {
                        var OfferSyncStatus = 0;
                       // t.executeSql('CREATE TABLE IF NOT EXISTS OfferIndentOffline (BranchID TEXT,IndentType Text,Productid TEXT,ProductName TEXT,IndentQty TEXT,UnitPrice TEXT,OrderQty TEXT,SyncStatus TEXT)');

                        tx.executeSql('SELECT * FROM OfferIndentOffline where SyncStatus= "' + OfferSyncStatus + '" ', [], function (tx, results) {
                            var len = results.rows.length;
                            for (var i = 0; i < len; ++i) {
                                var obj = results.rows.item(i);
                                var OrderQty = obj.OrderQty;
                                if (OrderQty == "" || OrderQty == null) {
                                    OrderQty = "0";
                                }
                                if (OrderQty == "0") {
                                }
                                else {
                                    OfferOrderDatails.push({ Productsno: obj.Productid, Unitsqty: obj.OrderQty, BranchID: obj.BranchID, IndentType: obj.IndentType, UnitCost: obj.UnitCost });
                                    OfferSyncStatus = 1;
                                    tx.executeSql('UPDATE OfferIndentOffline SET SyncStatus="' + OfferSyncStatus + '" where  Productid = "' + obj.Productid + '" and BranchID="' + obj.BranchID + '" ');
                                }
                            }




                            if (OrderDatails.length > 0) {
                                var Data = { 'op': 'NextIndent_SyncData', 'NextIndentdetail': OrderDatails,'OfferNextIndentdetail':OfferOrderDatails, 'end': 'Y' };
                                //                                if (i == OrderDatails.length - 1) {
                                //                                    Data = { 'op': 'NextIndent_SyncData', 'order_detail': OrderDatails[i], 'end': 'Y' };
                                //                                }
                                var s = function (msg) {
                                    if (msg) {
                                        if (msg == 'Success') {
                                            $('#divMsgAlert').css('display', 'block');
                                            document.getElementById('lblAlertMsg').innerHTML = "Indent successfully saved";
                                            document.getElementById("imgAlert").src = "Images/Success.png";
                                            document.getElementById("lblAlertMsg").style.color = '#59FA87';
                                        }
                                        else {
                                            $('#divMsgAlert').css('display', 'block');
                                            document.getElementById('lblAlertMsg').innerHTML = "Indent Sync Failed";
                                            document.getElementById("imgAlert").src = "Images/Alert.png";
                                            document.getElementById("lblAlertMsg").style.color = '#FA7E75';
                                        }
                                    }
                                }
                                var e = function (x, h, e) {
                                };
                                CallHandlerUsingJson_POST(Data, s, e);
                            }
                            else {
                                alert("No indent were found");
                            }
                        });
                    });
                });
            });
        }
    </script>
      <script type="text/javascript">

          (function ($) {
              var topics = {};
              $.publish = function (topic, args) {
                  if (topics[topic]) {
                      var currentTopic = topics[topic],
	        args = args || {};

                      for (var i = 0, j = currentTopic.length; i < j; i++) {
                          currentTopic[i].call($, args);
                      }
                  }
              };
              $.subscribe = function (topic, callback) {
                  if (!topics[topic]) {
                      topics[topic] = [];
                  }
                  topics[topic].push(callback);
                  return {
                      "topic": topic,
                      "callback": callback
                  };
              };
              $.unsubscribe = function (handle) {
                  var topic = handle.topic;
                  if (topics[topic]) {
                      var currentTopic = topics[topic];

                      for (var i = 0, j = currentTopic.length; i < j; i++) {
                          if (currentTopic[i] === handle.callback) {
                              currentTopic.splice(i, 1);
                          }
                      }
                  }
              };
          })(jQuery);
    </script>
    <script type="text/javascript">
        var $sigdivnew = "";
        var pubsubprefixnew = "";
        var $toolsnew = "";
        $(document).ready(function () {

            // This is the part where jSignature is initialized.
            var $sigdiv = $("#signature").jSignature({ 'UndoButton': true })
            // All the code below is just code driving the demo. 
	, $tools = $('#tools')
	, $extraarea = $('#displayarea')
	, pubsubprefix = 'jSignature.demo.'
            pubsubprefixnew = pubsubprefix;
            $sigdivnew = $sigdiv;
            $toolsnew = $tools;


            //            $.subscribe(pubsubprefix + 'image/svg+xml', function (data) {
            //                try {
            //                    var i = new Image()
            //                    i.src = 'data:' + data[0] + ';base64,' + btoa(data[1])
            //                    //$(i).appendTo($extraarea)
            //                } catch (ex) {
            //                }


            //            });


//            $.subscribe(pubsubprefix + 'image/jsignature;base30', function (data) {
//                
//                // $('<span><b>This is a vector format not natively render-able by browsers. Format is a compressed "movement coordinates arrays" structure tuned for use server-side. The bonus of this format is its tiny storage footprint and ease of deriving rendering instructions in programmatic, iterative manner.</b></span>').appendTo($extraarea)
//            });
//            if (Modernizr.touch) {
//                $('#scrollgrabber').height($('#content').height())
//            }

        });
        var base30 = "";
        function Btngetsignatureclick() {
            //        var t = document.getElementById('signature').innerHTML;
            //        alert(t);
            //        $('#signature .row.selected img').each(function () {
            //            alert($(this).attr('src'))
            //        });
            //var data = $sigdiv.jSignature('getData', e.target.value)
            var data = $sigdivnew.jSignature('getData', "base30")
            $.publish(pubsubprefixnew + 'formatchanged')
            if (typeof data === 'string') {
                $('textarea', $toolsnew).val(data)
            } else if ($.isArray(data) && data.length === 2) {
                $('textarea', $toolsnew).val(data.join(','))
                var agentsno = document.getElementById('ddlBranchName').value;
                if (agentsno == "Select Agent" || agentsno == "") {
                    alert("Please Select Agent Name");
                    return false;
                }
                db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
                db.transaction(function (tx) {

                    tx.executeSql('update branchdata1 set Sign="' + data.join(',') + '" WHERE Sno="' + agentsno + '" ', [], function (tx, results) {
                    });




                });
                //document.getElementById('displayarea').innerHTML = data.join(',')
                $.publish(pubsubprefixnew + data[0], data);
            } else {
                try {
                    $('textarea', $toolsnew).val(JSON.stringify(data))
                } catch (ex) {
                    $('textarea', $toolsnew).val('Not sure how to stringify this, likely binary, format.')
                }
            }
            //document.getElementById('displayarea').innerHTML = $toolsnew;
            //.appendTo($toolsnew);
        }
        function Btnsetsignatureclick() {
            document.getElementById('signature').innerHTML = "";
            var $sigdiv = $("#signature").jSignature({ 'UndoButton': true })
            // All the code below is just code driving the demo. 
	, $tools = $('#tools')
	, $extraarea = $('#displayarea')
	, pubsubprefix = 'jSignature.demo.'
            pubsubprefixnew = pubsubprefix;
            $sigdivnew = $sigdiv;
            $toolsnew = $tools;


            $.subscribe(pubsubprefix + 'image/svg+xml', function (data) {
                try {
                    var i = new Image()
                    i.src = 'data:' + data[0] + ';base64,' + btoa(data[1])
                    //$(i).appendTo($extraarea)
                } catch (ex) {
                }


            });


//            $.subscribe(pubsubprefix + 'image/jsignature;base30', function (data) {
//              //  $('<span><b>This is a vector format not natively render-able by browsers. Format is a compressed "movement coordinates arrays" structure tuned for use server-side. The bonus of this format is its tiny storage footprint and ease of deriving rendering instructions in programmatic, iterative manner.</b></span>').appendTo($extraarea)
//            });
//            if (Modernizr.touch) {
//                $('#scrollgrabber').height($('#content').height())
//            }
        }
        function btnsignatureclick() {
            $('#div1').css('display', 'block');
            $('#btnset').css('display', 'block');
            
           // $('#divPopsig').css('display', 'block');
            $('#div1').removeTemplate();
            $('#div1').setTemplateURL('signature.htm');
            $('#div1').processTemplate();
            var $sigdiv = $("#signature").jSignature({ 'UndoButton': true })
            // All the code below is just code driving the demo. 
	, $tools = $('#tools')
	, $extraarea = $('#displayarea')
	, pubsubprefix = 'jSignature.demo.'
            pubsubprefixnew = pubsubprefix;
            $sigdivnew = $sigdiv;
            $toolsnew = $tools;


            $.subscribe(pubsubprefix + 'image/svg+xml', function (data) {
                try {
                    var i = new Image()
                    i.src = 'data:' + data[0] + ';base64,' + btoa(data[1])
                    //$(i).appendTo($extraarea)
                } catch (ex) {
                }


            });
            var BranchName = document.getElementById('ddlBranchName').value;
            if (BranchName == "Select Agent" || BranchName == "") {
                alert("Please Select Agent Name");
                return false;
            }
            db = openDatabase('vyshnavidb', '1.0', 'Operations db1', 2 * 1024 * 1024);
            db.transaction(function (tx) {
                tx.executeSql('SELECT Sign FROM branchdata1 where Sno="' + BranchName + '"', [], function (tx, results) {
                    var len = results.rows.length;
                    for (var i = 0; i < len; i++) {
                        var obj = results.rows.item(i);

                        var Dsign = obj.Sign;

                    }
                    $("#signature").jSignature("importData", "data:" + Dsign);

                });
            });

//            $.subscribe(pubsubprefix + 'image/jsignature;base30', function (data) {
//                //$('<span><b>This is a vector format not natively render-able by browsers. Format is a compressed "movement coordinates arrays" structure tuned for use server-side. The bonus of this format is its tiny storage footprint and ease of deriving rendering instructions in programmatic, iterative manner.</b></span>').appendTo($extraarea)
//            });
//            if (Modernizr.touch) {
//                $('#scrollgrabber').height($('#content').height())
//            }
        }
</script>
</head>
<body>
<div id="divMain" style="width: 100%;height: 100%;">
    <marquee><span id="txtInternet" style="font-size:20px;font-weight:bold;"></span> </marquee><br />
    Route Name:<span id="txtroutename" style="font-size: 16px; color: Red; font-weight: bold;">
        </span><br />
    <div id="divWelcome" style="float: left;">
        <br />
        Welcome: <span id="txtUser" style="font-size: 26px; color: Red; font-weight: bold;">
        </span>

        
    </div>
    <div id="divLogOut" style="width: 39%; float: right;">
        <input type="button" value="LogOut" id="btnLogOut" class="logout" onclick=" return LogOutClick();" />
    </div>
    <br />
    <br />
    <br />
    <div id="divback" style="display: none">
        <span id="lblBranch" style="font-size: 16px; color: Red; width: 100%; padding-left: 30%;
            font-weight: bold;"></span>
        <input type="button" value="Back" id="btn_back" class="inputButton" onclick=" return btnbackclick();" />
    </div>
    <div id="divOrderRoute">
        <div id="divRouteOrder">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 19%; float: left;">
                        <label for="lblBranch">
                            Route Name</label>
                    </td>
                    <td style="width: 80%; float: right;">
                        <select id="ddlRouteName" class="ddlBranch" >
                        </select>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divHide">
            <div id="DivIndentType" style="display: none;">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 19%; float: left;">
                            <label for="lblBranch">
                                Indent Type</label>
                        </td>
                        <td style="width: 80%; float: right;">
                            <select id="ddlIndentType" class="ddlBranch">
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tableOrder">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 19%; float: left;">
                            <br />
                            <label for="lblBranch">
                                Agent Name</label>
                        </td>
                        <td style="width: 80%; float: right;">
                            <select id="ddlBranchName" class="ddlBranch" onchange="ddlBranchNameChange(this);">
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tableEmployee">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 19%; float: left;">
                            <label for="lblBranch">
                                Employee Name</label>
                        </td>
                        <td style="width: 80%; float: right;">
                            <select id="ddlEmployee" class="ddlBranch">
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divOrders" style="display: none;">
                <input type="button" value="Orders" id="btnorders" class="inputButton" onclick=" return divOrdersclick();" />
            </div>
            <div id="divIndentReporting" style="display: none;">
                <input type="button" value="Indent Reporting" id="Button8" class="inputButton" onclick=" return divIndentReportingclick();" />
            </div>
            <div id="divDelivers" style="display: none;">
                <input type="button" value="Deliveries" id="btndeliveries" class="inputButton" onclick=" return divDeliveryclick();" />
            </div>
            <div id="divCollections" style="display: none;">
                <input type="button" value="Collections" id="btncollections" class="inputButton"
                    onclick=" return divCollectionsclick();" />
            </div>
            <div id="divReports" >
                <input type="button" value="Reports" id="btnreports" class="inputButton" onclick=" return divReportsclick();" />
            </div>
          <%--  <div id="divindentback" style="display: none">
        
        <input type="button" value="Back" id="btnindentback" class="inputButton" onclick=" return btnindentbackclick();" />
    </div>--%>
            <div id="divonlineindent" style="display: none;">
                <input type="button" value="AgentWiseIndent" id="btnonlineorders" class="inputButton" onclick=" return divindentclick();" />
            </div>
            <div id="divtotalindent" style="display: none;">
                <input type="button" value="Total Indent" id="btntotalindent" class="inputButton" onclick=" return divtotalindentclick();" />
            </div>
            <div id="divOrderReport" style="display: none;">
               <input type="button" value="Order Report" id="Button1" class="inputButton"
                    onclick=" return divOrderReportsclick();" />
            </div>
            <div id="divCollectionReport" style="display: none;">
                <input type="button" value="Collections Report" id="btnColRep" class="inputButton"
                    onclick=" return divCollectionReportsclick();" />
            </div>
            <div id="divInventoryReport" style="display: none;">
                <input type="button" value="Inventory Report" id="Button10" class="inputButton" onclick=" return divInventoryReportclick();" />
            </div>
            <div id="divDeliverReport" style="display: none;">
                <input type="button" value="Delivery Report" id="Button7" class="inputButton" onclick=" return divDeliverReportclick();" />
            </div>
            <div id="divstatus" style="display: none;">
                <input type="button" value="Status Report" id="Button3" class="inputButton" onclick=" return divStatusReportclick();" />
            </div>
            <div id="divNextDayIndentReport" style="display: none;">
                <input type="button" value="Next Day Indent Report" id="Button4" class="inputButton" onclick=" return divNextDayIndentReportclick();" />
            </div>
            <div id="divDispatch" style="display: none;">
                <input type="button" value="Dispatch" id="Button2" class="inputButton" onclick=" return divDispatchclick();" />
            </div>
            <div id="divVerifyInventory" style="display: none;">
                <input type="button" value="Inventory Verifing" id="Button6" class="inputButton"
                    onclick=" return divVerifyInventoryclick();" />
            </div>
            <div id="divReporting">
                <input type="button" value="Reporting" id="btnReporting" class="inputButton" onclick=" return divReportingclick();" />
            </div>
            <div id="divInvReporting" style="display: none;">
                <input type="button" value="Inventory Reporting" id="btnInvReporting" class="inputButton"
                    onclick=" return divInvReportingclick();" />
            </div>
            <div id="divAmountReporting" style="display: none;">
                <input type="button" value="Amount Reporting" id="btnAmount" class="inputButton" onclick=" return divAmountReportingclick();" />
            </div>
            <div id="divShortage">
                <input type="button" value="Leaks and Shortage" id="btnShortage" class="inputButton"
                    onclick=" return divShortageclick();" />
            </div>
              <div id="divAgentRanking" style="display: block;">
                <input type="button" value="Route Plan" id="btnAgentOrder" class="inputButton" onclick=" return divAgentorderclick();" />
                </div>
                 <div id="divOfflineIndent" style="display: block;">
                <input type="button" value="Next Day Indent" id="btnOfflineIndent" class="inputButton"
                    onclick=" return divOfflineIndentclick();" />
            </div>
            
                <div id="divSync" style="display: none;">
                <input type="button" value="Sync database" id="btnSynctoDB" class="inputButton" onclick=" return divSyncDeliversclick();" />
            </div>
           
                <div id="divAgent" style="display: none;width:100%; border-radius: 4px 4px 4px 4px;">
                    <table align="center" style="width:100%;">
                        <tr>
                            <td style="width:70%;float:left;">
                                <div id="divselected" style="float: left; width: 100%; height: 330px;font-size:22px; border: 1px solid gray;
                                    overflow: auto;">
                                </div>
                            </td>
                            <td style="width:29%;float:right;">
                                <div>
                                <br />
                                <br />
                                <br />
                                    <input type="button" class="btnUp" onclick="btnUpClick();" /><br />
                                    <br /><br />
                                    <input type="button" class="btnDown" onclick="btnDownClick();" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                <br />
                                <br />
                                    <input id="btnSaveAgentOrder" type="button" value="Assign" class="ContinueButton" style="width:100%;height:40px;font-size:16px;"  onclick="btnSaveAgentOrderClick();" /><br />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
        </div>
        <div style="width: 100%">
            <div id="divFillScreen">
            </div>
        </div>
    </div>
    </div>
     <div id="divMsgAlert" class="pickupclass" style="text-align: center; height: 112%;
        width: 100%; position: absolute; display: none; left: 0%; top: 0%; z-index: 99999;
        background: rgba(192, 192, 192, 0.7);">
        <div id="divAddNewRow" style="border: 5px solid #A0A0A0; position: absolute; top: 40%;
            background-color: White; left: 20%; right: 20%; width: 55%;bottom:20%; height: 40%; -webkit-box-shadow: 1px 1px 10px rgba(50, 50, 50, 0.65);
            -moz-box-shadow: 1px 1px 10px rgba(50, 50, 50, 0.65); box-shadow: 1px 1px 10px rgba(50, 50, 50, 0.65);
            border-radius: 10px 10px 10px 10px;">
            <table  style="float: left;" id="tableDeliverProductDetails" class="mainText2" >
            <tr>
            <td >
                        <span id="lblAlertMsg" style="font-size:16px;font-weight:bold;" ></span>
                    </td>
            </tr>
                <tr>
                    
                    <td >
                         <img src="" id="imgAlert" alt="Alert"/>
                    </td>
                </tr>
                <tr>
                    
                    <td>
                        <input type="button" value="Ok" id="btnOk" onclick="btnAlertOKClick();" class="ContinueButton"
                            style="width: 100%; height: 40px; font-size: 16px;" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
