using System.Net;

namespace Domain.Exceptions
{
    public class ObjectNotFound : BarberBossException
    {
        public ObjectNotFound(string objectName, Guid id) 
            : base(string.Format(ExceptionResource.OBJECT_NOT_FOUND, objectName, id))
        {
            
        }

        internal override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }

}
