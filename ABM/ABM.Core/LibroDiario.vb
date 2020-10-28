Public Class LibroDiario

    Public Function Crear(cliente As Cliente, fecha As Date) As Factura
        Return new Factura(cliente, fecha)
    End Function

End Class