Imports System.IO
Imports System.Data.SqlClient
Public Class Usuarios
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim errores As String = "", en As String = vbCrLf
        If Usr1.Text <> Usr2.Text Then
            errores &= "Los usuarios ingresados no concuerdan" & en
        End If
        If Pswd1.Text <> Pswd2.Text Then
            errores &= "Las contraseñas ingresadas no concuerdan" & en
        End If
        If errores.Length > 0 Then
            MsgBox("Hubo errores, por favor verifique y corrija antes de intentar de nuevo:" & en & en & errores)
            Exit Sub
        End If

        If SQL_Accion("insert into Usuarios ([User], Pass) values ('" & Usr1.Text.Trim.ToUpper.Replace("'", "´") & "', '" & Pswd1.Text.Trim.ToUpper.Replace("'", "´") & "')") = True Then
            MsgBox("Se cargo el usuario.")
            Me.Close()
            Form1.Show()
        Else
            MsgBox("Se produjo un error al querer guardar los datos del usuario, reintente, y si el error persiste, anote todos los datos que quizo ingresar y comuníquese con el programador.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class