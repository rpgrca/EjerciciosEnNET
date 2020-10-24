Public Class Cliente

    Public Const NAME_IS_INVALID_EXCEPTION As String = "El nombre del cliente es invalido"

    Private ReadOnly Property Nombre As String
    Private ReadOnly Property Telefono As String
    Private ReadOnly Property Correo As String

    Public Sub New(nombre As String, telefono As String, correo As String)
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)

        Me.Nombre = nombre
        Me.Telefono = telefono
        Me.Correo = correo
    End Sub

    Public Function ConocidoComo(nombre As String) As Boolean
        Return Me.Nombre = nombre
    End Function

    Public Function LlamadoAl(telefono As String) As Boolean
        Return Me.Telefono = telefono
    End Function

    Public Function MensajeadoAl(correo As String) As Boolean
        Return Me.Correo = correo
    End Function

    Public Function CambiarNombre(nuevoNombre As String) As Cliente
        Return New Cliente(nuevoNombre, Telefono, Correo)
    End Function

    Public Function CambiarTelefono(nuevoTelefono As String) As Cliente
        Return New Cliente(Nombre, nuevoTelefono, Correo)
    End Function

    Public Function CambiarCorreo(nuevoCorreo As String) As Cliente
        Return New Cliente(Nombre, Telefono, nuevoCorreo)
    End Function
End Class