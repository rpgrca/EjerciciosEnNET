Public Class DatosDeCliente

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        editorDeId.Enabled = False
    End Sub

    Public ReadOnly Property Nombre As String
        Get
            Return editorDeNombre.Text
        End Get
    End Property

    Public ReadOnly Property Telefono As String
        Get
            Return editorDeTelefono.Text
        End Get
    End Property

    Public ReadOnly Property Correo As String
        Get
            Return editorDeCorreo.Text
        End Get
    End Property

    Public ReadOnly Property Id As Integer?
        Get
            Dim result As Integer

            If Integer.TryParse(editorDeId.Text, result) Then
                Return result
            Else 
                Return Nothing
            End If
        End Get
    End Property

    Public Sub Limpiar()
        editorDeId.Text = String.Empty
        editorDeNombre.Text = String.Empty
        editorDeTelefono.Text = String.Empty
        editorDeCorreo.Text = String.Empty
    End Sub

    Public Sub Inicializar(id As Integer, nombre As String, telefono As String, correo As String)
        editorDeId.Text = id.ToString()
        editorDeNombre.Text = nombre
        editorDeTelefono.Text = telefono
        editorDeCorreo.Text = correo
    End Sub

    Public Sub HabilitarId()
        editorDeId.Enabled = True
    End Sub
End Class
