<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstimation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstimation))
        Me.btnLoad = New System.Windows.Forms.Button
        Me.cmbNetworkType = New System.Windows.Forms.ComboBox
        Me.dgvUnsolvedProblems = New System.Windows.Forms.DataGridView
        Me.Problem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Estimation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbNetworkName = New System.Windows.Forms.TextBox
        Me.lbSubjectDomain = New System.Windows.Forms.ListBox
        Me.btnOpenDialog = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.tbFileName = New System.Windows.Forms.TextBox
        Me.gbLoadNetwork = New System.Windows.Forms.GroupBox
        Me.gbNetworks = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbUnused = New System.Windows.Forms.ListBox
        Me.lbUnsolvedProblem = New System.Windows.Forms.ListBox
        Me.lbSolvedProblem = New System.Windows.Forms.ListBox
        Me.gbEstimation = New System.Windows.Forms.GroupBox
        Me.btnEstimate = New System.Windows.Forms.Button
        CType(Me.dgvUnsolvedProblems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLoadNetwork.SuspendLayout()
        Me.gbNetworks.SuspendLayout()
        Me.gbEstimation.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(464, 64)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(100, 24)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Загрузить"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'cmbNetworkType
        '
        Me.cmbNetworkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNetworkType.FormattingEnabled = True
        Me.cmbNetworkType.Items.AddRange(New Object() {"Решенная задача", "Нерешенная задача", "Предметная область"})
        Me.cmbNetworkType.Location = New System.Drawing.Point(260, 65)
        Me.cmbNetworkType.Name = "cmbNetworkType"
        Me.cmbNetworkType.Size = New System.Drawing.Size(182, 24)
        Me.cmbNetworkType.TabIndex = 1
        '
        'dgvUnsolvedProblems
        '
        Me.dgvUnsolvedProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnsolvedProblems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Problem, Me.Estimation})
        Me.dgvUnsolvedProblems.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvUnsolvedProblems.Location = New System.Drawing.Point(23, 38)
        Me.dgvUnsolvedProblems.Name = "dgvUnsolvedProblems"
        Me.dgvUnsolvedProblems.ReadOnly = True
        Me.dgvUnsolvedProblems.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvUnsolvedProblems.RowTemplate.Height = 24
        Me.dgvUnsolvedProblems.Size = New System.Drawing.Size(245, 217)
        Me.dgvUnsolvedProblems.TabIndex = 6
        '
        'Problem
        '
        Me.Problem.HeaderText = "Задача"
        Me.Problem.Name = "Problem"
        Me.Problem.ReadOnly = True
        '
        'Estimation
        '
        Me.Estimation.HeaderText = "Оценка"
        Me.Estimation.Name = "Estimation"
        Me.Estimation.ReadOnly = True
        '
        'tbNetworkName
        '
        Me.tbNetworkName.Location = New System.Drawing.Point(26, 65)
        Me.tbNetworkName.Name = "tbNetworkName"
        Me.tbNetworkName.Size = New System.Drawing.Size(213, 22)
        Me.tbNetworkName.TabIndex = 7
        Me.tbNetworkName.Text = "Семантическая сеть"
        '
        'lbSubjectDomain
        '
        Me.lbSubjectDomain.AllowDrop = True
        Me.lbSubjectDomain.FormattingEnabled = True
        Me.lbSubjectDomain.ItemHeight = 16
        Me.lbSubjectDomain.Location = New System.Drawing.Point(71, 44)
        Me.lbSubjectDomain.Name = "lbSubjectDomain"
        Me.lbSubjectDomain.Size = New System.Drawing.Size(200, 196)
        Me.lbSubjectDomain.TabIndex = 8
        '
        'btnOpenDialog
        '
        Me.btnOpenDialog.Location = New System.Drawing.Point(464, 20)
        Me.btnOpenDialog.Name = "btnOpenDialog"
        Me.btnOpenDialog.Size = New System.Drawing.Size(100, 24)
        Me.btnOpenDialog.TabIndex = 9
        Me.btnOpenDialog.Text = "Открыть"
        Me.btnOpenDialog.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'tbFileName
        '
        Me.tbFileName.Enabled = False
        Me.tbFileName.Location = New System.Drawing.Point(26, 21)
        Me.tbFileName.Name = "tbFileName"
        Me.tbFileName.Size = New System.Drawing.Size(416, 22)
        Me.tbFileName.TabIndex = 10
        '
        'gbLoadNetwork
        '
        Me.gbLoadNetwork.Controls.Add(Me.tbFileName)
        Me.gbLoadNetwork.Controls.Add(Me.btnOpenDialog)
        Me.gbLoadNetwork.Controls.Add(Me.tbNetworkName)
        Me.gbLoadNetwork.Controls.Add(Me.cmbNetworkType)
        Me.gbLoadNetwork.Controls.Add(Me.btnLoad)
        Me.gbLoadNetwork.Location = New System.Drawing.Point(20, 483)
        Me.gbLoadNetwork.Name = "gbLoadNetwork"
        Me.gbLoadNetwork.Size = New System.Drawing.Size(574, 103)
        Me.gbLoadNetwork.TabIndex = 11
        Me.gbLoadNetwork.TabStop = False
        Me.gbLoadNetwork.Text = "Загрузка"
        '
        'gbNetworks
        '
        Me.gbNetworks.Controls.Add(Me.Label4)
        Me.gbNetworks.Controls.Add(Me.Label3)
        Me.gbNetworks.Controls.Add(Me.gbLoadNetwork)
        Me.gbNetworks.Controls.Add(Me.Label2)
        Me.gbNetworks.Controls.Add(Me.Label1)
        Me.gbNetworks.Controls.Add(Me.lbUnused)
        Me.gbNetworks.Controls.Add(Me.lbUnsolvedProblem)
        Me.gbNetworks.Controls.Add(Me.lbSolvedProblem)
        Me.gbNetworks.Controls.Add(Me.lbSubjectDomain)
        Me.gbNetworks.Location = New System.Drawing.Point(20, 12)
        Me.gbNetworks.Name = "gbNetworks"
        Me.gbNetworks.Size = New System.Drawing.Size(615, 600)
        Me.gbNetworks.TabIndex = 12
        Me.gbNetworks.TabStop = False
        Me.gbNetworks.Text = "Семантические сети"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(353, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Нерешенные задачи"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(108, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Неиспользуемые"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(353, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Решенные задчи"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Предметная область"
        '
        'lbUnused
        '
        Me.lbUnused.AllowDrop = True
        Me.lbUnused.ForeColor = System.Drawing.Color.Red
        Me.lbUnused.FormattingEnabled = True
        Me.lbUnused.ItemHeight = 16
        Me.lbUnused.Location = New System.Drawing.Point(71, 276)
        Me.lbUnused.Name = "lbUnused"
        Me.lbUnused.Size = New System.Drawing.Size(200, 196)
        Me.lbUnused.TabIndex = 12
        '
        'lbUnsolvedProblem
        '
        Me.lbUnsolvedProblem.AllowDrop = True
        Me.lbUnsolvedProblem.FormattingEnabled = True
        Me.lbUnsolvedProblem.ItemHeight = 16
        Me.lbUnsolvedProblem.Location = New System.Drawing.Point(332, 276)
        Me.lbUnsolvedProblem.Name = "lbUnsolvedProblem"
        Me.lbUnsolvedProblem.Size = New System.Drawing.Size(200, 196)
        Me.lbUnsolvedProblem.TabIndex = 11
        '
        'lbSolvedProblem
        '
        Me.lbSolvedProblem.AllowDrop = True
        Me.lbSolvedProblem.FormattingEnabled = True
        Me.lbSolvedProblem.ItemHeight = 16
        Me.lbSolvedProblem.Location = New System.Drawing.Point(332, 44)
        Me.lbSolvedProblem.Name = "lbSolvedProblem"
        Me.lbSolvedProblem.Size = New System.Drawing.Size(200, 196)
        Me.lbSolvedProblem.TabIndex = 10
        '
        'gbEstimation
        '
        Me.gbEstimation.Controls.Add(Me.btnEstimate)
        Me.gbEstimation.Controls.Add(Me.dgvUnsolvedProblems)
        Me.gbEstimation.Location = New System.Drawing.Point(662, 12)
        Me.gbEstimation.Name = "gbEstimation"
        Me.gbEstimation.Size = New System.Drawing.Size(496, 600)
        Me.gbEstimation.TabIndex = 13
        Me.gbEstimation.TabStop = False
        Me.gbEstimation.Text = "Оценка нерешенных задач"
        '
        'btnEstimate
        '
        Me.btnEstimate.Location = New System.Drawing.Point(390, 555)
        Me.btnEstimate.Name = "btnEstimate"
        Me.btnEstimate.Size = New System.Drawing.Size(100, 24)
        Me.btnEstimate.TabIndex = 7
        Me.btnEstimate.Text = "Оценить"
        Me.btnEstimate.UseVisualStyleBackColor = True
        '
        'frmEvaluation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1181, 628)
        Me.Controls.Add(Me.gbEstimation)
        Me.Controls.Add(Me.gbNetworks)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEvaluation"
        Me.Text = "Evaluation"
        CType(Me.dgvUnsolvedProblems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLoadNetwork.ResumeLayout(False)
        Me.gbLoadNetwork.PerformLayout()
        Me.gbNetworks.ResumeLayout(False)
        Me.gbNetworks.PerformLayout()
        Me.gbEstimation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents cmbNetworkType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvUnsolvedProblems As System.Windows.Forms.DataGridView
    Friend WithEvents Problem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estimation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbNetworkName As System.Windows.Forms.TextBox
    Friend WithEvents lbSubjectDomain As System.Windows.Forms.ListBox
    Friend WithEvents btnOpenDialog As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbFileName As System.Windows.Forms.TextBox
    Friend WithEvents gbLoadNetwork As System.Windows.Forms.GroupBox
    Friend WithEvents gbNetworks As System.Windows.Forms.GroupBox
    Friend WithEvents lbUnused As System.Windows.Forms.ListBox
    Friend WithEvents lbUnsolvedProblem As System.Windows.Forms.ListBox
    Friend WithEvents lbSolvedProblem As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbEstimation As System.Windows.Forms.GroupBox
    Friend WithEvents btnEstimate As System.Windows.Forms.Button

End Class
