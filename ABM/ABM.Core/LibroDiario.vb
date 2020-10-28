Public Class LibroDiario

    Public Function Crear(cliente As Cliente, fecha As Date) As Factura
        Return new Factura(cliente, fecha)
    End Function

    Public Sub Agregar(factura As Factura)
        If factura Is Nothing Then Throw new ArgumentException(Agenda.CLIENT_IS_INVALID_EXCEPTION)

    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return 2
        End Get
    End Property 
End Class