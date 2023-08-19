using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {
        private readonly IRoomBooking _roomBookingRepo;

        public RoomBookingController(IRoomBooking roomBookingRepo)
        {
            _roomBookingRepo = roomBookingRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomBooking>> GetAllRbookings()
        {
            var roomBookings = _roomBookingRepo.GetAllRbooking();
            if (roomBookings == null)
            {
                return NotFound();
            }
            return Ok(roomBookings);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomBooking> GetRbookingById(int id)
        {
            var roomBooking = _roomBookingRepo.GetRbooking(id);
            if (roomBooking == null)
            {
                return NotFound();
            }
            return Ok(roomBooking);
        }

        [HttpPost]
        public ActionResult<RoomBooking> BookRoom(RoomBooking roomBooking)
        {
            var bookedRoom = _roomBookingRepo.BookRoom(roomBooking);
            if (bookedRoom == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetRbookingById), new { id = bookedRoom.BookingId }, bookedRoom);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomBooking> UpdateRbookingDetail(int id, RoomBooking roomBooking)
        {
            var updatedRoomBooking = _roomBookingRepo.UpdateRbookingDetail(roomBooking, id);
            if (updatedRoomBooking == null)
            {
                return NotFound();
            }
            return Ok(updatedRoomBooking);
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomBooking> DeleteBooking(int id)
        {
            var deletedBooking = _roomBookingRepo.DeleteBooking(id);
            if (deletedBooking == null)
            {
                return NotFound();
            }
            return Ok(deletedBooking);
        }

    }
}
