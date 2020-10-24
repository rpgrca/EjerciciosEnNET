Public Class Cliente
    Public Const NAME_IS_INVALID_EXCEPTION As String = "El nombre del cliente es invalido"

    Public Sub New(nombre As String, telefono As String, correo As String)
        If nombre = String.Empty Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)

        Me.Nombre = nombre
        Me.Telefono = telefono
        Me.Correo = correo
    End Sub

    Public ReadOnly Property Nombre As String
    Public ReadOnly Property Telefono As String
    Public ReadOnly Property Correo As String
End Class