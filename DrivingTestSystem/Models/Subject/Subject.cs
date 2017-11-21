using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DrivingTestSystem.Models.Subject
{
    public class Subject
    {
        [Key]
        public int subject_id { get; set; }
        public string subject_content { get; set; }   //汉语,藏语
        public string subject_which { get; set; }   //科目几:一 or 四
        public string subject_type { get; set; }    //是什么类型：选择判断
        public string subject_ctype { get; set; }   //题目内容类型：速度、距离等等等
        public string subject_A { get; set; } //汉语,藏语
        public string subject_B { get; set; } //汉语,藏语
        public string subject_C { get; set; } //汉语,藏语
        public string subject_D { get; set; } //汉语,藏语
        public string subject_img { get; set; }
        public string subject_answer { get; set; } //正确答案
        public string subject_video { get; set; }//动画题目
        public string subject_sound_content { get; set; }//题目内容的音频
        public string subject_sound_trick { get; set; } //题目的技巧

    }
}