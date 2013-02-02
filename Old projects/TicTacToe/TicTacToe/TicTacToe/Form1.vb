Public Class Form1
    Public plays As Integer
    Public board(2, 2) As Integer
    Dim namep1 As String = "Player 1"
    Dim namep2 As String = "Player 2"
    Dim point As Point
    Public Enum Player
        Player1 = 1
        Player2 = 10
    End Enum
    Public Structure P
        Public P1, P2, P3 As Point
        Sub New(ByVal p1 As Point, ByVal p2 As Point, ByVal p3 As Point)
            Me.P1 = p1
            Me.P2 = p2
            Me.P3 = p3
        End Sub
    End Structure
    Public L As List(Of P)
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        'Select Case DirectCast(sender, Button).Name
        '    Case "btn1" : point = New Point(0, 0)
        '    Case "btn2" : point = New Point(0, 1)
        '    Case "btn3" : point = New Point(0, 2)
        '        'Case "btn4" : point = New Point(1, 0)
        '        'Case "btn5" : point = New Point(1, 1)
        '        'Case "btn6" : point = New Point(1, 2)
        '        'Case "btn7" : point = New Point(2, 1)
        '        'Case "btn8" : point = New Point(2, 1)
        '        'Case "btn9" : point = New Point(2, 2)
        'End Select

        plays += 1
        Dim b As Button = DirectCast(sender, Button)

        If plays Mod 2 = 0 Then
            b.Text = "X"
            b.Enabled = False
            board(DirectCast(b.Tag, Point).X, DirectCast(b.Tag, Point).Y) = Player.Player1
        Else
            b.Text = "O"
            b.Enabled = False
            board(DirectCast(b.Tag, Point).X, DirectCast(b.Tag, Point).Y) = Player.Player2
        End If
        If plays >= 5 Then
            ' determines winner
            'Dim counti As Integer = 0
            'For i As Integer = 0 To 2
            '    Dim countj As Integer = 0
            '    For j As Integer = 0 To 2
            '        countj += board(j, i)
            '    Next
            '    If countj = 3 Then
            '        MsgBox("X wins in column")
            '    ElseIf countj = 30 Then
            '        MsgBox("O wins in column")
            '    End If
            'Next

            'If plays = 9 Then
            '    MsgBox("Tie!")
            'End If

            ' Class 26-10-2011
            'Dim res As Integer = 0
            'For line As Integer = 0 To 2
            '    res += (board(line, 0) + board(line, 1) + board(line, 2))
            '    If res = 3 Or res = 30 Then
            '        'show winners
            '        MsgBox("hai")
            '        Exit For
            '    End If
            'Next
            ' if "notwon" then
            ' 'test columns
            ' if ""
            ' 'test diagonals

            'or

            'Dim res As Integer = 0
            'For line As Integer = 0 To 2
            '    L.Add(New P(New Point(line, 0), New Point(line, 1), New Point(line, 2)))
            'Next
            ' if "notwon" then
            ' 'test columns
            ' if ""
            ' 'test diagonals

            'or

            'For Each p In L
            'winner
            'If board(p.P1.X, p.P1.Y) + board(p.P2.X, p.P2.Y) + board(p.P3.X, p.P3.Y) = 3 Then
            '     MsgBox("hai")
            '    ElseIf board(p.P1.X, p.P1.Y) + board(p.P2.X, p.P2.Y) + board(p.P3.X, p.P3.Y) = 30 Then
            '        MsgBox("hai")
            '      Exit For
            '   End If
            'Next

        End If

    End Sub
    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        If MessageBox.Show("Are you sure that you want to start a new game?", "New game", MessageBoxButtons.OKCancel, Nothing, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            For Each c As Control In Me.Controls
                c.Text = ""
                c.Enabled = True
                plays = 0
            Next
        Else
            Exit Sub
        End If
    End Sub
    Private Sub PlayerNamesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim inputp1 As String
        Dim inputp2 As String
        inputp1 = InputBox("Name for player one:")
        If String.IsNullOrEmpty(inputp1) Then
            namep1 = "Player 1"
        Else
            namep1 = inputp1
        End If
        inputp2 = InputBox("Name for player two:")
        If String.IsNullOrEmpty(inputp1) Then
            namep2 = "Player 2"
        Else
            namep2 = inputp2
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btn1.Tag = New Point(0, 0)
        btn2.Tag = New Point(0, 1)
        btn3.Tag = New Point(0, 2)
        btn4.Tag = New Point(1, 0)
        btn5.Tag = New Point(1, 1)
        btn6.Tag = New Point(1, 2)
        btn7.Tag = New Point(2, 0)
        btn8.Tag = New Point(2, 1)
        btn9.Tag = New Point(2, 2)
        L = New List(Of P)
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click

    End Sub
End Class
