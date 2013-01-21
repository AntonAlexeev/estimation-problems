Imports Microsoft.Glee.GraphViewerGdi
Imports Microsoft.Glee.Drawing
Imports System.Windows
Imports EstimationTasks.mdlGlobal.enEdge

Public Class frmGlee
    Public Sub CreateView(ByRef net As clsNetwork)
        Dim n As clsNode, e As clsEdge, dn As Node, de As Edge
        Dim viewer As GViewer = New GViewer()
        Dim graph As Graph = New Graph("graph")
        Me.Controls.Clear()
        For Each e In net.GetEdges
            de = graph.AddEdge(e.Source.Id, e.Target.Id)
            Select Case e.Type
                Case edgWord
                    de.Attr.Label = e.Weight.ToString
                    de.Attr.Color = Color.DarkBlue
                Case edgLFunction
                    de.Attr.Label = e.LFunction.LFFunc
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
End Class