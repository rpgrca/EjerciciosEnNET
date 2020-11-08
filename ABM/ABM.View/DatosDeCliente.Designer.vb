<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatosDeCliente
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.editorDeTelefono = New System.Windows.Forms.TextBox()
        Me.editorDeCorreo = New System.Windows.Forms.TextBox()
        Me.editorDeId = New System.Windows.Forms.TextBox()
        Me.editorDeNombre = New System.Windows.Forms.TextBox()
        Me.etiquetaDeCorreo = New System.Windows.Forms.Label()
        Me.etiquetaDeTelefono = New System.Windows.Forms.Label()
        Me.etiquetaDeNombre = New System.Windows.Forms.Label()
        Me.etiquetaDeId = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'editorDeTelefono
        '
        Me.editorDeTelefono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeTelefono.Location = New System.Drawing.Point(64, 65)
        Me.editorDeTelefono.Name = "editorDeTelefono"
        Me.editorDeTelefono.Size = New System.Drawing.Size(529, 20)
        Me.editorDeTelefono.TabIndex = 15
        '
        'editorDeCorreo
        '
        Me.editorDeCorreo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeCorreo.Location = New System.Drawing.Point(64, 91)
        Me.editorDeCorreo.Name = "editorDeCorreo"
        Me.editorDeCorreo.Size = New System.Drawing.Size(408, 20)
        Me.editorDeCorreo.TabIndex = 16
        '
        'editorDeId
        '
        Me.editorDeId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeId.Enabled = false
        Me.editorDeId.Location = New System.Drawing.Point(64, 9)
        Me.editorDeId.Name = "editorDeId"
        Me.editorDeId.Size = New System.Drawing.Size(529, 20)
        Me.editorDeId.TabIndex = 13
        '
        'editorDeNombre
        '
        Me.editorDeNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeNombre.Location = New System.Drawing.Point(64, 37)
        Me.editorDeNombre.Name = "editorDeNombre"
        Me.editorDeNombre.Size = New System.Drawing.Size(529, 20)
        Me.editorDeNombre.TabIndex = 14
        '
        'etiquetaDeCorreo
        '
        Me.etiquetaDeCorreo.AutoSize = true
        Me.etiquetaDeCorreo.Location = New System.Drawing.Point(6, 94)
        Me.etiquetaDeCorreo.Name = "etiquetaDeCorreo"
        Me.etiquetaDeCorreo.Size = New System.Drawing.Size(38, 13)
        Me.etiquetaDeCorreo.TabIndex = 20
        Me.etiquetaDeCorreo.Text = "Correo"
        '
        'etiquetaDeTelefono
        '
        Me.etiquetaDeTelefono.AutoSize = true
        Me.etiquetaDeTelefono.Location = New System.Drawing.Point(3, 68)
        Me.etiquetaDeTelefono.Name = "etiquetaDeTelefono"
        Me.etiquetaDeTelefono.Size = New System.Drawing.Size(49, 13)
        Me.etiquetaDeTelefono.TabIndex = 19
        Me.etiquetaDeTelefono.Text = "Telefono"
        '
        'etiquetaDeNombre
        '
        Me.etiquetaDeNombre.AutoSize = true
        Me.etiquetaDeNombre.Location = New System.Drawing.Point(3, 40)
        Me.etiquetaDeNombre.Name = "etiquetaDeNombre"
        Me.etiquetaDeNombre.Size = New System.Drawing.Size(44, 13)
        Me.etiquetaDeNombre.TabIndex = 18
        Me.etiquetaDeNombre.Text = "Nombre"
        '
        'etiquetaDeId
        '
        Me.etiquetaDeId.AutoSize = true
        Me.etiquetaDeId.Location = New System.Drawing.Point(3, 12)
        Me.etiquetaDeId.Name = "etiquetaDeId"
        Me.etiquetaDeId.Size = New System.Drawing.Size(16, 13)
        Me.etiquetaDeId.TabIndex = 17
        Me.etiquetaDeId.Text = "Id"
        '
        'DatosDeCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.etiquetaDeCorreo)
        Me.Controls.Add(Me.etiquetaDeTelefono)
        Me.Controls.Add(Me.editorDeTelefono)
        Me.Controls.Add(Me.editorDeCorreo)
        Me.Controls.Add(Me.etiquetaDeNombre)
        Me.Controls.Add(Me.etiquetaDeId)
        Me.Controls.Add(Me.editorDeId)
        Me.Controls.Add(Me.editorDeNombre)
        Me.Name = "DatosDeCliente"
        Me.Size = New System.Drawing.Size(596, 120)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Private WithEvents etiquetaDeCorreo As Label
    Private WithEvents etiquetaDeTelefono As Label
    Private WithEvents etiquetaDeNombre As Label
    Private WithEvents etiquetaDeId As Label
    Private WithEvents editorDeTelefono As TextBox
    Private WithEvents editorDeCorreo As TextBox
    Private WithEvents editorDeId As TextBox
    Private WithEvents editorDeNombre As TextBox
End Class
