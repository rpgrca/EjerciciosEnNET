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

        agendaView.LlenarListaCon(_agenda.Filtrar(Nothing))
        agendaView.Show()
    End Sub

    Private Sub AgregarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem1.Click
        Dim agendaView As AgendaView = New AgendaView(_agenda) With {
            .MdiParent = Me
        }

        agendaView.PrepararParaBusqueda()
        agendaView.Show()
    End Sub
End Class