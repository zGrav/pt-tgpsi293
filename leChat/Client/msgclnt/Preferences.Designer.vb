<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preferences
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Preferences))
        Me.Notification = New System.Windows.Forms.TabControl()
        Me.General = New System.Windows.Forms.TabPage()
        Me.OtherInfo = New System.Windows.Forms.GroupBox()
        Me.AgeTxt = New System.Windows.Forms.TextBox()
        Me.DescTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NameTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BasicInfo = New System.Windows.Forms.GroupBox()
        Me.StatusBox = New System.Windows.Forms.ComboBox()
        Me.Nick_Label = New System.Windows.Forms.Label()
        Me.Status_Label = New System.Windows.Forms.Label()
        Me.NickTxt = New System.Windows.Forms.TextBox()
        Me.Connection = New System.Windows.Forms.TabPage()
        Me.ModifyBtn = New System.Windows.Forms.Button()
        Me.RemoveBtn = New System.Windows.Forms.Button()
        Me.ServerList = New System.Windows.Forms.DataGridView()
        Me.Addbtn = New System.Windows.Forms.Button()
        Me.ServerConn = New System.Windows.Forms.GroupBox()
        Me.ServerTxt = New System.Windows.Forms.TextBox()
        Me.Server_Label = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PortTxt = New System.Windows.Forms.TextBox()
        Me.IPTxt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.filebtn = New System.Windows.Forms.Button()
        Me.filepath = New System.Windows.Forms.TextBox()
        Me.spcheck = New System.Windows.Forms.CheckBox()
        Me.soundcheck = New System.Windows.Forms.CheckBox()
        Me.ApplyBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.ds = New System.Data.DataSet()
        Me.ServerTable = New System.Data.DataTable()
        Me.ServerColumn = New System.Data.DataColumn()
        Me.IPcolumn = New System.Data.DataColumn()
        Me.PortColumn = New System.Data.DataColumn()
        Me.SoundDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Notification.SuspendLayout()
        Me.General.SuspendLayout()
        Me.OtherInfo.SuspendLayout()
        Me.BasicInfo.SuspendLayout()
        Me.Connection.SuspendLayout()
        CType(Me.ServerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ServerConn.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServerTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Notification
        '
        Me.Notification.Controls.Add(Me.General)
        Me.Notification.Controls.Add(Me.Connection)
        Me.Notification.Controls.Add(Me.TabPage1)
        Me.Notification.Location = New System.Drawing.Point(12, 12)
        Me.Notification.Name = "Notification"
        Me.Notification.SelectedIndex = 0
        Me.Notification.Size = New System.Drawing.Size(337, 322)
        Me.Notification.TabIndex = 0
        '
        'General
        '
        Me.General.Controls.Add(Me.OtherInfo)
        Me.General.Controls.Add(Me.BasicInfo)
        Me.General.Location = New System.Drawing.Point(4, 22)
        Me.General.Name = "General"
        Me.General.Padding = New System.Windows.Forms.Padding(3)
        Me.General.Size = New System.Drawing.Size(329, 296)
        Me.General.TabIndex = 0
        Me.General.Text = "General"
        Me.General.UseVisualStyleBackColor = True
        '
        'OtherInfo
        '
        Me.OtherInfo.Controls.Add(Me.AgeTxt)
        Me.OtherInfo.Controls.Add(Me.DescTxt)
        Me.OtherInfo.Controls.Add(Me.Label3)
        Me.OtherInfo.Controls.Add(Me.Label2)
        Me.OtherInfo.Controls.Add(Me.NameTxt)
        Me.OtherInfo.Controls.Add(Me.Label1)
        Me.OtherInfo.Location = New System.Drawing.Point(6, 121)
        Me.OtherInfo.Name = "OtherInfo"
        Me.OtherInfo.Size = New System.Drawing.Size(317, 169)
        Me.OtherInfo.TabIndex = 4
        Me.OtherInfo.TabStop = False
        Me.OtherInfo.Text = "Other Info"
        '
        'AgeTxt
        '
        Me.AgeTxt.Location = New System.Drawing.Point(95, 136)
        Me.AgeTxt.MaxLength = 2
        Me.AgeTxt.Name = "AgeTxt"
        Me.AgeTxt.Size = New System.Drawing.Size(33, 20)
        Me.AgeTxt.TabIndex = 5
        '
        'DescTxt
        '
        Me.DescTxt.Location = New System.Drawing.Point(95, 52)
        Me.DescTxt.MaxLength = 500
        Me.DescTxt.Multiline = True
        Me.DescTxt.Name = "DescTxt"
        Me.DescTxt.Size = New System.Drawing.Size(216, 74)
        Me.DescTxt.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Age"
        '
        'NameTxt
        '
        Me.NameTxt.Location = New System.Drawing.Point(95, 20)
        Me.NameTxt.MaxLength = 25
        Me.NameTxt.Name = "NameTxt"
        Me.NameTxt.Size = New System.Drawing.Size(216, 20)
        Me.NameTxt.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'BasicInfo
        '
        Me.BasicInfo.Controls.Add(Me.StatusBox)
        Me.BasicInfo.Controls.Add(Me.Nick_Label)
        Me.BasicInfo.Controls.Add(Me.Status_Label)
        Me.BasicInfo.Controls.Add(Me.NickTxt)
        Me.BasicInfo.Location = New System.Drawing.Point(6, 15)
        Me.BasicInfo.Name = "BasicInfo"
        Me.BasicInfo.Size = New System.Drawing.Size(246, 100)
        Me.BasicInfo.TabIndex = 3
        Me.BasicInfo.TabStop = False
        Me.BasicInfo.Text = "BasicInfo"
        '
        'StatusBox
        '
        Me.StatusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StatusBox.FormattingEnabled = True
        Me.StatusBox.Items.AddRange(New Object() {"Online", "Away", "Busy", "Custom"})
        Me.StatusBox.Location = New System.Drawing.Point(95, 68)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(145, 21)
        Me.StatusBox.TabIndex = 3
        '
        'Nick_Label
        '
        Me.Nick_Label.AutoSize = True
        Me.Nick_Label.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nick_Label.Location = New System.Drawing.Point(6, 25)
        Me.Nick_Label.Name = "Nick_Label"
        Me.Nick_Label.Size = New System.Drawing.Size(70, 18)
        Me.Nick_Label.TabIndex = 0
        Me.Nick_Label.Text = "Nickname"
        '
        'Status_Label
        '
        Me.Status_Label.AutoSize = True
        Me.Status_Label.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_Label.Location = New System.Drawing.Point(6, 68)
        Me.Status_Label.Name = "Status_Label"
        Me.Status_Label.Size = New System.Drawing.Size(46, 18)
        Me.Status_Label.TabIndex = 2
        Me.Status_Label.Text = "Status"
        '
        'NickTxt
        '
        Me.NickTxt.Location = New System.Drawing.Point(95, 25)
        Me.NickTxt.MaxLength = 14
        Me.NickTxt.Name = "NickTxt"
        Me.NickTxt.Size = New System.Drawing.Size(145, 20)
        Me.NickTxt.TabIndex = 1
        '
        'Connection
        '
        Me.Connection.Controls.Add(Me.ModifyBtn)
        Me.Connection.Controls.Add(Me.RemoveBtn)
        Me.Connection.Controls.Add(Me.ServerList)
        Me.Connection.Controls.Add(Me.Addbtn)
        Me.Connection.Controls.Add(Me.ServerConn)
        Me.Connection.Location = New System.Drawing.Point(4, 22)
        Me.Connection.Name = "Connection"
        Me.Connection.Padding = New System.Windows.Forms.Padding(3)
        Me.Connection.Size = New System.Drawing.Size(329, 296)
        Me.Connection.TabIndex = 1
        Me.Connection.Text = "Connection"
        Me.Connection.UseVisualStyleBackColor = True
        '
        'ModifyBtn
        '
        Me.ModifyBtn.Enabled = False
        Me.ModifyBtn.Location = New System.Drawing.Point(248, 267)
        Me.ModifyBtn.Name = "ModifyBtn"
        Me.ModifyBtn.Size = New System.Drawing.Size(75, 23)
        Me.ModifyBtn.TabIndex = 5
        Me.ModifyBtn.Text = "Modify"
        Me.ModifyBtn.UseVisualStyleBackColor = True
        '
        'RemoveBtn
        '
        Me.RemoveBtn.Enabled = False
        Me.RemoveBtn.Location = New System.Drawing.Point(87, 267)
        Me.RemoveBtn.Name = "RemoveBtn"
        Me.RemoveBtn.Size = New System.Drawing.Size(75, 23)
        Me.RemoveBtn.TabIndex = 4
        Me.RemoveBtn.Text = "Remove"
        Me.RemoveBtn.UseVisualStyleBackColor = True
        '
        'ServerList
        '
        Me.ServerList.AllowUserToAddRows = False
        Me.ServerList.AllowUserToDeleteRows = False
        Me.ServerList.BackgroundColor = System.Drawing.SystemColors.HighlightText
        Me.ServerList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ServerList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.ServerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ServerList.Location = New System.Drawing.Point(6, 113)
        Me.ServerList.Name = "ServerList"
        Me.ServerList.ReadOnly = True
        Me.ServerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ServerList.ShowCellErrors = False
        Me.ServerList.Size = New System.Drawing.Size(317, 148)
        Me.ServerList.TabIndex = 1
        '
        'Addbtn
        '
        Me.Addbtn.Location = New System.Drawing.Point(6, 267)
        Me.Addbtn.Name = "Addbtn"
        Me.Addbtn.Size = New System.Drawing.Size(75, 23)
        Me.Addbtn.TabIndex = 3
        Me.Addbtn.Text = "Add"
        Me.Addbtn.UseVisualStyleBackColor = True
        '
        'ServerConn
        '
        Me.ServerConn.Controls.Add(Me.ServerTxt)
        Me.ServerConn.Controls.Add(Me.Server_Label)
        Me.ServerConn.Controls.Add(Me.Label5)
        Me.ServerConn.Controls.Add(Me.PortTxt)
        Me.ServerConn.Controls.Add(Me.IPTxt)
        Me.ServerConn.Controls.Add(Me.Label4)
        Me.ServerConn.Location = New System.Drawing.Point(6, 6)
        Me.ServerConn.Name = "ServerConn"
        Me.ServerConn.Size = New System.Drawing.Size(317, 101)
        Me.ServerConn.TabIndex = 0
        Me.ServerConn.TabStop = False
        Me.ServerConn.Text = "Server Connection"
        '
        'ServerTxt
        '
        Me.ServerTxt.Location = New System.Drawing.Point(60, 64)
        Me.ServerTxt.Name = "ServerTxt"
        Me.ServerTxt.Size = New System.Drawing.Size(133, 20)
        Me.ServerTxt.TabIndex = 5
        '
        'Server_Label
        '
        Me.Server_Label.AutoSize = True
        Me.Server_Label.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Server_Label.Location = New System.Drawing.Point(6, 64)
        Me.Server_Label.Name = "Server_Label"
        Me.Server_Label.Size = New System.Drawing.Size(45, 18)
        Me.Server_Label.TabIndex = 4
        Me.Server_Label.Text = "Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(199, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = ":"
        '
        'PortTxt
        '
        Me.PortTxt.Location = New System.Drawing.Point(217, 25)
        Me.PortTxt.MaxLength = 5
        Me.PortTxt.Name = "PortTxt"
        Me.PortTxt.Size = New System.Drawing.Size(80, 20)
        Me.PortTxt.TabIndex = 2
        '
        'IPTxt
        '
        Me.IPTxt.Location = New System.Drawing.Point(60, 25)
        Me.IPTxt.MaxLength = 999
        Me.IPTxt.Name = "IPTxt"
        Me.IPTxt.Size = New System.Drawing.Size(133, 20)
        Me.IPTxt.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Server"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(329, 296)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Notifications"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.filebtn)
        Me.GroupBox1.Controls.Add(Me.filepath)
        Me.GroupBox1.Controls.Add(Me.spcheck)
        Me.GroupBox1.Controls.Add(Me.soundcheck)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 115)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sound"
        '
        'filebtn
        '
        Me.filebtn.Enabled = False
        Me.filebtn.Location = New System.Drawing.Point(162, 77)
        Me.filebtn.Name = "filebtn"
        Me.filebtn.Size = New System.Drawing.Size(75, 23)
        Me.filebtn.TabIndex = 3
        Me.filebtn.Text = "Select"
        Me.filebtn.UseVisualStyleBackColor = True
        '
        'filepath
        '
        Me.filepath.Enabled = False
        Me.filepath.Location = New System.Drawing.Point(6, 79)
        Me.filepath.Name = "filepath"
        Me.filepath.Size = New System.Drawing.Size(150, 20)
        Me.filepath.TabIndex = 2
        Me.filepath.Text = "Select a .wav file"
        '
        'spcheck
        '
        Me.spcheck.AutoSize = True
        Me.spcheck.Enabled = False
        Me.spcheck.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.spcheck.Location = New System.Drawing.Point(6, 51)
        Me.spcheck.Name = "spcheck"
        Me.spcheck.Size = New System.Drawing.Size(86, 22)
        Me.spcheck.TabIndex = 1
        Me.spcheck.Text = "From file:"
        Me.spcheck.UseVisualStyleBackColor = True
        '
        'soundcheck
        '
        Me.soundcheck.AutoSize = True
        Me.soundcheck.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.soundcheck.Location = New System.Drawing.Point(6, 19)
        Me.soundcheck.Name = "soundcheck"
        Me.soundcheck.Size = New System.Drawing.Size(188, 22)
        Me.soundcheck.TabIndex = 0
        Me.soundcheck.Text = "Enable sound notifications"
        Me.soundcheck.UseVisualStyleBackColor = True
        '
        'ApplyBtn
        '
        Me.ApplyBtn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ApplyBtn.Enabled = False
        Me.ApplyBtn.Location = New System.Drawing.Point(193, 340)
        Me.ApplyBtn.Name = "ApplyBtn"
        Me.ApplyBtn.Size = New System.Drawing.Size(75, 23)
        Me.ApplyBtn.TabIndex = 1
        Me.ApplyBtn.Text = "Apply"
        Me.ApplyBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(274, 340)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'ds
        '
        Me.ds.DataSetName = "dset"
        Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.ServerTable})
        '
        'ServerTable
        '
        Me.ServerTable.Columns.AddRange(New System.Data.DataColumn() {Me.ServerColumn, Me.IPcolumn, Me.PortColumn})
        Me.ServerTable.TableName = "ServerTable"
        '
        'ServerColumn
        '
        Me.ServerColumn.ColumnName = "Server Name"
        '
        'IPcolumn
        '
        Me.IPcolumn.ColumnName = "IP"
        '
        'PortColumn
        '
        Me.PortColumn.ColumnName = "Port"
        '
        'SoundDialog
        '
        Me.SoundDialog.FileName = "SoundDialog"
        '
        'Preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 375)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.ApplyBtn)
        Me.Controls.Add(Me.Notification)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Preferences"
        Me.Text = "Preferences"
        Me.Notification.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.OtherInfo.ResumeLayout(False)
        Me.OtherInfo.PerformLayout()
        Me.BasicInfo.ResumeLayout(False)
        Me.BasicInfo.PerformLayout()
        Me.Connection.ResumeLayout(False)
        CType(Me.ServerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ServerConn.ResumeLayout(False)
        Me.ServerConn.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServerTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Notification As System.Windows.Forms.TabControl
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents OtherInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NameTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BasicInfo As System.Windows.Forms.GroupBox
    Friend WithEvents StatusBox As System.Windows.Forms.ComboBox
    Friend WithEvents Nick_Label As System.Windows.Forms.Label
    Friend WithEvents Status_Label As System.Windows.Forms.Label
    Friend WithEvents NickTxt As System.Windows.Forms.TextBox
    Friend WithEvents Connection As System.Windows.Forms.TabPage
    Friend WithEvents ApplyBtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents AgeTxt As System.Windows.Forms.TextBox
    Friend WithEvents DescTxt As System.Windows.Forms.TextBox
    Friend WithEvents ServerConn As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PortTxt As System.Windows.Forms.TextBox
    Friend WithEvents IPTxt As System.Windows.Forms.TextBox
    Friend WithEvents ServerTxt As System.Windows.Forms.TextBox
    Friend WithEvents Server_Label As System.Windows.Forms.Label
    Friend WithEvents ServerList As System.Windows.Forms.DataGridView
    Friend WithEvents Addbtn As System.Windows.Forms.Button
    Friend WithEvents RemoveBtn As System.Windows.Forms.Button
    Friend WithEvents ds As System.Data.DataSet
    Friend WithEvents ServerTable As System.Data.DataTable
    Friend WithEvents ServerColumn As System.Data.DataColumn
    Friend WithEvents IPcolumn As System.Data.DataColumn
    Friend WithEvents PortColumn As System.Data.DataColumn
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents filebtn As System.Windows.Forms.Button
    Friend WithEvents filepath As System.Windows.Forms.TextBox
    Friend WithEvents spcheck As System.Windows.Forms.CheckBox
    Friend WithEvents soundcheck As System.Windows.Forms.CheckBox
    Friend WithEvents SoundDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ModifyBtn As System.Windows.Forms.Button
End Class
