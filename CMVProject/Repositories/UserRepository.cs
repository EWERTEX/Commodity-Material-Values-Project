using CMVProject.DataBase;
using CMVProject.Models;

namespace CMVProject.Repositories;

public class UserRepository : IRepository<User>
{
    private CMVContext _db;

    public UserRepository(CMVContext context)
    {
        _db = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _db.Users;
    }

    public User? Get(int id)
    {
        return _db.Users.Find(id);
    }

    public User Create(User user)
    {
        _db.Users.Add(user);
        return user;
    }

    public User? Update(User user)
    {
        var updatingUser = _db.Users.FirstOrDefault(u => u.Id == user.Id);

        if (updatingUser == null)
            return updatingUser;

        updatingUser.Name = user.Name;
        updatingUser.Surname = user.Surname;
        updatingUser.Patronymic = user.Patronymic;

        return user;
    }

    public User? Delete(int id)
    {
        var user = _db.Users.Find(id);

        if (user != null)
            _db.Users.Remove(user);
        return user;
    }
}