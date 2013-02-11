<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistic
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatistic))
        Me.dgvEdges = New System.Windows.Forms.DataGridView
        Me.dgvNodes = New System.Windows.Forms.DataGridView
        Me.clmSource = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmTarget = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmWeight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmNode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmFrequency = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmEdges = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvEdges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvEdges
        '
        Me.dgvEdges.AllowUserToAddRows = False
        Me.dgvEdges.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dgvEdges.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEdges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEdges.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvEdges.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEdges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEdges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmSource, Me.clmTarget, Me.clmWeight})
        Me.dgvEdges.Location = New System.Drawing.Point(0, 0)
        Me.dgvEdges.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvEdges.Name = "dgvEdges"
        Me.dgvEdges.ReadOnly = True
        Me.dgvEdges.RowHeadersVisible = False
        Me.dgvEdges.RowTemplate.Height = 24
        Me.dgvEdges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEdges.Size = New System.Drawing.Size(355, 450)
        Me.dgvEdges.TabIndex = 0
        '
        'dgvNodes
        '
        Me.dgvNodes.AllowUserToAddRows = False
        Me.dgvNodes.AllowUserToDeleteRows = False
        Me.dgvNodes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvNodes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmNode, Me.clmFrequency, Me.clmEdges})
        Me.dgvNodes.Location = New System.Drawing.Point(359, 0)
        Me.dgvNodes.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvNodes.Name = "dgvNodes"
        Me.dgvNodes.ReadOnly = True
        Me.dgvNodes.RowHeadersVisible = False
        Me.dgvNodes.RowTemplate.Height = 24
        Me.dgvNodes.Size = New System.Drawing.Size(370, 450)
        Me.dgvNodes.TabIndex = 1
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
        'clmNode
        '
        Me.clmNode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmNode.HeaderText = "Вершина"
        Me.clmNode.MinimumWidth = 100
        Me.clmNode.Name = "clmNode"
        Me.clmNode.ReadOnly = True
        '
        'clmFrequency
        '
        Me.clmFrequency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmFrequency.HeaderText = "Частота"
        Me.clmFrequency.Name = "clmFrequency"
        Me.clmFrequency.ReadOnly = True
        Me.clmFrequency.Width = 74
        '
        'clmEdges
        '
        Me.clmEdges.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.clmEdges.HeaderText = "Связи"
        Me.clmEdges.Name = "clmEdges"
        Me.clmEdges.ReadOnly = True
        Me.clmEdges.Width = 63
        '
        'frmStatistic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 462)
        Me.Controls.Add(Me.dgvNodes)
        Me.Controls.Add(Me.dgvEdges)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmStatistic"
        Me.Text = "Статистические данные"
        CType(Me.dgvEdges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvEdges As System.Windows.Forms.DataGridView
    Friend WithEvents dgvNodes As System.Windows.Forms.DataGridView
    Friend WithEvents clmSource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTarget As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFrequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEdges As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
