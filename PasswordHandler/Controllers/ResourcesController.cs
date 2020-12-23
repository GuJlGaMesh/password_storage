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

using PasswordHandler.Utils;

namespace PasswordHandler.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly PasswordContext _context;
        private readonly IEncrypt _encrypt;
        private readonly RuleContainer _ruleContainer;
        private readonly IMapper _mapper;
        private readonly PasswordGenerator _passwordGenerator;
        private Resource _record { get; set; }
        public ResourcesController(
            PasswordContext context,
            IEncrypt encrypt,
            RuleContainer ruleContainer,
            IMapper mapper)
        {
            _context = context;
            _encrypt = encrypt;
            _ruleContainer = ruleContainer;
            _mapper = mapper;
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

        public IActionResult Submit(Store store)
        {
            int _store;
            var record = _mapper.Map<Store, Resource>(store);
            record.Login = _encrypt.Crypt(record.Login, store.MasterKey);
            record.Password = _encrypt.Crypt(record.Password, store.MasterKey);
            _context.Add(record);
            _context.SaveChanges();
            return View(store);
        }
        public IActionResult Help()
        {
            return View(_ruleContainer);
        }
        public IActionResult GenerationEmpty(Store store)
        {
            store.Rules = _ruleContainer.GetNames().Select(n => new RuleActivity { Name = n, Enabled = false }).ToList();

            return View("Generation", store);
        }

        [HttpPost]
        public IActionResult Generation(Store store)
        {
            var genRules = store.Rules.Where(e => e.Enabled == true).Select(r => _ruleContainer.GetByName(r.Name).GetGenerator()).ToList();
            store.Password = new PasswordGenerator(genRules).GetPassword();
            return RedirectToAction("CheckingEmpty", store);
        }
        [HttpPost]
        public IActionResult Checking(Store store)
        {
            if (store.CheckingPassword)
            {
                var checkRules = store.Rules.Where(e => e.Enabled == true).Select(r => _ruleContainer.GetByName(r.Name).CreateRule()).ToList();
                store.Estimate = new PasswordEstimator(checkRules).EstimatePassword(store.Password).ToString();
            }
            return RedirectToAction("Submit", store);
        }
        public IActionResult CheckingEmpty(Store store)
        {
            store.Rules = _ruleContainer.GetNames().Select(n => new RuleActivity { Name = n, Enabled = false }).ToList();
            return View("Checking", store);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Store store)
        {

            if (store.Generation || string.IsNullOrEmpty(store.Password))
            {
               return RedirectToAction("GenerationEmpty", store);
            }
            return RedirectToAction("CheckingEmpty", store);
            


            /*
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
                */
            //return View(cheks);
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
