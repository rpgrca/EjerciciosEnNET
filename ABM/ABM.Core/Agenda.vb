Public Class Agenda

    Public Const CLIENT_IS_INVALID_EXCEPTION As String = "No se puede borrar un cliente invalido"

    Private ReadOnly _contactos As List(Of Cliente)
    Private _nextId As Integer = 0

    Public Sub New()
        _contactos = New List(Of Cliente)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _contactos.Count
        End Get
    End Property

    Public Function Agregar(nombre As String, Optional telefono As String = "", Optional correo As String = "") As Cliente
        Dim cliente As Cliente = Cliente.CreadoComo(_nextId, nombre, telefono, correo)

        _contactos.Add(cliente)
        _nextId += 1

        Return cliente
    End Function

    Public Function Buscar(nombre As String) As List(Of Cliente)
        Return _contactos.Where(Function(c) c.ConocidoComo(nombre)).ToList()
    End Function

    Public Sub Borrar(cliente As Cliente)
        If cliente Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        If Not _contactos.Any(Function(c) c.ConMismoIdQue(cliente)) Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)

        _contactos.RemoveAll(Function(c) c.ConMismoIdQue(cliente))
    End Sub

    Public Function CambiarNombreDe(cliente As Cliente, nuevoNombre As String) As Cliente
        Return CambiarAlgoDe(cliente, Function() cliente.CambiarNombre(nuevoNombre, Me))
    End Function

    Public Function CambiarCorreoDe(cliente As Cliente, nuevoCorreo As String) As Cliente
        Return CambiarAlgoDe(cliente, Function() cliente.CambiarCorreo(nuevoCorreo, Me))
    End Function

    Public Function CambiarTelefonoDe(cliente As Cliente, nuevoTelefono As String) As Cliente
        Return CambiarAlgoDe(cliente, Function() cliente.CambiarTelefono(nuevoTelefono, Me))
    End Function

    Private Function CambiarAlgoDe(clienteOriginal As Cliente, cambiarCliente As Func(Of Cliente)) As Cliente
        Dim clienteModificado = cambiarCliente()

        _contactos.Remove(clienteOriginal)
        _contactos.Add(clienteModificado)

        Return clienteModificado
    End Function
End Class