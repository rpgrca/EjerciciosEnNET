Public Class Agenda

    Public Const CLIENT_IS_INVALID_EXCEPTION As String = "No se puede borrar un cliente invalido"

    Private ReadOnly _contactos As List(Of Cliente)

    Public Sub New()
        _contactos = New List(Of Cliente)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _contactos.Count
        End Get
    End Property

    Public Function Agregar(nombre As String, Optional telefono As String = "", Optional correo As String = "") As Cliente
        Dim cliente As New Cliente(nombre, telefono, correo)

        _contactos.Add(cliente)

        Return cliente
    End Function

    Public Function Buscar(nombre As String) As Cliente
        Return _contactos.SingleOrDefault(Function(c) c.ConocidoComo(nombre))
    End Function

    Public Sub Borrar(cliente As Cliente)
        If cliente Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        If Not _contactos.Any(Function(c) c.Equals(cliente)) Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)

        _contactos.Remove(cliente)
    End Sub
End Class