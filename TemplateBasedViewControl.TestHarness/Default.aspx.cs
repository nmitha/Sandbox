using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateBasedViewControl.TestHarness
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            templateBasedViewControl1.DataSource = ObjectDataSource1;
            templateBasedViewControl1.DataBind();
        }
    }
}