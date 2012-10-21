Imports EstimationTasks.mdlGlobal.Direction

Public Class clsNode
    Private id_ As String
    Private lab As String
    Private wei As Integer
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

    Public Property Weight() As Integer
        Get
            Weight = wei
        End Get
        Set(ByVal value As Integer)
            wei = value
        End Set
    End Property

    Public Sub AddEdge(ByRef edg As clsEdge)
        edgs.Add(edg)
    End Sub

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


