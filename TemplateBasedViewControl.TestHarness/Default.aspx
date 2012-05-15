<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TemplateBasedViewControl.TestHarness._Default" %>
<%@ Register TagPrefix="infusion" Assembly="TemplateBasedViewControl" Namespace="TemplateBasedViewControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetAllCustomers" 
            TypeName="TemplateBasedViewControl.TestHarness.Customer">
        </asp:ObjectDataSource>

        <!-- TODO: Visualizer http://stackoverflow.com/questions/7020905/syntax-highlighting-with-nvelocity-in-castle-monorails 
        -->
        <!-- TODO: Spark view engine http://www.dimecasts.net/Casts/CastDetails/115 -->

        <infusion:TemplateBasedViewControl ID="templateBasedViewControl1" runat="server" DisplayErrorsOnScreen="true">
            <TemplateMarkup>
                <ul>
                    #foreach( $customer in $Model )
                        <li>$customer.FirstName $customer.LastName</li>
                    #end
                </ul>
            </TemplateMarkup>
        </infusion:TemplateBasedViewControl>

    </div>
    </form>
</body>
</html>
