<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM
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
        Me.pmchattxt = New System.Windows.Forms.TextBox()
        Me.pmsndbtn = New System.Windows.Forms.Button()
        Me.pmtxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pmchattxt
        '
        Me.pmchattxt.Enabled = False
        Me.pmchattxt.Location = New System.Drawing.Point(0, 12)
        Me.pmchattxt.Multiline = True
        Me.pmchattxt.Name = "pmchattxt"
        Me.pmchattxt.Size = New System.Drawing.Size(280, 212)
        Me.pmchattxt.TabIndex = 0
        '
        'pmsndbtn
        '
        Me.pmsndbtn.Enabled = False
        Me.pmsndbtn.Location = New System.Drawing.Point(197, 230)
        Me.pmsndbtn.Name = "pmsndbtn"
        Me.pmsndbtn.Size = New System.Drawing.Size(75, 23)
        Me.pmsndbtn.TabIndex = 1
        Me.pmsndbtn.Text = "Send"
        Me.pmsndbtn.UseVisualStyleBackColor = True
        '
        'pmtxt
        '
        Me.pmtxt.Enabled = False
        Me.pmtxt.Location = New System.Drawing.Point(8, 230)
        Me.pmtxt.Name = "pmtxt"
        Me.pmtxt.Size = New System.Drawing.Size(183, 20)
        Me.pmtxt.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'PM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 255)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pmtxt)
        Me.Controls.Add(Me.pmsndbtn)
        Me.Controls.Add(Me.pmchattxt)
        Me.Name = "PM"
        Me.Text = "PM"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pmchattxt As System.Windows.Forms.TextBox
    Friend WithEvents pmsndbtn As System.Windows.Forms.Button
    Friend WithEvents pmtxt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
