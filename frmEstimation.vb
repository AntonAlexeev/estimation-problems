Imports EstimationTasks.mdlGlobal.strEstimation

Public Class frmEstimation
    Private networks As Collection
    Private lbActive As ListBox

    Private Sub frmEstimation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        networks = New Collection
        cmbNetworkType.SelectedIndex = 0
    End Sub

    Private Sub btnEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimate.Click
        Dim netSD As clsNetwork, netSP As clsNetwork, item As Object, est As strEstimation
        netSD = JoinNetworks(lbSubjectDomain.Items)
        If netSD Is Nothing Then
            MsgBox("Не удалось сформировать семантическую сеть предметной области")
            Exit Sub
        End If
        netSP = JoinNetworks(lbSolvedProblem.Items)
        If netSP Is Nothing Then
            MsgBox("Не удалось сформировать семантическую сеть обучающегося")
            Exit Sub
        End If
        dgvUnsolvedProblems.Rows.Clear()
        For Each item In lbUnsolvedProblem.Items
            Dim dgvRow As New DataGridViewRow
            Dim dgvCell As DataGridViewCell
            est = EstimateNetwork(netSD, netSP, networks(item))
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = item
            dgvRow.Cells.Add(dgvCell)
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = est.Estimation
            dgvRow.Cells.Add(dgvCell)
            dgvUnsolvedProblems.Rows.Add(dgvRow)
        Next
    End Sub

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
        EstimateNetwork.Estimation = 0
    End Function

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

    Private Sub lbSubjectDomain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbSubjectDomain.MouseDown
        If lbSubjectDomain.SelectedIndex < 0 Then Return
        lbActive = lbSubjectDomain
        lbSubjectDomain.DoDragDrop(lbSubjectDomain.Items(lbSubjectDomain.SelectedIndex).ToString, DragDropEffects.Copy Or DragDropEffects.Move)
    End Sub

    Private Sub lbSolvedProblem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbSolvedProblem.MouseDown
        If lbSolvedProblem.SelectedIndex < 0 Then Return
        lbActive = lbSolvedProblem
        lbSolvedProblem.DoDragDrop(lbSolvedProblem.Items(lbSolvedProblem.SelectedIndex).ToString, DragDropEffects.Copy Or DragDropEffects.Move)
    End Sub

    Private Sub lbUnsolvedProblem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbUnsolvedProblem.MouseDown
        If lbUnsolvedProblem.SelectedIndex < 0 Then Return
        lbActive = lbUnsolvedProblem
        lbUnsolvedProblem.DoDragDrop(lbUnsolvedProblem.Items(lbUnsolvedProblem.SelectedIndex).ToString, DragDropEffects.Copy Or DragDropEffects.Move)
    End Sub

    Private Sub lbUnused_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbUnused.MouseDown
        If lbUnused.SelectedIndex < 0 Then Return
        lbActive = lbUnused
        lbUnused.DoDragDrop(lbUnused.Items(lbUnused.SelectedIndex).ToString, DragDropEffects.Copy Or DragDropEffects.Move)
    End Sub

    Private Sub lbSubjectDomain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbSubjectDomain.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lbSolvedProblem_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbSolvedProblem.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lbUnsolvedProblem_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbUnsolvedProblem.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lbUnused_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbUnused.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lbSubjectDomain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbSubjectDomain.DragDrop
        If lbSubjectDomain.FindStringExact(e.Data.GetData(DataFormats.Text).ToString) = -1 Then
            lbSubjectDomain.Items.Add(e.Data.GetData(DataFormats.Text).ToString)
            lbActive.Items.Remove(lbActive.Items(lbActive.SelectedIndex))
        End If
    End Sub

    Private Sub lbSolvedProblem_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbSolvedProblem.DragDrop
        If lbSolvedProblem.FindStringExact(e.Data.GetData(DataFormats.Text).ToString) = -1 Then
            lbSolvedProblem.Items.Add(e.Data.GetData(DataFormats.Text).ToString)
            lbActive.Items.Remove(lbActive.Items(lbActive.SelectedIndex))
        End If
    End Sub

    Private Sub lbUnsolvedProblem_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbUnsolvedProblem.DragDrop
        If lbUnsolvedProblem.FindStringExact(e.Data.GetData(DataFormats.Text).ToString) = -1 Then
            lbUnsolvedProblem.Items.Add(e.Data.GetData(DataFormats.Text).ToString)
            lbActive.Items.Remove(lbActive.Items(lbActive.SelectedIndex))
        End If
    End Sub

    Private Sub lbUnused_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lbUnused.DragDrop
        If lbUnused.FindStringExact(e.Data.GetData(DataFormats.Text).ToString) = -1 Then
            lbUnused.Items.Add(e.Data.GetData(DataFormats.Text).ToString)
            lbActive.Items.Remove(lbActive.Items(lbActive.SelectedIndex))
        End If
    End Sub

    Private Sub dgvUnsolvedProblems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUnsolvedProblems.CellContentClick

    End Sub
End Class