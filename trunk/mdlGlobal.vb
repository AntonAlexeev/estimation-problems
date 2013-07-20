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
        catS = 1     ' Существительное
        catA = 2      ' Прилагательное
        catV = 3     ' глагол
        catAdv = 4      ' наречие
        catNum = 5      ' числительное
        catPr = 6      ' предлог
        catCom = 7     ' композит
        catConj = 8    ' союз
        catPart = 9     ' частица
        catP = 10     ' слово-предложени
        catIntj = 11     ' междометие
        catNid = 12     ' иноязычное
    End Enum

    Public arrCategory() As String = { _
        "", _
        "Существительное", _
        "Прилагательное", _
        "Глагол", _
        "Наречие", _
        "Числительное", _
        "Предлог", _
        "Композит", _
        "Союз", _
        "Частица", _
        "Слово-предложени", _
        "Междометие", _
        "Иноязычное" _
}

    Public arrEdges() As String = { _
        "Обычное", _
        "Лексическая функция", _
        "Фиктивное" _
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
