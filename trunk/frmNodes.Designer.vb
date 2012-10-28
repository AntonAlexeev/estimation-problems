<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNodes
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
        Me.dgvNodes = New System.Windows.Forms.DataGridView
        Me.clmId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmNode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmFrequency = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmEdges = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvNodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNodes
        '
        Me.dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmId, Me.clmNode, Me.clmFrequency, Me.clmEdges})
        Me.dgvNodes.Location = New System.Drawing.Point(-2, 0)
        Me.dgvNodes.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvNodes.Name = "dgvNodes"
        Me.dgvNodes.RowTemplate.Height = 24
        Me.dgvNodes.Size = New System.Drawing.Size(720, 488)
        Me.dgvNodes.TabIndex = 0
        '
        'clmId
        '
        Me.clmId.HeaderText = "Id"
        Me.clmId.Name = "clmId"
        Me.clmId.ReadOnly = True
        '
        'clmNode
        '
        Me.clmNode.HeaderText = "Вершина"
        Me.clmNode.Name = "clmNode"
        Me.clmNode.ReadOnly = True
        Me.clmNode.Width = 200
        '
        'clmFrequency
        '
        Me.clmFrequency.HeaderText = "Частота"
        Me.clmFrequency.Name = "clmFrequency"
        Me.clmFrequency.ReadOnly = True
        '
        'clmEdges
        '
        Me.clmEdges.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.clmEdges.HeaderText = "Связи"
        Me.clmEdges.Name = "clmEdges"
        Me.clmEdges.ReadOnly = True
        Me.clmEdges.Width = 63
        '
        'frmNodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 488)
        Me.Controls.Add(Me.dgvNodes)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmNodes"
        Me.Text = "frmNetwork"
        CType(Me.dgvNodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvNodes As System.Windows.Forms.DataGridView
    Friend WithEvents clmId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFrequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEdges As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
