<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEdges
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
        Me.dgvEdges = New System.Windows.Forms.DataGridView
        Me.clmId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmSource = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmTarget = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmWeight = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvEdges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvEdges
        '
        Me.dgvEdges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEdges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmId, Me.clmSource, Me.clmTarget, Me.clmWeight})
        Me.dgvEdges.Location = New System.Drawing.Point(1, 2)
        Me.dgvEdges.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvEdges.Name = "dgvEdges"
        Me.dgvEdges.RowTemplate.Height = 24
        Me.dgvEdges.Size = New System.Drawing.Size(594, 479)
        Me.dgvEdges.TabIndex = 0
        '
        'clmId
        '
        Me.clmId.HeaderText = "Id"
        Me.clmId.Name = "clmId"
        Me.clmId.ReadOnly = True
        Me.clmId.Width = 50
        '
        'clmSource
        '
        Me.clmSource.HeaderText = "Начальная вершина"
        Me.clmSource.Name = "clmSource"
        Me.clmSource.ReadOnly = True
        Me.clmSource.Width = 200
        '
        'clmTarget
        '
        Me.clmTarget.HeaderText = "Конечная вершина"
        Me.clmTarget.Name = "clmTarget"
        Me.clmTarget.ReadOnly = True
        Me.clmTarget.Width = 200
        '
        'clmWeight
        '
        Me.clmWeight.HeaderText = "Вес"
        Me.clmWeight.Name = "clmWeight"
        Me.clmWeight.ReadOnly = True
        '
        'frmEdges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 483)
        Me.Controls.Add(Me.dgvEdges)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmEdges"
        Me.Text = "frmEdge"
        CType(Me.dgvEdges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvEdges As System.Windows.Forms.DataGridView
    Friend WithEvents clmId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTarget As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmWeight As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
