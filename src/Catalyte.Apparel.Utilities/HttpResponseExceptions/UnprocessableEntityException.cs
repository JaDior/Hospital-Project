using System;

namespace Catalyte.Apparel.Utilities.HttpResponseExceptions
{
    /// <summary>
    /// A custom exception for resource not found errors.
    /// </summary>
    [Serializable]
    public class UnprocessableEntityException : Exception, IHttpResponseException
    {
        public UnprocessableEntityException(string message)
        {
            Value = new(status: 422, error: "Unprocessable Entity", message: message);
        }
        public HttpResponseExceptionValue Value { get; set; }
    }
}

