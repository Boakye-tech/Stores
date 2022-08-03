using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stores.Models;
using Stores.ViewModels;
using Stores.App_Data;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stores.Controllers
{
    public class BinCardTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BinCardTransactionsController(ApplicationDbContext appDb)
        {
            _context = appDb;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Items> ItemList = _context.Items.ToList();
            List<Location> LocationList = _context.Location.ToList();
            List<BinCard> binCards = _context.BinCard.ToList();
            List<MeasuringUnit> measuringUnit = _context.MeasuringUnit.ToList();

            var bincardRecord = from b in binCards
                                join i in ItemList on b.ItemCode equals i.ItemCode into table1
                                from i in table1.ToList()
                                join l in LocationList on b.LocationCode equals l.LocationCode into table2
                                from l in table2.ToList()
                                join u in measuringUnit on b.UnitId equals u.UnitId into table3
                                from u in table3.ToList()
                                select new BinCardModel
                                {
                                    BinCardNumber = b.BinCardNumber,
                                    ItemDescription = i.ItemDescription,
                                    LocationName = l.LocationName,
                                    MaximumStockLevel = b.MaximumStockLevel,
                                    MinimumStockLevel = b.MinimumStockLevel,
                                    ReOrderLevel = b.ReOrderLevel,
                                    UnitName = u.UnitName
                                };
            return View(bincardRecord);
        }


        public IActionResult GetBinCardTransactions()
        {
            BinCardTransactionsVM BCTVM = new BinCardTransactionsVM();
            BCTVM.BinCardModel = GetBinCardModel();
            BCTVM.BinCardTransactionsModel = GetBinCardTransactionsModel();
            return View(BCTVM);
        }

        [HttpGet]
        public IActionResult Create(string binCardNumber)
        {
            BinCardTransactionsVM BCTVM = new BinCardTransactionsVM();
            List<TransactionType> transactionTypesList = _context.TransactionType.ToList();

            BCTVM.BinCardModel = GetBinCardModel(binCardNumber);
            BCTVM.BinCardTransactionsModel = GetBinCardTransactionsModel();
            BCTVM.TransTypeDropDown = transactionTypesList.Select(t => new SelectListItem { Text = t.TransactionTypes, Value = t.TransactionTypeId.ToString() });
            return View(BCTVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BinCardTransactionsVM viewModel)
        {
            if (viewModel != null)
            {
                BinCardTransactions binCardTrans = new BinCardTransactions();

                binCardTrans.BinCardNumber = viewModel.BinCardModel.BinCardNumber;
                binCardTrans.TransactionDate = viewModel.BinCardTransactionsModel.TransactionDate;
                binCardTrans.TransactionTypeId = viewModel.BinCardTransactionsModel.TransactionTypeId;
                binCardTrans.GRBNoteNumber = viewModel.BinCardTransactionsModel.GRBNoteNumber;
                binCardTrans.QuantityReceived = viewModel.BinCardTransactionsModel.QuantityReceived;
                binCardTrans.RequistionNumber = viewModel.BinCardTransactionsModel.RequistionNumber;
                binCardTrans.QuantityIssued = viewModel.BinCardTransactionsModel.QuantityIssued;
                binCardTrans.Balance = viewModel.BinCardTransactionsModel.Balance;
                binCardTrans.Remarks = viewModel.BinCardTransactionsModel.Remarks;
                binCardTrans.Who = "testapp";

                _context.BinCardTransaction.Add(binCardTrans);
                _context.SaveChanges();
                return RedirectToAction("Index", "BinCardTransactions");
            }

            return View(viewModel);
        }

        public BinCardModel GetBinCardModel()
        {
            List<Items> ItemList = _context.Items.ToList();
            List<Location> LocationList = _context.Location.ToList();
            List<BinCard> binCards = _context.BinCard.ToList();
            List<MeasuringUnit> measuringUnit = _context.MeasuringUnit.ToList();

            BinCardModel bModel = new BinCardModel();

            var bincardRecord = from b in binCards
                                join i in ItemList on b.ItemCode equals i.ItemCode into table1
                                from i in table1.ToList()
                                join l in LocationList on b.LocationCode equals l.LocationCode into table2
                                from l in table2.ToList()
                                join u in measuringUnit on b.UnitId equals u.UnitId into table3
                                from u in table3.ToList()
                                select bModel = new BinCardModel
                                {
                                    BinCardNumber = b.BinCardNumber,
                                    ItemDescription = i.ItemDescription,
                                    LocationName = l.LocationName,
                                    MaximumStockLevel = b.MaximumStockLevel,
                                    MinimumStockLevel = b.MinimumStockLevel,
                                    ReOrderLevel = b.ReOrderLevel,
                                    UnitName = u.UnitName
                                };
            return bModel;
        }

        public BinCardModel GetBinCardModel(string binCardNumber)
        {
            List<Items> ItemList = _context.Items.ToList();
            List<Location> LocationList = _context.Location.ToList();
            List<BinCard> binCards = _context.BinCard.ToList();
            List<MeasuringUnit> measuringUnit = _context.MeasuringUnit.ToList();

            BinCardModel bModel = new BinCardModel();

            var bincardRecord = from b in binCards
                                join i in ItemList on b.ItemCode equals i.ItemCode into table1
                                from i in table1.ToList()
                                join l in LocationList on b.LocationCode equals l.LocationCode into table2
                                from l in table2.ToList()
                                join u in measuringUnit on b.UnitId equals u.UnitId into table3
                                from u in table3.ToList()
                                select bModel = new BinCardModel
                                {
                                    BinCardNumber = b.BinCardNumber,
                                    ItemDescription = i.ItemDescription,
                                    LocationName = l.LocationName,
                                    MaximumStockLevel = b.MaximumStockLevel,
                                    MinimumStockLevel = b.MinimumStockLevel,
                                    ReOrderLevel = b.ReOrderLevel,
                                    UnitName = u.UnitName
                                };

            bModel = bincardRecord.ToList().Find(x => x.BinCardNumber == binCardNumber);
            
            return bModel;
        }

        public BinCardTransactions GetBinCardTransactionsModel()
        {
            List<BinCardTransactions> binCardTransactionsList = _context.BinCardTransaction.ToList();

            BinCardTransactions bTransModel = new BinCardTransactions();

            var binTransRecord = from b in binCardTransactionsList
                                 select bTransModel = new BinCardTransactions
                                 {
                                     BinCardNumber = b.BinCardNumber,
                                     TransactionDate = b.TransactionDate,

                                     TransactionTypeId = b.TransactionTypeId,
                                     GRBNoteNumber = b.GRBNoteNumber,
                                     QuantityReceived = b.QuantityReceived,
                                     RequistionNumber = b.RequistionNumber,
                                     QuantityIssued = b.QuantityIssued,
                                     Balance = b.Balance,
                                     Remarks = b.Remarks,
                                     Who = b.Who
                                 };

            return bTransModel;

        }

    }
}
