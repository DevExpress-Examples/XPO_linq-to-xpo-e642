Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System.Linq
Imports System.Linq.Expressions
Imports DevExpress.Xpo
Imports Northwind

Namespace XpoLinqNorthwindSample
	Partial Public Class Form1
		Inherits Form
		Private log As XpoLogWriter
		Public Sub New()
			InitializeComponent()
			log = New XpoLogWriter(textBox1)
			System.Diagnostics.Trace.Listeners.Add(log)
		End Sub


		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' this line is needed to show initial queries produced by XPO 
			' when it connects to the database to retrive an object
			' for the first time after the application is started
			Dim cust As Customer = XpoDefault.Session.FindObject(Of Customer)(Nothing)
		End Sub

		Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			textBox1.Text = ""
		End Sub

		Private Class XpoLogWriter
			Inherits TraceListener
			Private outputWindow As TextBox
			Public Sub New(ByVal outputWindow As TextBox)
				Me.outputWindow = outputWindow
			End Sub
			Public Overrides Overloads Sub Write(ByVal message As String)
				outputWindow.AppendText(message)
			End Sub
			Public Overrides Overloads Sub WriteLine(ByVal message As String)
				outputWindow.AppendText(message & Constants.vbCrLf)
			End Sub
		End Class

		Private customers As XPQuery(Of Customer) = New XPQuery(Of Customer)(Session.DefaultSession)
		Private orders As XPQuery(Of Order) = New XPQuery(Of Order)(Session.DefaultSession)
		Private employees As XPQuery(Of Employee) = New XPQuery(Of Employee)(Session.DefaultSession)

		Private Sub btnSelectWhere_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectWhere.Click
			log.WriteLine("---------------------------------")
			' simple Select with Where and OrderBy clauses
			Dim myList = _
				From c In customers _
				Where (c.Country = "Germany" AndAlso c.ContactTitle = "Sales Representative") _
				Order By c.ContactName _
				Select c
			For Each cust As Customer In myList
				log.WriteLine(String.Format("{0}" & Constants.vbTab & "{1}" & Constants.vbTab & "{2}", cust.ContactName, cust.Country, cust.ContactTitle))
			Next cust
		End Sub

		Private Sub btnSelectTop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectTop.Click
			log.WriteLine("---------------------------------")
			' Select Top 5 objects
			Dim myList = ( _
					From o In orders _
					Order By o.ShippedDate Descending _
					Select o).Take(5)
			For Each order As Order In myList
				log.WriteLine(String.Format("{0}" & Constants.vbTab & "{1}" & Constants.vbTab & "{2}", order.OrderID, order.ShippedDate, order.Customer.CompanyName))
			Next order
		End Sub

		Private Sub btnJoin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnJoin.Click
			log.WriteLine("---------------------------------")
			' Group Join customers with an aggregation on their Orders
			Dim myList = _
				From c In customers _
				Group Join o In orders On c Equals o.Customer Into oo = Group _
				Where oo.Count() >= 1 _
				Select New With {Key c.CompanyName, Key .OrderCount = oo.Count()}
			For Each item In myList
				log.WriteLine(String.Format("{0}" & Constants.vbTab & "{1}", item.CompanyName, item.OrderCount))
			Next item
		End Sub

		Private Sub btnAggregates_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAggregates.Click
			log.WriteLine("---------------------------------")
			' an example of aggregated functions (Count and Average)
			Dim myList = _
				From o In orders _
				Select o
			Dim count As Integer = myList.Count()
			log.WriteLine(String.Format("Orders Row Count: {0}", count))

			Dim avg As Decimal = myList.Average(Function(x) x.Freight)
			log.WriteLine(String.Format("Orders Average Freight: {0:c2}", avg))
		End Sub

		Private Sub btnGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGroup.Click
			log.WriteLine("---------------------------------")
			' Select with Group By
			Dim myList = _
				From c In customers _
				Group c By c.ContactTitle Into cc = Group _
				Where cc.Count() >= 1 _
				Select New With {Key .Title = ContactTitle, Key .Count = cc.Count()}
			For Each item In myList
				log.WriteLine(String.Format("{0}" & Constants.vbTab & "{1}", item.Title, item.Count))
			Next item
		End Sub

		Private Sub btnAny_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAny.Click
			log.WriteLine("---------------------------------")
			Dim result As Boolean = customers.Any(Function(c) c.Country = "Spain")
			log.WriteLine(String.Format("Is there any customer from Spain? {0}",If(result, "Yes", "No")))
			result = customers.Any(Function(c) c.Country = "Monaco")
			log.WriteLine(String.Format("Is there any customer from Monaco? {0}",If(result, "Yes", "No")))
		End Sub
	End Class
End Namespace