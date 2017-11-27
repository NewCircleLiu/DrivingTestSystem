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
        public int subject_id { get; set; }  //题目ID
        public string subject_content { get; set; }   //题目汉语
        public string subject_content_tibetan { get; set; }   //题目藏语
        public string subject_class { get; set; }       //科目几:一 or 四
        public string subject_type { get; set; }        //是什么类型：选择判断  S/J
        public string subject_ctype { get; set; }       //题目内容类型：速度、距离等等等
        public string subject_A { get; set; }           //汉语选项A
        public string subject_B { get; set; }           //汉语选项B
        public string subject_C { get; set; }           //汉语选项C
        public string subject_D { get; set; }           //汉语选项D
        public string subject_A_tibetan { get; set; }   //藏语选项A
        public string subject_B_tibetan { get; set; }   //藏语选项B
        public string subject_C_tibetan { get; set; }   //藏语选项C
        public string subject_D_tibetan { get; set; }   //藏语选项D
        public string subject_answer { get; set; }      //正确答案
        public string subject_img { get; set; }         //图片链接  
        public string subject_video { get; set; }       //动画链接
        public string subject_sound_content { get; set; }   //题目内容（汉语）的音频链接
        public string subject_sound_content_tibetan { get; set; }   //题目内容（藏语）的音频链接
        public string subject_sound_trick { get; set; }     //答题技巧汉
        public string subject_sound_trick_tibetan { get; set; }   //答题技巧藏
    }
}