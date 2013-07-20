Imports EstimationTasks.mdlGlobal.enEdge

Public Class clsEdge
    Private m_id As String
    Private m_weight As Integer
    Private m_source As clsNode
    Private m_target As clsNode
    Private m_type As Integer
    Private m_names As New Collection

    Public Property id() As String
        Get
            id = m_id
        End Get
        Set(ByVal value As String)
            m_id = value
        End Set
    End Property

    Property Weight() As Integer
        Get
            Weight = m_weight
        End Get
        Set(ByVal value As Integer)
            m_weight = value
        End Set
    End Property

    Property Source() As clsNode
        Get
            Source = m_source
        End Get
        Set(ByVal value As clsNode)
            m_source = value
        End Set
    End Property

    Property Target() As clsNode
        Get
            Target = m_target
        End Get
        Set(ByVal value As clsNode)
            m_target = value
        End Set
    End Property

    Property Type() As Integer
        Get
            Type = m_type
        End Get
        Set(ByVal value As Integer)
            m_type = value
        End Set
    End Property

    Public ReadOnly Property Names As Collection
        Get
            Names = m_names
        End Get
    End Property

    Public Function Label(Optional ByVal inverted As Boolean = False) As String
        If inverted Then
            Label = IIf(m_target Is Nothing, "", m_target.Label) & "-" & IIf(m_source Is Nothing, "", m_source.Label) & CStr(m_type)
        Else
            Label = IIf(m_source Is Nothing, "", m_source.Label) & "-" & IIf(m_target Is Nothing, "", m_target.Label) & CStr(m_type)
        End If
    End Function

    Public Function Sibling(ByRef nod As clsNode) As clsNode
        If nod Is m_source Then
            Sibling = m_target
        ElseIf nod Is m_target Then
            Sibling = m_source
        Else
            Sibling = Nothing
        End If
    End Function

End Class
