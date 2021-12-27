using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceKKreme.Models;

namespace WcfServiceKKreme
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]

    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "users/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseBase<User> ShowUserById(string id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "coupons", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [Description("Mensjae xd")]
        ResponseBase<Coupon> AllCopuon();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "coupons/{id}", ResponseFormat = WebMessageFormat.Json)]
        ResponseBase<Coupon> ShowCopuonById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "coupons", ResponseFormat = WebMessageFormat.Json)]
        ResponseBase<Coupon> StoreCoupon(Coupon coupon);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", UriTemplate = "coupons/{id}", ResponseFormat = WebMessageFormat.Json)]
        //ResponseBase<Coupon> UpdateCoupon(Coupon coupon);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE", UriTemplate = "coupons/{id}", ResponseFormat = WebMessageFormat.Json)]
        //ResponseBase<Coupon> RemoveCopuon(Coupon coupon);
    }
}
