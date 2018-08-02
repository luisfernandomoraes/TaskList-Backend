using System;

namespace Supero.TaskList.Domain.BusinessExceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string msg,Exception innerException):base(msg,innerException)
        {
            
        }
    }
}