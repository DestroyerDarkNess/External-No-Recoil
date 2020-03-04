Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1

#Region " Pinvoke's "

    <DllImport("user32.dll")> _
    Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    <DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Public Shared Function GetCursorPos(ByRef lpPoint As POINTAPI) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetCursorPos(ByVal X As Integer, ByVal Y As Integer) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Sub mouse_event(dwFlags As UInteger, dx As UInteger, dy As UInteger, dwData As UInteger, dwExtraInfo As Integer)
    End Sub

    <Flags()> _
    Public Enum MouseEventFlags As UInteger
        MOUSEEVENTF_ABSOLUTE = &H8000
        MOUSEEVENTF_LEFTDOWN = &H2
        MOUSEEVENTF_LEFTUP = &H4
        MOUSEEVENTF_MIDDLEDOWN = &H20
        MOUSEEVENTF_MIDDLEUP = &H40
        MOUSEEVENTF_MOVE = &H1
        MOUSEEVENTF_RIGHTDOWN = &H8
        MOUSEEVENTF_RIGHTUP = &H10
        MOUSEEVENTF_XDOWN = &H80
        MOUSEEVENTF_XUP = &H100
        MOUSEEVENTF_WHEEL = &H800
        MOUSEEVENTF_HWHEEL = &H1000
    End Enum

    Const MAUSE_LEFT = 1
    Const MAUSE_RIGHT = 2

    <System.Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
    Public Structure POINTAPI
        Public X As Integer
        Public Y As Integer
    End Structure

#End Region

#Region " Declare's "

    Dim ProcessGame As String = String.Empty
    Dim ProcessID As Integer = Nothing
    Dim ProcessGameTitle As String = String.Empty
    Dim MausePos As New POINTAPI
    Dim ActivateH As Boolean = False

#End Region

#Region " Function's "

    Private Function Get_Process_PID(ByVal ProcessName As String) As IntPtr
        If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
        Dim ProcessArray = Process.GetProcessesByName(ProcessName)
        If ProcessArray.Length = 0 Then Return Nothing Else Return ProcessArray(0).Id
    End Function

    Private Function Get_Process_Window_Title(ByVal ProcessName As String) As String
        If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
        Dim ProcessArray = Process.GetProcessesByName(ProcessName)
        If ProcessArray.Length = 0 Then Return Nothing Else Return ProcessArray(0).MainWindowTitle
    End Function

    Private Function CorrectProcessString(ByVal processA As String) As String
        ' Another method would be :
        ' Dim ProcessName As String = Path.GetFileNameWithoutExtension(processA)
        ' Return ProcessName
        Dim ProcessName As String = processA
        If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
        Return ProcessName
    End Function

#End Region

#Region " GameMonitors "

    Private Sub GameOpenMonitor_Tick(sender As Object, e As EventArgs) Handles GameOpenMonitor.Tick
        ProcessGame = CorrectProcessString(ProcessTextBox.Text)
        Dim p As Process() = Process.GetProcessesByName(ProcessGame)
        If p.Count = 1 Then
            StatusLabel.Text = "The game is running!"
            StatusLabel.ForeColor = Color.Lime
            ProcessID = Get_Process_PID(ProcessGame)
            ProcessGameTitle = Get_Process_Window_Title(ProcessGame)
            NoRecoilTimer.Enabled = True
            FocusMonitor.Enabled = True
            GameEndMonitor.Enabled = True
            GameOpenMonitor.Enabled = False
        End If
    End Sub

    Private Sub GameEndMonitor_Tick(sender As Object, e As EventArgs) Handles GameEndMonitor.Tick
        Dim p As Process() = Process.GetProcessesByName(ProcessGame)
        If Not p.Count = 1 Then
            StatusLabel.Text = "The game has been Closed!"
            StatusLabel.ForeColor = Color.Red
            SaveSetting()
            NoRecoilTimer.Enabled = False
            FocusMonitor.Enabled = False
            GameOpenMonitor.Enabled = True
            GameEndMonitor.Enabled = False
        End If
    End Sub

#End Region

#Region " Setting "

    Private Sub SaveSetting()
        My.Settings.MauseValue = MauseValueTrackBar.Value
        My.Settings.SpeedValue = SpeedValueTrackBar.Value
        My.Settings.ProcessGameS = ProcessGame
        My.Settings.Save()
    End Sub

    Private Sub LoadSetting()
        On Error Resume Next
        MauseValueTrackBar.Value = My.Settings.MauseValue
        SpeedValueTrackBar.Value = My.Settings.SpeedValue
        ValueLabel.Text = MauseValueTrackBar.Value
        SpeedLabel.Text = SpeedValueTrackBar.Value
        ProcessGame = My.Settings.ProcessGameS
    End Sub

#End Region

#Region " Load/Close "
    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Computer.FileSystem.FileExists(LogFile) Then : My.Computer.FileSystem.DeleteFile(LogFile) : End If

        Try : AddHandler Application.ThreadException, AddressOf Application_Exception_Handler _
          : Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, False) _
          : Catch : End Try

        LoadSetting()
    End Sub

    Public Sub EventCallBack(hWinEventHook As IntPtr, [Event] As UInteger, hwnd As IntPtr, idObject As Integer, idChild As Integer, dwEventThread As UInteger, dwmsEventTime As UInteger)
       
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting()
    End Sub

    Private Sub DiscordButton11_Click(sender As Object, e As EventArgs) Handles DiscordButton11.Click
        Me.Close()
    End Sub

#End Region

#Region " LogSystem "

    Dim LogFile = CurDir() & "\" & System.Reflection.Assembly.GetExecutingAssembly.GetName().Name & ".log"

    Public Enum InfoType
        Information
        Exception
        Critical
        None
    End Enum

    Private Sub Application_Exception_Handler(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Dim ex As Exception = CType(e.Exception, Exception)
        WriteLog(ex.Message, InfoType.Exception)
     End Sub

    Private Function WriteLog(ByVal Message As String, ByVal InfoType As InfoType) As Boolean
        Dim LocalDate As String = My.Computer.Clock.LocalTime.ToString.Split(" ").First
        Dim LocalTime As String = My.Computer.Clock.LocalTime.ToString.Split(" ").Last
        Dim LogDate As String = "[ " & LocalDate & " ] " & " [ " & LocalTime & " ]  "
        Dim MessageType As String = Nothing

        Select Case InfoType
            Case InfoType.Information : MessageType = "Information: "
            Case InfoType.Exception : MessageType = "Error: "
            Case InfoType.Critical : MessageType = "Critical: "
            Case InfoType.None : MessageType = ""
        End Select

        Try
            My.Computer.FileSystem.WriteAllText(LogFile, vbNewLine & LogDate & MessageType & Message & vbNewLine, True)
            Return True
        Catch ex As Exception
            'Return False
            Throw New Exception(ex.Message)
        End Try

    End Function

#End Region

#Region " UI "

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/DestroyerDarkNess/External-No-Recoil")
    End Sub

#End Region

#Region " Focus App Monitor "

    Private Sub FocusMonitor_Tick(sender As Object, e As EventArgs) Handles FocusMonitor.Tick
        Dim FocusWindowedAPP As String = GetFocusActiveAPP.ToString
        If Not FocusWindowedAPP = ProcessGameTitle Then
            ActivateH = False
            WriteLog("The game is not in prescience. By deactivating Program, you can activate again in F2. (Inside the game) | " & FocusWindowedAPP & "≠" & ProcessGameTitle, InfoType.Exception)
        Else
            ActivateH = True
            WriteLog("Active game, You can activate Pressing F2. (In game) | " & FocusWindowedAPP & "=" & ProcessGameTitle, InfoType.Information)
        End If
    End Sub

    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

    Public Function GetFocusActiveAPP() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function

#End Region

    Private Sub NoRecoilTimer_Tick(sender As Object, e As EventArgs) Handles NoRecoilTimer.Tick
       If GetAsyncKeyState(113) = -32767 Then
            If ActivateH = False Then
                ActivateH = True
            Else
                ActivateH = False
            End If
        End If
        If ActivateH = True Then
            If GetAsyncKeyState(MAUSE_LEFT) <> 0 Then
                AppActivate(Get_Process_Window_Title(ProcessGame))
                Dim FuncGetPost As Boolean = GetCursorPos(MausePos)
                If FuncGetPost = True Then
                    SetCursorPos(MausePos.X, MausePos.Y + MauseValueTrackBar.Value)
                End If
            End If
        End If
    End Sub

    Private Sub ControlsMonitor_Tick(sender As Object, e As EventArgs) Handles ControlsMonitor.Tick
        Dim CalculateInverse As Integer = SpeedValueTrackBar.Maximum - SpeedValueTrackBar.Value
        If CalculateInverse = 0 Then
            CalculateInverse = 1
        End If
        NoRecoilTimer.Interval = CalculateInverse
        ValueLabel.Text = MauseValueTrackBar.Value
        SpeedLabel.Text = SpeedValueTrackBar.Value
    End Sub

End Class
