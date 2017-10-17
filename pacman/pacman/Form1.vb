Public Class Form1
    Dim switch As Boolean = True
    Dim dir As Integer = 0
    Dim a As Boolean = True
    Dim pox As Integer = 0
    Dim poy As Integer = 0
    Dim way As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim player_R As Rectangle = New Rectangle(Me.PictureBox1.Location, Me.PictureBox1.Size)
        Dim ghost_R As Rectangle = New Rectangle(Me.PictureBox2.Location, Me.PictureBox2.Size)
        If (player_R.IntersectsWith(ghost_R) = True And a = True) Then
            a = False
            PictureBox2.Visible = False
            MessageBox.Show("You Win!")
            MessageBox.Show("New Game!")
            Application.Restart()
        End If

        If dir = 0 Then

            If switch = True Then
                PictureBox1.Image = My.Resources.pac1
            Else
                PictureBox1.Image = My.Resources.pac2
            End If
            switch = Not switch

        ElseIf dir = 1 Then

            If switch = True Then
                PictureBox1.Image = My.Resources.pac11
            Else
                PictureBox1.Image = My.Resources.pac22
            End If
            switch = Not switch

        ElseIf dir = 2 Then

            If switch = True Then
                PictureBox1.Image = My.Resources.pac111
            Else
                PictureBox1.Image = My.Resources.pac222
            End If
            switch = Not switch


        ElseIf dir = 3 Then

            If switch = True Then
                PictureBox1.Image = My.Resources.pac1111
            Else
                PictureBox1.Image = My.Resources.pac2222
            End If
            switch = Not switch
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim key As Integer = e.KeyValue
        Me.Text = key
        If key = 87 Then
            dir = 2
            PictureBox1.Top -= 10
            If PictureBox1.Top < 0 Then
                PictureBox1.Top = 0
            End If
        End If
        If key = 83 Then
            dir = 3
            PictureBox1.Top += 10
            If PictureBox1.Top > Me.Height - PictureBox1.Height - 42 Then
                PictureBox1.Top = Me.Height - PictureBox1.Height - 42
            End If
        End If

        If key = 65 Then
            dir = 0
            PictureBox1.Left -= 10
            If PictureBox1.Left < 0 Then
                PictureBox1.Left = 0
            End If
        End If
        If key = 68 Then
            dir = 1
            PictureBox1.Left += 10
            If PictureBox1.Left > Me.Width - PictureBox1.Width - 20 Then
                PictureBox1.Left = Me.Width - PictureBox1.Width - 20
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If PictureBox2.Left > Me.Width - PictureBox2.Width - 20 Then
            pox = 0
        ElseIf PictureBox2.Left < 0 Then
            pox = 1
        End If
        If PictureBox2.Top > Me.Height - PictureBox2.Height - 42 Then
            poy = 1
        ElseIf PictureBox2.Top < 0 Then
            poy = 0
        End If
        If way = 0 Then
            If pox = 1 Then
                PictureBox2.Left += 1
            ElseIf pox = 0 Then
                PictureBox2.Left -= 1
            End If
        End If
        If way = 1 Then
            If poy = 0 Then
                PictureBox2.Top += 1
            ElseIf poy = 1 Then
                PictureBox2.Top -= 1
            End If
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Randomize()
        pox = Int(Rnd() * 2)
        Randomize()
        poy = Int(Rnd() * 2)
        Randomize()
        way = Int(Rnd() * 2)
    End Sub
End Class
