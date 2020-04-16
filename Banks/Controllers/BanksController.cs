using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banks.Models;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Banks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        [HttpGet("{ifsc}")]
        public async Task<ActionResult<Bank>> Get(String ifsc) {
			try {
				if (!Regex.IsMatch(ifsc, "^[a-z0-9]{4}0[a-z0-9]{6}$", RegexOptions.IgnoreCase)) {
					throw new NotFoundException();
				}

				using (ApplicationContext db = new ApplicationContext()) {
					var bank = await db.Banks.FindAsync(ifsc);

					if (bank == null) {
						var client = new HttpClient();
						HttpResponseMessage response = await client.GetAsync($"https://ifsc.razorpay.com/{ifsc}");

						if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
							throw new NotFoundException();
						}

						if (!response.IsSuccessStatusCode) {
							throw new Exception();
						}

						bank = await response.Content.ReadAsAsync<Bank>();
						db.Banks.Add(bank);
						await db.SaveChangesAsync();
					}

					return bank;
				}
			} catch (Exception e) {
				Response.StatusCode = e is NotFoundException ? 404 : 500;
				return null;
			}
        }

		private class NotFoundException: Exception { }

    }

}
