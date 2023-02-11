using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.Context;
using OrderHandler.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.DB.Provider;

public static class UserDataProvider
{
    public static UserData? GetUserDataById(int id)
        => getUserDataById(new UserDataContext(), id);

    public static IEnumerable<UserData> GetUsersDataById(IEnumerable<int> ids)
        => getUsersDataById(new UserDataContext(), ids);
    
    public static UserData? GetUserDataByLogin(string login)
        => getUserDataByLogin(new UserDataContext(), login);
    
    public static IEnumerable<UserData> GetUsersDataByLogin(IEnumerable<string> logins)
        => getUsersDataByLogin(new UserDataContext(), logins);




    private static readonly Func<UserDataContext, int, UserData?> getUserDataById =
        EF.CompileQuery((UserDataContext db, int id) =>
            db.Users.FirstOrDefault(user => user.Id == id));

    private static readonly Func<UserDataContext, IEnumerable<int>, IEnumerable<UserData>> getUsersDataById =
        EF.CompileQuery((UserDataContext db, IEnumerable<int> ids) =>
            db.Users.Where(user => ids.Contains(user.Id)));

    private static readonly Func<UserDataContext, string, UserData?> getUserDataByLogin =
        EF.CompileQuery((UserDataContext db, string login) =>
            db.Users.FirstOrDefault(user => user.Login == login));

    private static readonly Func<UserDataContext, IEnumerable<string>, IEnumerable<UserData>> getUsersDataByLogin =
        EF.CompileQuery((UserDataContext db, IEnumerable<string> logins) =>
            db.Users.Where(user => logins.Contains(user.Login)));
}
