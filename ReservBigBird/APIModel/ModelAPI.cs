using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservBigBird.APIModel
{
    public class ModelAPI
    {
    }
    public class Article
    {
        public string articleId { get; set; }
        public string articleIdAlias { get; set; }
        public string articleName { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public string department { get; set; }
        public string departmentType { get; set; }
        public string gender { get; set; }
        public int id { get; set; }
        public int price { get; set; }
        public string size { get; set; }
        public string unit { get; set; }
    }

    public class Login
    {
        public int id { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String pass { get; set; }
    }

    public class MonitorOrder
    {
        public string NoItem { get; set; }
        public string NoOrder { get; set; }
        public string Sts { get; set; }
        public string Disc { get; set; }
        public string Jenis { get; set; }
        public string Pool { get; set; }
        public string KelTujuan { get; set; }
        public string AlamatJemput { get; set; }
        public string TglJemput { get; set; }
        public string JamJemput { get; set; }
        public string TglSelesei { get; set; }
        public string JamSelesei { get; set; }
    }

    public class DisplayPlanning
    {
        public int NoDetail { get; set; }
        public string NoOrder { get; set; }
        public string TglPakai { get; set; }
        public string JamJemput { get; set; }
        public string Bus { get; set; }
        public string Nip1 { get; set; }
        public string Hp { get; set; }
        public string Popnpk { get; set; }
        public int Popid { get; set; }
        public string Popnpm { get; set; }
        public string Poppolid { get; set; }
        public string popdaow { get; set; }
    }

    //public class ListTgl
    //{
    //    public string Date { get; set; }
    //    public int Value { get; set; }
    //}

    //public class TerimaOrder
    //{
    //    public string poolName { get; set; }
    //    public IList<ListTgl> ListTgl { get; set; }
    //}


    public class ListJml
    {
        public int jml { get; set; }
    }

    public class Datum
    {
        public string poolName { get; set; }
        public IList<ListJml> listJml { get; set; }
    }

    public class TerimaOrder
    {
        public IList<Datum> data { get; set; }
        public int stck { get; set; }
        public string jnb { get; set; }
    }

    public class ListJml2
    {
        public int jml { get; set; }
    }

    public class TerimaOrder2
    {
        public string poolName { get; set; }
        public int stc { get; set; }
        public IList<ListJml2> listJml { get; set; }
    }

    //public class ListJml
    //{
    //    public int jml { get; set; }
    //}

    //public class TerimaOrder
    //{
    //    public string poolName { get; set; }
    //    public IList<ListJml> listJml { get; set; }
    //}

    public class BudgetStore
    {
        public int budget { get; set; }
        public int remaining { get; set; }
    }

    public class Denomination
    {
        public int id { get; set; }
        public int currencyIdFk { get; set; }
        public int nominal { get; set; }
    }

    public class Currency
    {
        public string sign { get; set; }
        public string name { get; set; }
        public IList<Denomination> denominations { get; set; }
    }

    public class Store
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public object Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Regional { get; set; }
        public int StoreTypeId { get; set; }
        public object Address2 { get; set; }
        public object Address3 { get; set; }
        public object Address4 { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerIdStore { get; set; }
    }

    public class Warehouse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public object Type { get; set; }
        public string Address { get; set; }
        public object Address2 { get; set; }
        public object Address3 { get; set; }
        public object Address4 { get; set; }
        public string City { get; set; }
        public string Regional { get; set; }
        public object Division { get; set; }
    }

    public class Bank
    {
        public string bankId { get; set; }
        public string bankName { get; set; }
        public string account { get; set; }
    }

    public class Possition
    {
        public int id { get; set; }
        public string possitionId { get; set; }
        public string possitionName { get; set; }
    }

    public class Employee
    {
        public int id { get; set; }
        public string employeeId { get; set; }
        public string name { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public string passwordaja { get; set; }
        public Possition possition { get; set; }
    }

    public class storedata
    {
        public string deviceCode { get; set; }
        public BudgetStore budgetStore { get; set; }
        public Currency currency { get; set; }
        public object customerData { get; set; }
        public Store store { get; set; }
        public Warehouse warehouse { get; set; }
        public IList<Bank> banks { get; set; }
        public IList<Employee> employees { get; set; }
    }

}