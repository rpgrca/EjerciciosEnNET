Public Class Agenda

    Private ReadOnly _contactos As List(Of Object)

    Public Sub New()
        _contactos = New List(Of Object)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _contactos.Count
        End Get
    End Property

    Public Sub Agregar(nombre As String)
        _contactos.Add(nombre)
    End Sub

End Class