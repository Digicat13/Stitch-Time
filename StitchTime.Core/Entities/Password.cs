namespace StitchTime.Core.Entities
{
    public class Password : IEntity<int>
    {
        public int Id { get; set; }

        public string PasswordValue { get; set; }

        public User User { get; set; }
    }
}
