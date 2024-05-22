using Microsoft.AspNetCore.Http;
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
        var isUsernameDuplicate = await DoesUsernameExist(dto.UserName);
        var isEmailDuplicate = await DoesEmailExist(dto.Email);
        
        //checks to see if input parameters are correct
        if (dto.Password.IsNullOrEmpty() || dto.Password.Length < 4)
        {
            throw new BadHttpRequestException("the password you have entered is invalid!");
        }
        if (isUsernameDuplicate || dto.UserName.IsNullOrEmpty())
        {
            throw new BadHttpRequestException("this username you  have entered is invalid or already exists!");
        }
        if (isEmailDuplicate || dto.Email.IsNullOrEmpty())
        {
            throw new BadHttpRequestException("this email you  have entered is invalid or already exists!");
        }
        
        //creating user
        var newUser = new DataBase.User()
        {
            UserName = dto.UserName,
            RoleCode = 2,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            IsActive = true,
            IsVisible = true,
            IsEmailConfirmed = false,
            CreatedOn = DateTime.UtcNow,
            LastModifiedOn = DateTime.UtcNow
        };
        var user =  await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        var hashPassword =  await _passwordRepository.HashPassword(dto.Password);
        //adding password
        var newPassword = new DataBase.Password()
        {
            UserId = user.Entity.Id,
            HashPassword = hashPassword,
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
