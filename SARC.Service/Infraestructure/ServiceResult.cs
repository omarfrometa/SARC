using System.Collections.Generic;

namespace SARC.Service.Infraestructure
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T ResultObject { get; set; }
        public string ActionTitle { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
