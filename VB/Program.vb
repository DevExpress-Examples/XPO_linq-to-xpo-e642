Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace XpoLinqNorthwindSample
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Dim connectionStr As String = MSSqlConnectionProvider.GetConnectionString("(local)", "Northwind")
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionStr, AutoCreateOption.DatabaseAndSchema)

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace
