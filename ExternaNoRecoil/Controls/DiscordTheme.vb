'Discord Theme
'Made by DiamondWolf
'Creation date : 25/06/2019
'Last Update : 26/06/2019

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Module HelpersDiscord

    Enum RoundingStyle As Byte
        All = 0
        Top = 1
        Bottom = 2
        Left = 3
        Right = 4
        TopRight = 5
        BottomRight = 6
    End Enum

    Public Function FullRectangle(ByVal S As Size, ByVal Subtract As Boolean) As Rectangle
        If Subtract Then
            Return New Rectangle(0, 0, S.Width - 1, S.Height - 1)
        Else
            Return New Rectangle(0, 0, S.Width, S.Height)
        End If
    End Function
    Public Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

    Public Sub CenterString(ByVal G As Graphics, ByVal T As String, ByVal F As Font, ByVal C As Color, ByVal R As Rectangle)
        Dim TS As SizeF = G.MeasureString(T, F)

        Using B As New SolidBrush(C)
            G.DrawString(T, F, B, New Point(R.Width / 2 - (TS.Width / 2), R.Height / 2 - (TS.Height / 2)))
        End Using
    End Sub
    Public Sub CenterStringWidth(ByVal G As Graphics, ByVal T As String, ByVal F As Font, ByVal C As Color, ByVal R As Rectangle)
        Dim TS As SizeF = G.MeasureString(T, F)

        Using B As New SolidBrush(C)
            G.DrawString(T, F, B, New Point(R.Width / 2 - (TS.Width / 2), (50 - TS.Height) / 2))
        End Using
    End Sub

    Public Function RoundRect(ByVal Rect As Rectangle, ByVal Rounding As Integer, Optional ByVal Style As RoundingStyle = RoundingStyle.All) As Drawing2D.GraphicsPath

        Dim GP As New Drawing2D.GraphicsPath()
        Dim AW As Integer = Rounding * 2

        GP.StartFigure()

        If Rounding = 0 Then
            GP.AddRectangle(Rect)
            GP.CloseAllFigures()
            Return GP
        End If

        Select Case Style
            Case RoundingStyle.All
                GP.AddArc(New Rectangle(Rect.X, Rect.Y, AW, AW), -180, 90)
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Y, AW, AW), -90, 90)
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Height - AW + Rect.Y, AW, AW), 0, 90)
                GP.AddArc(New Rectangle(Rect.X, Rect.Height - AW + Rect.Y, AW, AW), 90, 90)
            Case RoundingStyle.Top
                GP.AddArc(New Rectangle(Rect.X, Rect.Y, AW, AW), -180, 90)
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Y, AW, AW), -90, 90)
                GP.AddLine(New Point(Rect.X + Rect.Width, Rect.Y + Rect.Height), New Point(Rect.X, Rect.Y + Rect.Height))
            Case RoundingStyle.Bottom
                GP.AddLine(New Point(Rect.X, Rect.Y), New Point(Rect.X + Rect.Width, Rect.Y))
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Height - AW + Rect.Y, AW, AW), 0, 90)
                GP.AddArc(New Rectangle(Rect.X, Rect.Height - AW + Rect.Y, AW, AW), 90, 90)
            Case RoundingStyle.Left
                GP.AddArc(New Rectangle(Rect.X, Rect.Y, AW, AW), -180, 90)
                GP.AddLine(New Point(Rect.X + Rect.Width, Rect.Y), New Point(Rect.X + Rect.Width, Rect.Y + Rect.Height))
                GP.AddArc(New Rectangle(Rect.X, Rect.Height - AW + Rect.Y, AW, AW), 90, 90)
            Case RoundingStyle.Right
                GP.AddLine(New Point(Rect.X, Rect.Y + Rect.Height), New Point(Rect.X, Rect.Y))
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Y, AW, AW), -90, 90)
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Height - AW + Rect.Y, AW, AW), 0, 90)
            Case RoundingStyle.TopRight
                GP.AddLine(New Point(Rect.X, Rect.Y + 1), New Point(Rect.X, Rect.Y))
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Y, AW, AW), -90, 90)
                GP.AddLine(New Point(Rect.X + Rect.Width, Rect.Y + Rect.Height - 1), New Point(Rect.X + Rect.Width, Rect.Y + Rect.Height))
                GP.AddLine(New Point(Rect.X + 1, Rect.Y + Rect.Height), New Point(Rect.X, Rect.Y + Rect.Height))
            Case RoundingStyle.BottomRight
                GP.AddLine(New Point(Rect.X, Rect.Y + 1), New Point(Rect.X, Rect.Y))
                GP.AddLine(New Point(Rect.X + Rect.Width - 1, Rect.Y), New Point(Rect.X + Rect.Width, Rect.Y))
                GP.AddArc(New Rectangle(Rect.Width - AW + Rect.X, Rect.Height - AW + Rect.Y, AW, AW), 0, 90)
                GP.AddLine(New Point(Rect.X + 1, Rect.Y + Rect.Height), New Point(Rect.X, Rect.Y + Rect.Height))
        End Select

        GP.CloseAllFigures()

        Return GP

    End Function

    Public Sub DrawRoundRect(ByVal G As Graphics, ByVal R As Rectangle, ByVal Curve As Integer, ByVal C As Color)

        Using P As New Pen(C)
            G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90)
            G.DrawLine(P, CInt(R.X + Curve / 2), R.Y, CInt(R.X + R.Width - Curve / 2), R.Y)
            G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90)
            G.DrawLine(P, R.X, CInt(R.Y + Curve / 2), R.X, CInt(R.Y + R.Height - Curve / 2))
            G.DrawLine(P, CInt(R.X + R.Width), CInt(R.Y + Curve / 2), CInt(R.X + R.Width), CInt(R.Y + R.Height - Curve / 2))
            G.DrawLine(P, CInt(R.X + Curve / 2), CInt(R.Y + R.Height), CInt(R.X + R.Width - Curve / 2), CInt(R.Y + R.Height))
            G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90)
            G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90)
        End Using

    End Sub

End Module
Public Class DiscordForm
    Inherits ContainerControl

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G.FillRectangle(New SolidBrush(Color.FromArgb(32, 34, 37)), New Rectangle(0, 0, Me.Width, 50))
        Dim TextHeight As Single = G.MeasureString(NewText, New Font("Segoe UI", 9)).Height
        Dim TextWhidth As Single = G.MeasureString(NewText, New Font("Segoe UI", 9)).Width
        CenterStringWidth(G, NewText, New Font("Segoe UI", 9), Color.White, New Rectangle(0, 0, Width, Height))
        MyBase.OnPaint(e)
        G.Dispose()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Me.Invalidate()
        MyBase.OnResize(e)
    End Sub

    Private MousePoint As New Point(0, 0)
    Private IsDown As Boolean = False

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = System.Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, 50).Contains(e.Location) Then
            IsDown = True
            MousePoint = e.Location
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        IsDown = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If IsDown Then
            Me.Parent.Location = MousePosition - MousePoint
        End If
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Me.ParentForm.FormBorderStyle = FormBorderStyle.None
        Me.ParentForm.AllowTransparency = False
        Me.ParentForm.TransparencyKey = Color.Fuchsia
        Me.ParentForm.FindForm.StartPosition = FormStartPosition.CenterScreen
        Me.Dock = DockStyle.Fill
        Me.Invalidate()
        Me.BackColor = Color.FromArgb(54, 57, 63)
        ' Me.Text = "Discord Theme"
    End Sub

    Dim NewText As String

    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            NewText = value
            Me.Invalidate()
        End Set
    End Property
End Class
Public Class DiscordTextBox
    Inherits Control
    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
    End Enum

    Private WithEvents TB As New TextBox
    Private G As Graphics
    Private State As MouseState
    Private IsDown As Boolean
    Private _UseSystemPasswordChar As Boolean
    <Category("Control")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        MyBase.OnGotFocus(e)
        TB.Focus()
    End Sub

    Private Sub TextChangeTb() Handles TB.TextChanged
        Text = TB.Text
    End Sub

    Private Sub TextChng() Handles MyBase.TextChanged
        TB.Text = Text
    End Sub

    Public Sub NewTextBox()
        With TB

            .Text = String.Empty
            .BackColor = Color.FromArgb(72, 76, 82)
            .ForeColor = Color.FromArgb(87, 90, 96)
            .TextAlign = HorizontalAlignment.Left
            .BorderStyle = BorderStyle.None
            .Location = New Point(3, 3)
            .Font = New Font("Segoe UI", 9)
            .Size = New Size(Width - 3, Height - 3)
        End With
    End Sub

    Sub New()
        MyBase.New()
        NewTextBox()
        Controls.Add(TB)
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        ForeColor = Color.FromArgb(220, 221, 222)
        Font = New Font("Segoe UI", 9)
        Size = New Size(130, 29)
        Enabled = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        MyBase.OnPaint(e)
        G.Clear(Color.FromArgb(54, 57, 63))
        G.FillPath(New SolidBrush(Color.FromArgb(72, 76, 82)), HelpersDiscord.RoundRect(HelpersDiscord.FullRectangle(Size, True), 1))

        TB.ForeColor = Color.FromArgb(155, 155, 160)

    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)

        Dim tbheight As Integer = TB.Height
        TB.Location = New Point(10, CType(((Height / 2) - (tbheight / 2) - 0), Integer))
        TB.Size = New Size(Width - 20, tbheight)

    End Sub

    Protected Overrides Sub OnEnter(ByVal e As EventArgs)
        MyBase.OnEnter(e)
        State = MouseState.Down : Invalidate()
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
        MyBase.OnLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

End Class
Public Class DiscordTab
    Inherits TabControl

#Region " Drawing "
    Private G As Graphics
    Private Rect As Rectangle
    Private LastIndex As Integer
    Private _Index As Integer = -1
    Private Property Index As Integer
        Get
            Return _Index
        End Get
        Set(ByVal value As Integer)
            _Index = value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True
        ItemSize = New Size(40, 170)
        Alignment = TabAlignment.Left
    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
        MyBase.OnControlAdded(e)
        e.Control.BackColor = Color.FromArgb(55, 57, 63)
        e.Control.ForeColor = Color.FromArgb(47, 49, 54)
        e.Control.Font = New Font("Segoe UI", 10)
        SizeMode = TabSizeMode.Fixed
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        G.Clear(Color.FromArgb(47, 49, 54)) 'Contour

        For i As Integer = 0 To TabPages.Count - 1

            Rect = GetTabRect(i)

            If String.IsNullOrEmpty(TabPages(i).Tag) Then

                If SelectedIndex = i Then

                    Using B As New SolidBrush(Color.FromArgb(64, 68, 75))
                        G.FillRectangle(B, Rect)
                    End Using
                    Using B As New SolidBrush(Color.White)
                        G.DrawString(TabPages(i).Text, New Font("Segoe UI semibold", 10), B, New Point(Rect.X + 55, Rect.Y + 12))

                    End Using

                Else

                    Using B As New SolidBrush(Color.FromArgb(66, 70, 77))

                    End Using
                    Using B As New SolidBrush(Color.FromArgb(144, 144, 144))
                        G.DrawString(TabPages(i).Text, New Font("Segoe UI semibold", 10), B, New Point(Rect.X + 55, Rect.Y + 12))
                    End Using

                End If

            Else

                Using B As New SolidBrush(Color.FromArgb(66, 70, 77))
                    G.DrawString(TabPages(i).Text.ToUpper, New Font("Segoe UI semibold", 9), B, New Point(Rect.X + 25, Rect.Y + 18))
                End Using

            End If

        Next

    End Sub

    Protected Overrides Sub OnSelecting(ByVal e As TabControlCancelEventArgs)
        MyBase.OnSelecting(e)

        If Not IsNothing(e.TabPage) Then
            If Not String.IsNullOrEmpty(e.TabPage.Tag) Then
                e.Cancel = True
            Else
                Index = -1
            End If
        End If

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        For i As Integer = 0 To TabPages.Count - 1
            If GetTabRect(i).Contains(e.Location) And Not SelectedIndex = i And String.IsNullOrEmpty(TabPages(i).Tag) Then
                Index = i
                Exit For
            End If
        Next
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        Index = -1
    End Sub

#End Region

End Class
Public Class DiscordButton1
    Inherits Control

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
    End Enum

    Private G As Graphics
    Private State As MouseState

    Public Shadows Event Click(ByVal sender As Object, ByVal e As EventArgs)

    Sub New()
        DoubleBuffered = True
        Enabled = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        Select Case State

            Case MouseState.Over

                G.FillPath(New SolidBrush(Color.FromArgb(103, 123, 196)), HelpersDiscord.RoundRect(HelpersDiscord.FullRectangle(Size, True), Height / 20))

            Case Else

                G.FillPath(New SolidBrush(Color.FromArgb(114, 137, 218)), HelpersDiscord.RoundRect(HelpersDiscord.FullRectangle(Size, True), Height / 20))

        End Select

        Using ButtonFont As New Font("Segoe UI", 9, FontStyle.Bold), Border As New Pen(Brushes.LightGray)

            HelpersDiscord.CenterString(G, Text, ButtonFont, Color.White, HelpersDiscord.FullRectangle(Size, False))
        End Using

    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()

    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Enabled Then
            RaiseEvent Click(Me, e)
        End If

        State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.None : Invalidate()
    End Sub

End Class
Public Class DiscordButton2
    Inherits Control

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
    End Enum

    Private G As Graphics
    Private State As MouseState

    Public Shadows Event Click(ByVal sender As Object, ByVal e As EventArgs)

    Sub New()
        DoubleBuffered = True
        Enabled = True
    End Sub

    Private _ColorBackGround As Color = Color.FromArgb(41, 43, 47)
    Public Property ColorBackGround() As Color
        Get
            Return _ColorBackGround
        End Get
        Set(ByVal value As Color)
            _ColorBackGround = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        Select Case State

            Case MouseState.Over

                G.FillPath(New SolidBrush(Color.FromArgb(47, 49, 54)), HelpersDiscord.RoundRect(HelpersDiscord.FullRectangle(Size, True), Height / 20))

            Case Else

                G.FillPath(New SolidBrush(_ColorBackGround), HelpersDiscord.RoundRect(HelpersDiscord.FullRectangle(Size, True), Height / 20))

        End Select

        Using ButtonFont As New Font("Segoe UI", 9, FontStyle.Bold), Border As New Pen(Brushes.LightGray)

            HelpersDiscord.CenterString(G, Text, ButtonFont, Color.White, HelpersDiscord.FullRectangle(Size, False))
        End Using

    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()

    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Enabled Then
            RaiseEvent Click(Me, e)
        End If

        State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.None : Invalidate()
    End Sub



End Class

Public Class DiscordSeparator
    Inherits Control

    Private G As Graphics

    Sub New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        Using C As New Pen(Color.FromArgb(47, 49, 54))
            G.DrawLine(C, New Point(0, 0), New Point(Width, 0))
        End Using

    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(Width, 2)
    End Sub

End Class



Public Class DiscordCheckBox
    Inherits Control

    Public Event CheckedChanged(sender As Object, e As EventArgs)

    Private _Checked As Boolean
    Private _EnabledCalc As Boolean
    Private G As Graphics

    Private B64Enabled As String = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAA1UlEQVQ4T6WTzQ2CQBCF56EnLpaiXvUAJBRgB2oFtkALdEAJnoVEMIGzdEIFjNkFN4DLn+xpD/N9efMWQAsPFvL0lyBMUg8MiwzyZwuiJAuI6CyTMxezBC24EuSTBTp4xaaN6JWdqKQbge6udfB1pfbBjrMvEMZZAdCm3ilw7eO1KRmCxRyiOH0TsFUQs5KMwVLweKY7ALFKUZUTECD6qdquCxM7i9jNhLJEraQ5xZzrYJngO9crGYBbAm2SEfhHoCQGeeK+Ls1Ld+fuM0/+kPp+usWCD10idEOGa4QuAAAAAElFTkSuQmCC"
    Private B64Disabled As String = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAA1UlEQVQ4T6WTzQ2CQBCF56EnLpaiXvUAJBRgB2oFtkALdEAJnoVEMIGzdEIFjNkFN4DLn+xpD/N9efMWQAsPFvL0lyBMUg8MiwzyZwuiJAuI6CyTMxezBC24EuSTBTp4xaaN6JWdqKQbge6udfB1pfbBjrMvEMZZAdCm3ilw7eO1KRmCxRyiOH0TsFUQs5KMwVLweKY7ALFKUZUTECD6qdquCxM7i9jNhLJEraQ5xZzrYJngO9crGYBbAm2SEfhHoCQGeeK+Ls1Ld+fuM0/+kPp+usWCD10idEOGa4QuAAAAAElFTkSuQmCC"

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Public Shadows Property Enabled As Boolean
        Get
            Return EnabledCalc
        End Get
        Set(value As Boolean)
            _EnabledCalc = value

            If Enabled Then
                Cursor = Cursors.Hand
            Else
                Cursor = Cursors.Default
            End If

            Invalidate()
        End Set
    End Property


    Public Property EnabledCalc As Boolean
        Get
            Return _EnabledCalc
        End Get
        Set(value As Boolean)
            Enabled = value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True
        Enabled = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)



        If Enabled Then

            Using Background As New SolidBrush(Color.FromArgb(72, 76, 82)), Border As New Pen(Color.FromArgb(41, 43, 47)), TextColor As New SolidBrush(Color.FromArgb(220, 221, 222)), TextFont As New Font("Segoe UI", 9)
                G.FillPath(Background, HelpersDiscord.RoundRect(New Rectangle(0, 0, 16, 16), 3))
                G.DrawPath(Border, HelpersDiscord.RoundRect(New Rectangle(0, 0, 16, 16), 1))
                G.DrawString(Text, TextFont, TextColor, New Point(25, 0))
            End Using

            If Checked Then

                Using I As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String(B64Enabled)))
                    G.DrawImage(I, New Rectangle(3, 3, 11, 11))
                End Using

            End If

        Else

            Using Background As New SolidBrush(Color.FromArgb(103, 123, 196)), Border As New Pen(Color.FromArgb(103, 123, 196)), TextColor As New SolidBrush(Color.FromArgb(103, 123, 196)), TextFont As New Font("Segoe UI", 9)
                G.FillPath(Background, HelpersDiscord.RoundRect(New Rectangle(0, 0, 16, 16), 3))
                G.DrawPath(Border, HelpersDiscord.RoundRect(New Rectangle(0, 0, 16, 16), 3))
                G.DrawString(Text, TextFont, TextColor, New Point(25, 0))
            End Using

            If Checked Then

                Using I As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String(B64Disabled)))
                    G.DrawImage(I, New Rectangle(3, 3, 11, 11))
                End Using

            End If

        End If

    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Enabled Then
            Checked = Not Checked
            RaiseEvent CheckedChanged(Me, e)
        End If

    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(Width, 18)
    End Sub

End Class





Public Class DiscordProgressBar
    Inherits Control

#Region "Declarations"
    Private _ProgressColour As Color = Color.FromArgb(114, 137, 218)
    Private _GlowColour As Color = Color.FromArgb(114, 137, 218)
    Private _BorderColour As Color = Color.FromArgb(114, 137, 218)
    Private _BaseColour As Color = Color.FromArgb(233, 231, 231)
    Private _FontColour As Color = Color.FromArgb(50, 50, 50)
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
#End Region

#Region "Properties"

    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property ProgressColour As Color
        Get
            Return _ProgressColour
        End Get
        Set(value As Color)
            _ProgressColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property GlowColour As Color
        Get
            Return _GlowColour
        End Get
        Set(value As Color)
            _GlowColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _FontColour
        End Get
        Set(value As Color)
            _FontColour = value
        End Set
    End Property

#End Region

#Region "Events"

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 8
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Height = 8
    End Sub

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(60, 70, 73)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B = New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Dim ProgVal As Integer = CInt(_Value / _Maximum * (Width + 1))
            Select Case Value
                Case 0
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .DrawLine(New Pen(_BorderColour), New Point(Width + 1, 0), New Point(Width + 1, Height))
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))

                Case _Maximum
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))

                Case Else
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))


            End Select
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class




Public Class DiscordListBox
    Inherits Control

#Region "Declarations"

    Private WithEvents ListB As New ListBox
    Private _Items As String() = {""}
    Private _BaseColour As Color = Color.FromArgb(72, 76, 82)
    Private _SelectedColour As Color = Color.FromArgb(114, 137, 218)
    Private _TextColour As Color = Color.FromArgb(163, 163, 163)
    Private _BorderColour As Color = Color.FromArgb(114, 137, 218)

#End Region

#Region "Properties"

    <Category("Control")> _
    Public Property Items As String()
        Get
            Return _Items
        End Get
        Set(value As String())
            _Items = value
            ListB.Items.Clear()
            ListB.Items.AddRange(value)
            Invalidate()
        End Set
    End Property

    <Category("Colours")> _
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")> _
    Public Property SelectedColour As Color
        Get
            Return _SelectedColour
        End Get
        Set(value As Color)
            _SelectedColour = value
        End Set
    End Property

    <Category("Colours")> _
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")> _
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As String
        Get
            Return ListB.SelectedItem
        End Get
    End Property

    Public ReadOnly Property SelectedIndex() As Integer
        Get
            Return ListB.SelectedIndex
            If ListB.SelectedIndex < 0 Then Exit Property
        End Get
    End Property

    Public Sub Clear()
        ListB.Items.Clear()
    End Sub

    Public Sub ClearSelected()
        For i As Integer = (ListB.SelectedItems.Count - 1) To 0 Step -1
            ListB.Items.Remove(ListB.SelectedItems(i))
        Next
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(ListB) Then
            Controls.Add(ListB)
        End If
    End Sub

    Sub AddRange(ByVal items As Object())
        ListB.Items.Remove("")
        ListB.Items.AddRange(items)
    End Sub

    Sub AddItem(ByVal item As Object)
        ListB.Items.Remove("")
        ListB.Items.Add(item)
    End Sub

#End Region

#Region "Draw Control"

    Sub Drawitem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles ListB.DrawItem
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        e.DrawFocusRectangle()
        With e.Graphics
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .InterpolationMode = InterpolationMode.HighQualityBicubic
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            If InStr(e.State.ToString, "Selected,") > 0 Then
                .FillRectangle(New SolidBrush(_BaseColour), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
                .DrawLine(New Pen(_BorderColour), e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
                .DrawString(" " & ListB.Items(e.Index).ToString(), New Font("Segoe UI", 9, FontStyle.Bold), New SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2)
            Else
                .FillRectangle(New SolidBrush(_BaseColour), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
                .DrawString(" " & ListB.Items(e.Index).ToString(), New Font("Segoe UI", 8), New SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2)
            End If
            .Dispose()
        End With
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
            ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        ListB.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        ListB.ScrollAlwaysVisible = False
        ListB.HorizontalScrollbar = False
        ListB.BorderStyle = BorderStyle.None
        ListB.BackColor = _BaseColour
        ListB.Location = New Point(3, 3)
        ListB.Font = New Font("Segoe UI", 8)
        ListB.ItemHeight = 20
        ListB.Items.Clear()
        ListB.IntegralHeight = False
        Size = New Size(130, 100)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .Clear(Color.FromArgb(248, 250, 249))
            ListB.Size = New Size(Width - 6, Height - 7)
            .FillRectangle(New SolidBrush(BaseColour), Base)
            .DrawRectangle(New Pen((_BorderColour), 1), New Rectangle(0, 0, Width, Height - 1))
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class


Public Class DiscordLabel
    Inherits Label

#Region "Declaration"
    Private _FontColour As Color = Color.FromArgb(155, 155, 160)
#End Region

#Region "Property & Event"

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _FontColour
        End Get
        Set(value As Color)
            _FontColour = value
        End Set
    End Property

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Font = New Font("Segoe UI semibold", 9)
        ForeColor = _FontColour
        BackColor = Color.Transparent
        Text = Text
    End Sub

#End Region

End Class

Public Class DiscordRadioButton
    Inherits Control

    Public Event CheckedChanged(sender As Object, e As EventArgs)

    Private _Checked As Boolean
    Private _EnabledCalc As Boolean
    Private G As Graphics

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Public Shadows Property Enabled As Boolean
        Get
            Return EnabledCalc
        End Get
        Set(value As Boolean)
            _EnabledCalc = value

            If Enabled Then
                Cursor = Cursors.Hand
            Else
                Cursor = Cursors.Default
            End If

            Invalidate()
        End Set
    End Property


    Public Property EnabledCalc As Boolean
        Get
            Return _EnabledCalc
        End Get
        Set(value As Boolean)
            Enabled = value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True
        Enabled = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)



        If Enabled Then

            Using Background As New SolidBrush(Color.FromArgb(72, 76, 82)), Border As New Pen(Color.FromArgb(41, 43, 47)), TextColor As New SolidBrush(Color.FromArgb(220, 221, 222)), TextFont As New Font("Segoe UI", 9)
                G.FillEllipse(Background, New Rectangle(0, 0, 16, 16))
                G.DrawEllipse(Border, New Rectangle(0, 0, 16, 16))
                G.DrawString(Text, TextFont, TextColor, New Point(25, 0))
            End Using

            If Checked Then

                Using Background As New SolidBrush(Color.FromArgb(114, 137, 218))
                    G.FillEllipse(Background, New Rectangle(4, 4, 8, 8))
                End Using

            End If

        Else

            Using Background As New SolidBrush(Color.FromArgb(103, 123, 196)), Border As New Pen(Color.FromArgb(103, 123, 196)), TextColor As New SolidBrush(Color.FromArgb(103, 123, 196)), TextFont As New Font("Segoe UI", 9)
                G.FillEllipse(Background, New Rectangle(0, 0, 16, 16))
                G.DrawEllipse(Border, New Rectangle(0, 0, 16, 16))
                G.DrawString(Text, TextFont, TextColor, New Point(25, 0))
            End Using

            If Checked Then

                Using Background As New SolidBrush(Color.FromArgb(114, 137, 218))
                    G.FillEllipse(Background, New Rectangle(4, 4, 8, 8))
                End Using

            End If

        End If

    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Enabled Then

            For Each C As Control In Parent.Controls
                If TypeOf C Is DiscordRadioButton Then
                    DirectCast(C, DiscordRadioButton).Checked = False
                End If
            Next

            Checked = Not Checked
            RaiseEvent CheckedChanged(Me, e)
        End If

    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(Width, 18)
    End Sub

End Class