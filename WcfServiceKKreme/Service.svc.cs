using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using WcfServiceKKreme.Models;
using WcfServiceKKreme.Repository;

namespace WcfServiceKKreme
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    //[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class Service : IService
    {
        public OperationRepository operation;

        Service()
        {
            operation = new OperationRepository();
        }

        public ResponseBase<Coupon> AllCopuon()
        {
            return operation.GetCoupons();
        }

        public ResponseBase<Coupon> RemoveCopuon(string id)
        {
            return operation.DeleteCouponById(Convert.ToInt32(id));
        }

        public ResponseBase<User> ShowUserById(string id)
        {
            return operation.GetUserById(Convert.ToInt32(id));
        }

        public ResponseBase<Coupon> ShowCopuonById(string id)
        {
            return operation.GetCouponById(Convert.ToInt32(id));
        }

        public ResponseBase<Coupon> PostCoupon(Coupon coupon)
        {
            return operation.InsertCoupon(coupon);
        }

        public ResponseBase<Coupon> UpdateCoupon(Coupon coupon, string id)
        {
            return operation.UpdateCouponById(coupon, Convert.ToInt32(id));
        }

        public ResponseBase<Status> AllStaus()
        {
            return operation.GetStatus();
        }

        public ResponseBase<Establishment> AllEstablishment()
        {
            return operation.GetEstablishments();
        }

        public ResponseBase<Coupon> ExchangeCoupon(Coupon coupon, string id)
        {
            return operation.ExchangeCouponById(coupon, Convert.ToInt32(id));
        }
    }
}
