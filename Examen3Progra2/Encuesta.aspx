<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen3Progra2.Encuesta" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="EstilosEncuesta.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ENCUESTA</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <label for="nombre">Nombre Completo:</label>
                <asp:TextBox ID="Tnombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="Tnombre"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="genero">Genero:</label>
                <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Masculino</asp:ListItem>
                <asp:ListItem>Femenino</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese un genero" ControlToValidate="DropDownList3"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="edad">Edad:</label>
                <asp:TextBox ID="TEdad" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Number"></asp:TextBox><asp:RangeValidator runat="server" ErrorMessage="La edad debe de ser de 18 a 50 años" MinimumValue="18" MaximumValue="50" ControlToValidate="TEdad" Type="Integer"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese una edad" ControlToValidate="TEdad"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="correo">Correo:</label>
                <asp:TextBox ID="TCorreo" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Introduzca un correo válido" ControlToValidate="TCorreo" ValidationExpression="^[^@]+@[^@]+\.[a-zA-Z]{2,}$" BorderColor="#66FFFF" ClientIDMode="AutoID"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese un correo" ControlToValidate="TCorreo"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="partidop">Partido Politico:</label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>PLN</asp:ListItem>
                <asp:ListItem>PUSC</asp:ListItem>
                <asp:ListItem>PAC</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese un Partido Politico" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Button ID="BAgregar" runat="server" Text="Agregar" OnClick="BAgregar_Click" />
                <asp:Button ID="BResultados" runat="server" Text="Resultado" OnClick="BResultados_Click" />
            </div>
            <div>
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#CCFFFF" BorderColor="#0099CC" BorderStyle="Solid" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"></asp:BoundField>
                        <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero"></asp:BoundField>
                        <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad"></asp:BoundField>
                        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo"></asp:BoundField>
                        <asp:BoundField DataField="PartidoPolitico" HeaderText="PartidoPolitico" SortExpression="PartidoPolitico"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="EXAMENFINAL" ConnectionString="<%$ ConnectionStrings:EncuestaConnectionString %>" SelectCommand="MenuReportes" SelectCommandType="StoredProcedure" OnSelecting="EXAMENFINAL_Selecting">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Toperacion" PropertyName="Text" DefaultValue="1" Name="operacion" Type="Int32"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div>
                <Label for="ReporteCE">Ingrese el numero para obtener el reporte deseado:(1)Hombres Encuestados (2)Mujeres Encuestadas (3)Cantidad total de Encuestas  </Label> 
            </div>
            <div>
                <asp:TextBox ID="Toperacion" runat="server"></asp:TextBox><asp:Button ID="BCantidadE" runat="server" Text="Generar Consulta" OnClick="BMostrarGeneros_Click" />
                <asp:GridView ID="GridView2" runat="server" DataSourceID="EXAMENFINAL" BackColor="#FFCCFF">
                    <Columns>
                        <asp:BoundField HeaderText="Reporte" ></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
