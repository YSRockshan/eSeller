using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.BoostUnit
{
    public partial class ValidationText : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int _interval = 4000;
        private int _fadeInDuration = 500;
        private int _fadeInSteps = 20;
        private int _fadeOutDuration = 500;
        private int _fadeOutSteps = 20;
        private bool _insertJavascript = true;

        public string CssClass
        {
            get { return lblMessage.CssClass; }
            set { lblMessage.CssClass = value; }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        public int FadeInDuration
        {
            get { return _fadeInDuration; }
            set { _fadeInDuration = value; }
        }

        public int FadeInSteps
        {
            get { return _fadeInSteps; }
            set { _fadeInSteps = value; }
        }

        public int FadeOutDuration
        {
            get { return _fadeOutDuration; }
            set { _fadeOutDuration = value; }
        }

        public int FadeOutSteps
        {
            get { return _fadeOutSteps; }
            set { _fadeOutSteps = value; }
        }

        public void Display(string messageText, string cssClass)
        {
            lblMessage.Text = messageText;
            lblMessage.CssClass = cssClass;
            Display();
        }

        public void Display()
        {
            //Set the duration, steps, etc. for the javascript fade in and fade out   
            string js = "fadeIn('" + lblMessage.ClientID + "', " + FadeInSteps + ", " + FadeInDuration + ", " + Interval +
                        ", " + FadeOutSteps + ", " + FadeOutDuration + ");"; // window.scroll(0,0);";

            //Find the script manager on the page, and the update panel the FlashMessage control
            //is nested in

            ScriptManager sm = ScriptManager.GetCurrent(Page);
            ContentPlaceHolder up = (ContentPlaceHolder)GetParentOfType(lblMessage, typeof(ContentPlaceHolder));


            if (sm != null && up != null)
            {
                //The user control is nested in an update panel, register the javascript with the script manager and
                //attach it to the update panel in order to fire it after the async postback
                if (sm.IsInAsyncPostBack == true)
                {
                    ScriptManager.RegisterClientScriptBlock(up, typeof(UpdatePanel), "jscript1", js, true);
                }
                else
                {
                    //The user control is not in an update panel (or there is no script manager on the page), 
                    //so register the javascript for a normal postback
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "jscript1", js, true);
                }
            }
            //this.Focus();
            buttonFalseFocus.Focus();
        }



        // Return the parent control of the given root control, as long as it matches the entered type

        private Control GetParentOfType(Control root, System.Type type)
        {
            Control parent = root.Parent;
            if (parent == null)
            {
                return null;
            }
            if (parent.GetType().ToString() == type.ToString())
            {
                return root.Parent;
            }
            Control p = GetParentOfType(parent, type);
            if (p != null)
            {
                return p;
            }
            return null;
        }

    }
}