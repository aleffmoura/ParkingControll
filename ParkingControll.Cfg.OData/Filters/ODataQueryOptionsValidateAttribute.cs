using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace ParkingControll.Cfg.OData.Filters
{
    public class ODataQueryOptionsValidateAttribute : ActionFilterAttribute
    {
        private ODataValidationSettings _oDataValidationSettings;

        public ODataQueryOptionsValidateAttribute(AllowedQueryOptions allowedQueryOptions = AllowedQueryOptions.All ^ AllowedQueryOptions.Expand)
        {
            _oDataValidationSettings = new ODataValidationSettings() { AllowedQueryOptions = allowedQueryOptions };
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ActionArguments.FirstOrDefault(act => act.Value != null && act.Value.GetType().Name.Contains(typeof(ODataQueryOptions).Name)).Value is ODataQueryOptions oDataQueryOptions)
            {
                oDataQueryOptions.Validate(_oDataValidationSettings);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
