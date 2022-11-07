using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Utility;
using ViewModels;

namespace BusinessLogicLayer
{
    public class RepairCrud:IDisposable
    {
        RepairsRepository db=new RepairsRepository();
        public bool Create(Repair repair)
        {
            try
            {
                db.InsertRepair(repair);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(Repair repair)
        {
            try
            {
                db.UpdateRepair(repair);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.DeleteRepair(id);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RepairViewModel> Read()
        {
            List<RepairViewModel> Repairs=new List<RepairViewModel>();
            foreach (DataRow item in db.GetAllRepairsBySql().Rows)
            {
                Repairs.Add(new RepairViewModel()
                {
                    ReceptionNumber = item[0].ToString(),
                    Model = item[1].ToString(),
                    BarCode = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi(),
                    Description = item[4].ToString(),
                    CustomerName = item[5].ToString(),
                    PhoneNumber = item[6].ToString(),
                    PhoneId = int.Parse(item[7].ToString())
                });
            }

            return Repairs;
        }

        public Customer GetCustomer(string number)
        {
            CustomerRepository cr=new CustomerRepository();
            return cr.GetCustomerByPhone(number);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Repair Find(int id)
        {
            return db.GetRepairById(id);
        }
    }
}
