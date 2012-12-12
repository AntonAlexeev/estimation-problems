Imports Microsoft.Glee

Public Class frmGlee
    Public Sub CreateView(ByRef net As clsNetwork)
        Dim n As clsNode, e As clsEdge, dn As Drawing.Node
        Dim viewer As GraphViewerGdi.GViewer = New GraphViewerGdi.GViewer()
        Dim graph As Drawing.Graph = New Microsoft.Glee.Drawing.Graph("graph")
        For Each e In net.GetEdges
            graph.AddEdge(e.Source.Id, e.Weight.ToString, e.Target.Id)
        Next
        For Each n In net.GetNodes
            dn = Nothing
            dn = graph.FindNode(n.Id)
            If dn Is Nothing Then
                dn = graph.AddNode(n.Id)
            End If
            dn.Attr.Label = n.Label
            dn.Attr.Fillcolor = Drawing.Color.LightBlue
            dn.Attr.Shape = Drawing.Shape.Ellipse
        Next
        viewer.Graph = graph
        Me.SuspendLayout()
        viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Controls.Add(viewer)
        Me.ResumeLayout()
        Me.ShowDialog()
    End Sub
End Class