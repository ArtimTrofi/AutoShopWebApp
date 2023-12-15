

   // using WebApplication1.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using Microsoft.AspNetCore.Identity;

using System.Diagnostics.Metrics;
using System.Formats.Asn1;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ArtimAppContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly string _pathName;

        /* public SeedController(WorldCitiesContext db, IWebHostEnvironment environment,
             UserManager<WorldCitiesUser> userManager)
         {
             _db = db;
             _userManager = userManager;
             _pathName = Path.Combine(environment.ContentRootPath, "Data/worldcities.csv");
         }*/

        [HttpPost("Users")]
        public async Task<IActionResult> ImportUsersAsync()
        {
            //List<WorldCitiesUser> userList = new();

            (string name, string email) = ("user1", "user@umail.com");
            AppUser user = new()
            {
                UserName = name,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if (await _userManager.FindByNameAsync(name) is not null)
            {
                user.UserName = "user2";
            }
            _ = await _userManager.CreateAsync(user, "P@ssw0rd!")
                                ?? throw new InvalidOperationException();
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            await _db.SaveChangesAsync();

            return Ok();
        }

        /*[HttpPost("Countries")]
        public async Task<IActionResult> ImportCountriesAsync()
        {
            // create a lookup dictionary containing all the countries already existing 
            // into the Database (it will be empty on first run).
            Dictionary<string, Country> countriesByName = _db.Countries
                .AsNoTracking().ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);

            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null
            };

            using StreamReader reader = new(_pathName);
            using CsvReader csv = new(reader, config);

            List<WorldCitiesCsv> records = csv.GetRecords<WorldCitiesCsv>().ToList();
            foreach (WorldCitiesCsv record in records)
            {
                if (countriesByName.ContainsKey(record.country))
                {
                    continue;
                }

                Country country = new()
                {
                    Name = record.country,
                    Iso2 = record.iso2,
                    Iso3 = record.iso3
                };
                await _db.Countries.AddAsync(country);
                countriesByName.Add(record.country, country);
            }

            await _db.SaveChangesAsync();

            return new JsonResult(countriesByName.Count);

        }*/

        /*  [HttpPost("Cities")]
          public async Task<IActionResult> ImportCities()
          {
              Dictionary<string, Country> countries = await _db.Countries//.AsNoTracking()
                  .ToDictionaryAsync(c => c.Name);

              CsvConfiguration config = new(CultureInfo.InvariantCulture)
              {
                  HasHeaderRecord = true,
                  HeaderValidated = null
              };
              int cityCount = 0;
              using (StreamReader reader = new(_pathName))
              using (CsvReader csv = new(reader, config))
              {
                  IEnumerable<WorldCitiesCsv>? records = csv.GetRecords<WorldCitiesCsv>();
                  foreach (WorldCitiesCsv record in records)
                  {
                      if (!countries.ContainsKey(record.country))
                      {
                          Console.WriteLine($"Not found country for {record.city}");
                          return NotFound(record);
                      }

                      if (!record.population.HasValue || string.IsNullOrEmpty(record.city_ascii))
                      {
                          Console.WriteLine($"Skipping {record.city}");
                          continue;
                      }
                      City city = new()
                      {
                          Name = record.city,
                          Lat = record.lat,
                          Lon = record.lng,
                          Population = (int)record.population.Value,
                          CountryId = countries[record.country].Id
                      };
                      _db.Cities.Add(city);
                      cityCount++;
                  }
                  await _db.SaveChangesAsync();
              }
              return new JsonResult(cityCount);
          }*/

    }
}

    

