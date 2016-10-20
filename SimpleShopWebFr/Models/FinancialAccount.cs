using System.ComponentModel.DataAnnotations;

namespace SimpleShopWebFr.Models
{
    public class FinancialAccount : MyObject
    {
        /// <summary>
        /// 账户余额，单位为分
        /// </summary>
        [Required]
        public virtual int Balance { get; set; }

        [Required]
        public virtual Member Member { get; set; }

        public virtual string AlipayAccount { get; set; }

        public virtual string WechatPayAccount { get; set; }

        public FinancialAccount()
        {
            Balance = 0;
        }
    }
}