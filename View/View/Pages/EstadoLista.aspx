<%@ Page Language="C#" Inherits="View.Pages.EstadoLista" %>
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
         
            <form id="principal" runat="server" class="form-horizontal">
                
              <asp:GridView runat="server" id="dridListaEstado" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        
                        <asp:BoundField DataField="Id" HeaderText="Id" >
                            <ItemStyle width="5%">
                        </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Nome" HeaderText="Estado">
                               <ItemStyle width="15%">
                        </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Sigla" HeaderText="Sigla">
                               <ItemStyle width="5%">
                        </ItemStyle>
                        </asp:BoundField>
                        </Columns>
                    
                    </asp:GridView>
                    
            </form>   
       
        </div> 
        <script src="../Scripts/jquery-1.9.1.js"></script>
        <script src="../Scripts/bootstrap.js"></script>
    </body>
</html>
