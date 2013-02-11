Imports System.Windows.Forms
Imports EstimationTasks.mdlGlobal.strEstimation


Public Class frmEstimation
    Private networks As Collection
    Private lbActive As ListBox
    Private WithEvents mnuEmpty As ContextMenu
    Private WithEvents mnuSingle As ContextMenu
    Private WithEvents mnuMulti As ContextMenu
    Private WithEvents itmLoad As MenuItem
    Private WithEvents itmSLoad As MenuItem
    Private WithEvents itmMLoad As MenuItem
    Private WithEvents itmStatistic As MenuItem
    Private WithEvents itmMStatistic As MenuItem
    Private WithEvents itmRename As MenuItem
    Private WithEvents itmCombain As MenuItem
    Private WithEvents itmDelete As MenuItem
    Private WithEvents itmMDelete As MenuItem
    Private WithEvents itmGraph As MenuItem
    Private WithEvents itmMGraph As MenuItem

    Private Function JoinNetworks(ByRef list As ListBox.ObjectCollection) As clsNetwork
        Dim cnt As Integer
        Dim item As Object
        cnt = list.Count
        JoinNetworks = Nothing
        If cnt > 0 Then
            ' Объединение сетей
            JoinNetworks = New clsNetwork
            For Each item In list
                JoinNetworks.Join(networks(item))
            Next
        End If
    End Function

    Private Function EstimateNetwork(ByRef netSD As clsNetwork, ByRef netSP As clsNetwork, ByRef net As clsNetwork) As strEstimation
        EstimateNetwork = New strEstimation
        If Not netSP Is Nothing Then
            EstimateNetwork.SDComplexity = netSD.Complexity(net)
        End If
        If Not netSP Is Nothing Then
            EstimateNetwork.SPComplexity = netSP.Complexity(net)
        End If
    End Function

    Private Sub frmEstimation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        networks = New Collection
        ' Формирвоание контекстного меню mnuEmpty
        mnuEmpty = New ContextMenu
        itmLoad = New MenuItem
        mnuEmpty.MenuItems.AddRange(New MenuItem() {itmLoad})
        itmLoad.Index = 0 : itmLoad.Text = "Загрузить"
        ' Формирвоание контекстного меню mnuSingle
        mnuSingle = New ContextMenu
        itmSLoad = New MenuItem
        itmStatistic = New MenuItem
        itmGraph = New MenuItem
        itmRename = New MenuItem
        itmDelete = New MenuItem
        mnuSingle.MenuItems.AddRange(New MenuItem() {itmSLoad, itmStatistic, itmGraph, itmRename, itmDelete})
        itmSLoad.Index = 0 : itmSLoad.Text = "Загрузить"
        itmStatistic.Index = 1 : itmStatistic.Text = "Статистика"
        itmGraph.Index = 2 : itmGraph.Text = "Граф"
        itmRename.Index = 3 : itmRename.Text = "Переименовать"
        itmDelete.Index = 4 : itmDelete.Text = "Удалить"
        ' Формирвоание контекстного меню mnuMulti
        mnuMulti = New ContextMenu
        itmMLoad = New MenuItem
        itmMStatistic = New MenuItem
        itmCombain = New MenuItem
        itmMGraph = New MenuItem
        itmMDelete = New MenuItem
        mnuMulti.MenuItems.AddRange(New MenuItem() {itmMLoad, itmMStatistic, itmMGraph, itmCombain, itmMDelete})
        itmMLoad.Index = 0 : itmMLoad.Text = "Загрузить"
        itmMStatistic.Index = 1 : itmMStatistic.Text = "Статистика"
        itmMGraph.Index = 2 : itmMGraph.Text = "Граф"
        itmCombain.Index = 3 : itmCombain.Text = "Объединить"
        itmMDelete.Index = 4 : itmMDelete.Text = "Удалить"
        ' Назначение событий
        AddHandler lbSubjectDomain.MouseDown, AddressOf lbNetwork_MouseDown
        AddHandler lbSolvedProblem.MouseDown, AddressOf lbNetwork_MouseDown
        AddHandler lbUnsolvedProblem.MouseDown, AddressOf lbNetwork_MouseDown
        AddHandler lbUnused.MouseDown, AddressOf lbNetwork_MouseDown
        AddHandler lbSubjectDomain.DragEnter, AddressOf lbNetwork_DragEnter
        AddHandler lbSolvedProblem.DragEnter, AddressOf lbNetwork_DragEnter
        AddHandler lbUnsolvedProblem.DragEnter, AddressOf lbNetwork_DragEnter
        AddHandler lbUnused.DragEnter, AddressOf lbNetwork_DragEnter
        AddHandler lbSubjectDomain.DragDrop, AddressOf lbNetwork_DragDrop
        AddHandler lbSolvedProblem.DragDrop, AddressOf lbNetwork_DragDrop
        AddHandler lbUnsolvedProblem.DragDrop, AddressOf lbNetwork_DragDrop
        AddHandler lbUnused.DragDrop, AddressOf lbNetwork_DragDrop
        AddHandler lbSubjectDomain.KeyPress, AddressOf lbNetwork_KeyPress
        AddHandler lbSolvedProblem.KeyPress, AddressOf lbNetwork_KeyPress
        AddHandler lbUnsolvedProblem.KeyPress, AddressOf lbNetwork_KeyPress
        AddHandler lbUnused.KeyPress, AddressOf lbNetwork_KeyPress
    End Sub

    Private Sub btnEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimate.Click
        Dim netSD As clsNetwork, netSP As clsNetwork, item As Object, est As strEstimation
        netSD = JoinNetworks(lbSubjectDomain.Items)
        If netSD Is Nothing Then
            MsgBox("Не удалось сформировать семантическую сеть предметной области.")
            Exit Sub
        End If
        netSP = JoinNetworks(lbSolvedProblem.Items)
        If lbUnsolvedProblem.Items.Count > 0 Then
            dgvUnsolvedProblems.Rows.Clear()
            For Each item In lbUnsolvedProblem.Items
                Dim dgvRow As New DataGridViewRow
                Dim dgvCell As DataGridViewCell
                est = EstimateNetwork(netSD, netSP, networks(item))
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = item
                dgvRow.Cells.Add(dgvCell)
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = est.Difficulty
                dgvRow.Cells.Add(dgvCell)
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = est.SDComplexity
                dgvRow.Cells.Add(dgvCell)
                dgvUnsolvedProblems.Rows.Add(dgvRow)
            Next
        Else
            MsgBox("Отсутсвуют задачи для оценки.")
        End If
    End Sub

    Private Sub lbNetwork_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim cnt As Integer
        lbActive = sender
        cnt = lbActive.SelectedItems.Count
        Select Case e.Button
            Case MouseButtons.Left
                If cnt = 1 Then
                    sender.DoDragDrop(sender.Items(sender.SelectedIndex).ToString, DragDropEffects.Copy Or DragDropEffects.Move)
                End If
            Case MouseButtons.Right
                Select Case cnt
                    Case 0
                        mnuEmpty.Show(sender, New Point(e.X, e.Y))
                    Case 1
                        mnuSingle.Show(sender, New Point(e.X, e.Y))
                    Case Is > 1
                        mnuMulti.Show(sender, New Point(e.X, e.Y))
                End Select
            Case MouseButtons.Middle
        End Select
    End Sub

    Private Sub lbNetwork_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lbNetwork_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
        If sender.FindStringExact(e.Data.GetData(DataFormats.Text).ToString) = -1 Then
            sender.Items.Add(e.Data.GetData(DataFormats.Text).ToString)
            lbActive.Items.Remove(lbActive.Items(lbActive.SelectedIndex))
        End If
    End Sub

    Private Sub lbNetwork_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim i As Integer
        Select Case e.KeyChar
            Case Chr(1)
                For i = 0 To sender.Items.Count - 1
                    sender.SetSelected(i, True)
                Next
        End Select
    End Sub

    Private Sub OpenFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        Dim nam As String, net As clsNetwork, path As String
        For Each path In OpenFileDialog.FileNames
            nam = IO.Path.GetFileNameWithoutExtension(path)
            If Not networks.Contains(nam) Then
                net = New clsNetwork
                If Not net.Load(path) Then
                    MsgBox("Не удалось загрузить семантичскую сеть " & nam)
                    Continue For
                End If
                net.Name = nam
                net.URL = path
                networks.Add(net, nam)
                lbActive.Items.Add(nam)
            Else
                MsgBox("Имя " & nam & " уже используется")
                Continue For
            End If
        Next
    End Sub

    Private Sub itmLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmLoad.Click, itmSLoad.Click, itmMLoad.Click
        OpenFileDialog.Title = "Выберите файл(ы)"
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub itmStatistic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmStatistic.Click, itmMStatistic.Click
        Dim net As clsNetwork, lab As String, cnt As Integer, itm As Object
        cnt = lbActive.SelectedItems.Count
        lab = ""
        If cnt = 1 Then
            lab = lbActive.SelectedItem
            net = networks(lab)
        ElseIf cnt > 1 Then
            net = New clsNetwork
            For Each itm In lbActive.SelectedItems
                net.Join(networks(itm))
                lab = lab & itm & "| "
            Next
        Else
            Exit Sub
        End If
        frmStatistic.Text = lab
        frmStatistic.SetNodes = net.GetNodes
        frmStatistic.SetEdges = net.GetEdges
        frmStatistic.ShowDialog(Me)
    End Sub

    Private Sub itmGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmGraph.Click, itmMGraph.Click
        Dim itm As Object, net As New clsNetwork, cnt As Integer
        cnt = lbActive.SelectedItems.Count
        If cnt = 1 Then
            net = networks(lbActive.SelectedItem)
        ElseIf cnt > 1 Then
            net = New clsNetwork
            For Each itm In lbActive.SelectedItems
                net.Join(networks(itm))
            Next
        Else
            Exit Sub
        End If
        frmGlee.CreateView(net)
    End Sub

    Private Sub itmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmDelete.Click, itmMDelete.Click
        Dim i As Integer, nam As String, net As New clsNetwork, cnt As Integer
        cnt = lbActive.SelectedItems.Count
        If cnt = 1 Then
            networks.Remove(lbActive.SelectedItem)
            lbActive.Items.Remove(lbActive.SelectedItem)
        ElseIf cnt > 1 Then
            For i = 0 To cnt - 1
                nam = lbActive.SelectedItems(0)
                networks.Remove(nam)
                lbActive.Items.Remove(nam)
            Next
        Else
            Exit Sub
        End If
    End Sub

    Private Sub itmRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmRename.Click, itmCombain.Click
        Dim nam As String, oldnam As String, net As clsNetwork, cnt As Integer, i As Integer
        frmRename.ShowDialog()
        nam = frmRename.tbName.Text
        If nam <> "" Then
            If networks.Contains(nam) Then
                MsgBox("Имя " & nam & " уже используется")
                Exit Sub
            End If
            cnt = lbActive.SelectedItems.Count
            If cnt = 1 Then
                oldnam = lbActive.SelectedItem
                net = networks(oldnam)
                networks.Remove(oldnam)
                networks.Add(net, nam)
                lbActive.Items(lbActive.SelectedIndex) = nam
            ElseIf cnt > 1 Then
                net = New clsNetwork
                For i = 0 To cnt - 1
                    oldnam = lbActive.SelectedItems(0)
                    net.Join(networks(oldnam))
                    networks.Remove(oldnam)
                    lbActive.Items.Remove(oldnam)
                Next
                networks.Add(net, nam)
                lbActive.Items.Add(nam)
            Else
                Exit Sub
            End If
        End If
    End Sub

    'Private Sub itmConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmConvert.Click
    '    networks.Item(lbActive.SelectedItem).Convert()
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim syn As clsSyntax = New clsSyntax()
    '    If Not syn.CreateGrammarEngine("..\..\syntax\bin-windows\dictionary.xml") Then
    '        MsgBox("Ошибка загрузки словаря")
    '    End If
    '    syn.SyntaxAnalisis("пила злобно лежит на дубовом столе", "rus")
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim syn As New clsSeman
    '    syn.Test()
    'End Sub
End Class