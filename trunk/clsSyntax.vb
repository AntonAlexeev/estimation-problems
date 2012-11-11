Imports SolarixGrammarEngineNET
Imports System.Text

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
        Dim langID As Integer, hPack As Integer, hNode As Integer, hLeaf As Integer
        Dim i As Integer, j As Integer, r As Integer, l As Integer, minv As Integer, iGraf As Integer
        Dim net As New clsNetwork, buf As String
        On Error GoTo Exit_SyntaxAnalisis
        Select Case Language
            Case "eng"
                langID = GrammarEngineAPI.ENGLISH_LANGUAGE
            Case "rus"
                langID = GrammarEngineAPI.RUSSIAN_LANGUAGE
            Case Else
                GoTo Exit_SyntaxAnalisis
        End Select
        hPack = GrammarEngine.sol_SyntaxAnalysis( _
            hEngine, _
            Sentense, _
            MorfologicalFlags, _
            SyntacticFlags, _
            MaxTimeout, _
            langID)
        ' Выберем граф с минимальным количеством корневых узлов
        iGraf = -1 : minv = 2000000
        For i = 0 To GrammarEngine.sol_CountGrafs(hPack) - 1
            r = GrammarEngine.sol_CountRoots(hPack, i)
            If r < minv Then
                minv = r
                iGraf = i
            End If
        Next
        buf = ""
        For i = 0 To GrammarEngine.sol_CountRoots(hPack, iGraf) - 1
            hNode = GrammarEngine.sol_GetRoot(hPack, iGraf, i)
            TreversalTree(hNode, buf)
        Next
        MsgBox(buf)
Exit_SyntaxAnalisis:
        If hPack <> 0 Then
            GrammarEngine.sol_DeleteResPack(hPack)
        End If
        SyntaxAnalisis = net
    End Function

    Private Function TreversalTree(ByVal hNode As Integer, ByRef txt As String) As Boolean
        Dim hPack As Integer, hLeaf As Integer
        Dim i As Integer, l As Integer, buf As New StringBuilder
        On Error GoTo Exit_TreversalTree
        l = GrammarEngine.sol_CountLeafs(hNode)
        GrammarEngine.sol_GetNodeContents(hNode, buf)
        txt += buf.ToString
        If l > 0 Then
            For i = 0 To l - 1
                hLeaf = GrammarEngine.sol_GetLeaf(hNode, i)
                If Not TreversalTree(hLeaf, txt) Then
                    GoTo Exit_TreversalTree
                End If
            Next
        End If
        TreversalTree = True
        Exit Function
Exit_TreversalTree:
        TreversalTree = False
    End Function

    Protected Overrides Sub Finalize()
        GrammarEngine.sol_DeleteGrammarEngine(hEngine)
        MyBase.Finalize()
    End Sub
End Class
