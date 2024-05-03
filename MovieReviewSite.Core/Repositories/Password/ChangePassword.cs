using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Models.Password.Requests;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Repositories.Password;

public partial class PasswordRepository
{
    public async Task ChangePassword(UpdatePasswordRequest dto)
    {
        if (dto.CurrentPassword.IsNullOrEmpty() || dto.NewPassword.IsNullOrEmpty() )
        {
            throw new ArgumentException("please enter a valid value for all the fields");
        }
        if (dto.CurrentPassword == dto.NewPassword)
        {
            throw new ArgumentException("the new password shouldn't be the same as your current password!");
        }
        
        //checks if the current password is correct 
        var isCurrentCorrect = await AuthorizeUserPassword(dto.CurrentPassword!, dto.UserId);
        if (!isCurrentCorrect)
        {
            throw new ArgumentException("the password you entered as your current password is invalid!");
        }

        //adds the ne password to passwords table
        var newPassword = new DataBase.Password()
        {
            UserId = dto.UserId,
            Password1 = dto.NewPassword
        };
        await _context.Passwords.AddAsync(newPassword);
        await _context.SaveChangesAsync();

        //adds the new password to userPassword table
        var userPassword = new UserPassword()
        {
            UserId = dto.UserId,
            PasswordId = newPassword.Id,
        };
        await _context.UserPasswords.AddAsync(userPassword);
        await _context.SaveChangesAsync();
    }

}
