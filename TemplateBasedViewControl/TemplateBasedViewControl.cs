using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using NVelocity.App;
using Commons.Collections;
using NVelocity;
using System.IO;
using System.Linq.Expressions;
using System.Resources;

namespace TemplateBasedViewControl
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TemplateBasedViewControl runat=server></{0}:ServerControl1>")]
    public class TemplateBasedViewControl : CompositeDataBoundControl
    {
        [Bindable(true)]
        [Category("Template")]
        [DefaultValue("")]
        [Localizable(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public string TemplateMarkup { get; set; }

        [Bindable(true), Category("Advanced")]
        [DefaultValue(false)]
        public bool DisplayErrorsOnScreen { get; set; }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
        }

        protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
        {

            int count = 0;

            if (string.IsNullOrEmpty(TemplateMarkup))
            {
                DisplayError("No template specified.");
            }
            else if (!dataBinding)
            {
                DisplayError("Control is not databound.");
            }
            else if (dataSource == null)
            {
                DisplayError("Data source was null.");
            }
            else
            {
                VelocityEngine velocity = new VelocityEngine();
                velocity.Init();
                
                Hashtable contextHashtable = new Hashtable {
                    { "Model", dataSource},
                    { "HttpContextCurrent", HttpContext.Current}
                };

                // TODO: Add ResourceManager and other useful things

                var velocityContext = new VelocityContext(contextHashtable);
                string evaluatedTemplate;
                using (StringWriter stringWriter = new StringWriter())
                {
                    velocity.Evaluate(velocityContext, stringWriter, /*logTag:*/ string.Empty, TemplateMarkup);
                    evaluatedTemplate = stringWriter.ToString();
                }

                Controls.Add(new LiteralControl { Text = evaluatedTemplate });
            }

            return count;
        }

        protected virtual void DisplayError(string errorMessage)
        {
            if (DisplayErrorsOnScreen)
            {
                Controls.Add(new Label() { Text = errorMessage, CssClass = "error templatebasedviewcontrolerror" });
            }
        }
    }
}
