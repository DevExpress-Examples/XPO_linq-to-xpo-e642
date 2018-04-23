Imports DevExpress.Xpo
Imports System

Namespace Northwind
    <Persistent("Customers")> _
    Public Class Customer
        Inherits XPLiteObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _City As String
        Private _Country As String
        Private _ContactName As String
        Private _ContactTitle As String
        Private _CompanyName As String
        Private _CustomerId As String
        <Key> _
        Public Property CustomerId() As String
            Get
                Return _CustomerId
            End Get
            Set(ByVal value As String)
                SetPropertyValue("CustomerId", _CustomerId, value)
            End Set
        End Property
        Public Property CompanyName() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal value As String)
                SetPropertyValue("CompanyName", _CompanyName, value)
            End Set
        End Property
        Public Property ContactTitle() As String
            Get
                Return _ContactTitle
            End Get
            Set(ByVal value As String)
                SetPropertyValue("ContactTitle", _ContactTitle, value)
            End Set
        End Property
        Public Property ContactName() As String
            Get
                Return _ContactName
            End Get
            Set(ByVal value As String)
                SetPropertyValue("ContactName", _ContactName, value)
            End Set
        End Property
        Public Property Country() As String
            Get
                Return _Country
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Country", _Country, value)
            End Set
        End Property
        Public Property City() As String
            Get
                Return _City
            End Get
            Set(ByVal value As String)
                SetPropertyValue("City", _City, value)
            End Set
        End Property
        <Association("CustomerOrders", GetType(Order))> _
        Public ReadOnly Property Orders() As XPCollection(Of Order)
            Get
                Return GetCollection(Of Order)("Orders")
            End Get
        End Property
    End Class

    <Persistent("Orders")> _
    Public Class Order
        Inherits XPLiteObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private _Freight As Decimal
        Private _Employee As Employee
        Private _Customer As Customer
        Private _ShippedDate As Date
        Private _OrderID As Integer
        <Key> _
        Public Property OrderID() As Integer
            Get
                Return _OrderID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("OrderID", _OrderID, value)
            End Set
        End Property
        Public Property ShippedDate() As Date
            Get
                Return _ShippedDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue("ShippedDate", _ShippedDate, value)
            End Set
        End Property
        <Persistent("CustomerID"), Association("CustomerOrders")> _
        Public Property Customer() As Customer
            Get
                Return _Customer
            End Get
            Set(ByVal value As Customer)
                SetPropertyValue("Customer", _Customer, value)
            End Set
        End Property

        <Persistent("EmployeeID"), Association("EmployeeOrders")> _
        Public Property Employee() As Employee
            Get
                Return _Employee
            End Get
            Set(ByVal value As Employee)
                SetPropertyValue("Employee", _Employee, value)
            End Set
        End Property
        Public Property Freight() As Decimal
            Get
                Return _Freight
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue("Freight", _Freight, value)
            End Set
        End Property
    End Class
    <Persistent("Employees")> _
    Public Class Employee
        Inherits XPLiteObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private _LastName As String
        Private _FirstName As String
        Private _EmployeeID As Integer
        <Key> _
        Public Property EmployeeID() As Integer
            Get
                Return _EmployeeID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("EmployeeID", _EmployeeID, value)
            End Set
        End Property
        Public Property FirstName() As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue("FirstName", _FirstName, value)
            End Set
        End Property
        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue("LastName", _LastName, value)
            End Set
        End Property
        <Association("EmployeeOrders")> _
        Public ReadOnly Property Orders() As XPCollection(Of Order)
            Get
                Return GetCollection(Of Order)("Orders")
            End Get
        End Property
    End Class
End Namespace