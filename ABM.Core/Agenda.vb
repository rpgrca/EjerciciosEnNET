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

    Public Sub Agregar(nombre As String)
        Dim cliente As New Cliente(nombre)

        _contactos.Add(cliente)
    End Sub

    Public Function Buscar(nombre As String) As Cliente
        Return _contactos.SingleOrDefault(Function(o) o.Nombre = nombre)
    End Function
End Class