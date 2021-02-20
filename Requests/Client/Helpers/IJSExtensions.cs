using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Client.Helpers
{
    public static class IJSExtensions
    {
        public static Task Alerts(this IJSRuntime js, string message)
        {
            return js.InvokeAsync<object>("swal", message).AsTask();
        }
    }
}
