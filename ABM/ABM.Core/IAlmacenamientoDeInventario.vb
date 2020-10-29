Public Interface IAlmacenamientoDeLibroDiario(of T)

    Function Contar() As Integer
    Function Agregar(factura As T) As T
    Sub Borrar(factura As T)
    Function Existe(factura As T) As Boolean
    Sub Reemplazar(original As T, reemplazo As T)

End Interface