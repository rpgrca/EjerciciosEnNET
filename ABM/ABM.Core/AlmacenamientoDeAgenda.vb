Friend Class AlmacenamientoDeAgenda
    Implements IAlmacenamientoDeAgenda(of Cliente)

    Private ReadOnly _contactos As List(Of Cliente)
    Private _nextId as Integer

    Public Sub New()
        _contactos = New List(Of Cliente)
        _nextId = 1
    End Sub

    Public Function Contar() As Integer Implements IAlmacenamientoDeAgenda(Of Cliente).Contar
        Return _contactos.Count
    End Function

    Public Function Agregar(cliente As Cliente) As Cliente Implements IAlmacenamientoDeAgenda(Of Cliente).Agregar
        Dim clienteModificado = cliente.AjustarIdA(_nextId)

        _contactos.Add(clienteModificado)
        _nextId += 1

        Return clienteModificado
    End Function

    Public Function Filtrar(Optional nombre As String = "") As List(Of Cliente) Implements IAlmacenamientoDeAgenda(Of Cliente).Filtrar
        Return _contactos.Where(Function(c) c.ConocidoComo(nombre)).ToList()
    End Function

    public Function Existe(cliente As Cliente) As Boolean Implements IAlmacenamientoDeAgenda(Of Cliente).Existe
        Return _contactos.Any(Function(c) c.ConMismoIdQue(cliente))
    End Function

    Public Sub Borrar(cliente As Cliente) Implements IAlmacenamientoDeAgenda(Of Cliente).Borrar
        _contactos.RemoveAll(Function(c) c.ConMismoIdQue(cliente))
    End Sub

    Public Sub Reemplazar(original As Cliente, reemplazo As Cliente) Implements IAlmacenamientoDeAgenda(Of Cliente).Reemplazar
        _contactos.Remove(original)
        _contactos.Add(reemplazo)
    End Sub

End Class