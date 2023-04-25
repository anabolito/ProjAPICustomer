using Microsoft.AspNetCore.Mvc;
using ProjAPICustomer.Models;
using ProjAPICustomer.Services;


namespace ProjAPICustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AddressController : Controller
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;


        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]

        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);

            if (address == null) return NotFound();
            return address;
        }


        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
           // address.City = _cityService.Create();//?
            return _addressService.Create(address);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Address address)
        {
            var c = _addressService.Get(id);
            if (c == null) return NotFound();

            _addressService.Update(id, address);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            var address = _addressService.Get(id);

            if (address == null) return NotFound();

            _addressService.Delete(id);
            return Ok();
        }
    }
}
