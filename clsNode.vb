Imports EstimationTasks.mdlGlobal.enDirection

Public Class clsNode
    Private m_id As String
    Private m_label As String
    Private m_weight As Integer
    Private m_word As strWord
    Private m_category As Integer
    Private m_edges As New Collection

    Public Property Id() As String
        Get
            Id = m_id
        End Get
        Set(ByVal value As String)
            m_id = value
        End Set
    End Property

    Public Property Label() As String
        Get
            Label = m_label
        End Get
        Set(ByVal value As String)
            m_label = value
        End Set
    End Property

    Public ReadOnly Property Edges() As Collection
        Get
            Edges = m_edges
        End Get
    End Property

    Public Property Weight() As Integer
        Get
            Weight = m_weight
        End Get
        Set(ByVal value As Integer)
            m_weight = value
        End Set
    End Property

    Public Property Word() As Object
        Get
            Word = m_word
        End Get
        Set(ByVal value As Object)
            m_word = value
            m_id = value.Id
            m_label = value.Lemma + "#" + value.Feat.Split(" "c)(0)
        End Set
    End Property

    Public Property Category() As Object
        Get
            Category = m_category
        End Get
        Set(ByVal value As Object)
            m_category = value
        End Set
    End Property

    Public Sub AddEdge(ByRef edg As clsEdge, Optional ByVal key As String = "")
        If key = "" Then
            m_edges.Add(edg)
        Else
            m_edges.Add(edg, key)
        End If
    End Sub

    Public Function Siblings(Optional ByVal dir As Integer = dirNone) As Collection
        Dim edg As clsEdge
        Siblings = New Collection
        Select Case dir
            Case dirNone
                For Each edg In m_edges
                    Siblings.Add(edg.Sibling(Me))
                Next edg
            Case dirForward
                For Each edg In m_edges
                    If edg.Source Is Me Then
                        Siblings.Add(edg.Target)
                    End If
                Next edg
            Case dirBackward
                For Each edg In m_edges
                    If edg.Target Is Me Then
                        Siblings.Add(edg.Source)
                    End If
                Next edg
        End Select
    End Function

    Public Function IsSibling(ByRef nod As clsNode) As Boolean
        Dim edg As clsEdge
        IsSibling = False
        For Each edg In m_edges
            If edg.Sibling(Me) Is nod Then
                IsSibling = True
                Exit For
            End If
        Next edg
    End Function
End Class


