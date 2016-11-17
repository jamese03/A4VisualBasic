<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtOrdernumber = New System.Windows.Forms.TextBox()
        Me.lblTypeOrderNumber = New System.Windows.Forms.Label()
        Me.btnGetorder = New System.Windows.Forms.Button()
        Me.chkBoxDiscount = New System.Windows.Forms.CheckBox()
        Me.lstDisplayBox = New System.Windows.Forms.ListBox()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.btnByCustomer = New System.Windows.Forms.Button()
        Me.btnByDate = New System.Windows.Forms.Button()
        Me.txtOrderDate = New System.Windows.Forms.TextBox()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.lblCustomerID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtOrdernumber
        '
        Me.txtOrdernumber.Location = New System.Drawing.Point(114, 70)
        Me.txtOrdernumber.Name = "txtOrdernumber"
        Me.txtOrdernumber.Size = New System.Drawing.Size(100, 20)
        Me.txtOrdernumber.TabIndex = 0
        '
        'lblTypeOrderNumber
        '
        Me.lblTypeOrderNumber.AutoSize = True
        Me.lblTypeOrderNumber.Location = New System.Drawing.Point(72, 41)
        Me.lblTypeOrderNumber.Name = "lblTypeOrderNumber"
        Me.lblTypeOrderNumber.Size = New System.Drawing.Size(100, 13)
        Me.lblTypeOrderNumber.TabIndex = 1
        Me.lblTypeOrderNumber.Text = "Type Order Number"
        '
        'btnGetorder
        '
        Me.btnGetorder.Location = New System.Drawing.Point(33, 67)
        Me.btnGetorder.Name = "btnGetorder"
        Me.btnGetorder.Size = New System.Drawing.Size(75, 23)
        Me.btnGetorder.TabIndex = 2
        Me.btnGetorder.Text = "Get Order"
        Me.btnGetorder.UseVisualStyleBackColor = True
        '
        'chkBoxDiscount
        '
        Me.chkBoxDiscount.AutoSize = True
        Me.chkBoxDiscount.Location = New System.Drawing.Point(91, 171)
        Me.chkBoxDiscount.Name = "chkBoxDiscount"
        Me.chkBoxDiscount.Size = New System.Drawing.Size(68, 17)
        Me.chkBoxDiscount.TabIndex = 3
        Me.chkBoxDiscount.Text = "Discount"
        Me.chkBoxDiscount.UseVisualStyleBackColor = True
        '
        'lstDisplayBox
        '
        Me.lstDisplayBox.FormattingEnabled = True
        Me.lstDisplayBox.Location = New System.Drawing.Point(60, 249)
        Me.lstDisplayBox.Name = "lstDisplayBox"
        Me.lstDisplayBox.Size = New System.Drawing.Size(506, 160)
        Me.lstDisplayBox.TabIndex = 4
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Location = New System.Drawing.Point(401, 197)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(100, 20)
        Me.txtCustomerID.TabIndex = 5
        '
        'btnByCustomer
        '
        Me.btnByCustomer.Location = New System.Drawing.Point(303, 195)
        Me.btnByCustomer.Name = "btnByCustomer"
        Me.btnByCustomer.Size = New System.Drawing.Size(75, 23)
        Me.btnByCustomer.TabIndex = 6
        Me.btnByCustomer.Text = "By Customer"
        Me.btnByCustomer.UseVisualStyleBackColor = True
        '
        'btnByDate
        '
        Me.btnByDate.Location = New System.Drawing.Point(320, 70)
        Me.btnByDate.Name = "btnByDate"
        Me.btnByDate.Size = New System.Drawing.Size(75, 23)
        Me.btnByDate.TabIndex = 7
        Me.btnByDate.Text = "By Date"
        Me.btnByDate.UseVisualStyleBackColor = True
        '
        'txtOrderDate
        '
        Me.txtOrderDate.Location = New System.Drawing.Point(401, 73)
        Me.txtOrderDate.Name = "txtOrderDate"
        Me.txtOrderDate.Size = New System.Drawing.Size(100, 20)
        Me.txtOrderDate.TabIndex = 8
        '
        'lblOrderDate
        '
        Me.lblOrderDate.AutoSize = True
        Me.lblOrderDate.Location = New System.Drawing.Point(347, 40)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(144, 13)
        Me.lblOrderDate.TabIndex = 9
        Me.lblOrderDate.Text = "Type In Order Date (1/1/98):"
        '
        'lblCustomerID
        '
        Me.lblCustomerID.AutoSize = True
        Me.lblCustomerID.Location = New System.Drawing.Point(338, 158)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(165, 13)
        Me.lblCustomerID.TabIndex = 10
        Me.lblCustomerID.Text = "Type In 5 Character Customer ID "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 439)
        Me.Controls.Add(Me.lblCustomerID)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Controls.Add(Me.txtOrderDate)
        Me.Controls.Add(Me.btnByDate)
        Me.Controls.Add(Me.btnByCustomer)
        Me.Controls.Add(Me.txtCustomerID)
        Me.Controls.Add(Me.lstDisplayBox)
        Me.Controls.Add(Me.chkBoxDiscount)
        Me.Controls.Add(Me.btnGetorder)
        Me.Controls.Add(Me.lblTypeOrderNumber)
        Me.Controls.Add(Me.txtOrdernumber)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOrdernumber As System.Windows.Forms.TextBox
    Friend WithEvents lblTypeOrderNumber As System.Windows.Forms.Label
    Friend WithEvents btnGetorder As System.Windows.Forms.Button
    Friend WithEvents chkBoxDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents lstDisplayBox As System.Windows.Forms.ListBox
    Friend WithEvents txtCustomerID As System.Windows.Forms.TextBox
    Friend WithEvents btnByCustomer As System.Windows.Forms.Button
    Friend WithEvents btnByDate As System.Windows.Forms.Button
    Friend WithEvents txtOrderDate As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label

End Class
