using WebAPIProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIProject.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> RegisterAsync(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserStore<IdentityUser> store = new UserStore<IdentityUser>(new ApplicationDbContext());
                UserManager<IdentityUser> manager = new UserManager<IdentityUser>(store);
                IdentityUser user = new IdentityUser();
                user.UserName = model.UserName;
                user.PasswordHash = model.Password;
                IdentityResult result = await manager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Created("", "Registration Succeeded" + user.UserName);
                }
                else
                {
                    string errors = "";
                    foreach (var str in errors)
                        errors += str + "\n";
                    return BadRequest(errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
