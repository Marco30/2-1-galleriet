<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1DV406_Labb2_1.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>
<html lang="sv">
<head runat="server">
    <title>Marco - Labb 2.1</title>

    <link rel="stylesheet" href="Style.css" media="screen">
</head>

<body>
    <form id="form1" runat="server">

        <div id="inramning">

            <div id="TitleLabel">
            <h1>Marcos Gallery</h1>
                </div>
            <!-- Visar att upplandning lyckats -->
            <div id="Close">
                <div id="Message" runat="server" visible="false">
                    <h2>
                        <asp:Literal ID="StatusMessage" runat="server"></asp:Literal></h2>
                    <a href="#" id="CloseMessage">Stäng meddelande</a>
                </div>
            </div>

            <div id="Bildvisaren">

              
                <!-- loppar igenom bilderna och Presenterar dem -->
                <asp:Image ID="SelectedImage" Width="100%" runat="server" />
            </div>

            <div id="thumbnails">
                <!-- Visar tumnagel bilderna med hjälp av repeatern -->
                <asp:Repeater ID="GalleryThumbnailsRepeater" runat="server" ItemType="_1DV406_Labb2_1.Model.GalleryClass" SelectMethod="GalleryThumbnailsRepeater_GetData">
                    <ItemTemplate>
                        <asp:HyperLink ID="PictureHyperLink" runat="server" NavigateUrl='<%# "~/Default.aspx?Picture=" + Item.Name %>'>
                       <img src='<%# "Bilder/thumbnails/" + Item.Name %>' width="100" height="100" Class='<%# Item.Name %>' alt="" runat="server" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="text">
                <h2>Ladda upp bild</h2>
            </div>
            <div id="val">
                <!-- Visar alla samlade fel meddelanden -->
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="field-validation-error" />
            </div>
            <!-- ladd upp bild -->
            <asp:FileUpload ID="PictureUpload" runat="server" CssClass="standardButton" />

            <!-- Validering: Kontrollerar man vald bild-->
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="En fil måste väljas!" Text="*"
                ControlToValidate="PictureUpload" Display="Dynamic" CssClass="field-validation-error"></asp:RequiredFieldValidator>


            <!-- Validering: Kontrollerar om filen som ladas upp är av bild format-->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Filen är inte av typen JPG/PNG/GIF"
                Text="*" ControlToValidate="PictureUpload" CssClass="field-validation-error"
                Display="Dynamic" ValidationExpression="([^\s]+(\.(?i)(jpg|png|gif))$)"></asp:RegularExpressionValidator>
            <div id="UploadButton1">
                <!-- knap-->
                <asp:Button ID="UploadButton" runat="server" Text="Ladda upp bild" CssClass="standardButton" OnClick="UploadButton_Click" />
            </div>
            <footer class="footer">
                <a>Marco</a>

            </footer>
        </div>

    </form>

    <!-- Sätter fokus på bilden man lagt in och tar bort ladda upp meddelande-->
    <script type="text/javascript" src="js/script.js"></script>

</body>

</html>

