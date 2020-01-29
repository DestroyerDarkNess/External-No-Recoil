Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Module ThemeModule

    Friend G As Graphics

    Sub New()
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
    End Sub

    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics

    Friend Function MeasureString(text As String, font As Font) As SizeF
        Return TextGraphics.MeasureString(text, font)
    End Function

    Friend Function MeasureString(text As String, font As Font, width As Integer) As SizeF
        Return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic)
    End Function

    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Friend Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Friend Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

End Module

<DefaultEvent("Scroll")> _
Class SevenOperXTrackBar
    Inherits Control

    Event Scroll(ByVal sender As Object)

    Public Property BarColorFromBoxmoving As Boolean

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property

    Private _Maximum As Integer = 10
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer

        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            Invalidate()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Dim _BarProgressColor As Color = Color.FromArgb(107, 57, 216)
    Public Property BarProgressColor() As Color
        Get
            Return _BarProgressColor
        End Get
        Set(ByVal v As Color)
            _BarProgressColor = v
            Invalidate()
        End Set
    End Property

    Dim _BarColor As Color = Color.FromArgb(60, 60, 63)
    Public Property BarColor() As Color
        Get
            Return _BarColor
        End Get
        Set(ByVal v As Color)
            _BarColor = v
            Invalidate()
        End Set
    End Property

    Dim _BoxColor As Color = Color.FromArgb(60, 60, 63)
    Public Property BoxColor() As Color
        Get
            Return _BoxColor
        End Get
        Set(ByVal v As Color)
            _BoxColor = v
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Height = 17

        P1 = New Pen(_BarProgressColor, 2)
        P2 = New Pen(Color.FromArgb(24, 26, 26))
        P3 = New Pen(Color.FromArgb(24, 26, 26))
        P4 = New Pen(Color.FromArgb(24, 26, 26))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private R1, R2, R3 As Rectangle
    Private I1 As Integer

    Private P1, P2, P3, P4 As Pen

    Private GB1, GB2, GB3 As LinearGradientBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 5, Width - 1, 10, 5)
        GP2 = CreateRound(1, 6, Width - 3, 8, 5)

        R1 = New Rectangle(0, 7, Width - 1, 5)
        GB1 = New LinearGradientBrush(R1, _BarColor, _BarColor, 90.0F)

        I1 = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
        R2 = New Rectangle(I1, 0, 10, 20)

        G.SetClip(GP2)
        G.FillRectangle(GB1, R1)

        R3 = New Rectangle(1, 7, R2.X + R2.Width - 2, 8)
        GB2 = New LinearGradientBrush(R3, _BarProgressColor, _BarProgressColor, 90.0F)

        G.SmoothingMode = SmoothingMode.None
        G.FillRectangle(GB2, R3)
        G.SmoothingMode = SmoothingMode.AntiAlias

        For I As Integer = 0 To R3.Width - 15 Step 5
            G.DrawLine(P1, I, 0, I + 15, Height)
        Next

        G.ResetClip()

        G.DrawPath(P2, GP1)
        G.DrawPath(P3, GP2)

        GP3 = CreateRound(R2, 5)
        GP4 = CreateRound(R2.X + 1, R2.Y + 1, R2.Width - 2, R2.Height - 2, 5)

        If BarColorFromBoxmoving = False Then
            GB3 = New LinearGradientBrush(ClientRectangle, _BoxColor, _BoxColor, 90.0F)
        Else
            GB3 = New LinearGradientBrush(ClientRectangle, _BarProgressColor, _BarProgressColor, 90.0F)
        End If

        G.FillRectangle(GB3, New Rectangle(R2.X, R2.Y, 10, 20))
        ' Dim Pointsa As Point() = {New Point(10), New Point(10), New Point(10)}
        ' G.FillPi(GB3, New Rectangle(R2.X, R2.Y, 10, 20), 5, 4)
        ' G.FillPath(GB3, GP3)
        ' G.DrawPath(P3, GP3)
        ' G.DrawPath(P4, GP4)
    End Sub

    Private TrackDown As Boolean
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            I1 = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
            R2 = New Rectangle(I1, 0, 10, 20)

            TrackDown = R2.Contains(e.Location)
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If TrackDown AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
            Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        TrackDown = False
        MyBase.OnMouseUp(e)
    End Sub

End Class