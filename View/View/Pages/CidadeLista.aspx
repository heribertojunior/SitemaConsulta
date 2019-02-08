<%@ Page Language="C#" Inherits="View.Pages.CidadeLista" %>
<!DOCTYPE html>
<html>
    <head runat="server">
        <title>Default</title>
        <link type="text/css" rel="stylesheet" href="../Content/bootstrap.css" />
        <style>
            .posicaoButton{
                margin-top: 20px;
            }
            .correcao{
              margin-top: 20px;
            }
        </style>
        <script>
            function reloadPage(){
              window.location.href = "http://127.0.0.1:8080/Pages/CidadeLista.aspx"
            }
        </script>
    </head>
    <body>
        <div class="container">
          <!-- #include file ="../menu.inc" -->
         
            <form id="principal" runat="server" class="form-horizontal">
                 <div align="center" class="col-sm-3">
                       Cidade:       
                       <asp:Textbox id="descricao" autocomplete="off" runat="server" CssClass="form-control" />         
                   </div>
                <div align="left">
                    <asp:Button id="btnCadastrar" runat="server" Text="Localizar" CssClass="btn btn-primary posicaoButton" OnClick="btnPesquisarCidade"/> 
                    <button type="button" class="btn btn-primary posicaoButton" onclick="reloadPage()">Teste</button>
                </div>
                <div>
              <asp:GridView runat="server" id="dridListaCidade" CssClass="table table-bordered table-hover correcao" AutoGenerateColumns="true">
                    <Columns>
                        
                       
                        </Columns>
                        
                    
                    </asp:GridView>
                    </div>
            </form>   
       
        </div> 
        <script src="../Scripts/jquery-1.9.1.js"></script>
        <script src="../Scripts/bootstrap.js"></script>
    </body>
</html>
