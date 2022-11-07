using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Utility;
using ViewModels;

namespace BusinessLogicLayer
{
    public class PhoneCrud:IDisposable
    {
        PhoneRepository db=new PhoneRepository();

        public bool Create(Phone phone)
        {
            try
            {
                db.InsertPhone(phone);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PhoneViewModel> Read()
        {
            List<PhoneViewModel> Phones=new List<PhoneViewModel>();
            string Text = "";
            string visit = "";
            string end = "---";
            foreach (DataRow item in db.GetAllPhoneBySql().Rows)
            {
                if (Convert.ToBoolean(item[5]) == true)
                {
                    Text = "تعمیر شده";
                }
                else
                {
                    Text = "در حال تعمیر";
                }

                if (Convert.ToBoolean(item[7]))
                {
                    visit = "ویزیت شده";
                }
                else
                {
                    visit = "ویزیت نشده";
                }

                if (item[4]==null)
                {
                    end = Convert.ToDateTime(item[4]).Shamsi();
                }
                else
                {
                    end = "----";
                }
                Phones.Add(new PhoneViewModel()
                {
                    PhoneID = int.Parse(item[0].ToString()),
                    Model = item[1].ToString(),
                    BarCode = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi(),
                    EndDate = end,
                    IsDone = Text,
                    Description = item[6].ToString(),
                    Visit = visit,
                    ReceptionNumber = item[8].ToString(),
                    Price = double.Parse(item[9].ToString()).ToString("N0"),
                    CustomerName = item[10].ToString(),
                    PhoneNumber = item[11].ToString()
                });
            }

            return Phones;
        }

        public List<PhoneViewModel> ReadByName(string name)
        {
            List<PhoneViewModel> Phones = new List<PhoneViewModel>();
            string Text = "";
            string visit = "";
            string end = "---";
            foreach (DataRow item in db.GetAllPhoneBySql().Rows)
            {
                if (Convert.ToBoolean(item[5]) == true)
                {
                    Text = "تعمیر شده";
                }
                else
                {
                    Text = "در حال تعمیر";
                }

                if (Convert.ToBoolean(item[7]))
                {
                    visit = "ویزیت شده";
                }
                else
                {
                    visit = "ویزیت نشده";
                }

                if (item[4] == null)
                {
                    end = Convert.ToDateTime(item[4]).Shamsi();
                }
                else
                {
                    end = "----";
                }
                Phones.Add(new PhoneViewModel()
                {
                    PhoneID = int.Parse(item[0].ToString()),
                    Model = item[1].ToString(),
                    BarCode = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi(),
                    EndDate = end,
                    IsDone = Text,
                    Description = item[6].ToString(),
                    Visit = visit,
                    ReceptionNumber = item[8].ToString(),
                    Price = double.Parse(item[9].ToString()).ToString("N0"),
                    CustomerName = item[10].ToString(),
                    PhoneNumber = item[11].ToString()
                });
            }

            return Phones;
        }

        public bool Delete(int id)
        {
            try
            {
                db.DeletePhone(id);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Phone Find(int id)
        {
            return db.GetPhoneById(id);
        }

        public bool Edit(Phone phone)
        {
            try
            {
                db.UpdatePhone(phone);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Change(int id)
        {
            try
            {
                foreach (var item in db.GetPhones(id))
                {
                    item.IsPay = true;
                    db.UpdatePhone(item);
                    db.Save();
                }

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public void Dispose()
        {
           db.Dispose();
        }
    }
}
