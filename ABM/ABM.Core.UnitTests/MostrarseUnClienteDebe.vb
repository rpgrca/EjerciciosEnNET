Imports Xunit
Imports ABM.Core.UnitTests.Constantes
Imports ABM.Core.Visualizadores

Public Class MostrarseUnClienteDebe

    Private Class VisualizadorFalsoDeCliente
        Implements IVisualizadorDeCliente

        Public Property Id As Integer
        Public Property Nombre As String
        Public Property Telefono As String
        Public Property Correo As String

        Public Sub Generar(id As Integer, nombre As String, telefono As String, correo As String) Implements IVisualizadorDeCliente.Generar
            Me.Id = id
            Me.Nombre = nombre
            Me.Telefono = telefono
            Me.Correo = correo
        End Sub

    End Class


    <Fact>
    Public Sub LanzarExcepcion_CuandoSeIntentaVisualizarSinVisualizador()
        Dim agenda As Agenda = CreateSubjectUnderTest()
        Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), sub() sut.MostrarmeEn(Nothing))
        Assert.Equal(Cliente.VIEWER_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    public Sub EnviarDatosAlVisualizador_CuandoSeMuestraUnCliente()
        Dim agenda As Agenda = CreateSubjectUnderTest()
        Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)

        Dim visualizadorFalso As New VisualizadorFalsoDeCliente
        sut.MostrarmeEn(visualizadorFalso)

        Assert.Equal(-1, visualizadorFalso.Id)
        Assert.Equal(CLIENTE_JUAN_PEREZ, visualizadorFalso.Nombre)
        Assert.Equal(TELEFONO_DE_JUAN_PEREZ, visualizadorFalso.Telefono)
        Assert.Equal(CORREO_DE_JUAN_PEREZ, visualizadorFalso.Correo)
    End Sub

    '<Fact>
    'Public Sub MostrarIdYNombre_SiClienteSoloPoseeEsosDatos()
    '    Dim agenda As Agenda = CreateSubjectUnderTest()
    '    Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

    '    Dim texto As String = sut.MostrarmeEn()
    '    Assert.Contains("-1", texto)
    '    Assert.Contains(CLIENTE_JUAN_PEREZ, texto)
    '    Assert.DoesNotContain("Tel", texto)
    '    Assert.DoesNotContain("()", texto)
    'End Sub

    Private Function CreateSubjectUnderTest() As Agenda
        Return Core.Agenda.Nuevo.Constructor.Construir()
    End Function

    '<Fact>
    'Public Sub MostrarIdNombreYTelefono_SiClienteSoloPoseeEsosDatos()
    '    Dim agenda As Agenda = CreateSubjectUnderTest()
    '    Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ)

    '    Dim texto As String = sut.MostrarmeEn()
    '    Assert.Contains("-1", texto)
    '    Assert.Contains(CLIENTE_JUAN_PEREZ, texto)
    '    Assert.Contains(TELEFONO_DE_JUAN_PEREZ, texto)
    '    Assert.DoesNotContain("()", texto)
    'End Sub

    '<Fact>
    'Public Sub MostrarIdNombreTelefonoYCorreo_SiClientePoseeEsosDatos()
    '    Dim agenda As Agenda = CreateSubjectUnderTest()
    '    Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)

    '    Dim texto As String = sut.MostrarmeEn()
    '    Assert.Contains("-1", texto)
    '    Assert.Contains(CLIENTE_JUAN_PEREZ, texto)
    '    Assert.Contains(TELEFONO_DE_JUAN_PEREZ, texto)
    '    Assert.Contains(CORREO_DE_JUAN_PEREZ, texto)
    'End Sub

    '<Fact>
    'Public Sub MostrarIdNombreYCorreo_SiClienteSoloPoseeEsosDatos()
    '    Dim agenda As Agenda = CreateSubjectUnderTest()
    '    Dim sut As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, , CORREO_DE_JUAN_PEREZ)

    '    Dim texto As String = sut.MostrarmeEn()
    '    Assert.Contains("-1", texto)
    '    Assert.Contains(CLIENTE_JUAN_PEREZ, texto)
    '    Assert.Contains(CORREO_DE_JUAN_PEREZ, texto)
    '    Assert.DoesNotContain("Tel", texto)
    'End Sub

End Class
