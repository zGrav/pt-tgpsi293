Public Class Form2
    Const side As Integer = 100
    Const exptab As Integer = 15
    Const pad As Integer = 5
    Dim trade As Boolean
    Public plays As Integer
    Public board(2, 2) As Integer
    Public data As GameData
    Dim images As Image
    Public ingame As Boolean = False
    Dim timercount As Integer = 10
    Public wins As Boolean = False

    Public Structure Line
        Public P1, P2, P3 As Point
        Sub New(ByVal p1 As Point, ByVal p2 As Point, ByVal p3 As Point)
            Me.P1 = p1
            Me.P2 = p2
            Me.P3 = p3
        End Sub
    End Structure
    Public win As List(Of Line)

    Public Enum Player
        Player1 = 1
        Player2 = 10
    End Enum
    Public Structure GameData
        Public p1 As String
        Public p2 As String
        Public firsttoplay As Boolean
        Public timedplay As Boolean
        Public p1piece As String
        Public p2piece As String
        Public theme As String
    End Structure
    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim p As New Pen(Color.Black, 3)
        ' Vertical
        'e.Graphics.DrawLine(p, 100, 19, 100, 310)
        'e.Graphics.DrawLine(p, 215, 19, 215, 310)
        ' Horizontal
        'e.Graphics.DrawLine(p, 19, 100, 310, 100)
        'e.Graphics.DrawLine(p, 19, 215, 310, 215)

        'e.Graphics.DrawEllipse(p, 5, 5, 90, 90)

        'e.Graphics.DrawLine(p, 5, 5, 90, 90)
        'e.Graphics.DrawLine(p, 90, 5, 5, 90)

        'e.Graphics.DrawEllipse(p, 115, 10, 85, 75)

        ' Dim trade As Boolean
        'Dim origem As New Point(5, 5)
        'Dim posX As Integer = 2, posY As Integer = 1
        'Dim rect As New Rectangle(0, 0, 90, 90)
        'For i As Integer = 0 To 2
        '    For j As Integer = 0 To 2
        '        rect = New Rectangle(0, 0, 90, 90)
        '        rect.Offset(i * 115, j * 115)
        '        If trade Then
        '            e.Graphics.DrawEllipse(p, rect)
        '        Else
        '            'e.Graphics.DrawLine(p, rect.X, rect.Y, rect.Width, rect.Height)
        '            e.Graphics.DrawLine(p, rect.Height, rect.Width, rect.X, rect.Y)
        '            'e.Graphics.DrawEllipse(p, rect.Width, rect.Y, rect.Height, rect.X)
        '        End If
        '        trade = Not trade

        '    Next
        'Next

        'p.Dispose()


        'rect.Offset(posX * 115, posY * 115)

        'e.Graphics.DrawEllipse(p, rect)

        'p.Dispose()


        ' 02-11

        'For i As Integer = 0 To 2
        '    For j As Integer = 0 To 2
        '        If trade Then
        '            'desenha cruz
        '            desenha_cruz(e.Graphics, New Point(0 + i * side + exptab, 0 + j * side + exptab), side)
        '        Else
        '            'desenha bola
        '            desenha_bola(e.Graphics, New Point(0 + i * side + exptab, 0 + j * side + exptab), side)
        '        End If
        '        trade = Not trade
        '    Next
        'Next


        ' 03-11
        'draw board

        ' Vertical

        'e.Graphics.DrawLine(Pens.Black, side + exptab \ 2, 0, side + exptab \ 2, side * 3 + exptab * 2)
        'e.Graphics.DrawLine(Pens.Black, 9 + side * 2 + exptab \ 2, 0, 9 + side * 2 + exptab \ 2, side * 3 + exptab * 2)
        'e.Graphics.DrawLine(Pens.Black, (9 + (side * 2)) + exptab \ 2, 0, (9 + (side * 2)) + exptab \ 2, side * 3 + exptab * 2)

        e.Graphics.DrawLine(p, 2 * pad + 1 * side, 0, 2 * pad + 1 * side, 6 * pad + 3 * side)
        e.Graphics.DrawLine(p, 4 * pad + 2 * side, 0, 4 * pad + 2 * side, 6 * pad + 3 * side)


        ' Horizontal
        e.Graphics.DrawLine(p, 0, 2 * pad + 1 * side, 6 * pad + 3 * side, 2 * pad + 1 * side)
        e.Graphics.DrawLine(p, 0, 4 * pad + 2 * side, 6 * pad + 3 * side, 4 * pad + 2 * side)

        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                If board(i, j) <> 0 Then
                    If board(i, j) = Player.Player1 Then
                        If data.p1piece = "Cross" Or data.p1piece = "Space Shuttle" Then
                            draw_x(e.Graphics, New Point((2 * i + 1) * pad + i * side, (2 * j + 1) * pad + j * side), side)
                        Else
                            draw_o(e.Graphics, New Point((2 * i + 1) * pad + i * side, (2 * j + 1) * pad + j * side), side)
                        End If
                    Else
                        If data.p2piece = "Cross" Or data.p2piece = "Space Shuttle" Then
                            draw_x(e.Graphics, New Point((2 * i + 1) * pad + i * side, (2 * j + 1) * pad + j * side), side)
                        Else
                            draw_o(e.Graphics, New Point((2 * i + 1) * pad + i * side, (2 * j + 1) * pad + j * side), side)
                        End If
                    End If
                End If
            Next
        Next
        p.Dispose()
    End Sub
    Sub draw_x(ByVal g As Graphics, ByVal p As Point, ByVal side As Integer)
        'g.DrawLine(Pens.Green, p.X, p.Y, p.X + side, p.Y + side)
        'g.DrawLine(Pens.Green, p.X + side, p.Y, p.X, p.Y + side)
        If data.p1piece = "Cross" Or data.p2piece = "Cross" Then
            g.DrawImage(My.Resources.X, p.X, p.Y, side, side)
        End If
        If data.p1piece = "Space Shuttle" Or data.p2piece = "Space Shuttle" Then
            g.DrawImage(My.Resources.space_shuttle_icon, p.X, p.Y, side, side)
        End If
    End Sub
    Sub draw_o(ByVal g As Graphics, ByVal p As Point, ByVal side As Integer)
        'g.DrawEllipse(Pens.Red, p.X, p.Y, side, side)
        If data.p1piece = "Circle" Or data.p2piece = "Circle" Then
            g.DrawImage(My.Resources.O, p.X, p.Y, side, side)
        End If
        If data.p1piece = "Astronaut" Or data.p2piece = "Astronaut" Then
            g.DrawImage(My.Resources.astronaut_icon, p.X, p.Y, side, side)
        End If
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        'Dim g As Graphics = Panel1.CreateGraphics
        'Me.Text = e.X.ToString & ":" & e.Y.ToString()
        Dim np As Point = pixeltotab(New Point(e.X, e.Y), side)
        'Me.Text += "|" & np.X.ToString() & ":" & np.Y.ToString()
        'If trade Then
        '    'draw X
        '    draw_x(g, New Point(0 + np.X * side + exptab, 0 + np.Y * side + exptab), side)

        'Else
        '    'draw O
        '    draw_o(g, New Point(0 + np.X * side + exptab, 0 + np.Y * side + exptab), side)

        'End If
        Try
            If Not ingame Then
                If MsgBox("Do you want to start a new game?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    NewToolStripMenuItem.PerformClick()
                    ingame = True
                End If



            Else

                'so joga na  pos nao jogada
                If board(np.X, np.Y) = Player.Player1 Or board(np.X, np.Y) = Player.Player2 Then
                    GameLabel.Text = "Unable to play there."
                    Exit Sub
                End If
                plays += 1
                'trade = Not trade
                'mostrAR VEZ de quem joga
                If plays Mod 2 = 0 Then

                    board(np.X, np.Y) = Player.Player1
                    '  playerlabel.Text = "It's " & data.p1 & " turn"
                Else
                    board(np.X, np.Y) = Player.Player2
                    ' playerlabel.Text = "It's " & data.p2 & " turn"
                End If


                'If plays = 9 Then
                '    GameLabel.Text = "Game is over."
                '    If MsgBox("Game is over, do you want to start a new game?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '        NewToolStripMenuItem.PerformClick()
                '    Else
                '        ingame = False
                '    End If
                If plays >= 5 Then
                    For Each Line In win
                        Dim r As Integer = board(Line.P1.X, Line.P1.Y) + board(Line.P2.X, Line.P2.Y) + board(Line.P3.X, Line.P3.Y)
                        If r = 3 Then
                            MsgBox(data.p1 & " wins")
                            playerlabel.Text = ""
                            GameLabel.Text = "Game is over."
                            ingame = False
                            wins = True
                            Exit For
                        ElseIf r = 30 Then
                            MsgBox(data.p2 & " wins")
                            playerlabel.Text = ""
                            GameLabel.Text = "Game is over."
                            ingame = False
                            wins = True
                            Exit For
                        End If
                    Next
                End If

                If plays > 8 Then
                    wins = False
                    ingame = False
                    GameLabel.Text = "Game is over."
                    playerlabel.Text = ""
                    If MsgBox("Tie. Do you want to start a new game?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        NewToolStripMenuItem.PerformClick()
                    Else
                        Exit Sub
                    End If
                End If


            End If
            timercount = 10
        Catch ex As System.IndexOutOfRangeException
            Exit Sub
        End Try
        Refresh()
        'g.Dispose()
    End Sub

    'Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
    '    Me.Text = e.X.ToString & ":" & e.Y.ToString()
    ' End Sub

    Function pixeltotab(ByVal p As Point, ByVal side As Integer) As Point
        Dim np As New Point
        'Invalidate() - might come in handy
        'Refresh() - might come in handy
        np.X = p.X \ side
        np.Y = p.Y \ side
        Return np

    End Function

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click
        GameLabel.Text = "Game is paused."
        'Panel1.Enabled = True - disabled due to ingame state

        'Clean board
        If frmNewGame.ShowDialog = DialogResult.OK Then
            plays = 0
            For i As Integer = 0 To 2
                For j As Integer = 0 To 2
                    board(i, j) = 0
                Next
                Refresh()
            Next
            data = New GameData
            With data
                .p1 = frmNewGame.txtp1name.Text
                p1Label.Text = .p1
                .p2 = frmNewGame.txtp2name.Text
                p2Label.Text = .p2
                .p1piece = frmNewGame.boxp1.Text
                .p2piece = frmNewGame.boxp2.Text
                .firsttoplay = frmNewGame.p1play.Checked
                .theme = frmNewGame.boxskin.Text
                .timedplay = frmNewGame.checktimer.Checked
                'If .p1piece = "Cross" Then
                '    PictureBox1.Image = My.Resources.X
                'ElseIf .p1piece = "Circle" Then
                '    PictureBox1.Image = My.Resources.O
                'End If
                'If .p2piece = "Cross" Then
                '    PictureBox2.Image = My.Resources.X
                'ElseIf .p2piece = "Circle" Then
                '    PictureBox2.Image = My.Resources.O
                'End If

                'Determinar vez de quem joga

                'If data.firsttoplay = True Then
                '    playerlabel.Text = "It's " & .p1 & " turn"
                'Else
                '    playerlabel.Text = "It's " & .p2 & " turn"
                'End If
                If data.firsttoplay = False Then
                    plays = 1
                Else
                    plays = 0
                End If
                If frmNewGame.p1play.Checked = True Then
                    '   playerlabel.Text = .p1
                Else
                    '   playerlabel.Text = .p2
                End If



                If data.timedplay = True Then
                    timer_play.Enabled = True
                    timer_play.Interval = 1000
                Else
                    timer_play.Enabled = False
                End If
            End With
            GameLabel.Text = "Game is running"
            ingame = True
        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p1Label.Text = ""
        p2Label.Text = ""
        countdownlabel.Text = ""
        GameLabel.Text = "Game is stopped, press New Game or click the Game Grid."
        playerlabel.Text = ""
        'Panel1.Enabled = False - Disabled due to ingame state.
        win = New List(Of Line)
        ' Vertical
        For i As Integer = 0 To 2
            win.Add(New Line(New Point(i, 0), New Point(i, 1), New Point(i, 2)))
        Next
        ' Horizontal
        For i As Integer = 0 To 2
            win.Add(New Line(New Point(0, i), New Point(1, i), New Point(2, i)))
        Next
        ' Diagonals
        win.Add(New Line(New Point(0, 0), New Point(1, 1), New Point(2, 2)))
        win.Add(New Line(New Point(0, 2), New Point(1, 1), New Point(2, 0)))

    End Sub

    Private Sub PlayerOneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PlayerOneToolStripMenuItem.Click
        With ImageOpen
            .CheckFileExists = True
            .ShowReadOnly = False
            .Filter = "All Files|*.*|Bitmap Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg"
            .FileName = ""
            .FilterIndex = 2
            If .ShowDialog = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(.FileName)
            End If
        End With
    End Sub

    Private Sub PlayerTwoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PlayerTwoToolStripMenuItem.Click
        With ImageOpen
            .CheckFileExists = True
            .ShowReadOnly = False
            .Filter = "All Files|*.*|Bitmap Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg"
            .FileName = ""
            .FilterIndex = 2
            If .ShowDialog = DialogResult.OK Then
                PictureBox2.Image = Image.FromFile(.FileName)
            End If
        End With
    End Sub

    Private Sub timer_play_Tick(sender As System.Object, e As System.EventArgs) Handles timer_play.Tick
        If timercount <> 0 Then
            timercount -= 1
            countdownlabel.Text = timercount.ToString
        ElseIf timercount = 0 Then
            autoplay()
        End If
        If timercount < 4 Then
            countdownlabel.ForeColor = Color.Red
        Else
            countdownlabel.ForeColor = Color.Black
        End If
    End Sub

    Public Sub autoplay()
        Randomize()
        For i As Integer = (CInt(Rnd() * 2)) To 2
            For j As Integer = (CInt(Rnd() * 2)) To 2
                If board(i, j) = 0 Then
                    If plays Mod 2 = 0 Then
                        board(i, j) = Player.Player1
                        plays += 1
                        Panel1.Refresh()
                        timercount = 10
                        Exit Sub
                    Else
                        board(i, j) = Player.Player2
                        plays += 1
                        Panel1.Refresh()
                        timercount = 10
                        Exit Sub
                    End If
                End If
            Next
        Next
    End Sub
End Class