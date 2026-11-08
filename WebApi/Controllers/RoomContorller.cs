using Application.Interfaces;
using Application.Responces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class RoomContorller(IRoomService roomService) : ControllerBase
{
    private IRoomService service = roomService;

    [HttpPost]
    public async Task<ApiResronce<bool>> AddRoom(Room room)
    {
        return await service.AddRoom(room);
    }

    [HttpDelete]
    public async Task<ApiResronce<bool>> DeleteRoom(int id)
    {
        return await service.DeleteRoom(id);
    }
    
    [HttpPut]
    public async Task<ApiResronce<bool>> UpdateRoom(Room room)
    {
        return await service.UpdateRoom(room);
    }
}