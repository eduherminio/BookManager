using System;
using System.Collections.Generic;
using System.Net;

namespace BookManager.Exceptions
{
    public class ExceptionToHttpCodeConverter
    {
        private readonly Dictionary<Type, HttpExceptionResponseInfo> _exceptionInfo = new Dictionary<Type, HttpExceptionResponseInfo>();

        protected void AddValues(Type type, HttpStatusCode code, string msg)
        {
            _exceptionInfo.Add(type, new HttpExceptionResponseInfo(code, msg));
        }

        private HttpExceptionResponseInfo GetValue(Type type)
        {
            if (!_exceptionInfo.TryGetValue(type, out HttpExceptionResponseInfo info))
            {
                info = new HttpExceptionResponseInfo(HttpStatusCode.InternalServerError, null);
            }

            return info;
        }

        public ExceptionToHttpCodeConverter()
        {
            AddValues(typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized, "Unauthorized access exception");
            AddValues(typeof(InvalidOperationException), HttpStatusCode.BadRequest, "Invalid operation exception");
            AddValues(typeof(EntityDoesNotExistException), HttpStatusCode.NotFound, "Entity does not exist exception");
            AddValues(typeof(InternalErrorException), HttpStatusCode.InternalServerError, "Internal error exception");
        }

        public HttpExceptionResponseInfo GetMessageAndHttpCode(Exception exc)
        {
            var values = GetValue(exc.GetType());

            if (values.Message == null)
            {
                values.Message = exc.ToString();
            }

            return values;
        }
    }
}
