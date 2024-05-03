using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    //user sign up
    public async Task AddUser(NewUserRequest dto)
    {
        //gets all users list to check username
        var allUsers = await GetAllUsers();
        
        //checks to see if input parameters are correct
        if (dto.Password.IsNullOrEmpty() || dto.Password.Length < 4)
        {
            throw new ArgumentException("the password you have entered is invalid!");
        }
        if (Enumerable.Any<BaseUser>(allUsers, u => u.UserName == dto.UserName) || dto.UserName.IsNullOrEmpty())
        {
            throw new ArgumentException("this username you  have entered is invalid!");
        }
        
        //creating user
        var newUser = new DataBase.User()
        {
            UserName = dto.UserName,
            RoleCode = 2,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            IsActive = true,
            IsVisible = true,
            IsEmailConfirmed = false,
            CreatedOn = DateTime.UtcNow,
            LastModifiedOn = DateTime.UtcNow
        };
        var user =  await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        
        //adding password
        var newPassword = new DataBase.Password()
        {
            UserId = user.Entity.Id,
            Password1 = dto.Password
        };
        var password = await _context.Passwords.AddAsync(newPassword);
        user.Entity.PasswordId = password.Entity.Id;
        _context.Users.Update(user.Entity);
        await _context.SaveChangesAsync();
        
        //adding the password and user to the joint table
        var userPassword = new DataBase.UserPassword()
        {
            UserId = user.Entity.Id,
            PasswordId = password.Entity.Id
        };
        await _context.UserPasswords.AddAsync(userPassword);
        await _context.SaveChangesAsync();
    }
}
