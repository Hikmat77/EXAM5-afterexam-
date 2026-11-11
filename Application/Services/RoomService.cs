using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private IRoomRepository repository = roomRepository;
    public async Task<ApiResponse<bool>> AddRoomAsync(CreateRoomDto dto)
    {
        var room = new Room()
        {
            Name = dto.Name
        };
        var res = await repository.AddRoomAsync(room);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeactivateRoomAsync(int id)
    {
        var res = await repository.DeactivateRoomAsync(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }


    public async Task<ApiResponse<List<RoomDto>>> GetRoomsAsync()
    {
        var rooms = await repository.GetRoomsAsync();
        var res = rooms.Select(x=>new RoomDto()
        {
            Id = x.Id,
            Name = x.Name,
            IsActive = x.IsActive
        }).ToList();
        return new ApiResponse<List<RoomDto>>(HttpStatusCode.OK, "List of rooms.", res);
    }

    public async Task<ApiResponse<bool>> UpdateRoomAsync(int id, UpdateRoomDto dto)
    {
        var room = new Room()
        {
            Id = id,
            Name = dto.Name,
            IsActive = dto.IsActive
        };
        var res = await repository.UpdateRoomAsync(room);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
