using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrivingTestSystem.Utils;
using DrivingTestSystem.Models.Subject;

namespace DrivingTestSystem.Utils
{
    public class Subject2InfoController : Controller
    {
        //
        // GET: /Subject2Info/
        private Subject2_PicEntities1 pics = new Subject2_PicEntities1();
        private Subject2_SoundEntities sounds = new Subject2_SoundEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult getPic(string xh="10029")
        {
            if (xh != null || xh != "")
            {
                var pic = pics.EXAM_TK_TP.Where(p => p.STXH == xh).FirstOrDefault();
                byte[] bytes = Convert.FromBase64String(pic.TPNR);
                return File(bytes, "image/gif");
            }
            else
            {
                return Content("");
            }
        }
        [HttpGet]
        public ActionResult getSound(string xh)
        {
            if (xh != null || xh != "")
            {
                var sound = sounds.EXAM_TK_YY_ADY.Where(tk_s => tk_s.STXH == xh).FirstOrDefault();
                byte[] bytes = Convert.FromBase64String(sound.YYNR);
                return File(bytes, "audio/mp3");
            }
            else
            {
                return Content("");
            }
        }

    }
}
