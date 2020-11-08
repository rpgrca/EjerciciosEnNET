<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgendaView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.editorDeNombre = New System.Windows.Forms.TextBox()
        Me.botonAgregar = New System.Windows.Forms.Button()
        Me.editorDeId = New System.Windows.Forms.TextBox()
        Me.etiquetaDeId = New System.Windows.Forms.Label()
        Me.etiquetaDeNombre = New System.Windows.Forms.Label()
        Me.etiquetaDeCorreo = New System.Windows.Forms.Label()
        Me.etiquetaDeTelefono = New System.Windows.Forms.Label()
        Me.editorDeTelefono = New System.Windows.Forms.TextBox()
        Me.editorDeCorreo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ListView1.FullRowSelect = true
        Me.ListView1.GridLines = true
        Me.ListView1.HideSelection = false
        Me.ListView1.Location = New System.Drawing.Point(12, 12)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(390, 264)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = false
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'editorDeNombre
        '
        Me.editorDeNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeNombre.Location = New System.Drawing.Point(70, 310)
        Me.editorDeNombre.Name = "editorDeNombre"
        Me.editorDeNombre.Size = New System.Drawing.Size(332, 20)
        Me.editorDeNombre.TabIndex = 1
        '
        'botonAgregar
        '
        Me.botonAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.botonAgregar.Location = New System.Drawing.Point(299, 362)
        Me.botonAgregar.Name = "botonAgregar"
        Me.botonAgregar.Size = New System.Drawing.Size(103, 23)
        Me.botonAgregar.TabIndex = 4
        Me.botonAgregar.Text = "Agregar"
        Me.botonAgregar.UseVisualStyleBackColor = true
        '
        'editorDeId
        '
        Me.editorDeId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeId.Enabled = false
        Me.editorDeId.Location = New System.Drawing.Point(70, 282)
        Me.editorDeId.Name = "editorDeId"
        Me.editorDeId.Size = New System.Drawing.Size(332, 20)
        Me.editorDeId.TabIndex = 0
        '
        'etiquetaDeId
        '
        Me.etiquetaDeId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.etiquetaDeId.AutoSize = true
        Me.etiquetaDeId.Location = New System.Drawing.Point(9, 285)
        Me.etiquetaDeId.Name = "etiquetaDeId"
        Me.etiquetaDeId.Size = New System.Drawing.Size(16, 13)
        Me.etiquetaDeId.TabIndex = 7
        Me.etiquetaDeId.Text = "Id"
        '
        'etiquetaDeNombre
        '
        Me.etiquetaDeNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.etiquetaDeNombre.AutoSize = true
        Me.etiquetaDeNombre.Location = New System.Drawing.Point(9, 313)
        Me.etiquetaDeNombre.Name = "etiquetaDeNombre"
        Me.etiquetaDeNombre.Size = New System.Drawing.Size(44, 13)
        Me.etiquetaDeNombre.TabIndex = 8
        Me.etiquetaDeNombre.Text = "Nombre"
        '
        'etiquetaDeCorreo
        '
        Me.etiquetaDeCorreo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.etiquetaDeCorreo.AutoSize = true
        Me.etiquetaDeCorreo.Location = New System.Drawing.Point(12, 367)
        Me.etiquetaDeCorreo.Name = "etiquetaDeCorreo"
        Me.etiquetaDeCorreo.Size = New System.Drawing.Size(38, 13)
        Me.etiquetaDeCorreo.TabIndex = 12
        Me.etiquetaDeCorreo.Text = "Correo"
        '
        'etiquetaDeTelefono
        '
        Me.etiquetaDeTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.etiquetaDeTelefono.AutoSize = true
        Me.etiquetaDeTelefono.Location = New System.Drawing.Point(9, 341)
        Me.etiquetaDeTelefono.Name = "etiquetaDeTelefono"
        Me.etiquetaDeTelefono.Size = New System.Drawing.Size(49, 13)
        Me.etiquetaDeTelefono.TabIndex = 11
        Me.etiquetaDeTelefono.Text = "Telefono"
        '
        'editorDeTelefono
        '
        Me.editorDeTelefono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeTelefono.Location = New System.Drawing.Point(70, 338)
        Me.editorDeTelefono.Name = "editorDeTelefono"
        Me.editorDeTelefono.Size = New System.Drawing.Size(332, 20)
        Me.editorDeTelefono.TabIndex = 2
        '
        'editorDeCorreo
        '
        Me.editorDeCorreo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.editorDeCorreo.Location = New System.Drawing.Point(70, 364)
        Me.editorDeCorreo.Name = "editorDeCorreo"
        Me.editorDeCorreo.Size = New System.Drawing.Size(223, 20)
        Me.editorDeCorreo.TabIndex = 3
        '
        'AgendaView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 391)
        Me.Controls.Add(Me.etiquetaDeCorreo)
        Me.Controls.Add(Me.etiquetaDeTelefono)
        Me.Controls.Add(Me.editorDeTelefono)
        Me.Controls.Add(Me.editorDeCorreo)
        Me.Controls.Add(Me.etiquetaDeNombre)
        Me.Controls.Add(Me.etiquetaDeId)
        Me.Controls.Add(Me.editorDeId)
        Me.Controls.Add(Me.botonAgregar)
        Me.Controls.Add(Me.editorDeNombre)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "AgendaView"
        Me.Text = "AgendaView"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ListView1 As ListView
    Friend WithEvents botonAgregar As Button
    Friend WithEvents editorDeNombre As TextBox
    Friend WithEvents editorDeId As TextBox
    Friend WithEvents etiquetaDeId As Label
    Friend WithEvents etiquetaDeNombre As Label
    Friend WithEvents etiquetaDeCorreo As Label
    Friend WithEvents etiquetaDeTelefono As Label
    Friend WithEvents editorDeTelefono As TextBox
    Friend WithEvents editorDeCorreo As TextBox
End Class
