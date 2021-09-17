using System;
namespace TaxCalculation.Api.Middlewares
{
    public class ResultErrorViewModelOutput
    {
        public string Message { get; set; }
        public ResultErrorViewModelOutput(string message)
        {
            Message = message;
        }
    }
}
