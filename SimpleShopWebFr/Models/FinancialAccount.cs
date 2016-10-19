namespace SimpleShopWebFr.Models
{
    public class FinancialAccount
    {
        public int Id { get; set; }

        /// <summary>
        /// 账户余额，单位为分
        /// </summary>
        public int Balance { get; set; }

        public virtual Member Member { get; set; }
    }
}