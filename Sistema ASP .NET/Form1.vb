Imports System.IO
Imports System.Data.SqlClient

Public Class Form1
    Private Sub bBotonSalir_Click(sender As Object, e As EventArgs) Handles bBotonSalir.Click
        If MessageBox.Show("Desea salir del sistema?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then End
    End Sub

    Private Sub bBotonIng_Click(sender As Object, e As EventArgs) Handles bBotonIng.Click

        Dim errores As String = ""

        Dim en As String = vbCrLf

        If tUsr.Text.Trim.Length < 3 Then

            errores &= "Debe Igresar un Usuario de al menos 3 caracteres." & en

        End If

        If tPass.Text.Trim.Length < 3 Then

            errores &= "Debe Igresar una Contraseña de al menos 3 caracteres.." & en

        End If

        If errores.Length > 0 Then

            MsgBox("Hubo errores, Por Favor Verifique y Corrija Antes de Intentar de Nuevo:" & en & en & errores, MsgBoxStyle.Information, "Errores")

            Exit Sub

        Else

            Inicio()

        End If

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

    Sub inicio()

        tUsr.Text = tUsr.Text.Replace("'", "").Replace(" ", "").Replace("""", "").ToUpper()
        tPass.Text = tPass.Text.Replace("'", "").Replace(" ", "").Replace("""", "").ToUpper()

        Dim dataAdapter As New SqlDataAdapter("SELECT User, Pass FROM Usuarios WHERE [User] ='" & tUsr.Text & "' AND Pass='" & tPass.Text & "'", con)

        Dim dataSet As New DataSet

        dataAdapter.Fill(dataSet, "Usuarios")

        If dataSet.Tables("Usuarios").Rows.Count > 0 Then

            Dim inicio As New Inicio

            inicio.Show()

            Me.Hide()

        Else

            MsgBox("El Usuario o Contraseña no son Correctos. Intentelo de Nuevo.", MsgBoxStyle.Information, "Inicio Sesión")

        End If

    End Sub

    Private Sub bAgregar_Click(sender As Object, e As EventArgs) Handles bAgregar.Click
        Dim usuarios As New Usuarios
        usuarios.Show()
        Me.Hide()
    End Sub
End Class