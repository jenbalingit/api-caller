using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Response
{
    public class ResponseCallback : CallBack
    {
        public ResponseCallback()
        {
            Success = false;
            Message = string.Empty;
        }

        public void SuccessMethod(string message)
        {
            Success = true;
            this.Message = message;
        }
    }
}
