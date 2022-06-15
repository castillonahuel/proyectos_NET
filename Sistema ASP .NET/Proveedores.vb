Imports System.IO
Imports System.Data.SqlClient

Public Class Proveedores
    Private Sub bVolverp_Click(sender As Object, e As EventArgs) Handles bVolverp.Click
        Me.Close()
    End Sub

    Dim ar As String
    Dim con As New SqlConnection("data source=" & CStr(leerarchivo(ar)) & "; initial catalog=Sistema; integrated security=true")
    Function leerarchivo(ByVal archivo As String) As String
        If File.Exists("c:\ABM\ip.txt") = True Then
            Dim SR As StreamReader = File.OpenText("c:\ABM\ip.txt")
            Dim Line As String = SR.ReadLine()
            SR.Close()
            Return Line
        Else
            MsgBox("Verifique Falta Archivo de Configuracion")
            Me.Close()
        End If
    End Function

    Private Sub ABM_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        buscar(" nombreprov like '" & tApellido.Text & "%' ")
    End Sub
    Sub buscar(ByVal condicion As String)

        Dim da As New SqlDataAdapter("SELECT TOP (100) PERCENT nprov,nombreprov from proveedores where " & condicion & " order by nprov", con)
        Dim ds As New DataSet
        da.Fill(ds, "Proveedores")
        If ds.Tables("Proveedores").Rows.Count = 0 Then

            DataGridView1.Visible = False

            pBotones.Visible = False
            pCampos.Visible = False
            lLegajo.Visible = False
        Else

            DataGridView1.DataSource = ds.Tables("Proveedores")
            DataGridView1.Refresh()
            DataGridView1.Visible = True

            lLegajo.Visible = True
        End If

    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        FilaClick(e)
    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        FilaClick(e)
    End Sub
    Sub FilaClick(ByVal e As Object)
        Dim fila As Integer = e.RowIndex
        Dim tfila As String

        If IsNothing(DataGridView1.Rows(fila).Cells(0).Value) Then
            lLegajo.Text = "0"
            pBotones.Visible = False
            pCampos.Visible = False
            Exit Sub
        Else
            tfila = DataGridView1.Rows(fila).Cells(0).Value
            lLegajo.Text = tfila.ToString()
            CargarCamposProveedores()
        End If

    End Sub

    Sub CargarCamposProveedores()
        If Val(lLegajo.Text) = 0 Then
            pBotones.Visible = False
            pCampos.Visible = False

            Exit Sub
        Else
            pBotones.Visible = True
            pCampos.Visible = True
            Dim da As New SqlDataAdapter("SELECT  upper(ltrim(rtrim(isnull(nombreprov,'****')))) as nombre ,isnull(cuitprov,0) as cuit, ltrim(rtrim(isnull(domicilioprov,''))) as dirección,ltrim(rtrim(isnull(localidadprov,''))) as localidad,ltrim(rtrim(isnull(provinciaprov,''))) as provincia,ltrim(rtrim(isnull(teléfonosProv,''))) as teléfonos,Fechafundacionprov as fechanacimiento,ltrim(rtrim(isnull(comentariosProv,''))) as comentarios,ltrim(rtrim(isnull([E-Mail-Prov],''))) as email, isnull(estado,0) as Estado from proveedores where nprov=" & Val(lLegajo.Text), con)
            Dim ds As New DataSet
            da.Fill(ds, "Proveedores")
            TextBox1.Text = ds.Tables("Proveedores").Rows(0)("nombre")
            TextBox2.Text = ds.Tables("Proveedores").Rows(0)("cuit")

            TextBox3.Text = ds.Tables("Proveedores").Rows(0)("dirección")
            TextBox4.Text = ds.Tables("Proveedores").Rows(0)("localidad")
            TextBox5.Text = ds.Tables("Proveedores").Rows(0)("provincia")
            TextBox6.Text = ds.Tables("Proveedores").Rows(0)("teléfonos")
            TextBox7.Text = ds.Tables("Proveedores").Rows(0)("email")
            CheckBox1.Checked = IIf(ds.Tables("Proveedores").Rows(0)("estado") = 0, False, True)


            TextBox12.Text = ds.Tables("Proveedores").Rows(0)("comentarios")

            DateTimePicker1.Value = ds.Tables("Proveedores").Rows(0)("fechanacimiento")
        End If
    End Sub

    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click
        buscar(" nombreprov like '" & tApellido.Text & "%' ")
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        tApellido.Text = ""
        buscar(" nombreprov like '" & tApellido.Text & "%' ")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If MessageBox.Show("Está por ELIMINAR definitivamente al REGISTRO DE : " & TextBox1.Text.Trim.ToUpper & ". Es algo EXTREMO, porque todos los cursos que lo tienen desde el 2005 perderán las referencias. Está SEGURO?", "Eliminar Profesor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

        If SQL_Accion("delete from proveedores  where  nprov=" & Val(lLegajo.Text)) = False Then
            MsgBox("Hubo un error al intentar borrar al Proveedor, reintente, y si el error persiste, anote todos los datos que quizo ingresar y comuníquese con el programador.")
        Else

            buscar(" nprov=" & Val(lLegajo.Text))
            MsgBox("El registro fue ELIMINADO de la base de datos.")

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim errores As String = "", en As String = vbCrLf
        If TextBox1.Text.Trim.Length < 3 Then
            errores &= "Debe completar el nombre del proveedor." & en
        End If
        TextBox2.Text = Val(TextBox2.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", ""))
        If TextBox2.Text.Trim.Length < 4 Or TextBox2.Text.IndexOf("11111") > -1 Or TextBox2.Text.IndexOf("12345") > -1 Or TextBox2.Text.IndexOf("000000") > -1 Then
            errores &= "Debe completar CORRECTAMENTE el CUIT del proveedor." & en
        End If
        If TextBox7.Text.Trim.Length <> 0 And (TextBox7.Text.IndexOf("@") < 0 Or TextBox7.Text.IndexOf(".") < 0) Then
            errores &= "Verifique por favor el email del profesor. No es obligatorio, pero si lo escribe debe ser correcto." & en
        End If
        If errores.Length > 0 Then
            MsgBox("Hubo errores, por favor verifique y corrija antes de intentar de nuevo:" & en & en & errores)
            Exit Sub
        End If
        ' TextBox12.Text = "update Profesores set apellidos='" & TextBox1.Text.Trim.ToUpper.Replace("'", "´") & "', nombres='" & TextBox2.Text.Trim.ToUpper.Replace("'", "´") & "', sexo='" & Sexo.SelectedItem & "', doc=" & Val(TextBox3.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", "")) & ", nacionalidad='" & TextBox10.Text.Trim.ToUpper & "', dirección='" & TextBox4.Text.Trim.ToUpper.Replace("'", "´") & "', localidad='" & TextBox5.Text.Trim.ToUpper.Replace("'", "´") & "', teléfparticular='" & TextBox6.Text.Trim.ToUpper.Replace("'", "´") & "', emailalumno='" & TextBox7.Text.Trim.ToUpper.Replace("'", "´") & "', fechanacimiento=" & FechaSQL(DateTimePicker1.Value) & ", ocupación='" & TextBox8.Text.Trim.ToUpper.Replace("'", "´") & "', colegio='" & TextBox9.Text.Trim.ToUpper.Replace("'", "´") & "', turno='" & TextBox11.Text.Trim.ToUpper.Replace("'", "´") & "', comentarios='" & TextBox12.Text.Trim.ToUpper.Replace("'", "´") & "' where legajo=" & VNum(lLegajo.Text)
        If SQL_Accion("update proveedores set estado='" & If(CheckBox1.Checked, 1, 0) & "', nombreprov='" & TextBox1.Text.Trim.ToUpper.Replace("'", "´") & "', cuitprov=" & Val(TextBox2.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", "")) & ", domicilioprov='" & TextBox3.Text.Trim.ToUpper.Replace("'", "´") & "', localidadprov='" & TextBox4.Text.Trim.ToUpper.Replace("'", "´") & "', provinciaprov='" & TextBox5.Text.Trim.ToUpper.Replace("'", "´") & "', teléfonosprov='" & TextBox6.Text.Trim.ToUpper.Replace("'", "´") & "', [e-mail-prov]='" & TextBox7.Text.Trim.ToUpper.Replace("'", "´") & "', fechafundacionprov=" & FechaSQL(DateTimePicker1.Value) & ", comentariosprov='" & TextBox12.Text.Trim.ToUpper.Replace("'", "´") & "' where nprov=" & VNum(lLegajo.Text)) = True Then
            MsgBox("Cambios realizados correctamente.")

            buscar(" nprov=" & VNum(lLegajo.Text))
        Else
            MsgBox("Se produjo un error al querer guardar los datos del profesor, reintente, y si el error persiste, anote todos los datos que quizo ingresar y comuníquese con el programador.")
        End If
    End Sub

    Private Sub bNuevoProfesor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoProv.Click
        If SQL_Accion("insert into proveedores (nombreprov, cuitprov, domicilioprov, localidadprov, teléfonosprov, fechafundacionprov, comentariosprov,[e-mail-prov],estado) values ('*****',                  0,           '',           '',             '',           getdate(),               ''       ,      ''    ,     1   )  ") Then


            buscar(" nombreprov like '****%' ")
            MsgBox("Se ha creado un nuevo registro para el profesor que desea ingresar, seleccione la línea nueva, cargue los datos y luego confirme con el botón 'Aceptar Cambios'.")
        End If
    End Sub

End Class