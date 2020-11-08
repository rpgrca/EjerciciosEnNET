Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ClienteDebe

    <Fact> Public Sub DevolverUnNuevoClienteRenombrado_CuandoSeCambiaElNombreConCallback()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim resultadoDeModificacion As Resultado(Of Cliente) = agenda.CambiarNombreDeY(cliente, CLIENTE_EDUARDO_PEREZ)
        Dim sut As Cliente = Nothing

        resultadoDeModificacion.ConExitoEjecutar(Sub(clienteModificado) sut = clienteModificado)

        Assert.True(sut.ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverUnNuevoClienteRenombrado_CuandoSeCambiaElNombreSinCallback()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim sut As Cliente = agenda.CambiarNombreDe(cliente, CLIENTE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Theory>
    <InlineData("")>
    <InlineData(" ")>
    <InlineData(Nothing)>
    Public Sub LanzarUnaExcepcion_CuandoSeCambiaElNombreAUnNombreInvalidoSinCallback(nombreInvalido As String)
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() agenda.CambiarNombreDe(sut, nombreInvalido))
        Assert.Equal(Cliente.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub DevolverUnNuevoClienteConNuevoTelefono_CuandoSeCambiaElTelefono()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim sut As Cliente = agenda.CambiarTelefonoDe(cliente, TELEFONO_DE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_JUAN_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_EDUARDO_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverUnNuevoClienteConNuevoCorreo_CuandoSeCambiaElCorreo()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim sut As Cliente = agenda.CambiarCorreoDe(cliente, CORREO_DE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_JUAN_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_EDUARDO_PEREZ))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosClientesPoseenDistintoId()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo As Cliente = agenda.Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.False(sut.Equals(clienteEduardo))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosClientesPoseenDistintoIdYSeComparaComoObject()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo As Cliente = agenda.Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.False(sut.Equals(CType(clienteEduardo, Object)))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosClientesPoseenMismoId()
        Dim sut As Cliente = CreateSystemUnderTest().Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo As Cliente = CreateSystemUnderTest().Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.True(sut.Equals(clienteEduardo))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosClientesPoseenMismoIdYSeComparaComoObject()
        Dim sut As Cliente = CreateSystemUnderTest().Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo As Cliente = CreateSystemUnderTest().Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.True(sut.Equals(CType(clienteEduardo, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingConCliente()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(Nothing))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingCasteadoAObjetConCliente()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(CType(Nothing, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaClienteConOtroObjetoCasteadoACliente()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(New Object()))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaClienteConOtroObjetoCasteadoAObject()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(agenda))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoSeComparaClienteConClienteRenombradoConCallback()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim resultadoDeModificacion As Resultado(Of Cliente) = agenda.CambiarNombreDeY(sut, CLIENTE_EDUARDO_PEREZ)
        Dim clienteRenombrado As Cliente = Nothing
        resultadoDeModificacion.ConExitoEjecutar(Sub(clienteModificado) clienteRenombrado = clienteModificado)
        
        Assert.True(sut.Equals(clienteRenombrado))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoSeComparaClienteConClienteRenombradoSinCallback()
        Dim agenda As Agenda = CreateSystemUnderTest()
        Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteRenombrado As Cliente = agenda.CambiarNombreDe(sut, CLIENTE_EDUARDO_PEREZ)
        
        Assert.True(sut.Equals(clienteRenombrado))
    End Sub

End Class
