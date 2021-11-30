using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProcess.Service
{
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
    public class Result
    {
        public bool Success { get; set; }
        public List<ValidationFailure> Errors { get; set; }
    }
}
