using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceKKreme.Models;

namespace WcfServiceKKreme.Repository
{
    internal interface IOperation
    {
        ResponseBase<User> GetUserById(int id);

        ResponseBase<Coupon> InsertCoupon(Coupon coupon);
        ResponseBase<Coupon> GetCoupons();
        ResponseBase<Coupon> GetCouponById(int id);
        ResponseBase<Coupon> UpdateCouponById(Coupon coupon);
        ResponseBase<Coupon> DeleteCouponById(Coupon coupon);
    }
}
