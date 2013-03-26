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
        Me.dgvUnsolvedProblems = New System.Windows.Forms.DataGridView
        Me.Problem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Difficulty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Complexity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbSubjectDomain = New System.Windows.Forms.ListBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
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
        Me.clmDiff = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvUnsolvedProblems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNetworks.SuspendLayout()
        Me.gbEstimation.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUnsolvedProblems
        '
        Me.dgvUnsolvedProblems.AllowUserToAddRows = False
        Me.dgvUnsolvedProblems.AllowUserToDeleteRows = False
        Me.dgvUnsolvedProblems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvUnsolvedProblems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvUnsolvedProblems.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvUnsolvedProblems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUnsolvedProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnsolvedProblems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Problem, Me.Difficulty, Me.Complexity, Me.clmDiff})
        Me.dgvUnsolvedProblems.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvUnsolvedProblems.Location = New System.Drawing.Point(13, 36)
        Me.dgvUnsolvedProblems.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvUnsolvedProblems.Name = "dgvUnsolvedProblems"
        Me.dgvUnsolvedProblems.ReadOnly = True
        Me.dgvUnsolvedProblems.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvUnsolvedProblems.RowHeadersVisible = False
        Me.dgvUnsolvedProblems.RowTemplate.Height = 24
        Me.dgvUnsolvedProblems.Size = New System.Drawing.Size(390, 348)
        Me.dgvUnsolvedProblems.TabIndex = 6
        '
        'Problem
        '
        Me.Problem.HeaderText = "Задача"
        Me.Problem.Name = "Problem"
        Me.Problem.ReadOnly = True
        Me.Problem.Width = 68
        '
        'Difficulty
        '
        Me.Difficulty.HeaderText = "Трудность"
        Me.Difficulty.Name = "Difficulty"
        Me.Difficulty.ReadOnly = True
        Me.Difficulty.Width = 85
        '
        'Complexity
        '
        Me.Complexity.HeaderText = "Сложность"
        Me.Complexity.Name = "Complexity"
        Me.Complexity.ReadOnly = True
        Me.Complexity.Width = 88
        '
        'lbSubjectDomain
        '
        Me.lbSubjectDomain.AllowDrop = True
        Me.lbSubjectDomain.FormattingEnabled = True
        Me.lbSubjectDomain.Location = New System.Drawing.Point(18, 36)
        Me.lbSubjectDomain.Margin = New System.Windows.Forms.Padding(2)
        Me.lbSubjectDomain.Name = "lbSubjectDomain"
        Me.lbSubjectDomain.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSubjectDomain.Size = New System.Drawing.Size(151, 160)
        Me.lbSubjectDomain.TabIndex = 8
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        Me.OpenFileDialog.Filter = "UNL files (*.unl)|*.unl|All files (*.*)|*.*"
        Me.OpenFileDialog.Multiselect = True
        '
        'gbNetworks
        '
        Me.gbNetworks.Controls.Add(Me.Label4)
        Me.gbNetworks.Controls.Add(Me.Label3)
        Me.gbNetworks.Controls.Add(Me.Label2)
        Me.gbNetworks.Controls.Add(Me.Label1)
        Me.gbNetworks.Controls.Add(Me.lbUnused)
        Me.gbNetworks.Controls.Add(Me.lbUnsolvedProblem)
        Me.gbNetworks.Controls.Add(Me.lbSolvedProblem)
        Me.gbNetworks.Controls.Add(Me.lbSubjectDomain)
        Me.gbNetworks.Location = New System.Drawing.Point(15, 10)
        Me.gbNetworks.Margin = New System.Windows.Forms.Padding(2)
        Me.gbNetworks.Name = "gbNetworks"
        Me.gbNetworks.Padding = New System.Windows.Forms.Padding(2)
        Me.gbNetworks.Size = New System.Drawing.Size(367, 429)
        Me.gbNetworks.TabIndex = 12
        Me.gbNetworks.TabStop = False
        Me.gbNetworks.Text = "Семантические сети"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 208)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Нерешенные задачи"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(46, 208)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Неиспользуемые"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Решенные задчи"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Предметная область"
        '
        'lbUnused
        '
        Me.lbUnused.AllowDrop = True
        Me.lbUnused.ForeColor = System.Drawing.Color.Red
        Me.lbUnused.FormattingEnabled = True
        Me.lbUnused.Location = New System.Drawing.Point(18, 224)
        Me.lbUnused.Margin = New System.Windows.Forms.Padding(2)
        Me.lbUnused.Name = "lbUnused"
        Me.lbUnused.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbUnused.Size = New System.Drawing.Size(151, 160)
        Me.lbUnused.TabIndex = 12
        '
        'lbUnsolvedProblem
        '
        Me.lbUnsolvedProblem.AllowDrop = True
        Me.lbUnsolvedProblem.FormattingEnabled = True
        Me.lbUnsolvedProblem.Location = New System.Drawing.Point(195, 224)
        Me.lbUnsolvedProblem.Margin = New System.Windows.Forms.Padding(2)
        Me.lbUnsolvedProblem.Name = "lbUnsolvedProblem"
        Me.lbUnsolvedProblem.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbUnsolvedProblem.Size = New System.Drawing.Size(151, 160)
        Me.lbUnsolvedProblem.TabIndex = 11
        '
        'lbSolvedProblem
        '
        Me.lbSolvedProblem.AllowDrop = True
        Me.lbSolvedProblem.FormattingEnabled = True
        Me.lbSolvedProblem.Location = New System.Drawing.Point(195, 36)
        Me.lbSolvedProblem.Margin = New System.Windows.Forms.Padding(2)
        Me.lbSolvedProblem.Name = "lbSolvedProblem"
        Me.lbSolvedProblem.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSolvedProblem.Size = New System.Drawing.Size(151, 160)
        Me.lbSolvedProblem.TabIndex = 10
        '
        'gbEstimation
        '
        Me.gbEstimation.Controls.Add(Me.btnEstimate)
        Me.gbEstimation.Controls.Add(Me.dgvUnsolvedProblems)
        Me.gbEstimation.Location = New System.Drawing.Point(395, 10)
        Me.gbEstimation.Margin = New System.Windows.Forms.Padding(2)
        Me.gbEstimation.Name = "gbEstimation"
        Me.gbEstimation.Padding = New System.Windows.Forms.Padding(2)
        Me.gbEstimation.Size = New System.Drawing.Size(407, 429)
        Me.gbEstimation.TabIndex = 13
        Me.gbEstimation.TabStop = False
        Me.gbEstimation.Text = "Оценка нерешенных задач"
        '
        'btnEstimate
        '
        Me.btnEstimate.Location = New System.Drawing.Point(315, 388)
        Me.btnEstimate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEstimate.Name = "btnEstimate"
        Me.btnEstimate.Size = New System.Drawing.Size(75, 20)
        Me.btnEstimate.TabIndex = 7
        Me.btnEstimate.Text = "Оценить"
        Me.btnEstimate.UseVisualStyleBackColor = True
        '
        'clmDiff
        '
        Me.clmDiff.HeaderText = "Разность"
        Me.clmDiff.Name = "clmDiff"
        Me.clmDiff.ReadOnly = True
        Me.clmDiff.Width = 80
        '
        'frmEstimation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 452)
        Me.Controls.Add(Me.gbEstimation)
        Me.Controls.Add(Me.gbNetworks)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmEstimation"
        Me.Text = "Evaluation"
        CType(Me.dgvUnsolvedProblems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNetworks.ResumeLayout(False)
        Me.gbNetworks.PerformLayout()
        Me.gbEstimation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvUnsolvedProblems As System.Windows.Forms.DataGridView
    Friend WithEvents lbSubjectDomain As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
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
    Friend WithEvents Problem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Difficulty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Complexity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDiff As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
