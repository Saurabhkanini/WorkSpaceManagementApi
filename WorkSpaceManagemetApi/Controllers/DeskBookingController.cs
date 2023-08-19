using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskBookingController : ControllerBase
    {
        private readonly IDeskBooking _deskBookingRepo;

        public DeskBookingController(IDeskBooking deskBookingRepo)
        {
            _deskBookingRepo = deskBookingRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeskBooking>> GetAllDbookings()
        {
            var deskBookings = _deskBookingRepo.GetAllDbooking();
            if (deskBookings == null)
            {
                return NotFound();
            }
            return Ok(deskBookings);
        }

        [HttpGet("{id}")]
        public ActionResult<DeskBooking> GetDbookingById(int id)
        {
            var deskBooking = _deskBookingRepo.GetDbooking(id);
            if (deskBooking == null)
            {
                return NotFound();
            }
            return Ok(deskBooking);
        }

        [HttpPost]
        public ActionResult<DeskBooking> BookDesk(DeskBooking deskBooking)
        {
            var bookedDesk = _deskBookingRepo.BookDesk(deskBooking);
            if (bookedDesk == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetDbookingById), new { id = bookedDesk.BookingId }, bookedDesk);
        }

        [HttpPut("{id}")]
        public ActionResult<DeskBooking> UpdateDbookingDetail(int id, DeskBooking deskBooking)
        {
            var updatedDeskBooking = _deskBookingRepo.UpdateDbookingDetail(deskBooking, id);
            if (updatedDeskBooking == null)
            {
                return NotFound();
            }
            return Ok(updatedDeskBooking);
        }

        [HttpDelete("{id}")]
        public ActionResult<DeskBooking> DeleteBooking(int id)
        {
            var deletedBooking = _deskBookingRepo.DeleteBooking(id);
            if (deletedBooking == null)
            {
                return NotFound();
            }
            return Ok(deletedBooking);
        }

    }
}
