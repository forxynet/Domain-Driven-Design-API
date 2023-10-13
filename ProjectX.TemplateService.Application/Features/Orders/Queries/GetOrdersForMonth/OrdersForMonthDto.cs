namespace ProjectX.Template.Application.Features.Orders.Queries.GetOrdersForMonth {
    public class OrdersForMonthDto {
        public Guid Id { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}