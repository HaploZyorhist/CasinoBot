using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoBot.Models
{
    public class Response
    {
        public Status Status { get; set; }

        public List<string>? Messages { get; set; }

        public List<string>? Errors { get; set; }

        public static Response Success(params string[] messages) => new()
        {
            Status = Status.Success,
            Messages = messages.ToList()
        };

        public static Response Success(IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Success,
            Messages = messages?.ToList()  ?? new List<string>()
        };

        public static Response<T> Success<T>(T result, params string[] messages) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };

        public static Response<T> Success<T>(T result, IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages  = messages?.ToList() ?? new List<string>()
        };

        public static Response Error(params string[] messages) => new()
        {
            Status = Status.Error,
            Messages = messages.ToList()
        };

        public static Response Error(IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Error,
            Messages = messages?.ToList() ?? new List<string>()
        };

        public static Response<T> Error<T>(T result, params string[] messages) => new()
        {
            Status = Status.Error,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };

        public static Response<T> Error<T>(T result, IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Error,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };
    }

    public class Response<T> : Response
    {
        public T Result { get; internal init; } = default!;

        public static Response<T> Success(T result, params string[] messages) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages = messages.ToList()
        };

        public static Response<T> Success(T result, IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Success,
            Result = result,
            Messages = messages?.ToList() ?? new List<string>()
        };

        public static Response<T> Error(params string[] messages) => new()
        {
            Status = Status.Error,
            Messages = messages?.ToList() ?? new List<string>()
        };

        public static Response<T> Error(IEnumerable<string>? messages = null) => new()
        {
            Status = Status.Error,
            Messages = messages?.ToList() ?? new List<string>()
        };
    }

    public enum Status
    {
        Success,
        Error,
        NoResults
    }
}