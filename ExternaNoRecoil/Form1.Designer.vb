<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GameOpenMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.GameEndMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.NoRecoilTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ControlsMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FocusMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.DiscordForm1 = New ExternaNoRecoil.DiscordForm()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SpeedLabel = New ExternaNoRecoil.DiscordLabel()
        Me.ValueLabel = New ExternaNoRecoil.DiscordLabel()
        Me.DiscordLabel5 = New ExternaNoRecoil.DiscordLabel()
        Me.MauseValueTrackBar = New ExternaNoRecoil.SevenOperXTrackBar()
        Me.DiscordButton11 = New ExternaNoRecoil.DiscordButton1()
        Me.DiscordLabel6 = New ExternaNoRecoil.DiscordLabel()
        Me.SpeedValueTrackBar = New ExternaNoRecoil.SevenOperXTrackBar()
        Me.StatusLabel = New ExternaNoRecoil.DiscordLabel()
        Me.DiscordLabel4 = New ExternaNoRecoil.DiscordLabel()
        Me.DiscordLabel3 = New ExternaNoRecoil.DiscordLabel()
        Me.DiscordLabel2 = New ExternaNoRecoil.DiscordLabel()
        Me.DiscordLabel1 = New ExternaNoRecoil.DiscordLabel()
        Me.ProcessTextBox = New ExternaNoRecoil.DiscordTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DiscordForm1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GameOpenMonitor
        '
        Me.GameOpenMonitor.Enabled = True
        Me.GameOpenMonitor.Interval = 1
        '
        'GameEndMonitor
        '
        '
        'NoRecoilTimer
        '
        Me.NoRecoilTimer.Interval = 1
        '
        'ControlsMonitor
        '
        Me.ControlsMonitor.Enabled = True
        Me.ControlsMonitor.Interval = 1
        '
        'FocusMonitor
        '
        Me.FocusMonitor.Interval = 1
        '
        'DiscordForm1
        '
        Me.DiscordForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.DiscordForm1.Controls.Add(Me.LinkLabel1)
        Me.DiscordForm1.Controls.Add(Me.SpeedLabel)
        Me.DiscordForm1.Controls.Add(Me.ValueLabel)
        Me.DiscordForm1.Controls.Add(Me.DiscordLabel5)
        Me.DiscordForm1.Controls.Add(Me.MauseValueTrackBar)
        Me.DiscordForm1.Controls.Add(Me.DiscordButton11)
        Me.DiscordForm1.Controls.Add(Me.DiscordLabel6)
        Me.DiscordForm1.Controls.Add(Me.SpeedValueTrackBar)
        Me.DiscordForm1.Controls.Add(Me.StatusLabel)
        Me.DiscordForm1.Controls.Add(Me.DiscordLabel4)
        Me.DiscordForm1.Controls.Add(Me.DiscordLabel3)
        Me.DiscordForm1.Controls.Add(Me.DiscordLabel2)
        Me.DiscordForm1.Controls.Add(Me.DiscordLabel1)
        Me.DiscordForm1.Controls.Add(Me.ProcessTextBox)
        Me.DiscordForm1.Controls.Add(Me.Button1)
        Me.DiscordForm1.Controls.Add(Me.Panel1)
        Me.DiscordForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DiscordForm1.Location = New System.Drawing.Point(0, 0)
        Me.DiscordForm1.Name = "DiscordForm1"
        Me.DiscordForm1.Size = New System.Drawing.Size(444, 297)
        Me.DiscordForm1.TabIndex = 1
        Me.DiscordForm1.Text = "External No Recoil"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DeepSkyBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 275)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(40, 13)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "GitHub"
        Me.ToolTip1.SetToolTip(Me.LinkLabel1, "Source Code | How to use | and more...")
        '
        'SpeedLabel
        '
        Me.SpeedLabel.AutoSize = True
        Me.SpeedLabel.BackColor = System.Drawing.Color.Transparent
        Me.SpeedLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.SpeedLabel.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.SpeedLabel.ForeColor = System.Drawing.Color.White
        Me.SpeedLabel.Location = New System.Drawing.Point(405, 159)
        Me.SpeedLabel.Name = "SpeedLabel"
        Me.SpeedLabel.Size = New System.Drawing.Size(28, 15)
        Me.SpeedLabel.TabIndex = 12
        Me.SpeedLabel.Text = "100"
        '
        'ValueLabel
        '
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.BackColor = System.Drawing.Color.Transparent
        Me.ValueLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.ValueLabel.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.ValueLabel.ForeColor = System.Drawing.Color.White
        Me.ValueLabel.Location = New System.Drawing.Point(405, 121)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(14, 15)
        Me.ValueLabel.TabIndex = 11
        Me.ValueLabel.Text = "1"
        '
        'DiscordLabel5
        '
        Me.DiscordLabel5.AutoSize = True
        Me.DiscordLabel5.BackColor = System.Drawing.Color.Transparent
        Me.DiscordLabel5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.DiscordLabel5.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel5.Location = New System.Drawing.Point(301, 273)
        Me.DiscordLabel5.Name = "DiscordLabel5"
        Me.DiscordLabel5.Size = New System.Drawing.Size(140, 15)
        Me.DiscordLabel5.TabIndex = 10
        Me.DiscordLabel5.Text = "Discord: Destroyer#3527"
        Me.ToolTip1.SetToolTip(Me.DiscordLabel5, "Contact Me For more ...")
        '
        'MauseValueTrackBar
        '
        Me.MauseValueTrackBar.BarColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.MauseValueTrackBar.BarColorFromBoxmoving = True
        Me.MauseValueTrackBar.BarProgressColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.MauseValueTrackBar.BoxColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.MauseValueTrackBar.Location = New System.Drawing.Point(58, 119)
        Me.MauseValueTrackBar.Maximum = 20
        Me.MauseValueTrackBar.Minimum = 1
        Me.MauseValueTrackBar.Name = "MauseValueTrackBar"
        Me.MauseValueTrackBar.Size = New System.Drawing.Size(336, 20)
        Me.MauseValueTrackBar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.MauseValueTrackBar, "Space interval that will lower the pointer.")
        Me.MauseValueTrackBar.Value = 1
        '
        'DiscordButton11
        '
        Me.DiscordButton11.Location = New System.Drawing.Point(413, 1)
        Me.DiscordButton11.Name = "DiscordButton11"
        Me.DiscordButton11.Size = New System.Drawing.Size(30, 21)
        Me.DiscordButton11.TabIndex = 9
        Me.DiscordButton11.Text = "X"
        '
        'DiscordLabel6
        '
        Me.DiscordLabel6.AutoSize = True
        Me.DiscordLabel6.BackColor = System.Drawing.Color.Transparent
        Me.DiscordLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.DiscordLabel6.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel6.ForeColor = System.Drawing.Color.White
        Me.DiscordLabel6.Location = New System.Drawing.Point(12, 200)
        Me.DiscordLabel6.Name = "DiscordLabel6"
        Me.DiscordLabel6.Size = New System.Drawing.Size(379, 60)
        Me.DiscordLabel6.TabIndex = 8
        Me.DiscordLabel6.Text = resources.GetString("DiscordLabel6.Text")
        '
        'SpeedValueTrackBar
        '
        Me.SpeedValueTrackBar.BarColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.SpeedValueTrackBar.BarColorFromBoxmoving = True
        Me.SpeedValueTrackBar.BarProgressColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.SpeedValueTrackBar.BoxColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.SpeedValueTrackBar.Location = New System.Drawing.Point(58, 157)
        Me.SpeedValueTrackBar.Maximum = 100
        Me.SpeedValueTrackBar.Minimum = 1
        Me.SpeedValueTrackBar.Name = "SpeedValueTrackBar"
        Me.SpeedValueTrackBar.Size = New System.Drawing.Size(336, 20)
        Me.SpeedValueTrackBar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.SpeedValueTrackBar, "Speed ​​With which the Pointer falls in the Recoil.")
        Me.SpeedValueTrackBar.Value = 100
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.BackColor = System.Drawing.Color.Transparent
        Me.StatusLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.StatusLabel.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.StatusLabel.ForeColor = System.Drawing.Color.White
        Me.StatusLabel.Location = New System.Drawing.Point(252, 71)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(92, 15)
        Me.StatusLabel.TabIndex = 6
        Me.StatusLabel.Text = "Waiting Game..."
        '
        'DiscordLabel4
        '
        Me.DiscordLabel4.AutoSize = True
        Me.DiscordLabel4.BackColor = System.Drawing.Color.Transparent
        Me.DiscordLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.DiscordLabel4.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel4.Location = New System.Drawing.Point(206, 71)
        Me.DiscordLabel4.Name = "DiscordLabel4"
        Me.DiscordLabel4.Size = New System.Drawing.Size(49, 15)
        Me.DiscordLabel4.TabIndex = 5
        Me.DiscordLabel4.Text = "Status : "
        '
        'DiscordLabel3
        '
        Me.DiscordLabel3.AutoSize = True
        Me.DiscordLabel3.BackColor = System.Drawing.Color.Transparent
        Me.DiscordLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.DiscordLabel3.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel3.Location = New System.Drawing.Point(9, 162)
        Me.DiscordLabel3.Name = "DiscordLabel3"
        Me.DiscordLabel3.Size = New System.Drawing.Size(49, 15)
        Me.DiscordLabel3.TabIndex = 4
        Me.DiscordLabel3.Text = "Speed : "
        '
        'DiscordLabel2
        '
        Me.DiscordLabel2.AutoSize = True
        Me.DiscordLabel2.BackColor = System.Drawing.Color.Transparent
        Me.DiscordLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.DiscordLabel2.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel2.Location = New System.Drawing.Point(9, 119)
        Me.DiscordLabel2.Name = "DiscordLabel2"
        Me.DiscordLabel2.Size = New System.Drawing.Size(46, 15)
        Me.DiscordLabel2.TabIndex = 3
        Me.DiscordLabel2.Text = "Value : "
        '
        'DiscordLabel1
        '
        Me.DiscordLabel1.AutoSize = True
        Me.DiscordLabel1.BackColor = System.Drawing.Color.Transparent
        Me.DiscordLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.DiscordLabel1.FontColour = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DiscordLabel1.Location = New System.Drawing.Point(9, 71)
        Me.DiscordLabel1.Name = "DiscordLabel1"
        Me.DiscordLabel1.Size = New System.Drawing.Size(56, 15)
        Me.DiscordLabel1.TabIndex = 2
        Me.DiscordLabel1.Text = "Process : "
        '
        'ProcessTextBox
        '
        Me.ProcessTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ProcessTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ProcessTextBox.Location = New System.Drawing.Point(71, 71)
        Me.ProcessTextBox.Name = "ProcessTextBox"
        Me.ProcessTextBox.Size = New System.Drawing.Size(123, 21)
        Me.ProcessTextBox.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ProcessTextBox, "Enter the name of the Game Process.")
        Me.ProcessTextBox.UseSystemPasswordChar = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(0, 52)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(444, 245)
        Me.Button1.TabIndex = 14
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(444, 52)
        Me.Panel1.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(444, 297)
        Me.Controls.Add(Me.DiscordForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = true
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.DiscordForm1.ResumeLayout(false)
        Me.DiscordForm1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents MauseValueTrackBar As ExternaNoRecoil.SevenOperXTrackBar
    Friend WithEvents DiscordForm1 As ExternaNoRecoil.DiscordForm
    Friend WithEvents GameOpenMonitor As System.Windows.Forms.Timer
    Friend WithEvents DiscordLabel3 As ExternaNoRecoil.DiscordLabel
    Friend WithEvents DiscordLabel2 As ExternaNoRecoil.DiscordLabel
    Friend WithEvents DiscordLabel1 As ExternaNoRecoil.DiscordLabel
    Friend WithEvents ProcessTextBox As ExternaNoRecoil.DiscordTextBox
    Friend WithEvents GameEndMonitor As System.Windows.Forms.Timer
    Friend WithEvents StatusLabel As ExternaNoRecoil.DiscordLabel
    Friend WithEvents DiscordLabel4 As ExternaNoRecoil.DiscordLabel
    Friend WithEvents DiscordButton11 As ExternaNoRecoil.DiscordButton1
    Friend WithEvents DiscordLabel6 As ExternaNoRecoil.DiscordLabel
    Friend WithEvents SpeedValueTrackBar As ExternaNoRecoil.SevenOperXTrackBar
    Friend WithEvents NoRecoilTimer As System.Windows.Forms.Timer
    Friend WithEvents DiscordLabel5 As ExternaNoRecoil.DiscordLabel
    Friend WithEvents SpeedLabel As ExternaNoRecoil.DiscordLabel
    Friend WithEvents ValueLabel As ExternaNoRecoil.DiscordLabel
    Friend WithEvents ControlsMonitor As System.Windows.Forms.Timer
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FocusMonitor As System.Windows.Forms.Timer

End Class
