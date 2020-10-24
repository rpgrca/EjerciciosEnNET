Public Class Agenda

    Public Const NAME_IS_INVALID_EXCEPTION As String = "El nombre del cliente es invalido"

    Private ReadOnly _contactos As List(Of Object)

    Public Sub New()
        _contactos = New List(Of Object)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _contactos.Count
        End Get
    End Property

    Public Sub Agregar(nombre As String)
        If nombre = String.Empty Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)

        _contactos.Add(nombre)
    End Sub

    Public Function Buscar(nombre As String) As Cliente
        If _contactos.Count > 0 Then
            Return New Cliente(nombre)
        End If

        Return Nothing
    End Function
End Class