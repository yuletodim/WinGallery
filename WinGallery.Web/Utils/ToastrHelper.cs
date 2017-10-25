namespace WinGallery.Web.Utils
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// Display a message to the user via Toastr. Command is the toastr action, success, info, etc.
    /// and Message is the text to display in the alert.
    /// </summary>
    public class Alert
    {
        public Alert(string command, string message)
        {
            this.Command = command;
            this.Message = message;
        }

        public string Command { get; set; }

        public string Message { get; set; }
    }

    /// <summary>
    /// A strongly-type extension method for accessing TempData which is used to store our Alerts.
    /// </summary>
    public static class AlertExtensions
    {
        private const string Alerts = "_Alerts";

        public static List<Alert> GetAlerts(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(Alerts))
            {
                tempData[Alerts] = new List<Alert>();
            }

            return (List<Alert>)tempData[Alerts];
        }

        // helper methods to simplify the creation of the AlertDecoratorResult types
        public static ActionResult WithSuccess(this ActionResult result, string message)
        {
            return new AlertDecoratorResult(result, "success", message);
        }

        public static ActionResult WithInfo(this ActionResult result, string message)
        {
            return new AlertDecoratorResult(result, "info", message);
        }

        public static ActionResult WithWarning(this ActionResult result, string message)
        {
            return new AlertDecoratorResult(result, "warning", message);
        }

        public static ActionResult WithError(this ActionResult result, string message)
        {
            return new AlertDecoratorResult(result, "error", message);
        }
    }

    /// <summary>
    /// Adds the alerts to an existing ActionResult
    /// </summary>
    public class AlertDecoratorResult : ActionResult
    {
        public AlertDecoratorResult(ActionResult innerResult, string command, string message)
        {
            this.InnerResult = innerResult;
            this.Command = command;
            this.Message = message;
        }

        public ActionResult InnerResult { get; set; }

        public string Command { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Uses the extension method to get the list of alerts from temp data add a new alert to
        /// this list and then hand the execution off to the innerResult
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();

            alerts.Add(new Alert(Command, Message));

            InnerResult.ExecuteResult(context);
        }
    }
}