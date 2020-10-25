Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ClienteDebe

    <Fact> Public Sub DevolverUnNuevoClienteRenombrado_CuandoSeCambiaElNombre()
        Dim agenda As New Agenda()
        Dim cliente As Cliente
        Dim sut As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut = cliente.CambiarNombre(CLIENTE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverUnNuevoClienteConNuevoTelefono_CuandoSeCambiaElTelefono()
        Dim agenda As New Agenda()
        Dim cliente As Cliente
        Dim sut As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut = cliente.CambiarTelefono(TELEFONO_DE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_JUAN_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_EDUARDO_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverUnNuevoClienteConNuevoCorreo_CuandoSeCambiaElCorreo()
        Dim agenda As New Agenda()
        Dim cliente As Cliente
        Dim sut As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut = cliente.CambiarCorreo(CORREO_DE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_JUAN_PEREZ))
        Assert.True(sut.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(sut.MensajeadoAl(CORREO_DE_EDUARDO_PEREZ))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosClientesPoseenDistintoId()
        Dim agenda As New Agenda()
        Dim clienteJuan As Cliente
        Dim clienteEduardo As Cliente

        clienteJuan = agenda.Agregar(CLIENTE_JUAN_PEREZ)
        clienteEduardo = agenda.Agregar(CLIENTE_EDUARDO_PEREZ)

        Assert.False(clienteJuan.Equals(clienteEduardo))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosClientesPoseenDistintoIdYSeComparaComoObject()
        Dim agenda As New Agenda()
        Dim clienteJuan As Cliente
        Dim clienteEduardo As Cliente

        clienteJuan = agenda.Agregar(CLIENTE_JUAN_PEREZ)
        clienteEduardo = agenda.Agregar(CLIENTE_EDUARDO_PEREZ)

        Assert.False(clienteJuan.Equals(CType(clienteEduardo, Object)))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosClientesPoseenMismoId()
        Dim clienteJuan As Cliente
        Dim clienteEduardo As Cliente

        clienteJuan = New Agenda().Agregar(CLIENTE_JUAN_PEREZ)
        clienteEduardo = New Agenda().Agregar(CLIENTE_EDUARDO_PEREZ)

        Assert.True(clienteJuan.Equals(clienteEduardo))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosClientesPoseenMismoIdYSeComparaComoObject()
        Dim clienteJuan As Cliente
        Dim clienteEduardo As Cliente

        clienteJuan = New Agenda().Agregar(CLIENTE_JUAN_PEREZ)
        clienteEduardo = New Agenda().Agregar(CLIENTE_EDUARDO_PEREZ)

        Assert.True(clienteJuan.Equals(CType(clienteEduardo, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingConCliente()
        Dim agenda = New Agenda()
        Dim cliente As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(Nothing))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingCasteadoAObjetConCliente()
        Dim agenda = New Agenda()
        Dim cliente As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(CType(Nothing, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaClienteConOtroObjetoCasteadoACliente()
        Dim agenda = New Agenda()
        Dim cliente As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(New Object()))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaClienteConOtroObjetoCasteadoAObject()
        Dim agenda = New Agenda()
        Dim cliente As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)

        Assert.False(cliente.Equals(agenda))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoSeComparaClienteConClienteRenombrado()
        Dim agenda = New Agenda()
        Dim cliente As Cliente
        Dim clienteRenombrado As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)
        clienteRenombrado = cliente.CambiarNombre(CLIENTE_EDUARDO_PEREZ)

        Assert.True(cliente.Equals(clienteRenombrado))
    End Sub
End Class
