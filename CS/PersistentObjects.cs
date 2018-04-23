namespace Northwind {
    using System;
    using DevExpress.Xpo;


    [Persistent("Customers")]
    public class Customer : XPLiteObject {
        public Customer(Session session) : base(session) { }

        [Key]
        public string CustomerID;

        public string CompanyName;
        public string ContactTitle;
        public string ContactName;
        public string Country;
        public string City;

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

        [Key]
        public int OrderID;
        public DateTime ShippedDate;

        [Persistent("CustomerID"), Association("CustomerOrders")]
        public Customer Customer;

        [Persistent("EmployeeID"), Association("EmployeeOrders")]
        public Employee Employee;

        public decimal Freight;
    }

    [Persistent("Employees")]
    public class Employee : XPLiteObject {
        public Employee(Session session) : base(session) { }

        [Key]
        public int EmployeeID;
        public string FirstName;
        public string LastName;

        [Association("EmployeeOrders")]
        public XPCollection<Order> Orders {
            get {
                return GetCollection<Order>("Orders");
            }
        }
    }
}