Namespace Almacenamiento

    Public Interface IAlmacenamiento(Of T As Class)

        Function Contar() As Integer
        Function Agregar(elemento As T) As T
        Function Existe(elemento As T) As Boolean
        Sub Borrar(elemento As T)
        Sub Reemplazar(elementoOriginal As T, elementoNuevo As T)
        Function Filtrar(filtro As IFiltroDeAlmacenamiento(Of T)) As List(Of T)

    End Interface

End NameSpace