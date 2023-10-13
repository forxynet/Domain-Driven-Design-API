namespace ProjectX.Template.Domain.Common {
    public class AuditableEntity {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
