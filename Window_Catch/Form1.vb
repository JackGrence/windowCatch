Public Class Form1
    'f1 = 112
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassname As String, ByVal lpWindowName As String) As Integer
    Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hwndinsertafter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uflags As Integer) As Boolean
    Declare Function GetWindowRect Lib "user32" (ByVal hwnd As Integer, ByRef lpRect As rect) As Boolean
    Declare Function GetForegroundWindow Lib "user32" () As Integer
    Declare Function GetAsyncKeyState Lib "user32" (ByVal key As Integer) As Short
    Declare Function GetCursorPos Lib "user32" (ByRef p As Point) As Boolean

    Public pt As Point
    Structure rect
        Dim left As Integer
        Dim top As Integer
        Dim right As Integer
        Dim bottom As Integer

    End Structure
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim hwd As Integer
        Dim str As String
        Dim xy As rect
        Dim proc() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcesses

        str = TextBox1.Text

        For Each p As System.Diagnostics.Process In proc
            If p.ProcessName = str Then
                hwd = FindWindow(vbNullString, p.MainWindowTitle)
                GetWindowRect(hwd, xy)
                GetCursorPos(pt)
                SetWindowPos(hwd, 0, pt.X, pt.Y, xy.right - xy.left, xy.bottom - xy.top, 4)
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim hwd As Integer
        Dim xy As rect
        If GetAsyncKeyState(17) And GetAsyncKeyState(36) Then
            hwd = GetForegroundWindow
            GetWindowRect(hwd, xy)
            GetCursorPos(pt)
            SetWindowPos(hwd, 0, pt.X, pt.Y, xy.right - xy.left, xy.bottom - xy.top, 4)
        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        Debug.Print(e.KeyCode)
    End Sub
End Class
