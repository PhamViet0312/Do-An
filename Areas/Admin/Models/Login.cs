using Do_An.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Areas.Admin.Models
{
    [Area("Admin")]
    public class Login
    {
        private readonly MovieContext _dbcontext;


        public Login(MovieContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Checklogin(string useradmin, string password)
        {
            var login = _dbcontext.TbAccounts.FirstOrDefault(x => x.Username == useradmin);
            if (login == null)
            {
                return -2; 
            }
            else
            {
                if (login.IsActive == false)
                {
                    return 0; 
                }
                else
                {
                    if (login.Password == password)
                    {
                        return 1; 
                    }
                    else
                    {
                        return -1; 
                    }
                }


            }
        }
    }
}
