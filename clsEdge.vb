Public Class clsEdge
    Private id_ As String
    Private lab As String
    Private wei As Integer
    Private src As clsNode
    Private tar As clsNode

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

    Property Weight() As Integer
        Get
            Weight = wei
        End Get
        Set(ByVal value As Integer)
            wei = value
        End Set
    End Property

    Property Source() As clsNode
        Get
            Source = src
        End Get
        Set(ByVal value As clsNode)
            src = value
        End Set
    End Property

    Property Target() As clsNode
        Get
            Target = tar
        End Get
        Set(ByVal value As clsNode)
            tar = value
        End Set
    End Property

    Public Function Sibling(ByRef nod As clsNode) As clsNode
        If nod Is src Then
            Sibling = tar
        ElseIf nod Is tar Then
            Sibling = src
        Else
            Sibling = Nothing
        End If
    End Function

End Class
