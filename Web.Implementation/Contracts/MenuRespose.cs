namespace Web.Implementation.Contracts
{
    public class MenuRespose
    {
        public int MenuId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentMenuId { get; set; }
        public byte DisplayOrder { get; set; }
        public byte Status { get; set; }
    }
}
