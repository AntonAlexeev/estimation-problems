Imports System.IO
Imports System.Xml
Imports EstimationTasks.mdlGlobal.strEstimation
Imports EstimationTasks.mdlGlobal.enEdge

Public Class clsNetwork
    Private nam As String
    Private url_ As String
    Private nodes As Collection
    Private edges As Collection

    Public Property Name()
        Get
            Name = nam
        End Get
        Set(ByVal value)
            nam = value
        End Set
    End Property

    Public Property URL()
        Get
            URL = url_
        End Get
        Set(ByVal value)
            url_ = value
        End Set
    End Property

    Public ReadOnly Property GetNodes()
        Get
            GetNodes = nodes
        End Get
    End Property

    Public ReadOnly Property GetEdges()
        Get
            GetEdges = edges
        End Get
    End Property

    Public Function Load(ByVal path As String) As Boolean
        Dim ext As String, net As clsNetwork
        net = Nothing
        ext = IO.Path.GetExtension(path)
        Select Case ext
            Case ".graphml"
                Dim graphml As New clsGraphml
                If graphml.Load(path) Then
                    net = graphml.GetNetwork
                End If
            Case ".unl"
                Dim unl As New clsUNL
                If unl.Load(path) Then
                    net = unl.GetNetwork
                End If
        End Select
        If Not net Is Nothing Then
            nodes = net.GetNodes
            edges = net.GetEdges
            '    If Join(net) Then
            Load = True
            '    End If
        End If
    End Function

    Public Function Join(ByRef net As clsNetwork) As Boolean
        Dim n As clsNode, e As clsEdge, lab As String, edg As clsEdge, nod As clsNode
        Dim src As String, tar As String
        ' Объединение вершин
        For Each n In net.GetNodes
            lab = n.Label
            If nodes.Contains(lab) Then
                nod = nodes(lab)
                nod.Weight = nod.Weight + n.Weight
            Else
                nod = New clsNode
                nod.Label = lab
                nod.Id = lab
                nod.Weight = n.Weight
                nod.Category = n.Category
                nodes.Add(nod, lab)
            End If
        Next
        ' Объединение дуг
        For Each e In net.GetEdges
            src = e.Source.Label
            tar = e.Target.Label
            lab = e.Label
            If edges.Contains(lab) Then
                edg = edges(lab)
                edg.Weight = edg.Weight + e.Weight
            ElseIf edges.Contains(e.Label(True)) Then ' Объединение дуг, имеющих обратное направление
                edg = edges(e.Label(True))
                edg.Weight = edg.Weight + e.Weight
            Else
                edg = New clsEdge
                edg.Source = nodes(e.Source.Label)
                edg.Target = nodes(e.Target.Label)
                nodes(src).AddEdge(edg, lab)
                If src <> tar Then
                    nodes(tar).AddEdge(edg, lab)
                End If
                edg.Type = e.Type
                edg.Weight = e.Weight
                edg.id = lab
                edges.Add(edg, lab)
                End If
        Next
        Join = True
    End Function

    Public Function Complexity(ByRef net As clsNetwork) As Double
        Dim e As clsEdge, ed As clsEdge, lab As String, est As Double
        Complexity = 0
        For Each e In net.GetEdges
            est = 0
            lab = e.Label
            ' Поиск прямых связей
            For Each ed In edges
                If ed.Label() = lab Or ed.Label(True) = lab Then
                    est += ed.Weight
                End If
            Next
            ' Поиск косвенных связей
            If est = 0 Then
                Dim n As clsNode, src As clsNode, tar As clsNode, e1 As clsEdge, e2 As clsEdge
                Dim n1 As clsNode, n2 As clsNode
                Dim w1 As Integer, w2 As Integer
                src = Nothing
                tar = Nothing
                'Поиск связей глубиной 2
                For Each n In nodes
                    If n.Label = e.Source.Label Then
                        src = n
                    End If
                    If n.Label = e.Target.Label Then
                        tar = n
                    End If
                Next n
                If Not src Is Nothing And Not tar Is Nothing Then
                    For Each e1 In src.Edges
                        n1 = e1.Sibling(src)
                        For Each e2 In tar.Edges
                            If n1 Is e2.Sibling(tar) Then
                                w1 = e1.Weight
                                w2 = e2.Weight
                                est += IIf(w1 < w2, w1, w2) / 2
                            End If
                        Next
                    Next
                End If
            End If
            Complexity += est
        Next
    End Function

    Public Sub Delete(ByRef ent As Object)
        Dim edg As clsEdge, id As String, sib As clsNode
        If TypeOf ent Is clsNode Then
            For Each edg In ent.Edges
                id = edg.id
                sib = edg.Sibling(ent)
                sib.Edges.Remove(id)
                edges.Remove(id)
            Next
            nodes.Remove(ent.id)
        ElseIf TypeOf ent Is clsEdge Then
            edges.Remove(ent.Label)
        End If
    End Sub

    Public Sub Exclude(ByRef nod As clsNode)
        Dim tar As New Collection, src As New Collection, e As clsEdge, t As clsNode, s As clsNode, edg As clsEdge
        Dim lab As String, i As Integer
        For Each e In nod.Edges
            If e.Source Is nod Then
                tar.Add(e.Target)
            ElseIf e.Target Is nod Then
                src.Add(e.Source)
            End If
        Next
        Delete(nod)
        For Each t In tar
            For Each s In src
                edg = New clsEdge
                edg.Type = edgWord
                edg.Weight = 1
                edg.Source = s
                edg.Target = t
                lab = edg.Label
                i = 1
                While edges.Contains(lab)
                    lab = lab & i
                End While
                edg.id = lab
                s.AddEdge(edg, lab)
                t.AddEdge(edg, lab)
                edges.Add(edg, lab)
            Next
        Next
    End Sub

    Public Sub New()
        nodes = New Collection
        edges = New Collection
    End Sub
End Class
