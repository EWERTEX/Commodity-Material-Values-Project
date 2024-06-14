using CMVProject.Models;
using CMVProject.Units;

namespace CMVProject.Controllers;

public class UserController
{
    private readonly UnitOfWork _unitOfWork;

    public UserController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _unitOfWork.Users.GetAll();
    }

    public User? GetUserById(int id)
    {
        return _unitOfWork.Users.Get(id);
    }

    public void EditUser(User user)
    {
        _unitOfWork.Users.Update(user);
        _unitOfWork.Save();
    }

    public void RegisterUser(User user)
    {
        _unitOfWork.Users.Create(user);
        _unitOfWork.Save();
    }

    public void DeleteUser(int id)
    {
        _unitOfWork.Users.Delete(id);
        _unitOfWork.Save();
    }
}