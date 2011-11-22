using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.ApplicationServer.Http.Dispatcher;

namespace VeryFirstWcfWebAPI.Handlers {

    public class GlobalErrorHandler : HttpErrorHandler {

        protected override bool OnTryProvideResponse(Exception exception, ref System.Net.Http.HttpResponseMessage message) {

            if(exception != null) // Notify ELMAH of the exception.
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);

            message = new HttpResponseMessage {
                StatusCode = HttpStatusCode.InternalServerError
            };

            return true;
        }
    }
}