﻿using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Domain.Entities {
    public class Order : AuditableEntity {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
