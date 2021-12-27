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

        public ResponseBase<Coupon> DeleteCouponById(Coupon coupon)
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                clsDataBase.Save("DELETE_COUPONS_BY_ID", coupon, EAction.DELETE);

                ResponseBase.EliminacionCorrecta();
            }
            catch (Exception)
            {
                ResponseBase.codigoResultado = 500;
                ResponseBase.mensaje = "Error al realizar la consulta";
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

                dt = clsDataBase.GetData("GET_USER_BY_ID", EAction.SELECTBYID, id);
                if (dt == null || dt.Rows.Count == 0)
                {
                    ResponseBase.ConsultaNoEncontrada();
                    return ResponseBase;
                }

                foreach (DataRow drow in dt.Rows)
                {
                    coupon = new Coupon();
                    coupon.Id = Convert.ToInt32(drow["id"]);
                    coupon.Duration = Convert.ToDateTime(drow["duration"]);
                    coupon.Serie = drow["serie"].ToString();
                    coupon.Description = drow["Description"].ToString();
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

                ResponseBase.elemento = coupon;
                ResponseBase.ConsultaCorrecta();

            }
            catch (Exception ex)
            {
                ResponseBase.codigoResultado = 500;
                ResponseBase.mensaje = "Error al realizar la consulata";
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
                    coupon.Duration = Convert.ToDateTime(drow["duration"]);
                    coupon.Serie = drow["serie"].ToString();
                    coupon.Description = drow["Description"].ToString();
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

                ResponseBase.lista = coupons;
                ResponseBase.ConsultaCorrecta();
            }
            catch (Exception ex)
            {
                ResponseBase.codigoResultado = 500;
                ResponseBase.mensaje = "Error al realizar la consulata";
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

                    user.Roles = new List<Role>();
                    if (String.IsNullOrEmpty(drow["RoleId"].ToString()))
                    {
                        user.Roles.Add(new Role()
                        {
                            Id = Convert.ToInt32(drow["RoleId"]),
                            Name = drow["RoleName"].ToString(),
                        });
                    }

                    user.Permissions = new List<Permission>();
                    if (String.IsNullOrEmpty(drow["RoleId"].ToString()))
                    {
                        user.Permissions.Add(new Permission()
                        {
                            Id = Convert.ToInt32(drow["RoleId"]),
                            Name = drow["RoleName"].ToString(),
                        });
                    }
                }

                ResponseBase.elemento = user;
                ResponseBase.ConsultaCorrecta();
            }
            catch (Exception ex)
            {
                ResponseBase.codigoResultado = 500;
                ResponseBase.mensaje = "Error al realizar la consulata";
            }

            return ResponseBase;
        }

        public ResponseBase<Coupon> InsertCoupon(Coupon coupon)
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                clsDataBase.Save("INSERT_COUPONS", coupon, EAction.INSERT);

                ResponseBase.CreacionCorrecta();
            }
            catch (Exception)
            {
                ResponseBase.codigoResultado = 500;
                ResponseBase.mensaje = "Error al realizar la inserción";
            }

            return ResponseBase;
        }

        public ResponseBase<Coupon> UpdateCouponById(Coupon coupon)
        {
            ResponseBase<Coupon> ResponseBase = new ResponseBase<Coupon>();

            try
            {
                clsDataBase.Save("UPDATE_COUPONS_BY_ID", coupon, EAction.UPDATE);

                ResponseBase.ActualizacionCorrecta();
            }
            catch (Exception)
            {
                ResponseBase.codigoResultado = 500;
                ResponseBase.mensaje = "Error al realizar la actualizacion";
            }

            return ResponseBase;
        }
    }
}