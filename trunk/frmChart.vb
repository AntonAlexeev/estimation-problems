Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmChart
    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chrEstimation.Left = 0
        chrEstimation.Top = 0
    End Sub

    Private Sub frmChart_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        chrEstimation.Width = Width
        chrEstimation.Height = Height
    End Sub

    Public Sub BarChart(ByVal data(,) As Object)
        Dim row As Integer, col As Integer, i As Integer, j As Integer, series() As Series, p As DataPoint
        row = data.GetLength(1) - 1
        col = data.GetLength(0) - 1
        chrEstimation.Series.Clear()
        chrEstimation.Titles.Clear()
        chrEstimation.Titles.Add("Оценка задач")
        chrEstimation.ChartAreas(0).AxisX.MajorGrid.LineWidth = 0
        chrEstimation.ChartAreas(0).AxisX.Interval = 1
        ReDim series(col - 1)
        For i = 1 To col
            series(i - 1) = chrEstimation.Series.Add(data(i, 0))
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
        chrEstimation.Series.Clear()
        chrEstimation.Titles.Clear()
        chrEstimation.Titles.Add("Решение задач")
        chrEstimation.ChartAreas(0).AxisX.MajorGrid.LineWidth = 1
        chrEstimation.ChartAreas(0).AxisX.Interval = 10
        cnt = names.Length - 1
        For j = 0 To cnt
            series = chrEstimation.Series.Add(names(j))
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