using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EventsAPI.Models.Core
{
    public class EventsApiResponse
    {
        [DataContract]
        public class EventsApiResponseBase
        {
            [DataMember]
            public int StatusCode { get; set; }

            [DataMember]
            public long Id { get; set; }

            public bool IsSuccess => StatusCode == 200;

            [DataMember]
            public string ErrorMessage { get; set; }
        }

        [DataContract]
        public class EventsApiResponse<TData> : EventsApiResponse
        {
            [DataMember]
            public TData Data { get; set; }

            public EventsApiResponse()
            {
            }

            public EventsApiResponse(TData data)
            {
                Data = data;
            }


            public static EventsApiResponse<T> Success<T>(T data)
            {
                return new EventsApiResponse<T>(data)
                {
                    StatusCode = 200,
                    Data = data
                };
            }
        }

        public class EventsApiResponse : EventsApiResponseBase
        {
            public static EventsApiResponse Failed(string text)
            {
                return new EventsApiResponse
                {
                    ErrorMessage = text,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }

            public static EventsApiResponse Failed(string text, int statusCode)
            {
                return new EventsApiResponse { ErrorMessage = text, StatusCode = statusCode };
            }

            public static EventsApiResponse<T> Failed<T>(string text)
            {
                return new EventsApiResponse<T>() { ErrorMessage = text };
            }

            public static EventsApiResponse<T> Success<T>(T data)
            {
                return new EventsApiResponse<T>(data)
                {
                    StatusCode = 200,
                    Data = data
                };
            }
            public static EventsApiResponse Success()
            {
                return new EventsApiResponse()
                {
                    StatusCode = 200,
                };
            }
        }
    }
}
