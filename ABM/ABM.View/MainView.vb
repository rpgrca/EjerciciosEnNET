Imports ABM.Core

Public Class MainView

    private ReadOnly _agenda As Agenda

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _agenda = Agenda.Nuevo.Constructor.Construir()
    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        Dim agendaView As AgendaView = new AgendaView(_agenda) With {
            .MdiParent = Me
        }

        agendaView.LlenarListaConAgenda()
        agendaView.Show()
    End Sub

End Class