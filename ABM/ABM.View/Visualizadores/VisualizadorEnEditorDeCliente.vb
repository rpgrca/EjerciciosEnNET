Imports ABM.Core.Visualizadores

Namespace Visualizadores

    Public Class VisualizadorEnEditorDeCliente
        Implements IVisualizadorDeCliente

        Private ReadOnly _datosDeCliente As DatosDeCliente

        Public Sub New(datosDeCliente As DatosDeCliente)
            _datosDeCliente = datosDeCliente
        End Sub

        Public Sub Generar(id As Integer, nombre As String, telefono As String, correo As String) Implements IVisualizadorDeCliente.Generar
            _datosDeCliente.Inicializar(id, nombre, telefono, correo)
        End Sub

    End Class

End NameSpace