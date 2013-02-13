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
                AddRow(dgvNodes, New Object() {nod.Label, arrCategory(nod.Category), nod.Weight, names})
            Next
        End If
        If Edges Is Nothing Then
            MsgBox("Отсутсвует коллекция отношений")
        Else
            dgvEdges.Rows.Clear()
            For Each edg In Edges
                AddRow(dgvEdges, New Object() {edg.Source.Label, edg.Target.Label, arrEdges(edg.Type), edg.Weight})
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
        AddRow(dgvCategory, New Object() {arrCategory(catS), S})
        AddRow(dgvCategory, New Object() {arrCategory(catA), A})
        AddRow(dgvCategory, New Object() {arrCategory(catV), V})
        AddRow(dgvCategory, New Object() {arrCategory(catAdv), Adv})
        AddRow(dgvCategory, New Object() {arrCategory(catNum), Num})
        AddRow(dgvCategory, New Object() {arrCategory(catPr), Pr})
        AddRow(dgvCategory, New Object() {arrCategory(catCom), Com})
        AddRow(dgvCategory, New Object() {arrCategory(catConj), Conj})
        AddRow(dgvCategory, New Object() {arrCategory(catPart), Part})
        AddRow(dgvCategory, New Object() {arrCategory(catP), P})
        AddRow(dgvCategory, New Object() {arrCategory(catIntj), Intj})
        AddRow(dgvCategory, New Object() {arrCategory(catNid), Nid})
        dgvStat.Rows.Clear()
        AddRow(dgvStat, New Object() {"Слова", Nodes.Count})
        AddRow(dgvStat, New Object() {"Синтаксические связи", Edges.Count})
        AddRow(dgvStat, New Object() {"Лексические функции", LF})
        AddRow(dgvStat, New Object() {"Фиктивные связи", F})
    End Sub
End Class