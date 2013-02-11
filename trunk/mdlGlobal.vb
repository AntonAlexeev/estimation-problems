Module mdlGlobal
    Public Enum enDirection
        dirNone = 0
        dirForward = 1
        dirBackward = 2
    End Enum

    Public Enum enEdge
        edgWord = 0
        edgLFunction = 1
    End Enum

    Public Enum enCategory
        catNoun = 0     ' ��������������
        catAdj = 1      ' ��������������
        catVerb = 2     ' ������
        catAdv = 3      ' �������
        catNum = 4      ' ������������
        catExc = 5      ' �������
        catComp = 6     ' ��������
        catUnion = 7    ' ����
        catPart = 8     ' �������
        catSent = 9     ' �����-����������
        catInt = 10     ' ����������
        catFor = 11     ' ����������
    End Enum

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

    Public Structure strLFunction
        Public LFArg As String
        Public LFFunc As String
        Public LFVal As String
    End Structure
End Module
