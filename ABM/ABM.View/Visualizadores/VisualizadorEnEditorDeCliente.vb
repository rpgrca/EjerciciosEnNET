Imports ABM.Core.Visualizadores

Namespace Visualizadores

    Public Class VisualizadorEnEditorDeCliente
        Implements IVisualizadorDeCliente

        Private ReadOnly _editorDeId As TextBox
        Private ReadOnly _editorDeNombre As TextBox
        Private ReadOnly _editorDeTelefono As TextBox
        Private ReadOnly _editorDeCorreo As TextBox

        Public Sub New(agendaView As AgendaView)
            _editorDeId = agendaView.editorDeId
            _editorDeNombre = agendaView.editorDeNombre
            _editorDeTelefono = agendaView.editorDeTelefono
            _editorDeCorreo = agendaView.editorDeCorreo
        End Sub

        Public Sub Generar(id As Integer, nombre As String, telefono As String, correo As String) Implements IVisualizadorDeCliente.Generar
            _editorDeId.Text = id.ToString()
            _editorDeNombre.Text = nombre
            _editorDeTelefono.Text = telefono
            _editorDeCorreo.Text = correo
        End Sub

    End Class
End NameSpace