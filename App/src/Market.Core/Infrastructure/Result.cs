using System.Collections.Generic;
using Market.Core.Products;

namespace Market.Core.Infrastructure
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public List<MarketError> Errors { get; set; }

        public Result()
        {
            Errors = new List<MarketError>();
        }

        public static Result Success()
        {
            return new Result { Succeeded = true };
        }

        /// <summary>
        /// Constructor for error result
        /// </summary>
        /// <param name="exception"></param>
        public Result(MarketError exception) : this()
        {
            Errors.Add(exception);
            Succeeded = false;
        }

        /// <summary>
        /// Constructor for error result
        /// </summary>
        /// <param name="exceptions"></param>
        public Result(IEnumerable<MarketError> exceptions) : this()
        {
            Errors.AddRange(exceptions);
            Succeeded = false;
        }
    }


    public class Result<T> : Result
    {
        public T Content { get; set; }

        public Result() { }

        /// <summary>
        /// Constructor for successful result
        /// </summary>
        /// <param name="data"></param>
        public Result(T data)
        {
            Content = data;
            Succeeded = true;
        }

        /// <summary>
        /// Constructor for error result
        /// </summary>
        /// <param name="exception"></param>
        public Result(MarketError exception) : base(exception) { }
        /// <summary>
        /// Constructor for error result
        /// </summary>
        /// <param name="exceptions"></param>
        public Result(IEnumerable<MarketError> exceptions) : base(exceptions) { }
    }
}