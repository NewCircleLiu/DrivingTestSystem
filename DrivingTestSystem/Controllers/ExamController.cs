using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrivingTestSystem.Utils;
using DrivingTestSystem.Models.Subject;

namespace DrivingTestSystem.Controllers
{
    public class ExamController : Controller
    {
        //
        // GET: /Exam/
        private SubjectContext sc = new SubjectContext();
        private Subject[] getRandomList(Subject[] oldList)
        {
            if (oldList.Length == 1)
            {
                return oldList;
            }
            //生成一个新数组：用于在之上计算和返回
            Subject[] temp;
            temp = new Subject[oldList.Length];
            for (int i = 0; i < oldList.Length; i++)
            {
                temp[i] = oldList[i];
            }
            //打乱数组中元素顺序
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < temp.Length; i++)
            {
                int x, y;
                Subject t;
                x = rand.Next(0, temp.Length);
                do
                {
                    y = rand.Next(0, temp.Length);
                } while (y == x);
                t = temp[x];
                temp[x] = temp[y];
                temp[y] = t;
            }
            return temp;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult setLan(string lan) //设置新的的语言
        {
            Session["language"] = lan;
            return Content(lan);
        }
        [HttpPost]
        public ActionResult getLan()  //获得当前的语言
        {
            string lan = (string)Session["language"];
            return Content(lan);
        }
        [UserAuthorize]
        public ActionResult SubjectOnePage()
        {
            return View();
        }
        [UserAuthorize]
        public ActionResult SubjectFourPage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FourPuzzle(string ctype, string language = "ch")
        {
            Subject[] sOld = sc.SubjectList.Where(s => s.subject_ctype == ctype && s.subject_class == "4").ToArray();
            Subject[] sArray = getRandomList(sOld);
            ViewBag.len = sArray.Length > 100 ? 100 :sArray.Length;
            ViewBag.nowIndex = 0;
            ViewBag.language = language;
            return View(sArray);
        }
        [HttpPost]
        public JsonResult CheckAnswer(string user_answer, int subject_id)
        {
            Subject exist = sc.SubjectList.Where(s => s.subject_id == subject_id).FirstOrDefault();
            if (exist.subject_answer == user_answer)
            {
                return Json("ok");
            }
            else
            {
                return Json(exist.subject_answer);
            }
        }
    }
}
