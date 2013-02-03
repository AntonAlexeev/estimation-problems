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
        Me.dgvEdges.AllowUserToAddRows = False
        Me.dgvEdges.AllowUserToDeleteRows = False
        Me.dgvEdges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEdges.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvEdges.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEdges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEdges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmId, Me.clmSource, Me.clmTarget, Me.clmWeight})
        Me.dgvEdges.Location = New System.Drawing.Point(0, 0)
        Me.dgvEdges.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvEdges.Name = "dgvEdges"
        Me.dgvEdges.ReadOnly = True
        Me.dgvEdges.RowHeadersVisible = False
        Me.dgvEdges.RowTemplate.Height = 24
        Me.dgvEdges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEdges.Size = New System.Drawing.Size(579, 500)
        Me.dgvEdges.TabIndex = 0
        '
        'clmId
        '
        Me.clmId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmId.HeaderText = "Id"
        Me.clmId.MinimumWidth = 50
        Me.clmId.Name = "clmId"
        Me.clmId.ReadOnly = True
        Me.clmId.Width = 50
        '
        'clmSource
        '
        Me.clmSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmSource.HeaderText = "Начальная вершина"
        Me.clmSource.MinimumWidth = 150
        Me.clmSource.Name = "clmSource"
        Me.clmSource.ReadOnly = True
        Me.clmSource.Width = 150
        '
        'clmTarget
        '
        Me.clmTarget.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmTarget.HeaderText = "Конечная вершина"
        Me.clmTarget.MinimumWidth = 150
        Me.clmTarget.Name = "clmTarget"
        Me.clmTarget.ReadOnly = True
        Me.clmTarget.Width = 150
        '
        'clmWeight
        '
        Me.clmWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmWeight.HeaderText = "Вес"
        Me.clmWeight.MinimumWidth = 50
        Me.clmWeight.Name = "clmWeight"
        Me.clmWeight.ReadOnly = True
        Me.clmWeight.Width = 51
        '
        'frmEdges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 527)
        Me.Controls.Add(Me.dgvEdges)
        Me.Margin = New System.Windows.Forms.Padding(2)
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
