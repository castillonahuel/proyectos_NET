Imports System.IO
Imports System.Data.SqlClient
Public Class Clientes
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

    Private Sub ABM_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        buscar(" apellidocli like '" & tApellidoC.Text & "%' ")
    End Sub
    Sub buscar(ByVal condicion As String)

        Dim da As New SqlDataAdapter("SELECT TOP (100) PERCENT ncli,apellidocli from clientes where " & condicion & " order by ncli", con)
        Dim ds As New DataSet
        da.Fill(ds, "Clientes")
        If ds.Tables("Clientes").Rows.Count = 0 Then

            DataGridView1.Visible = False

            pBotones.Visible = False
            pCampos.Visible = False
            lLegajo.Visible = False
        Else

            DataGridView1.DataSource = ds.Tables("Clientes")
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
            CargarCamposClientes()
        End If

    End Sub

    Sub CargarCamposClientes()
        If Val(lLegajo.Text) = 0 Then
            pBotones.Visible = False
            pCampos.Visible = False

            Exit Sub
        Else
            pBotones.Visible = True
            pCampos.Visible = True
            Dim da As New SqlDataAdapter("SELECT  upper(ltrim(rtrim(isnull(apellidocli,'****')))) as apellido, upper(ltrim(rtrim(isnull(nombrecli,'****')))) as nombre, isnull([documento-cli],0) as documento , isnull(cuitcli,0) as cuit, ltrim(rtrim(isnull(UserCli,''))) as usuario, ltrim(rtrim(isnull(clavecli,''))) as pass, ltrim(rtrim(isnull(domiciliocli,''))) as direccion, ltrim(rtrim(isnull(localidadcli,''))) as localidad, ltrim(rtrim(isnull(provinciacli,''))) as provincia, ltrim(rtrim(isnull(teléfonoscli,''))) as teléfonos,Fechanacimientocli as fechanacimiento,ltrim(rtrim(isnull(comentarioscli,''))) as comentarios,ltrim(rtrim(isnull([E-Mail-Cli],''))) as email, isnull(postalcli,0) as codpostal, isnull(estado,0) as Estado from clientes where ncli=" & Val(lLegajo.Text), con)
            Dim ds As New DataSet
            da.Fill(ds, "Clientes")
            TextBox1.Text = ds.Tables("Clientes").Rows(0)("apellido")
            TextBox2.Text = ds.Tables("Clientes").Rows(0)("nombre")
            TextBox3.Text = ds.Tables("Clientes").Rows(0)("documento")
            TextBox4.Text = ds.Tables("Clientes").Rows(0)("cuit")
            TextBox5.Text = ds.Tables("Clientes").Rows(0)("usuario")
            TextBox6.Text = ds.Tables("Clientes").Rows(0)("pass")

            TextBox7.Text = ds.Tables("Clientes").Rows(0)("direccion")
            TextBox8.Text = ds.Tables("Clientes").Rows(0)("localidad")
            TextBox9.Text = ds.Tables("Clientes").Rows(0)("provincia")
            TextBox10.Text = ds.Tables("Clientes").Rows(0)("teléfonos")
            TextBox11.Text = ds.Tables("Clientes").Rows(0)("email")
            TextBox13.Text = ds.Tables("Clientes").Rows(0)("codpostal")
            CheckBox1.Checked = IIf(ds.Tables("Clientes").Rows(0)("estado") = 0, False, True)


            TextBox12.Text = ds.Tables("Clientes").Rows(0)("comentarios")

            DateTimePicker1.Value = ds.Tables("Clientes").Rows(0)("fechanacimiento")
        End If
    End Sub

    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click
        buscar(" apellidocli like '" & tApellidoC.Text & "%' ")
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        tApellidoC.Text = ""
        buscar(" apellidocli like '" & tApellidoC.Text & "%' ")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If MessageBox.Show("Está por ELIMINAR definitivamente al REGISTRO DE : " & TextBox1.Text.Trim.ToUpper & ". Es algo EXTREMO, porque todos los cursos que lo tienen desde el 2005 perderán las referencias. Está SEGURO?", "Eliminar Profesor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

        If SQL_Accion("delete from clientes where ncli=" & Val(lLegajo.Text)) = False Then
            MsgBox("Hubo un error al intentar borrar al Cliente, reintente, y si el error persiste, anote todos los datos que quizo ingresar y comuníquese con el programador.")
        Else

            buscar(" ncli=" & Val(lLegajo.Text))
            MsgBox("El registro fue ELIMINADO de la base de datos.")

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim errores As String = "", en As String = vbCrLf
        If TextBox1.Text.Trim.Length < 3 Then
            errores &= "Debe completar el apellido del cliente." & en
        End If
        If TextBox2.Text.Trim.Length < 3 Then
            errores &= "Debe completar el nombre del cliente." & en
        End If
        TextBox3.Text = Val(TextBox3.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", ""))
        If TextBox3.Text.Trim.Length < 4 Or TextBox3.Text.IndexOf("11111") > -1 Or TextBox3.Text.IndexOf("12345") > -1 Or TextBox3.Text.IndexOf("000000") > -1 Then
            errores &= "Debe completar CORRECTAMENTE el DOCUMENTO del cliente." & en
        End If
        TextBox4.Text = Val(TextBox4.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", ""))
        If TextBox4.Text.Trim.Length < 4 Or TextBox4.Text.IndexOf("11111") > -1 Or TextBox4.Text.IndexOf("12345") > -1 Or TextBox4.Text.IndexOf("000000") > -1 Then
            errores &= "Debe completar CORRECTAMENTE el CUIT del cliente." & en
        End If

        If TextBox11.Text.Trim.Length <> 0 And (TextBox11.Text.IndexOf("@") < 0 Or TextBox11.Text.IndexOf(".") < 0) Then
            errores &= "Verifique por favor el email del profesor. No es obligatorio, pero si lo escribe debe ser correcto." & en
        End If
        If errores.Length > 0 Then
            MsgBox("Hubo errores, por favor verifique y corrija antes de intentar de nuevo:" & en & en & errores)
            Exit Sub
        End If
        ' TextBox12.Text = "update Profesores set apellidos='" & TextBox1.Text.Trim.ToUpper.Replace("'", "´") & "', nombres='" & TextBox2.Text.Trim.ToUpper.Replace("'", "´") & "', sexo='" & Sexo.SelectedItem & "', doc=" & Val(TextBox3.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", "")) & ", nacionalidad='" & TextBox10.Text.Trim.ToUpper & "', dirección='" & TextBox4.Text.Trim.ToUpper.Replace("'", "´") & "', localidad='" & TextBox5.Text.Trim.ToUpper.Replace("'", "´") & "', teléfparticular='" & TextBox6.Text.Trim.ToUpper.Replace("'", "´") & "', emailalumno='" & TextBox7.Text.Trim.ToUpper.Replace("'", "´") & "', fechanacimiento=" & FechaSQL(DateTimePicker1.Value) & ", ocupación='" & TextBox8.Text.Trim.ToUpper.Replace("'", "´") & "', colegio='" & TextBox9.Text.Trim.ToUpper.Replace("'", "´") & "', turno='" & TextBox11.Text.Trim.ToUpper.Replace("'", "´") & "', comentarios='" & TextBox12.Text.Trim.ToUpper.Replace("'", "´") & "' where legajo=" & VNum(lLegajo.Text)
        If SQL_Accion("update clientes set estado='" & If(CheckBox1.Checked, 1, 0) & "', apellidocli='" & TextBox1.Text.Trim.ToUpper.Replace("'", "´") & "', nombrecli='" & TextBox2.Text.Trim.ToUpper.Replace("'", "´") & "', [documento-cli]='" & Val(TextBox3.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", "")) & "', cuitcli='" & Val(TextBox4.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", "")) & "', usercli='" & TextBox5.Text.Trim.ToUpper.Replace("'", "´") & "', clavecli='" & TextBox6.Text.Trim.ToUpper.Replace("'", "´") & "', domiciliocli='" & TextBox7.Text.Trim.ToUpper.Replace("'", "´") & "', localidadcli='" & TextBox8.Text.Trim.ToUpper.Replace("'", "´") & "', provinciacli='" & TextBox9.Text.Trim.ToUpper.Replace("'", "´") & "', teléfonoscli='" & TextBox10.Text.Trim.ToUpper.Replace("'", "´") & "', [e-mail-cli]='" & TextBox11.Text.Trim.ToUpper.Replace("'", "´") & "', postalcli='" & Val(TextBox13.Text.Trim.Replace(".", "").Replace(" ", "").Replace(",", "")) & "', fechanacimientocli=" & FechaSQL(DateTimePicker1.Value) & ", comentarioscli='" & TextBox12.Text.Trim.ToUpper.Replace("'", "´") & "' where ncli=" & VNum(lLegajo.Text)) = True Then
            MsgBox("Cambios realizados correctamente.")

            buscar(" ncli=" & VNum(lLegajo.Text))
        Else
            MsgBox("Se produjo un error al querer guardar los datos del cliente, reintente, y si el error persiste, anote todos los datos que quizo ingresar y comuníquese con el programador.")
        End If
    End Sub

    Private Sub bNuevoProfesor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoCli.Click
        If SQL_Accion("insert into clientes (apellidocli, nombrecli, [documento-cli], cuitcli, usercli, clavecli, domiciliocli, localidadcli, teléfonoscli, fechanacimientocli, comentarioscli ,[e-mail-cli], postalcli, estado) values ('*****', '*****',                  0,                  0,           '',           '',           '',           '',             '',           getdate(),               ''       ,         ''    ,              0,     1   )  ") Then


            buscar(" apellidocli like '****%' ")
            MsgBox("Se ha creado un nuevo registro para el profesor que desea ingresar, seleccione la línea nueva, cargue los datos y luego confirme con el botón 'Aceptar Cambios'.")
        End If
    End Sub

End Class