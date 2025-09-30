using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{

    internal class User : BaseEntity<int> {

    public User(int id, string name, string password, string login, string email, DateTime dateRegister, DateTime dateLogin, string state, Boolean active) : base(id)
        {
            Name = name;
            Password = password;
            State = state;
            Login = login;
            Email = email;
            DateRegister = dateRegister;
            DateLogin = dateLogin;
            Active = active;
        }

    public string Name { get; set; }
    public string State { get; set; }
    public string Password { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public DateTime DateRegister { get; set; }
    public DateTime DateLogin { get; set; }
    public Boolean Active { get; set; }

    }
}
