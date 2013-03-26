Imports Microsoft.Glee.GraphViewerGdi
Imports Microsoft.Glee.Drawing
Imports System.Windows
Imports EstimationTasks.mdlGlobal.enEdge

Public Class frmGlee
    Private viewer As GViewer

    Public Sub CreateView(ByRef net As clsNetwork)
        Dim n As clsNode, e As clsEdge, dn As Node, de As Edge
        Dim graph As Graph
        viewer = New GViewer()
        graph = New Graph("graph")
        Me.Controls.Clear()
        For Each e In net.GetEdges
            de = graph.AddEdge(e.Source.Id, e.Target.Id)
            Select Case e.Type
                Case edgWord
                    de.Attr.Label = e.Weight.ToString
                    de.Attr.Color = Color.DarkBlue
                Case edgLFunction
                    de.Attr.Label = e.LFunction.LFFunc
                    de.Attr.Color = Color.Orange
                Case edgFictit
                    de.Attr.Label = e.Weight.ToString
                    de.Attr.Color = Color.Red
            End Select
        Next
        For Each n In net.GetNodes
            dn = Nothing
            dn = graph.FindNode(n.Id)
            If dn Is Nothing Then
                dn = graph.AddNode(n.Id)
            End If
            dn.Attr.Label = n.Label
            dn.Attr.Fillcolor = Color.LightBlue
            dn.Attr.Shape = Shape.Ellipse
        Next
        viewer.Graph = graph
        Me.SuspendLayout()
        viewer.Dock = Forms.DockStyle.Fill
        Me.Controls.Add(viewer)
        Me.ResumeLayout()
        Me.ShowDialog()
    End Sub

    Private Sub frmGlee_Close(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'viewer.Graph = Nothing
        viewer.Refresh()
        viewer = Nothing
    End Sub
End Class