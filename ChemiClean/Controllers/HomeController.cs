using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChemiClean.Models;
using ChemiClean.Repositories;
using ChemiClean.StorageService;
using ChemiClean.Util;

namespace ChemiClean.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(ProductsRepository.GetInstance().GetAll());
        }

        [HttpGet]
        [Route("home/{name}")]
        public async Task<ActionResult> ProductByName(string name)
        {
            var product = ProductsRepository.GetInstance().Get(name);
            try
            {
                var documentBytes = await StorageApi.GetNewProductDocument(product.Url);
                if (product.LastBackup != "")
                {
                    var cachedDocumentBytes = await StorageApi.GetLocalProductDocument(product.Name);
                    product.IsUpdated = !Util.Util.CompareBytes(documentBytes, cachedDocumentBytes);
                }
                product.Url = await StorageApi.PostProductDocument(name, documentBytes);
                product.LastBackup = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                ProductsRepository.GetInstance().Update(product.Name);
            }
            catch (Exception)
            {
                product.IsUrlBroken = true;
                if (product.LastBackup != "")
                {
                    product.Url = StorageApi.ProductsRoute + product.Name;
                }
            }

            return View(product);
        }
    }
}
