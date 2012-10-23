<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNetwork
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvNetowrk = New System.Windows.Forms.DataGridView
        Me.clmNode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmEdges = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvNetowrk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNetowrk
        '
        Me.dgvNetowrk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNetowrk.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmNode, Me.clmEdges})
        Me.dgvNetowrk.Location = New System.Drawing.Point(-2, 0)
        Me.dgvNetowrk.Name = "dgvNetowrk"
        Me.dgvNetowrk.RowTemplate.Height = 24
        Me.dgvNetowrk.Size = New System.Drawing.Size(1099, 600)
        Me.dgvNetowrk.TabIndex = 0
        '
        'clmNode
        '
        Me.clmNode.HeaderText = "Вершина"
        Me.clmNode.Name = "clmNode"
        Me.clmNode.ReadOnly = True
        Me.clmNode.Width = 200
        '
        'clmEdges
        '
        Me.clmEdges.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.clmEdges.HeaderText = "Связи"
        Me.clmEdges.Name = "clmEdges"
        Me.clmEdges.ReadOnly = True
        Me.clmEdges.Width = 72
        '
        'frmNetwork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 600)
        Me.Controls.Add(Me.dgvNetowrk)
        Me.Name = "frmNetwork"
        Me.Text = "frmNetwork"
        CType(Me.dgvNetowrk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvNetowrk As System.Windows.Forms.DataGridView
    Friend WithEvents clmNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEdges As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
