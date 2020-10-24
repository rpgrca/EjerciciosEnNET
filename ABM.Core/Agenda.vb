Public Class Agenda

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
        Return _contactos.SingleOrDefault(Function(o) o.ConocidoComo(nombre))
    End Function

End Class