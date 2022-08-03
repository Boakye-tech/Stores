using Microsoft.AspNetCore.Mvc;
using Stores.App_Data;
using System.Collections.Generic;
using Stores.Models;
using Stores.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stores.Controllers
{
    public class BinCardController : Controller
    {
        private readonly ApplicationDbContext _appDb;

        public BinCardController(ApplicationDbContext DbCon)
        {
            _appDb = DbCon;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //IEnumerable<BinCard> objList = _appDb.BinCard;
            //return View(objList);

            List<Items> ItemList = _appDb.Items.ToList();
            List<Location> LocationList = _appDb.Location.ToList();
            List<BinCard> binCards = _appDb.BinCard.ToList();
            List<MeasuringUnit> measuringUnit = _appDb.MeasuringUnit.ToList();

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
                                    UnitName = u.UnitName,
                                    UnitPrice = b.UnitPrice
                                };
           return View(bincardRecord);
        }

        // GET: /<create item>/
        public IActionResult CreateBinCard()
        {
            List<Items> ItemList = _appDb.Items.ToList();
            List<Location> LocationList = _appDb.Location.ToList();
            List<MeasuringUnit> measuringUnit = _appDb.MeasuringUnit.ToList();

            BinCardVM bincardVM = new BinCardVM()
            {
                BinCard = new BinCard(),

                TypeDropDown = ItemList.Select(i => new SelectListItem
                {
                    Text = i.ItemCode + " - " + i.ItemDescription,
                    Value = i.ItemCode
                }),

                LocationDropDown = LocationList.Select(l => new SelectListItem
                {
                    Text = l.LocationCode + " - " + l.LocationName,
                    Value = l.LocationCode
                }),

                UnitDropDown = measuringUnit.Select(u => new SelectListItem
                {
                    Text = u.UnitName,
                    Value = u.UnitId.ToString()
                })
            };

            return View(bincardVM);
        }

        /*
        // POST: /<create item>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBinCard(BinCard itemObj)
        {
            if (ModelState.IsValid)
            {
                _appDb.BinCard.Add(itemObj);
                _appDb.SaveChanges();
                return RedirectToAction("Index", "BinCard");
            }

            return View(itemObj);
        }
        */

        // POST: /<create item>/ - using view model. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBinCard(BinCardVM itemObj)
        {
            if (ModelState.IsValid)
            {
                _appDb.BinCard.Add(itemObj.BinCard);
                _appDb.SaveChanges();
                return RedirectToAction("Index", "BinCard");
            }

            return View(itemObj);
        }

        [HttpGet]
        public IActionResult UpdateBinCard(string binCardNumber)
        {
            List<Items> ItemList = _appDb.Items.ToList();
            List<Location> LocationList = _appDb.Location.ToList();
            List<BinCard> binCards = _appDb.BinCard.ToList();
            List<MeasuringUnit> measuringUnit = _appDb.MeasuringUnit.ToList();

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
                                    ItemCode = i.ItemCode,
                                    ItemDescription = i.ItemDescription,
                                    LocationName = l.LocationName,
                                    MaximumStockLevel = b.MaximumStockLevel,
                                    MinimumStockLevel = b.MinimumStockLevel,
                                    ReOrderLevel = b.ReOrderLevel,
                                    UnitName = u.UnitName,
                                    UnitPrice = b.UnitPrice
                                };

            var bModel = bincardRecord.ToList().Find(x => x.BinCardNumber == binCardNumber);


            BinCardVM bincardVM = new BinCardVM()
            {
                //BinCard = new BinCard(),
                BinCardModel = bModel,


                
                TypeDropDown = ItemList.Select(i => new SelectListItem
                {
                    Text = i.ItemCode + " - " + i.ItemDescription,
                    Value = i.ItemCode
                }),
                
                LocationDropDown = LocationList.Select(l => new SelectListItem
                {
                    Text = l.LocationCode + " - " + l.LocationName,
                    Value = l.LocationCode
                }),

                UnitDropDown = measuringUnit.Select(u => new SelectListItem
                {
                    Text = u.UnitName,
                    Value = u.UnitId.ToString()
                })
            };



            return View(bincardVM);
        }

        [HttpPost]
        public IActionResult UpdateBinCard(BinCardVM itemObj)
        {
            /*
            if (ModelState.IsValid)
            {
                BinCard binCard = new BinCard();

                binCard.BinCardNumber = itemObj.BinCardModel.BinCardNumber;
                binCard.MaximumStockLevel = itemObj.BinCardModel.MaximumStockLevel;
                binCard.MinimumStockLevel = itemObj.BinCardModel.MinimumStockLevel;
                binCard.ReOrderLevel = itemObj.BinCardModel.ReOrderLevel;
                binCard.UnitId = itemObj.BinCard.UnitId;
                binCard.LocationCode = itemObj.BinCard.LocationCode;
                binCard.UnitPrice = itemObj.BinCardModel.UnitPrice;

                //_appDb.BinCard.Update(itemObj.BinCard);
                _appDb.BinCard.Update(binCard);
                _appDb.SaveChanges();
                return RedirectToAction("Index", "BinCard");
            }
            return View(itemObj);
            */

            BinCard binCard = new BinCard();

                binCard.BinCardNumber = itemObj.BinCardModel.BinCardNumber;
                binCard.MaximumStockLevel = itemObj.BinCardModel.MaximumStockLevel;
                binCard.MinimumStockLevel = itemObj.BinCardModel.MinimumStockLevel;
                binCard.ReOrderLevel = itemObj.BinCardModel.ReOrderLevel;
                binCard.UnitId = itemObj.BinCard.UnitId;
                binCard.LocationCode = itemObj.BinCard.LocationCode;
                binCard.ItemCode = itemObj.BinCardModel.ItemCode;
                binCard.UnitPrice = itemObj.BinCardModel.UnitPrice;

                //_appDb.BinCard.Update(itemObj.BinCard);
                _appDb.BinCard.Update(binCard);
                _appDb.SaveChanges();
                return RedirectToAction("Index", "BinCard");
        }

    }
}
