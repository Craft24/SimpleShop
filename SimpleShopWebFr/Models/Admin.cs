namespace SimpleShopWebFr.Models
{
    public class Admin : User
    {
        /// <summary>
        /// 管理员状态，0是待审核，1是正常
        /// </summary>
        public int Status { get; set; }

        public Admin()
        {
            Status = 0;
        }
    }
}