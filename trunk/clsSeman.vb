Imports SEMANLib
Imports AGRAMTABLib
Imports GRAPHANLib
Imports LEMMATIZERLib
Imports MAPOSTLib
Imports STRUCTDICTLib
Imports SYNANLib

Public Class clsSeman
    Private RusGramTab As New RusGramTab

    Public Function Test() As Long
        Dim Seman As New SemStructure
        RusGramTab.Load()
        Seman.InitPresemanDicts()
        Seman.InitSemanDicts()
        Seman.InitializeIndices()
        Seman.ShouldBuildTclGraph = False
        Test = 0
    End Function
End Class
