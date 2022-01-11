using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WcfServiceKKreme.DataAccess;
using WcfServiceKKreme.Models;

namespace WcfServiceKKreme.Repository
{
    public class OperationRepository : IOperation
    {
        ClsDataBase clsDataBase;

        public OperationRepository()
        {
            clsDataBase = new ClsDataBase();
        }

        public ResponseBase<Coupon> DeleteCouponById(int id)
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                clsDataBase.Save("DELETE_COUPONS_BY_ID", EAction.DELETE, null, id);

                ResponseBase.EliminacionCorrecta();
            }
            catch (Exception)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la consulta";
            }

            return ResponseBase;
        }

        public ResponseBase<Coupon> GetCouponById(int id)
        {
            Coupon coupon = null;
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                var dt = new DataTable();

                dt = clsDataBase.GetData("GET_COUPON_BY_ID", EAction.SELECTBYID, id);
                if (dt == null || dt.Rows.Count == 0)
                {
                    ResponseBase.ConsultaNoEncontrada();
                    return ResponseBase;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    coupon = new Coupon();
                    coupon.Id = Convert.ToInt32(drow["id"]);
                    coupon.Duration = drow["duration"].ToString();
                    coupon.Serie = drow["serie"].ToString();
                    coupon.Description = drow["description"].ToString();
                    coupon.CreatedAt = drow["CreatedAt"].ToString();
                    coupon.Status = new Status
                    {
                        Id = Convert.ToInt32(drow["stId"]),
                        Name = drow["Status"].ToString(),
                    };
                    coupon.Establishment = new Establishment
                    {
                        Id = Convert.ToInt32(drow["estId"]),
                        Name = drow["establishment"].ToString(),
                    };
                }

                ResponseBase.Element = coupon;
                ResponseBase.ConsultaCorrecta();

            }
            catch (Exception ex)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la consulata";
            }

            return ResponseBase;
        }

        public ResponseBase<Coupon> GetCoupons()
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();
            List<Coupon> coupons = new List<Coupon>();

            try
            {
                var dt = new DataTable();

                dt = clsDataBase.GetData("GET_COUPONS", EAction.SELECT);
                if (dt == null || dt.Rows.Count == 0)
                {
                    ResponseBase.ConsultaNoEncontrada();
                    return ResponseBase;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    var coupon = new Coupon();
                    coupon.Id = Convert.ToInt32(drow["id"]);
                    coupon.Duration = drow["duration"].ToString();
                    coupon.Serie = drow["serie"].ToString();
                    coupon.Description = drow["Description"].ToString();
                    coupon.CreatedAt = drow["CreatedAt"].ToString();
                    coupon.Status = new Status
                    {
                        Id = Convert.ToInt32(drow["stId"]),
                        Name = drow["Status"].ToString(),
                    };
                    coupon.Establishment = new Establishment
                    {
                        Id = Convert.ToInt32(drow["estId"]),
                        Name = drow["establishment"].ToString(),
                    };

                    coupons.Add(coupon);
                }

                ResponseBase.List = coupons;
                ResponseBase.ConsultaCorrecta();
            }
            catch (Exception ex)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la consulata";
            }

            return ResponseBase;
        }

        public ResponseBase<User> GetUserById(int id)
        {
            User user = null;
            ResponseBase<User> ResponseBase = new ResponseBase<User>();

            try
            {
                var dt = new DataTable();
                dt = clsDataBase.GetData("GET_USER_BY_ID", EAction.SELECTBYID, id);

                if (dt == null || dt.Rows.Count == 0)
                {
                    ResponseBase.ConsultaNoEncontrada();
                    return ResponseBase;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    user = new User();
                    user.Id = Convert.ToInt32(drow["id"]);
                    user.Name = drow["name"].ToString();
                    user.LastName = drow["lastName"].ToString();
                }

                user.Permissions = GetPermissionsUserById(id);
                user.Roles = GetRolesUserById(id);

                ResponseBase.Element = user;
                ResponseBase.ConsultaCorrecta();
            }
            catch (Exception ex)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la consulata";
            }

            return ResponseBase;
        }

        public List<Permission> GetPermissionsUserById(int id)
        {
            List<Permission> listPermissions = new List<Permission>();
            try
            {
                var dt = new DataTable();
                dt = clsDataBase.GetData("GET_PERMISSIONS_USER_BY_ID", EAction.SELECTBYID, id);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return listPermissions;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    var permission = new Permission();
                    permission.Id = Convert.ToInt32(drow["id"]);
                    permission.Name = drow["name"].ToString();
                    listPermissions.Add(permission);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listPermissions;
        }

        public List<Role> GetRolesUserById(int id)
        {
            List<Role> listRoles = new List<Role>();
            try
            {
                var dt = new DataTable();
                dt = clsDataBase.GetData("GET_ROLES_USER_BY_ID", EAction.SELECTBYID, id);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return listRoles;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    var Role = new Role();
                    Role.Id = Convert.ToInt32(drow["id"]);
                    Role.Name = drow["name"].ToString();
                    listRoles.Add(Role);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listRoles;
        }

        public ResponseBase<Coupon> InsertCoupon(Coupon coupon)
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                clsDataBase.Save("INSERT_COUPONS", EAction.INSERT, coupon);

                ResponseBase.CreacionCorrecta();
            }
            catch (Exception)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la inserción";
            }

            return ResponseBase;
        }

        public ResponseBase<Coupon> UpdateCouponById(Coupon coupon, int id)
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                clsDataBase.Save("UPDATE_COUPONS_BY_ID", EAction.UPDATE, coupon, id);

                ResponseBase.ActualizacionCorrecta();
            }
            catch (Exception)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la actualizacion";
            }

            return ResponseBase;
        }

        public ResponseBase<Status> GetStatus()
        {
            ResponseBase<Status> ResponseBase = new ResponseBase<Status>();
            List<Status> listStatus = new List<Status>();

            try
            {
                var dt = new DataTable();

                dt = clsDataBase.GetData("GET_STATUS", EAction.SELECT);
                if (dt == null || dt.Rows.Count == 0)
                {
                    ResponseBase.ConsultaNoEncontrada();
                    return ResponseBase;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    var Status = new Status();
                    Status.Id = Convert.ToInt32(drow["id"]);
                    Status.Name = drow["name"].ToString();
                    listStatus.Add(Status);
                }

                ResponseBase.List = listStatus;
                ResponseBase.ConsultaCorrecta();
            }
            catch (Exception ex)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la consulta";
            }

            return ResponseBase;
        }

        public ResponseBase<Establishment> GetEstablishments()
        {
            ResponseBase<Establishment> ResponseBase = new ResponseBase<Establishment>();
            List<Establishment> ListEstablishments = new List<Establishment>();

            try
            {
                var dt = new DataTable();

                dt = clsDataBase.GetData("GET_ESTABLISHMENT", EAction.SELECT);
                if (dt == null || dt.Rows.Count == 0)
                {
                    ResponseBase.ConsultaNoEncontrada();
                    return ResponseBase;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    var Establishment = new Establishment();
                    Establishment.Id = Convert.ToInt32(drow["id"]);
                    Establishment.Name = drow["name"].ToString();
                    ListEstablishments.Add(Establishment);
                }

                ResponseBase.List = ListEstablishments;
                ResponseBase.ConsultaCorrecta();
            }
            catch (Exception ex)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la consulta";
            }

            return ResponseBase;
        }


        public ResponseBase<Coupon> ExchangeCouponById(Coupon coupon, int id)
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                int res = clsDataBase.Save("EXCHANGE_COUPONS_BY_ID", EAction.UPDATE, coupon, id);

                ResponseBase.Value = res;
                ResponseBase.ActualizacionCorrecta();
            }
            catch (Exception)
            {
                ResponseBase.CodeResult = 500;
                ResponseBase.Messaje = "Error al realizar la actualizacion";
            }

            return ResponseBase;
        }
    }
}