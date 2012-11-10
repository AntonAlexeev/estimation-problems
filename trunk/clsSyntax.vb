Imports SolarixGrammarEngineNET

Public Class clsSyntax
    Private hEngine As Integer

    Public Function CreateGrammarEngine(ByVal Dictionary As String) As Boolean
        hEngine = 0
        hEngine = GrammarEngine.sol_CreateGrammarEngineW(Dictionary)
        CreateGrammarEngine = IIf(hEngine = 0, False, True)
    End Function

    Public Function DictionaryVersion() As Integer
        DictionaryVersion = GrammarEngine.sol_DictionaryVersion(hEngine)
    End Function

    Public Function SyntaxAnalisis( _
        ByVal Sentense As String, _
        ByVal Language As String, _
        Optional ByVal MorfologicalFlags As Integer = 0, _
        Optional ByVal SyntacticFlags As Integer = 0, _
        Optional ByVal MaxTimeout As Integer = 60000 _
    ) As clsNetwork
        Dim langID As Integer, hPack As Integer
        Dim i As Integer, n As Integer, minv As Integer, imin As Integer
        Dim net As New clsNetwork
        On Error GoTo Error_SyntaxAnalisis
        Select Case Language
            Case "eng"
                langID = GrammarEngineAPI.ENGLISH_LANGUAGE
            Case "rus"
                langID = GrammarEngineAPI.RUSSIAN_LANGUAGE
            Case Else
                GoTo Error_SyntaxAnalisis
        End Select
        hPack = GrammarEngine.sol_SyntaxAnalysis( _
            hEngine, _
            Sentense, _
            MorfologicalFlags, _
            SyntacticFlags, _
            MaxTimeout, _
            langID)
        ' Выберем граф с минимальным количеством корневых узлов
        imin = -1 : minv = 2000000
        For i = 0 To GrammarEngine.sol_CountGrafs(hPack) - 1
            n = GrammarEngine.sol_CountRoots(hPack, i)
            If n < minv Then
                minv = n
                imin = i
            End If
        Next
        For i = 0 To GrammarEngine.sol_CountRoots(hPack, imin) - 1
            'IntPtr hNode = GrammarEngine.sol_GetRoot(hPack, imin_graf, j);
            'PrintNode(hNode);
        Next
Error_SyntaxAnalisis:
        SyntaxAnalisis = net
    End Function

    Protected Overrides Sub Finalize()
        GrammarEngine.sol_DeleteGrammarEngine(hEngine)
        MyBase.Finalize()
    End Sub
End Class
