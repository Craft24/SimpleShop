using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class User: MyObject
    {
        [Required]
        [StringLength(20,ErrorMessage ="用户名长度只能在6-20个字符之间",MinimumLength =6)]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Passwd { get; set; }

        [Required]
        public virtual string Salt { get; set; }

        public virtual string QQ { get; set; }

        public virtual string TelPhone { get; set; }

        [Required]
        public virtual string CellPhone { get; set; }
        
        /// <summary>
        /// 0男，1女，2其他
        /// </summary>
        public virtual int Sex { get; set; }

        public User()
        {
            Sex = 0;
        }
    }
}