Imports System.Xml

Public Class clsGraphml
    Private network As clsNetwork
    Private nodes As Collection
    Private edges As Collection

    Public ReadOnly Property GetNetwork()
        Get
            GetNetwork = network
        End Get
    End Property

    Public Function Load(ByVal path) As Boolean
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
                                nod.Id = id
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
                                srcnod.AddEdge(edg, id)
                                tarnod.AddEdge(edg, id)
                                edges.Add(edg, id)
                            End If
                        End If
                End Select
            End If
        End While
        Load = True
    End Function

    Public Sub New()
        network = New clsNetwork
        nodes = network.GetNodes
        edges = network.GetEdges
    End Sub
End Class
