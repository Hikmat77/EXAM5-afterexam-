using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("rooms")]
public class RoomController(IRoomService roomService) : ControllerBase
{
    private IRoomService service = roomService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddRoom(CreateRoomDto dto)
    {
        return await service.AddRoomAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateRoom(int id, UpdateRoomDto dto)
    {
        return await service.UpdateRoomAsync(id, dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateRoom(int id)
    {
        return await service.DeactivateRoomAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<RoomDto>>> GetRooms()
    {
        return await service.GetRoomsAsync();
    }
}
