Imports System.IO
Imports System.Xml
Imports EstimationTasks.mdlGlobal.strEstimation

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
        Dim ext As String
        ext = IO.Path.GetExtension(path)
        Select Case ext
            Case ".graphml"
                Load = GraphML(path)
            Case ".unl"
                Load = UNL(path)
        End Select
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
                nod.Weight = n.Weight
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
                nodes(src).AddEdge(edg)
                nodes(tar).AddEdge(edg)
                edg.Weight = e.Weight
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
                Dim w1 As Integer, w2 As Integer, buf As Double
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

    Private Function GraphML(ByVal path As String) As Boolean
        Dim xr As XmlReader = XmlReader.Create(path)
        Dim xnod As XmlReader, xshp As XmlReader, xdat As XmlReader
        While xr.Read()
            If xr.IsStartElement Then
                Select Case xr.Name
                    Case "node"
                        Dim id As String, wei As Integer, lab As String, str As String
                        id = "" : wei = 1 : lab = ""
                        id = xr.GetAttribute("id")
                        xnod = xr.ReadSubtree()
                        If xnod.ReadToFollowing("data") Then
                            Do
                                If xnod.IsStartElement Then
                                    Select Case xnod.GetAttribute("key")
                                        Case "d4"
                                            str = xnod.ReadString()
                                            If IsNumeric(str) Then
                                                wei = CInt(str)
                                            End If
                                        Case Else
                                            xdat = xnod.ReadSubtree()
                                            If xdat.ReadToFollowing("y:ShapeNode") Then
                                                xshp = xnod.ReadSubtree()
                                                Do
                                                    If xr.IsStartElement Then
                                                        Select Case xshp.LocalName
                                                            Case "Geometry"
                                                            Case "Fill"
                                                            Case "BorderStyle"
                                                            Case "NodeLabel"
                                                                lab = xshp.ReadString
                                                            Case "Shape"
                                                        End Select
                                                    End If
                                                Loop While xshp.Read()
                                            End If
                                    End Select
                                    xnod.ReadToNextSibling("data")
                                End If
                            Loop While xnod.Read()
                            If id <> "" And lab <> "" Then
                                Dim nod As New clsNode
                                nod.id = id
                                nod.Label = lab
                                nod.Weight = wei
                                nodes.Add(nod, id)
                            End If
                        End If
                    Case "edge"
                        Dim id As String, src As String, tar As String, lab As String
                        id = "" : lab = "" : src = "" : tar = ""
                        id = xr.GetAttribute("id")
                        src = xr.GetAttribute("source")
                        tar = xr.GetAttribute("target")
                        xnod = xr.ReadSubtree()
                        If xnod.ReadToFollowing("data") Then
                            Do
                                If xnod.IsStartElement Then
                                    Select Case xnod.GetAttribute("key")
                                        Case "d9"
                                        Case Else
                                            xdat = xnod.ReadSubtree()
                                            If xdat.ReadToFollowing("y:PolyLineEdge") Then
                                                xshp = xnod.ReadSubtree()
                                                Do
                                                    If xr.IsStartElement Then
                                                        Select Case xshp.LocalName
                                                            Case "Path"
                                                            Case "LineStyle"
                                                            Case "Arrows"
                                                            Case "EdgeLabel"
                                                                lab = xshp.ReadString
                                                            Case "BendStyle"
                                                        End Select
                                                    End If
                                                Loop While xshp.Read()
                                            End If
                                    End Select
                                    xnod.ReadToNextSibling("data")
                                End If
                            Loop While xnod.Read()
                            If id <> "" And src <> "" And tar <> "" Then
                                Dim srcnod As clsNode, tarnod As clsNode, edg As New clsEdge
                                srcnod = nodes.Item(src)
                                tarnod = nodes.Item(tar)
                                edg.Source = srcnod
                                edg.Target = tarnod
                                If IsNumeric(lab) Then
                                    edg.Weight = CInt(lab)
                                Else
                                    edg.Weight = 1
                                End If
                                edg.id = id
                                srcnod.AddEdge(edg)
                                tarnod.AddEdge(edg)
                                edges.Add(edg, id)
                            End If
                        End If
                End Select
            End If
        End While
        GraphML = True
    End Function

    Private Function UNL(ByVal path) As Boolean
        Dim xr As XmlReader = XmlReader.Create(path), wrd As XmlReader
        Dim tree As New clsNetwork, nods As Collection, edgs As Collection
        nods = tree.nodes
        edgs = tree.edges
        Dim i As Integer
        While xr.Read()
            If xr.IsStartElement Then
                If xr.Name = "S" Then
                    wrd = xr.ReadSubtree()
                    If wrd.ReadToFollowing("W") Then
                        Do
                            If wrd.IsStartElement Then
                                Dim word As strWord, srcnod As clsNode, tarnod As clsNode, edg As clsEdge
                                word.Id = wrd.GetAttribute("ID")
                                word.Lemma = wrd.GetAttribute("LEMMA")
                                word.Link = wrd.GetAttribute("LINK")
                                word.Dom = wrd.GetAttribute("DOM")
                                word.Feat = wrd.GetAttribute("FEAT")
                                If Not nods.Contains(word.Id) Then
                                    tarnod = New clsNode
                                    nods.Add(tarnod, word.Id)
                                Else
                                    tarnod = nods.Item(word.Id)
                                End If
                                tarnod.Word = word
                                tarnod.Weight = 1
                                If word.Dom <> "_root" Then
                                    If Not nods.Contains(word.Dom) Then
                                        srcnod = New clsNode
                                        nods.Add(srcnod, word.Dom)
                                    Else
                                        srcnod = nods.Item(word.Dom)
                                    End If
                                    edg = New clsEdge
                                    edg.id = CStr(i)
                                    edg.Weight = 1
                                    edg.Source = srcnod
                                    edg.Target = tarnod
                                    srcnod.AddEdge(edg)
                                    tarnod.AddEdge(edg)
                                    edgs.Add(edg, i)
                                    i += 1
                                End If
                            End If
                        Loop While wrd.Read()
                    End If
                End If
            End If
        End While
        ' Конвертация семантической сети дерева в семантическую сеть понятий
        If tree.ToConcepts() Then
        End If
        ' Присоединение к сущетсвующей сети
        If Join(tree) Then
        End If
        nodes = tree.nodes
        edges = tree.edges
        UNL = True
UNL_Error:
    End Function

    Private Function ToConcepts() As Boolean
        ToConcepts = True
    End Function

    Public Sub New()
        nodes = New Collection
        edges = New Collection
    End Sub
End Class
