using System;

namespace OrionTek.Entities
{
    /// <summary>
    /// Clase Base de donde heredan todos los modelos
    /// </summary>
    public class BaseModel
    {

        public Guid Id { get; set; }

        //Estos campos son de auditoria para los modelos
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
