using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_XYZ_Apparels.Models;
using System.Web.Security;

namespace Mvc_XYZ_Apparels.Controllers
{
    public class HomeController : Controller
    {
        UsersDAL dal = new UsersDAL();
        CustomersDAL dal1 = new CustomersDAL();
        SuppliersDAL dal2 = new SuppliersDAL();
        ContractorsDAL dal3 = new ContractorsDAL();

        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult DataEntryIndex()
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal1.CreateCustomer(model))
                {
                    return ShowCustomers();
                }
                else
                {
                    ViewBag.msg = "Customer Not Created";
                    return ShowCustomers();
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult EditCustomerPanel(int id)
        {
            ViewData["Customer"] = dal1.FindCustomer(id);
            return View("EditCustomer");
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal1.UpdateCustomer(model))
                {
                    ViewBag.msg = "Customer Updated Success";
                    return ShowCustomers();
                }
                else
                {
                    ViewBag.msg = "Customer Not Updated";
                    return ShowCustomers();

                }
            }
            return View("AdminIndex");
        }

        public ActionResult ShowCustomers()
        {
            ViewData["CustomerList"] = dal1.GetCustomers();
            return View("ShowCustomers");
        }

        [HttpGet]
        public string ChangeCustomerStatus(int id, String status)
        {
            if (ModelState.IsValid)
            {
                if (status == "ACTIVE")
                {
                    dal1.ChangeStatusActive(id);

                }
                else
                {
                    dal1.ChangeStatusInactive(id);
                }
                return "success";
            }
            return "";
        }

        public ActionResult CreateSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSupplier(SupplierModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal2.CreateSupplier(model))
                {
                    return ShowSuppliers();
                }
                else
                {
                    ViewBag.msg = "Supplier Not Created";
                    return ShowSuppliers();
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult EditSupplierPanel(int id)
        {
            ViewData["Supplier"] = dal2.FindSupplier(id);
            return View("EditSupplier");
        }

        [HttpPost]
        public ActionResult EditSupplier(SupplierModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal2.UpdateSupplier(model))
                {
                    ViewBag.msg = "Supplier Updated Success";
                    return ShowSuppliers();
                }
                else
                {
                    ViewBag.msg = "Supplier Not Updated";
                    return ShowSuppliers();

                }
            }
            return View("AdminIndex");
        }

        public ActionResult ShowSuppliers()
        {
            ViewData["SupplierList"] = dal2.GetSuppliers();
            return View("ShowSuppliers");
        }

        [HttpGet]
        public string ChangeSupplierStatus(int id, String status)
        {
            if (ModelState.IsValid)
            {
                if (status == "ACTIVE")
                {
                    dal2.ChangeStatusActive(id);

                }
                else
                {
                    dal2.ChangeStatusInactive(id);
                }
                return "success";
            }
            return "";
        }

        public ActionResult CreateContractor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContractor(ContractorModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal3.CreateContractor(model))
                {
                    return ShowContractors();
                }
                else
                {
                    ViewBag.msg = "Contractor Not Created";
                    return ShowContractors();
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult EditContractorPanel(int id)
        {
            ViewData["Contractor"] = dal3.FindContractor(id);
            return View("EditContractor");
        }

        [HttpPost]
        public ActionResult EditContractor(ContractorModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal3.UpdateContractor(model))
                {
                    ViewBag.msg = "Contractor Updated Success";
                    return ShowContractors();
                }
                else
                {
                    ViewBag.msg = "Contractor Not Updated";
                    return ShowContractors();

                }
            }
            return View("AdminIndex");
        }

        public ActionResult ShowContractors()
        {
            ViewData["ContractorList"] = dal3.GetContractors();
            return View("ShowContractors");
        }

        [HttpGet]
        public string ChangeContractorStatus(int id, String status)
        {
            if (ModelState.IsValid)
            {
                if (status == "ACTIVE")
                {
                    dal3.ChangeStatusActive(id);

                }
                else
                {
                    dal3.ChangeStatusInactive(id);
                }
                return "success";
            }
            return "";
        }

    }
}
