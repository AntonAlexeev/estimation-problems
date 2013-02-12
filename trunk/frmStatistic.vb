Imports EstimationTasks.mdlGlobal.enCategory
Imports EstimationTasks.mdlGlobal.enEdge

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
        Dim nod As clsNode, edg As clsEdge, names As String
        If Nodes Is Nothing Then
            MsgBox("Отсутсвует коллекция вершин")
        Else
            dgvNodes.Rows.Clear()
            For Each nod In Nodes
                names = ""
                For Each edg In nod.Edges
                    names += edg.Sibling(nod).Label & " | "
                Next
                AddRow(dgvNodes, New String() {nod.Label, arrCategory(nod.Category), nod.Weight, names})
            Next
        End If
        If Edges Is Nothing Then
            MsgBox("Отсутсвует коллекция отношений")
        Else
            dgvEdges.Rows.Clear()
            For Each edg In Edges
                AddRow(dgvEdges, New String() {edg.Source.Label, edg.Target.Label, arrEdges(edg.Type), edg.Weight})
            Next
        End If
        Common()
    End Sub

    Private Sub Common()
        Dim S As Integer, A As Integer, V As Integer, Adv As Integer, Num As Integer, Pr As Integer, Com As Integer, Conj As Integer, Part As Integer, P As Integer, Intj As Integer, Nid As Integer
        Dim F As Integer, LF As Integer
        Dim nod As clsNode, edg As clsEdge
        dgvCategory.Rows.Clear()
        For Each nod In Nodes
            Select Case nod.Category
                Case catS
                    S += 1
                Case catA
                    A += 1
                Case catV
                    V += 1
                Case catAdv
                    Adv += 1
                Case catNum
                    Num += 1
                Case catPr
                    Pr += 1
                Case catCom
                    Com += 1
                Case catConj
                    Conj += 1
                Case catPart
                    Part += 1
                Case catP
                    P += 1
                Case catIntj
                    Intj += 1
                Case catNid
                    Nid += 1
            End Select
        Next
        For Each edg In Edges
            Select Case edg.Type
                Case edgLFunction
                    LF += 1
                Case edgFictit
                    F += 1
            End Select
        Next
        AddRow(dgvCategory, New String() {arrCategory(catS), CStr(S)})
        AddRow(dgvCategory, New String() {arrCategory(catA), CStr(A)})
        AddRow(dgvCategory, New String() {arrCategory(catV), CStr(V)})
        AddRow(dgvCategory, New String() {arrCategory(catAdv), CStr(Adv)})
        AddRow(dgvCategory, New String() {arrCategory(catNum), CStr(Num)})
        AddRow(dgvCategory, New String() {arrCategory(catPr), CStr(Pr)})
        AddRow(dgvCategory, New String() {arrCategory(catCom), CStr(Com)})
        AddRow(dgvCategory, New String() {arrCategory(catConj), CStr(Conj)})
        AddRow(dgvCategory, New String() {arrCategory(catPart), CStr(Part)})
        AddRow(dgvCategory, New String() {arrCategory(catP), CStr(P)})
        AddRow(dgvCategory, New String() {arrCategory(catIntj), CStr(Intj)})
        AddRow(dgvCategory, New String() {arrCategory(catNid), CStr(Nid)})

        AddRow(dgvStat, New String() {"Понятия", CStr(Nodes.Count)})
        AddRow(dgvStat, New String() {"Отношения", CStr(Edges.Count)})
        AddRow(dgvStat, New String() {"Лексические функции", CStr(LF)})
        AddRow(dgvStat, New String() {"Фиктивные отношения", CStr(F)})
    End Sub

    Private Sub AddRow(ByRef dgv As DataGridView, ByVal val() As String)
        Dim dgvRow As DataGridViewRow, dgvCell As DataGridViewCell, s As String, res As Integer
        dgvRow = New DataGridViewRow
        For Each s In val
            dgvCell = New DataGridViewTextBoxCell()
            If Integer.TryParse(s, res) Then
                dgvCell.Value = res
            Else
                dgvCell.Value = s
            End If
            dgvRow.Cells.Add(dgvCell)
        Next
        dgv.Rows.Add(dgvRow)
    End Sub
End Class