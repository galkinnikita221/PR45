using API_Galkin.Context;
using API_Galkin.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_Galkin.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class UsersController : Controller
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Данный метод преднозначен для авторизации пользователя на сайте</returns>
        /// <response code="200">Пользователь успешно авторизован</response>
        /// <response code="403">Ошибка запроса, данные не указаны</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [HttpPost("SignIn")]
        public ActionResult SingIn([FromForm] string Login, [FromForm] string Password)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                return StatusCode(403, "Необходимо указать логин и пароль");

            try
            {
                using (var context = new UsersContext())
                {
                    Users user = context.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password);
                    if (user == null)
                    {
                        return StatusCode(403, "Неверные учетные данные");
                    }

                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
