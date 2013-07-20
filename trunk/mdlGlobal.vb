Module mdlGlobal
    Public Enum enDirection
        dirNone = 0
        dirForward = 1
        dirBackward = 2
    End Enum

    Public Enum enEdge
        edgWord = 0
        edgLFunction = 1
        edgFictit = 2
    End Enum

    Public Enum enCategory
        catS = 1     ' ���������������
        catA = 2      ' ��������������
        catV = 3     ' ������
        catAdv = 4      ' �������
        catNum = 5      ' ������������
        catPr = 6      ' �������
        catCom = 7     ' ��������
        catConj = 8    ' ����
        catPart = 9     ' �������
        catP = 10     ' �����-����������
        catIntj = 11     ' ����������
        catNid = 12     ' ����������
    End Enum

    Public arrCategory() As String = { _
        "", _
        "���������������", _
        "��������������", _
        "������", _
        "�������", _
        "������������", _
        "�������", _
        "��������", _
        "����", _
        "�������", _
        "�����-����������", _
        "����������", _
        "����������" _
}

    Public arrEdges() As String = { _
        "�������", _
        "����������� �������", _
        "���������" _
}

    Public Structure strEstimation
        Private dif As Double
        Private SD As Double
        Private SP As Double
        Public ReadOnly Property Difficulty() As Double
            Get
                Difficulty = dif
            End Get
        End Property
        Public Property SDComplexity() As Double
            Get
                SDComplexity = SD
            End Get
            Set(ByVal value As Double)
                SD = value
                dif = IIf(SD - SP > 0, SD - SP, 0)
            End Set
        End Property
        Public Property SPComplexity() As Double
            Get
                SPComplexity = SP
            End Get
            Set(ByVal value As Double)
                SP = value
                dif = IIf(SD - SP > 0, SD - SP, 0)
            End Set
        End Property
    End Structure

    Public Structure strWord
        Public Id As String
        Public Lemma As String
        Public Link As String
        Public Dom As String
        Public Feat As String
    End Structure

    Public Sub AddRow(ByRef dgv As DataGridView, ByVal val() As Object)
        Dim dgvRow As DataGridViewRow, dgvCell As DataGridViewCell, s As Object
        dgvRow = New DataGridViewRow
        For Each s In val
            dgvCell = New DataGridViewTextBoxCell()
            Select Case s.GetType.Name
                Case "Int32"
                    dgvCell.Value = Convert.ToInt32(s)
                Case "Double"
                    dgvCell.Value = Convert.ToDouble(s)
                Case Else
                    dgvCell.Value = s.ToString
            End Select
            dgvRow.Cells.Add(dgvCell)
        Next
        dgv.Rows.Add(dgvRow)
    End Sub
End Module
