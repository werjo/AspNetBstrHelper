using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetBstrHelper
{
    public static class HtmlHelperExtension
    {
        private const string Nbsp = "&nbsp;";
        
        public static MvcHtmlString Feedback(this HtmlHelper helper)
        {
            return new MvcHtmlString("<div id=\"message\" class=\"alert alert-dismissable\" style=\"display: none; margin-bottom: 10px;\"></div>");
        }

        public static MvcHtmlString FeedbackScript(this HtmlHelper helper, TempDataDictionary tempData)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<script type=\"text/javascript\">");
            builder.Append(System.Environment.NewLine);
            builder.Append("$(function () {{ " + System.Environment.NewLine + " {0} " + System.Environment.NewLine + " }});");
            builder.Append("</script>");
            string value = builder.ToString();

            bool hasResult = tempData["Result"] != null;
            bool hasMessage = tempData["Message"] != null;
            bool success = false;
            if(hasResult)
            {
                success = tempData["Result"].Equals("Done");
            }

            if(!hasResult)
            {
                value = string.Format(value, "$(\"#message\").hide();");
            }
            else
            {
                if(success)
                {
                    string message = "$(\"#message\").removeClass(\"alert-danger\").addClass(\"alert-success\");"
                        + System.Environment.NewLine
                        + "$(\"#message\").html(\"<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button><span class='glyphicon glyphicon-ok'></span>\" + \"" + tempData["Message"] + "\");"
                        + System.Environment.NewLine
                        + "$(\"#message\").show();";

                    value = string.Format(value, message);
                }
                else
                {
                    string message = "$(\"#message\").addClass(\"alert-danger\").removeClass(\"alert-success\");"
                        + System.Environment.NewLine
                        + "$(\"#message\").html(\"<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button><span class='glyphicon glyphicon-remove'></span>\" + \"" + tempData["Message"] + "\");"
                        + System.Environment.NewLine
                        + "$(\"#message\").show();";
                    value = string.Format(value, message);
                }
            }
            
            MvcHtmlString result = new MvcHtmlString(value);
            return result;
            /*
             * <script type="text/javascript">
        $(function () {
            @if (TempData["Result"] == null)
                {
                    // kein Resultat
                    <text>$("#message").hide();</text>
                }
                else
                {
                    if(TempData["Result"].Equals("Done"))
                    {
                        //positives Resultat
                        <text>
            $("#message").removeClass("alert-danger").addClass("alert-success");
            $("#message").html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button><span class='glyphicon glyphicon-ok'></span> " + "@Html.Raw(TempData["Message"])");
            $("#message").show();
            </text>
                    }
                    else
                    {
                        //negateives Resultat
                        <text>
            $("#message").addClass("alert-danger").removeClass("alert-success");
            $("#message").html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button><span class='glyphicon glyphicon-remove'></span> " + "@Html.Raw(TempData["Message"])");
            $("#message").show();
            </text>
                    }
                }
        });
    </script>*/
        }
    }
}
