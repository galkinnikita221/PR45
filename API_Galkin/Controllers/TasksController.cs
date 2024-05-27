using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Galkin.Controllers
{
    [Route("api/TasksController")]
    public class TasksController : Controller
    {
        ///<summary>
        ///Получение списка задач
        /// </summary>
        /// <remarks>Данный метод получает список задач, находящихся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code ="500">При выполнении запроса произошла ошибка</respinse>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Tasks> Tasks = new TasksContext().Tasks;
                return Json(Tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        ///Получение задачи
        /// </summary>
        /// <remarks>Данный метод получает задачу, находящуюся в базе данных</remarks>
        /// <response code="200">Задача выполнена успешно</response>
        /// <response code="500">При выполнении задачи произошла ошибка</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Tasks), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                Tasks Task = new TasksContext().Tasks.Where(x => x.Id == Id).First();
                return Json(Task);
            }
            catch (Exception exp) {
                return StatusCode(500);
            }
        }
    }
}
