namespace DAL.Data
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? CreatedOn{ get; set; } = DateTime.UtcNow;
        public string? CreatedBy{ get; set; }
		public DateTime? LastUpdatedDate { get; set; } = DateTime.UtcNow;
		public string? LastUpdatedBy { get; set; }
		public int? StatusID { get; set; }
	}
}
