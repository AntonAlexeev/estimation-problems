Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmChart

    Private Sub frmChart_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        chrLines.Width = Width
        chrLines.Height = Height
        chrLines.Left = 0
        chrLines.Top = 0
    End Sub

    Public Sub BarChart(ByVal data(,) As Object)
        Dim row As Integer, col As Integer, i As Integer, j As Integer, series() As Series, p As DataPoint
        row = data.GetLength(1) - 1
        col = data.GetLength(0) - 1
        chrLines.Series.Clear()
        chrLines.Titles.Clear()
        chrLines.Titles.Add("Оценка задач")
        chrLines.ChartAreas(0).AxisX.MajorGrid.LineWidth = 0
        chrLines.ChartAreas(0).AxisX.Interval = 1
        ReDim series(col - 1)
        For i = 1 To col
            series(i - 1) = chrLines.Series.Add(data(i, 0))
            For j = 1 To row
                series(i - 1).ChartType = SeriesChartType.Column
                p = series(i - 1).Points.Add(data(i, j))
                p.AxisLabel = data(0, j)
                p.Label = data(i, j)
            Next
        Next
    End Sub

    Public Sub LineChart(ByVal data(,) As Double, names() As String)
        Dim i As Integer, j As Integer, cnt As Integer, p As DataPoint
        Dim series As Series
        chrLines.Series.Clear()
        chrLines.Titles.Clear()
        chrLines.Titles.Add("Решение задач")
        chrLines.ChartAreas(0).AxisX.MajorGrid.LineWidth = 1
        chrLines.ChartAreas(0).AxisX.Interval = 10
        cnt = names.Length - 1
        For j = 0 To cnt
            series = chrLines.Series.Add(names(j))
            series.ChartType = SeriesChartType.Line
            series.BorderWidth = 2
            For i = 0 To cnt
                If data(i, j) > 0 Then
                    p = series.Points.Add(data(i, j))
                    p.ToolTip = data(i, j)
                End If
            Next
        Next
    End Sub
End Class