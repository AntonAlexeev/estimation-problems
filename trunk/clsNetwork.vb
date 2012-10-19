Imports System.IO
Imports System.Xml

Public Class clsNetwork
    Private nam As String
    Private url_ As String
    Private nodes As Collection

    Public Property Name()
        Get
            Name = nam
        End Get
        Set(ByVal value)
            nam = value
        End Set
    End Property

    Public ReadOnly Property GetNodes()
        Get
            GetNodes = nodes
        End Get
    End Property

    Public Property URL()
        Get
            URL = url_
        End Get
        Set(ByVal value)
            url_ = value
        End Set
    End Property

    Public Function Load(ByVal path As String) As Collection
        Dim xnod As XmlReader, xedg As XmlReader, xshp As XmlReader, xtr As XmlTextReader
        xtr = New XmlTextReader(path)
        While Not xtr.EOF
            xtr.Read()
            If xtr.NodeType <> XmlNodeType.Element Then
                Continue While
            End If
            Select Case xtr.Name
                Case "node"
                    Dim id As String, frq As Integer, lab As String
                    id = "" : frq = 0 : lab = ""
                    id = xtr.GetAttribute("id")
                    xnod = xtr.ReadSubtree()
                    xnod.ReadToFollowing("data")
                    While Not xnod.EOF
                        Select Case xnod.GetAttribute("key")
                            Case "d4"
                                frq = CInt(xnod.ReadString())
                            Case "d6"
                            Case "d7"
                                xnod.ReadToFollowing("y:ShapeNode")
                                xshp = xnod.ReadSubtree()
                                xshp.Read()
                                While Not xshp.EOF
                                    xshp.Read()
                                    If xshp.NodeType <> XmlNodeType.Element Then
                                        Continue While
                                    End If
                                    Select Case xshp.LocalName
                                        Case "Geometry"
                                        Case "Fill"
                                        Case "BorderStyle"
                                        Case "NodeLabel"
                                            lab = xshp.ReadString
                                        Case "Shape"
                                    End Select
                                End While
                        End Select
                        xnod.ReadToNextSibling("data")
                    End While
                    If id <> "" And lab <> "" Then
                        Dim nod As New clsNode
                        nod.id = id
                        nod.Label = lab
                        nod.Frequency = frq
                        nodes.Add(nod, id)
                    End If
                Case "edge"
                    Dim id As String, src As String, tar As String, lab As String
                    id = "" : lab = "" : src = "" : tar = ""
                    id = xtr.GetAttribute("id")
                    src = xtr.GetAttribute("source")
                    tar = xtr.GetAttribute("target")
                    xedg = xtr.ReadSubtree()
                    xedg.ReadToFollowing("data")
                    While Not xedg.EOF
                        Select Case xedg.GetAttribute("key")
                            Case "d9"
                            Case "d12"
                                xedg.ReadToFollowing("y:PolyLineEdge")
                                xshp = xedg.ReadSubtree()
                                xshp.Read()
                                While Not xshp.EOF
                                    xshp.Read()
                                    If xshp.NodeType <> XmlNodeType.Element Then
                                        Continue While
                                    End If
                                    Select Case xshp.LocalName
                                        Case "Path"
                                        Case "LineStyle"
                                        Case "Arrows"
                                        Case "EdgeLabel"
                                            lab = xshp.ReadString
                                        Case "BendStyle"
                                    End Select
                                End While
                        End Select
                        xedg.ReadToNextSibling("data")
                    End While
                    If id <> "" And src <> "" And tar <> "" And lab <> "" Then
                        Dim srcnod As clsNode, tarnod As clsNode, edg As New clsEdge
                        srcnod = nodes.Item(src)
                        tarnod = nodes.Item(tar)
                        edg.Source = srcnod
                        edg.Target = tarnod
                        edg.Weight = lab
                        edg.id = id
                        srcnod.AddEdge(edg)
                        tarnod.AddEdge(edg)
                    End If
            End Select
        End While
        Load = nodes
    End Function

    Public Function Join(ByRef net As clsNetwork) As Boolean
        Dim n As clsNode, e As clsEdge, newnodes As Collection, edgs As Collection, lab As String
        newnodes = net.GetNodes
        For Each n In newnodes
            lab = n.Label
            If nodes.Contains(lab) Then
                edgs = n.Edges
                For Each e In edgs
                    If e.Source Is n Then
                        If nodes.Contains(lab) Then
                            e.Target = nodes.Item(lab)
                        End If
                    ElseIf e.Target Is n Then
                        If nodes.Contains(lab) Then
                            e.Target = nodes.Item(lab)
                        End If
                    End If
                Next
            Else
                nodes.Add(n, lab)
            End If
        Next n
        Join = True
    End Function

    Public Sub New()
        nodes = New Collection
    End Sub
End Class
