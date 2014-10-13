using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetBstrHelper
{
    public class FeedbackHelper
    {
        /// <summary>
        /// Baut die Feedbackobjekte zusammen. Es kann zwischen positiven und negativen Feedbacks unterschieden werden. 
        /// Die Nachricht wird außerdem so aufbereitet, dass sie dargestellt werden kann (excapte Anführungszeichen werden ersetzt)
        /// Die beiden Felder ["Result"] und ["Message"] im Dictionary werden für die Feedbacks verwendet benutzt. 
        /// </summary>
        /// <param name="success">Bestimmt ob das Feedback positiv oder negativ ist</param>
        /// <param name="message">Die Nachricht als string</param>
        /// <param name="tempdata">Das TempDataDictionary vom Controller</param>
        public static void BuildTempData(bool success, string message, TempDataDictionary tempdata)
        {
            if (success)
            {
                tempdata["Result"] = "Done";
            }
            else
            {
                tempdata["Result"] = "Error";
            }
            tempdata["Message"] = message.Replace("\"", "\\\"");
        }
    }
}
