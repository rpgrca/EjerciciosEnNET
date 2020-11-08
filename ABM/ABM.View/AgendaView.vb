Imports ABM.Core
Imports ABM.View.Visualizadores

Public Class AgendaView

    Private ReadOnly _agenda As Agenda

    Public Sub New(agenda As Agenda)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Text = "Agenda"
        _agenda = agenda
        CrearColumnas()
        AjustarTamanoDeColumnas()
        CambiarBotonAAgregar()
    End Sub

    Private Sub CrearColumnas()
        ListView1.Columns.Add("Id", "Id", 50)
        ListView1.Columns.Add("Nombre", "Nombre", 200)
        ListView1.Columns.Add("Telefono", "Telefono", 100)
        ListView1.Columns.Add("Correo", "Correo", 100)
    End Sub

    Public Sub LlenarListaConAgenda()
        Dim clientes As List(Of Cliente)

        clientes = _agenda.Filtrar(Nothing)
        For Each cliente As Cliente In clientes
            Dim visualizador As New VisualizadorEnListViewDeCliente(ListView1)
            cliente.MostrarmeEn(visualizador)
        Next
    End Sub

    Private Sub LimpiarLista()
        ListView1.Items.Clear()
    End Sub

    Private Sub AlAgregar(sender As Object, e As EventArgs)
        _agenda.CrearY(editorDeNombre.Text, editorDeTelefono.Text, editorDeCorreo.Text) _
            .ConErrorEjecutar(Sub(mensajeDeError) MessageBox.Show(mensajeDeError)) _
            .ConExitoEjecutar(Sub(clienteCreado) AgendarClienteNuevoYRefrescarLista(clienteCreado))
    End Sub

    Private Sub AlEditar(sender As Object, e As EventArgs)
        Dim cliente As Cliente = ObtenerClienteDeEdicion()

        _agenda.CambiarNombreDeY(cliente, editorDeNombre.Text) _
            .ConErrorEjecutar(Sub(mensajeDeError) MessageBox.Show(mensajeDeError)) _
            .ConExitoEjecutar(Sub(clienteModificado) ModificarClienteYRefrescarLista(clienteModificado))
    End Sub

    Private Sub AgendarClienteNuevoYRefrescarLista(clienteCreado As Cliente)
        _agenda.Agregar(clienteCreado)

        LimpiarLista()
        LimpiarTextos()
        LlenarListaConAgenda()
        AjustarTamanoDeColumnas()
    End Sub

    Private Sub ModificarClienteYRefrescarLista(clienteModificado As Cliente)
        clienteModificado = _agenda.CambiarTelefonoDe(clienteModificado, editorDeTelefono.Text)
        _agenda.CambiarCorreoDe(clienteModificado, editorDeCorreo.Text)

        LimpiarLista()
        LimpiarTextos()
        LlenarListaConAgenda()
        AjustarTamanoDeColumnas()
        CambiarBotonAAgregar()
    End Sub

    Private Sub LimpiarTextos()
        editorDeNombre.Text = String.Empty
        editorDeTelefono.Text = String.Empty
        editorDeCorreo.Text = String.Empty
    End Sub

    Private Sub AjustarTamanoDeColumnas()
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        Dim tamanoPorColumnas As Integer

        For index As Integer = 0 To 2
            ListView1.AutoResizeColumn(index, ColumnHeaderAutoResizeStyle.HeaderSize)
            tamanoPorColumnas = ListView1.Columns.Item(index).Width
            ListView1.AutoResizeColumn(index, ColumnHeaderAutoResizeStyle.ColumnContent)

            if tamanoPorColumnas > ListView1.Columns.Item(index).Width Then
                ListView1.AutoResizeColumn(index, ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        Next
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Dim cliente As Cliente = ObtenerClienteDeListViewItem(sender)
        CambiarBotonAEditar()
        EditarCliente(cliente)
    End Sub

    Private Function ObtenerClienteDeListViewItem(sender As Object) As Cliente
        Dim listView As ListView = CType(sender, ListView)
        Dim itemElegido As ListViewItem = listView.SelectedItems.Item(0)

        Return ObtenerClientePor(itemElegido.SubItems.Item(0).Text)
    End Function

    Private Function ObtenerClienteDeEdicion() As Cliente
        Return ObtenerClientePor(editorDeId.Text)
    End Function

    Private Function ObtenerClientePor(texto As String) As Cliente
        Dim id As Integer = Integer.Parse(texto)
        Dim filtro As New FiltroDeAgenda With { .Id = id }
        Return _agenda.Filtrar(filtro).Single()
    End Function

    Private Sub CambiarBotonAEditar()
        botonAgregar.Text = "Completar"
        RemoverHandlersDelBoton()
        AddHandler botonAgregar.Click, AddressOf AlEditar
    End Sub

    Private Sub CambiarBotonAAgregar()
        botonAgregar.Text = "Agregar"
        RemoverHandlersDelBoton()
        AddHandler botonAgregar.Click, AddressOf AlAgregar
    End Sub

    Private Sub RemoverHandlersDelBoton()
        RemoveHandler botonAgregar.Click, AddressOf AlAgregar
        RemoveHandler botonAgregar.Click, AddressOf AlEditar
    End Sub

    Private Sub EditarCliente(cliente As Cliente)
        Dim visualizador As New VisualizadorEnEditorDeCliente(Me)
        cliente.MostrarmeEn(visualizador)
    End Sub

End Class