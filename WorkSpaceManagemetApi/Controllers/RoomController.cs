using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomDetail _roomDetailRepo;

        public RoomController(IRoomDetail roomDetailRepo)
        {
            _roomDetailRepo = roomDetailRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDetail>> GetAllRooms()
        {
            var roomDetails = _roomDetailRepo.GetAllRooms();
            if (roomDetails == null)
            {
                return NotFound();
            }
            return Ok(roomDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomDetail> GetRoomDetailById(int id)
        {
            var roomDetail = _roomDetailRepo.GetRoomDetail(id);
            if (roomDetail == null)
            {
                return NotFound();
            }
            return Ok(roomDetail);
        }

        [HttpPost]
        public ActionResult<RoomDetail> AddRoom(RoomDetail roomDetail)
        {
            var addedRoom = _roomDetailRepo.AddRoom(roomDetail);
            if (addedRoom == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetRoomDetailById), new { id = addedRoom.RoomId }, addedRoom);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomDetail> UpdateRoomDetail(int id, RoomDetail roomDetail)
        {
            var updatedRoom = _roomDetailRepo.UpdateRoomDetail(roomDetail, id);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return Ok(updatedRoom);
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomDetail> DeleteRoom(int id)
        {
            var deletedRoom = _roomDetailRepo.DeleteRoom(id);
            if (deletedRoom == null)
            {
                return NotFound();
            }
            return Ok(deletedRoom);
        }
    }
}
