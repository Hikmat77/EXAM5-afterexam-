using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Domain.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("rooms")]
public class RoomController(
    IRoomService roomService,
    ILogger<RoomController> logger) : ControllerBase
{
    private IRoomService service = roomService;
    private ILogger<RoomController> _logger = logger;

    [HttpPost]
    public async Task<PagedResponse<bool>> AddRoom(CreateRoomDto dto)
    {
        _logger.LogInformation("POST rooms {date}", DateTime.Now);
        return await service.AddRoomAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<PagedResponse<bool>> UpdateRoom(int id, UpdateRoomDto dto)
    {
        _logger.LogInformation("PUT rooms/{id} {date}", id, DateTime.Now);
        return await service.UpdateRoomAsync(id, dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<PagedResponse<bool>> DeactivateRoom(int id)
    {
        _logger.LogInformation("PATCH rooms/{id}/deactivate {date}", id, DateTime.Now);
        return await service.DeactivateRoomAsync(id);
    }

    [HttpGet]
    public async Task<PagedResponse<List<RoomDto>>> GetRooms([FromQuery] RoomFilter filter)
    {
        _logger.LogInformation("GET rooms {date}", DateTime.Now);
        return await service.GetRoomsAsync(filter);
    }
}
