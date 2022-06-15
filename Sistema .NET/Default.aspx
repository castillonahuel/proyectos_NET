<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Sistema._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema</title>
    <style>
        form{  
            width: 767px;
            height: 100%;
            margin: auto auto;
            margin-top: auto;
            margin-bottom: auto;
        }
        .auto-style2 {
            height: 10466px;
            margin-bottom: 133px;
        }
        .auto-style3 {
            width: 290px;
        }
        .auto-style5 {
            height: 66px;
        }
        .auto-style6 {
            height: 45px;
        }
        .auto-style10 {
            width: 100%;
            height: 52px;
        }
        .auto-style11 {
            width: 365px;
        }
        .auto-style13 {
            width: 380px;
        }
        .auto-style14 {
            width: 395px;
        }
        .auto-style15 {
            margin-left: 6px;
        }
        .auto-style16 {
            width: 248px;
        }
        .auto-style18 {
            width: 292px;
        }
        .auto-style19 {
            width: 100%;
            height: 369px;
        }
        .auto-style20 {
            height: 231px;
        }
        .auto-style21 {
            height: 82px;
        }
        .auto-style22 {
            width: 100%;
            height: 427px;
        }
        .auto-style23 {
            height: 61px;
        }
        </style>
</head>
<body bgcolor="#ffffff">
    <form id="form1" runat="server" class="auto-style2">
        <asp:Panel ID="pPortada" runat="server" Height="350px" Width="765px">
            <asp:ImageButton ID="bPortada" runat="server" ImageAlign="Middle" ImageUrl="~/imagenes/portada.jpg" Height="350px" Width="760px" />
        </asp:Panel>

        <asp:Panel ID="pLogin" runat="server" Height="548px" Font-Bold="true" ForeColor="Blue" Width="765px" Font-Size="Large" BorderStyle="Solid" Visible="False">
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Label ID="lVersion" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#999999" Text="Versión"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label104" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Ingresá tu Usuario y Clave, y oprimí ENTRAR!"></asp:Label>
                    </td>
                </tr>
            </table>

            <table style="width:100%;">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Usuario: "></asp:Label>
                        <asp:TextBox ID="tUsuario" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" Height="40px" Width="140px"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="X-Large" Text=" Clave: "></asp:Label>
                        <asp:TextBox ID="tClave" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" Height="45px" Width="140px"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/imagenes/entrar.png" Width="152px" />
                    </td>
                </tr>
                
                <tr>
                    <td align="center">
                        <asp:Label ID="lErrorLogin" runat="server" Font-Bold="true" Font-Size="Large" Text="Error en el Login" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="bRecuperarClave" runat="server" Height="68px" ImageUrl="~/imagenes/reenviarclave.png" Width="557px"/>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lReenviarClave" runat="server" Font-Bold="true" Font-Size="Large" Text="[ReenviarClave]" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>

            <br>
            
            <br>

            <table style="width:100%;">
                <tr>
                   <td align="center">
                     <asp:Label ID="Entraradmin" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Ingreso Administrador "></asp:Label>
                     <br>
                       <asp:Label ID="Label11" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Colocá tus datos en las casillas de arriba y clickea aca: "></asp:Label>
                     <br>
                     <asp:ImageButton ID="bAdministrador" runat="server" Height="50px" ImageUrl="~/imagenes/entrar.png" Width="152px" />
                   </td>
              </tr>   
            </table>

            <br>
            <br>

            <table style="width:100%;">
             <tr>
               <td align ="center">
                   <asp:ImageButton ID="bVolverLogin" runat="server" Height="68px" ImageUrl="~/imagenes/terminarvolver.png" />
               </td>
             </tr>
            </table>

            </asp:Panel>

        <br>

        <asp:Panel ID="pLoginMenu" runat="server" Height="392px" Font-Bold="true" ForeColor="Blue" Width="766px" Font-Size="Large" BorderStyle="Solid" Visible="false">
            <table style="width:100%;">
             <tr>
               <td align="center">
                   <asp:Image runat="server" Height="58px" ImageUrl="~/imagenes/registrate.png" Width="577px" />
               </td>
             </tr>  
             <tr>
               <td class="auto-style">
                   <asp:ImageButton ID="bRegistrarse" runat="server" Height="100px" ImageUrl="~/imagenes/registrateaqui.png" Width="760px" />
               </td>
             </tr>
             
             <tr>
               <td class="auto-style">
                   <asp:ImageButton ID="bEntrar" runat="server" Height="100px" ImageUrl="~/imagenes/yaregistrado.png" Width="760px" />
               </td>
             </tr>
              <tr>
               <td align="center">
                   <asp:ImageButton ID="bTerminar" runat="server" Height="70px" ImageUrl="~/imagenes/terminarvolver.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pRegistrarse" runat="server" Height="972px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false" style="margin-right: 0px;">
            <table style="width:100%;">
             <tr>
               <td align="center">
                   <asp:Image runat="server" Height="50px" ImageUrl="~/imagenes/registrarsetitulo.png" />
               </td>
             </tr>  
             <tr>
               <td>
                   Para poder registrarste debés ser mayor de 18 años, residir en Argentina y contar con documento válido que acredite tu identidad.<br /> Sólo se puede hacer un registro por documento. Los datos deben ser reales, correctos y vigentes.<br /> Todos los datos a continuación (menos Origen) son obligatorios:&nbsp;</td>
             </tr>
            </table>
            
            <br>
            <br>

             <table style="width:100%;">
                <tr>
                    <td align="center" class="auto-style13">
                        
                        <asp:CheckBox ID="Administrador" runat="server" Text = "Administrador" AutoPostBack = "True" OnCheckedChanged = "Admin_Checked"/>
                        
                    </td>
                    <td align="center">
                        
                        <asp:CheckBox ID="Usuario" runat="server" Text = "Usuario" AutoPostBack = "True" OnCheckedChanged = "Usu_Checked"/>
                        
                    </td>
                </tr>
            </table>

            <br>
            <br>

            <table style="width:100%;">
             <tr>
               <td class="auto-style3">
                   Tu/s Nombre/s:</td>
               <td>
                    <asp:TextBox ID="tNombreU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="20" Width="280px"></asp:TextBox>
                 </td>
                 <td>
                    <asp:Label ID="lENombreU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
              <tr>
               <td class="auto-style3">
                   Apellido/s:</td>
               <td>
                    <asp:TextBox ID="tApellidoU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="20" Width="280px"></asp:TextBox>
                 </td>
                  <td>
                    <asp:Label ID="lEApellidoU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Tipo Doc.:</td>
                <td>
                    <asp:DropDownList ID="dTDocU" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="MidnightBlue" Width="279px" Height="28px">
                        <asp:ListItem Value="DNI">Doc. Nacional de Identidad</asp:ListItem>
                        <asp:ListItem Value="LC">Libreta Cívica</asp:ListItem>
                        <asp:ListItem Value="LE">Libreta de  Enrolamiento</asp:ListItem>
                    </asp:DropDownList>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   N° Doc. (sin puntos ni espacios):</td>
                <td>
                    <asp:TextBox ID="tDocU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="8" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lEDocU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Fecha Nac.: (ddmmaa)</td>
                 <td>
                    <asp:TextBox ID="tF_Nac" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="6" Width="120px"></asp:TextBox>
                     <asp:Label ID="lEdad" runat="server" Font-Bold="True" Font-Size="Small">0</asp:Label>
                 </td>
                    <td>
                    <asp:Label ID="lEFNac" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Email válido para notificaciones:</td>
                 <td>
                    <asp:TextBox ID="tEmailU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="70" Width="280px" Rows="2" TextMode="MultiLine"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lEEmailU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Provincia:</td>
                <td>
                    <asp:DropDownList ID="didProvU" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="MidnightBlue" Width="279px" Height="28px">
                        <asp:ListItem Value="1">Buenos Aires</asp:ListItem>
                        <asp:ListItem Value="2">Catamarca</asp:ListItem>
                        <asp:ListItem Value="3">Chaco</asp:ListItem>
                        <asp:ListItem Value="4">Chubut</asp:ListItem>
                        <asp:ListItem Value="5">CABA</asp:ListItem>
                        <asp:ListItem Value="6">Córdoba</asp:ListItem>
                        <asp:ListItem Value="7">Corrientes</asp:ListItem>
                        <asp:ListItem Value="8">Entre Ríos</asp:ListItem>
                        <asp:ListItem Value="9">Formosa</asp:ListItem>
                        <asp:ListItem Value="10">Jujuy</asp:ListItem>
                        <asp:ListItem Value="11">La Pampa</asp:ListItem>
                        <asp:ListItem Value="12">La Rioja</asp:ListItem>
                        <asp:ListItem Value="13">Mendoza</asp:ListItem>
                        <asp:ListItem Value="14">Misiones</asp:ListItem>
                        <asp:ListItem Value="15">Neuquén</asp:ListItem>
                        <asp:ListItem Value="16">Rio Negro</asp:ListItem>
                        <asp:ListItem Value="17">Salta</asp:ListItem>
                        <asp:ListItem Value="18">San Luis</asp:ListItem>
                        <asp:ListItem Value="19">San Juan</asp:ListItem>
                        <asp:ListItem Value="20">Santa Cruz</asp:ListItem>
                        <asp:ListItem Value="21">Santa Fe</asp:ListItem>
                        <asp:ListItem Value="22">Santiago del Estero</asp:ListItem>
                        <asp:ListItem Value="23">Tucumán</asp:ListItem>
                        <asp:ListItem Value="24">Tierra del Fuego</asp:ListItem>
                    </asp:DropDownList> 
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Localidad:</td>
                 <td>
                    <asp:TextBox ID="tLocalidadU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="25" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lELocalidadU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Dirección:</td>
                 <td>
                    <asp:TextBox ID="tDireccionU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="100" Width="280px" Rows="2" TextMode="MultiLine"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lEDireccionU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Teléfono (agregue característica):</td>
                 <td>
                    <asp:TextBox ID="tTelefonosU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="25" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lETelefonosU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Usuario:</td>
                 <td>
                    <asp:TextBox ID="tUrsuarioU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="10" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lEUsuarioU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Clave:</td>
                 <td>
                    <asp:TextBox ID="tPassU" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="10" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lEPassU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Repetir Clave:</td>
                  <td>
                    <asp:TextBox ID="tPass2U" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="10" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="lEPass2U" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
              </table>
             
               <br><br>
              <asp:Label ID="lErroresU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>

            <br>
            <br>
            <table style="width:100%;">
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="bRegistrarseU" runat="server" Height="70px" ImageUrl="~/imagenes/registrarse.png" />
                    </td>
                    <td align="center">
                        <asp:ImageButton ID="bRegistrarseU0" runat="server" Height="70px" ImageUrl="~/imagenes/cancelarvolver.png" />
                    </td>
                </tr>
            </table>
            <br>         
            </br>
        </asp:Panel>

        <br>


        <asp:Panel ID="pBienvenido" runat="server" Height="427px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td align="center" class="auto-style5">
                   <asp:Label ID="lBienvenido" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Bienvenido/a!"></asp:Label>
               </td>
             </tr>  
             <tr>
               <td>
                   Ya estas anotado/a en los cursos de ASP.NET!<br /> Con el ingreso, te recordamos que tenes acceso al campus donde se realizarán las actividades y clases del curso, en breves te llegará un mail indicándote los datos de ingreso y donde ingresar.<br />
                   <br />
                   De parte del equipo de cursos de Castillo estamos contentos de recibir un nuevo alumno/a.<br /> Mucha suerte y nos estamos leyendo!<br />
               </td>
              </tr>
              <tr>
               <td align="center">
                   <asp:ImageButton ID="bRegok" runat="server" Height="65px" ImageUrl="~/imagenes/todook.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>
        
        <asp:Panel ID="pAreaUsuario" runat="server" Height="550px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td align="center" class="auto-style5">
                   <asp:Label ID="lBienvenidoAreaU" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Bienvenido/a!"></asp:Label>
               </td>
             </tr>  
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bAhoraQueHago" runat="server" ImageUrl="~/imagenes/ahora_que_hago.png" />
               </td>
             </tr>
             <tr>
               <td align="center">
                   Desde acá vas a poder hacer varias cosas relacionadas con tu cuenta en ASP ,NET.
               </td>
             </tr>
                <tr>
               <td align="center">
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bHacerPedido" runat="server" Height="65px" ImageUrl="~/imagenes/hacerpedido.png" />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="pVerHistorico" runat="server" Height="65px" ImageUrl="~/imagenes/vertodosmov.png" />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bModificarDatos" runat="server" Height="65px" ImageUrl="~/imagenes/modificardatos.png" />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bPedidosFabrica" runat="server" Height="65px" ImageUrl="~/imagenes/pedidosfabrica.png" />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bVolverLoginU1" runat="server" Height="65px" ImageUrl="~/imagenes/terminarvolver.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pAreaAdmin" runat="server" Height="397px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td align="center" class="auto-style5">
                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Bienvenido/a!"></asp:Label>
               </td>
             </tr>  
             
             <tr>
               <td align="center">
                   Desde acá vas a poder hacer varias cosas relacionadas con tu cuenta de administrador.
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bAltaAdmin" runat="server" Height="65px" ImageUrl="~/imagenes/pedidosfabrica.png" />
               </td>
             </tr>
                <tr>
               <td align="center" class="auto-style21">
                   
                   <asp:Button ID="bGestionUsuarios" runat="server" BackColor="#339933" BorderColor="White" Font-Bold="True" Font-Names="Calibri" Font-Overline="False" Font-Size="X-Large" ForeColor="White" Height="70px" Text="Gestion de Usuarios" Width="284px" />
                   
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bPedidosAdmin" runat="server" Height="65px" ImageUrl="~/imagenes/todoslospedidos.png" />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="bVolverLoginA" runat="server" Height="65px" ImageUrl="~/imagenes/terminarvolver.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pAhoraQueHago" runat="server" Height="228px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td align="center">
                   
                   Te cuento un poco!</td>
             </tr>  
             <tr>
               <td></td>
             </tr> 
             <tr>
               <td>
                   Ya estas anotado/a! <br /> En breves te llegará un mail indicándote los datos de ingreso y donde ingresar.<br /> <br />
               </td>
              </tr>
              <tr>
               <td align="center">
                   <asp:ImageButton ID="bVolverLoginU2" runat="server" Height="65px" ImageUrl="~/imagenes/terminarvolver.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pCambiarDatosPersonalesU" runat="server" Height="489px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Bold="True" Visible="false" BackImageUrl="~/imagenes/datospersonales.jpg">

            <table style="width:100%;">
             <tr>
               <td align="center" class="auto-style5">
                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Cambiar Datos Personales"></asp:Label>
               </td>
             </tr>
             <tr>
               <td></td>
             </tr>
            </table>

            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">Email válido para notificaciones:</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" BackColor="MidnightBlue" Font-Bold="true" Font-Size="Large" ForeColor="White" MaxLength="70" Rows="2" TextMode="MultiLine" Width="280px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="EEmailU" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
               <td class="auto-style3">
                   Provincia:</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="MidnightBlue" Width="279px" Height="28px">
                        <asp:ListItem Value="1">Buenos Aires</asp:ListItem>
                        <asp:ListItem Value="2">Catamarca</asp:ListItem>
                        <asp:ListItem Value="3">Chaco</asp:ListItem>
                        <asp:ListItem Value="4">Chubut</asp:ListItem>
                        <asp:ListItem Value="5">CABA</asp:ListItem>
                        <asp:ListItem Value="6">Córdoba</asp:ListItem>
                        <asp:ListItem Value="7">Corrientes</asp:ListItem>
                        <asp:ListItem Value="8">Entre Ríos</asp:ListItem>
                        <asp:ListItem Value="9">Formosa</asp:ListItem>
                        <asp:ListItem Value="10">Jujuy</asp:ListItem>
                        <asp:ListItem Value="11">La Pampa</asp:ListItem>
                        <asp:ListItem Value="12">La Rioja</asp:ListItem>
                        <asp:ListItem Value="13">Mendoza</asp:ListItem>
                        <asp:ListItem Value="14">Misiones</asp:ListItem>
                        <asp:ListItem Value="15">Neuquén</asp:ListItem>
                        <asp:ListItem Value="16">Rio Negro</asp:ListItem>
                        <asp:ListItem Value="17">Salta</asp:ListItem>
                        <asp:ListItem Value="18">San Luis</asp:ListItem>
                        <asp:ListItem Value="19">San Juan</asp:ListItem>
                        <asp:ListItem Value="20">Santa Cruz</asp:ListItem>
                        <asp:ListItem Value="21">Santa Fe</asp:ListItem>
                        <asp:ListItem Value="22">Santiago del Estero</asp:ListItem>
                        <asp:ListItem Value="23">Tucumán</asp:ListItem>
                        <asp:ListItem Value="24">Tierra del Fuego</asp:ListItem>
                    </asp:DropDownList> 
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Localidad:</td>
                 <td>
                    <asp:TextBox ID="TextBox6" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="25" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="ELocalidadU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Dirección:</td>
                 <td>
                    <asp:TextBox ID="TextBox7" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="100" Width="280px" Rows="2" TextMode="MultiLine"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="EDireccionU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Teléfono (agregue característica):</td>
                 <td>
                    <asp:TextBox ID="TextBox8" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="25" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="ETelefonosU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Usuario:</td>
                 <td>
                    <asp:TextBox ID="TextBox9" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="10" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="EUsuarioU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
                <tr>
               <td class="auto-style3">
                   Clave:</td>
                 <td>
                    <asp:TextBox ID="TextBox10" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" MaxLength="10" Width="280px"></asp:TextBox>
                 </td>
                    <td>
                    <asp:Label ID="EPassU" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
              </table>
             
              <br>
              <br>

            <table style="width:100%;">
              <tr>
                 <td align="center">
                    <asp:Label ID="Error" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
             </table>

             <table style="width:100%;">
              <tr>
                 <td align="center">
                    <asp:ImageButton ID="bCambiarDatos" runat="server" Height="70px" ImageUrl="~/imagenes/cambiarlosdatos.png" />
                 </td>
                  <td align="center">
                    <asp:ImageButton ID="bCancelarCambio" runat="server" Height="70px" ImageUrl="~/imagenes/cancelarvolver.png" />
                 </td>
             </tr>
             </table>
        </asp:Panel>

            <br>

        <asp:Panel ID="pCambioExitoso" runat="server" Height="304px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/datospersonales.jpg">
            <table style="width:100%;">
              
             <tr>
                 <td>
                    <br>
                    <br>
                    <br>
                    <br>
                 </td>
             </tr>
              <tr>
                 <td align="center">
                    <asp:Label ID="lCambiosExitosos" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Tus datos han sido cambiados correctamente"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                 </td>
             </tr>
              <tr>
                 <td align="center">
                    <asp:ImageButton ID="bVolverAreaUsuario" runat="server" Height="70px" ImageUrl="~/imagenes/volveratuarea.png" />
                 </td>
             </tr>
             </table>
        </asp:Panel>

        
        <br>

        <asp:Panel ID="pPedidos" runat="server" Height="405px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td class="auto-style5">
                   <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Menú de Pedidos" ForeColor="Black" ></asp:Label>
               </td>
             </tr> 
             <tr>
               <td align="center">
                   <br />
                   <br />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="ImageButton2" runat="server" Height="65px" ImageUrl="~/imagenes/nuevopedido2.png" />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="ImageButton3" runat="server" Height="65px" ImageUrl="~/imagenes/todoslospedidos.png" />
               </td>
             </tr>
              <tr>
               <td align="center">
                   <br />
                   <br />
                   <br />
                   <br />
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="ImageButton4" runat="server" Height="65px" ImageUrl="~/imagenes/terminar.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pNuevoPedido" runat="server" Height="821px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td class="auto-style5">
                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Nuevo Pedido a Fábrica" ForeColor="Black" ></asp:Label>
               </td>
             </tr> 
             <tr>
              <td class="auto-style6">
                  
                  &nbsp;

                   <asp:Button ID="bInstrucciones" runat="server" Height="22px" Text="Abrir Instrucciones" Width="128px" />
                   
                   &nbsp;
                   
                    <asp:Label ID="lInstrucciones" runat="server" Font-Bold="True" Font-Size="Small" Text="Instrucciones" ForeColor="Black" ></asp:Label>
               </td>
             </tr>
             <tr>
               <td>

                   Seleccione el gusto del Helado<br />
                   <asp:DropDownList ID="dHelados" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="Black" Width="730px" Height="30px">
                   </asp:DropDownList>

               </td>
             </tr>
            </table>

            &nbsp;

            <table style="width:100%;">
             <tr>
              <td>
                  <asp:Label ID="Label7" runat="server" Font-Size="Small" Text="Agregar:" ForeColor="Black" ></asp:Label>
              </td>
              <td>
                  <asp:Label ID="lCosaAgregar" runat="server" Font-Bold="True" Font-Size="Medium" Text="Label" ForeColor="Black" ></asp:Label>
              </td>
              <td>
                  <asp:Label ID="lQueEs" runat="server" Font-Size="Small" Text="Label" ForeColor="Black" ></asp:Label>
              </td>
             </tr>
            </table>

            <table class="auto-style10">
             <tr>
              <td>
                  <asp:Label ID="Label8" runat="server" Font-Size="X-Large" Text="Cantidad de Latas o Unidades:" ForeColor="Black" ></asp:Label>
             </td>
             <td>    
                  <asp:DropDownList ID="tCantLatas" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="Black" Width="55px" Height="28px" aling="right">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList> 
              </td>
              <td>
                  <asp:ImageButton ID="bAgregarALista" runat="server" Height="65px" ImageUrl="~/imagenes/agregar.png" />
              </td>
             </tr>
            </table>

            <table style="width:100%;">
             <tr>
                <td>
                  <asp:Label ID="Label9" runat="server" Font-Size="Large" Text="Esta es la lista de su pedido." ForeColor="Black" ></asp:Label>
                </td>
             </tr>
             <tr>
               <td>
                  
                   <asp:GridView ID="gListaPedido" runat="server" Height="386px" Width="763px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
                       <Columns>
                           <asp:ButtonField ButtonType="Image" CommandName="Quitar" ImageUrl="./imagenes/quitar.png" Text="Quitar" />
                           <asp:BoundField DataField="Item" HeaderText="Item Solicitado" ValidateRequestMode="Disabled" />
                           <asp:BoundField DataField="Cantidad" HeaderText="Cant." />
                       </Columns>
                       <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                       <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                       <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                       <RowStyle BackColor="White" ForeColor="#330099" />
                       <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                       <SortedAscendingCellStyle BackColor="#FEFCEB" />
                       <SortedAscendingHeaderStyle BackColor="#AF0101" />
                       <SortedDescendingCellStyle BackColor="#F6F0C0" />
                       <SortedDescendingHeaderStyle BackColor="#7E0000" />
                   </asp:GridView>
                  
               </td>
            </tr>
            </table>

            <table style="width:100%;">
             <tr>
                <td class="auto-style16">
                 <asp:ImageButton ID="bQuitarTodos" runat="server" Height="65px" ImageUrl="~/imagenes/quitartodos.png" />
                </td>
             
               <td class="auto-style18">
                  <asp:ImageButton ID="bSolicitarPedido" runat="server" Height="65px" ImageUrl="~/imagenes/solicitar.png" Width="231px" />
               </td>
            
               <td>
                  <asp:ImageButton ID="bCancelarPedido" runat="server" Height="65px" ImageUrl="~/imagenes/cancelarpedido.png" CssClass="auto-style15" />
               </td>
            </tr>
            </table>

            

            <asp:Label ID="lErrorPedido" runat="server" Font-Size="Small" Text="lErrorPedido" ForeColor="red" Visible = "false" ></asp:Label>
        </asp:Panel>

      

         <asp:Panel ID="pPedidoCreado" runat="server" Height="372px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td class="auto-style5">
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:Label ID="lPedidoCreado" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Label" ForeColor="Black" ></asp:Label>
               </td>
             </tr>
             <tr>
               <td>               
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="ImageButton6" runat="server" Height="65px" ImageUrl="~/imagenes/terminar.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>


        <asp:Panel ID="pHistorico" runat="server" Height="435px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table class="auto-style19">
             <tr>
               <td class="auto-style5">
                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Histórico de Pedidos y Revisar Estado" ForeColor="Black" ></asp:Label>
               </td>
             </tr> 
             <tr>
               <td align="center">
                   <asp:Label ID="lErrorHistorico" runat="server" Font-Bold="True" Font-Size="small" Text="lErrorHistórico" ForeColor="red" ></asp:Label>
               </td>
             </tr>
             <tr>
               <td align="center">
                   
               </td>
             </tr>
             <tr>
               <td align="center" class="auto-style20">

                   <asp:GridView ID="gHistorico" runat="server" Height="220px" Width="757px" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                       <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
                           <asp:ButtonField ButtonType="Button" CommandName="Ver" Text="Ver Pedido" ControlStyle-BackColor="#66ff66">
                           <ControlStyle BackColor="#66FF66" />
                           </asp:ButtonField>
                           <asp:ButtonField ButtonType="Button" CommandName="Anular" HeaderText="(sólo &quot;Solicitado&quot;)" Text="Anular Pedido" ControlStyle-BackColor="#ff5050">
                           <ControlStyle BackColor="#FF5050" />
                           </asp:ButtonField>
                           <asp:BoundField DataField="NPedido" HeaderText="N° Pedido" ReadOnly="True" />
                           <asp:BoundField DataField="fecha" HeaderText="Fecha y Hora" ReadOnly="True" />
                           <asp:BoundField DataField="estado" HeaderText="Estado de Pedido" />
                       </Columns>
                       <FooterStyle BackColor="#CCCCCC" />
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                       <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                       <SortedAscendingHeaderStyle BackColor="#808080" />
                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                       <SortedDescendingHeaderStyle BackColor="#383838" />
                   </asp:GridView>

               </td>
             </tr>
             <tr>
               <td align="center">
                   
               </td>
             </tr>
            </table>

            <table style="width:100%;">
            <tr>
               <td align="center" class="auto-style11">
                   <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/imagenes/actualizar.png" Width="176px" />
               </td>
                <td align="center">
                   <asp:ImageButton ID="bTerminarHistorico" runat="server" ImageUrl="~/imagenes/terminarvolver.png" Height="55px" Width="218px" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pVerUnPedido" runat="server" Height="355px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
           <table style="width:100%;">
            <tr>
               <td class="auto-style5">
                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Detalle de Pedido N°" ForeColor="Black" ></asp:Label> 
               </td>
             </tr>
              <tr>
                 <td align="center">
                    
                     <asp:GridView ID="gVerUnPedido" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="628px" AutoGenerateColumns="False">
                         <AlternatingRowStyle BackColor="#CCCCCC" />
                         <Columns>
                             <asp:BoundField DataField="Item" HeaderText="Item Solicitado" />
                             <asp:BoundField DataField="Cantidad" HeaderText="Cant." />
                         </Columns>
                         <FooterStyle BackColor="#CCCCCC" />
                         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#808080" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#383838" />
                     </asp:GridView>
                    
                 </td>
             </tr>
             <tr>
                 <td>
                 </td>
             </tr>
             <tr>
                 <td align="center">
                     <asp:Label ID="lErrorVerUnPedido" runat="server" Font-Bold="True" Font-Size="Small" Text="lErrorVerUnPedido" ForeColor="red" ></asp:Label> 
                 </td>
             </tr>
             <tr>
                 <td>
                 </td>
              </tr>
              <tr>
                 <td align="center">
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/imagenes/terminarvolver.png" />
                 </td>
             </tr>
            </table>
        </asp:Panel>
        
         <br>

         <asp:Panel ID="pPedidoAnulado" runat="server" Height="288px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td class="auto-style5">
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:Label ID="lPedidoAnulado" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Label" ForeColor="Black" ></asp:Label>
               </td>
             </tr>
             <tr>
               <td>               
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="ImageButton7" runat="server" Height="65px" ImageUrl="~/imagenes/terminar.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pNuevaConsulta" runat="server" Height="403px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false" style="margin-right: 0px;">
            <table style="width:100%;">
             <tr>
               <td></td>
             </tr>
             <tr>
               <td align = "center">
                   <asp:Label ID="NewConsulta" runat="server" Font-Bold="true" Font-Size="XX-Large" ForeColor="Blue" Text="Nueva Consulta"></asp:Label>
                   <br>
                   <asp:Label ID="Label13" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="Blue" Text="Una vez que haya finalizado de cargar presione 'Cancelar y Volver'"></asp:Label>
               </td>
             </tr>
            </table>
            <br>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">Gusto:</td>
                    <td>
                        <asp:TextBox ID="tGusto" runat="server" BackColor="MidnightBlue" Font-Bold="true" Font-Size="Large" ForeColor="White" MaxLength="100" Width="280px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lEGusto" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Precio por unidad:</td>
                    <td>
                        <asp:TextBox ID="tPrecio" runat="server" BackColor="MidnightBlue" Font-Bold="true" Font-Size="Large" ForeColor="White" MaxLength="10" Width="280px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lEPrecio" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Stock de latas:</td>
                    <td>
                        <asp:TextBox ID="tStock" runat="server" BackColor="MidnightBlue" Font-Bold="true" Font-Size="Large" ForeColor="White" MaxLength="100" Width="280px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lEStock" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <br>
            <br>
            <asp:Label ID="lEConsulta" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
            <br>
            <br>
             <asp:Label ID="lConsultaExistosa" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green" Visible="false"></asp:Label>
            <br>
            <br>
            <table style="width:100%;">
                <tr>
                    <td align="center" class="auto-style14">
                        <asp:ImageButton ID="bNuevaConsulta" runat="server" Height="70px" ImageUrl="~/imagenes/agregar.png" />
                    </td>
                    <td align="center">
                        <asp:ImageButton ID="bCancelarConsulta" runat="server" Height="70px" ImageUrl="~/imagenes/cancelarvolver.png" />
                    </td>
                </tr>
            </table>
            <br></br>
        </asp:Panel>

        <br>

        <asp:Panel ID="pHistoricoA" runat="server" Height="435px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table class="auto-style19">
             <tr>
               <td class="auto-style5">
                   <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Histórico de Pedidos y Revisar Estado" ForeColor="Black" ></asp:Label>
               </td>
             </tr> 
             <tr>
               <td align="center">
                   <asp:Label ID="lErrorHistoricoA" runat="server" Font-Bold="True" Font-Size="small" Text="lErrorPedidosA" ForeColor="red" ></asp:Label>
               </td>
             </tr>
             <tr>
               <td align="center">
                   
               </td>
             </tr>
             <tr>
               <td align="center" class="auto-style20">

                   <asp:GridView ID="gHistoricoA" runat="server" Height="220px" Width="757px" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                       <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
                           <asp:ButtonField ButtonType="Button" CommandName="Ver" Text="Ver Pedido" ControlStyle-BackColor="#66ff66">
                           <ControlStyle BackColor="#66FF66" />
                           </asp:ButtonField>
                           <asp:ButtonField ButtonType="Button" CommandName="Anular" HeaderText="(sólo &quot;Solicitado&quot;)" Text="Anular Pedido" ControlStyle-BackColor="#ff5050">
                           <ControlStyle BackColor="#FF5050" />
                           </asp:ButtonField>
                           <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" ControlStyle-BackColor="#ff5050">
                           <ControlStyle BackColor="#66FF66" />
                           </asp:ButtonField>
                           <asp:BoundField DataField="NPedido" HeaderText="N° Pedido" ReadOnly="True" />
                           <asp:BoundField DataField="Num_Cli" HeaderText="Cliente" ReadOnly="True" />
                           <asp:BoundField DataField="fecha" HeaderText="Fecha y Hora" ReadOnly="True" />
                           <asp:BoundField DataField="estado" HeaderText="Estado de Pedido" />
                       </Columns>
                       <FooterStyle BackColor="#CCCCCC" />
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                       <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                       <SortedAscendingHeaderStyle BackColor="#808080" />
                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                       <SortedDescendingHeaderStyle BackColor="#383838" />
                   </asp:GridView>

               </td>
             </tr>
             <tr>
               <td align="center">
                   
               </td>
             </tr>
            </table>

            <table style="width:100%;">
            <tr>
               <td align="center" class="auto-style11">
                   <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/imagenes/actualizar.png" Width="176px" />
               </td>
                <td align="center">
                   <asp:ImageButton ID="bTerminarPedidosA" runat="server" ImageUrl="~/imagenes/terminarvolver.png" Height="55px" Width="218px" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pVerPedidoA" runat="server" Height="379px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
           <table style="width:100%;">
            <tr>
               <td class="auto-style5">
                   <asp:Label ID="lPedidoA" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Detalle de Pedido N°" ForeColor="Black" ></asp:Label> 
               </td>
             </tr>
              <tr>
                 <td align="center">
                    
                     <asp:GridView ID="gVerPedidoA" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="628px" AutoGenerateColumns="False">
                         <AlternatingRowStyle BackColor="#CCCCCC" />
                         <Columns>
                             <asp:BoundField DataField="NItem" HeaderText="N° Item" ReadOnly="True" />
                             <asp:BoundField DataField="Item" HeaderText="Item Solicitado" />
                             <asp:BoundField DataField="Cantidad" HeaderText="Cant." />
                              <asp:ButtonField ButtonType="Button" CommandName="Quitar" Text="Quitar" ControlStyle-BackColor="#ff5050">
                           <ControlStyle BackColor="#FF5050" />
                           </asp:ButtonField>
                         </Columns>
                         <FooterStyle BackColor="#CCCCCC" />
                         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#808080" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#383838" />
                     </asp:GridView>
                    
                 </td>
             </tr>
             <tr>
                 <td>
                 </td>
             </tr>
             <tr>
                 <td align="center">
                     <asp:Label ID="lErrorVerUnPedidoA" runat="server" Font-Bold="True" Font-Size="Small" Text="lErrorVerUnPedido" ForeColor="red" ></asp:Label> 
                 </td>
             </tr>
             <tr>
                 <td>
                 </td>
              </tr>
              <tr>
                 <td align="center">
                    <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/imagenes/terminarvolver.png" />
                 </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

         <asp:Panel ID="pPedidoAnuladoA" runat="server" Height="288px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table style="width:100%;">
             <tr>
               <td class="auto-style5">
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:Label ID="lPedidoAnuladoA" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Label" ForeColor="Black" ></asp:Label>
               </td>
             </tr>
             <tr>
               <td>               
               </td>
             </tr>
             <tr>
               <td align="center">
                   <asp:ImageButton ID="ImageButton11" runat="server" Height="65px" ImageUrl="~/imagenes/terminar.png" />
               </td>
             </tr>
            </table>
        </asp:Panel>

         <br>

        <asp:Panel ID="pGestionUsuario" runat="server" Height="435px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <table class="auto-style19">
             <tr>
               <td class="auto-style5">
                   <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Gestion de Usuarios" ForeColor="Black" ></asp:Label>
               </td>
             </tr> 
             <tr>
               <td align="center">
                   <asp:Label ID="lErrorGestionUsuario" runat="server" Font-Bold="True" Font-Size="small" Text="lErrorGestionUsuario" ForeColor="red" ></asp:Label>
               </td>
             </tr>
             <tr>
               <td align="center">
                   
               </td>
             </tr>
             <tr>
               <td align="center" class="auto-style20">

                   <asp:GridView ID="gGestionUsuario" runat="server" Height="220px" Width="757px" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                       <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
                           <asp:ButtonField ButtonType="Button" CommandName="Bloquear" Text="Bloquear" ControlStyle-BackColor="#ff5050">
                           <ControlStyle BackColor="#FF5050" />
                           </asp:ButtonField>
                           <asp:ButtonField ButtonType="Button" CommandName="Desbloquear" Text="Desbloquear" ControlStyle-BackColor="#ff5050">
                           <ControlStyle BackColor="#FF5050" />
                           </asp:ButtonField>
                           <asp:ButtonField ButtonType="Button" CommandName="Quitar" Text="Quitar" ControlStyle-BackColor="#ff5050">
                           <ControlStyle BackColor="#FF5050" />
                           </asp:ButtonField>
                           <asp:BoundField DataField="idUsuario" HeaderText="ID Usuario" ReadOnly="True" />
                           <asp:BoundField DataField="Usuario" HeaderText="Nombre Usuario" ReadOnly="True" />
                       </Columns>
                       <FooterStyle BackColor="#CCCCCC" />
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                       <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                       <SortedAscendingHeaderStyle BackColor="#808080" />
                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                       <SortedDescendingHeaderStyle BackColor="#383838" />
                   </asp:GridView>

               </td>
             </tr>
             <tr>
               <td align="center">
                   
               </td>
             </tr>
            </table>

            <table style="width:100%;">
            <tr>
               <td align="center" class="auto-style11">
                   <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/imagenes/actualizar.png" Width="176px" />
               </td>
                <td align="center">
                   <asp:ImageButton ID="bTerminarGestionUsuario" runat="server" ImageUrl="~/imagenes/terminarvolver.png" Height="55px" Width="218px" />
               </td>
             </tr>
            </table>
        </asp:Panel>

        <br>

        <asp:Panel ID="pVerificaMail" runat="server" Height="438px" BorderColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">

            <table class="auto-style22">
            
            <tr>
                <td align="center">     
                 </td>
            </tr>

            <tr>
                <td align="center" style="font-size: 20px; color: royalblue ; font-weight: bold">
                    
                    Te hemos enviado un códgo de verificación al email que ingresaste. Abrí el mail, copiá el código, y pegalo en el cuadro de texto a continuación.<br /> Luego oprimí Validar. Para corregir algún dato ingresado, oprimí &quot;Regresar al Registro&quot;; o bien &quot;Cancelar y Volver&quot; para anular la operación y volver al Login.</td>
            </tr>

            <tr>
                <td align="center">     
                 </td>
            </tr>
  
            <tr>
                <td align="center">
                    <asp:TextBox ID="tValidar" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="MidnightBlue" Height="40px" Width="140px"></asp:TextBox>
               </td>
            </tr>
            <tr>
                <td align="center">
                   <asp:Label ID="lCodigo" runat="server" Font-Bold="True" Font-Size="small" Text="*** Código Incorrecto ***" ForeColor="orange" ></asp:Label>
               </td>
            </tr>
            <tr>
               <td align="center" class="auto-style23">
                  
                   <asp:Button ID="bValidar" runat="server" Text="Validar el Código!" BackColor="#00CC66" Font-Names="Calibri" Font-Size="X-Large" Height="55px" Width="286px" />
                  
               </td>
            </tr>
            <tr>
                <td align="center">
                  
                    <asp:Button ID="bRegresarRegistro" runat="server" Text="Regresar al Registro" BackColor="#FFFF66" Font-Bold="False" Font-Names="Calibri" Font-Size="X-Large" ForeColor="Black" Height="55px" Width="286px" />
                  
               </td>
             </tr>
             <tr>
                <td align="center">
                   <asp:ImageButton ID="bCancelarValidar" runat="server" ImageUrl="~/imagenes/cancelarvolver.png" Height="55px" Width="218px" />
               </td>
             </tr>
            </table>

        </asp:Panel>

    </form>
</body>
</html>