Public Class frmRename
    Private Sub frmEstimation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbName.Text = ""
    End Sub

    Private Sub tbName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbName.KeyPress
        If e.KeyChar = Chr(13) Then
            Close()
        End If
    End Sub

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        Close()
    End Sub
End Class