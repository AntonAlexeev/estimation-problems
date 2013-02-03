Public Class frmNodes
    Private Nodes As Collection

    Public WriteOnly Property SetNodes()
        Set(ByVal value As Object)
            Nodes = value
        End Set
    End Property

    Private Sub frmEdges_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dgvRow As DataGridViewRow, dgvCell As DataGridViewCell
        Dim nod As clsNode, edg As clsEdge
        If Nodes Is Nothing Then
            MsgBox("Отсутсвует коллекция отношений")
            Return
        End If
        'Формирование таблицы
        dgvNodes.Rows.Clear()
        For Each nod In Nodes
            dgvRow = New DataGridViewRow
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = nod.id
            dgvRow.Cells.Add(dgvCell)
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
        Me.Width = dgvNodes.Width + 20
        Me.Height = dgvNodes.Height
    End Sub
End Class