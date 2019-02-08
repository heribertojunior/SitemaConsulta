<%@ Page Language="C#" Inherits="View.Pages.EspecialidadePesquisa" %>
<!DOCTYPE html>
<html>
    <head runat="server">
        <title>Default</title>
        <link type="text/css" rel="stylesheet" href="../Content/bootstrap.css" />
        <style>
            .posicaoButton{
                
                margin-top: 20px;
            }
        </style>
        
    </head>
    <body>
        <div class="container">
          <!-- #include file ="../menu.inc" -->
          <div class="jumbotron">
            <form id="principal" runat="server" class="form-horizontal">
                <div class="form-group">
                   <div class="col-sm-2">
                       ID Especialidade         
                       <asp:Textbox id="id" autocomplete="off" runat="server" CssClass="form-control" />         
                   </div>
                        <div class="col-sm-3">
                       Nome Esspecialidade         
                       <asp:Textbox id="nome" autocomplete="off" runat="server" CssClass="form-control" />         
                   </div>
                  <asp:Button id="btnCadastrar" runat="server" Text="Localizar" CssClass="btn btn-primary posicaoButton" OnClick="btnPesquisarEspecialidade"/>  
                </div>
                    
                    <div class="form-group">
                        <h3> <asp:Label id="lblMensagem" runat="server"/> </h3>
                    </div>
                        
            </form>   
          </div>
        </div> 
        <script src="../Scripts/jquery-1.9.1.js"></script>
        <script src="../Scripts/bootstrap.js"></script>
    </body>
</html>

