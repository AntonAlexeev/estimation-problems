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
        Me.Difficulty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Complexity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbSubjectDomain = New System.Windows.Forms.ListBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
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
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnEstimate = New System.Windows.Forms.Button
        CType(Me.dgvUnsolvedProblems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLoadNetwork.SuspendLayout()
        Me.gbNetworks.SuspendLayout()
        Me.gbEstimation.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(304, 27)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(100, 25)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "���������"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'cmbNetworkType
        '
        Me.cmbNetworkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNetworkType.FormattingEnabled = True
        Me.cmbNetworkType.Items.AddRange(New Object() {"�������� ������", "���������� ������", "���������� �������"})
        Me.cmbNetworkType.Location = New System.Drawing.Point(27, 27)
        Me.cmbNetworkType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbNetworkType.Name = "cmbNetworkType"
        Me.cmbNetworkType.Size = New System.Drawing.Size(215, 24)
        Me.cmbNetworkType.TabIndex = 1
        '
        'dgvUnsolvedProblems
        '
        Me.dgvUnsolvedProblems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvUnsolvedProblems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvUnsolvedProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnsolvedProblems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Problem, Me.Difficulty, Me.Complexity})
        Me.dgvUnsolvedProblems.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvUnsolvedProblems.Location = New System.Drawing.Point(20, 44)
        Me.dgvUnsolvedProblems.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvUnsolvedProblems.Name = "dgvUnsolvedProblems"
        Me.dgvUnsolvedProblems.ReadOnly = True
        Me.dgvUnsolvedProblems.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvUnsolvedProblems.RowTemplate.Height = 24
        Me.dgvUnsolvedProblems.Size = New System.Drawing.Size(457, 428)
        Me.dgvUnsolvedProblems.TabIndex = 6
        '
        'Problem
        '
        Me.Problem.HeaderText = "������"
        Me.Problem.Name = "Problem"
        Me.Problem.ReadOnly = True
        Me.Problem.Width = 82
        '
        'Difficulty
        '
        Me.Difficulty.HeaderText = "���������"
        Me.Difficulty.Name = "Difficulty"
        Me.Difficulty.ReadOnly = True
        Me.Difficulty.Width = 102
        '
        'Complexity
        '
        Me.Complexity.HeaderText = "���������"
        Me.Complexity.Name = "Complexity"
        Me.Complexity.ReadOnly = True
        Me.Complexity.Width = 104
        '
        'lbSubjectDomain
        '
        Me.lbSubjectDomain.AllowDrop = True
        Me.lbSubjectDomain.FormattingEnabled = True
        Me.lbSubjectDomain.ItemHeight = 16
        Me.lbSubjectDomain.Location = New System.Drawing.Point(24, 44)
        Me.lbSubjectDomain.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lbSubjectDomain.Name = "lbSubjectDomain"
        Me.lbSubjectDomain.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSubjectDomain.Size = New System.Drawing.Size(200, 196)
        Me.lbSubjectDomain.TabIndex = 8
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        Me.OpenFileDialog.Filter = "UNL files (*.unl)|*.unl|All files (*.*)|*.*"
        Me.OpenFileDialog.Multiselect = True
        '
        'gbLoadNetwork
        '
        Me.gbLoadNetwork.Controls.Add(Me.cmbNetworkType)
        Me.gbLoadNetwork.Controls.Add(Me.btnLoad)
        Me.gbLoadNetwork.Location = New System.Drawing.Point(24, 482)
        Me.gbLoadNetwork.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLoadNetwork.Name = "gbLoadNetwork"
        Me.gbLoadNetwork.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLoadNetwork.Size = New System.Drawing.Size(461, 66)
        Me.gbLoadNetwork.TabIndex = 11
        Me.gbLoadNetwork.TabStop = False
        Me.gbLoadNetwork.Text = "��������"
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
        Me.gbNetworks.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbNetworks.Name = "gbNetworks"
        Me.gbNetworks.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbNetworks.Size = New System.Drawing.Size(507, 562)
        Me.gbNetworks.TabIndex = 12
        Me.gbNetworks.TabStop = False
        Me.gbNetworks.Text = "������������� ����"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(307, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "���������� ������"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(61, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "��������������"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(307, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "�������� �����"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "���������� �������"
        '
        'lbUnused
        '
        Me.lbUnused.AllowDrop = True
        Me.lbUnused.ForeColor = System.Drawing.Color.Red
        Me.lbUnused.FormattingEnabled = True
        Me.lbUnused.ItemHeight = 16
        Me.lbUnused.Location = New System.Drawing.Point(24, 276)
        Me.lbUnused.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lbUnused.Name = "lbUnused"
        Me.lbUnused.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbUnused.Size = New System.Drawing.Size(200, 196)
        Me.lbUnused.TabIndex = 12
        '
        'lbUnsolvedProblem
        '
        Me.lbUnsolvedProblem.AllowDrop = True
        Me.lbUnsolvedProblem.FormattingEnabled = True
        Me.lbUnsolvedProblem.ItemHeight = 16
        Me.lbUnsolvedProblem.Location = New System.Drawing.Point(285, 276)
        Me.lbUnsolvedProblem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lbUnsolvedProblem.Name = "lbUnsolvedProblem"
        Me.lbUnsolvedProblem.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbUnsolvedProblem.Size = New System.Drawing.Size(200, 196)
        Me.lbUnsolvedProblem.TabIndex = 11
        '
        'lbSolvedProblem
        '
        Me.lbSolvedProblem.AllowDrop = True
        Me.lbSolvedProblem.FormattingEnabled = True
        Me.lbSolvedProblem.ItemHeight = 16
        Me.lbSolvedProblem.Location = New System.Drawing.Point(285, 44)
        Me.lbSolvedProblem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lbSolvedProblem.Name = "lbSolvedProblem"
        Me.lbSolvedProblem.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSolvedProblem.Size = New System.Drawing.Size(200, 196)
        Me.lbSolvedProblem.TabIndex = 10
        '
        'gbEstimation
        '
        Me.gbEstimation.Controls.Add(Me.Button2)
        Me.gbEstimation.Controls.Add(Me.Button1)
        Me.gbEstimation.Controls.Add(Me.btnEstimate)
        Me.gbEstimation.Controls.Add(Me.dgvUnsolvedProblems)
        Me.gbEstimation.Location = New System.Drawing.Point(539, 12)
        Me.gbEstimation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbEstimation.Name = "gbEstimation"
        Me.gbEstimation.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbEstimation.Size = New System.Drawing.Size(496, 562)
        Me.gbEstimation.TabIndex = 13
        Me.gbEstimation.TabStop = False
        Me.gbEstimation.Text = "������ ���������� �����"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(46, 507)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(172, 509)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 28)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnEstimate
        '
        Me.btnEstimate.Location = New System.Drawing.Point(377, 523)
        Me.btnEstimate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEstimate.Name = "btnEstimate"
        Me.btnEstimate.Size = New System.Drawing.Size(100, 25)
        Me.btnEstimate.TabIndex = 7
        Me.btnEstimate.Text = "�������"
        Me.btnEstimate.UseVisualStyleBackColor = True
        '
        'frmEstimation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 591)
        Me.Controls.Add(Me.gbEstimation)
        Me.Controls.Add(Me.gbNetworks)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "frmEstimation"
        Me.Text = "Evaluation"
        CType(Me.dgvUnsolvedProblems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLoadNetwork.ResumeLayout(False)
        Me.gbNetworks.ResumeLayout(False)
        Me.gbNetworks.PerformLayout()
        Me.gbEstimation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents cmbNetworkType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvUnsolvedProblems As System.Windows.Forms.DataGridView
    Friend WithEvents lbSubjectDomain As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
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
    Friend WithEvents Problem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Difficulty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Complexity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class