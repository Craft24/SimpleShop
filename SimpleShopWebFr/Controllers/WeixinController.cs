using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;
using Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleShopWebFr.Controllers
{
    public class WeixinController : Controller
    {
        public readonly string Token = ConfigurationManager.AppSettings["Token"].ToString();
        public readonly string AppId = ConfigurationManager.AppSettings["AppId"].ToString();
        public readonly string EncodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"].ToString();
        // GET: Weixin
        public ActionResult Index(PostModel postModel,string echostr)
        {
            if (CheckSignature.Check(postModel.Signature,postModel.Timestamp,postModel.Nonce, Token))
            {
                return Content(echostr);
            }
            else
            {
                return Content("failed:"+Token+"," + postModel.Signature + ","
                    + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        [HttpPost]
        public ActionResult Index(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content("参数错误！");
            }

            postModel.Token = Token;
            postModel.EncodingAESKey = EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = AppId;//根据自己后台的设置保持一致
            
            var messageHandler = new CustomMessageHandler(Request.InputStream, postModel);//接收消息（第一步）

            messageHandler.Execute();//执行微信处理过程（第二步）

            return new FixWeixinBugWeixinResult(messageHandler);//返回（第三步）
        }
    }
}