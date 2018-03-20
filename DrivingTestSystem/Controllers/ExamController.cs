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
        private Subject2Entities s2 = new Subject2Entities();
        private Subject2_PicEntities1 pic = new Subject2_PicEntities1();
        private Subject2_SoundEntities sound = new Subject2_SoundEntities();

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
        [HttpGet]
        public ActionResult OnePuzzle()
        {
            EXAM_TK[] tk = s2.EXAM_TK.ToArray();
            List<Subject> list = new List<Subject>();
            for (int i = 0; i < tk.Length; i++)
            {
                Subject s = new Subject();
                s.subject_content = tk[i].STNRH;
                s.subject_content_tibetan = tk[i].STNRZ;
                if (tk[i].STTX.Equals("2")) //选择题
                {
                    s.subject_A = tk[i].XZDAAH;
                    s.subject_A_tibetan = tk[i].XZDAAZ;

                    s.subject_B = tk[i].XZDABH;
                    s.subject_B_tibetan = tk[i].XZDABZ;

                    s.subject_C = tk[i].XZDACH;
                    s.subject_C_tibetan = tk[i].XZDACZ;

                    s.subject_D = tk[i].XZDADH;
                    s.subject_D_tibetan = tk[i].XZDADZ;

                    s.subject_type = "C";
                }
                else {
                    s.subject_A = "正确";
                    s.subject_A_tibetan = "འགྲིག་པ།";
                    s.subject_B = "错误";
                    s.subject_B_tibetan = "ནོར་བ།";
                    s.subject_type = "J";
                }
                switch (tk[i].STDA)
                {
                    case "1":
                        s.subject_answer = "A";
                        break;
                    case "2":
                        s.subject_answer = "B";
                        break;
                    case "3":
                        s.subject_answer = "C";
                        break;
                    case "4":
                        s.subject_answer = "D";
                        break;
                    case "5":
                        s.subject_answer = "A";
                        break;
                    case "6":
                        s.subject_answer = "B";
                        break;
                }
                s.subject_id = int.Parse(tk[i].STXH);
                list.Add(s);
            }
            string lan = (string)Session["language"];
            //Subject[] sOld = sc.SubjectList.ToArray();
            Subject[] sArray = getRandomList(list.ToArray());
            List<Subject> s_a = new List<Subject>();
            int len = sArray.Length > 100 ? 100 : sArray.Length;
            ViewBag.len=len;
            for (int i = 0; i < len; i++) {
                string xh = sArray[i].subject_id.ToString();
                var pics = pic.EXAM_TK_TP.Where(p => p.STXH == xh).ToList();
                var sounds = sound.EXAM_TK_YY_ADY.Where(tk_s => tk_s.STXH == xh).ToList();
                if (pics.Count() > 0)
                {
                    sArray[i].subject_img = pics[0].STXH;
                }
                if (sounds.Count() > 0)
                {
                    sArray[i].subject_sound_content_tibetan = sounds[0].STXH;
                }
                s_a.Add(sArray[i]);
            }
            ViewBag.nowIndex = 0;
            ViewBag.language = lan;
            return View(s_a.ToArray());
        }
        [UserAuthorize]
        [HttpGet]
        public ActionResult FourPuzzle() //科目四每题两分
        {
            EXAM_TK[] tk = s2.EXAM_TK.ToArray();
            List<Subject> list = new List<Subject>();
            for (int i = 0; i < tk.Length; i++)
            {
                Subject s = new Subject();
                s.subject_content = tk[i].STNRH;
                s.subject_content_tibetan = tk[i].STNRZ;
                if (tk[i].STTX.Equals("2")) //选择题
                {
                    s.subject_A = tk[i].XZDAAH;
                    s.subject_A_tibetan = tk[i].XZDAAZ;

                    s.subject_B = tk[i].XZDABH;
                    s.subject_B_tibetan = tk[i].XZDABZ;

                    s.subject_C = tk[i].XZDACH;
                    s.subject_C_tibetan = tk[i].XZDACZ;

                    s.subject_D = tk[i].XZDADH;
                    s.subject_D_tibetan = tk[i].XZDADZ;

                    s.subject_type = "C";
                }
                else
                {
                    s.subject_A = "正确";
                    s.subject_A_tibetan = "འགྲིག་པ།";
                    s.subject_B = "错误";
                    s.subject_B_tibetan = "ནོར་བ།";
                    s.subject_type = "J";
                }
                switch (tk[i].STDA)
                {
                    case "1":
                        s.subject_answer = "A";
                        break;
                    case "2":
                        s.subject_answer = "B";
                        break;
                    case "3":
                        s.subject_answer = "C";
                        break;
                    case "4":
                        s.subject_answer = "D";
                        break;
                    case "5":
                        s.subject_answer = "A";
                        break;
                    case "6":
                        s.subject_answer = "B";
                        break;
                }
                s.subject_id = int.Parse(tk[i].STXH);
                list.Add(s);
            }
            string lan = (string)Session["language"];
            //Subject[] sOld = sc.SubjectList.ToArray();
            Subject[] sArray = getRandomList(list.ToArray());
            List<Subject> s_a = new List<Subject>();
            int len = sArray.Length > 50 ? 50 : sArray.Length;
            ViewBag.len = len;
            for (int i = 0; i < len; i++)
            {
                string xh = sArray[i].subject_id.ToString();
                var pics = pic.EXAM_TK_TP.Where(p => p.STXH == xh).ToList();
                var sounds = sound.EXAM_TK_YY_ADY.Where(tk_s => tk_s.STXH == xh).ToList();
                if (pics.Count() > 0)
                {
                    sArray[i].subject_img = pics[0].STXH;
                }
                if (sounds.Count() > 0)
                {
                    sArray[i].subject_sound_content_tibetan = sounds[0].STXH;
                }
                s_a.Add(sArray[i]);
            }
            ViewBag.nowIndex = 0;
            ViewBag.language = lan;
            return View(s_a.ToArray());
        }
        [HttpPost]
        public JsonResult CheckAnswer(string user_answer, int subject_id)
        {
            string id = subject_id.ToString();
            var exist = s2.EXAM_TK.Where(tk => tk.STXH == id).FirstOrDefault();
            string subject_answer = "A";
            switch (exist.STDA)
            {
                case "1":
                    subject_answer = "A";
                    break;
                case "2":
                    subject_answer = "B";
                    break;
                case "3":
                    subject_answer = "C";
                    break;
                case "4":
                    subject_answer = "D";
                    break;
                case "5":
                    subject_answer = "A";
                    break;
                case "6":
                    subject_answer = "B";
                    break;
            }
            if (subject_answer == user_answer)
            {
                return Json("ok");
            }
            else
            {
                return Json(subject_answer);
            }
        }
    }
}
