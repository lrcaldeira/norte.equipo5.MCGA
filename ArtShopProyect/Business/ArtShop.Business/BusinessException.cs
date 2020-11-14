using ArtShop.Framework.Exceptions;

namespace ArtShop.Business
{
    public class BusinessException : ApiException
    {
        public BusinessException(string message) : base(message, "B")
        {
        }
    }
}
