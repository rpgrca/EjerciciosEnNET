Public Interface IAlmacenamientoDeLibroDiario(of T)

    Function Contar() As Integer
    Function Agregar(factura As T) As T
    Function Existe(factura As T) As Boolean
    Sub Borrar(factura As T)
    Sub Reemplazar(original As T, reemplazo As T)

End Interface