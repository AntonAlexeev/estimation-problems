Imports EstimationTasks.mdlGlobal.enEdge

Public Class clsEdge
    Private id_ As String
    Private weight_ As Integer
    Private source_ As clsNode
    Private target_ As clsNode
    Private type_ As Integer
    Private lfunction_ As strLFunction

    Public Property id() As String
        Get
            id = id_
        End Get
        Set(ByVal value As String)
            id_ = value
        End Set
    End Property

    Property Weight() As Integer
        Get
            Weight = weight_
        End Get
        Set(ByVal value As Integer)
            weight_ = value
        End Set
    End Property

    Property Source() As clsNode
        Get
            Source = source_
        End Get
        Set(ByVal value As clsNode)
            source_ = value
        End Set
    End Property

    Property Target() As clsNode
        Get
            Target = target_
        End Get
        Set(ByVal value As clsNode)
            target_ = value
        End Set
    End Property

    Property Type() As Integer
        Get
            Type = type_
        End Get
        Set(ByVal value As Integer)
            type_ = value
        End Set
    End Property

    Public Property LFunction() As Object
        Get
            LFunction = lfunction_
        End Get
        Set(ByVal value As Object)
            lfunction_ = value
        End Set
    End Property

    Public Function Label(Optional ByVal inverted As Boolean = False) As String
        If inverted Then
            Label = IIf(target_ Is Nothing, "", target_.Label) & "-" & IIf(source_ Is Nothing, "", source_.Label)
        Else
            Label = IIf(source_ Is Nothing, "", source_.Label) & "-" & IIf(target_ Is Nothing, "", target_.Label)
        End If
    End Function

    Public Function Sibling(ByRef nod As clsNode) As clsNode
        If nod Is source_ Then
            Sibling = target_
        ElseIf nod Is target_ Then
            Sibling = source_
        Else
            Sibling = Nothing
        End If
    End Function

End Class
