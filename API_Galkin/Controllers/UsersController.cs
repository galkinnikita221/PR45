using API_Galkin.Context;
using API_Galkin.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_Galkin.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
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
        public ActionResult SingIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null)
                return StatusCode(403);
            try
            {
                Users User = new UsersContext().Users.Where(x => x.Login == Login && x.Password == Password).First();
                return Json(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
