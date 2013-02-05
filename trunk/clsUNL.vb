Imports System.Xml
Imports EstimationTasks.mdlGlobal.enEdge

Public Class clsUNL
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
        Dim word As strWord, lf As strLFunction, srcnod As clsNode, tarnod As clsNode, edg As clsEdge
        Dim i As Integer
        While xr.Read()
            If xr.IsStartElement Then
                If xr.Name = "S" Then
                    While xr.Read()
                        If xr.IsStartElement Then
                            Select Case xr.Name
                                Case "W"
                                    word = New strWord
                                    word.Id = xr.GetAttribute("ID")
                                    word.Lemma = xr.GetAttribute("LEMMA")
                                    word.Link = xr.GetAttribute("LINK")
                                    word.Dom = xr.GetAttribute("DOM")
                                    word.Feat = xr.GetAttribute("FEAT")
                                    If Not nodes.Contains(word.Id) Then
                                        tarnod = New clsNode
                                        nodes.Add(tarnod, word.Id)
                                    Else
                                        tarnod = nodes.Item(word.Id)
                                    End If
                                    tarnod.Word = word
                                    tarnod.Weight = 1
                                    If word.Dom <> "_root" Then
                                        If Not nodes.Contains(word.Dom) Then
                                            srcnod = New clsNode
                                            nodes.Add(srcnod, word.Dom)
                                        Else
                                            srcnod = nodes.Item(word.Dom)
                                        End If
                                        edg = New clsEdge
                                        edg.id = CStr(i)
                                        edg.Type = edgWord
                                        edg.Weight = 1
                                        edg.Source = srcnod
                                        edg.Target = tarnod
                                        srcnod.AddEdge(edg, i)
                                        tarnod.AddEdge(edg, i)
                                        edges.Add(edg, i)
                                        i += 1
                                    End If
                                Case "LF"
                                    lf = New strLFunction
                                    lf.LFArg = xr.GetAttribute("LFARG")
                                    lf.LFFunc = xr.GetAttribute("LFFUNC")
                                    lf.LFVal = xr.GetAttribute("LFVAL")
                                    If Not nodes.Contains(lf.LFVal) Then
                                        tarnod = New clsNode
                                        nodes.Add(tarnod, lf.LFVal)
                                    Else
                                        tarnod = nodes.Item(lf.LFVal)
                                    End If
                                    tarnod.Weight = 1
                                    If Not nodes.Contains(lf.LFArg) Then
                                        srcnod = New clsNode
                                        nodes.Add(srcnod, lf.LFArg)
                                    Else
                                        srcnod = nodes.Item(lf.LFArg)
                                    End If
                                    edg = New clsEdge
                                    edg.id = CStr(i)
                                    edg.Type = edgLFunction
                                    edg.LFunction = lf
                                    edg.Weight = 1
                                    edg.Source = srcnod
                                    edg.Target = tarnod
                                    srcnod.AddEdge(edg, i)
                                    tarnod.AddEdge(edg, i)
                                    edges.Add(edg, i)
                                    i += 1
                            End Select
                        End If
                    End While
                End If
            End If
        End While
        Convert()
        Load = True
    End Function

    Private Sub Convert()
        Dim n As clsNode
        For Each n In nodes
            If Not n.Word Is Nothing Then
                If n.Word.Feat = "NID" Then
                    network.Exclude(n)
                End If
            End If
        Next
    End Sub

    Public Sub New()
        network = New clsNetwork
        nodes = network.GetNodes
        edges = network.GetEdges
    End Sub
End Class
