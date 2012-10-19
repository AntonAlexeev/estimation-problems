Imports EstimationTasks.mdlGlobal.Direction

Public Class clsNode
    Private id_ As String
    Private lab As String
    Private frq As String
    Private edgs As New Collection

    Public Property id() As String
        Get
            id = id_
        End Get
        Set(ByVal value As String)
            id_ = value
        End Set
    End Property

    Public Property Label() As String
        Get
            Label = lab
        End Get
        Set(ByVal value As String)
            lab = value
        End Set
    End Property

    Public ReadOnly Property Edges() As Collection
        Get
            Edges = edgs
        End Get
    End Property

    Public Property Frequency() As Integer
        Get
            Frequency = frq
        End Get
        Set(ByVal value As Integer)
            frq = value
        End Set
    End Property

    Public Function AddEdge(ByRef nod As clsNode, Optional ByVal dir As Integer = dirNone) As clsEdge
        Dim edg As New clsEdge
        Select Case dir
            Case dirForward, dirNone
                edg.Source = Me
                edg.Target = nod
            Case dirBackward
                edg.Source = nod
                edg.Target = Me
        End Select
        edgs.Add(edg)
        AddEdge = edg
    End Function

    Public Sub AddEdge(ByRef edg As clsEdge)
        edgs.Add(edg)
    End Sub

    'Public Sub RemoveEdge(ByRef nod As clsNode, Optional ByVal dir As Integer = dirNone)
    '    Dim edg As New clsEdge
    '    For Each edg In edgs
    '        If edg.Sibling(Me) Is nod Then
    '            edgs.
    '        End If
    '    Next edg
    '    edgs.Add(edg)
    'End Sub

    Public Function Siblings(Optional ByVal dir As Integer = dirNone) As Collection
        Dim edg As clsEdge
        Siblings = New Collection
        Select Case dir
            Case dirNone
                For Each edg In edgs
                    Siblings.Add(edg.Sibling(Me))
                Next edg
            Case dirForward
                For Each edg In edgs
                    If edg.Source Is Me Then
                        Siblings.Add(edg.Target)
                    End If
                Next edg
            Case dirBackward
                For Each edg In edgs
                    If edg.Target Is Me Then
                        Siblings.Add(edg.Source)
                    End If
                Next edg
        End Select
    End Function
End Class


