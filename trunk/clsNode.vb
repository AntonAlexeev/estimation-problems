Imports EstimationTasks.mdlGlobal.enDirection

Public Class clsNode
    Private id_ As String
    Private label_ As String
    Private weight_ As Integer
    Private word_ As strWord
    Private edges_ As New Collection

    Public Property Id() As String
        Get
            Id = id_
        End Get
        Set(ByVal value As String)
            id_ = value
        End Set
    End Property

    Public Property Label() As String
        Get
            Label = label_
        End Get
        Set(ByVal value As String)
            label_ = value
        End Set
    End Property

    Public ReadOnly Property Edges() As Collection
        Get
            Edges = edges_
        End Get
    End Property

    Public Property Weight() As Integer
        Get
            Weight = weight_
        End Get
        Set(ByVal value As Integer)
            weight_ = value
        End Set
    End Property

    Public Property Word() As Object
        Get
            Word = word_
        End Get
        Set(ByVal value As Object)
            word_ = value
            id_ = value.Id
            label_ = value.Lemma
        End Set
    End Property

    Public Sub AddEdge(ByRef edg As clsEdge)
        edges_.Add(edg)
    End Sub

    Public Function Siblings(Optional ByVal dir As Integer = dirNone) As Collection
        Dim edg As clsEdge
        Siblings = New Collection
        Select Case dir
            Case dirNone
                For Each edg In edges_
                    Siblings.Add(edg.Sibling(Me))
                Next edg
            Case dirForward
                For Each edg In edges_
                    If edg.Source Is Me Then
                        Siblings.Add(edg.Target)
                    End If
                Next edg
            Case dirBackward
                For Each edg In edges_
                    If edg.Target Is Me Then
                        Siblings.Add(edg.Source)
                    End If
                Next edg
        End Select
    End Function
End Class


