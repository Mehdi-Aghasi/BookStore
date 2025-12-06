namespace BookStore.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public DateTime CreateAt { get; set; }=DateTime.UtcNow;
        public DateTime? UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
