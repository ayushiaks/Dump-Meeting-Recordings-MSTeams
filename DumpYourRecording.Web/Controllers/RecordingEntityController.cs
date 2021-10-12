using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DumpYourRecording.Web.Models;
using DumpYourRecording.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DumpYourRecording.Web.Controllers
{
    public class RecordingEntityController : Controller
    {
        private readonly ICosmosDbService cosmosDbService;

        public RecordingEntityController(ICosmosDbService cosmosDbService)
        {
            this.cosmosDbService = cosmosDbService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }

        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Id,Name,Date,Url")] RecordingEntity entity)
        {
            if (ModelState.IsValid)
            {
                entity.Id = Guid.NewGuid().ToString();
                await cosmosDbService.AddItemAsync(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }
    }
}
