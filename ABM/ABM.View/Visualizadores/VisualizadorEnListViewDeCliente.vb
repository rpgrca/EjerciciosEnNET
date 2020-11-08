Imports ABM.Core.Visualizadores

Namespace Visualizadores

    Public Class VisualizadorEnListViewDeCliente
        Implements IVisualizadorDeCliente

        Private ReadOnly _listView As ListView

        Public Sub New(listView As ListView)
            _listView = listView
        End Sub

        Public Sub Generar(id As Integer, nombre As String, telefono As String, correo As String) Implements IVisualizadorDeCliente.Generar
            Dim listViewItem As ListViewItem = _listView.Items.Add(id.ToString())
            listViewItem.SubItems.Add(nombre)
            listViewItem.SubItems.Add(telefono)
            listViewItem.SubItems.Add(correo)
        End Sub

    End Class
End NameSpace