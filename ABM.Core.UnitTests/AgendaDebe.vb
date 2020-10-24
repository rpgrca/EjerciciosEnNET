Imports Xunit

Public Class AgendaDebe
    Private Const CLIENTE_JUAN_PEREZ As String = "Juan Perez"
    Private Const CLIENTE_EDUARDO_PEREZ As String = "Eduardo Perez"

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeContactosDeUnaAgendaVacia()
        Dim sut As Agenda

        sut = New Agenda()
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeContactosDeUnaAgendaConUnContacto()
        Dim sut As Agenda

        sut = New Agenda()
        sut.Agregar(CLIENTE_JUAN_PEREZ)

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeContactosConVariosContactos()
        Dim sut As Agenda

        sut = New Agenda()
        sut.Agregar(CLIENTE_JUAN_PEREZ)
        sut.Agregar(CLIENTE_EDUARDO_PEREZ)

        Assert.Equal(2, sut.Total)
    End Sub

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnClienteConNombreInvalido(nombreInvalido As String)
        Dim sut As Agenda
        Dim exception As Exception

        sut = New Agenda()

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(nombreInvalido))
        Assert.Contains(Agenda.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(CLIENTE_JUAN_PEREZ)>
    Public Sub DevolverNothing_CuandoSeBuscaNombreEnAgendaVacia(cualquierNombre As String)
        Dim sut As Agenda
        Dim cliente As Object

        sut = New Agenda()

        cliente = sut.Buscar(cualquierNombre)
        Assert.Null(cliente)
    End Sub

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeBuscaClienteExistente()
        Dim sut As Agenda
        Dim cliente As Cliente

        sut = New Agenda()

        sut.Agregar(CLIENTE_JUAN_PEREZ)
        cliente = sut.Buscar(CLIENTE_JUAN_PEREZ)
        Assert.NotNull(cliente)
        Assert.Equal(CLIENTE_JUAN_PEREZ, cliente.Nombre)
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeBuscaClienteInexistenteEnAgendaConContactos()
        Dim sut As Agenda
        Dim cliente As Cliente

        sut = New Agenda()

        sut.Agregar(CLIENTE_JUAN_PEREZ)
        cliente = sut.Buscar(CLIENTE_EDUARDO_PEREZ)
        Assert.Null(cliente)
    End Sub
End Class