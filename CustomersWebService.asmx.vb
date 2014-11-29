Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Services
Imports System.Collections.Generic



' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<ScriptService()> _
Public Class CustomersWebService
    Inherits System.Web.Services.WebService
    Dim DB As New ClassDBWeb

    Public Structure Customer
        Public RecordID As Integer
        Public Username As String
        Public Password As String
        Public Lastname As String
        Public Firstname As String
        Public MI As String
        Public Address As String
        Public City As String
        Public State As String
        Public Zipcode As String
        Public Phone As String
        Public EmailAddr As String
    End Structure

    Public Structure Accounts
        Public AccountNumber As String
        Public AccountNumberReal As String
        Public AccountName As String
        Public Balance As Integer
    End Structure

    Public Structure Transactions
        Public Description As String
        Public TransactionAmount As String
        Public DateTr As String
    End Structure

    Public Structure Stocks
        Public StockName As String
        Public StockTicker As String
        Public Price As String
    End Structure

    Public Structure Test
        Public Correct As Boolean
        Public CustomerNumber As String
    End Structure

    <WebMethod()> _
    Public Function GetEmail(email As String) As List(Of Customer)
        Dim stuff As New List(Of Customer)
        DB.GetByEmail(email)


        Try
            For i = 0 To DB.CustDataset.Tables("tblCustomers").Rows.Count - 1
                Dim person As New Customer
                person.Password = DB.CustDataset.Tables("tblCustomers").Rows(i).Item("Password").ToString
                stuff.Add(person)
            Next
        Catch ex As Exception

        End Try


        Return stuff
    End Function

    <WebMethod()> _
    Public Function CheckEmail(email As String) As Integer
        Dim count As Integer
        DB.GetByEmail(email)
        count = DB.CustDataset.Tables("tblCustomers").Rows.Count()


        Return count
    End Function



    <WebMethod()> _
    Public Function CheckLogin(email As String, password As String) As Boolean
        DB.GetByEmail(email)
        If DB.CustDataset.Tables("tblCustomers").Rows.Count() > 0 Then
            If DB.CustDataset.Tables("tblCustomers").Rows(0).Item("Password").ToString = password Then
                Return True
            End If

        End If

        Return False
    End Function



    <WebMethod()> _
    Public Function CheckLoginFinal(email As String, password As String) As String
        DB.GetByEmail(email)
        Dim CNumber As String
        If DB.CustDataset.Tables("tblCustomers").Rows.Count() > 0 Then
            If DB.CustDataset.Tables("tblCustomers").Rows(0).Item("Password").ToString = password Then
                CNumber = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("CustomerNumber").ToString
            Else
                CNumber = ""
            End If
        Else
            CNumber = ""
        End If

        Return CNumber
    End Function



    <WebMethod()> _
    Public Function LoginStructure(email As String, password As String) As List(Of Test)
        DB.GetByEmail(email)
        Dim Login As New List(Of Test)

        If DB.CustDataset.Tables("tblCustomers").Rows.Count() > 0 Then
            If DB.CustDataset.Tables("tblCustomers").Rows(0).Item("Password").ToString = password Then

                Try
                    For i = 0 To DB.CustDataset.Tables("tblCustomers").Rows.Count() - 1
                        Dim exam As New Test
                        exam.Correct = True
                        exam.CustomerNumber = DB.CustDataset.Tables("tblCustomers").Rows(i).Item("CustomerNumber").ToString
                        Login.Add(exam)
                    Next
                Catch ex As Exception
                    Throw New Exception("Error is " & ex.Message.ToString)
                End Try

            End If

        End If

        Return Login
    End Function


    <WebMethod()> _
    Public Function GetCustomerNumber() As String
        Dim custNumber As String
        custNumber = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("CustomerNumber").ToString()

        Return custNumber

    End Function


    <WebMethod()> _
    Public Function CheckPassword(password As String) As String
        Dim strDBPassword As String
        strDBPassword = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("password").ToString

        'check if input password matches DB password and return T/F
        If strDBPassword = password Then
            Return "success"
        End If

        Return "error"
    End Function


    <WebMethod()> _
    Public Function GetAccounts(customerNumber As String) As List(Of Accounts)
        Dim bank As New List(Of Accounts)
        DB.GetAccountByCustomerNumber(customerNumber)
        Dim i As Integer

        If DB.AccountsDataset2.Tables("tblAccounts").Rows.Count() > 0 Then
            Try
                For i = 0 To DB.AccountsDataset2.Tables("tblAccounts").Rows.Count - 1
                    Dim account As New Accounts
                    account.AccountNumber = DB.AccountsDataset2.Tables("tblAccounts").Rows(i).Item("Account Number").ToString
                    account.AccountNumberReal = DB.AccountsDataset2.Tables("tblAccounts").Rows(i).Item("AccountNumber").ToString
                    account.AccountName = DB.AccountsDataset2.Tables("tblAccounts").Rows(i).Item("AccountName").ToString
                    account.Balance = CInt(DB.AccountsDataset2.Tables("tblAccounts").Rows(i).Item("Balance"))
                    bank.Add(account)
                Next
            Catch ex As Exception
                Throw New Exception("Error is " & ex.Message.ToString)
            End Try
        End If

        Return bank
    End Function


    <WebMethod()> _
    Public Function GetTransactions(accountNumber As String) As List(Of Transactions)
        Dim listTr As New List(Of Transactions)
        DB.GetTransactions(accountNumber)
        Dim i As Integer

        If DB.TransactionsDataset3.Tables("tblTransactions").Rows.Count() > 0 Then
            Try
                For i = 0 To DB.TransactionsDataset3.Tables("tblTransactions").Rows.Count - 1
                    Dim idk As New Transactions
                    idk.Description = DB.TransactionsDataset3.Tables("tblTransactions").Rows(i).Item("Description").ToString
                    idk.TransactionAmount = DB.TransactionsDataset3.Tables("tblTransactions").Rows(i).Item("TransactionAmount").ToString
                    idk.DateTr = DB.TransactionsDataset3.Tables("tblTransactions").Rows(i).Item("Date").ToString
                    listTr.Add(idk)
                Next
            Catch ex As Exception
                Throw New Exception("Error is " & ex.Message.ToString)
            End Try
        End If

        Return listTr
    End Function


    <WebMethod()> _
    Public Function GetStocks(ticker As String) As List(Of Stocks)
        Dim tickers As New List(Of Stocks)
        DB.GetStocks(ticker)
        Dim i As Integer

        If DB.StocksDataset4.Tables("tblStocks").Rows.Count() > 0 Then
            Try
                For i = 0 To DB.StocksDataset4.Tables("tblStocks").Rows.Count - 1
                    Dim money As New Stocks
                    money.StockName = DB.StocksDataset4.Tables("tblStocks").Rows(i).Item("Name").ToString
                    money.StockTicker = DB.StocksDataset4.Tables("tblStocks").Rows(i).Item("TickerSymbol").ToString
                    money.Price = DB.StocksDataset4.Tables("tblStocks").Rows(i).Item("SalesPrice").ToString
                    tickers.Add(money)
                Next
            Catch ex As Exception
                Throw New Exception("Error is " & ex.Message.ToString)
            End Try
        End If

        Return tickers
    End Function



    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

End Class