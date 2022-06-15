Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net.Mail

Public Class _Default
    Inherits System.Web.UI.Page

    Public a As Integer
    Public connectionString As String = ConfigurationManager.ConnectionStrings(ConfigurationManager.AppSettings("Conexion")).ToString()
    Public EmailActivo As String = ConfigurationManager.AppSettings("EmailActivo")
    Public Email As String = ConfigurationManager.AppSettings(EmailActivo)
    Public EmailPass As String = ConfigurationManager.AppSettings(EmailActivo & "Pass")

    Dim con As New SqlConnection(connectionString)
    Dim ar As String

    Function EnviarMail(ByVal EmailDestino As String, ByVal Subject As String, ByVal Mensaje As String) As String
        Dim Resultado As String = "OK"
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()

        Try

            mail = New MailMessage()

            mail.From = New MailAddress(Email, "Helados Fernando")
            mail.To.Add(EmailDestino)
            mail.Subject = Subject
            mail.Body = Mensaje
            mail.IsBodyHtml = False
            mail.Priority = MailPriority.Normal

            If EmailActivo = "EmailGmail" Then
                SmtpServer.Credentials = New Net.NetworkCredential(Email, EmailPass)
                SmtpServer.Host = "smtp.gmail.com"
                SmtpServer.Port = 587
                SmtpServer.EnableSsl = True
            Else
                SmtpServer.Credentials = New Net.NetworkCredential(Email, EmailPass)
                SmtpServer.Host = "dctwin033.ferozo.com"
                SmtpServer.Port = 465
                SmtpServer.EnableSsl = True
            End If

            SmtpServer.Send(mail)

        Catch
            Resultado = Err.Description
        End Try
        mail.Dispose()
        Return Resultado
    End Function

    Protected Sub bRecuperarClave_Click(sender As Object, e As ImageClickEventArgs) Handles bRecuperarClave.Click
        Dim usu As String = tUsuario.Text.Trim.ToUpper, email As String, xusuario As String, mensaje As String, pass As String
        Dim en As String = Chr(13) & Chr(10)
        If Comprobar(usu) = False Then
            lReenviarClave.Text = "*** El usuario es incorrecto. Revisá por favor. ***"
            lReenviarClave.Visible = True
            Exit Sub
        End If

        Dim da2 As New SqlDataAdapter("select ltrim(rtrim(nombre)) + ' ' + ltrim(rtrim(apellido)) as usuario,  pass," & " email from Usuarios where upper(ltrim(rtrim(Usuario)))='" & usu & "'", con)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Login")
        If ds2.Tables("Login").Rows.Count = 0 Then
            lReenviarClave.Text = "*** El usuario es incorrecto. Revisá por favor. ***"
            lReenviarClave.Visible = True
            Exit Sub
        End If
        email = ds2.Tables("Login").Rows(0)("Email").ToString.Trim.ToLower
        pass = ds2.Tables("Login").Rows(0)("pass").ToString.Trim.ToLower
        xusuario = ds2.Tables("Login").Rows(0)("usuario").ToString.Trim

        mensaje = "Hola " & xusuario & "." & en & en & "Le escribimos desde Helados Fernando, respondiendo a su pedido " & "de recuperacion de clave." & en & en & "Su usuario es " & """" & usu & """" & en & "Su clave es " & """" & pass & """" & en & en & "Ya podés volver a entrar y armar tus pedidos!" & en & "Un gran saludo desde Helados Fernando!" & en & en & en & en & "(Por favor no respondas a este mail, es automático....gracias!)" & en & en

        Dim ok As String = EnviarMail(email, "Helados Fernando- Clave Recuperada", mensaje)
        If ok = "OK" Then
            lReenviarClave.Text = "*** Ya te enviams un mail con la clave! ***"
        Else
            lReenviarClave.Text = "*** Hubo un error al querer enviar el mail... ***"
        End If
        lReenviarClave.Visible = True
    End Sub

    Protected Sub Usu_Checked()

        Administrador.Checked = False

    End Sub
    Protected Sub Admin_Checked()

        Usuario.Checked = False

    End Sub

    Protected Sub bPortada_Click(sender As Object, e As ImageClickEventArgs) Handles bPortada.Click
        pPortada.Visible = False
        pLoginMenu.Visible = True
    End Sub
    Protected Sub bVolverLogin_Click(sender As Object, e As ImageClickEventArgs) Handles bVolverLogin.Click
        pPortada.Visible = True
        pLogin.Visible = False
    End Sub

    Protected Sub bRegistrarse_Click(sender As Object, e As ImageClickEventArgs) Handles bRegistrarse.Click
        pLoginMenu.Visible = False
        pRegistrarse.Visible = True
    End Sub

    Protected Sub bTerminar_Click(sender As Object, e As ImageClickEventArgs) Handles bTerminar.Click
        pLoginMenu.Visible = False
        pPortada.Visible = True
    End Sub

    Protected Sub bRegistrarseU_Click(sender As Object, e As ImageClickEventArgs) Handles bRegistrarseU.Click
        Dim ok As Boolean = True

        LimpiarErroresRegistroU()

        If Usuario.Checked = True Then

            tNombreU.Text = tNombreU.Text.Trim.ToUpper
            If Comprobar(tNombreU.Text) = False Then
                ArreglarCampo(tNombreU)
                ok = False
                lENombreU.Text = "El nombre contenía caracteres inválidos, fueron quitados."
                lENombreU.Visible = True
            End If

            tApellidoU.Text = tApellidoU.Text.Trim.ToUpper
            If Comprobar(tApellidoU.Text) = False Then
                ArreglarCampo(tApellidoU)
                ok = False
                lEApellidoU.Text = "El apellido contenía caracteres inválidos, fueron quitados."
                lEApellidoU.Visible = True
            End If

            tDocU.Text = tDocU.Text.Trim
            If Comprobar(tDocU.Text) = False Or Not IsNumeric(tDocU.Text) Then
                SoloNumeros(tDocU)
                ok = False
                lEDocU.Text = "El documento no era válido, se ajustó a número."
                lEDocU.Visible = True
            End If

            ArreglarCampo(tEmailU)
            If ValidateEmail(tEmailU.Text) = False Then
                ok = False
                lEEmailU.Text = "El email no es válido."
                lEEmailU.Visible = True
            End If

            tLocalidadU.Text = tLocalidadU.Text.Trim().ToUpper
            If Comprobar(tLocalidadU.Text) = False Then
                ArreglarCampo(tLocalidadU)
                ok = False
                lELocalidadU.Text = "La localidad contenia caracteres inválidos, fueron quitados"
                lELocalidadU.Visible = True
            End If

            tDireccionU.Text = tDireccionU.Text.Trim().ToUpper
            If Comprobar(tDireccionU.Text) = False Then
                ArreglarCampo(tDireccionU)
                ok = False
                lEDireccionU.Text = "La dirección contenia caracteres inválidos, fueron quitados"
                lEDireccionU.Visible = True
            End If

            tTelefonosU.Text = tTelefonosU.Text.Trim().ToUpper
            If Comprobar(tTelefonosU.Text) = False Then
                ArreglarCampo(tTelefonosU)
                ok = False
                lETelefonosU.Text = "El teléfono contenia caracteres inválidos, fueron quitados"
                lETelefonosU.Visible = True
            End If

            Dim FechaNacimiento As Date
            ControlDeNacimiento(tF_Nac, ok, lEFNac, lEdad, True, FechaNacimiento)

            tUrsuarioU.Text = tUrsuarioU.Text.Trim().ToUpper
            If Comprobar(tUrsuarioU.Text) = False Or tUrsuarioU.Text.IndexOf(" ") > -1 Then
                tUrsuarioU.Text = tUrsuarioU.Text.Replace(" ", "")
                ArreglarCampo(tUrsuarioU)
                ok = False
                lEUsuarioU.Text = "El usuario contenía caracteres inválidos, fueron quitados."
                lEUsuarioU.Visible = True
            End If
            If tUrsuarioU.Text.Length < 5 Then
                ok = False
                lEUsuarioU.Text = "El usuario debe tener de 5 a 10 caracteres, letras y/o números"
                lEUsuarioU.Visible = True
            End If

            tPassU.Text = tPassU.Text.Trim()
            If Comprobar(tPassU.Text) = False Or tPassU.Text.IndexOf(" ") > -1 Then
                tPassU.Text = tPassU.Text.Replace(" ", "")
                ArreglarCampo(tPassU)
                ok = False
                lEPassU.Text = "La clave contenía caracteres inválidos, fueron quitados."
                lEPassU.Visible = True
            End If
            If tPassU.Text.Length < 5 Then
                ok = False
                lEPassU.Text = "La clave debe tener de 5 a 10 caracteres, letras y/o números."
                lEPassU.Visible = True
            End If
            tPass2U.Text = tPass2U.Text.Trim()
            If Comprobar(tPass2U.Text) = False Or tPass2U.Text.IndexOf(" ") > -1 Then
                tPass2U.Text = tPassU.Text.Replace(" ", "")
                ArreglarCampo(tPassU)
                ok = False
                lEPass2U.Text = "La segunda clave contenía caracteres inválidos, fueron quitados."
                lEPass2U.Visible = True
            End If
            If tPass2U.Text.Length < 5 Then
                ok = False
                lEPass2U.Text = "La segunda clave debe tener de 5 a 10 caracteres, letras y/o números."
                lEPass2U.Visible = True
            End If

            If ok = False Then
                lErroresU.Text = "Revise los errores por favor y luego reintente."
                lErroresU.Visible = True
                Exit Sub
            End If
            If tPass2U.Text <> tPassU.Text Then
                ok = False
                tPass2U.Text = "Las 2 claves son diferentes."
                tPass2U.Visible = True
            End If

            Session("Usuario") = tUrsuarioU.Text
            Session("Password") = tPassU.Text
            Session("mail") = tEmailU.Text
            Session("TipoDocumento") = dTDocU.SelectedValue.Trim
            Session("Documento") = tDocU.Text.Trim
            If YaExisteSQL("select idUsuario from Usuarios where Usuario='" & Session("Usuario") & "'") Then
                ok = False
                lEUsuarioU.Text = "El usuario elegido ya existe. Pruebe con otro"
                lEUsuarioU.Visible = True
            End If

            If YaExisteSQL("select idUsuario from Usuarios where Doc='" & Session("Documento") & "' and tDoc='" & Session("TipoDocumento") & "'") Then
                ok = False
                lEDocU.Text = "Ya existe el " & Session("TipoDocumento") & " " & Session("Documento") & "."
                lEDocU.Visible = True
            End If

            If YaExisteSQL("select idUsuario from Usuario where email='" & Session("Mail") & "'") Then
                ok = False
                lEEmailU.Text = "Ya se utilizo este email. Pruebe con otro"
                lEEmailU.Visible = True
            End If

            If ok = False Then
                lErroresU.Text = "Solo se permite una inscripción por persona."
                lErroresU.Visible = True
                Exit Sub
            End If

            Session("Usuario") = tUrsuarioU.Text.ToLower
            Session("Password") = tPassU.Text
            Session("TipoDocumento") = dTDocU.SelectedValue.Trim
            Session("Documento") = tDocU.Text.Trim
            Session("ApellidoYNombre") = tNombreU.Text.Trim & " " & tApellidoU.Text.Trim
            Session("Email") = tEmailU.Text.Trim

            LimpiarErroresRegistroU()

            Session("sqlIngreso") = "insert into Usuarios (Apellido,Nombre,tDoc,Doc,Usuario,Pass,Email,idProv,Localidad,Direccion,Telefonos,fNacimiento) values('" & tApellidoU.Text.Trim & "','" & tNombreU.Text.Trim & "','" & Session("TipoDocumento") & "','" & Session("Documento") & "','" & Session("Usuario") & "','" & Session("Password") & "','" & Session("Email") & "','" & didProvU.SelectedValue & "','" & tLocalidadU.Text.Trim & "','" & tDireccionU.Text.Trim & "','" & tTelefonosU.Text.Trim & "','" & FechaNacimiento.ToString("yyyy-MM-dd") & "')"

            Dim codigo As String = CrearCodigo(4)
            Session("codigo") = codigo
            Dim en As String = Chr(13) & Chr(10), mensaje As String = "Saludos " & Session("ApellidoYNombre") & "." & en & en & "Te escribimos desde Helados Fernando, en respuesta a tu solicitud de registro " & "como nuevo usuario de nuestra aplicación." & en & en & "Por favor ingresá el código: " & codigo & " en el cuadro de texto de " & "la aplicacon web, y presioná Validar. Esto completará tu registro " & "Como nuevo usuario de Helados Fernando" & en & en & "Felicitaciones" & en & "El equipo de Helados Fernando" & en & en & en & en & "(Por favor, no responda a éste mail, es automático...muchas gracias!)" & en & en

            Dim ok2 As String = EnviarMail(Session("Email"), "Helados Fernando - Registro como Usuario", mensaje)
            tValidar.Text = ""
            lCodigo.Visible = False
            pRegistrarse.Visible = False
            pVerificaMail.Visible = True

        ElseIf Administrador.Checked = True Then

            tNombreU.Text = tNombreU.Text.Trim.ToUpper
            If Comprobar(tNombreU.Text) = False Then
                ArreglarCampo(tNombreU)
                ok = False
                lENombreU.Text = "El nombre contenía caracteres inválidos, fueron quitados."
                lENombreU.Visible = True
            End If

            tApellidoU.Text = tApellidoU.Text.Trim.ToUpper
            If Comprobar(tApellidoU.Text) = False Then
                ArreglarCampo(tApellidoU)
                ok = False
                lEApellidoU.Text = "El apellido contenía caracteres inválidos, fueron quitados."
                lEApellidoU.Visible = True
            End If

            tDocU.Text = tDocU.Text.Trim
            If Comprobar(tDocU.Text) = False Or Not IsNumeric(tDocU.Text) Then
                SoloNumeros(tDocU)
                ok = False
                lEDocU.Text = "El documento no era válido, se ajustó a número."
                lEDocU.Visible = True
            End If

            ArreglarCampo(tEmailU)
            If ValidateEmail(tEmailU.Text) = False Then
                ok = False
                lEEmailU.Text = "El email no es válido."
                lEEmailU.Visible = True
            End If

            tLocalidadU.Text = tLocalidadU.Text.Trim().ToUpper
            If Comprobar(tLocalidadU.Text) = False Then
                ArreglarCampo(tLocalidadU)
                ok = False
                lELocalidadU.Text = "La localidad contenia caracteres inválidos, fueron quitados"
                lELocalidadU.Visible = True
            End If

            tDireccionU.Text = tDireccionU.Text.Trim().ToUpper
            If Comprobar(tDireccionU.Text) = False Then
                ArreglarCampo(tDireccionU)
                ok = False
                lEDireccionU.Text = "La dirección contenia caracteres inválidos, fueron quitados"
                lEDireccionU.Visible = True
            End If

            tTelefonosU.Text = tTelefonosU.Text.Trim().ToUpper
            If Comprobar(tTelefonosU.Text) = False Then
                ArreglarCampo(tTelefonosU)
                ok = False
                lETelefonosU.Text = "El teléfono contenia caracteres inválidos, fueron quitados"
                lETelefonosU.Visible = True
            End If

            Dim FechaNacimiento As Date
            ControlDeNacimiento(tF_Nac, ok, lEFNac, lEdad, True, FechaNacimiento)

            tUrsuarioU.Text = tUrsuarioU.Text.Trim().ToUpper
            If Comprobar(tUrsuarioU.Text) = False Or tUrsuarioU.Text.IndexOf(" ") > -1 Then
                tUrsuarioU.Text = tUrsuarioU.Text.Replace(" ", "")
                ArreglarCampo(tUrsuarioU)
                ok = False
                lEUsuarioU.Text = "El usuario contenía caracteres inválidos, fueron quitados."
                lEUsuarioU.Visible = True
            End If
            If tUrsuarioU.Text.Length < 5 Then
                ok = False
                lEUsuarioU.Text = "El usuario debe tener de 5 a 10 caracteres, letras y/o números"
                lEUsuarioU.Visible = True
            End If

            tPassU.Text = tPassU.Text.Trim()
            If Comprobar(tPassU.Text) = False Or tPassU.Text.IndexOf(" ") > -1 Then
                tPassU.Text = tPassU.Text.Replace(" ", "")
                ArreglarCampo(tPassU)
                ok = False
                lEPassU.Text = "La clave contenía caracteres inválidos, fueron quitados."
                lEPassU.Visible = True
            End If
            If tPassU.Text.Length < 5 Then
                ok = False
                lEPassU.Text = "La clave debe tener de 5 a 10 caracteres, letras y/o números."
                lEPassU.Visible = True
            End If
            tPass2U.Text = tPass2U.Text.Trim()
            If Comprobar(tPass2U.Text) = False Or tPass2U.Text.IndexOf(" ") > -1 Then
                tPass2U.Text = tPassU.Text.Replace(" ", "")
                ArreglarCampo(tPassU)
                ok = False
                lEPass2U.Text = "La segunda clave contenía caracteres inválidos, fueron quitados."
                lEPass2U.Visible = True
            End If
            If tPass2U.Text.Length < 5 Then
                ok = False
                lEPass2U.Text = "La segunda clave debe tener de 5 a 10 caracteres, letras y/o números."
                lEPass2U.Visible = True
            End If

            If ok = False Then
                lErroresU.Text = "Revise los errores por favor y luego reintente."
                lErroresU.Visible = True
                Exit Sub
            End If
            If tPass2U.Text <> tPassU.Text Then
                ok = False
                tPass2U.Text = "Las 2 claves son diferentes."
                tPass2U.Visible = True
            End If

            Session("Usuario") = tUrsuarioU.Text
            Session("Password") = tPassU.Text
            Session("Mail") = tEmailU.Text
            Session("TipoDocumento") = dTDocU.SelectedValue.Trim
            Session("Documento") = tDocU.Text.Trim
            If YaExisteSQL("select idAdmin from Administradores where Usuario='" & Session("Usuario") & "'") Then
                ok = False
                lEUsuarioU.Text = "El usuario elegido ya existe. Pruebe con otro"
                lEUsuarioU.Visible = True
            End If

            If YaExisteSQL("select idAdmin from Administradores where Doc='" & Session("Documento") & "' and tDoc='" & Session("TipoDocumento") & "'") Then
                ok = False
                lEDocU.Text = "Ya existe el " & Session("TipoDocumento") & " " & Session("Documento") & "."
                lEDocU.Visible = True
            End If

            If YaExisteSQL("select idAdmin from Administradores where email='" & Session("Mail") & "'") Then
                ok = False
                lEEmailU.Text = "Ya se utilizo este email. Pruebe con otro"
                lEEmailU.Visible = True
            End If

            If ok = False Then
                lErroresU.Text = "Solo se permite una inscripción por persona."
                lErroresU.Visible = True
                Exit Sub
            End If

            Session("Usuario") = tUrsuarioU.Text.ToLower
            Session("Password") = tPassU.Text
            Session("TipoDocumento") = dTDocU.SelectedValue.Trim
            Session("Documento") = tDocU.Text.Trim
            Session("ApellidoYNombre") = tNombreU.Text.Trim & " " & tApellidoU.Text.Trim
            Session("Email") = tEmailU.Text.Trim

            LimpiarErroresRegistroU()

            Session("sqlIngreso") = "insert into Administradores (Apellido,Nombre,tDoc,Doc,Usuario,Pass,Email,idProv,Localidad,Direccion,Telefonos,fNacimiento) values('" & tApellidoU.Text.Trim & "','" & tNombreU.Text.Trim & "','" & Session("TipoDocumento") & "','" & Session("Documento") & "','" & Session("Usuario") & "','" & Session("Password") & "','" & Session("Email") & "','" & didProvU.SelectedValue & "','" & tLocalidadU.Text.Trim & "','" & tDireccionU.Text.Trim & "','" & tTelefonosU.Text.Trim & "','" & FechaNacimiento.ToString("yyyy-MM-dd") & "')"

            Dim codigo As String = CrearCodigo(4)
            Session("codigo") = codigo
            Dim en As String = Chr(13) & Chr(10), mensaje As String = "Saludos " & Session("ApellidoYNombre") & "." & en & en & "Te escribimos desde Helados Fernando, en respuesta a tu solicitud de registro " & "como nuevo usuario de nuestra aplicación." & en & en & "Por favor ingresá el código: " & codigo & " en el cuadro de texto de " & "la aplicacon web, y presioná Validar. Esto completará tu registro " & "Como nuevo administrador de Helados Fernando" & en & en & "Felicitaciones" & en & "El equipo de Helados Fernando" & en & en & en & en & "(Por favor, no responda a éste mail, es automático...muchas gracias!)" & en & en

            Dim ok2 As String = EnviarMail(Session("Email"), "Helados Fernando - Registro como Administrador", mensaje)
            tValidar.Text = ""
            lCodigo.Visible = False
            pRegistrarse.Visible = False
            pVerificaMail.Visible = True

        End If


    End Sub

    Protected Sub bRegistrarseU0_Click(sender As Object, e As ImageClickEventArgs) Handles bRegistrarseU0.Click
        pLoginMenu.Visible = True
        pRegistrarse.Visible = False
    End Sub

    Protected Sub bRegok_Click(sender As Object, e As ImageClickEventArgs) Handles bRegok.Click
        pBienvenido.Visible = False
        pLogin.Visible = True
    End Sub
    Sub ArreglarCampo(ByRef campo As TextBox)
        campo.Text = campo.Text.Trim.Replace(" '", "").Replace("""", "").Replace("*", "").Replace("+", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace("`", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace("&", "")
    End Sub

    Function Comprobar(ByVal user As String) As Boolean
        If user Is System.DBNull.Value Then
            Return False
        Else
            Dim aux As Boolean = True
            Dim listanegra, x As String
            listanegra = "'*+-/:;´><&" & """"
            If user <> "" Then
                For Each x In user
                    If aux = True Then
                        If InStr(1, listanegra, x) > 0 Then
                            aux = False
                        Else
                            aux = True
                        End If
                    Else
                        Return False
                    End If
                Next
                If aux = True Then
                    Return True
                End If
            Else
                Return False
            End If
        End If
    End Function

    Sub LimpiarErroresRegistroU()
        lErroresU.Text = ""
        lErroresU.Visible = False
        lEFNac.Visible = False
        lEFNac.Text = ""
        lENombreU.Text = ""
        lEApellidoU.Text = ""
        lEDocU.Text = ""
        lEEmailU.Text = ""
        lELocalidadU.Text = ""
        lEDireccionU.Text = ""
        lETelefonosU.Text = ""
        lEUsuarioU.Text = ""
        lEPassU.Text = ""
        lEPass2U.Text = ""
        lENombreU.Visible = False
        lEApellidoU.Visible = False
        lEDocU.Visible = False
        lEEmailU.Visible = False
        lELocalidadU.Visible = False
        lEDireccionU.Visible = False
        lETelefonosU.Visible = False
        lEUsuarioU.Visible = False
        lEPassU.Visible = False
        lEPass2U.Visible = False
    End Sub

    Sub LimpiarRegistroU()
        LimpiarErroresRegistroU()
        pRegistrarse.Visible = False

        lEFNac.Text = ""
        lENombreU.Text = ""
        lEApellidoU.Text = ""
        dTDocU.SelectedIndex = 0
        lEDocU.Text = ""
        lEEmailU.Text = ""
        didProvU.SelectedIndex = 0
        lELocalidadU.Text = ""
        lEDireccionU.Text = ""
        lETelefonosU.Text = ""
        lEUsuarioU.Text = ""
        lEPassU.Text = ""
        lEPass2U.Text = ""
    End Sub

    Public Function ValidateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)
        Return emailMatch.Success
    End Function

    Sub SoloNumeros(ByRef campo As TextBox)
        Dim cam As String = campo.Text.Trim, salida As String = "", c As String
        For Each c In salida
            If IsNumeric(c) Then salida &= c
        Next
        campo.Text = salida
    End Sub

    Function VNum(ByVal NTexto As String) As Decimal
        Return CDec(Val(NTexto.Trim.Replace(",", ".")))
    End Function

    Function NumSQL(ByVal numero As String) As String
        Return CStr(VNum(numero)).Trim.Replace(",", ".")
    End Function

    Function RellenaNum(ByVal numero As Integer, ByVal cantidad As Integer) As String
        Dim snum As String = CStr(numero).Trim
        Return "00000000000000000000".Substring(0, cantidad - snum.Length) & snum
    End Function

    Function FechaSQL(ByVal fecha As Date) As String
        Return "'" & RellenaNum(Year(fecha), 4) & RellenaNum(Month(fecha), 2) & RellenaNum(fecha.Day, 2) & "'"
    End Function

    Public Function Vstr(ByVal cosa As Object) As String
        If IsDBNull(cosa) Then Return "" Else Return CStr(cosa)
    End Function

    Function CalcularEdad(ByVal FechaNac As Date) As Integer
        Dim edad As Integer = DateTime.Today.AddTicks(-FechaNac.Ticks).Year - 1
        Return edad
    End Function

    Sub ControlDeNacimiento(ByRef xtF_nac As TextBox, ByRef ok As Boolean, ByRef xlEFNac As Label, ByRef xlEdad As Label, ByVal Valida18 As Boolean, ByRef FechaNacimiento As Date)
        ArreglarCampo(xtF_nac)
        xlEFNac.Visible = False
        If xtF_nac.Text.Length < 6 Then
            ok = False
            xlEFNac.Text &= "El campo fecha de nacimiento debe tener 6 números"
            xlEdad.Text = "0"
            xlEFNac.Visible = True
        Else
            Dim FechaX As String = xtF_nac.Text
            Dim AñoX As Integer = VNum(FechaX.Substring(4, 2))
            If AñoX + 2000 > Date.Today.Year Then AñoX += 1900 Else AñoX += 2000
            FechaX = AñoX.ToString.Trim & "-" & FechaX.Substring(2, 2) & "-" & FechaX.Substring(0, 2)
            If Not IsDate(FechaX) Then
                ok = False
                xlEFNac.Text &= "El campo fecha de nacimiento, es una fecha inválida"
                xlEdad.Text = "0"
                xlEFNac.Visible = True
            Else
                Dim dFechax As Date
                dFechax = CDate(FechaX)
                FechaNacimiento = dFechax
                If dFechax > Date.Today Then
                    ok = False
                    xlEFNac.Text &= "Nació en el futuro...."
                    xlEdad.Text = "0"
                    xlEFNac.Visible = True
                Else
                    Dim Edad As Integer = CalcularEdad(dFechax)
                    xlEdad.Text = Edad

                    If Edad < 18 And Valida18 Then
                        ok = False
                        xlEFNac.Text &= "Debe ser mayor de edad (18 años)"
                        xlEdad.Text = "0"
                        xlEFNac.Visible = True
                    End If
                End If
            End If
        End If
    End Sub

    Public Function SQL_Accion(ByVal Sql_de_accion As String) As Boolean

        Dim adapter As New SqlDataAdapter, salida As Boolean = True
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            If Sql_de_accion.ToUpper.IndexOf("INSERT") Then
                adapter.InsertCommand = New SqlCommand(Sql_de_accion, con)
                adapter.InsertCommand.ExecuteNonQuery()
            Else
                If Sql_de_accion.ToUpper.IndexOf("UPDATE") Then
                    adapter.UpdateCommand = New SqlCommand(Sql_de_accion, con)
                    adapter.UpdateCommand.ExecuteNonQuery()
                Else
                    If Sql_de_accion.ToUpper.IndexOf("DELETE") Then
                        adapter.DeleteCommand = New SqlCommand(Sql_de_accion, con)
                        adapter.DeleteCommand.ExecuteNonQuery()
                    Else
                        salida = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            salida = False
        End Try
        Return salida

    End Function

    Function LeeUnCampo(ByVal sql As String, ByVal campo As String) As Object

        Dim da1 As New SqlDataAdapter(sql, con)
        Dim ds1 As New DataSet
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            da1.Fill(ds1, "datos")
            If ds1.Tables("datos").Rows.Count < 1 Then
                Return "**NADA**"
            Else
                Return ds1.Tables("datos").Rows(0)(campo)
            End If
        Catch
            Return "**ERROR**"
        End Try

    End Function

    Public Function YaExisteSQL(ByVal sql As String) As Boolean
        Dim con As New SqlConnection(connectionString)
        Dim da1 As New SqlDataAdapter(sql, con)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "afidesc")
        If ds1.Tables("afidesc").Rows.Count < 1 Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub Loguea()
        Dim usu As String = tUsuario.Text.Trim.ToUpper, pass As String = tClave.Text
        If Comprobar(tUsuario.Text.Trim) = False Or Comprobar(tClave.Text.Trim) = False Then
            lErrorLogin.Text = "El usuario o la clave son incorrectos. Revise por favor"
            lErrorLogin.Text = True
            Exit Sub
        End If

        Dim da1 As New SqlDataAdapter("select * from " & Session("QueEs") & " where upper(ltrim(rtrim(usuario)))= '" & usu & "' and ltrim(rtrim(pass))='" & pass & "'", con)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "Login")
        If ds1.Tables("Login").Rows.Count = 0 Then

            lErrorLogin.Text = "El usuario o la clave son incorrectos. Revise por favor"
            lErrorLogin.Text = True
            Exit Sub
        End If

        Select Case Session("QueEs")
            Case "Usuarios"
                Session("idUsuario") = ds1.Tables("Login").Rows(0)("idUsuario")
                Session("Usuario") = usu
                Session("Password") = pass
                Session("TipoDocumento") = ds1.Tables("Login").Rows(0)("tDoc")
                Session("Documento") = ds1.Tables("Login").Rows(0)("Doc").ToString.Trim
                Session("ApellidoYNombre") = ds1.Tables("Login").Rows(0)("Nombre").ToString.Trim & ds1.Tables("Login").Rows(0)("Apellido").ToString.Trim
                Session("Email") = ds1.Tables("Login").Rows(0)("Email").ToString.Trim
                Session("idprov") = ds1.Tables("Login").Rows(0)("idprov").ToString.Trim
                Session("Localidad") = ds1.Tables("Login").Rows(0)("Localidad").ToString.Trim
                Session("Direccion") = ds1.Tables("Login").Rows(0)("Direccion").ToString.Trim
                Session("Telefonos") = ds1.Tables("Login").Rows(0)("Telefonos").ToString.Trim
                If SQL_Accion("Select Bloqueo from Usuarios") = 1 Then
                    lErrorLogin.Visible = True
                    lErrorLogin.Text = "El usuario esta bloqueado"
                End If
                lBienvenidoAreaU.Text = "Bienvenido " & Session("ApellidoYNombre") & ", a tu Área de Usuario."
                LimpiarRegistroU()
                pLogin.Visible = False
                pAreaUsuario.Visible = True

            Case "Administradores"

                Session("idAdmin") = ds1.Tables("Login").Rows(0)("idAdmin")
                Session("Usuario") = usu
                Session("Password") = pass
                Session("TipoDocumento") = ds1.Tables("Login").Rows(0)("tDoc")
                Session("Documento") = ds1.Tables("Login").Rows(0)("Doc").ToString.Trim
                Session("ApellidoYNombre") = ds1.Tables("Login").Rows(0)("Nombre").ToString.Trim & ds1.Tables("Login").Rows(0)("Apellido").ToString.Trim
                Session("Email") = ds1.Tables("Login").Rows(0)("Email").ToString.Trim
                Session("idprov") = ds1.Tables("Login").Rows(0)("idprov").ToString.Trim
                Session("Localidad") = ds1.Tables("Login").Rows(0)("Localidad").ToString.Trim
                Session("Direccion") = ds1.Tables("Login").Rows(0)("Direccion").ToString.Trim
                Session("Telefonos") = ds1.Tables("Login").Rows(0)("Telefonos").ToString.Trim
                If SQL_Accion("Select Bloqueo from Administrador") = 1 Then
                    lErrorLogin.Visible = True
                    lErrorLogin.Text = "El usuario esta bloqueado"
                End If
                lBienvenidoAreaU.Text = "Bienvenido " & Session("ApellidoYNombre") & ", a tu Área de Administrador."
                LimpiarRegistroU()
                pLogin.Visible = False
                pAreaAdmin.Visible = True

        End Select
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Session("QueEs") = "Usuarios"
        Loguea()
    End Sub

    Protected Sub bAdministrador_Click(sender As Object, e As ImageClickEventArgs) Handles bAdministrador.Click
        Session("QueEs") = "Administradores"
        Loguea()
    End Sub

    Protected Sub bEntrar_Click(sender As Object, e As ImageClickEventArgs) Handles bEntrar.Click
        pLoginMenu.Visible = False
        pLogin.Visible = True
    End Sub

    Protected Sub bAhoraQueHago_Click(sender As Object, e As ImageClickEventArgs) Handles bAhoraQueHago.Click
        pAreaUsuario.Visible = False
        pAhoraQueHago.Visible = True
    End Sub

    Sub LimpiarLogin()
        lErrorLogin.Text = ""
        lErrorLogin.Visible = False
        tUsuario.Text = ""
        tClave.Text = ""
        pRegistrarse.Visible = False
    End Sub

    Protected Sub bVolverLoginU1_Click(sender As Object, e As ImageClickEventArgs) Handles bVolverLoginU1.Click
        LimpiarLogin()
        LimpiarRegistroU()
        lReenviarClave.Text = ""
        pLogin.Visible = True
        pAreaUsuario.Visible = False
        tUsuario.Text = Session("Usuario")
        tClave.Text = Session("Password")
    End Sub

    Protected Sub bVolverLoginU2_Click(sender As Object, e As ImageClickEventArgs) Handles bVolverLoginU2.Click
        pAhoraQueHago.Visible = False
        pAreaUsuario.Visible = True
    End Sub

    Protected Sub bPedidosFabrica_Click(sender As Object, e As ImageClickEventArgs) Handles bPedidosFabrica.Click
        pAreaUsuario.Visible = False
        pPedidos.Visible = True
    End Sub


    Sub CargarHelados()
        Dim x As Integer = 0, cosa As String
        Dim da2 As New SqlDataAdapter("select * from web_helados order by gusto", con)
        Dim ds2 As New DataSet
        dHelados.Items.Clear()
        da2.Fill(ds2, "dato")
        If ds2.Tables("dato").Rows.Count = 0 Then
            dHelados.Items.Add("*** No hay Helados disponibles en este momento... ***")
            Exit Sub
        End If
        For x = 0 To ds2.Tables("dato").Rows.Count - 1
            cosa = ds2.Tables("dato").Rows(x)("gusto").ToString.Trim

            dHelados.Items.Add(cosa)
        Next
        dHelados.SelectedIndex = 0
        lCosaAgregar.Text = dHelados.SelectedItem.ToString
        lQueEs.Text = "Helado"
    End Sub

    Sub CargaTemporal()

        Dim idU As Integer = VNum(Session("idUsuario"))
        Dim consulta As String = "select item, cantidad from web_pedidos_temporal where num_cli =" & Session("idUsuario") & "order by item"
        Dim da1 As New SqlDataAdapter(consulta, con)

        Dim ds1 As New DataSet
        da1.Fill(ds1, "histo")
        gListaPedido.DataSource = ds1.Tables("histo")
        gListaPedido.DataBind()
        If ds1.Tables("histo").Rows.Count = 0 Then
            lErrorHistorico.Text = ""
            gListaPedido.Visible = False
            bSolicitarPedido.Visible = False
            bQuitarTodos.Visible = False
            Label9.Visible = False
        Else
            gListaPedido.Visible = True
            bSolicitarPedido.Visible = True
            bQuitarTodos.Visible = True
            Label9.Visible = True
        End If
    End Sub

    Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        pAreaUsuario.Visible = True
        pPedidos.Visible = False
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        Dim en As String = "</br>"
        lInstrucciones.Text = "INSTRUCCIONES:" & en & en & "1) Elija el Helado que desea solicitar a la fábrica." & ", se verá el elegido en 'Agregar:'." & en & "2) Indique la cantidad de latas de helado." & en & "3) Oprima el boton 'Agregar a la lista'. El item elegido y la cantidad se verán en la lista inferior." & "Si quiere sacar algún item (lo quita completo, " & "solo presione sobre el item en la lista para seleccionarlo y oprima 'Quitar'." & "Si agrega un item que ya estaba en la lista, se suman las cantidades." & en & "4) Cuando haya terminado oprima 'Enviar el Pedido'." & "Todos los items figurarán como 'Solicitado', y desde 'Revisar estado de los Pedidos', " & "podrá ver si cambiaron a 'Despachado' o 'Enviado'." & "Desde alli podrá anular los pedidos que aún estén en 'Solicidato'."
        lInstrucciones.Visible = False
        bInstrucciones.Text = "Abrir Instrucciones"

        pPedidos.Visible = False
        lCosaAgregar.Text = ""
        CargarHelados()

        bQuitarTodos.Visible = False
        bSolicitarPedido.Visible = False
        lErrorPedido.Text = ""
        If IsNothing(Session("idUsuario")) Then
            pLogin.Visible = True
            Exit Sub
        End If
        SQL_Accion("delete web_pedidos_temporal where num_cli=" & Session("idUsuario"))
        CargaTemporal()
        pNuevoPedido.Visible = True
    End Sub

    Protected Sub bCancelarPedido_Click(sender As Object, e As ImageClickEventArgs) Handles bCancelarPedido.Click
        If SQL_Accion("delete web_pedidos_temporal where num_cli=" & VNum(Session("idUsuario"))) = False Then

        End If
        pNuevoPedido.Visible = False
        pPedidos.Visible = True
    End Sub

    Protected Sub bInstrucciones_Click(sender As Object, e As EventArgs) Handles bInstrucciones.Click
        If bInstrucciones.Text = "Abrir Instrucciones" Then
            bInstrucciones.Text = "Cerrar Instrucciones"
            lInstrucciones.Visible = True
        Else
            bInstrucciones.Text = "Abrir Instrucciones"
            lInstrucciones.Visible = False
        End If
    End Sub

    Protected Sub dHelados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dHelados.SelectedIndexChanged
        lCosaAgregar.Text = dHelados.SelectedItem.ToString
        lQueEs.Text = "Helado"
    End Sub

    Protected Sub bAgregarALista_Click(sender As Object, e As ImageClickEventArgs) Handles bAgregarALista.Click
        Dim x As Integer = 0, c As String, numero As Integer = 0
        Dim Cosa As String = lCosaAgregar.Text.Trim
        If Cosa = "---------------" Then Exit Sub

        Dim Cantidad As Integer = VNum(tCantLatas.SelectedValue.ToString)

        If Cantidad <= 0 Then Exit Sub
        lErrorPedido.Text = ""

        Dim da2 As New SqlDataAdapter("select cantidad from web_pedidos_temporal where num_cli=" & Session("idUsuario") & " and ltrim(rtrim(item))='" & Cosa & "'", con)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "dato")
        If ds2.Tables("dato").Rows.Count > 0 Then
            Cantidad += VNum(ds2.Tables("dato").Rows(0)("cantidad"))
            If SQL_Accion("update web_pedidos_temporal set cantidad=" & Cantidad & " where num_cli=" & Session("idUsuario") & " and ltrim(rtrim(item))='" & Cosa & "'") = False Then
                lErrorPedido.Text = "No puedo modificar el item elegido. Intente más tarde."
                Exit Sub
            End If

        Else

            If SQL_Accion("insert into web_pedidos_temporal (num_cli, item, cantidad) values (" & Session("idUsuario") & ", '" & Cosa & "', " & Cantidad & ")") = False Then
                lErrorPedido.Text = "No puedo agregar el item a la lista. Intente más tarde"
                Exit Sub
            End If
        End If
        tCantLatas.SelectedIndex = 0
        CargaTemporal()
    End Sub

    Protected Sub gListaPedido_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gListaPedido.RowCommand

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gListaPedido.Rows(index)
        Dim item As String = row.Cells(1).Text, en As String = Chr(13) & Chr(10)
        Dim consulta As String = "delete web_pedidos_temporal where ltrim(rtrim(item))='" & item & "' and num_cli=" & VNum(Session("idUsuario"))

        lErrorPedido.Text = ""
        If (e.CommandName = "Quitar") Then
            If SQL_Accion(consulta) = False Then
                lErrorPedido.Text = "No puedo quitar el item de la lista. Intente más tarde"
                Exit Sub
            End If
            CargaTemporal()
        End If
    End Sub

    Protected Sub bQuitarTodos_Click(sender As Object, e As ImageClickEventArgs) Handles bQuitarTodos.Click
        If SQL_Accion("delete web_pedidos_temporal where num_cli=" & VNum(Session("idUsuario"))) = False Then
            lErrorPedido.Text = "No puedo quitar a todos los items de la lista. Intente más tarde."
            Exit Sub
        End If
        CargaTemporal()
    End Sub

    Protected Sub bNuevaConsulta_Click(sender As Object, e As ImageClickEventArgs) Handles bNuevaConsulta.Click

        Dim ok As Boolean = True

        tGusto.Text = tGusto.Text.Trim.ToUpper
        If Comprobar(tGusto.Text) = False Then
            ArreglarCampo(tGusto)
            ok = False
            lEGusto.Text = "El gusto contenía caracteres inválidos, fueron quitados."
            lEGusto.Visible = True
        End If

        tPrecio.Text = tPrecio.Text.Trim.ToUpper
        If Not IsNumeric(tPrecio.Text) Then
            ok = False
            lEPrecio.Text = "El precio no es valido, intente de nuevo."
            lEPrecio.Visible = True
        End If

        tStock.Text = tStock.Text.Trim.ToUpper
        If Not IsNumeric(tStock.Text) Then
            ok = False
            lEStock.Text = "El valor de stock no es valido, intente de nuevo."
            lEStock.Visible = True
        End If

        LimpiarErroresRegistroU()

        If SQL_Accion("insert into Web_Helados (Gusto,Precio,Stock) values('" & tGusto.Text.Trim & "','" & tPrecio.Text.Trim & "','" & tStock.Text.Trim & "')") = False Then
            lEConsulta.Text = "Se ha producido un error al querer guardar tus datos..."
            lEConsulta.Visible = True
            Exit Sub
        ElseIf SQL_Accion("insert into Web_Helados (Gusto,Precio,Stock) values('" & tGusto.Text.Trim & "','" & tPrecio.Text.Trim & "','" & tStock.Text.Trim & "')") = True Then
            lConsultaExistosa.Text = "Se ha cargado el gusto correctamente."
            lConsultaExistosa.Visible = True
        End If

    End Sub

    Protected Sub bVolverLoginA_Click(sender As Object, e As ImageClickEventArgs) Handles bVolverLoginA.Click
        LimpiarLogin()
        LimpiarRegistroU()
        lReenviarClave.Text = ""
        pLogin.Visible = True
        pAreaAdmin.Visible = False
        tUsuario.Text = Session("Usuario")
        tClave.Text = Session("Password")
    End Sub

    Protected Sub bAltaAdmin_Click(sender As Object, e As ImageClickEventArgs) Handles bAltaAdmin.Click
        pNuevaConsulta.Visible = True
        pAreaAdmin.Visible = False
    End Sub

    Protected Sub bCancelarConsulta_Click(sender As Object, e As ImageClickEventArgs) Handles bCancelarConsulta.Click
        pNuevaConsulta.Visible = False
        pAreaAdmin.Visible = True
    End Sub

    Protected Sub bSolicitarPedido_Click(sender As Object, e As ImageClickEventArgs) Handles bSolicitarPedido.Click
        Dim idU As Integer = VNum(Session("idUsuario"))
        Dim npedido As Integer = 0, vItem As String = "", vTipo As String = "", vCantidad As Integer = 0, cosa As String
        Dim linea As String = "", en As String = Chr(13) & Chr(10)
        lErrorPedido.Text = ""
        If SQL_Accion("insert into web_pedidos (num_cli) values(" & Session("idUsuario") & ")") = True Then
            Dim da1 As New SqlDataAdapter("select top 1 npedido from web_pedidos where num_cli=" & Session("idUsuario") & " order by npedido desc", con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "dato")
            If ds1.Tables("dato").Rows.Count > 0 Then
                npedido = ds1.Tables("dato").Rows(0)("npedido")
                If SQL_Accion("INSERT INTO WEB_Pedidos_detalle ( item, cantidad, NPedido ) " & "SELECT WEB_Pedidos_Temporal.item, WEB_Pedidos_Temporal.Cantidad," & npedido & "AS Npedido FROM WEB_Pedidos_Temporal where num_cli=" & idU) = True Then
                    lPedidoCreado.Text = "El pedido N°" & npedido & ", fue creado correctamente."
                    pNuevoPedido.Visible = False
                    pPedidoCreado.Visible = True
                    If SQL_Accion("delete web_pedidos_temporal where num_cli=" & idU) = False Then
                    End If
                Else
                    lErrorPedido.Text = "Hubo un error al intentar guardar el detalle del pedido " & npedido & ", que quedó vacío o con carga parcial. Anúlelo e Intente más tarde"
                    Exit Sub
                End If
                Exit Sub
            Else
                lErrorPedido.Text = "Hubo un error al intentar guardar el detalle del pedido " & npedido & ", que quedó vacío o con carga parcial. Anúlelo e Intente más tarde"
                Exit Sub
            End If
        Else
            lErrorPedido.Text = "Hubo un error al intentar guardar el pedido. Intente más tarde"
        End If

        Dim da2 As New SqlDataAdapter("select ltrim(rtrim(nombre)) + ' ' + ltrim(rtrim(apellido)) as usuario,  pass," & " email from Usuarios where upper(ltrim(rtrim(Usuario)))='" & Session("Usuario") & "'", con)
        Dim ds2 As New DataSet
        Dim xusuario As String, pass As String, mensaje As String, email As String
        da2.Fill(ds2, "Login")
        email = ds2.Tables("Login").Rows(0)("Email").ToString.Trim.ToLower
        pass = ds2.Tables("Login").Rows(0)("pass").ToString.Trim.ToLower
        xusuario = ds2.Tables("Login").Rows(0)("usuario").ToString.Trim

        mensaje = "Hola " & xusuario & en & en & "Tu pedido ha sido solicitado correctamente0" & en & en & "(Por favor no respondas a este mail, es automático....gracias!)" & en & en

        Dim EmailOK As String = EnviarMail(Email, "Pedido - Helados Fernando", mensaje)

    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        CargarHistorico()
    End Sub

    Sub CargarHistorico()
        lErrorHistorico.Text = ""
        Dim idU As Integer = VNum(Session("idUsuario"))
        Dim da1 As New SqlDataAdapter("select Npedido, fecha,estado from web_pedidos where num_cli=" & idU & " and estado <> 'Enviado' order by npedido desc", con)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "histo")
        gHistorico.DataSource = ds1.Tables("histo")
        gHistorico.DataBind()
        If ds1.Tables("histo").Rows.Count = 0 Then
            lErrorHistorico.Text = "No hay pedidos anteriores o hubo un error al cargarlos. Reintente más tarde"
            gHistorico.Visible = False
        Else
            gHistorico.Visible = True
        End If

        pPedidos.Visible = False
        pHistorico.Visible = True
    End Sub

    Protected Sub gHistorico_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gHistorico.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gHistorico.Rows(index)
        Dim Npedido As Integer = VNum(row.Cells(2).Text), en As String = Chr(13) & Chr(10)

        If (e.CommandName = "Ver") Then
            Label10.Text = "Detalle del Pedido N° " & Npedido

            lErrorVerUnPedido.Text = ""
            Dim da1 As New SqlDataAdapter("SELECT web_pedidos_detalle.item, " & "web_pedidos_detalle.Cantidad FROM web_pedidos_detalle INNER JOIN WEB_Helados ON " & "web_pedidos_detalle.item = WEB_Helados.GUSTO WHERE web_pedidos_detalle.NPedido=" & Npedido & " ORDER BY WEB_Helados.CODH", con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "histo")
            gVerUnPedido.DataSource = ds1.Tables("histo")
            gVerUnPedido.DataBind()
            If ds1.Tables("histo").Rows.Count = 0 Then
                lErrorHistorico.Text = "Hubo un error al cargar los items del pedido " & Npedido & ", porque no se leyó ninguno. Reintente más tarde"
                gVerUnPedido.Visible = False
            Else
                gVerUnPedido.Visible = True
            End If
            pHistorico.Visible = False
            pVerUnPedido.Visible = True

        End If

        If (e.CommandName = "Anular") Then
            lErrorHistorico.Text = ""
            Dim da1 As New SqlDataAdapter("select estado from web_pedidos where npedido=" & Npedido, con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "histo")
            If ds1.Tables("histo").Rows.Count = 0 Then
                lErrorHistorico.Text = "No puedo acceder al pedido N° " & Npedido & ". Reintente más tarde."
                Exit Sub
            Else
                Dim Estado As String = ds1.Tables("histo")(0)("estado").ToString.Trim
                If Estado <> "Solicitado" Then
                    lErrorHistorico.Text = "El pedido tiene Estado = '" & Estado & "' y ya no puede cancelarse por web (solo 'Solicitado'). Llame a la fábrica " & "por favor."
                    Exit Sub
                Else
                    If Estado = "Anulado" Then
                        lErrorHistorico.Text = "El pedido tiene Estado = '" & Estado & "' y ya no puede cancelarse por web (solo 'Solicitado'). Llame a la fábrica " & "por favor."
                        Exit Sub
                    End If
                    lErrorHistorico.Text = ""
                    If SQL_Accion("update web_pedidos set estado = 'Anulado' where npedido= " & Npedido) = False Then
                        lErrorHistorico.Text = "No he podido cambiar el estado hubo algún " & "error de conexión. Por favor, reintente más tarde o llame a la " & "fábrica para avisar de la anulación"
                        Exit Sub
                    Else
                        lPedidoAnulado.text = "El´pedido N° " & Npedido & ", fue ANULADO "
                        pHistorico.Visible = False
                        pPedidoAnulado.visible = True
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub ImageButton7_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton7.Click
        CargarHistorico()
        pPedidoAnulado.Visible = False
        pHistorico.Visible = True
    End Sub

    Protected Sub ImageButton6_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton6.Click
        pPedidoCreado.Visible = False
        pPedidos.Visible = True
    End Sub

    Protected Sub ImageButton8_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton8.Click
        CargarHistorico()
    End Sub

    Protected Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        pVerUnPedido.Visible = False
        pHistorico.Visible = True
    End Sub

    Protected Sub bTerminarHistorico_Click(sender As Object, e As ImageClickEventArgs) Handles bTerminarHistorico.Click
        pHistorico.Visible = False
        pPedidos.Visible = True
    End Sub

    Sub CargarHistoricoA()
        lErrorHistoricoA.Text = ""
        Dim da1 As New SqlDataAdapter("select * from web_pedidos where estado <> 'Enviado' order by npedido desc", con)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "histo")
        gHistoricoA.DataSource = ds1.Tables("histo")
        gHistoricoA.DataBind()
        If ds1.Tables("histo").Rows.Count = 0 Then
            lErrorHistoricoA.Text = "No hay pedidos anteriores o hubo un error al cargarlos. Reintente más tarde"
            gHistoricoA.Visible = False
        Else
            gHistoricoA.Visible = True
        End If

        pAreaAdmin.Visible = False
        pHistoricoA.Visible = True
    End Sub

    Protected Sub bPedidosAdmin_Click(sender As Object, e As ImageClickEventArgs) Handles bPedidosAdmin.Click
        CargarHistoricoA()
    End Sub

    Protected Sub bTerminarPedidosA_Click(sender As Object, e As ImageClickEventArgs) Handles bTerminarPedidosA.Click
        pAreaAdmin.Visible = True
        pHistoricoA.Visible = False
    End Sub

    Protected Sub gHistoricoA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gHistoricoA.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gHistoricoA.Rows(index)
        Dim NpedidoA As Integer = VNum(row.Cells(3).Text), en As String = Chr(13) & Chr(10)

        If (e.CommandName = "Ver") Then
            lPedidoA.Text = "Detalle del Pedido N° " & NpedidoA

            lErrorVerUnPedidoA.Text = ""
            Dim da1 As New SqlDataAdapter("SELECT web_pedidos_detalle.NItem, web_pedidos_detalle.item, " & "web_pedidos_detalle.Cantidad FROM web_pedidos_detalle INNER JOIN WEB_Helados ON " & "web_pedidos_detalle.item = WEB_Helados.GUSTO WHERE web_pedidos_detalle.NPedido=" & NpedidoA & " ORDER BY WEB_Helados.CODH", con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "histo")
            gVerPedidoA.DataSource = ds1.Tables("histo")
            gVerPedidoA.DataBind()
            If ds1.Tables("histo").Rows.Count = 0 Then
                lErrorHistoricoA.Text = "Hubo un error al cargar los items del pedido " & NpedidoA & ", porque no se leyó ninguno. Reintente más tarde"
                gVerPedidoA.Visible = False
            Else
                gVerPedidoA.Visible = True
            End If
            pHistoricoA.Visible = False
            pVerPedidoA.Visible = True

        End If

        If (e.CommandName = "Anular") Then
            lErrorHistoricoA.Text = ""
            Dim da1 As New SqlDataAdapter("select estado from web_pedidos where npedido=" & NpedidoA, con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "histo")
            If ds1.Tables("histo").Rows.Count = 0 Then
                lErrorHistoricoA.Text = "No puedo acceder al pedido N° " & NpedidoA & ". Reintente más tarde."
                Exit Sub
            Else
                Dim Estado As String = ds1.Tables("histo")(0)("estado").ToString.Trim
                If Estado <> "Solicitado" Then
                    lErrorHistoricoA.Text = "El pedido tiene Estado = '" & Estado & "' y ya no puede cancelarse por web (solo 'Solicitado'). Llame a la fábrica " & "por favor."
                    Exit Sub
                Else
                    If Estado = "Anulado" Then
                        lErrorHistoricoA.Text = "El pedido tiene Estado = '" & Estado & "' y ya no puede cancelarse por web (solo 'Solicitado'). Llame a la fábrica " & "por favor."
                        Exit Sub
                    End If
                    lErrorHistoricoA.Text = ""
                    If SQL_Accion("update web_pedidos set estado = 'Anulado' where npedido= " & NpedidoA) = False Then
                        lErrorHistoricoA.Text = "No he podido cambiar el estado hubo algún " & "error de conexión. Por favor, reintente más tarde o llame a la " & "fábrica para avisar de la anulación"
                        Exit Sub
                    Else
                        lPedidoAnuladoA.Text = "El pedido N° " & NpedidoA & ", fue ANULADO "
                        pHistoricoA.Visible = False
                        pPedidoAnuladoA.Visible = True
                    End If
                End If
            End If
        End If

        If (e.CommandName = "Editar") Then
            lPedidoA.Text = "Detalle del Pedido N° " & NpedidoA

            lErrorVerUnPedidoA.Text = ""
            Dim da1 As New SqlDataAdapter("SELECT web_pedidos_detalle.NItem, web_pedidos_detalle.item, " & "web_pedidos_detalle.Cantidad FROM web_pedidos_detalle INNER JOIN WEB_Helados ON " & "web_pedidos_detalle.item = WEB_Helados.GUSTO WHERE web_pedidos_detalle.NPedido=" & NpedidoA & " ORDER BY WEB_Helados.CODH", con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "histo")
            gVerPedidoA.DataSource = ds1.Tables("histo")
            gVerPedidoA.DataBind()
            If ds1.Tables("histo").Rows.Count = 0 Then
                lErrorHistoricoA.Text = "Hubo un error al cargar los items del pedido " & NpedidoA & ", porque no se leyó ninguno. Reintente más tarde"
                gVerPedidoA.Visible = False
            Else
                gVerPedidoA.Visible = True
            End If
            pHistoricoA.Visible = False
            pVerPedidoA.Visible = True

        End If
    End Sub


    Protected Sub gVerPedidoA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gVerPedidoA.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gVerPedidoA.Rows(index)
        Dim NItem As Integer = VNum(row.Cells(0).Text), en As String = Chr(13) & Chr(10)
        Dim usu As String = tUsuario.Text.Trim.ToUpper, email As String, xusuario As String, mensaje As String, pass As String


        If (e.CommandName = "Quitar") Then

            lErrorVerUnPedidoA.Text = ""
            Dim da1 As New SqlDataAdapter("delete from web_pedidos_detalle where NItem= " & NItem, con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "histo")
            gVerPedidoA.DataSource = ds1.Tables("histo")
            gVerPedidoA.DataBind()
            pHistoricoA.Visible = True
            pVerPedidoA.Visible = False

            Dim da2 As New SqlDataAdapter("select ltrim(rtrim(nombre)) + ' ' + ltrim(rtrim(apellido)) as usuario,  pass," & " email from Usuarios where upper(ltrim(rtrim(Usuario)))='" & usu & "'", con)
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Login")

            Email = ds2.Tables("Login").Rows(0)("Email").ToString.Trim.ToLower
            pass = ds2.Tables("Login").Rows(0)("pass").ToString.Trim.ToLower
            xusuario = ds2.Tables("Login").Rows(0)("usuario").ToString.Trim

            mensaje = "Hola " & xusuario & "." & en & en & "Le escribimos desde Helados Fernando, avisandole de que quitamos el item " & NItem & " de su pedido" & en & en & en & en & "(Por favor no respondas a este mail, es automático....gracias!)" & en & en

            Dim ok As String = EnviarMail(email, "Helados Fernando - Clave Recuperada", mensaje)

        End If
    End Sub

    Protected Sub ImageButton10_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton10.Click
        pVerPedidoA.Visible = False
        pHistoricoA.Visible = True
    End Sub

    Protected Sub ImageButton11_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton11.Click
        pHistoricoA.Visible = True
        pPedidoAnuladoA.Visible = False
    End Sub

    Protected Sub bGestionUsuarios_Click(sender As Object, e As EventArgs) Handles bGestionUsuarios.Click
        pAreaAdmin.Visible = False
        pGestionUsuario.Visible = True
    End Sub

    Protected Sub gGestionUsuario_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gGestionUsuario.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gGestionUsuario.Rows(index)
        Dim idUsu As Integer = VNum(row.Cells(2).Text), en As String = Chr(13) & Chr(10)
        Dim email As String, xusuario As String, mensaje As String


        If (e.CommandName = "Quitar") Then

            lErrorVerUnPedidoA.Text = ""
            Dim da1 As New SqlDataAdapter("delete from Usuarios where idUsuario= " & idUsu, con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "histo")
            gGestionUsuario.DataSource = ds1.Tables("histo")
            gGestionUsuario.DataBind()

            Dim da2 As New SqlDataAdapter("select ltrim(rtrim(nombre)) + ' ' + ltrim(rtrim(apellido)) as usuario" & " email from Usuarios where idUsuario='" & idUsu & "'", con)
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Login")

            email = ds2.Tables("Login").Rows(0)("Email").ToString.Trim.ToLower
            xusuario = ds2.Tables("Login").Rows(0)("usuario").ToString.Trim

            mensaje = "Hola " & xusuario & "." & en & en & "Le escribimos desde Helados Fernando, avisandole de que hemos borrado su usuario por incumplimiento de normas o baja propia." & en & en & en & en & "(Por favor no respondas a este mail, es automático....gracias!)" & en & en

            Dim ok As String = EnviarMail(email, "Helados Fernando - Informe", mensaje)

        End If

        If (e.CommandName = "Bloquear") Then

            lErrorVerUnPedidoA.Text = ""
            Dim da1 As New SqlDataAdapter("update Bloqueo = 1 from Usuarios where idUsuario= " & idUsu, con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "gUsu")
            gGestionUsuario.DataSource = ds1.Tables("gUsu")
            gGestionUsuario.DataBind()

            If ds1.Tables("gUsu").Rows.Count = 0 Then
                lErrorGestionUsuario.Text = "Hubo un error al bloquear el usuario."

            ElseIf SQL_Accion("update Bloqueo = 1 from Usuarios where idUsuario= " & idUsu) = False Then

                lErrorGestionUsuario.Text = "Hubo un error al bloquear el usuario. El Usuario ya esta Bloqueado"

            End If


            Dim da2 As New SqlDataAdapter("select ltrim(rtrim(nombre)Then) + ' ' + ltrim(rtrim(apellido)) as usuario" & " email from Usuarios where idUsuario='" & idUsu & "'", con)
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Login")


            email = ds2.Tables("Login").Rows(0)("Email").ToString.Trim.ToLower
            xusuario = ds2.Tables("Login").Rows(0)("usuario").ToString.Trim

            mensaje = "Hola " & xusuario & "." & en & en & "Le escribimos desde Helados Fernando, avisandole de que hemos bloqueado su usuario por incumplimiento de normas. Si lo desbloqueamos le mandaremos un mail informandole." & en & en & en & en & "(Por favor no respondas a este mail, es automático....gracias!)" & en & en

            Dim ok As String = EnviarMail(email, "Helados Fernando - Informe", mensaje)

        End If

        If (e.CommandName = "Desbloquear") Then

            lErrorVerUnPedidoA.Text = ""
            Dim da1 As New SqlDataAdapter("update Bloqueo = 0 from Usuarios where idUsuario= " & idUsu, con)
            Dim ds1 As New DataSet
            da1.Fill(ds1, "gUsu")
            gGestionUsuario.DataSource = ds1.Tables("gUsu")
            gGestionUsuario.DataBind()

            If ds1.Tables("gUsu").Rows.Count = 0 Then
                lErrorGestionUsuario.Text = "Hubo un error al desbloquear el usuario."

            ElseIf SQL_Accion("update Bloqueo = 0 from Usuarios where idUsuario= " & idUsu) = False Then

                lErrorGestionUsuario.Text = "Hubo un error al descbloquear el usuario. El Usuario ya esta desbloqueado o no se bloqueo en un principio"

            End If


            Dim da2 As New SqlDataAdapter("select ltrim(rtrim(nombre)Then) + ' ' + ltrim(rtrim(apellido)) as usuario" & " email from Usuarios where idUsuario='" & idUsu & "'", con)
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Login")


            email = ds2.Tables("Login").Rows(0)("Email").ToString.Trim.ToLower
            xusuario = ds2.Tables("Login").Rows(0)("usuario").ToString.Trim

            mensaje = "Hola " & xusuario & "." & en & en & "Le escribimos desde Helados Fernando, avisandole de que hemos desbloqueado su usuario del sistema. Por favor no cometa mas incumplimientos." & en & en & en & en & "(Por favor no respondas a este mail, es automático....gracias!)" & en & en

            Dim ok As String = EnviarMail(email, "Helados Fernando - Informe", mensaje)

        End If
    End Sub

    Public Function CrearCodigo(ByVal cantCaracteres As Integer) As String
        Dim strRand As String = Nothing, r As New Random, c As String, i As Integer

        For i = 0 To cantCaracteres - 1
            If Math.Round(r.Next(0, 2)) = 0 Then
                c = Chr(Math.Round(r.Next(48, 58)))
            Else
                c = Chr(Math.Round(r.Next(65, 91)))
            End If
            strRand &= c
        Next
        Return strRand
    End Function

    Protected Sub bValidar_Click(sender As Object, e As EventArgs) Handles bValidar.Click
        pVerificaMail.Visible = False
        Dim sqlIngreso As String = Session("sqlIngreso") & " "
        If sqlIngreso.Length < 10 Or sqlIngreso.IndexOf("insert") < 0 Then
            lErroresU.Text = "Hubo un error con el código. Por favor, trate de generar un nuevo código."
            lErroresU.Visible = True
            Exit Sub
        End If
        If tValidar.Text.Trim.ToUpper <> Session("Codigo") Then
            lCodigo.Visible = True
            Exit Sub
        End If

        If SQL_Accion(sqlIngreso) = False Then
            lErroresU.Text = "Hubo un error al tratar de validar el código. Por favor, trate de generar uno nuevo."
            lErroresU.Visible = True
            Exit Sub
        End If

        If Usuario.Checked = True Then

            Session("idUsuario") = VNum(LeeUnCampo("select top 1 idUsuario from Usuarios where Usuario='" & Session("Usuario") & "' and Pass='" & Session("Password") & "' ", "idUsuario"))
            lBienvenido.Text = "Bienvenido " & Session("ApellidoYNombre") & "!"

            Dim mensaje As String, xusuario As String = Session("ApellidoYNombre"), en As String = Chr(13) & Chr(10)
            mensaje = "Bienvenido " & xusuario & " al Sistema de Helados Fernando!." & en & en & "Tu usuario es " & """" & Session("Usuario") & """" & en & "Tu clave es " & """" & Session("Password") & """" & en & en & "Ya podes loguearte para ver tus datos!." & en & en
            LimpiarRegistroU()
            pRegistrarse.Visible = False
            pBienvenido.Visible = True
            bRegok.Focus()

        ElseIf Administrador.Checked = True Then

            Session("idAdmin") = VNum(LeeUnCampo("select top 1 idAdmin from Administradores where Usuario='" & Session("Usuario") & "' and Pass='" & Session("Password") & "' ", "idAdmin"))
            lBienvenido.Text = "Bienvenido " & Session("ApellidoYNombre") & "!"

            Dim mensaje As String, xusuario As String = Session("ApellidoYNombre"), en As String = Chr(13) & Chr(10)
            mensaje = "Bienvenido " & xusuario & " al Sistema de Helados Fernando!." & en & en & "Tu usuario es " & """" & Session("Usuario") & """" & en & "Tu clave es " & """" & Session("Password") & """" & en & en & "Ya podes loguearte para ver tus datos!." & en & en
            LimpiarRegistroU()
            pRegistrarse.Visible = False
            pBienvenido.Visible = True
            bRegok.Focus()

        End If
    End Sub
End Class