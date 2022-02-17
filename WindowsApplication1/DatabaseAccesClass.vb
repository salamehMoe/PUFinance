Imports System.Data.SqlClient
Imports System.DirectoryServices

Public Class DatabaseAccesClass
    Private connectionString = "Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;"
    Dim dt As New DataTable
    Dim da As New SqlDataAdapter
    '   Method : GetConnection()
    '   Role   : Open sqlconnection with database based on the connectionstring
    '   ---------------------------------------------

    Public Function GetConnection() As SqlConnection
        Dim MySqlConnection As SqlConnection = New SqlConnection(connectionString)
        MySqlConnection.Open()
        Return MySqlConnection
    End Function
    Public Sub closeconnection()
        Dim conn As New SqlConnection
        conn = GetConnection()
        conn.Close()
    End Sub

    '   Method : ExecuteDataset(command)
    '   Role   : Return the result for the sql query as Dataset 
    '   -----------------------------------------------------

    Public Function ExecuteDataset(ByVal command As String) As DataSet

        Dim sqlAdapter As SqlDataAdapter = New SqlDataAdapter()
        sqlAdapter.SelectCommand = New SqlCommand(command, GetConnection())

        Dim dataSet As DataSet = New DataSet()
        sqlAdapter.Fill(dataSet)
        Return dataSet

    End Function



    '   Method :ExecuteDataReader(command)
    '   Role   : Return the result for the sql query as DataReader 
    '   --------------------------------------------------------

    Public Function ExecuteDataReader(ByVal command As String) As SqlDataReader

        Dim SqReader As SqlDataReader
        Dim SqlCom As SqlCommand = New SqlCommand(command, GetConnection())
        SqReader = SqlCom.ExecuteReader()
        Return SqReader

    End Function




    '   Method : ExecuteNonQuery(command)
    '   Role   : Insert or update or delete record from database based on sql query
    '   -------------------------------------------------------------------------

    Public Function PerformQuery_GetID(ByVal command As String) As Integer

        Dim result As Integer
        Dim conn As SqlConnection = GetConnection()
        Dim com As SqlCommand = New SqlCommand(command, conn)
        com.CommandType = CommandType.Text
        result = com.ExecuteNonQuery()

        'This part to get the ID of last inserted Item

        If command.Contains("Insert") = True Or command.Contains("INSERT") Then
            Dim query As String = " SELECT SCOPE_IDENTITY()"
            Dim com1 As SqlCommand = New SqlCommand(query, conn)
            com1.CommandType = CommandType.Text
            result = com1.ExecuteScalar()
        End If

        Return result

    End Function

    '   Method : ExecuteScaler(command)
    '   Role   : Get the ID of record in DB based on sql query asked
    '   ----------------------------------------------------------

    Public Function ExecuteScaler(ByVal command As String) As Integer

        Dim ID As Integer
        Dim com As SqlCommand = New SqlCommand(command, GetConnection())
        ID = CInt(com.ExecuteScalar())
        Return ID

    End Function

    '//////////////////////////////////////////////
    'Method: PerformQuery(query)
    'Role :general method to execute sql query
    '//////////////////////////////////////////////

    Public Function PerformQuery(ByVal query As String) As Integer
        Dim conn As SqlConnection = GetConnection()
        Dim com As SqlCommand = New SqlCommand(query, conn)
        com.CommandType = CommandType.Text
        Return com.ExecuteNonQuery()
    End Function

    '   Method : CheckQueryResults(Value,index)
    '   Role   : Check if the query is executed according to the value passed to it
    '   --------------------------------------------------------------------------

    Public Sub CheckQueryResults(ByVal Value As Integer, ByVal Index As Integer)
        Dim Result As String = ""

        Select Case Index
            Case 0 'Case of INSERT Query
                If Value > 0 Then
                    MessageBox.Show("Data Inserted Successfully", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Failed To Insert Data", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

            Case 1 'Case of UPDATE Query
                If Value > 0 Then
                    MessageBox.Show("Data Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Failed To Update Data", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

            Case 2 'Case Of DELETE Query
                If Value > 0 Then
                    MessageBox.Show("Data Deleted Successfuly", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Failed To Delete Data", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
        End Select
    End Sub

    Public Function SelectMethode(ByVal str As String) As DataTable

        dt = New DataTable
        Dim sql As String = str
        da = New SqlDataAdapter(sql, GetConnection())
        dt.Clear()
        da.Fill(dt)
        Return dt

    End Function
End Class
