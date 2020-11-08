Imports ABM.Core
Imports ABM.View.Visualizadores

Public Class AgendaView

    Private ReadOnly _agenda As Agenda
    Private _ultimoFiltro As FiltroDeAgenda

    Public Sub New(agenda As Agenda)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Text = "Agenda"
        _agenda = agenda
        CrearColumnas()
        AjustarTamanoDeColumnas()
        CambiarBotonAAgregar()
        HabilitarEdicion()
    End Sub

    Private Sub HabilitarEdicion()
        AddHandler ListView1.DoubleClick, AddressOf AlHacerDobleClickEnLaLista
    End Sub

    Private Sub DeshabilitarEdicion()
        RemoveHandler ListView1.DoubleClick, AddressOf AlHacerDobleClickEnLaLista
    End Sub

    Private Sub CrearColumnas()
        ListView1.Columns.Add("Id", "Id", 50)
        ListView1.Columns.Add("Nombre", "Nombre", 200)
        ListView1.Columns.Add("Telefono", "Telefono", 100)
        ListView1.Columns.Add("Correo", "Correo", 100)
    End Sub

    Public Sub LlenarListaCon(clientes As List(Of Cliente))
        For Each cliente As Cliente In clientes
            Dim visualizador As New VisualizadorEnListViewDeCliente(ListView1)
            cliente.MostrarmeEn(visualizador)
        Next
    End Sub

    Private Sub LimpiarLista()
        ListView1.Items.Clear()
    End Sub

    Private Sub AlAgregar(sender As Object, e As EventArgs)
        _agenda.CrearY(DatosDeCliente1.Nombre, DatosDeCliente1.Telefono, DatosDeCliente1.Correo) _
            .ConErrorEjecutar(Sub(mensajeDeError) MessageBox.Show(mensajeDeError)) _
            .ConExitoEjecutar(Sub(clienteCreado) AgendarClienteNuevoYRefrescarLista(clienteCreado))
    End Sub

    Private Sub AlEditar(sender As Object, e As EventArgs)
        ObtenerClienteDeEdicion() _
            .ConExitoEjecutar(
                Sub(cliente)
                    _agenda.CambiarNombreDeY(cliente, DatosDeCliente1.Nombre) _
                                 .ConExitoEjecutar(Sub(clienteModificado) ModificarClienteYRefrescarLista(clienteModificado)) _
                                 .ConErrorEjecutar(Sub(mensajeDeError) MessageBox.Show(mensajeDeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error))
                End Sub) _
            .ConErrorEjecutar(Sub(mensajeDeError) MessageBox.Show(mensajeDeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error))

        LimpiarTextos()
        CambiarBotonAAgregar()
        LimpiarLista()
        LlenarListaCon(FiltrarAgendaConUltimoFiltro())
        AjustarTamanoDeColumnas()
    End Sub

    Private Sub AlBuscar(sender As Object, e As EventArgs)
        _ultimoFiltro = New FiltroDeAgenda With {
                .Id = DatosDeCliente1.Id,
                .Nombre = DatosDeCliente1.Nombre
        }

        LimpiarLista()
        LlenarListaCon(FiltrarAgendaConUltimoFiltro())
        AjustarTamanoDeColumnas()
    End Sub

    Private Sub AgendarClienteNuevoYRefrescarLista(clienteCreado As Cliente)
        _agenda.Agregar(clienteCreado)

        LimpiarLista()
        LimpiarTextos()
        LlenarListaCon(FiltrarAgendaConUltimoFiltro())
        AjustarTamanoDeColumnas()
    End Sub

    Private Function FiltrarAgendaConUltimoFiltro() As List(Of Cliente)
        Return _agenda.Filtrar(_ultimoFiltro)
    End Function

    Private Sub ModificarClienteYRefrescarLista(clienteModificado As Cliente)
        clienteModificado = _agenda.CambiarTelefonoDe(clienteModificado, DatosDeCliente1.Telefono)
        _agenda.CambiarCorreoDe(clienteModificado, DatosDeCliente1.Correo)
    End Sub

    Private Sub LimpiarTextos()
        DatosDeCliente1.Limpiar()
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

    Private Sub AlHacerDobleClickEnLaLista(sender As Object, e As EventArgs) 
        Dim cliente As Cliente
        
        ObtenerClienteDeListViewItem(sender) _
            .ConExitoEjecutar(
                Sub(clienteEncontrado)
                    cliente = clienteEncontrado
                    CambiarBotonAEditar()
                    EditarCliente(cliente)
                End Sub) _
            .ConErrorEjecutar(
                Sub(mensajeDeError)
                    MessageBox.Show(mensajeDeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    LimpiarLista()
                    LlenarListaCon(FiltrarAgendaConUltimoFiltro())
                End Sub)
    End Sub

    Private Function ObtenerClienteDeListViewItem(sender As Object) As Resultado(Of Cliente)
        Dim itemElegido As ListViewItem = CType(sender, ListView).SelectedItems.Item(0)
        Return ObtenerClientePor(Integer.Parse(itemElegido.SubItems.Item(0).Text))
    End Function

    Private Function ObtenerClienteDeEdicion() As Resultado(Of Cliente)
        Return ObtenerClientePor(DatosDeCliente1.Id)
    End Function

    Private Function ObtenerClientePor(id As Integer?) As Resultado(Of Cliente)
        Dim filtro As New FiltroDeAgenda With { .Id = id }
        Dim clientes As List(Of Cliente) = _agenda.Filtrar(filtro)

        if clientes.Count = 1 Then
            Return Resultado(Of Cliente).Bien(clientes.Item(0))
        Else
            Return Resultado(Of Cliente).Mal("El cliente ya no existe")
        End If
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
        Dim visualizador As New VisualizadorEnEditorDeCliente(DatosDeCliente1)
        cliente.MostrarmeEn(visualizador)
    End Sub

    Public Sub PrepararParaBusqueda()
        DatosDeCliente1.HabilitarId()
        botonAgregar.Text = "Buscar"
        RemoverHandlersDelBoton()
        DeshabilitarEdicion()
        AddHandler botonAgregar.Click, AddressOf AlBuscar
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        if MessageBox.Show("Esta seguro?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim itemElegido As ListViewItem = ListView1.SelectedItems.Item(0)
            
            ObtenerClientePor(Integer.Parse(itemElegido.SubItems.Item(0).Text)) _
                .ConExitoEjecutar(Sub(clienteABorrar) _agenda.Borrar(clienteABorrar)) _
                .ConErrorEjecutar(sub(mensajeDeError) MessageBox.Show(mensajeDeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error))

            LimpiarLista()
            LlenarListaCon(FiltrarAgendaConUltimoFiltro())
            AjustarTamanoDeColumnas()
        End If
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        if e.Button = MouseButtons.Right Then
            if ListView1.FocusedItem.Bounds.Contains(e.Location) Then
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub

End Class