using System;

namespace Student.Entities.Entities
{
    public class GenericResponse<T>
    {
        public int StatusCode { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }

        public GenericResponse()
        {
            StatusCode = 200;
            //Result = null;
            Message = "";
        }
    }
}
