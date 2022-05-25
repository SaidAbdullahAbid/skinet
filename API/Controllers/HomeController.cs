// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;

// namespace API.Controllers
// {
//     [Route("/")]
//     [ApiController]
//     public class HomeController : Controller
//     {
//         [HttpGet(nameof(GetRoot))]
//         public IActionResult GetRoot()
//         {
//             var result = new
//             {
//                 href = Url.Link(nameof(GetRoot), null),
//                 product = new
//                 {
//                     singleProduct = Url.Link(nameof(ProductsController.GetProduct), 10),
//                     // AllProducts = Url.Link(nameof(ProductsController.GetProducts), null)
//                 }
//             };
//             return Ok(result);
//         }

//     }
// }