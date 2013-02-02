<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filesv2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Filesv2))
        Me.sendbtn = New System.Windows.Forms.Button()
        Me.receivebtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'sendbtn
        '
        Me.sendbtn.Location = New System.Drawing.Point(12, 3)
        Me.sendbtn.Name = "sendbtn"
        Me.sendbtn.Size = New System.Drawing.Size(75, 23)
        Me.sendbtn.TabIndex = 0
        Me.sendbtn.Text = "Send"
        Me.sendbtn.UseVisualStyleBackColor = True
        '
        'receivebtn
        '
        Me.receivebtn.Location = New System.Drawing.Point(93, 3)
        Me.receivebtn.Name = "receivebtn"
        Me.receivebtn.Size = New System.Drawing.Size(75, 23)
        Me.receivebtn.TabIndex = 1
        Me.receivebtn.Text = "Receive"
        Me.receivebtn.UseVisualStyleBackColor = True
        '
        'Filesv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(177, 30)
        Me.Controls.Add(Me.receivebtn)
        Me.Controls.Add(Me.sendbtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Filesv2"
        Me.Text = "Files"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sendbtn As System.Windows.Forms.Button
    Friend WithEvents receivebtn As System.Windows.Forms.Button
End Class
