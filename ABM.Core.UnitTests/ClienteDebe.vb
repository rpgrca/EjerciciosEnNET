Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ClienteDebe

    <Fact> Public Sub DevolverUnNuevoClienteRenombrado_CuandoSeCambiaElNombre()
        Dim agenda As New Agenda()
        Dim cliente As Cliente
        Dim sut As Cliente

        cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO, CORREO)
        sut = cliente.CambiarNombre(CLIENTE_EDUARDO_PEREZ)

        Assert.True(sut.ConocidoComo(CLIENTE_EDUARDO_PEREZ))
    End Sub

End Class
