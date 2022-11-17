Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Linq
Imports DevExpress.Xpo
Imports Northwind

Namespace XpoLinqNorthwindSample

    Public Partial Class Form1
        Inherits Form

        Private log As XpoLogWriter

        Public Sub New()
            InitializeComponent()
            log = New XpoLogWriter(textBox1)
            System.Diagnostics.Trace.Listeners.Add(log)
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' this line is needed to show initial queries produced by XPO 
            ' when it connects to the database to retrive an object
            ' for the first time after the application is started
            Dim cust As Customer = XpoDefault.Session.FindObject(Of Customer)(Nothing)
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs)
            textBox1.Text = ""
        End Sub

        Private Class XpoLogWriter
            Inherits TraceListener

            Private outputWindow As TextBox

            Public Sub New(ByVal outputWindow As TextBox)
                Me.outputWindow = outputWindow
            End Sub

            Public Overrides Sub Write(ByVal message As String)
                outputWindow.AppendText(message)
            End Sub

            Public Overrides Sub WriteLine(ByVal message As String)
                outputWindow.AppendText(message & Microsoft.VisualBasic.Constants.vbCrLf)
            End Sub
        End Class

        Private customers As XPQuery(Of Customer) = New XPQuery(Of Customer)(Session.DefaultSession)

        Private orders As XPQuery(Of Order) = New XPQuery(Of Order)(Session.DefaultSession)

        Private employees As XPQuery(Of Employee) = New XPQuery(Of Employee)(Session.DefaultSession)

        Private Sub btnSelectWhere_Click(ByVal sender As Object, ByVal e As EventArgs)
            log.WriteLine("---------------------------------")
            ' simple Select with Where and OrderBy clauses
            Dim myList = From c In customers Where c.Country Is "Germany" AndAlso c.ContactTitle Is "Sales Representative" Order By c.ContactName Select c
            For Each cust As Customer In myList
                log.WriteLine(String.Format("{0}" & Microsoft.VisualBasic.Constants.vbTab & "{1}" & Microsoft.VisualBasic.Constants.vbTab & "{2}", cust.ContactName, cust.Country, cust.ContactTitle))
            Next
        End Sub

        Private Sub btnSelectTop_Click(ByVal sender As Object, ByVal e As EventArgs)
            log.WriteLine("---------------------------------")
            ' Select Top 5 objects
            Dim myList =(From o In orders Order By o.ShippedDate Select o).Take(5)
            For Each order As Order In myList
                log.WriteLine(String.Format("{0}" & Microsoft.VisualBasic.Constants.vbTab & "{1}" & Microsoft.VisualBasic.Constants.vbTab & "{2}", order.OrderID, order.ShippedDate, order.Customer.CompanyName))
            Next
        End Sub

        Private Sub btnJoin_Click(ByVal sender As Object, ByVal e As EventArgs)
            log.WriteLine("---------------------------------")
            ' Group Join customers with an aggregation on their Orders
            Dim myList = From c In customers Group Join o In orders On c Equals o.Customer Into oo = Group Where oo.Count() >= 1 Select New With {c.CompanyName, .OrderCount = oo.Count()}
            For Each item In myList
                log.WriteLine(String.Format("{0}" & Microsoft.VisualBasic.Constants.vbTab & "{1}", item.CompanyName, item.OrderCount))
            Next
        End Sub

        Private Sub btnAggregates_Click(ByVal sender As Object, ByVal e As EventArgs)
            log.WriteLine("---------------------------------")
            ' an example of aggregated functions (Count and Average)
            Dim myList = From o In orders Select o
            Dim count As Integer = myList.Count()
            log.WriteLine(String.Format("Orders Row Count: {0}", count))
            Dim avg As Decimal = myList.Average(Function(x) x.Freight)
            log.WriteLine(String.Format("Orders Average Freight: {0:c2}", avg))
        End Sub

        Private Sub btnGroup_Click(ByVal sender As Object, ByVal e As EventArgs)
            log.WriteLine("---------------------------------")
            ' Select with Group By
            Dim myList = From c In customers Group c By __groupByKey1__ = c.ContactTitle Into cc = Group Select New With {.Title = __groupByKey1__, .Count = cc.Count()}
            For Each item In myList
                log.WriteLine(String.Format("{0}" & Microsoft.VisualBasic.Constants.vbTab & "{1}", item.Title, item.Count))
            Next
        End Sub

        Private Sub btnAny_Click(ByVal sender As Object, ByVal e As EventArgs)
            log.WriteLine("---------------------------------")
            Dim result As Boolean = customers.Any(Function(c) c.Country Is "Spain")
            log.WriteLine(String.Format("Is there any customer from Spain? {0}", If(result, "Yes", "No")))
            result = customers.Any(Function(c) c.Country Is "Monaco")
            log.WriteLine(String.Format("Is there any customer from Monaco? {0}", If(result, "Yes", "No")))
        End Sub
    End Class
End Namespace
