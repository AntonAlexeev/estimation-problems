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

    Public Function Load(ByVal path As String) As Collection
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
        Load = nodes
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
        Dim e As clsEdge, edgs As Collection, lab As String
        Complexity = 0
        For Each e In net.GetEdges
            ' Поиск прямых связей
            lab = e.Label
            If edges.Contains(lab) Then
                Complexity += edges(lab).Weight
            End If
            lab = e.Label(True)
            If edges.Contains(lab) Then
                Complexity += edges(lab).Weight
            End If
            ' Поиск косвенных связей
            If Complexity <= 0 Then
                Dim src As clsNode, tar As clsNode, e1 As clsEdge, e2 As clsEdge
                Dim w1 As Integer, w2 As Integer
                'Поиск связей глубиной 2
                src = e.Source
                tar = e.Target
                For Each e1 In src.Edges
                    For Each e2 In tar.Edges
                        If e1.Sibling(src) Is e2.Sibling(tar) Then
                            w1 = e1.Weight
                            w2 = e2.Weight
                            Complexity += IIf(w1 > w2, w1, w2) / 2
                        End If
                    Next
                Next
            End If
        Next
    End Function

    Public Sub New()
        nodes = New Collection
        edges = New Collection
    End Sub
End Class
