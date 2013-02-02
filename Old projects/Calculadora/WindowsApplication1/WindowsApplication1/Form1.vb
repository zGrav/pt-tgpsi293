' Calculator (VB.Net/WinForm)
' TGPSI 293 - 2nd Year - David

'TODO:
'Unfocus buttons/disable enter button press?

Public Class Form1
    Dim total1 As Double 'Operand 1
    Dim total2 As Double 'Operand 2
    Dim Result As Double 'Result for both operands
    Dim memory As Double ' Memory counter
    Dim op As String ' Used for operations
    Dim state As Boolean = False ' Clear Display Boolean
    Dim dec As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator ' Decimal (Regional Settings) reader
    'Handles all buttons
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn0.Click
        If state = True Then
            txtMainDisplay.Text = ""
            state = False
        End If
        txtMainDisplay.Text &= DirectCast(sender, Button).Text 'DirectCast is used to access/convert a certain type of operation (?)
    End Sub
    'Keypress handle
    Private Sub Form1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn1.KeyPress, MyBase.KeyPress
        Select Case (e.KeyChar)
            Case "1"c
                btn1.PerformClick()
            Case "2"c
                btn2.PerformClick()
            Case "3"c
                btn3.PerformClick()
            Case "4"c
                btn4.PerformClick()
            Case "5"c
                btn5.PerformClick()
            Case "6"c
                btn6.PerformClick()
            Case "7"c
                btn7.PerformClick()
            Case "8"c
                btn8.PerformClick()
            Case "9"c
                btn9.PerformClick()
            Case "0"c
                btn0.PerformClick()
            Case "+"c
                btnAdd.PerformClick()
            Case "-"c
                btnSub.PerformClick()
            Case "*"c
                btnMul.PerformClick()
            Case "/"c
                btnDiv.PerformClick()
            Case "."c
                btnComma.PerformClick()
            Case ChrW(Keys.Back)
                btnBack.PerformClick()
            Case ChrW(Keys.Enter)
                btnEqual.PerformClick()
        End Select
        e.Handled = True
    End Sub
    'Equal button
    Private Sub btnEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEqual.Click
        If String.IsNullOrEmpty(txtMainDisplay.Text) = True Then
            Exit Sub
        Else
            total2 = CDbl(txtMainDisplay.Text)
            Select Case op 'Operation handler
                Case "+"c
                    txtSecDisplay.Text &= CDbl(total2)
                    txtPapermode.Text &= CDbl(total2)
                    txtSecDisplay.Clear()
                    Result = CDbl(total1) + CDbl(total2)
                Case "-"c
                    txtSecDisplay.Text &= CDbl(total2)
                    txtPapermode.Text &= CDbl(total2)
                    txtSecDisplay.Clear()
                    Result = CDbl(total1) - CDbl(total2)
                Case "*"c
                    txtSecDisplay.Text &= CDbl(total2)
                    txtPapermode.Text &= CDbl(total2)
                    txtSecDisplay.Clear()
                    Result = CDbl(total1) * CDbl(total2)
                Case "/"c
                    txtSecDisplay.Text &= CDbl(total2)
                    txtPapermode.Text &= CDbl(total2)
                    txtSecDisplay.Clear()
                    Result = CDbl(total1) / CDbl(total2)
            End Select
            txtMainDisplay.Text = CStr(Result)
            txtPapermode.Text &= "=" & Result & Environment.NewLine
            If Result = CDbl(txtMainDisplay.Text) Then
                state = True
                total1 = 0
                total2 = 0
            End If
        End If
    End Sub
    ' Add button
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtMainDisplay.Text) = True Then
            Exit Sub
        Else
            total1 = CDbl(txtMainDisplay.Text)
            state = True
            ' TxtMainDisplay.Clear() - disabled due to state
            op = "+"c
            txtSecDisplay.Text &= CDbl(total1) & "+"
            txtPapermode.Text &= CDbl(total1) & "+"
            If Result = CDbl(txtMainDisplay.Text) Then
                txtSecDisplay.Clear()
                txtSecDisplay.Text &= CDbl(Result) & "+"
                txtPapermode.Text &= CDbl(Result) & "+"
            End If
        End If
    End Sub
    ' Comma button
    Private Sub btnComma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComma.Click
        'Dim grp As String // Not sure if needed.
        'grp = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator // Not sure if needed.
        If txtMainDisplay.Text.IndexOf(dec) = -1 And txtMainDisplay.Text.Length > 0 Then ' Gets index -1 of dec (comma) and adds it, if exists, exits sub.
            txtMainDisplay.Text = txtMainDisplay.Text & dec
            btnComma.Text = dec
        End If
        If txtMainDisplay.Text = Nothing Then
            txtMainDisplay.Text = "0" & dec
            state = False
        End If
    End Sub
    ' Clear everything button
    Private Sub btnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC.Click
        txtMainDisplay.Clear()
        txtSecDisplay.Clear()
        total1 = 0
        total2 = 0
        txtMainDisplay.Text = "0"
        state = True
    End Sub
    'Clear operation button
    Private Sub btnCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCE.Click
        txtMainDisplay.Clear()
        txtMainDisplay.Text = "0"
        state = True
    End Sub
    ' Multiply button
    Private Sub btnMul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMul.Click
        If String.IsNullOrEmpty(txtMainDisplay.Text) = True Then
            Exit Sub
        Else
            total1 = CDbl(txtMainDisplay.Text)
            state = True
            'txtMainDisplay.Clear() - disabled due to state
            op = "*"c
            txtSecDisplay.Text &= CDbl(total1) & "*"
            txtPapermode.Text &= CDbl(total1) & "*"
            If Result = CDbl(txtMainDisplay.Text) Then
                txtSecDisplay.Clear()
                txtSecDisplay.Text &= CDbl(Result) & "*"
                txtPapermode.Text &= CDbl(Result) & "*"
            End If
        End If
    End Sub
    ' Subtract button
    Private Sub btnSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSub.Click
        If String.IsNullOrEmpty(txtMainDisplay.Text) = True Then
            Exit Sub
        Else
            total1 = CDbl(txtMainDisplay.Text)
            state = True
            'txtMainDisplay.Clear() - disabled due to state
            op = "-"c
            txtSecDisplay.Text &= CDbl(total1) & "-"
            txtPapermode.Text &= CDbl(total1) & "-"
            If Result = CDbl(txtMainDisplay.Text) Then
                txtSecDisplay.Clear()
                txtSecDisplay.Text &= CDbl(Result) & "-"
                txtPapermode.Text &= CDbl(total1) & "-"
            End If
        End If
    End Sub
    ' Divide button
    Private Sub btnDiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiv.Click
        If String.IsNullOrEmpty(txtMainDisplay.Text) = True Then
            Exit Sub
        Else
            total1 = CDbl(txtMainDisplay.Text)
            state = True
            'txtMainDisplay.Clear() - disabled due to state
            op = "/"c
            txtSecDisplay.Text &= CDbl(total1) & "/"
            txtPapermode.Text &= CDbl(total1) & "/"
            If Result = CDbl(txtMainDisplay.Text) Then
                txtSecDisplay.Clear()
                txtSecDisplay.Text &= CDbl(Result) & "/"
                txtPapermode.Text &= CDbl(total1) & "/"
            End If
        End If
    End Sub
    ' Backspace button
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        '  Dim str As String // Not needed, basicly being used below directly on txtMainDisplay.
        If txtMainDisplay.Text.Length > 0 Then
            'str = txtMainDisplay.Text.Chars(txtMainDisplay.Text.Length - 1) ' Passes chars and length -1 to string // Disabled, explained above.
            'txtMainDisplay.Text = txtMainDisplay.Text.Remove(txtMainDisplay.Text.Length - 1, 1) ' Handle for the Backscape (counts to the end of the string and deletes char.) // Disabled, explained above.
            txtMainDisplay.Text = txtMainDisplay.Text.Substring(0, txtMainDisplay.TextLength() - 1)
        End If
        If txtMainDisplay.TextLength = 0 Then
            txtMainDisplay.Text = "0"
            state = True
        End If
    End Sub
    ' Add Minus (negative) number
    Private Sub btnAddMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMinus.Click
        If txtMainDisplay.TextLength > 0 Then
            txtMainDisplay.Text = ((CDbl(txtMainDisplay.Text)) * -1).ToString  ' Handle for the minus sign (if exists in txtMainDisplay, removes on another click.), passes String to Double, removes final value and then to String again.
        Else
            Exit Sub
        End If
    End Sub
    ' Pow button
    Private Sub btnPow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPow.Click
        Dim input As String ' Inputbox handle
        Dim store As Double ' Stores inputbox value
        Dim store2 As Double ' Stores txtMainDisplay value
        Dim powop As Double ' Operation handle
        input = InputBox("Insert value.")
        If IsNumeric(input) = True Then
            If String.IsNullOrEmpty(input) Then
                Exit Sub
            Else
                store = CDbl(input)
                If String.IsNullOrEmpty(txtMainDisplay.Text) Then
                    Exit Sub
                Else
                    store2 = CDbl(txtMainDisplay.Text)
                    powop = System.Math.Pow(store2, store)
                    txtMainDisplay.Text = CStr(powop)
                    txtSecDisplay.Text = "Pow" & "(" & store2 & ")" & "^" & "(" & store & ")"
                    txtPapermode.Text &= "Pow" & "(" & store2 & ")" & "^" & "(" & store & ")" & "=" & powop & Environment.NewLine
                End If
            End If
        End If
        state = True
    End Sub
    ' Root button
    Private Sub btnRoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoot.Click
        Dim root As Double ' Stores number from txtMainDisplay
        Dim store As Double ' Stores number for txtSecDisplay
        If String.IsNullOrEmpty(txtMainDisplay.Text) Then
            Exit Sub
        Else
            store = CDbl(txtMainDisplay.Text)
            root = CDbl(txtMainDisplay.Text)
            root = CDbl(System.Math.Sqrt(root))
            txtMainDisplay.Text = CStr(root)
            txtSecDisplay.Text = "sqrt" & "(" & store & ")" & " "
            txtPapermode.Text &= "sqrt" & "(" & store & ")" & " " & "=" & root & Environment.NewLine
        End If
        state = True
    End Sub
    ' Reciproc button
    Private Sub btnReci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReci.Click
        Dim convert As Double ' Stores number from txtMainDisplay
        Dim store As Double ' Stores number for txtSecDisplay
        If String.IsNullOrEmpty(txtMainDisplay.Text) Then
            Exit Sub
        Else
            If CDbl(txtMainDisplay.Text) > 0 Then
                store = CDbl(txtMainDisplay.Text)
                convert = 1 / CDbl(txtMainDisplay.Text)
                txtMainDisplay.Text = CStr(convert)
                txtSecDisplay.Text = "reciproc" & "(" & store & ")" & " "
                txtPapermode.Text &= "reciproc" & "(" & store & ")" & " " & "=" & convert & Environment.NewLine
            End If
        End If
        state = True
    End Sub
    ' Percentage button
    Private Sub btnPer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPer.Click
        Dim per As Double '  Stores number from txtMainDisplay
        Dim store As Double '  Stores number for txtSecDisplay
        per = CDbl(txtMainDisplay.Text)
        store = per
        txtMainDisplay.Text = CStr(CDbl(total1) * (per / 100))
        per = CDbl(total1) * (per / 100)
        txtSecDisplay.Text = store & "%" & " "
        txtPapermode.Text &= store & "%" & " " & "=" & per & Environment.NewLine
    End Sub
    ' Memory Clear button
    Private Sub btnMC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMC.Click
        If memory <> 0 Then
            memory = 0
            txtMem.Text = ""
        End If
        state = True
    End Sub
    ' Memory Read button
    Private Sub btnMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMR.Click
        If memory <> 0 Then
            txtMainDisplay.Text = CStr(memory)
        End If
        state = True
    End Sub
    ' Memory Store button
    Private Sub btnMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMS.Click
        If String.IsNullOrEmpty(txtMainDisplay.Text) Then
            Exit Sub
        Else
            memory = CDbl(txtMainDisplay.Text)
            txtMem.Text = "M"
        End If
        state = True
    End Sub
    ' M+ button
    Private Sub btnMplus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMplus.Click
        If memory <> 0 Then
            memory += CInt(txtMainDisplay.Text)
        End If
        If memory = 0 Then
            txtMem.Text = ""
        Else
            txtMem.Text = "M"
        End If
        state = True
    End Sub
    ' M- button
    Private Sub btnMminus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMminus.Click
        If memory <> 0 Then
            memory -= CInt(txtMainDisplay.Text)
        End If
        If memory = 0 Then
            txtMem.Text = ""
        Else
            txtMem.Text = "M"
        End If
        state = True
    End Sub
    ' Exit menu
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
    ' About menu
    Private Sub AboutProgramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutProgramToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub
    ' txtMainDisplay Auto-Scroll
    Private Sub txtMainDisplay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecDisplay.TextChanged
        txtMainDisplay.SelectionLength = 0
        txtMainDisplay.SelectionStart = Len(txtMainDisplay.Text) ' Starts selecting the text.
        txtMainDisplay.ScrollToCaret() ' Auto-Scroll handle.
    End Sub
    ' txtSecDisplay Auto-Scroll
    Private Sub txtSecDisplay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecDisplay.TextChanged
        txtSecDisplay.SelectionLength = 0
        txtSecDisplay.SelectionStart = Len(txtSecDisplay.Text)
        txtSecDisplay.ScrollToCaret()
    End Sub
    ' txtPapermode Auto-Scroll
    Private Sub txtPapermode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPapermode.TextChanged
        txtPapermode.SelectionLength = 0
        txtPapermode.SelectionStart = Len(txtPapermode.Text)
        txtPapermode.ScrollToCaret()
    End Sub
    ' Copy Handle
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.Clear() ' Cleans Clipboard.
        Clipboard.SetText(txtMainDisplay.Text) ' Passes txtMainDisplay content into Clipboard.
    End Sub
    ' Paste Handle
    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        If IsNumeric(Clipboard.GetText) = True Then ' Only passes from Clipboard IF FULLY Numeric.
            txtMainDisplay.Text = Clipboard.GetText
        End If
    End Sub
    ' Normal view
    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Height = 327
        Me.Width = 335
    End Sub
    ' Papermode view
    Private Sub PaperModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaperModeToolStripMenuItem.Click
        PaperModeToolStripMenuItem.Checked = Not PaperModeToolStripMenuItem.Checked
        If PaperModeToolStripMenuItem.Checked Then
            Me.Height = 327
            Me.Width = 647
        Else
            Me.Height = 327
            Me.Width = 335
        End If
    End Sub
    ' Loads up small size
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = 327
        Me.Width = 335
        btnComma.Text = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator ' Gets Decimal separator from Regional Settings
    End Sub
    ' Resize button for Papermode
    Private Sub btnResize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResize.Click
        PaperModeToolStripMenuItem.Checked = Not PaperModeToolStripMenuItem.Checked
        If PaperModeToolStripMenuItem.Checked Then
            Me.Height = 327
            Me.Width = 647
        Else
            Me.Height = 327
            Me.Width = 335
        End If
    End Sub
    ' Open file button on papermode
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        btnClear.PerformClick()
        PapermodeOpenFile.Filter = "Text files (*.txt)| *.txt" ' File filter (text only.)
        PapermodeOpenFile.FileName = "" ' Filename in dialogbox
        PapermodeOpenFile.ShowDialog() ' Opens up file manager window
        Dim filename As String = PapermodeOpenFile.FileName ' Gets filename and passes to String
        If System.IO.File.Exists(filename) Then
            Dim read As New System.IO.StreamReader(filename)
            txtPapermode.Text = read.ReadToEnd ' Reads file to end
            read.Close() ' Closes StreamReader
        End If
    End Sub
    ' Save file button on papermode
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        PapermodeSaveFile.Filter = "Text files (*.txt)| *.txt" ' File filter (text only.)
        PapermodeSaveFile.ShowDialog() ' Opens up file manager window
        If PapermodeSaveFile.FileName <> Nothing Then
            My.Computer.FileSystem.WriteAllText(PapermodeSaveFile.FileName, txtPapermode.Text, False) ' Gets all text from txtPapermode.Text, writes in a textfile (name given in PapermodeSaveFile.Filename) and stores in disk, append is disabled.
        End If
        PapermodeSaveFile.FileName = ""
    End Sub
    ' Clear txtPapermode button
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtPapermode.Clear()
    End Sub
    'Programmer mode
    Private Sub ProgrammerModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgrammerModeToolStripMenuItem.Click
        ProgrammerModeToolStripMenuItem.Checked = Not ProgrammerModeToolStripMenuItem.Checked
        If ProgrammerModeToolStripMenuItem.Checked Then
            'to Binary
            If String.IsNullOrEmpty(txtMainDisplay.Text) Then
                Exit Sub
            Else
                txtMainDisplay.Text = Convert.ToString(CInt(txtMainDisplay.Text), 2)
                txtPapermode.Text &= "Binary: " & txtMainDisplay.Text & Environment.NewLine
            End If
        Else
            If String.IsNullOrEmpty(txtMainDisplay.Text) Then
                Exit Sub
            Else
                'to Decimal
                txtMainDisplay.Text = CStr(Convert.ToInt16(txtMainDisplay.Text, 2))
                txtPapermode.Text &= "Decimal: " & txtMainDisplay.Text & Environment.NewLine
            End If
        End If
        btn2.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btn3.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btn4.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btn5.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btn6.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btn7.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btn8.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btn9.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btnPer.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btnRoot.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btnPow.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btnReci.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
        btnComma.Enabled = Not ProgrammerModeToolStripMenuItem.Checked
    End Sub
End Class