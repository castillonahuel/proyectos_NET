<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bBotonSalir = New System.Windows.Forms.Button()
        Me.bBotonIng = New System.Windows.Forms.Button()
        Me.tUsr = New System.Windows.Forms.TextBox()
        Me.tPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bAgregar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña:"
        '
        'bBotonSalir
        '
        Me.bBotonSalir.BackColor = System.Drawing.Color.IndianRed
        Me.bBotonSalir.Location = New System.Drawing.Point(12, 161)
        Me.bBotonSalir.Name = "bBotonSalir"
        Me.bBotonSalir.Size = New System.Drawing.Size(104, 38)
        Me.bBotonSalir.TabIndex = 2
        Me.bBotonSalir.Text = "Salir"
        Me.bBotonSalir.UseVisualStyleBackColor = False
        '
        'bBotonIng
        '
        Me.bBotonIng.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.bBotonIng.Location = New System.Drawing.Point(337, 161)
        Me.bBotonIng.Name = "bBotonIng"
        Me.bBotonIng.Size = New System.Drawing.Size(104, 38)
        Me.bBotonIng.TabIndex = 3
        Me.bBotonIng.Text = "Entrar"
        Me.bBotonIng.UseVisualStyleBackColor = False
        '
        'tUsr
        '
        Me.tUsr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tUsr.Location = New System.Drawing.Point(161, 72)
        Me.tUsr.Name = "tUsr"
        Me.tUsr.Size = New System.Drawing.Size(280, 24)
        Me.tUsr.TabIndex = 4
        '
        'tPass
        '
        Me.tPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPass.Location = New System.Drawing.Point(161, 115)
        Me.tPass.Name = "tPass"
        Me.tPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tPass.Size = New System.Drawing.Size(280, 24)
        Me.tPass.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(156, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Bienvenido!"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(107, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(214, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Ingrese usuario y contraseña para continuar"
        '
        'bAgregar
        '
        Me.bAgregar.BackColor = System.Drawing.Color.Lime
        Me.bAgregar.Location = New System.Drawing.Point(171, 162)
        Me.bAgregar.Name = "bAgregar"
        Me.bAgregar.Size = New System.Drawing.Size(104, 38)
        Me.bAgregar.TabIndex = 8
        Me.bAgregar.Text = "Agregar Usuario"
        Me.bAgregar.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Aquamarine
        Me.ClientSize = New System.Drawing.Size(453, 211)
        Me.ControlBox = False
        Me.Controls.Add(Me.bAgregar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tPass)
        Me.Controls.Add(Me.tUsr)
        Me.Controls.Add(Me.bBotonIng)
        Me.Controls.Add(Me.bBotonSalir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Ingreso al Sistema"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents bBotonSalir As Button
    Friend WithEvents bBotonIng As Button
    Friend WithEvents tUsr As TextBox
    Friend WithEvents tPass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents bAgregar As Button
End Class
