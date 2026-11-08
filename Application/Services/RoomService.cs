using System.Net;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private IRoomRepository repository = roomRepository;
    public async Task<ApiResronce<bool>> AddRoom(Room room)
    {
        var res = await repository.AddRoomAsync(room);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Added", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResronce<bool>> DeleteRoom(int id)
    {
        var res = await repository.DeleteRoomAsync(id);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Deleted", res);
    }

    public async Task<ApiResronce<bool>> UpdateRoom(Room room)
    {
        var res = await repository.UpdateRoomAsync(room);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Updated", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Updated", res);
    }

}