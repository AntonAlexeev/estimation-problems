Imports System.IO
Imports EstimationTasks.mdlGlobal.strEstimation
Imports EstimationTasks.mdlGlobal.enEdge
Imports EstimationTasks.mdlGlobal.enCategory

Public Class clsNetwork
    Private m_name As String
    Private m_url As String
    Private m_nodes As Collection
    Private m_edges As Collection

    Public Property Name()
        Get
            Name = m_name
        End Get
        Set(ByVal value)
            m_name = value
        End Set
    End Property

    Public Property URL()
        Get
            URL = m_url
        End Get
        Set(ByVal value)
            m_url = value
        End Set
    End Property

    Public ReadOnly Property GetNodes()
        Get
            GetNodes = m_nodes
        End Get
    End Property

    Public ReadOnly Property GetEdges()
        Get
            GetEdges = m_edges
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
        If net IsNot Nothing Then
            m_nodes = net.GetNodes
            m_edges = net.GetEdges
            '    If Join(net) Then
            Load = True
            '    End If
        End If
    End Function

    Public Function Join(ByRef net As clsNetwork) As Boolean
        Dim n As clsNode, e As clsEdge, lab As String, edg As clsEdge, nod As clsNode, nam As String
        Dim src As String, tar As String
        ' Объединение вершин
        For Each n In net.GetNodes
            lab = n.Label
            If m_nodes.Contains(lab) Then
                nod = m_nodes(lab)
                nod.Weight = nod.Weight + n.Weight
            Else
                nod = New clsNode
                nod.Label = lab
                nod.Weight = n.Weight
                nod.Category = n.Category
                nod.Id = lab
                m_nodes.Add(nod, lab)
            End If
        Next
        ' Объединение дуг
        For Each e In net.GetEdges
            src = e.Source.Label
            tar = e.Target.Label
            lab = e.Label
            If m_edges.Contains(lab) Then
                edg = m_edges(lab)
                edg.Weight += e.Weight
                'ElseIf m_edges.Contains(e.Label(True)) Then ' Объединение дуг, имеющих обратное направление
                '    edg = m_edges(e.Label(True))
                '    edg.Weight += e.Weight
            Else
                edg = New clsEdge
                edg.Source = m_nodes(e.Source.Label)
                edg.Target = m_nodes(e.Target.Label)
                m_nodes(src).AddEdge(edg, lab)
                If src <> tar Then
                    m_nodes(tar).AddEdge(edg, lab)
                End If
                edg.Type = e.Type
                edg.Weight = e.Weight
                edg.id = lab
                m_edges.Add(edg, lab)
            End If
            If e.Names.Count > 0 Then
                For Each nam In e.Names
                    If Not edg.Names.Contains(nam) Then
                        edg.Names.Add(nam, nam)
                    End If
                Next
                edg.Weight = edg.Names.Count
            End If
        Next
        Join = True
    End Function

    Public Function Complexity(ByRef net As clsNetwork) As Double
        Dim e As clsEdge, ed As clsEdge, lab As String, est As Double
        Dim n As clsNode, src As clsNode, tar As clsNode
        Complexity = 0
        For Each e In net.GetEdges
            est = 0
            lab = e.Label
            ' Учитываем только отношения между существительными
            'If e.Source.Category <> catS Or e.Target.Category <> catS Then
            ' Continue For
            'End If
            ' Поиск прямых связей
            'For Each ed In m_edges
            '    If ed.Label() = lab Then 'Or ed.Label(True) = lab
            '        est += ed.Weight
            '    End If
            'Next
            ' Поиск косвенных связей
            'If est = 0 Then
            src = Nothing : tar = Nothing
            For Each n In m_nodes
                If n.Label = e.Source.Label Then
                    src = n
                End If
                If n.Label = e.Target.Label Then
                    tar = n
                End If
            Next
            If src IsNot Nothing And tar IsNot Nothing Then
                est += ComplexEdge(src, tar, 3)
            End If
            'End If
            Complexity += est
        Next
    End Function

    Private Function ComplexEdge(ByRef src As clsNode, ByVal tar As clsNode, ByVal maxdep As Integer, Optional ByVal curdep As Integer = 1, Optional ByVal min As Integer = Int32.MaxValue, Optional ByVal root As clsNode = Nothing) As Double
        Dim n As clsNode, e As clsEdge
        ComplexEdge = 0
        If root Is Nothing Then
            root = src
        End If
        For Each e In src.Edges
            n = e.Target
            If n Is src Or n Is root Then
                Continue For
            End If
            If n Is tar Then
                ComplexEdge += Math.Min(e.Weight, min) / IIf(curdep < 1, 1, curdep * curdep)
            Else
                If curdep < maxdep Then
                    ComplexEdge += ComplexEdge(n, tar, maxdep, curdep + 1, Math.Min(e.Weight, min), root)
                End If
            End If
        Next
    End Function

    Public Sub Delete(ByRef ent As Object)
        Dim edg As clsEdge, id As String, sib As clsNode
        If TypeOf ent Is clsNode Then
            For Each edg In ent.Edges
                id = edg.id
                sib = edg.Sibling(ent)
                sib.Edges.Remove(id)
                m_edges.Remove(id)
            Next
            m_nodes.Remove(ent.id)
        ElseIf TypeOf ent Is clsEdge Then
            m_edges.Remove(ent.Label)
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
                While m_edges.Contains(lab)
                    lab = lab & i
                End While
                edg.id = lab
                s.AddEdge(edg, lab)
                t.AddEdge(edg, lab)
                m_edges.Add(edg, lab)
            Next
        Next
    End Sub

    Public Sub New()
        m_nodes = New Collection
        m_edges = New Collection
    End Sub
End Class
