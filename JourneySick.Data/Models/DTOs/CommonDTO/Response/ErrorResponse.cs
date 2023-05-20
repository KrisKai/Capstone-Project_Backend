using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Response
{
    public class ErrorResponse
    {
        //public ErrorResponse(string _Code, string _Message) {
        //    this.Code = _Code;
        //    this.Message = _Message;
        //}
        //public ErrorResponse() { };
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
