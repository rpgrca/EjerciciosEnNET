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

End Class
