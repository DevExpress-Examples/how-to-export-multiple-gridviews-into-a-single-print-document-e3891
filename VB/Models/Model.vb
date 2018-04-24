Imports System.Web
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic

Namespace CS.Model
    Public Class MyModel
        Public Shared Function GetCategories() As DataTable
            Dim dataTableCategories As New DataTable()
            Using connection As OleDbConnection = GetConnection()
                Dim adapter As New OleDbDataAdapter(String.Empty, connection)
                adapter.SelectCommand.CommandText = "SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]"
                adapter.Fill(dataTableCategories)
            End Using
            Return dataTableCategories
        End Function
        Public Shared Function GetProducts(ByVal masterRowKey As Object) As DataTable
            Dim dataTableProducts As New DataTable()
            Using connection As OleDbConnection = GetConnection()
                Dim adapter As New OleDbDataAdapter(String.Empty, connection)
                adapter.SelectCommand.CommandText = "SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products]"

                If masterRowKey IsNot Nothing Then
                    adapter.SelectCommand.CommandText &= "WHERE [CategoryID] = @CategoryID"

                    adapter.SelectCommand.Parameters.Add("@CategoryID", OleDbType.SmallInt)
                    adapter.SelectCommand.Parameters("@CategoryID").Value = masterRowKey
                    adapter.Fill(dataTableProducts)
                End If

            End Using
            Return dataTableProducts
        End Function

        Private Shared Function GetConnection() As OleDbConnection
            Dim connection As New OleDbConnection()
            connection.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/nwind.mdb"))
            Return connection
        End Function

    End Class

    Public Class MyViewModel
        Public Property Categories() As DataTable
        Public Property Products() As DataTable
    End Class
End Namespace