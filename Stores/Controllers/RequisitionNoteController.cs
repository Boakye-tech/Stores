using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stores.App_Data;
using Stores.Models;
using Stores.ViewModels;

namespace Stores.Controllers
{
    public class RequisitionNoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequisitionNoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: RequisitionNote
        public async Task<IActionResult> Indexs()
        {
            var applicationDbContext = _context.RequisitionNote.Include(r => r.DepartmentName).Include(r => r.ItemDescription).Include(r => r.LocationName);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Index()
        {
            List<Department> departmentList = _context.Departments.ToList();
            List<Location> locationList = _context.Location.ToList();
            List<Staff> staffList = _context.Staff.ToList();
            List<RequisitionNote> requisitionNotes = _context.RequisitionNote.ToList();


            RequisitionViewModel requisitionNote = new RequisitionViewModel();

            var pendingRequestList = from r in requisitionNotes
                                     join l in locationList on r.LocationCode equals l.LocationCode into table1
                                     from l in table1.ToList()
                                     join d in departmentList on r.DepartmentCode equals d.DepartmentCode into table2
                                     from d in table2.ToList()
                                     join s in staffList on r.StaffIdentificationNumber equals s.StaffIdentificationNumber into table3
                                     from s in table3.ToList()
                                     orderby r.RequisitionDate, r.RequisitionNumber
                                     select requisitionNote = new RequisitionViewModel
                                     {
                                         RequisitionDate = r.RequisitionDate,
                                         RequisitionNumber = r.RequisitionNumber,
                                         Location = l.LocationName,
                                         Department = d.DepartmentName,
                                         FullName = s.Firstname.ToString().Trim() + " " + s.Middlename.ToString().Trim() + " " + s.Surname.ToString().Trim(),
                                         Status = r.Status
                                     };

            return View(pendingRequestList.Distinct(new RequisitionListViewModelComparer()));
        }

        // GET: RequisitionNote/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Department> departmentList = _context.Departments.ToList();
            List<Location> locationList = _context.Location.ToList();
            List<Staff> staffList = _context.Staff.ToList();
            List<RequisitionNote> requisitionNotes = _context.RequisitionNote.ToList();

            List<MeasuringUnit> measuringUnits = _context.MeasuringUnit.ToList();
            List<Items> items = _context.Items.ToList();

            RequisitionDetailsViewModel requisitionDetailsVM = new RequisitionDetailsViewModel();

            var requisitionDetailsList = from r in requisitionNotes
                                         join i in items on r.ItemCode equals i.ItemCode into table1
                                         from i in table1.ToList()
                                         join u in measuringUnits on r.UnitId equals u.UnitId into table2
                                         from u in table2.ToList()
                                         where r.RequisitionNumber.Contains(id)

                                         select requisitionDetailsVM = new RequisitionDetailsViewModel
                                         {
                                               BinCardNumber = r.BinCardNumber,
                                               ItemDescription = i.ItemDescription,
                                               MeasureUnit = u.UnitName,
                                               QuantityRequested = r.QuantityRequested,
                                               QuantityIssued = r.QuantityIssued,
                                               UnitPrice = r.UnitPrice,
                                               Value = r.Value
                                          };

            RequisitionViewModel requisitionNote = new RequisitionViewModel();

            var pendingRequestList = from r in requisitionNotes
                                     join l in locationList on r.LocationCode equals l.LocationCode into table1
                                     from l in table1.ToList()
                                     join d in departmentList on r.DepartmentCode equals d.DepartmentCode into table2
                                     from d in table2.ToList()
                                     join s in staffList on r.StaffIdentificationNumber equals s.StaffIdentificationNumber into table3
                                     from s in table3.ToList()
                                     orderby r.RequisitionDate, r.RequisitionNumber
                                     select requisitionNote = new RequisitionViewModel
                                     {
                                         RequisitionDate = r.RequisitionDate,
                                         RequisitionNumber = r.RequisitionNumber,
                                         Location = l.LocationName,
                                         Department = d.DepartmentName,
                                         FullName = s.Firstname.ToString().Trim() + " " + s.Middlename.ToString().Trim() + " " + s.Surname.ToString().Trim(),
                                         Status = r.Status,
                                         requisitionDetails = requisitionDetailsList.ToList()
                                     };

            //return View(pendingRequestList.Distinct(new RequisitionListViewModelComparer()).ToList().Find(x => x.RequisitionNumber == id));
            return View(pendingRequestList.ToList().Find(x => x.RequisitionNumber == id)) ;


            /*
            var requisitionNote = await _context.RequisitionNote
                .Include(r => r.DepartmentName)
                .Include(r => r.ItemDescription)
                .Include(r => r.LocationName)
                .FirstOrDefaultAsync(m => m.RequisitionNumber == id);
            if (requisitionNote == null)
            {
                return NotFound();
            }

            return View(requisitionNote);
            */
        }

        // GET: RequisitionNote/Create
        public IActionResult Create()
        {
            //ViewData["DepartmentCode"] = new SelectList(_context.Departments, "DepartmentCode", "DepartmentName");
            //ViewData["ItemCode"] = new SelectList(_context.Items, "ItemCode", "ItemCode");
            //ViewData["LocationCode"] = new SelectList(_context.Location, "LocationCode", "LocationCode");

            List<Department> departmentList = _context.Departments.ToList();
            List<Items> itemsList = _context.Items.ToList();
            List<Location> locationList = _context.Location.ToList();

            RequisitionNoteVM requisitionNoteVM = new RequisitionNoteVM()
            {
                RequisitionNote = new RequisitionNote(),

                ItemDropDown = itemsList.Select(i => new SelectListItem
                {
                    Text = i.ItemDescription,
                    Value = i.ItemCode
                }),

                LocationDropDown = locationList.Select(l => new SelectListItem
                {
                    Text = l.LocationName,
                    Value = l.LocationCode
                }),

                DepartmentDropDown = departmentList.Select(d => new SelectListItem
                {
                    Text = d.DepartmentName,
                    Value = d.DepartmentCode.ToString()
                })

            };
            
            return View(requisitionNoteVM);
        }

        // GET: RequisitionNote/StaffList
        public List<StaffViewModel> StaffList(int? departmentcode)
        {
            List<Staff> staffLists = _context.Staff.ToList();
            List<Department> departmentList = _context.Departments.ToList();

            var staffRecord = from b in staffLists
                              join d in departmentList on b.DepartmentCode equals d.DepartmentCode into table1
                              from d in table1.ToList().Where(s => s.DepartmentCode == departmentcode)
                              select new StaffViewModel
                              {
                                  StaffIdentificationNumber = b.StaffIdentificationNumber,
                                  Firstname = b.Firstname,
                                  Middlename = b.Middlename,
                                  Surname = b.Surname,
                                  DepartmentCode = b.DepartmentCode,
                                  DepartmentName = d.DepartmentName
                              };

            return staffRecord.ToList();
        }

        /*
        public IEnumerable<RequistionListViewModel> PendingRequest()
        {
            List<Department> departmentList = _context.Departments.ToList();
            List<Location> locationList = _context.Location.ToList();
            List<Staff> staffList = _context.Staff.ToList();
            List<RequisitionNote> requisitionNotes = _context.RequisitionNote.ToList();


            RequistionListViewModel requisitionNote = new RequistionListViewModel();

            var pendingRequestList = from r in requisitionNotes
                                     join l in locationList on r.LocationCode equals l.LocationCode into table1
                                     from l in table1.ToList()
                                     join d in departmentList on r.DepartmentCode equals d.DepartmentCode into table2
                                     from d in table2.ToList()
                                     join s in staffList on r.StaffIdentificationNumber equals s.StaffIdentificationNumber into table3
                                     from s in table3.ToList()
                                     orderby r.RequisitionDate, r.RequisitionNumber
                                     select requisitionNote = new RequistionListViewModel
                                     {
                                         RequisitionDate = r.RequisitionDate,
                                         RequisitionNumber = r.RequisitionNumber,
                                         Location = l.LocationName,
                                         Department = d.DepartmentName,
                                         FullName = s.Firstname.ToString().Trim() + " " + s.Middlename.ToString().Trim() + " " + s.Surname.ToString().Trim()
                                     };

            return pendingRequestList.Distinct().ToList();
        }
        */
       
        public BinCardModel GetBinCardModel(string itemDescription)
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
                                    ItemCode = i.ItemCode,
                                    ItemDescription = i.ItemDescription,
                                    LocationName = l.LocationName,
                                    MaximumStockLevel = b.MaximumStockLevel,
                                    MinimumStockLevel = b.MinimumStockLevel,
                                    ReOrderLevel = b.ReOrderLevel,
                                    UnitId = u.UnitId,
                                    UnitName = u.UnitName,
                                    UnitPrice = b.UnitPrice
                                };

            bModel = bincardRecord.ToList().Find(x => x.ItemDescription == itemDescription);

            return bModel;
        }

        // POST: RequisitionNote/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequisitionNoteVM requisitionNoteVM)
        {
            //RequisitionNoteVM requisitionNoteVM = new RequisitionNoteVM();

            if (ModelState.IsValid)
            {
                
                _context.Add(requisitionNoteVM.RequisitionNote);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentCode"] = new SelectList(_context.Departments, "DepartmentCode", "DepartmentCode", requisitionNoteVM.RequisitionNote.DepartmentCode );
            ViewData["ItemCode"] = new SelectList(_context.Items, "ItemCode", "ItemCode", requisitionNoteVM.RequisitionNote.ItemCode);
            ViewData["LocationCode"] = new SelectList(_context.Location, "LocationCode", "LocationCode", requisitionNoteVM.RequisitionNote.LocationCode);
            return View(requisitionNoteVM);
        }

        
        // POST: RequisitionNote/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult InsertRecords([FromBody] List<RequisitionNote> requisitionNotes)
        {
            try
            {

                if (requisitionNotes == null)
                {
                    requisitionNotes = new List<RequisitionNote>();
                }

                int insertedRecords = 0;
                foreach (RequisitionNote requisitionNote in requisitionNotes)
                {
                    _context.Add(requisitionNote);
                    insertedRecords++;
                }
                _context.SaveChanges();

                //int insertedRecords = _context.SaveChanges();
                return Json(insertedRecords);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.ToString());
            }

        }

        public JsonResult ApprovedRecords([FromBody] List<RequisitionNote> requisitionNotes)
        {

            if (requisitionNotes == null)
            {
                requisitionNotes = new List<RequisitionNote>();
            }

            int insertedRecords = 0;
            foreach (RequisitionNote requisitionNote in requisitionNotes)
            {
                _context.Update(requisitionNote);
                _context.SaveChangesAsync();

                insertedRecords++;
            }

            //int insertedRecords = _context.SaveChanges();
            return Json(insertedRecords);
        }


        // GET: RequisitionNote/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitionNote = await _context.RequisitionNote.FindAsync(id);
            if (requisitionNote == null)
            {
                return NotFound();
            }
            ViewData["DepartmentCode"] = new SelectList(_context.Departments, "DepartmentCode", "DepartmentCode", requisitionNote.DepartmentCode);
            ViewData["ItemCode"] = new SelectList(_context.Items, "ItemCode", "ItemCode", requisitionNote.ItemCode);
            ViewData["LocationCode"] = new SelectList(_context.Location, "LocationCode", "LocationCode", requisitionNote.LocationCode);
            return View(requisitionNote);
        }

        // POST: RequisitionNote/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RequisitionNumber,RequisitionDate,LocationCode,DepartmentCode,StaffStaffIdentificationNumber,BinCardNumber,ItemCode,MeasuringUnitId,QuantityRequested,QuantityIssued,UnitPrice,Value,Remarks,HODAuthorization,HODAuthorizationDate,SHODAuthorization,SHODAuthorizationDate,FHODAuthorization,FHODAuthorizationDate,Whom")] RequisitionNote requisitionNote)
        {
            if (id != requisitionNote.RequisitionNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisitionNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisitionNoteExists(requisitionNote.RequisitionNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentCode"] = new SelectList(_context.Departments, "DepartmentCode", "DepartmentCode", requisitionNote.DepartmentCode);
            ViewData["ItemCode"] = new SelectList(_context.Items, "ItemCode", "ItemCode", requisitionNote.ItemCode);
            ViewData["LocationCode"] = new SelectList(_context.Location, "LocationCode", "LocationCode", requisitionNote.LocationCode);
            return View(requisitionNote);
        }

        // GET: RequisitionNote/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitionNote = await _context.RequisitionNote
                .Include(r => r.DepartmentName)
                .Include(r => r.ItemDescription)
                .Include(r => r.LocationName)
                .FirstOrDefaultAsync(m => m.RequisitionNumber == id);
            if (requisitionNote == null)
            {
                return NotFound();
            }

            return View(requisitionNote);
        }

        // POST: RequisitionNote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var requisitionNote = await _context.RequisitionNote.FindAsync(id);
            _context.RequisitionNote.Remove(requisitionNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool RequisitionNoteExists(string id)
        {
            return _context.RequisitionNote.Any(e => e.RequisitionNumber == id);
        }
        
    }
}
