using System;
using System.Data;

namespace FN.Common.Contract
{
    public class BusinessValidationException : DataException
    {
        public string PropertyName { get; }
        public string ValidationKey { get; }
        public BusinessValidationException() : base()
        {
            PropertyName = string.Empty;
            ValidationKey = string.Empty;
        }
        public BusinessValidationException(string propertyName, string validationKey)
            : this("The property: " + propertyName + " is not valid. Reason: " + validationKey)
        {
            PropertyName = propertyName;
            ValidationKey = validationKey;
        }
        public BusinessValidationException(string message)
          : base(message)
        {
            PropertyName = string.Empty;
            ValidationKey = string.Empty;
        }
        public BusinessValidationException(string propertyName, string validationKey, Exception innerException)
            : this("The property: " + propertyName + " is not valid. Reason: " + validationKey, innerException)
        {
            PropertyName = propertyName;
            ValidationKey = validationKey;
        }
        public BusinessValidationException(string message, Exception innerException)
          : base(message, innerException)
        {
            PropertyName = string.Empty;
            ValidationKey = string.Empty;
        }
    }
}
