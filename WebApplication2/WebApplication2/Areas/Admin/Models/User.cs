namespace WebApplication2.Areas.Admin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string GroupId { get; set; }
        public bool IsDeleted { get; set; }
        public string GroupName { get; set; }
    }
}
