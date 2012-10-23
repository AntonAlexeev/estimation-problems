Imports System.Windows.Forms
Imports EstimationTasks.mdlGlobal.strEstimation

Public Class frmEstimation
    Private networks As Collection
    Private lbActive As ListBox
    Private WithEvents mnuListBox As ContextMenu
    Private WithEvents itmDetail As MenuItem
    Private WithEvents itmDelete As MenuItem

    Private Function JoinNetworks(ByRef list As ListBox.ObjectCollection) As clsNetwork
        Dim cnt As Integer
        Dim item As Object
        cnt = list.Count
        JoinNetworks = Nothing
        If cnt > 0 Then
            If cnt = 1 Then
                JoinNetworks = networks.Item(list(0))
            Else
                ' Объединение сетей
                JoinNetworks = New clsNetwork
                For Each item In list
                    JoinNetworks.Join(networks(item))
                Next
            End If
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
        cmbNetworkType.SelectedIndex = 0
        ' Формирвоание контекстного меню ListBox
        mnuListBox = New ContextMenu
        itmDetail = New MenuItem
        itmDelete = New MenuItem
        mnuListBox.MenuItems.AddRange(New MenuItem() {itmDetail, itmDelete})
        itmDetail.Index = 0
        itmDetail.Text = "Detail"
        itmDelete.Index = 1
        itmDelete.Text = "Delete"
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

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim net As New clsNetwork, nodes As Collection, nam As String, path As String
        nam = tbNetworkName.Text
        path = tbFileName.Text
        If nam <> "" And path <> "" Then
            If Not networks.Contains(nam) Then
                nodes = net.Load(path)
                net.Name = nam
                net.URL = path
                networks.Add(net, nam)
                Select Case cmbNetworkType.SelectedIndex
                    Case 0
                        lbSolvedProblem.Items.Add(nam)
                    Case 1
                        lbUnsolvedProblem.Items.Add(nam)
                    Case 2
                        lbSubjectDomain.Items.Add(nam)
                End Select
            Else
                MsgBox("Такое имя семантической сети уже используется")
            End If
        Else
            MsgBox("Заполните все данные")
        End If
    End Sub

    Private Sub btnOpenDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenDialog.Click
        OpenFileDialog.Title = "Выберите файл"
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub OpenFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        tbFileName.Text = OpenFileDialog.FileName.ToString()
    End Sub

    Private Sub lbNetwork_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If sender.SelectedIndex < 0 Then Return
        lbActive = sender
        Select Case e.Button
            Case MouseButtons.Left
                sender.DoDragDrop(sender.Items(sender.SelectedIndex).ToString, DragDropEffects.Copy Or DragDropEffects.Move)
            Case MouseButtons.Right
                mnuListBox.Show(sender, New Point(e.X, e.Y))
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

    Private Sub itmDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmDetail.Click
        Dim dtv As DataGridView, net As clsNetwork, lab As String
        Dim dgvRow As DataGridViewRow, dgvCell As DataGridViewCell
        Dim nod As clsNode, edg As clsEdge
        dtv = frmNetwork.dgvNetowrk
        lab = lbActive.SelectedItem
        net = networks(lab)
        frmNetwork.Text = lab
        dtv.Rows.Clear()
        For Each nod In net.GetNodes
            dgvRow = New DataGridViewRow
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = nod.Label
            dgvRow.Cells.Add(dgvCell)
            dgvCell = New DataGridViewTextBoxCell()
            For Each edg In nod.Edges
                dgvCell.Value += edg.Sibling(nod).Label & " | "
            Next
            dgvRow.Cells.Add(dgvCell)
            dtv.Rows.Add(dgvRow)
        Next
        frmNetwork.ShowDialog(Me)
    End Sub

    Private Sub itmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itmDelete.Click
        networks.Remove(lbActive.SelectedItem)
        lbActive.Items.Remove(lbActive.SelectedItem)
    End Sub
End Class