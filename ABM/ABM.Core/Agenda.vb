Imports ABM.Core.Almacenamiento

Public Class Agenda

    Public Class Nuevo
        Private _almacenamiento as IAlmacenamiento(Of Cliente)

        public Shared ReadOnly Property Constructor As Nuevo
            get
                Return New Nuevo()
            End Get
        End Property

        Private Sub New()
            _almacenamiento = Nothing
        End Sub

        'public Function AlmacenandoEn(almacenamiento As IAlmacenamientoDeAgenda(Of Cliente)) As Nuevo
        '    _almacenamiento = almacenamiento
        '    Return Me
        'End Function

        public Function Construir() As Agenda
            If _almacenamiento Is Nothing Then _almacenamiento = New AgendaTemporal()

            Return New Agenda(_almacenamiento)
        End Function
    End Class

    Public Const CLIENT_IS_INVALID_EXCEPTION As String = "El cliente no puede estar vacio"
    Private _nextId as Integer

    Private ReadOnly _contactos As IAlmacenamiento(Of Cliente)

    Private Sub New(contactos As IAlmacenamiento(Of Cliente))
        _contactos = contactos
        _nextId = 0
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _contactos.Contar()
        End Get
    End Property

    Public Function Crear(nombre As String, Optional telefono As String = "", Optional correo As String = "") As Cliente
        _nextId -= 1
        Return Cliente.CreadoComo(_nextId, nombre, telefono, correo)
    End Function

    public Function Agregar(clienteNuevo As Cliente) As Cliente
        if clienteNuevo Is Nothing Then Throw new ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        Return clienteNuevo.AgregarseA(_contactos)
    End Function

    Public Function Filtrar(filtro As IFiltroDeAlmacenamiento(Of Cliente)) As List(Of Cliente)
        Return _contactos.Filtrar(filtro)
    End Function

    Public Sub Borrar(cliente As Cliente)
        If cliente Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        cliente.BorrarseDe(_contactos)
    End Sub

    Public Function CambiarNombreDe(cliente As Cliente, nuevoNombre As String) As Cliente
        Return CambiarAlgoDe(cliente, Function() cliente.CambiarNombre(nuevoNombre))
    End Function

    Public Function CambiarCorreoDe(cliente As Cliente, nuevoCorreo As String) As Cliente
        Return CambiarAlgoDe(cliente, Function() cliente.CambiarCorreo(nuevoCorreo))
    End Function

    Public Function CambiarTelefonoDe(cliente As Cliente, nuevoTelefono As String) As Cliente
        Return CambiarAlgoDe(cliente, Function() cliente.CambiarTelefono(nuevoTelefono))
    End Function

    Private Function CambiarAlgoDe(clienteOriginal As Cliente, cambiarCliente As Func(Of Cliente)) As Cliente
        Dim clienteModificado = cambiarCliente()

        _contactos.Reemplazar(clienteOriginal, clienteModificado)

        Return clienteModificado
    End Function

End Class