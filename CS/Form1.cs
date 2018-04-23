using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Xpo;
using Northwind;

namespace XpoLinqNorthwindSample {
    public partial class Form1 : Form {
        XpoLogWriter log;
        public Form1() {
            InitializeComponent();
            log = new XpoLogWriter(textBox1);
            System.Diagnostics.Trace.Listeners.Add(log);
        }
        private void Form1_Load(object sender, EventArgs e) {
            // this line is needed to show initial queries produced by XPO 
            // when it connects to the database to retrive an object
            // for the first time after the application is started
            Customer cust = XpoDefault.Session.FindObject<Customer>(null);
        }
        private void btnClear_Click(object sender, EventArgs e) {
            textBox1.Text = "";
        }
        class XpoLogWriter : TraceListener {
            TextBox outputWindow;
            public XpoLogWriter(TextBox outputWindow) {
                this.outputWindow = outputWindow;
            }
            public override void Write(string message) {
                outputWindow.AppendText(message);
            }
            public override void WriteLine(string message) {
                outputWindow.AppendText(message + "\r\n");
            }
        }

        XPQuery<Customer> customers = new XPQuery<Customer>(Session.DefaultSession);
        XPQuery<Order> orders = new XPQuery<Order>(Session.DefaultSession);
        XPQuery<Employee> employees = new XPQuery<Employee>(Session.DefaultSession);

        private void btnSelectWhere_Click(object sender, EventArgs e) {
            log.WriteLine("---------------------------------");
            // simple Select with Where and OrderBy clauses
            var myList = from c in customers
                       where (c.Country == "Germany" && c.ContactTitle == "Sales Representative")
                       orderby c.ContactName
                       select c;
            foreach (Customer cust in myList)
                log.WriteLine(string.Format("{0}\t{1}\t{2}", cust.ContactName, cust.Country, cust.ContactTitle));
        }

        private void btnSelectTop_Click(object sender, EventArgs e) {
            log.WriteLine("---------------------------------");
            // Select Top 5 objects
            var myList = (from o in orders
                        orderby o.ShippedDate descending
                        select o).Take(5);
            foreach (Order order in myList)
                log.WriteLine(string.Format("{0}\t{1}\t{2}", order.OrderID, order.ShippedDate, order.Customer.CompanyName));
        }

        private void btnJoin_Click(object sender, EventArgs e) {
            log.WriteLine("---------------------------------");
            // Group Join customers with an aggregation on their Orders
            var myList = from c in customers
                       join o in orders on c equals o.Customer into oo
                       where oo.Count() >= 1
                       select new { c.CompanyName, OrderCount = oo.Count() };
            foreach (var item in myList)
                log.WriteLine(string.Format("{0}\t{1}", item.CompanyName, item.OrderCount));
        }

        private void btnAggregates_Click(object sender, EventArgs e) {
            log.WriteLine("---------------------------------");
            // an example of aggregated functions (Count and Average)
            var myList = from o in orders
                       select o;
            int count = myList.Count();
            log.WriteLine(string.Format("Orders Row Count: {0}", count));

            decimal avg = myList.Average(x => x.Freight);
            log.WriteLine(string.Format("Orders Average Freight: {0:c2}", avg));
        }

        private void btnGroup_Click(object sender, EventArgs e) {
            log.WriteLine("---------------------------------");
            // Select with Group By
            var myList = from c in customers
                       group c by c.ContactTitle into cc
                       where cc.Count() >= 1
                       select new { Title = cc.Key, Count = cc.Count() };
            foreach (var item in myList)
                log.WriteLine(string.Format("{0}\t{1}", item.Title, item.Count));
        }

        private void btnAny_Click(object sender, EventArgs e) {
            log.WriteLine("---------------------------------");
            bool result = customers.Any(c => c.Country == "Spain");
            log.WriteLine(string.Format("Is there any customer from Spain? {0}", result ? "Yes" : "No"));
            result = customers.Any(c => c.Country == "Monaco");
            log.WriteLine(string.Format("Is there any customer from Monaco? {0}", result ? "Yes" : "No"));
        }
    }
}