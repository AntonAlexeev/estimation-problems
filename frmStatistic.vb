Public Class frmStatistic
    Private Edges As Collection
    Private Nodes As Collection

    Public WriteOnly Property SetEdges()
        Set(ByVal value As Object)
            Edges = value
        End Set
    End Property

    Public WriteOnly Property SetNodes()
        Set(ByVal value As Object)
            Nodes = value
        End Set
    End Property

    Private Sub frmStatistic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dgvRow As DataGridViewRow, dgvCell As DataGridViewCell
        Dim nod As clsNode, edg As clsEdge
        If Nodes Is Nothing Then
            MsgBox("Отсутсвует коллекция вершин")
        Else
            dgvNodes.Rows.Clear()
            For Each nod In Nodes
                dgvRow = New DataGridViewRow
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = nod.Label
                dgvRow.Cells.Add(dgvCell)
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = nod.Weight
                dgvRow.Cells.Add(dgvCell)
                dgvCell = New DataGridViewTextBoxCell()
                For Each edg In nod.Edges
                    dgvCell.Value += edg.Sibling(nod).Label & " | "
                Next
                dgvRow.Cells.Add(dgvCell)
                dgvNodes.Rows.Add(dgvRow)
            Next
        End If
        If Edges Is Nothing Then
            MsgBox("Отсутсвует коллекция отношений")
        Else
            dgvEdges.Rows.Clear()
            For Each edg In Edges
                dgvRow = New DataGridViewRow
                dgvCell = New DataGridViewTextBoxCell()
                dgvRow.Cells.Add(dgvCell)
                dgvCell.Value = edg.Source.Label
                dgvCell = New DataGridViewTextBoxCell()
                dgvRow.Cells.Add(dgvCell)
                dgvCell.Value = edg.Target.Label
                dgvCell = New DataGridViewTextBoxCell()
                dgvRow.Cells.Add(dgvCell)
                dgvCell.Value = edg.Weight
                dgvEdges.Rows.Add(dgvRow)
            Next
        End If
    End Sub
End Class