﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using book_store.Data;
using book_store.Models;
using Microsoft.Data.SqlClient;

namespace book_store.Controllers
{
    public class usersaccountsController : Controller
    {
        private readonly book_storeContext _context;

        public usersaccountsController(book_storeContext context)
        {
            _context = context;
        }

        // GET: usersaccounts
        public async Task<IActionResult> Index()
        {
              return _context.usersaccounts != null ? 
                          View(await _context.usersaccounts.ToListAsync()) :
                          Problem("Entity set 'book_storeContext.usersaccounts'  is null.");
        }

        // GET: usersaccounts/Details/5

        // GET: usersaccounts/Register
        public IActionResult Register()
        {
            return View();
        } 
        public IActionResult login()
        {
            return View();
        }

         public IActionResult landing()
        {
            return View();
        } 
        public IActionResult Go_to_buy()
        {
            return View();
        }

		



		[HttpPost, ActionName("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(string na, string pa)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=DESKTOP-5BL0E3U;Initial Catalog=DatabaseForT_book;Integrated Security=True;");
            string sql;
            sql = "SELECT * FROM usersaccounts where name ='" + na + "' and  pass ='" + pa + "' ";
            SqlCommand comm = new SqlCommand(sql, conn1);
            conn1.Open();
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {
                string role = (string)reader["role"];
                string id = Convert.ToString((int)reader["Id"]);
                HttpContext.Session.SetString("Name", na);
                HttpContext.Session.SetString("Role", role);
                HttpContext.Session.SetString("userid", id);
                reader.Close();
                conn1.Close();
                if (role == "customer")
                    return RedirectToAction("catalogue", "books");

                else
                    return RedirectToAction("Index", "books");

            }
            else
            {
                ViewData["Message"] = "Wrong user name and  password";
                return View();
            }
        }


        // POST: usersaccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,pass,email")] usersaccounts usersaccounts)
        {
            usersaccounts.role = "customer";
            _context.Add(usersaccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(login));
        }

        // GET: usersaccounts/Edit/5
        public async Task<IActionResult> Edit()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("userid"));

            var usersaccounts = await _context.usersaccounts.FindAsync(id);
            
            return View(usersaccounts);
        }

        // POST: usersaccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,pass,role,email")] usersaccounts usersaccounts)
        {
      
              
                    _context.Update(usersaccounts);
                    await _context.SaveChangesAsync();
             
                return RedirectToAction(nameof(login));
           
        }

    
        private bool usersaccountsExists(int id)
        {
          return (_context.usersaccounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
