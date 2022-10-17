using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoBot.Models
{
    /// <summary>
    /// response object being used for returning from services
    /// </summary>
    public class Response
    {
        /// <summary>
        /// the status of the response
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// messages on the response of the request
        /// </summary>
        public List<string>? Messages { get; set; }

        /// <summary>
        /// any errors regarding the request
        /// </summary>
        public List<string>? Errors { get; set; }

        /// <summary>
        /// convenience method for generating a success response
        /// </summary>
        public static Response Success(params string[] messages) => new()
        {
            Status = Status.Success,
            Messages = messages.ToList()
        };

        /// <summary>
        /// convenience method for generating a success response
        /// </summary>
        public static Response Success(IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Success,
            Messages = messages?.ToList()  ?? new List<string>()
        };

        /// <summary>
        /// convenience method for generating a success response
        /// </summary>
        public static Response<T> Success<T>(T result, params string[] messages) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };

        /// <summary>
        /// convenience method for generating a success response
        /// </summary>
        public static Response<T> Success<T>(T result, IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages  = messages?.ToList() ?? new List<string>()
        };

        /// <summary>
        /// convenience method for generating an error response
        /// </summary>
        public static Response Error(params string[] messages) => new()
        {
            Status = Status.Error,
            Messages = messages.ToList()
        };

        /// <summary>
        /// convenience method for generating an error response
        /// </summary>
        public static Response Error(IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Error,
            Messages = messages?.ToList() ?? new List<string>()
        };

        /// <summary>
        /// convenience method for generating an error response
        /// </summary>
        public static Response<T> Error<T>(T result, params string[] messages) => new()
        {
            Status = Status.Error,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };

        /// <summary>
        /// convenience method for generating an error response
        /// </summary>
        public static Response<T> Error<T>(T result, IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Error,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };
    }

    /// <summary>
    /// response object that contains another object
    /// </summary>
    /// <typeparam name="T">object being wrapped by the response object</typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// the object being wrapped by the response
        /// </summary>
        public T Result { get; internal init; } = default!;

        /// <summary>
        /// convenience method for generating a success response
        /// </summary>
        public static Response<T> Success(T result, params string[] messages) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages = messages.ToList()
        };

        /// <summary>
        /// convenience method for generating a success response
        /// </summary>
        public static Response<T> Success(T result, IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };

        /// <summary>
        /// convenience method for generating an error response
        /// </summary>
        public static Response<T> Error(params string[] messages) => new()
        {
            Status = Status.Error,
            Messages = messages?.ToList() ?? new List<string>()
        };

        /// <summary>
        /// convenience method for generating an error response
        /// </summary>
        public static Response<T> Error(IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Error,
            Messages = messages?.ToList() ?? new List<string>()
        };
    }

    /// <summary>
    /// status enum indicating the status of the response
    /// </summary>
    public enum Status
    {
        Success,
        Error,
        NoResults
    }
}