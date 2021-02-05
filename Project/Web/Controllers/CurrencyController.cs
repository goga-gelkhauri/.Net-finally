using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Web.ViewModels;

namespace Web.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyRepository _currencyRepository;
        private ICurrencyHistoryRepository _currencyHistoryRepository;
        private UserManager<ApplicationUser> _userManager;
        private IUnitOfWork unitOfWork;

        public CurrencyController(ICurrencyRepository currencyRepository, ICurrencyHistoryRepository currencyHistoryRepository, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _currencyHistoryRepository = currencyHistoryRepository;
            _userManager = userManager;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var currencies = await _currencyRepository.GetAll();
            var viewmodel = new CurrencyViewModel
            {
                Currencies = currencies
            };
            return View(viewmodel);
        }

        [HttpGet]
        [Authorize(Roles = "Basic")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Basic")]
        public async Task<IActionResult> Store(EditCurrencyViewModel request)
        {
           var user = await _userManager.GetUserAsync(User);
            try
            {
                var currencyHistory = new CurrencyHistory
                {
                    OldName = "",
                    NewName = request.Currency.Name,
                    OldValue = 0,
                    NewValue = request.Currency.Value,
                    Status = "Created",
                    Time = DateTime.Now,
                    User = user
                };
                var currency = new Currency
                {
                    Name = request.Currency.Name,
                    Value = request.Currency.Value
                };

                await unitOfWork.currencyHistoryRepository.Add(currencyHistory);
                await unitOfWork.currencyRepository.Add(currency);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
               // return ex.InnerException.Message;
            }

             return Redirect("/Currency");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var currency =  await _currencyRepository.GetByIdAsync(id);
            var viewModel = new EditCurrencyViewModel
            {
                Currency = currency,
                Old = new Currency
                {
                    Name = currency.Name,
                    Value = currency.Value,
                }
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditCurrencyViewModel request)
        {
            try
            {

                var id = request.Currency.Id;
                var currency = await _currencyRepository.GetByIdAsync(id);
                
                var currencyHistory = new CurrencyHistory
                {
                    OldName = currency.Name,
                    NewName = request.Currency.Name,
                    OldValue = currency.Value,
                    NewValue = request.Currency.Value,
                    Status = "Edited",
                    Time = DateTime.Now
                   
                };
                await unitOfWork.currencyHistoryRepository.Add(currencyHistory);

                currency.Name = request.Currency.Name;
                currency.Value = request.Currency.Value;
                unitOfWork.currencyRepository.Update(currency);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
            }

            return Redirect("/Currency");

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Currencyhistory()
        {
            var currencyHistories = await _currencyHistoryRepository.GetAllWithUser();
            var viewmodel = new CurrencyHistoryViewModel
            {
                CurrencyHistories = currencyHistories
            };
            return View(viewmodel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCurrencyHistory(int id)
        {
            if (id != 0)
            {
                try
                {
                    var currencyHistoryInDb = await unitOfWork.currencyHistoryRepository.GetByIdAsync(id);
                    unitOfWork.currencyHistoryRepository.Delete(currencyHistoryInDb);
                    unitOfWork.Commit();
                }
                catch
                {
                    unitOfWork.Rollback();
                }
            }

            return Redirect("/Currency/Currencyhistory");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                try
                {
                    var currencyInDb = await unitOfWork.currencyRepository.GetByIdAsync(id);
                    var currencyHistory = new CurrencyHistory
                    {
                        OldName = currencyInDb.Name,
                        NewName = "",
                        OldValue = currencyInDb.Value,
                        NewValue = 0,
                        Status = "Deleted",
                        Time = DateTime.Now

                    };
                    await unitOfWork.currencyHistoryRepository.Add(currencyHistory);
                    unitOfWork.currencyRepository.Delete(currencyInDb);
                    unitOfWork.Commit();
                }
                catch
                {
                    unitOfWork.Rollback();
                }
            }

            return Redirect("/Currency/Currencyhistory");
        }
    }
}
