Public Class frmEdges
    Private Edges As Collection

    Public WriteOnly Property SetEdges()
        Set(ByVal value As Object)
            Edges = value
        End Set
    End Property

    Private Sub frmEdges_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dgvRow As DataGridViewRow, dgvCell As DataGridViewCell
        Dim edg As clsEdge
        If Edges Is Nothing Then
            MsgBox("Отсутсвует коллекция отношений")
            Return
        End If
        'Формирование таблицы
        dgvEdges.Rows.Clear()
        For Each edg In Edges
            dgvRow = New DataGridViewRow
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = edg.id
            dgvRow.Cells.Add(dgvCell)
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
        Me.Width = dgvEdges.Width + 20
        Me.Height = dgvEdges.Height
    End Sub

    'Private Sub dgvEdges_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEdges.

    'End Sub
End Class