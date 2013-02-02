<Serializable()> _
Public Class frmNewGame
    Structure IconsSpace
        Shared iconspace1 As String = "Space Shuttle"
        Shared iconspace2 As String = "Astronaut"
    End Structure
    Structure IconsDefault
        Shared icondefault1 As String = "Cross"
        Shared icondefault2 As String = "Circle"
    End Structure


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Form2.GameLabel.Text = "Game is running."
        If boxp1.Text = "Cross" Then
            Form2.PictureBox1.Image = My.Resources.X
        ElseIf boxp1.Text = "Circle" Then
            Form2.PictureBox1.Image = My.Resources.O
        ElseIf boxp1.Text = "Space Shuttle" Then
            Form2.PictureBox1.Image = My.Resources.space_shuttle_icon
        ElseIf boxp1.Text = "Astronaut" Then
            Form2.PictureBox1.Image = My.Resources.astronaut_icon
        End If
        If boxp2.Text = "Cross" Then
            Form2.PictureBox2.Image = My.Resources.X
        ElseIf boxp2.Text = "Circle" Then
            Form2.PictureBox2.Image = My.Resources.O
        ElseIf boxp2.Text = "Space Shuttle" Then
            Form2.PictureBox2.Image = My.Resources.space_shuttle_icon
        ElseIf boxp2.Text = "Astronaut" Then
            Form2.PictureBox2.Image = My.Resources.astronaut_icon
        End If
    End Sub

    Private Sub boxp1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boxp1.SelectedIndexChanged
        If boxp1.SelectedIndex = 0 Then
            boxp2.SelectedIndex = 1
        ElseIf boxp1.SelectedIndex = 1 Then
            boxp2.SelectedIndex = 0
        End If
        validate()
    End Sub

    Private Sub boxp2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boxp2.SelectedIndexChanged
        If boxp2.SelectedIndex = 0 Then
            boxp1.SelectedIndex = 1
        ElseIf boxp2.SelectedIndex = 1 Then
            boxp1.SelectedIndex = 0
        End If
        validate()
    End Sub

    Private Sub txtp1name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtp1name.TextChanged, txtp2name.TextChanged
        ' If txtp1name.Text <> Nothing AndAlso txtp1name.Text <> txtp2name.Text Then
        validate()
        'End If
    End Sub
    Private Sub frmNewGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnOK.Enabled = False
    End Sub

    Private Sub validate()
        btnOK.Enabled = (txtp1name.Text <> "" AndAlso txtp2name.Text <> "" AndAlso txtp1name.Text <> txtp2name.Text AndAlso (p1play.Checked OrElse p2play.Checked) AndAlso boxp1.SelectedIndex >= 0 AndAlso boxp2.SelectedIndex >= 0 AndAlso boxskin.SelectedIndex >= 0) 'Then

        '    btnOK.Enabled = True
        'Else
        '   btnOK.Enabled = False
        'End If
    End Sub

    Private Sub p1play_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p1play.CheckedChanged, p2play.CheckedChanged
        validate()
    End Sub


    Private Sub boxskin_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles boxskin.SelectedIndexChanged
        If boxskin.SelectedIndex = 0 Then
            boxp1.Enabled = True
            boxp2.Enabled = True
            Form2.BackColor = DefaultBackColor
            Form2.BackgroundImage = Nothing
            Form2.PictureBox1.Image = My.Resources.O
            Form2.PictureBox2.Image = My.Resources.X
            Form2.PictureBox1.BackColor = DefaultBackColor
            Form2.PictureBox2.BackColor = DefaultBackColor
            Form2.GameLabel.BackColor = DefaultBackColor
            Form2.GameStatusLabel.BackColor = DefaultBackColor
            Form2.countdownlabel.BackColor = DefaultBackColor
            Form2.Panel1.BackColor = DefaultBackColor
            Form2.p1Label.BackColor = DefaultBackColor
            Form2.p2Label.BackColor = DefaultBackColor
            boxp1.Items.Clear()
            boxp1.Items.Add(IconsDefault.icondefault1)
            boxp1.Items.Add(IconsDefault.icondefault2)
            boxp2.Items.Clear()
            boxp2.Items.Add(IconsDefault.icondefault1)
            boxp2.Items.Add(IconsDefault.icondefault2)
        End If
        If boxskin.SelectedIndex = 1 Then
            boxp1.Enabled = True
            boxp2.Enabled = True
            Form2.BackgroundImage = My.Resources.Space
            Form2.PictureBox1.Image = My.Resources.astronaut_icon
            Form2.PictureBox2.Image = My.Resources.space_shuttle_icon
            Form2.PictureBox1.BackColor = Color.Transparent
            Form2.PictureBox2.BackColor = Color.Transparent
            Form2.GameLabel.BackColor = Color.Transparent
            Form2.GameStatusLabel.BackColor = Color.Transparent
            Form2.countdownlabel.BackColor = Color.Transparent
            Form2.Panel1.BackColor = Color.Transparent
            Form2.p1Label.BackColor = Color.Transparent
            Form2.p2Label.BackColor = Color.Transparent
            boxp1.Items.Clear()
            boxp1.Items.Add(IconsSpace.iconspace1)
            boxp1.Items.Add(IconsSpace.iconspace2)
            boxp2.Items.Clear()
            boxp2.Items.Add(IconsSpace.iconspace1)
            boxp2.Items.Add(IconsSpace.iconspace2)
        End If
    End Sub
End Class