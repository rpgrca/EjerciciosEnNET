Public Class Cliente
    Implements IEquatable(Of Cliente)

    Public Const NAME_IS_INVALID_EXCEPTION As String = "El nombre del cliente es invalido"

    Private ReadOnly Property Id As Integer
    Private ReadOnly Property Nombre As String
    Private ReadOnly Property Telefono As String
    Private ReadOnly Property Correo As String

    Friend Shared Function CreadoComo(id As Integer, nombre As String, telefono As String, correo As String)
        Return New Cliente(id, nombre, telefono, correo)
    End Function

    Private Sub New(id As Integer, nombre As String, telefono As String, correo As String)
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)

        Me.Id = id
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

    Friend Function CambiarNombre(nuevoNombre As String, agenda As Agenda) As Cliente
        Return New Cliente(Id, nuevoNombre, Telefono, Correo)
    End Function

    Friend Function CambiarTelefono(nuevoTelefono As String, agenda As Agenda) As Cliente
        Return New Cliente(Id, Nombre, nuevoTelefono, Correo)
    End Function

    Friend Function CambiarCorreo(nuevoCorreo As String, agenda As Agenda) As Cliente
        Return New Cliente(Id, Nombre, Telefono, nuevoCorreo)
    End Function
    
    Friend Function AjustarIdA(id As Integer) As Cliente
        Return new Cliente(id, Nombre, Telefono, Correo)
    End Function

    Friend Function ConMismoIdQue(otroCliente As Cliente) As Boolean
        Return Id = otroCliente.Id
    End Function

    Public Overloads Function Equals(otroCliente As Cliente) As Boolean Implements IEquatable(Of Cliente).Equals
        If otroCliente Is Nothing Then Return False
        Return ConMismoIdQue(otroCliente)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot Cliente Then Return False

        Dim otroCliente = CType(obj, Cliente)

        Return Equals(otroCliente)
    End Function

    Friend Sub BorrarseDe(almacenamiento As IAlmacenamientoDeAgenda(Of Cliente))
        If Not almacenamiento.Existe(Me) Then Throw New ArgumentException(Agenda.CLIENT_IS_INVALID_EXCEPTION)
        almacenamiento.Borrar(Me)
    End Sub

    Friend Function AgregarseA(almacenamiento As IAlmacenamientoDeAgenda(Of Cliente)) As Cliente
        Return almacenamiento.Agregar(Me)
    End Function

    Friend Function ConfirmarCreacionCon(almacenamiento As IAlmacenamientoDeAgenda(Of Cliente)) As Cliente
        Return Me
    End Function

End Class