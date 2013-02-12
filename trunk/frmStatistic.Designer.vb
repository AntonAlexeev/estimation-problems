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
        Me.tcStat = New System.Windows.Forms.TabControl
        Me.tpCommon = New System.Windows.Forms.TabPage
        Me.dgvCategory = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpNodes = New System.Windows.Forms.TabPage
        Me.dgvNodes = New System.Windows.Forms.DataGridView
        Me.tpEdges = New System.Windows.Forms.TabPage
        Me.dgvEdges = New System.Windows.Forms.DataGridView
        Me.clmNode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmCategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmFrequency = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmEdges = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvStat = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmSource = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmTarget = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmWeight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tcStat.SuspendLayout()
        Me.tpCommon.SuspendLayout()
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNodes.SuspendLayout()
        CType(Me.dgvNodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpEdges.SuspendLayout()
        CType(Me.dgvEdges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcStat
        '
        Me.tcStat.Controls.Add(Me.tpCommon)
        Me.tcStat.Controls.Add(Me.tpNodes)
        Me.tcStat.Controls.Add(Me.tpEdges)
        Me.tcStat.Location = New System.Drawing.Point(0, 0)
        Me.tcStat.Name = "tcStat"
        Me.tcStat.SelectedIndex = 0
        Me.tcStat.Size = New System.Drawing.Size(634, 460)
        Me.tcStat.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcStat.TabIndex = 3
        '
        'tpCommon
        '
        Me.tpCommon.Controls.Add(Me.dgvStat)
        Me.tpCommon.Controls.Add(Me.dgvCategory)
        Me.tpCommon.Location = New System.Drawing.Point(4, 22)
        Me.tpCommon.Name = "tpCommon"
        Me.tpCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCommon.Size = New System.Drawing.Size(626, 434)
        Me.tpCommon.TabIndex = 0
        Me.tpCommon.Text = "Общие"
        Me.tpCommon.UseVisualStyleBackColor = True
        '
        'dgvCategory
        '
        Me.dgvCategory.AllowUserToAddRows = False
        Me.dgvCategory.AllowUserToDeleteRows = False
        Me.dgvCategory.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCategory.ColumnHeadersVisible = False
        Me.dgvCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvCategory.Location = New System.Drawing.Point(-2, -2)
        Me.dgvCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvCategory.Name = "dgvCategory"
        Me.dgvCategory.ReadOnly = True
        Me.dgvCategory.RowHeadersVisible = False
        Me.dgvCategory.RowTemplate.Height = 24
        Me.dgvCategory.Size = New System.Drawing.Size(309, 438)
        Me.dgvCategory.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = ""
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'tpNodes
        '
        Me.tpNodes.Controls.Add(Me.dgvNodes)
        Me.tpNodes.Location = New System.Drawing.Point(4, 22)
        Me.tpNodes.Name = "tpNodes"
        Me.tpNodes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNodes.Size = New System.Drawing.Size(626, 434)
        Me.tpNodes.TabIndex = 1
        Me.tpNodes.Text = "Вершины"
        Me.tpNodes.UseVisualStyleBackColor = True
        '
        'dgvNodes
        '
        Me.dgvNodes.AllowUserToAddRows = False
        Me.dgvNodes.AllowUserToDeleteRows = False
        Me.dgvNodes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvNodes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmNode, Me.clmCategory, Me.clmFrequency, Me.clmEdges})
        Me.dgvNodes.Location = New System.Drawing.Point(-2, -2)
        Me.dgvNodes.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvNodes.Name = "dgvNodes"
        Me.dgvNodes.ReadOnly = True
        Me.dgvNodes.RowHeadersVisible = False
        Me.dgvNodes.RowTemplate.Height = 24
        Me.dgvNodes.Size = New System.Drawing.Size(632, 438)
        Me.dgvNodes.TabIndex = 2
        '
        'tpEdges
        '
        Me.tpEdges.Controls.Add(Me.dgvEdges)
        Me.tpEdges.Location = New System.Drawing.Point(4, 22)
        Me.tpEdges.Name = "tpEdges"
        Me.tpEdges.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEdges.Size = New System.Drawing.Size(626, 434)
        Me.tpEdges.TabIndex = 2
        Me.tpEdges.Text = "Отношения"
        Me.tpEdges.UseVisualStyleBackColor = True
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
        Me.dgvEdges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmSource, Me.clmTarget, Me.clmType, Me.clmWeight})
        Me.dgvEdges.Location = New System.Drawing.Point(-4, 0)
        Me.dgvEdges.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvEdges.Name = "dgvEdges"
        Me.dgvEdges.ReadOnly = True
        Me.dgvEdges.RowHeadersVisible = False
        Me.dgvEdges.RowTemplate.Height = 24
        Me.dgvEdges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEdges.Size = New System.Drawing.Size(634, 438)
        Me.dgvEdges.TabIndex = 2
        '
        'clmNode
        '
        Me.clmNode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmNode.HeaderText = "Вершина"
        Me.clmNode.MinimumWidth = 100
        Me.clmNode.Name = "clmNode"
        Me.clmNode.ReadOnly = True
        '
        'clmCategory
        '
        Me.clmCategory.HeaderText = "Часть речи"
        Me.clmCategory.Name = "clmCategory"
        Me.clmCategory.ReadOnly = True
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
        'dgvStat
        '
        Me.dgvStat.AllowUserToAddRows = False
        Me.dgvStat.AllowUserToDeleteRows = False
        Me.dgvStat.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvStat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStat.ColumnHeadersVisible = False
        Me.dgvStat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvStat.Location = New System.Drawing.Point(315, 0)
        Me.dgvStat.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvStat.Name = "dgvStat"
        Me.dgvStat.ReadOnly = True
        Me.dgvStat.RowHeadersVisible = False
        Me.dgvStat.RowTemplate.Height = 24
        Me.dgvStat.Size = New System.Drawing.Size(309, 438)
        Me.dgvStat.TabIndex = 4
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.HeaderText = ""
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = ""
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
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
        'clmType
        '
        Me.clmType.HeaderText = "Тип"
        Me.clmType.Name = "clmType"
        Me.clmType.ReadOnly = True
        Me.clmType.Width = 51
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
        'frmStatistic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 462)
        Me.Controls.Add(Me.tcStat)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximumSize = New System.Drawing.Size(650, 500)
        Me.MinimumSize = New System.Drawing.Size(650, 500)
        Me.Name = "frmStatistic"
        Me.Text = "Статистические данные"
        Me.tcStat.ResumeLayout(False)
        Me.tpCommon.ResumeLayout(False)
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNodes.ResumeLayout(False)
        CType(Me.dgvNodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpEdges.ResumeLayout(False)
        CType(Me.dgvEdges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcStat As System.Windows.Forms.TabControl
    Friend WithEvents tpCommon As System.Windows.Forms.TabPage
    Friend WithEvents tpNodes As System.Windows.Forms.TabPage
    Friend WithEvents tpEdges As System.Windows.Forms.TabPage
    Friend WithEvents dgvNodes As System.Windows.Forms.DataGridView
    Friend WithEvents dgvEdges As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCategory As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFrequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEdges As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvStat As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTarget As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmWeight As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
