using System.Collections.Generic;

namespace BabALSaray.Errors
{
    public class ApiValidationErrorResponse : ApiResponse /* Validation Error that fire according to data submitted by user was invalid 
    like login user name and password blanck or string instead of NO,ect ...... so need array of errors*/
    {
        public ApiValidationErrorResponse() : base(400)

        {

        }

        public IEnumerable<string> Errors {get;set;}



    }
}