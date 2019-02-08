<%@ Page Language="C#" Inherits="View.Pages.ExameCadastro" %>
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
                   
                    <div class="col-sm-3">
                       Consulta:
                       <asp:DropDownList id="idMedico" runat="server" CssClass="form-control" >
                           
                       </asp:DropDownList>
                   </div>    
                   <div class="col-sm-3">
                       Exame:
                       <asp:DropDownList id="idPaciente" runat="server" CssClass="form-control" >
                           
                       </asp:DropDownList>
                   </div>
                        <div class="col-sm-3">
                       Obs:          
                       <asp:Textbox id="obs" autocomplete="off" runat="server" CssClass="form-control" />         
                   </div>
                        
                  <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-primary posicaoButton" OnClick="btnCadastrarConsulta"/>  
                
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
