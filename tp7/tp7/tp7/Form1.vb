Public Class Form1
    Private Const TAILLE As Integer = 25
    Private NB_BOUTONS As Integer = 30
    Private foret(NB_BOUTONS - 1, NB_BOUTONS - 1) As Button
    Private arrRouge As New ArrayList
    Private ranDomNumber As Integer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initGene()
    End Sub
    'DECLARATION DES COMPOSANTS
    Dim pnlGene As New Panel

    Dim pnlForet As New TableLayoutPanel

    Private Sub initGene()

        Me.Size = New Size(595, 617)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog ' block d'option pour empecher le redimmenssionement de la fenetre 
        Me.SizeGripStyle = SizeGripStyle.Hide
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.AutoSize = False
        Me.Text = "Foret Simulator"

        pnlGene.Size = New Size(580, 580)
        pnlGene.Location = New Point(0, 0)
        pnlGene.BackColor = Color.Black

        pnlForet.Size = New Size(570, 570)
        pnlForet.Location = New Point(5, 5)
        pnlForet.RowCount = NB_BOUTONS
        pnlForet.ColumnCount = NB_BOUTONS
        pnlForet.BackColor = Color.White

        Me.Controls.Add(pnlGene)

        pnlGene.Controls.Add(pnlForet)
        CreerForet()

        AddHandler pnlForet.Click, AddressOf cooButt

    End Sub

    Public Sub CreerForet()
        For btn As Integer = 1 To 900
            Dim btnforet As New Button
            geneRanNum(btnforet)

            btnforet.Size = New Size(17, 17)
            btnforet.Margin = New Padding(1, 1, 1, 1)
            AddHandler btnforet.Click, AddressOf cooButt

            pnlForet.Controls.Add(btnforet)
        Next
    End Sub

    Private Sub cooButt(sender As Object, e As EventArgs)
        MsgBox("X : " + sender.location.X.ToString + "Y : " + sender.location.y.ToString)

    End Sub
    Private Sub departFeu()

    End Sub
    Private Sub geneRanNum(sender As Object)

        ranDomNumber = CInt(Math.Ceiling(Rnd() * 3)) - 1

        Select Case ranDomNumber
            Case 0
                sender.backColor = Color.Green
            Case 1
                sender.backColor = Color.Blue
            Case 2
                sender.backColor = Color.Brown
        End Select

    End Sub
End Class
