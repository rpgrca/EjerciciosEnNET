Imports System.Data.SqlClient

Namespace Almacenamiento

    Public Class AgendaPermanente
        Implements IAlmacenamiento(Of Cliente)

        Private ReadOnly _connection As SqlConnection

        Public Sub New(connection As SqlConnection)
            _connection = connection
        End Sub

        Public Sub Borrar(elemento As Cliente) Implements IAlmacenamiento(Of Cliente).Borrar
        End Sub

        Public Sub Reemplazar(elementoOriginal As Cliente, elementoNuevo As Cliente) Implements IAlmacenamiento(Of Cliente).Reemplazar
            Throw New NotImplementedException()
        End Sub

        Public Function Contar() As Integer Implements IAlmacenamiento(Of Cliente).Contar
            Throw New NotImplementedException()
        End Function

        Public Function Agregar(elemento As Cliente) As Cliente Implements IAlmacenamiento(Of Cliente).Agregar
            Dim query As String = "INSERT INTO dbo.clientes(Cliente, Telefono, Correo)
                                        VALUES (@Nombre, @Telefono, @Correo)"

            Dim comando As SqlCommand
            comando = _connection.CreateCommand()
            comando.CommandText = query
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 255)
            comando.Parameters("@Nombre").Value = elemento.Nombre
            comando.Parameters.Add("@Telefono", sqlDbType.VarChar, 255)
            comando.Parameters("@Telefono").Value = elemento.Telefono
            comando.Parameters.Add("@Correo", sqlDbType.VarChar, 255)
            comando.Parameters("@Correo").Value = elemento.Correo

            Dim resultadoDe As Integer = comando.ExecuteNonQuery()
            if resultadoDe <> 1 Then Throw new Exception("No se pudo agregar un nuevo cliente dentro de la base de datos")

            Dim recordset As SqlDataReader = comando.ExecuteReader()
        End Function

        Public Function Existe(elemento As Cliente) As Boolean Implements IAlmacenamiento(Of Cliente).Existe
            Throw New NotImplementedException()
        End Function

        Public Function Filtrar(filtro As IFiltroDeAlmacenamiento(Of Cliente)) As List(Of Cliente) Implements IAlmacenamiento(Of Cliente).Filtrar
            Throw New NotImplementedException()
        End Function
    End Class

End NameSpace