namespace JWT_AUTH_DOT_NET.Model
{
    public class Registration
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string  password{ get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
    }
}
