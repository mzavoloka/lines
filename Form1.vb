Public Class Form1
    Dim N As Integer = 9
    Dim Graph As Graphics
    Dim i, j, x, y, c, score, GameOver As Integer
    Dim a, b, p, q, u, v, u1, v1, t1, t2, g, h, prom, nachalo(6), konets(6), z, w As Integer
    Dim Sqr(2 * N + 1, 2 * N + 1, 4) As Integer
    Dim Turn As Integer
    Dim Selected As Boolean
    Dim Selected_i, Selected_j As Integer
    Dim RedPen As New Pen(Color.Red, 2)
    Dim GreyPen As New Pen(Color.FromArgb(255, 136, 132, 136), 2)
    Dim WhitePen As New Pen(Color.FromArgb(255, 255, 255, 255), 2)
    Dim Time As Integer
    'Sqr (N, N, 1) (0 - пусто, 1 - занято)
    'Sqr (N, N, 2) (1 - маленький, 2 - большой)
    'Sqr (N, N, 3) (1 - blue, 2 - light-green, 3 - purple, 4 - red, 5 - turquoise, 6 - vinous, 7 - yellow)
    'Sqr (N, N, 4) (0 - не подлежит взрыву, 1 - подлежит взрыву)

    Public Sub Blow()
        For i = 1 To N
            For j = 1 To N
                'по вертикали
                If Sqr(i, j, 2) = 2 And Sqr(i, j + 1, 2) = 2 And Sqr(i, j, 3) = Sqr(i, j + 1, 3) Then
                    If nachalo(1) = 0 Then
                        nachalo(1) = j
                    End If
                    konets(1) = j + 1
                Else
                    If (konets(1) + 1 - nachalo(1)) >= 5 Then
                        score = score + (konets(1) + 1 - nachalo(1)) * 2 * 100
                        LScore.Text = "Score: " & Str(score)
                        For g = 0 To (konets(1) - nachalo(1))
                            Graph.DrawImage(My.Resources.Blank, (i - 1) * 45 + 1, (j - g - 1) * 45 + 1)
                            Sqr(i, j - g, 1) = 0
                            Sqr(i, j - g, 2) = 0
                            Sqr(i, j - g, 3) = 0
                        Next g
                    End If
                    nachalo(1) = 0
                    konets(1) = 0
                End If
                ' по горизонтали
                If Sqr(j, i, 2) = 2 And Sqr(j + 1, i, 2) = 2 And Sqr(j, i, 3) = Sqr(j + 1, i, 3) Then
                    If nachalo(2) = 0 Then
                        nachalo(2) = j
                    End If
                    konets(2) = j + 1
                Else
                    If (konets(2) + 1 - nachalo(2)) >= 5 Then
                        score = score + (konets(2) + 1 - nachalo(2)) * 2 * 100
                        LScore.Text = "Score: " & Str(score)
                        For g = 0 To (konets(2) - nachalo(2))
                            Graph.DrawImage(My.Resources.Blank, (j - g - 1) * 45 + 1, (i - 1) * 45 + 1)
                            Sqr(j - g, i, 1) = 0
                            Sqr(j - g, i, 2) = 0
                            Sqr(j - g, i, 3) = 0
                        Next g
                    End If
                    nachalo(2) = 0
                    konets(2) = 0
                End If
            Next
        Next
        'по диагонали сверху вниз
        For a = 0 To N - 5
            j = 1
            For i = 1 To N
                If Sqr(i + a, j, 2) = 2 And Sqr(i + a + 1, j + 1, 2) = 2 And Sqr(i + a, j, 3) = Sqr(i + a + 1, j + 1, 3) Then
                    If nachalo(3) = 0 Then
                        nachalo(3) = j
                    End If
                    konets(3) = j + 1
                Else
                    If (konets(3) + 1 - nachalo(3)) >= 5 Then
                        score = score + (konets(3) + 1 - nachalo(3)) * 2 * 100
                        LScore.Text = "Score: " & Str(score)
                        For g = 0 To (konets(3) - nachalo(3))
                            Graph.DrawImage(My.Resources.Blank, (i + a - g - 1) * 45 + 1, (j - g - 1) * 45 + 1)
                            Sqr(i + a - g, j - g, 1) = 0
                            Sqr(i + a - g, j - g, 2) = 0
                            Sqr(i + a - g, j - g, 3) = 0
                        Next g
                    End If
                    nachalo(3) = 0
                    konets(3) = 0
                End If
                If Sqr(i, j + a, 2) = 2 And Sqr(i + 1, j + a + 1, 2) = 2 And Sqr(i, j + a, 3) = Sqr(i + 1, j + a + 1, 3) Then
                    If nachalo(4) = 0 Then
                        nachalo(4) = i
                    End If
                    konets(4) = i + 1
                Else
                    If (konets(4) + 1 - nachalo(4)) >= 5 Then
                        score = score + (konets(4) + 1 - nachalo(4)) * 2 * 100
                        LScore.Text = "Score: " & Str(score)
                        For g = 0 To (konets(4) - nachalo(4))
                            Graph.DrawImage(My.Resources.Blank, (i - g - 1) * 45 + 1, (j + a - g - 1) * 45 + 1)
                            Sqr(i - g, j + a - g, 1) = 0
                            Sqr(i - g, j + a - g, 2) = 0
                            Sqr(i - g, j + a - g, 3) = 0
                        Next g
                    End If
                    nachalo(4) = 0
                    konets(4) = 0
                End If
                j = j + 1
            Next i
        Next a
        'по диагонали снизу вверх
        For a = 0 To N - 5
            j = N
            For i = 1 To N
                If Sqr(i + a, j, 2) = 2 And Sqr(i + a + 1, j - 1, 2) = 2 And Sqr(i + a, j, 3) = Sqr(i + a + 1, j - 1, 3) Then
                    If nachalo(5) = 0 Then
                        nachalo(5) = i
                    End If
                    konets(5) = i + 1
                Else
                    If (konets(5) + 1 - nachalo(5)) >= 5 Then
                        score = score + (konets(5) + 1 - nachalo(5)) * 2 * 100
                        LScore.Text = "Score: " & Str(score)
                        For g = 0 To (konets(5) - nachalo(5))
                            Graph.DrawImage(My.Resources.Blank, (i + a - g - 1) * 45 + 1, (j + g - 1) * 45 + 1)
                            Sqr(i + a - g, j + g, 1) = 0
                            Sqr(i + a - g, j + g, 2) = 0
                            Sqr(i + a - g, j + g, 3) = 0
                        Next g
                    End If
                    nachalo(5) = 0
                    konets(5) = 0
                End If
                j = j - 1
            Next i
        Next a

        For i = 1 To N
            For j = 1 To N
                Sqr(i + N, j + N, 1) = Sqr(i, j, 1)
                Sqr(i + N, j + N, 2) = Sqr(i, j, 2)
                Sqr(i + N, j + N, 3) = Sqr(i, j, 3)
            Next
        Next

        For a = 0 To N - 5
            j = N
            For i = 1 To N
                If Sqr(i + N, j + N - a, 2) = 2 And Sqr(i + N + 1, j + N - a - 1, 2) = 2 And Sqr(i + N, j + N - a, 3) = Sqr(i + N + 1, j + N - a - 1, 3) Then
                    If nachalo(6) = 0 Then
                        nachalo(6) = i
                    End If
                    konets(6) = i + 1
                Else
                    If (konets(6) + 1 - nachalo(6)) >= 5 Then
                        score = score + (konets(6) + 1 - nachalo(6)) * 2 * 100
                        LScore.Text = "Score: " & Str(score)
                        For g = 0 To (konets(6) - nachalo(6))
                            Graph.DrawImage(My.Resources.Blank, (i - g - 1) * 45 + 1, (j - a + g - 1) * 45 + 1)
                            Sqr(i - g, j - a + g, 1) = 0
                            Sqr(i - g, j - a + g, 2) = 0
                            Sqr(i - g, j - a + g, 3) = 0
                        Next g
                    End If
                    nachalo(6) = 0
                    konets(6) = 0
                End If
                j = j - 1
            Next i
        Next a
    End Sub

    Public Sub Grow()
        For i = 1 To N
            For j = 1 To N
                If Sqr(i, j, 1) = 1 And Sqr(i, j, 2) = 1 Then
                    Sqr(i, j, 2) = 2
                    Select Case Sqr(i, j, 3)
                        Case 1
                            Graph.DrawImage(My.Resources.Ball_Blue, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 2
                            Graph.DrawImage(My.Resources.Ball_Light_green, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 3
                            Graph.DrawImage(My.Resources.Ball_Purple, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 4
                            Graph.DrawImage(My.Resources.Ball_Red, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 5
                            Graph.DrawImage(My.Resources.Ball_Turquoise, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 6
                            Graph.DrawImage(My.Resources.Ball_Vinous, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 7
                            Graph.DrawImage(My.Resources.Ball_Yellow, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    End Select
                End If
            Next
        Next
    End Sub

    Public Sub MakeBigger()
        For i = 1 To N
            For j = 1 To N
                If Sqr(i, j, 2) = 1 Then
                    Select Case Sqr(i, j, 3)
                        Case 1
                            Graph.DrawImage(My.Resources.Ball_Blue, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 2
                            Graph.DrawImage(My.Resources.Ball_Light_green, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 3
                            Graph.DrawImage(My.Resources.Ball_Purple, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 4
                            Graph.DrawImage(My.Resources.Ball_Red, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 5
                            Graph.DrawImage(My.Resources.Ball_Turquoise, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 6
                            Graph.DrawImage(My.Resources.Ball_Vinous, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                        Case 7
                            Graph.DrawImage(My.Resources.Ball_Yellow, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    End Select
                    Sqr(i, j, 2) = 2
                End If
            Next j
        Next i
    End Sub

    Public Sub FirstTurn()
        Call BallAppears()
        Call MakeBigger()
        Call BallAppears()
    End Sub

    Public Sub MakeRandom()
        Randomize()
        i = Rnd() * (N - 1) + 1
        j = Rnd() * (N - 1) + 1
    End Sub
    Private Sub BallAppears()
        For c = 1 To 3
            Call MakeRandom()
            If Sqr(i, j, 1) = 0 Then
                Sqr(i, j, 2) = 1
                Sqr(i, j, 3) = Rnd() * 6 + 1
                Select Case Sqr(i, j, 3)
                    Case 1
                        Graph.DrawImage(My.Resources.Ball_Blue_Small, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    Case 2
                        Graph.DrawImage(My.Resources.Ball_Light_green_Small, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    Case 3
                        Graph.DrawImage(My.Resources.Ball_Purple_Small, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    Case 4
                        Graph.DrawImage(My.Resources.Ball_Red_Small, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    Case 5
                        Graph.DrawImage(My.Resources.Ball_Turquoise_Small, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    Case 6
                        Graph.DrawImage(My.Resources.Ball_Vinous_Small, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                    Case 7
                        Graph.DrawImage(My.Resources.Ball_Yellow_Small, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
                End Select
                p = i
                q = j
            End If
            If Sqr(i, j, 1) = 1 Then
                Do Until Sqr(i, j, 1) = 0
                    Call MakeRandom()
                    a = i
                    b = j
                Loop
                Sqr(a, b, 3) = Rnd() * 6 + 1
                Select Case Sqr(a, b, 3)
                    Case 1
                        Graph.DrawImage(My.Resources.Ball_Blue_Small, (a - 1) * 45 + 1, (b - 1) * 45 + 1)
                    Case 2
                        Graph.DrawImage(My.Resources.Ball_Light_green_Small, (a - 1) * 45 + 1, (b - 1) * 45 + 1)
                    Case 3
                        Graph.DrawImage(My.Resources.Ball_Purple_Small, (a - 1) * 45 + 1, (b - 1) * 45 + 1)
                    Case 4
                        Graph.DrawImage(My.Resources.Ball_Red_Small, (a - 1) * 45 + 1, (b - 1) * 45 + 1)
                    Case 5
                        Graph.DrawImage(My.Resources.Ball_Turquoise_Small, (a - 1) * 45 + 1, (b - 1) * 45 + 1)
                    Case 6
                        Graph.DrawImage(My.Resources.Ball_Vinous_Small, (a - 1) * 45 + 1, (b - 1) * 45 + 1)
                    Case 7
                        Graph.DrawImage(My.Resources.Ball_Yellow_Small, (a - 1) * 45 + 1, (b - 1) * 45 + 1)
                End Select
                Sqr(a, b, 1) = 1
                Sqr(a, b, 2) = 1
            End If
            Sqr(p, q, 1) = 1
        Next c
    End Sub

    Private Sub SetBoxSize(ByVal N)
        Box.Height = 45 * N + 1
        Box.Width = 45 * N + 1
    End Sub

    Public Sub DrawGrid(ByVal N As Integer)
        For i = 0 To N
            Graph.DrawLine(Pens.Black, 0, 45 * i, 45 * N, 45 * i)
            Graph.DrawLine(Pens.Black, 45 * i, 0, 45 * i, 45 * N)
        Next i
        For i = 0 To (N - 1)
            For j = 0 To (N - 1)
                Graph.DrawImage(My.Resources.Blank, i * 45 + 1, j * 45 + 1)
            Next j
        Next i
    End Sub

    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetBoxSize(N)
        Graph = Box.CreateGraphics
        For i = 1 To N
            For j = 1 To N
                Sqr(i, j, 1) = 0
                Sqr(i, j, 2) = 0
                Sqr(i, j, 3) = 0
            Next j
        Next i
        Turn = 0
        Selected = False
        Selected_i = 0
        Selected_j = 0
        Time = 0
        prom = 0
        For i = 1 To 6
            nachalo(i) = 0
            konets(i) = 0
        Next i
        score = 0
        GameOver = 0
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call DrawGrid(N)
        Call FirstTurn()
        Timer1.Enabled = False
    End Sub

    Private Sub Box_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Box.MouseMove
        x = e.Location.X
        y = e.Location.Y
        Label1.Text = x
        Label2.Text = y
    End Sub

    Private Sub Box_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Box.Click
        For i = 0 To (N - 1)
            For j = 0 To (N - 1)
                If (x > 45 * i) And (x < 45 * (i + 1)) And (y > 45 * j) And (y < 45 * (j + 1)) Then
                    Label3.Text = (i + 1) & ", " & (j + 1)
                    If i = Selected_i And j = Selected_j Then
                        Exit Sub
                    End If
                    If Sqr(i + 1, j + 1, 1) = 1 And Sqr(i + 1, j + 1, 2) = 2 And (Selected = False) Then
                        Graph.DrawLine(RedPen, i * 45 + 2, j * 45 + 2, (i + 1) * 45 - 1, j * 45 + 2)
                        Graph.DrawLine(RedPen, i * 45 + 2, j * 45 + 2, i * 45 + 2, (j + 1) * 45 - 1)
                        Graph.DrawLine(RedPen, (i + 1) * 45 - 1, j * 45 + 2, (i + 1) * 45 - 1, (j + 1) * 45 - 1)
                        Graph.DrawLine(RedPen, i * 45 + 2, (j + 1) * 45 - 1, (i + 1) * 45 - 1, (j + 1) * 45 - 1)
                        Selected = True
                        Selected_i = i
                        Selected_j = j
                        u = i
                        v = j
                        u1 = i
                        v1 = j
                        Exit For
                    End If
                    If (Sqr(i + 1, j + 1, 1) = 0 And Sqr(i + 1, j + 1, 2) = 0 And Sqr(i + 1, j + 1, 3) = 0 And Selected = True) Or _
                    (Sqr(i + 1, j + 1, 1) = 1 And Sqr(i + 1, j + 1, 2) = 1 And Selected = True) Then
                        Sqr(i + 1, j + 1, 1) = 1
                        Sqr(i + 1, j + 1, 2) = 2
                        Sqr(i + 1, j + 1, 3) = Sqr(u + 1, v + 1, 3)
                        Graph.DrawImage(My.Resources.Blank, u * 45 + 1, v * 45 + 1)
                        Select Case Sqr(u + 1, v + 1, 3)
                            Case 1
                                Graph.DrawImage(My.Resources.Ball_Blue, i * 45 + 1, j * 45 + 1)
                            Case 2
                                Graph.DrawImage(My.Resources.Ball_Light_green, i * 45 + 1, j * 45 + 1)
                            Case 3
                                Graph.DrawImage(My.Resources.Ball_Purple, i * 45 + 1, j * 45 + 1)
                            Case 4
                                Graph.DrawImage(My.Resources.Ball_Red, i * 45 + 1, j * 45 + 1)
                            Case 5
                                Graph.DrawImage(My.Resources.Ball_Turquoise, i * 45 + 1, j * 45 + 1)
                            Case 6
                                Graph.DrawImage(My.Resources.Ball_Vinous, i * 45 + 1, j * 45 + 1)
                            Case 7
                                Graph.DrawImage(My.Resources.Ball_Yellow, i * 45 + 1, j * 45 + 1)
                        End Select
                        Sqr(u + 1, v + 1, 1) = 0
                        Sqr(u + 1, v + 1, 2) = 0
                        Sqr(u + 1, v + 1, 3) = 0
                        u1 = i
                        v1 = j
                        Call Grow()
                        Call Blow()
                        Call BallAppears()
                        i = u1
                        j = v1
                        Selected = False
                        Selected_i = 0
                        Selected_j = 0
                    End If
                    If Sqr(i + 1, j + 1, 1) = 1 And Sqr(i + 1, j + 1, 2) = 2 And Selected = True Then
                        Graph.DrawLine(RedPen, i * 45 + 2, j * 45 + 2, (i + 1) * 45 - 1, j * 45 + 2)
                        Graph.DrawLine(RedPen, i * 45 + 2, j * 45 + 2, i * 45 + 2, (j + 1) * 45 - 1)
                        Graph.DrawLine(RedPen, (i + 1) * 45 - 1, j * 45 + 2, (i + 1) * 45 - 1, (j + 1) * 45 - 1)
                        Graph.DrawLine(RedPen, i * 45 + 2, (j + 1) * 45 - 1, (i + 1) * 45 - 1, (j + 1) * 45 - 1)
                        'Стирается прошлое выделение
                        Graph.DrawLine(WhitePen, u1 * 45 + 2, v1 * 45 + 2, (u1 + 1) * 45 - 1, v1 * 45 + 2)
                        Graph.DrawLine(WhitePen, u1 * 45 + 2, v1 * 45 + 2, u1 * 45 + 2, (v1 + 1) * 45 - 1)
                        Graph.DrawLine(GreyPen, (u1 + 1) * 45 - 1, v1 * 45 + 2, (u1 + 1) * 45 - 1, (v1 + 1) * 45 - 1)
                        Graph.DrawLine(GreyPen, u1 * 45 + 2, (v1 + 1) * 45 - 1, (u1 + 1) * 45 - 1, (v1 + 1) * 45 - 1)
                        Selected = True
                        Selected_i = i
                        Selected_j = j
                        u = i
                        v = j
                        u1 = i
                        v1 = j
                    End If
                End If
            Next j
        Next i
    End Sub

    Private Sub TimerGameOver_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGameOver.Tick
        For i = 1 To N
            For j = 1 To N
                If Sqr(i, j, 1) = 1 Then
                    GameOver = GameOver + 1
                End If
            Next
        Next
        If GameOver >= N * N Then
            Box.Enabled = False
            Call DrawGrid(N)
            Graph.DrawImage(My.Resources.GameOver_G, 0 * 45 + 1, 4 * 45 + 1)
            Graph.DrawImage(My.Resources.GameOver_A, 1 * 45 + 1, 4 * 45 + 1)
            Graph.DrawImage(My.Resources.GameOver_M, 2 * 45 + 1, 4 * 45 + 1)
            Graph.DrawImage(My.Resources.GameOver_E, 3 * 45 + 1, 4 * 45 + 1)
            Graph.DrawImage(My.Resources.GameOver_O, 5 * 45 + 1, 4 * 45 + 1)
            Graph.DrawImage(My.Resources.GameOver_V, 6 * 45 + 1, 4 * 45 + 1)
            Graph.DrawImage(My.Resources.GameOver_E, 7 * 45 + 1, 4 * 45 + 1)
            Graph.DrawImage(My.Resources.GameOver_R, 8 * 45 + 1, 4 * 45 + 1)
            GameOver = 0
            TimerGameOver.Enabled = False
            Exit Sub
        Else
            GameOver = 0
        End If
    End Sub

    Private Sub BNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNewGame.Click
        For i = 1 To N
            For j = 1 To N
                Sqr(i, j, 1) = 0
                Sqr(i, j, 2) = 0
                Sqr(i, j, 3) = 0
                Graph.DrawImage(My.Resources.Blank, (i - 1) * 45 + 1, (j - 1) * 45 + 1)
            Next
        Next
        Timer1.Enabled = True
        TimerGameOver.Enabled = True
        Box.Enabled = True
        score = 0
        LScore.Text = "Score: " & score
    End Sub
End Class


