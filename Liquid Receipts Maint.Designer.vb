﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LiquidReceiptsMaint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LiquidReceiptsMaint))
        Me.RcptDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.t = New System.Windows.Forms.Label()
        Me.RcptDateTo = New System.Windows.Forms.DateTimePicker()
        Me.strc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FreezeToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnfreezeStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyWHeaderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyNoHeaderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteCellStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteMultipleStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadData = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbTest = New System.Windows.Forms.RadioButton()
        Me.rbProduction = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbSettle = New System.Windows.Forms.RadioButton()
        Me.rbReceive = New System.Windows.Forms.RadioButton()
        Me.CalcColumns = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CboRun = New System.Windows.Forms.ComboBox()
        Me.LblRun = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Item = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Supplier = New System.Windows.Forms.ComboBox()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'RcptDateFrom
        '
        Me.RcptDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.RcptDateFrom.Location = New System.Drawing.Point(68, 25)
        Me.RcptDateFrom.Name = "RcptDateFrom"
        Me.RcptDateFrom.Size = New System.Drawing.Size(99, 20)
        Me.RcptDateFrom.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Rcpt from"
        '
        't
        '
        Me.t.AutoSize = True
        Me.t.Location = New System.Drawing.Point(190, 26)
        Me.t.Name = "t"
        Me.t.Size = New System.Drawing.Size(20, 13)
        Me.t.TabIndex = 3
        Me.t.Text = "To"
        '
        'RcptDateTo
        '
        Me.RcptDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.RcptDateTo.Location = New System.Drawing.Point(216, 25)
        Me.RcptDateTo.Name = "RcptDateTo"
        Me.RcptDateTo.Size = New System.Drawing.Size(102, 20)
        Me.RcptDateTo.TabIndex = 2
        '
        'strc
        '
        Me.strc.FormattingEnabled = True
        Me.strc.Location = New System.Drawing.Point(388, 22)
        Me.strc.Name = "strc"
        Me.strc.Size = New System.Drawing.Size(56, 21)
        Me.strc.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(324, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Stockroom"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToOrderColumns = True
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Grid.Location = New System.Drawing.Point(15, 110)
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersWidth = 62
        Me.Grid.Size = New System.Drawing.Size(917, 379)
        Me.Grid.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FreezeToolStripMenu, Me.UnfreezeStripMenu, Me.ToolStripSeparator1, Me.CopyWHeaderToolStripMenuItem, Me.CopyNoHeaderToolStripMenuItem, Me.PasteCellStripMenu, Me.PasteMultipleStripMenu})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(163, 142)
        '
        'FreezeToolStripMenu
        '
        Me.FreezeToolStripMenu.Name = "FreezeToolStripMenu"
        Me.FreezeToolStripMenu.Size = New System.Drawing.Size(162, 22)
        Me.FreezeToolStripMenu.Text = "Freeze"
        '
        'UnfreezeStripMenu
        '
        Me.UnfreezeStripMenu.Name = "UnfreezeStripMenu"
        Me.UnfreezeStripMenu.Size = New System.Drawing.Size(162, 22)
        Me.UnfreezeStripMenu.Text = "Unfreeze"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'CopyWHeaderToolStripMenuItem
        '
        Me.CopyWHeaderToolStripMenuItem.Name = "CopyWHeaderToolStripMenuItem"
        Me.CopyWHeaderToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CopyWHeaderToolStripMenuItem.Text = "Copy w/Header"
        '
        'CopyNoHeaderToolStripMenuItem
        '
        Me.CopyNoHeaderToolStripMenuItem.Name = "CopyNoHeaderToolStripMenuItem"
        Me.CopyNoHeaderToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CopyNoHeaderToolStripMenuItem.Text = "Copy No Header"
        '
        'PasteCellStripMenu
        '
        Me.PasteCellStripMenu.Name = "PasteCellStripMenu"
        Me.PasteCellStripMenu.Size = New System.Drawing.Size(162, 22)
        Me.PasteCellStripMenu.Text = "Paste Cell"
        '
        'PasteMultipleStripMenu
        '
        Me.PasteMultipleStripMenu.Name = "PasteMultipleStripMenu"
        Me.PasteMultipleStripMenu.Size = New System.Drawing.Size(162, 22)
        Me.PasteMultipleStripMenu.Text = "Paste Multiple"
        '
        'LoadData
        '
        Me.LoadData.Location = New System.Drawing.Point(493, 18)
        Me.LoadData.Name = "LoadData"
        Me.LoadData.Size = New System.Drawing.Size(84, 27)
        Me.LoadData.TabIndex = 7
        Me.LoadData.Text = "Load Data"
        Me.LoadData.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbTest)
        Me.Panel1.Controls.Add(Me.rbProduction)
        Me.Panel1.Location = New System.Drawing.Point(896, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 43)
        Me.Panel1.TabIndex = 8
        '
        'rbTest
        '
        Me.rbTest.AutoSize = True
        Me.rbTest.Location = New System.Drawing.Point(3, 23)
        Me.rbTest.Name = "rbTest"
        Me.rbTest.Size = New System.Drawing.Size(46, 17)
        Me.rbTest.TabIndex = 1
        Me.rbTest.TabStop = True
        Me.rbTest.Text = "Test"
        Me.rbTest.UseVisualStyleBackColor = True
        '
        'rbProduction
        '
        Me.rbProduction.AutoSize = True
        Me.rbProduction.Location = New System.Drawing.Point(3, 3)
        Me.rbProduction.Name = "rbProduction"
        Me.rbProduction.Size = New System.Drawing.Size(76, 17)
        Me.rbProduction.TabIndex = 0
        Me.rbProduction.TabStop = True
        Me.rbProduction.Text = "Production"
        Me.rbProduction.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.rbSettle)
        Me.Panel2.Controls.Add(Me.rbReceive)
        Me.Panel2.Location = New System.Drawing.Point(803, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(87, 43)
        Me.Panel2.TabIndex = 9
        '
        'rbSettle
        '
        Me.rbSettle.AutoSize = True
        Me.rbSettle.Location = New System.Drawing.Point(3, 23)
        Me.rbSettle.Name = "rbSettle"
        Me.rbSettle.Size = New System.Drawing.Size(52, 17)
        Me.rbSettle.TabIndex = 1
        Me.rbSettle.TabStop = True
        Me.rbSettle.Text = "Settle"
        Me.rbSettle.UseVisualStyleBackColor = True
        '
        'rbReceive
        '
        Me.rbReceive.AutoSize = True
        Me.rbReceive.Location = New System.Drawing.Point(3, 3)
        Me.rbReceive.Name = "rbReceive"
        Me.rbReceive.Size = New System.Drawing.Size(65, 17)
        Me.rbReceive.TabIndex = 0
        Me.rbReceive.TabStop = True
        Me.rbReceive.Text = "Receive"
        Me.rbReceive.UseVisualStyleBackColor = True
        '
        'CalcColumns
        '
        Me.CalcColumns.Location = New System.Drawing.Point(658, 9)
        Me.CalcColumns.Name = "CalcColumns"
        Me.CalcColumns.Size = New System.Drawing.Size(82, 46)
        Me.CalcColumns.TabIndex = 15
        Me.CalcColumns.Text = "Calc Columns"
        Me.CalcColumns.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CboRun)
        Me.Panel3.Controls.Add(Me.LblRun)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Item)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Supplier)
        Me.Panel3.Location = New System.Drawing.Point(11, 55)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(964, 50)
        Me.Panel3.TabIndex = 18
        '
        'CboRun
        '
        Me.CboRun.FormattingEnabled = True
        Me.CboRun.Location = New System.Drawing.Point(755, 14)
        Me.CboRun.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CboRun.Name = "CboRun"
        Me.CboRun.Size = New System.Drawing.Size(58, 21)
        Me.CboRun.TabIndex = 24
        Me.CboRun.Visible = False
        '
        'LblRun
        '
        Me.LblRun.AutoSize = True
        Me.LblRun.Location = New System.Drawing.Point(725, 18)
        Me.LblRun.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblRun.Name = "LblRun"
        Me.LblRun.Size = New System.Drawing.Size(27, 13)
        Me.LblRun.TabIndex = 23
        Me.LblRun.Text = "Run"
        Me.LblRun.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(455, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Item"
        '
        'Item
        '
        Me.Item.FormattingEnabled = True
        Me.Item.Location = New System.Drawing.Point(488, 14)
        Me.Item.Name = "Item"
        Me.Item.Size = New System.Drawing.Size(219, 21)
        Me.Item.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(201, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Supplier"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(123, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Filtering:"
        '
        'Supplier
        '
        Me.Supplier.FormattingEnabled = True
        Me.Supplier.Location = New System.Drawing.Point(253, 14)
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Size = New System.Drawing.Size(186, 21)
        Me.Supplier.TabIndex = 18
        '
        'LiquidReceiptsMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 501)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.CalcColumns)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LoadData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.strc)
        Me.Controls.Add(Me.t)
        Me.Controls.Add(Me.RcptDateTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RcptDateFrom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LiquidReceiptsMaint"
        Me.Text = "Liquid Receipts Maint"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RcptDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents t As System.Windows.Forms.Label
    Friend WithEvents RcptDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents strc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LoadData As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbTest As System.Windows.Forms.RadioButton
    Friend WithEvents rbProduction As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbSettle As System.Windows.Forms.RadioButton
    Friend WithEvents rbReceive As System.Windows.Forms.RadioButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FreezeToolStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteCellStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteMultipleStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnfreezeStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyWHeaderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyNoHeaderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalcColumns As System.Windows.Forms.Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CboRun As ComboBox
    Friend WithEvents LblRun As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Item As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Supplier As ComboBox
    Friend WithEvents Grid As DataGridView
End Class
