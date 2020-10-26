Friend Class AlmacenamientoDeAgenda
    Implements IAlmacenamientoDeAgenda(of Cliente)

    Private ReadOnly _contactos As List(Of Cliente)

    Public Sub New()
        _contactos = New List(Of Cliente)
    End Sub

    Public Function Contar() As Integer Implements IAlmacenamientoDeAgenda(Of Cliente).Contar
        Return _contactos.Count
    End Function

    Public Sub Agregar(clienteNuevo As Cliente) Implements IAlmacenamientoDeAgenda(Of Cliente).Agregar
        _contactos.Add(clienteNuevo)
    End Sub

    Public Function Buscar(nombre As String) As List(Of Cliente) Implements IAlmacenamientoDeAgenda(Of Cliente).Buscar
        Return _contactos.Where(Function(c) c.ConocidoComo(nombre)).ToList()
    End Function

    public Function Existe(cliente As Cliente) As Boolean Implements IAlmacenamientoDeAgenda(Of Cliente).Existe
        Return _contactos.Any(Function(c) c.ConMismoIdQue(cliente))
    End Function

    Public Sub Borrar(cliente As Cliente) Implements IAlmacenamientoDeAgenda(Of Cliente).Borrar
        _contactos.RemoveAll(Function(c) c.ConMismoIdQue(cliente))
    End Sub

End Class