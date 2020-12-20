using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PasswordHandler.Data;
using PasswordHandler.Models;
using Password_Storage;
using PasswordStorage;
using AutoMapper;
using Password_Storage.Interfaces;
using PasswordHandler.Utils;

namespace PasswordHandler.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly PasswordContext _context;
        public ResourcesController(PasswordContext context)
        {
            _context = context;
        }

        // GET: Resources
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Records.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(Store m)
        {
            var toDecrypt = _context.Records.ToList();
            foreach (var td in toDecrypt)
            {
                try
                {
                    var c = new Crypto();
                    td.Password = c.Decrypt(td.Password, m.MasterKey);
                    td.Login = c.Decrypt(td.Login, m.MasterKey);
                }
                catch
                {
                    continue;
                }
            }
            return View(toDecrypt);
        }



        // GET: Resources/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Submit(Store model)
        {
            return View(model);
        }
        public IActionResult Help()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Store cheks, [FromForm] Store gen)
        {
            if (cheks.LengthValue != 0 && cheks.Generation) gen.Length = true;
            var checkRules = new List<IRule>();
            var genRules = new List<IGenerator>();
            if (cheks.CheckingPassword)
            {
                checkRules = (new RuleListcs<IRule>
                 (new List<IRule>()
                 {
                    new RuleSpecialSymbols(), new RuleLower(),
                    new RuleUpper(), new RuleDigit(),
                    new RuleLength(cheks.LengthValue)
                 }
                ))
                .GetListWithRules(cheks);
            }
            if (cheks.Generation || string.IsNullOrEmpty(cheks.Password))
            {
                var rules = new List<IGenerator>()
                    {
                        new SpecialChar(), new LowerChar(), new UpperChar(), new DigitChar(), new Length(cheks.LengthValue)
                    };
                if (cheks.LengthValue == 0)
                    genRules = new RuleListcs<IGenerator>(rules).GetListWithRules();
                else
                    genRules = new RuleListcs<IGenerator>(rules).GetListWithRules(gen);
            }
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Store, Resource>());
                var mapper = new Mapper(config);
                var record = mapper.Map<Store, Resource>(cheks);
                var c = new Crypto();
                if (cheks.Generation || string.IsNullOrEmpty(cheks.Password))
                {
                    cheks.Generation = true;
                    record.Password = (new PasswordGenerator(genRules)).GetPassword();
                }
                if (cheks.CheckingPassword)
                {
                    cheks.Estimate = (new PasswordEstimator(checkRules)).EstimatePassword(record.Password).ToString();
                }
                record.Login = c.Crypt(record.Login, cheks.MasterKey);
                record.Password = c.Crypt(record.Password, cheks.MasterKey);
                _context.Add(record);
                _context.SaveChanges();
                cheks.Password = c.Decrypt(record.Password, cheks.MasterKey);
                return RedirectToAction("Submit", cheks);
                }
            return View(cheks);
        }
          
    

        

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _context.Records.FindAsync(id);
            _context.Records.Remove(resource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}
