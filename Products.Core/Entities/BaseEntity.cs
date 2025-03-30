namespace Products.Core.Entities
{
    public class BaseEntity
    {
        //Protected set is made to use in the derived classes
        public Int64 Id { get; set; }
        //Below Properties are Audit properties
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int64? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
