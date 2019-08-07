using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarSales_Mini.BAL.Common.Model.Base
{
    public class ServiceResult
    {
        private ServiceErrorCollection _errors;
        private ServiceMessageCollection _info;

        public bool IsSuccess { get; set; }
        public ServiceErrorCollection Errors { get { return _errors; } }
        public ServiceMessageCollection Info { get { return _info; } }
        public ServiceResultModel Model { get; set; }
        public object ReturnModel { get; set; }

        public ServiceResult()
        {
            _errors = new ServiceErrorCollection();
            _info = new ServiceMessageCollection();
        }
    }

    public class ServiceError
    {
        public string ErrorMessage { get; set; }

        public ServiceError(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }

    public class ServiceMessage
    {
        public string Message { get; set; }

        public ServiceMessage(string message)
        {
            this.Message = message;
        }
    }

    public class ServiceErrorCollection : Collection<ServiceError>
    {
        public void Add(ModelStateDictionary modelState)
        {
            foreach (var modelStateKey in modelState.Keys)
            {
                foreach (var error in modelState[modelStateKey].Errors)
                {
                    this.Add(error.ErrorMessage);
                }
            }
        }

        public void Add(string errorMessage)
        {
            this.Add(new ServiceError(errorMessage));
        }
    }

    public class ServiceMessageCollection : Collection<ServiceMessage>
    {
        public void Add(string message)
        {
            this.Add(new ServiceMessage(message));
        }
    }

    public class ServiceResultModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class ServiceResultList<TModel>
    {
        public IEnumerable<TModel> Data { get; set; }
        public int Total { get; set; }
        
    }
}
