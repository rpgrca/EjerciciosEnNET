Public Class Cliente
    Public Const NAME_IS_INVALID_EXCEPTION As String = "El nombre del cliente es invalido"

    Public Sub New(nombre As String)
        If nombre = String.Empty Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)

        Me.Nombre = nombre
    End Sub

    Public ReadOnly Property Nombre As String
End Class