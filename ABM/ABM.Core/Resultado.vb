Public Class Resultado(Of T)

    Private ReadOnly _error As Boolean
    Private ReadOnly _mensajeDeError As String
    Private ReadOnly _resultadoCorrecto As T

    Private Sub New(mensajeDeError As String)
        _error = True
        _mensajeDeError = mensajeDeError
    End Sub

    Private Sub New(resultadoCorrecto As T)
        _error = False
        _resultadoCorrecto = resultadoCorrecto
    End Sub
    
    Public Function ConExitoEjecutar(accion As Action(Of T)) As Resultado(Of T)
        If Not _error Then accion.Invoke(_resultadoCorrecto)
        Return Me
    End Function

    Public Function ConErrorEjecutar(accion As Action(Of String)) As Resultado(Of T)
        if _error Then accion.Invoke(_mensajeDeError)
        Return Me
    End Function

    Public Shared Function Mal(descripcion As String) As Resultado(Of T)
        Return new Resultado(Of T)(descripcion)
    End Function

    Public Shared Function Bien(resultadoCorrecto As T) As Resultado(Of T)
        Return new Resultado(Of T)(resultadoCorrecto)
    End Function

End Class