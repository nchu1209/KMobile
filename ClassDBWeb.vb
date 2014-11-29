Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class ClassDBWeb
    'Declare module-level variables
    Dim mDatasetCustomer As New DataSet
    Dim mDatasetAccounts2 As New DataSet
    Dim mDatasetTransactions3 As New DataSet
    Dim mDatasetStocks4 As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As New SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size =4096;data source=MISSQL.mccombs.utexas.edu;integrated security=False; initial catalog=mis333k_msbck614; user id=msbck614; password=AmyEnrione1"
    Dim mMyView As New DataView
    Dim mMyView2 As New DataView
    Dim mMyView3 As New DataView
    Dim mMyView4 As New DataView

    'Define a public read-only property so "outsiders" can access the dataset filled by this class
    Public ReadOnly Property CustDataset() As DataSet
        Get
            'Return dataset to user
            Return mDatasetCustomer
        End Get
    End Property
    Public ReadOnly Property MyView() As DataView
        Get
            Return mMyView
        End Get
    End Property

    Public ReadOnly Property AccountsDataset2() As DataSet
        Get
            'Return dataset to user
            Return mDatasetAccounts2
        End Get
    End Property

    Public ReadOnly Property MyView2() As DataView
        Get
            Return mMyView2
        End Get
    End Property


    Public ReadOnly Property TransactionsDataset3() As DataSet
        Get
            'Return dataset to user
            Return mDatasetTransactions3
        End Get
    End Property

    Public ReadOnly Property MyView3() As DataView
        Get
            Return mMyView3
        End Get
    End Property


    Public ReadOnly Property StocksDataset4() As DataSet
        Get
            'Return dataset to user
            Return mDatasetStocks4
        End Get
    End Property

    Public ReadOnly Property MyView4() As DataView
        Get
            Return mMyView4
        End Get
    End Property

    Public Sub RunProcedureOneParameter(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)
        'Purpose: run any stored procedure with one parameter and fill dataset
        'Arguments: 3 strings
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 10/21/14
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
            'clear dataset
            mDatasetCustomer.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetCustomer, "tblCustomers")
            'copy dataset to dataview
            mMyView.Table = mDatasetCustomer.Tables("tblCustomers")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub RunProcedureOneParameterAccounts(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)
        'Purpose: run any stored procedure with one parameter and fill dataset
        'Arguments: 3 strings
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 10/21/14
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
            'clear dataset
            mDatasetAccounts2.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetAccounts2, "tblAccounts")
            'copy dataset to dataview
            mMyView2.Table = mDatasetAccounts2.Tables("tblAccounts")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub RunProcedureOneParameterTransactions(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)
        'Purpose: run any stored procedure with one parameter and fill dataset
        'Arguments: 3 strings
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 10/21/14
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
            'clear dataset
            mDatasetTransactions3.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetTransactions3, "tblTransactions")
            'copy dataset to dataview
            mMyView3.Table = mDatasetTransactions3.Tables("tblTransactions")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub RunProcedureOneParameterStocks(ByVal strProcedureName As String, ByVal strParameterName As String, ByVal strParameterValue As String)
        'Purpose: run any stored procedure with one parameter and fill dataset
        'Arguments: 3 strings
        'Returns: none (query results via property)
        'Author: Nicole Chu (nc7997)
        'Date: 10/21/14
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strProcedureName, objConnection)
        Try
            'sets command type to "stored procedure"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'add parameter to SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParameterName, strParameterValue))
            'clear dataset
            mDatasetStocks4.Clear()
            'open connection and fill dataset
            mdbDataAdapter.Fill(mDatasetStocks4, "tblStocks")
            'copy dataset to dataview
            mMyView4.Table = mDatasetStocks4.Tables("tblStocks")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strProcedureName.ToString & "parameters are " & strParameterName.ToString & strParameterValue.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub GetByEmail(ByVal strEmail As String)
        RunProcedureOneParameter("usp_customers_get_email", "@email", strEmail)
    End Sub

    Public Sub GetAccountByCustomerNumber(strCustomerNumber As String)
        RunProcedureOneParameterAccounts("usp_accounts_get_last_four", "@CustomerNumber", strCustomerNumber)
    End Sub

    Public Sub GetTransactions(strAccountNumber As String)
        RunProcedureOneParameterTransactions("usp_transactions_get_by_account_number", "@AccountNumber", strAccountNumber)
    End Sub

    Public Sub GetStocks(strTicker As String)
        RunProcedureOneParameterStocks("usp_stocks_get_by_keyword_ticker", "@Ticker", strTicker)
    End Sub
End Class
