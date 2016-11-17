' James  English
' IT 505
'11/13/12

Option Strict On
Imports System.Data.SqlClient
Imports System.Xml


Public Class Form1
    Private connectionNorthwind As New SqlConnection
    '------------------------------------------------------------------------------------------------------------------------

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim rslt As DialogResult
            Dim dlgOpen As New OpenFileDialog

            dlgOpen.InitialDirectory = Application.StartupPath

            dlgOpen.Filter = "Database files (*.mdf)|*.mdf|All Files (*.*)|*.*"
            rslt = dlgOpen.ShowDialog

            If rslt = Windows.Forms.DialogResult.OK Then
                Dim connectionBuilder As New SqlConnectionStringBuilder
                connectionBuilder.DataSource = ".\SQLExpress"

                connectionBuilder.AttachDBFilename = dlgOpen.FileName

                connectionBuilder.IntegratedSecurity = True
                connectionNorthwind.ConnectionString = connectionBuilder.ConnectionString
            Else
                Me.Close() ' closes otherwise    
            End If
        Catch ex As Exception ' catches exceptions
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    '-----------------------------------------get order------------------------------------------------------

    Private Sub btnGetorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetorder.Click
        Try
            If txtOrdernumber.Text = "" Then 'checks for a blank string 
                MessageBox.Show("Enter your order number.")
            Else
                Dim command As New SqlCommand

                Dim str As String

                command.CommandType = CommandType.Text

                str = "SELECT Quantity, OD.UnitPrice, ProductName,"
                If chkBoxDiscount.Checked = True Then 'checks to see if there is a discount
                    str &= "(OD.UnitPrice - OD.UnitPrice * Discount)" _
                    & " * Quantity AS Total"

                Else
                    str &= "OD.UnitPrice * Quantity AS Total" 'sets the string value 

                End If

                str &= " FROM " & _
                "[Order Details] AS OD, Products WHERE OD.ProductID = " & _
                "Products.ProductID AND OD.OrderID = @OrderNumber" 'sets the value for the string
                command.CommandText = str

                command.Connection = connectionNorthwind

                command.Parameters.AddWithValue("@OrderNumber", txtOrdernumber.Text)
                connectionNorthwind.Open()

                lstDisplaybox.Items.Clear() ' clears the display box

                lstDisplaybox.Items.Add("Product" & "Unit Price".PadLeft(50) _
                & "Quantity".PadLeft(15) & "Total".PadLeft(15)) 'adds and sets padding

                lstDisplaybox.Items.Add(StrDup(110, "-"))
                Dim rdr As SqlDataReader = command.ExecuteReader

                Dim intCounter As Integer

                Dim st As String

                Do While rdr.Read 'while it is reading 
                    st = rdr.GetString(rdr.GetOrdinal("ProductName")).PadRight(35) 'sets while reading 

                    st &= FormatCurrency(rdr.GetDecimal(rdr.GetOrdinal("UnitPrice"))).PadRight(20)

                    st &= FormatNumber((rdr.GetInt16(rdr.GetOrdinal("Quantity"))), 0).PadRight(15)

                    st &= FormatCurrency(rdr.GetValue(rdr.GetOrdinal("Total")))
                    lstDisplaybox.Items.Add(st)
                    intCounter = intCounter + 1
                Loop
                rdr.Close()
                If intCounter = 0 Then 'when there are no entries at all
                    lstDisplaybox.Items.Clear()
                    lstDisplaybox.Items.Add("No order number: " & txtOrdernumber.Text)
                Else
                    If chkBoxDiscount.Checked Then
                        str = "SELECT SUM((UnitPrice - UnitPrice * Discount) * Quantity)" _
                        & " AS FullTotal FROM [Order Details] WHERE OrderID = @OrderNumber"
                    Else
                        str = "SELECT SUM(UnitPrice * Quantity) AS FullTotal" _
                        & " FROM [Order Details] WHERE OrderID = @OrderNumber"
                    End If
                    command.CommandText = str
                    lstDisplaybox.Items.Add(StrDup(110, "-"))
                    lstDisplaybox.Items.Add(FormatCurrency(CDec(command.ExecuteScalar)).PadLeft(100)) 'creates total price for all items
                End If
            End If

        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connectionNorthwind.Close()
            txtOrderDate.Text = ""
            txtCustomerID.Text = ""
        End Try
    End Sub
    '-----------------------------------------------------buttonCustomerClick------------------------------------------
    Private Sub btnByCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnByCustomer.Click
        Try
            If txtCustomerID.Text = "" Then 'checks for a blank string
                MessageBox.Show("Enter your 5-character Customer ID")

            Else
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT OrderID, OrderDate, CompanyName FROM Orders," & _
                        "Customers WHERE Orders.CustomerID = Customers.CustomerID " _
                        & "AND Customers.CustomerID = @Customer"
                cmd.Connection = connectionNorthwind

                cmd.Parameters.AddWithValue("@Customer", txtCustomerID.Text)
                connectionNorthwind.Open()

                lstDisplayBox.Items.Clear() ' clears the display box 

                lstDisplayBox.Items.Add("Order Number" & Space(15) &
                        "Order Date" & Space(15) & "Company Name")

                lstDisplayBox.Items.Add(StrDup(90, "-"))

                Dim intCount As Integer

                Dim rdr As SqlDataReader = cmd.ExecuteReader

                Do While rdr.Read
                    Dim str As String
                    str = rdr("OrderID").ToString.PadLeft(15) & Space(20)
                    str &= FormatDateTime(CDate((rdr("OrderDate"))), _
                            DateFormat.ShortDate) & Space(20)

                    str &= rdr("CompanyName").ToString
                    lstDisplayBox.Items.Add(str)
                    intCount = intCount + 1
                Loop
                rdr.Close()

                If intCount = 0 Then 'when entries are blank
                    lstDisplayBox.Items.Clear()
                    lstDisplayBox.Items.Add("No Orders For This Customer: " & txtCustomerID.Text)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            connectionNorthwind.Close() ' close the connection 
            txtOrderDate.Text = ""
            txtOrdernumber.Text = ""
        End Try
    End Sub

    Private Sub btnByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnByDate.Click
        Try
            If txtOrderDate.Text = "" Then 'check for empty string
                MessageBox.Show("Please enter an order date (mm/dd/yy).")

            Else
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.Text

                cmd.CommandText = "SELECT OrderID, OrderDate, CompanyName, " _
                        & "Customers.CustomerID" & " FROM Orders, " & _
                        "Customers WHERE Orders.CustomerID = Customers.CustomerID " _
                        & "AND OrderDate = @Date"

                cmd.Connection = connectionNorthwind

                cmd.Parameters.AddWithValue("@Date", txtOrderDate.Text)
                connectionNorthwind.Open() ' opens the connection 

                lstDisplaybox.Items.Clear() ' clears the display box 
                lstDisplayBox.Items.Add("Order Number" & _
                        "Company Name".PadLeft(15) & "ID".PadLeft(15))
                lstDisplaybox.Items.Add(StrDup(80, "-")) ' adds and sets padding 

                Dim intCount As Integer ' counter 
                Dim rdr As SqlDataReader = cmd.ExecuteReader ' reader
                Do While rdr.Read ' loops while reading 

                    Dim str As String
                    str = rdr("OrderID").ToString.PadLeft(5) 'sets str and padding
                    str = str & rdr("CompanyName").ToString.PadLeft(35)
                    str = str & rdr("CustomerID").ToString.PadLeft(10)
                    lstDisplayBox.Items.Add(str)
                    intCount = intCount + 1
                Loop
                rdr.Close() ' closes the connection 

                If intCount = 0 Then 'when there are no entries

                    lstDisplayBox.Items.Clear() ' clears the list box 
                    lstDisplayBox.Items.Add("No orders for this exact date: " & txtOrderDate.Text)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lstDisplaybox.Items.Clear() 'clears the display box 

        Finally
            connectionNorthwind.Close() 'closes the connection 
            txtOrdernumber.Text = "" 'sets the text to blank 
            txtCustomerID.Text = "" 's
        End Try
    End Sub

    Private Sub txtOrderDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrderDate.KeyPress
        Select Case e.KeyChar ' only allows valid entries to be entered 
            Case "0"c To "9"c
            Case "/"c
            Case ControlChars.Back
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub txtOrdernumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrdernumber.KeyPress
        Select Case e.KeyChar ' only allows numbers for entries 
            Case "0"c To "9"c
            Case ControlChars.Back
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub chkBoxDiscount_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxDiscount.CheckedChanged
        Debug.WriteLine("ConString = " & connectionNorthwind.ConnectionString) 'checks if discount is checked 
        btnGetorder_Click(sender, e)
    End Sub
End Class
