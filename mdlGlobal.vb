Module mdlGlobal
    Public Enum Direction
        dirNone = 0
        dirForward = 1
        dirBackward = 2
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
End Module
