using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoiffeurWebsite.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CoiffeurWebsite.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly UserManager<UserDetails> _userManager;
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context, UserManager<UserDetails> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Appointments



        public async Task<IActionResult> Index()
        {
            // Include ile ilişkili tabloları getiriyoruz.
            var appointments = _context.Appointments
                .Include(a => a.Employee)
                .Include(a => a.Treatment)
                .Include(a => a.User) // Eğer User bilgisi gerekiyorsa
                .ToListAsync();

            return View(await appointments);
        }


        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Employee)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        public bool IsAppointmentAvailable(DateTime appointmentDate)
        {
            return !_context.Appointments.Any(a => a.AppointmentDate == appointmentDate);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewBag.Treatments = _context.Treatments.ToList();
            ViewBag.Employees = _context.Employees.ToList(); // Tüm çalışanları gönderiyoruz
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentID,AppointmentDate,Status,EmployeeID,TreatmentID")] Appointment appointment)
        {
            //if (ModelState.IsValid)
            //{ }
                // Giriş yapan kullanıcının e-postasını al
                var userEmail = User.Identity.Name;
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    return NotFound("Kullanıcı bulunamadı.");
                }

                // UserId'yi ata
                appointment.userId = user.Id;

                // Varsayılan durum ataması
                appointment.Status = "Pending";

                if (!IsAppointmentAvailable(appointment.AppointmentDate))
                {
                    ModelState.AddModelError("AppointmentDate", "Bu tarih ve saatte zaten bir randevu bulunmaktadır.");
                    return View(appointment);
                }


                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            //ViewData["TreatmentID"] = new SelectList(_context.Treatments, "TreatmentID", "TreatmentName", appointment.TreatmentID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeName", appointment.EmployeeID);
            //ViewBag.Treatments = _context.Treatments.ToList();
            //ViewBag.Employees = _context.Employees.ToList();
            //return View(appointment);
        }


        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", appointment.EmployeeID);
            ViewData["userId"] = new SelectList(_context.Users, "Id", "Id", appointment.userId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentID,Status")] Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return NotFound();
            }

            var existingAppointment = await _context.Appointments.FindAsync(id);
            if (existingAppointment == null)
            {
                return NotFound();
            }

            // Sadece Status alanını güncelle
            existingAppointment.Status = appointment.Status;

            try
            {
                _context.Update(existingAppointment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(appointment.AppointmentID))
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



        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Employee)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentID == id);
        }

        [HttpGet("Employees/Skills/{id}")]
        public async Task<IActionResult> GetEmployeesBySkillId([FromRoute] int id)
        {
            var employees = await _context.Employees
                .Where(e => e.TreatmentID == id)
                .ToListAsync();

            return Json(employees);
        }

    }
}
