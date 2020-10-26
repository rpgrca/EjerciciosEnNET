Public interface IAlmacenamientoDeAgenda(Of T)
    Function Contar() As Integer
    Sub Agregar(clienteNuevo As T)
    Function Buscar(nombre As String) As List(Of T)
    Function Existe(cliente As T) As Boolean
    Sub Borrar(cliente As T)
end interface