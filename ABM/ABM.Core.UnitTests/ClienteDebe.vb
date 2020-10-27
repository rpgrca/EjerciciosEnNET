Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ClienteDebe

    <Fact> Public Sub DevolverUnNuevoClienteRenombrado_CuandoSeCambiaElNombre()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim sut = agenda.CambiarNombreDe(cliente, CLIENTE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverUnNuevoClienteConNuevoTelefono_CuandoSeCambiaElTelefono()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim sut = agenda.CambiarTelefonoDe(cliente, TELEFONO_DE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_JUAN_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_EDUARDO_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverUnNuevoClienteConNuevoCorreo_CuandoSeCambiaElCorreo()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim sut = agenda.CambiarCorreoDe(cliente, CORREO_DE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_JUAN_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_EDUARDO_PEREZ))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosClientesPoseenDistintoId()
        Dim agenda = CreateSystemUnderTest()
        Dim clienteJuan = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo = agenda.Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.False(clienteJuan.Equals(clienteEduardo))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosClientesPoseenDistintoIdYSeComparaComoObject()
        Dim agenda = CreateSystemUnderTest()
        Dim clienteJuan = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo = agenda.Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.False(clienteJuan.Equals(CType(clienteEduardo, Object)))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosClientesPoseenMismoId()
        Dim clienteJuan = CreateSystemUnderTest().Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo = CreateSystemUnderTest().Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.True(clienteJuan.Equals(clienteEduardo))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosClientesPoseenMismoIdYSeComparaComoObject()
        Dim clienteJuan = CreateSystemUnderTest().Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteEduardo = CreateSystemUnderTest().Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.True(clienteJuan.Equals(CType(clienteEduardo, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingConCliente()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(Nothing))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingCasteadoAObjetConCliente()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(CType(Nothing, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaClienteConOtroObjetoCasteadoACliente()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(New Object()))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaClienteConOtroObjetoCasteadoAObject()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(agenda))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoSeComparaClienteConClienteRenombrado()
        Dim agenda = CreateSystemUnderTest()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim clienteRenombrado = agenda.CambiarNombreDe(cliente, CLIENTE_EDUARDO_PEREZ)

        Assert.True(cliente.Equals(clienteRenombrado))
    End Sub
End Class
