using System;
using Core.Mirror.Core.Enums;

namespace Core.Mirror.Core.Model
{
	public class MirrorResponse<T>
	{
        public T Data { get; set; }
        public ApiResponseEnum StatusCode { get; set; }
        public string Message { get; set; }


        public static MirrorResponse<T> MirrorResult(T data, ApiResponseEnum apiResponseEnum, string message)
        {
            return new MirrorResponse<T> { Data = data, StatusCode = apiResponseEnum, Message = message };
        }

    }

}



