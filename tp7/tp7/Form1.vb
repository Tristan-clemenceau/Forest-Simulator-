Public Class Form1
    Private Const TAILLE As Integer = 25
    Private NB_BOUTONS As Integer = 30
    Private foret(NB_BOUTONS - 1, NB_BOUTONS - 1) As Button
    Private arrRouge As New ArrayList


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initGene()
        CreerForet()
        DonnerCouleurs()

    End Sub
    'DECLARATION DES COMPOSANTS ET VARIABLES
    Dim pnlGene As New Panel

    Dim pnlForet As New TableLayoutPanel

    Dim timerSimulateur As New Timer

    Dim estLance As Boolean = False

    Dim ligne As Integer

    Dim trouveX As Integer
    Dim trouverY As Integer

    Private Sub initGene()
        Me.Text = "Simulateur Foret"
        Me.Size = New Size(596, 619)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.SizeGripStyle = SizeGripStyle.Hide
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.AutoSize = False

        pnlGene.Size = New Size(580, 580)
        pnlGene.Location = New Point(0, 0)
        pnlGene.BackColor = Color.Gray

        pnlForet.Size = New Size(570, 570)
        pnlForet.Location = New Point(5, 5)
        pnlForet.RowCount = NB_BOUTONS
        pnlForet.ColumnCount = NB_BOUTONS
        pnlForet.BackColor = Color.Gray

        Me.Controls.Add(pnlGene)

        AddHandler timerSimulateur.Tick, AddressOf PopagationTick

        pnlGene.Controls.Add(pnlForet)


    End Sub

    Private Sub CreerForet()
        For i As Integer = 0 To 29
            For j As Integer = 0 To 29
                Dim btnforet As New Button

                btnforet.Size = New Size(17, 17)
                btnforet.Margin = New Padding(1, 1, 1, 1)

                foret(i, j) = btnforet

                AddHandler btnforet.Click, AddressOf DepartForet

                pnlForet.Controls.Add(btnforet)

            Next
        Next
    End Sub

    Private Sub DepartForet(sender As Object, e As EventArgs)
        If (sender.backcolor.name.Equals(Color.Green.Name)) Then
            Console.WriteLine("Vert = " + sender.backcolor.name)
            arrRouge.Add(sender)
            sender.backColor = Color.Red
            timerInit()
            RecherchePoint(sender)
            ChangerVoisin(trouveX, trouverY)
            MiseAJour()
        Else
            Console.WriteLine("Vert != " + sender.backcolor.name)
        End If
    End Sub

    Private Sub DonnerCouleurs()
        For i As Integer = 0 To 29
            For j As Integer = 0 To 29
                Dim btnforet As New Button

                couleurBackSetUp(foret(i, j), randomNumber())

            Next
        Next
    End Sub

    Private Function randomNumber() As Integer

        Dim numberRand As Integer

        numberRand = Int(Rnd() * 3)

        Return numberRand
    End Function

    Private Sub couleurBackSetUp(sender As Object, rand As Integer)
        Select Case rand
            Case 0
                sender.backcolor = Color.Green
            Case 1
                sender.backcolor = Color.Blue
            Case 2
                sender.backcolor = Color.Brown
            Case Else
                MsgBox("Erreur : Random pas entre 0 et 2")
        End Select
    End Sub

    Private Sub timerInit()
        If (estLance) Then
            Console.WriteLine("Timer actif")
        Else
            Console.WriteLine("Timer en cours d'activation")
            timerSimulateur.Interval = 1000
            timerSimulateur.Enabled = True
            timerSimulateur.Start()
            estLance = True

        End If
    End Sub

    Private Sub MiseAJour()
        ClearArrayList()
        ParcourBtnRouge()
    End Sub

    Private Sub ClearArrayList()
        arrRouge.Clear()
    End Sub

    Private Sub ParcourBtnRouge() 'Parcours foret et ajoute les boutons rouges dans l'array list
        For i As Integer = 0 To 29
            For j As Integer = 0 To 29
                Dim btnforet As New Button

                If (foret(i, j).BackColor.Name.Equals(Color.Red.Name)) Then
                    arrRouge.Add(foret(i, j))
                End If

            Next
        Next
    End Sub

    Private Sub ChangerVoisin(valX As Integer, valY As Integer) 'Pour un point donné execute les procedures ligne haut , ligne mileu , ligne bas car un point dans une matrice de 3 x 3 possede trois lignes 
        '|A|B|C|   x = ligne 
        '|D|E|F|   y = colonne
        '|G|H|I|

        If (estdansMAtrice(valX - 1, valY - 1)) Then 'Point A
            verifPoint(valX - 1, valY - 1)
        End If
        If (estdansMAtrice(valX - 1, valY)) Then 'Point B
            verifPoint(valX - 1, valY)
        End If
        If (estdansMAtrice(valX - 1, valY + 1)) Then 'Point C
            verifPoint(valX - 1, valY + 1)
        End If
        If (estdansMAtrice(valX, valY - 1)) Then 'Point D
            verifPoint(valX, valY - 1)
        End If
        If (estdansMAtrice(valX, valY + 1)) Then 'Point F
            verifPoint(valX, valY + 1)
        End If
        If (estdansMAtrice(valX + 1, valY - 1)) Then 'Point G
            verifPoint(valX + 1, valY - 1)
        End If
        If (estdansMAtrice(valX + 1, valY)) Then 'Point H
            verifPoint(valX + 1, valY)
        End If
        If (estdansMAtrice(valX + 1, valY + 1)) Then 'Point H
            verifPoint(valX + 1, valY + 1)
        End If
    End Sub

    Private Sub verifPoint(ptx As Integer, pty As Integer)
        If (foret(ptx, pty).BackColor.Name.Equals(Color.Green.Name)) Then
            foret(ptx, pty).BackColor = Color.Red
        Else
            Console.WriteLine("Pas de couleur vert")
        End If

    End Sub

    Private Function estdansMAtrice(ptx As Integer, pty As Integer) As Boolean
        Dim boolVerif As Boolean = False
        If ((ptx >= 0 And ptx <= NB_BOUTONS - 1) And (pty >= 0 And pty <= NB_BOUTONS - 1)) Then
            Console.WriteLine("est dans matice")
            boolVerif = True
        Else
            Console.WriteLine("n'est pas dans matrice")
        End If
        Return boolVerif
    End Function

    Private Sub RecherchePoint(sender As Object)
        For i As Integer = 0 To 29
            For j As Integer = 0 To 29
                Dim btnforet As New Button

                If (sender.Equals(foret(i, j))) Then
                    Console.WriteLine("Trouve X : " + i.ToString + " Y : " + j.ToString)
                    trouverY = j
                    trouveX = i
                End If

            Next
        Next
    End Sub

    Private Sub PopagationTick()
        For Each btn In arrRouge
            RecherchePoint(btn)
            ChangerVoisin(trouveX, trouverY)
        Next
        MiseAJour()
    End Sub
End Class
