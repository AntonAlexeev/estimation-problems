<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRename
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
        Me.tbName = New System.Windows.Forms.TextBox
        Me.btOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'tbName
        '
        Me.tbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbName.Location = New System.Drawing.Point(21, 21)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(283, 27)
        Me.tbName.TabIndex = 0
        '
        'btOk
        '
        Me.btOk.Location = New System.Drawing.Point(180, 59)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(124, 28)
        Me.btOk.TabIndex = 1
        Me.btOk.Text = "Переименовать"
        Me.btOk.UseVisualStyleBackColor = True
        '
        'frmRename
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btOk
        Me.ClientSize = New System.Drawing.Size(332, 105)
        Me.Controls.Add(Me.btOk)
        Me.Controls.Add(Me.tbName)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(350, 150)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 150)
        Me.Name = "frmRename"
        Me.Text = "Введите новое имя"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents btOk As System.Windows.Forms.Button
End Class
