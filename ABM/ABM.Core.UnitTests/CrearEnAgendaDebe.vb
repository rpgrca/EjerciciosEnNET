Imports Xunit

Public Class CrearEnAgendaDebe

    <Fact> Public Sub DevolverClienteCreado_CuandoSeCreaCliente()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = sut.Crear(Constantes.CLIENTE_JUAN_PEREZ, Constantes.TELEFONO_DE_JUAN_PEREZ, Constantes.CORREO_DE_JUAN_PEREZ)

        Assert.NotNull(cliente)
        Assert.True(cliente.ConocidoComo(Constantes.CLIENTE_JUAN_PEREZ))
        Assert.True(cliente.LlamadoAl(Constantes.TELEFONO_DE_JUAN_PEREZ))
        Assert.True(cliente.MensajeadoAl(Constantes.CORREO_DE_JUAN_PEREZ))
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor().Construir()
    End Function

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaCrearUnClienteConNombreInvalido(nombreInvalido As String)
        Dim sut As Agenda = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(nombreInvalido))
        Assert.Contains(Cliente.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub DevolverResultado_CuandoSeCreaCliente()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim resultadoDeAgenda As Resultado(Of Cliente)
        resultadoDeAgenda = sut.CrearY(Constantes.CLIENTE_JUAN_PEREZ, Constantes.TELEFONO_DE_JUAN_PEREZ, Constantes.CORREO_DE_JUAN_PEREZ)

        Assert.NotNull(resultadoDeAgenda)
    End Sub

    <Fact> Public Sub DevolverResultado_CuandoNoSeCreaCliente()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim resultadoDeAgenda As Resultado(Of Cliente)
        resultadoDeAgenda = sut.CrearY(String.Empty)

        Assert.NotNull(resultadoDeAgenda)
    End Sub

    <Fact> Public Sub EjecutarClosureExitosa_CuandoSeCreaClienteCorrectamente()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = Nothing

        sut.CrearY(Constantes.CLIENTE_JUAN_PEREZ, Constantes.TELEFONO_DE_JUAN_PEREZ, Constantes.CORREO_DE_JUAN_PEREZ) _
            .ConExitoEjecutar(Sub(clienteCreado) cliente = clienteCreado)

        Assert.NotNull(cliente)
        Assert.True(cliente.ConocidoComo(Constantes.CLIENTE_JUAN_PEREZ))
        Assert.True(cliente.LlamadoAl(Constantes.TELEFONO_DE_JUAN_PEREZ))
        Assert.True(cliente.MensajeadoAl(Constantes.CORREO_DE_JUAN_PEREZ))
    End Sub

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    Public Sub EjecutarClosureFallida_CuandoNoSeCreaElClienteConCallback(nombreInvalido As String)
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim mensajeDeError As String = String.Empty

        sut.CrearY(nombreInvalido).ConErrorEjecutar(Sub(mensaje) mensajeDeError = mensaje)

        Assert.Equal(Cliente.NAME_IS_INVALID_EXCEPTION, mensajeDeError)
    End Sub

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    Public Sub LanzarExcepcion_CuandoNoSeCreaElClienteSinCallback(nombreInvalido As String)
        Dim sut As Agenda = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(nombreInvalido))

        Assert.Equal(Cliente.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class