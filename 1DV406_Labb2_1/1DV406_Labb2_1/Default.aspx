<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1DV406_Labb2_1.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Marcos - Labb 2.1</title>

    <link rel="stylesheet" href="Style.css" media="screen">

</head>
<body>
    <form id="form1" runat="server">

    <div id="inramning">

			
				<h1>Galleriet</h1>
				<p>
					<!--här väljer man fil att ladda up--->

					<asp:FileUpload ID="FileUpload" runat="server" />

					<!-- Validering: Kontrollerar om textboxsen är tom-->
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
						ErrorMessage="En fil måste väljas" ControlToValidate="MyFileUpload" Display="None">
					</asp:RequiredFieldValidator>

                    <!-- Validering: Kontrollerar om filen som ladas upp är av bild format-->
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
						ControlToValidate="MyFileUpload" ValidationExpression=".*.(gif|GIF|jpg|JPG|png|PNG)"
						ErrorMessage="Endast bilder av typerna gif, jpg eller png är tillåtna" Display="None">
					</asp:RegularExpressionValidator>

                    <!-- ladda upp knap-->
					<asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
				</p>


  </div>
    </form>
</body>
</html>
