namespace Northwind {
    using System;
    using DevExpress.Xpo;
    [Persistent("Customers")]
    public class Customer : XPLiteObject {
        public Customer(Session session) : base(session) { }
        private string _City;
        private string _Country;
        private string _ContactName;
        private string _ContactTitle;
        private string _CompanyName;
        private string _CustomerId;
        [Key]
        public string CustomerId {
            get {
                return _CustomerId;
            }
            set {
                SetPropertyValue("CustomerId", ref _CustomerId, value);
            }
        }
        public string CompanyName {
            get {
                return _CompanyName;
            }
            set {
                SetPropertyValue("CompanyName", ref _CompanyName, value);
            }
        }
        public string ContactTitle {
            get {
                return _ContactTitle;
            }
            set {
                SetPropertyValue("ContactTitle", ref _ContactTitle, value);
            }
        }
        public string ContactName {
            get {
                return _ContactName;
            }
            set {
                SetPropertyValue("ContactName", ref _ContactName, value);
            }
        }
        public string Country {
            get {
                return _Country;
            }
            set {
                SetPropertyValue("Country", ref _Country, value);
            }
        }
        public string City {
            get {
                return _City;
            }
            set {
                SetPropertyValue("City", ref _City, value);
            }
        }
        [Association("CustomerOrders", typeof(Order))]
        public XPCollection<Order> Orders {
            get {
                return GetCollection<Order>("Orders");
            }
        }
    }

    [Persistent("Orders")]
    public class Order : XPLiteObject {
        public Order(Session session) : base(session) { }

        private decimal _Freight;
        private Employee _Employee;
        private Customer _Customer;
        private DateTime _ShippedDate;
        private int _OrderID;
        [Key]
        public int OrderID {
            get {
                return _OrderID;
            }
            set {
                SetPropertyValue("OrderID", ref _OrderID, value);
            }
        }
        public DateTime ShippedDate {
            get {
                return _ShippedDate;
            }
            set {
                SetPropertyValue("ShippedDate", ref _ShippedDate, value);
            }
        }
        [Persistent("CustomerID"), Association("CustomerOrders")]
        public Customer Customer {
            get {
                return _Customer;
            }
            set {
                SetPropertyValue("Customer", ref _Customer, value);
            }
        }

        [Persistent("EmployeeID"), Association("EmployeeOrders")]
        public Employee Employee {
            get {
                return _Employee;
            }
            set {
                SetPropertyValue("Employee", ref _Employee, value);
            }
        }
        public decimal Freight {
            get {
                return _Freight;
            }
            set {
                SetPropertyValue("Freight", ref _Freight, value);
            }
        }
    }
    [Persistent("Employees")]
    public class Employee : XPLiteObject {
        public Employee(Session session) : base(session) { }

        private string _LastName;
        private string _FirstName;
        private int _EmployeeID;
        [Key]
        public int EmployeeID {
            get {
                return _EmployeeID;
            }
            set {
                SetPropertyValue("EmployeeID", ref _EmployeeID, value);
            }
        }
        public string FirstName {
            get {
                return _FirstName;
            }
            set {
                SetPropertyValue("FirstName", ref _FirstName, value);
            }
        }
        public string LastName {
            get {
                return _LastName;
            }
            set {
                SetPropertyValue("LastName", ref _LastName, value);
            }
        }
        [Association("EmployeeOrders")]
        public XPCollection<Order> Orders {
            get {
                return GetCollection<Order>("Orders");
            }
        }
    }
}