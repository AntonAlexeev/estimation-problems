Imports System.Xml
Imports EstimationTasks.mdlGlobal.enEdge
Imports EstimationTasks.mdlGlobal.enCategory

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
                                    tarnod.Category = Category(word.Feat)
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
                                        Select Case word.Link
                                            Case "fictit"
                                                edg.Type = edgFictit
                                            Case Else
                                                edg.Type = edgWord
                                        End Select
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
                If n.Category = catNid Then
                    network.Exclude(n)
                End If
            End If
        Next
    End Sub

    Private Function Category(ByVal str As String) As Integer
        Select Case str.Split(" "c)(0)
            Case "S"
                Category = catS
            Case "A"
                Category = catA
            Case "V"
                Category = catV
            Case "ADV"
                Category = catAdv
            Case "NUM"
                Category = catNum
            Case "PR"
                Category = catPr
            Case "COM"
                Category = catCom
            Case "CONJ"
                Category = catConj
            Case "PART"
                Category = catPart
            Case "P"
                Category = catP
            Case "INTJ"
                Category = catIntj
            Case "NID"
                Category = catNid
            Case Else
                Category = 0
        End Select
    End Function

    Public Sub New()
        network = New clsNetwork
        nodes = network.GetNodes
        edges = network.GetEdges
    End Sub
End Class
