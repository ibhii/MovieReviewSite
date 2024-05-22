using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Models.Password.Requests;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Repositories.Password;

public partial class PasswordRepository
{
    public async Task ChangePasswordByUserId(int id,UpdatePasswordRequest dto)
    {
        if (dto.CurrentPassword.IsNullOrEmpty() || dto.NewPassword.IsNullOrEmpty() )
        {
            throw new BadHttpRequestException("please enter a valid value for all the fields");
        }
        if (dto.CurrentPassword == dto.NewPassword)
        {
            throw new BadHttpRequestException("the new password shouldn't be the same as your current password!");
        }

        if (id != dto.ModifierId)
        {
            throw new BadHttpRequestException("you are not allowed to change other users passwords!");
        }
        //checks if the current password is correct 
        var isCurrentCorrect = await AuthorizeUserPassword(dto.CurrentPassword!, id);
        if (!isCurrentCorrect)
        {
            throw new BadHttpRequestException("the password you entered as your current password is invalid!");
        }

        var hashedPassword = await HashPassword(dto.NewPassword!);
        //adds the ne password to passwords table
        var newPassword = new DataBase.Password()
        {
            UserId = id,
            HashPassword = hashedPassword
        };
        await _context.Passwords.AddAsync(newPassword);
        await _context.SaveChangesAsync();

        //adds the new password to userPassword table
        var userPassword = new UserPassword()
        {
            UserId = id,
            PasswordId = newPassword.Id,
        };
        await _context.UserPasswords.AddAsync(userPassword);
        await _context.SaveChangesAsync();
    }

}
