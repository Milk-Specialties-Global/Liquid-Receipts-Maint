﻿Public Class LiquidReceiptsMaint
    Private LWconnectString As String = ""

    ' Two different presentations for maintenance, but with the same selection criteria
    ReadOnly srcpt As String = "select RecNo, Strc, RecTime, RecDte, SampNo, PDesc as ItemDesc, PNum as ItemNo, OrdNo, SupName, LoadNo, BolNo " &
                        ", TruckWgt, LotNo, FreightCost, Carrier from msgreceipts " &
                        "where recdte between @datefrom and @dateto and strc = @strc"
    ' 07.27.20 5 new fields at the end (2 calc'd, 3 manual entry) KH
    ReadOnly ssett As String = "select RecNo, SupName, PDesc as ItemDesc, LoadNo, m.SampNo, OrdNo, RecDte, BolNo " &
                        ", TruckWgt" &
                        ", lwsol as LabSol, SupSol, SettSol, [3pSol]" &
                        ", SupSolWgt, SettSolWgt" &
                        ", labworks.dbo.lwrslt(ras.result) as LabProtAsIs, SupProtAsIs, SettProtAsIs" &
                        ", labworks.dbo.lwrslt(rdb.result) as LabProtDB, SupProtDB, SettProtDB" &
                        ", SettPrice, SettValue" &
                        ", ButterfatPct as [Butterfat%], FatLbs as ButterfatLbs, RunWO_No, RunWO_Lot, WO_Prodname" &
                        " from msgreceipts m" &
                        " left outer join result ras on ras.sampno=m.sampno and ras.acode='PROT_ASIS_LECO' and ras.resultpart='mean_avg'" &
                        " left outer join result rdb on rdb.sampno=m.sampno and rdb.acode='PROT_DB_LECO_LIQUID' and rdb.resultpart='mean_avg'" &
                        " where recdte between @datefrom and @dateto and strc = @strc"
    'added new codes for ML
    '07.27.20 5 new fields at the end (2 calc'd, 3 manual entry) KH
    ReadOnly ssettml As String = "select RecNo, SupName, PDesc as ItemDesc, LoadNo, m.SampNo, OrdNo, RecDte, BolNo " &
                        ", TruckWgt" &
                        ", lwsol as LabSol, SupSol, SettSol, [3pSol]" &
                        ", SupSolWgt, SettSolWgt" &
                        ", labworks.dbo.lwrslt(ras.result) as LabProtAsIs, SupProtAsIs, SettProtAsIs" &
                        ", labworks.dbo.lwrslt(rdb.result) as LabProtDB, SupProtDB, SettProtDB" &
                        ", SettPrice, SettValue" &
                        ", ButterfatPct as [Butterfat%], FatLbs as ButterfatLbs, RunWO_No, RunWO_Lot, WO_Prodname" &
                        " from msgreceipts m" &
                        " left outer join result ras on ras.sampno=m.sampno And ras.acode='PROT_ASIS_kjeldahl' and ras.resultpart='mean_avg'" &
                        " left outer join result rdb on rdb.sampno=m.sampno and rdb.acode='PROT_DB_kjeldahl' and rdb.resultpart='mean_avg'" &
                        " where recdte between @datefrom and @dateto and strc = @strc"
    Private ReadOnly tbRcpt As New DataTable
    Private ReadOnly tbSett As New DataTable

    ' Internals
    Public Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is 
          Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function
    Function EscChar(p1 As String) As String
        ' Escape special characters in a string for filtering
        Dim escStr As String = ""
        For Each c As Char In p1
            Select Case c
                Case "'"
                    escStr &= "''"
                Case Else
                    escStr &= c
            End Select
        Next
        Return escStr
    End Function
    Sub Unfreeze()
        For Each cc As DataGridViewColumn In Grid.Columns
            cc.Frozen = False
        Next
    End Sub
    Sub SetConnString()
        If rbProduction.Checked Then
            LWconnectString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=labworks;Server=MILK8"
        Else
            LWconnectString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=labworks_test;Server=MILK8"
        End If
    End Sub
    Sub LoadStrc()
        If LWconnectString = "" Then
            MsgBox("Must choose either Production or Test", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim ssql As String = "select distinct strc from msgreceipts where recdte between @datefrom and @dateto order by strc"
        strc.Items.Clear()
        Using lwconn As New SqlClient.SqlConnection(LWconnectString)
            Using cmd As New SqlClient.SqlCommand(ssql, lwconn)
                cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = RcptDateFrom.Value.Date
                cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = RcptDateTo.Value.Date
                lwconn.Open()
                Using dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read()
                        strc.Items.Add(dr("strc"))
                    Loop
                End Using
                lwconn.Close()
            End Using
        End Using
        If strc.Items.Count = 1 Then
            strc.Text = ""
            strc.SelectedText = strc.Items(0)
        End If
    End Sub
    Sub LoadFilter()
        Dim ii As Integer

        Supplier.Items.Clear()
        Supplier.Items.Add("") ' "no filter" is always an option
        Dim suppliers = From row In If(rbSettle.Checked, tbSett, tbRcpt).AsEnumerable Select row.Field(Of String)("SupName") Distinct
        Dim ss = From s In suppliers Order By s Select s

        For ii = 0 To ss.Count - 1
            Supplier.Items.Add(ss(ii))
        Next ii
        Supplier.Text = ""

        Item.Items.Clear()
        Item.Items.Add("") ' "no filter" is always an option
        Dim Items = From row In If(rbSettle.Checked, tbSett, tbRcpt).AsEnumerable Select row.Field(Of String)("ItemDesc") Distinct
        Dim si = From s In Items Order By s Select s

        For ii = 0 To si.Count - 1
            Item.Items.Add(si(ii))
        Next ii
        Item.Text = ""

    End Sub
    Sub SetFilter()
        If Supplier.Text = "" Then
            If rbSettle.Checked Then tbSett.DefaultView.RowFilter = ""
            If Not rbSettle.Checked Then tbRcpt.DefaultView.RowFilter = ""
        Else
            If rbSettle.Checked Then tbSett.DefaultView.RowFilter = "SupName = '" & EscChar(Supplier.Text) & "'"
            If Not rbSettle.Checked Then tbRcpt.DefaultView.RowFilter = "SupName = '" & EscChar(Supplier.Text) & "'"
        End If

        If Item.Text <> "" Then
            If rbSettle.Checked Then tbSett.DefaultView.RowFilter = tbSett.DefaultView.RowFilter &
               If(tbSett.DefaultView.RowFilter = "", "", " AND ") & "ItemDesc = '" & EscChar(Item.Text) & "'"
            If Not rbSettle.Checked Then tbRcpt.DefaultView.RowFilter = tbRcpt.DefaultView.RowFilter &
               If(tbRcpt.DefaultView.RowFilter = "", "", " AND ") & "ItemDesc = '" & EscChar(Item.Text) & "'"
        End If
    End Sub

    'Query database, and load Grid
    Sub LoadRcpts()
        ' or settling as the case may be...
        SetConnString()
        If LWconnectString = "" Then Exit Sub

        Grid.DataSource = Nothing

        Dim idx As Integer

        Me.Cursor = Cursors.WaitCursor
        If rbSettle.Checked Then
            tbSett.Clear()
        Else
            tbRcpt.Clear()
        End If
        Using lwconn As New SqlClient.SqlConnection(LWconnectString)

            '  Using cmd As New SqlClient.SqlCommand(If(rbSettle.Checked, ssett, srcpt), lwconn)
            '  cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = RcptDateFrom.Value.Date
            '  cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = RcptDateTo.Value.Date
            '     cmd.Parameters.Add("@strc", SqlDbType.VarChar, 15).Value = strc.Text
            ' Using da As New SqlClient.SqlDataAdapter(cmd)
            ' Try
            ' da.Fill(If(rbSettle.Checked, tbSett, tbRcpt))
            '        Catch ex As Exception
            ' MsgBox(ex.Message)
            'End Try
            'End Using
            If strc.Text = "ML" Then
                Using cmd As New SqlClient.SqlCommand(If(rbSettle.Checked, ssettml, srcpt), lwconn)
                    cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = RcptDateFrom.Value.Date
                    cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = RcptDateTo.Value.Date
                    cmd.Parameters.Add("@strc", SqlDbType.VarChar, 15).Value = strc.Text
                    Using da As New SqlClient.SqlDataAdapter(cmd)
                        Try
                            da.Fill(If(rbSettle.Checked, tbSett, tbRcpt))
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End Using
            Else
                Using cmd As New SqlClient.SqlCommand(If(rbSettle.Checked, ssett, srcpt), lwconn)
                    cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = RcptDateFrom.Value.Date
                    cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = RcptDateTo.Value.Date
                    cmd.Parameters.Add("@strc", SqlDbType.VarChar, 15).Value = strc.Text
                    Using da As New SqlClient.SqlDataAdapter(cmd)
                        Try
                            da.Fill(If(rbSettle.Checked, tbSett, tbRcpt))
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End Using
            End If


        End Using



        LoadFilter()

        Grid.DataSource = If(rbSettle.Checked, tbSett, tbRcpt)

        ' Set editable (yellow) colums based on settling/receiving
        For idx = 0 To Grid.Columns.Count - 1
            Grid.Columns(idx).ReadOnly = True
        Next idx

        If rbSettle.Checked Then
            Grid.Columns("bolno").ReadOnly = False
            Grid.Columns("truckwgt").ReadOnly = False
            Grid.Columns("3pSol").ReadOnly = False
            Grid.Columns("SupSol").ReadOnly = False
            Grid.Columns("SettSol").ReadOnly = False
            Grid.Columns("SupProtAsIs").ReadOnly = False
            Grid.Columns("SettProtAsIs").ReadOnly = False
            Grid.Columns("SupProtDB").ReadOnly = False
            Grid.Columns("SettProtDB").ReadOnly = False
            Grid.Columns("SupSolWgt").ReadOnly = False
            Grid.Columns("SettSolWgt").ReadOnly = False
            Grid.Columns("SettPrice").ReadOnly = False
            Grid.Columns("SettValue").ReadOnly = False

            '07.27.20 format 3 new columns as readonly = false KH
            Grid.Columns("RunWO_No").ReadOnly = False
            Grid.Columns("RunWO_Lot").ReadOnly = False
            Grid.Columns("WO_Prodname").ReadOnly = False

            Grid.Columns("recno").Visible = False

            Grid.Columns("bolno").DefaultCellStyle.BackColor = Color.Yellow
            Grid.Columns("truckwgt").DefaultCellStyle.BackColor = Color.Yellow
            Grid.Columns("3pSol").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("SupSol").DefaultCellStyle.BackColor = Color.Linen
            Grid.Columns("SettSol").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("SupProtAsIs").DefaultCellStyle.BackColor = Color.Linen
            Grid.Columns("SettProtAsIs").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("SupProtDB").DefaultCellStyle.BackColor = Color.Linen
            Grid.Columns("SettProtDB").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("SupSolWgt").DefaultCellStyle.BackColor = Color.Linen
            Grid.Columns("SettSolWgt").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("SettPrice").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("SettValue").DefaultCellStyle.BackColor = Color.LightSteelBlue

            '07.27.20 format 3 new columns as backcolor = lightsteelblue KH
            Grid.Columns("RunWO_No").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("RunWO_Lot").DefaultCellStyle.BackColor = Color.LightSteelBlue
            Grid.Columns("WO_Prodname").DefaultCellStyle.BackColor = Color.LightSteelBlue

        Else
            Grid.Columns("loadno").ReadOnly = False
            Grid.Columns("bolno").ReadOnly = False
            Grid.Columns("lotno").ReadOnly = False
            Grid.Columns("truckwgt").ReadOnly = False
            Grid.Columns("FreightCost").ReadOnly = False

            Grid.Columns("recno").Visible = False
            Grid.Columns("loadno").DefaultCellStyle.BackColor = Color.Yellow
            Grid.Columns("bolno").DefaultCellStyle.BackColor = Color.Yellow
            Grid.Columns("lotno").DefaultCellStyle.BackColor = Color.Yellow
            Grid.Columns("truckwgt").DefaultCellStyle.BackColor = Color.Yellow
            Grid.Columns("FreightCost").DefaultCellStyle.BackColor = Color.Yellow
        End If

        Grid.AutoResizeColumns()

        '07.28.20 - new block to persist user column sort/sortdirection settings
        If rbSettle.Checked Then
            Grid.Sort(Grid.Columns(My.Settings.SettSortCol), My.Settings.SettSortDirection)
        Else
            Grid.Sort(Grid.Columns(My.Settings.RcptSortCol), My.Settings.RcptSortDirection)
        End If
        '07.28.20 end block

        Me.Cursor = Cursors.Arrow
    End Sub

    'User Interface
    Private Sub Form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        rbProduction.Checked = My.Settings.Production
        rbSettle.Checked = My.Settings.Mode

        rbTest.Checked = Not rbProduction.Checked
        rbReceive.Checked = Not rbSettle.Checked

        LoadStrc()
    End Sub
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) _
     Handles MyBase.FormClosing
        '07.28.20 new sub. handles user setting sorting info.
        If rbSettle.Checked Then
            My.Settings.SettSortCol = Grid.SortedColumn.Index
            If Grid.SortOrder = 1 Then
                My.Settings.SettSortDirection = 0
            Else
                My.Settings.SettSortDirection = 1
            End If
        Else
            My.Settings.RcptSortCol = Grid.SortedColumn.Index
            If Grid.SortOrder = 1 Then
                My.Settings.RcptSortDirection = 0
            Else
                My.Settings.RcptSortDirection = 1
            End If
        End If

    End Sub
    Private Sub strc_enter(sender As Object, e As System.EventArgs) Handles strc.Enter
        LoadStrc()
    End Sub
    Private Sub strc_TextChanged(sender As Object, e As System.EventArgs) Handles strc.TextChanged
        LoadRcpts()
    End Sub
    Private Sub LoadData_Click(sender As System.Object, e As System.EventArgs) Handles LoadData.Click
        LoadRcpts()
    End Sub
    Private Sub Grid_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Grid.DataError
        MsgBox(e.Exception.Message & vbCrLf & vbCrLf & "Repair cell, or Press <Esc> to cancel change", MsgBoxStyle.Exclamation, Me.Name)
    End Sub
    Private Sub rbProduction_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbProduction.CheckedChanged, rbTest.CheckedChanged
        My.Settings.Production = rbProduction.Checked
        My.Settings.Save()
        SetConnString()
    End Sub
    Private Sub rbSettle_CheckedChanged(sender As Object, e As EventArgs) Handles rbSettle.CheckedChanged
        My.Settings.Mode = rbSettle.Checked
        My.Settings.Save()
        LoadRcpts()
    End Sub
    Private Sub RcptDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles RcptDateFrom.ValueChanged
        RcptDateTo.Value = RcptDateFrom.Value
        LoadRcpts()
    End Sub
    Private Sub CalcColumns_Click(sender As Object, e As EventArgs) Handles CalcColumns.Click
        If LWconnectString = "" Then
            MsgBox("Must choose either Production or Test", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Dim procname As String = If(rbProduction.Checked, "labworks.dbo.msgReceiptsCalc", "labworks_test.dbo.msgReceiptsCalc")
        Dim rslt As Object

        Using lwconn As New SqlClient.SqlConnection(LWconnectString)
            Using cmd As New SqlClient.SqlCommand(procname, lwconn)
                Me.Cursor = Cursors.WaitCursor
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                lwconn.Open()
                rslt = cmd.ExecuteScalar
                lwconn.Close()
                Me.Cursor = Cursors.Arrow
            End Using
        End Using

        ' Calculation procedure completed, reload data
        LoadRcpts()

    End Sub
    ' Filter Grid
    Private Sub Supplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Supplier.SelectedIndexChanged, Item.SelectedIndexChanged
        SetFilter()
    End Sub

    ' Update Back-End Database
    Private Sub Grid_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grid.CellBeginEdit
        ' be sure that cell has not been changed by another process
        Dim fldname As String = Grid.Columns(e.ColumnIndex).Name
        Dim ssql As String = "select [" & fldname & "] from msgreceipts where recno = @recno"
        Dim ChkVal As String

        Using lwconn As New SqlClient.SqlConnection(LWconnectString)
            Using cmd As New SqlClient.SqlCommand(ssql, lwconn)
                cmd.Parameters.Add("@recno", SqlDbType.Int).Value = Grid.CurrentRow.Cells("recno").Value
                lwconn.Open()
                ChkVal = cmd.ExecuteScalar().ToString
                lwconn.Close()
            End Using
        End Using

        If Grid.CurrentCell.Value.ToString <> ChkVal Then
            MsgBox("Data in this cell has been changed by another program. Reload first", MsgBoxStyle.Information, "msgReceipts")
            e.Cancel = True
        End If
    End Sub
    Private Sub Grid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellEndEdit
        Updatecell(e.ColumnIndex, e.RowIndex)
    End Sub
    Private Sub Updatecell(pCol As Integer, pRow As Integer)
        ' validation complete, update database
        Dim fldname As String = Grid.Columns(pCol).Name
        Dim ssql As String = "update msgreceipts set [" & fldname & "] = @newdata, lastchgdt = @lastchgdt, lastchgusr = @lastchgusr where recno = @recno"
        Dim dbtype As SqlDbType

        Using lwconn As New SqlClient.SqlConnection(LWconnectString)
            Using cmd As New SqlClient.SqlCommand(ssql, lwconn)
                cmd.Parameters.Add("@recno", SqlDbType.Int).Value = Grid.Rows(pRow).Cells("recno").Value

                dbtype = If(Grid.CurrentCell.ValueType.Name = "TimeSpan", SqlDbType.DateTime, SqlDbType.Char)

                cmd.Parameters.Add("@newdata", dbtype).Value = Grid.CurrentCell.Value.ToString
                cmd.Parameters.Add("@lastchgdt", SqlDbType.DateTime).Value = Now
                cmd.Parameters.Add("@lastchgusr", SqlDbType.VarChar).Value = GetUserName()

                lwconn.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
                End Try
                lwconn.Close()
            End Using
        End Using
    End Sub

    ' Tool Strip
    Private Sub FreezeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FreezeToolStripMenu.Click
        If Grid.CurrentCellAddress.X < 0 Then
            MsgBox("must select a column or cell before freezing", MsgBoxStyle.Information, Me.Text)
        Else
            Grid.Columns(Grid.CurrentCellAddress.X).Frozen = Not Grid.Columns(Grid.CurrentCellAddress.X).Frozen
        End If
    End Sub
    Private Sub UnfreezeStripMenu_Click(sender As Object, e As EventArgs) Handles UnfreezeStripMenu.Click
        Unfreeze()
    End Sub
    Private Sub CopyWHeaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyWHeaderToolStripMenuItem.Click
        Grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Clipboard.SetDataObject(Grid.GetClipboardContent())
    End Sub
    Private Sub CopyNoHeaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyNoHeaderToolStripMenuItem.Click
        Grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Clipboard.SetDataObject(Grid.GetClipboardContent())
    End Sub
    Private Sub PasteCellStripMenu_Click(sender As Object, e As EventArgs) Handles PasteCellStripMenu.Click
        If Grid.CurrentCell.ReadOnly Then Exit Sub
        If Not Clipboard.ContainsText Then Exit Sub
        Grid.CurrentCell.Value = Clipboard.GetText
    End Sub
    Private Sub PasteMultipleStripMenu_Click(sender As Object, e As EventArgs) Handles PasteMultipleStripMenu.Click
        If Grid.CurrentCell.ReadOnly Then Exit Sub
        If Not Clipboard.ContainsText Then Exit Sub
        For Each cc As DataGridViewCell In Grid.SelectedCells
            cc.Value = Clipboard.GetText
        Next
        If MsgBox("Update these cells?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            For Each cc As DataGridViewCell In Grid.SelectedCells
                Updatecell(cc.ColumnIndex, cc.RowIndex)
            Next
        Else
            LoadRcpts()
        End If

    End Sub

    Private Sub strc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles strc.SelectedIndexChanged

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
