Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace XpoLinqNorthwindSample

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Dim connectionStr As String = MSSqlConnectionProvider.GetConnectionString("(local)", "Northwind")
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionStr, AutoCreateOption.DatabaseAndSchema)
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
