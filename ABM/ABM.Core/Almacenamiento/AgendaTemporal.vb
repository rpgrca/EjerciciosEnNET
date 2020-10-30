Namespace Almacenamiento

    Public Class AgendaTemporal
        Implements IAlmacenamiento(Of Cliente)

        Private ReadOnly _contactos As List(Of Cliente)
        Private _nextId as Integer

        Public Sub New
            _contactos = New List(Of Cliente)
            _nextId = 1
        End Sub

        Public Sub Borrar(elemento As Cliente) Implements IAlmacenamiento(Of Cliente).Borrar
            _contactos.RemoveAll(Function(c) c.ConMismoIdQue(elemento))
        End Sub

        Public Sub Reemplazar(elementoOriginal As Cliente, elementoNuevo As Cliente) Implements IAlmacenamiento(Of Cliente).Reemplazar
            _contactos.Remove(elementoOriginal)
            _contactos.Add(elementoNuevo)
        End Sub

        Public Function Contar() As Integer Implements IAlmacenamiento(Of Cliente).Contar
            Return _contactos.Count
        End Function

        Public Function Agregar(elemento As Cliente) As Cliente Implements IAlmacenamiento(Of Cliente).Agregar
            Dim clienteModificado = elemento.AjustarIdA(_nextId)

            _contactos.Add(clienteModificado)
            _nextId += 1

            Return clienteModificado
        End Function

        Public Function Existe(elemento As Cliente) As Boolean Implements IAlmacenamiento(Of Cliente).Existe
            Return _contactos.Any(Function(c) c.ConMismoIdQue(elemento))
        End Function

        Public Function Filtrar(filtro As IFiltroDeAlmacenamiento(Of Cliente)) As List(Of Cliente) Implements IAlmacenamiento(Of Cliente).Filtrar
            Dim filtroDeAgenda As FiltroDeAgenda = filtro

            Return _contactos.Where(Function(c) c.ConocidoComo(filtroDeAgenda.Nombre)).ToList()
        End Function
    End Class

End NameSpace