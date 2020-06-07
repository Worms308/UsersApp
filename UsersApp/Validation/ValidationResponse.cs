using System;

namespace UsersApp.Validation
{
    class ValidationResponse
    {
        public String message { get; set; }
        public Boolean valid { get; set; }

        public ValidationResponse(Boolean isValid, String message)
        {
            this.message = message;
            this.valid = isValid;
        }
    }
}
