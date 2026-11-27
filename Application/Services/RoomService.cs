using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;
using Domain.Filters;

namespace Application.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private IRoomRepository repository = roomRepository;
    public async Task<PagedResponse<bool>> AddRoomAsync(CreateRoomDto dto)
    {
        var room = new Room()
        {
            Name = dto.Name
        };
        var res = await repository.AddRoomAsync(room);
        return res==true
        ? new PagedResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new PagedResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<PagedResponse<bool>> DeactivateRoomAsync(int id)
    {
        var res = await repository.DeactivateRoomAsync(id);
        return res==true
        ? new PagedResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new PagedResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }


    public async Task<PagedResponse<List<RoomDto>>> GetRoomsAsync(RoomFilter filter)
    {
        var rooms = await repository.GetRoomsAsync(filter);
        var items = rooms.Items.Select(x=>new RoomDto()
        {
            Id = x.Id,
            Name = x.Name,
            IsActive = x.IsActive
        }).ToList();
        return new PagedResponse<List<RoomDto>>(
            items,
            rooms.TotalCount,
            rooms.PageNumber,
            rooms.PageSize,
            "List of rooms.");
    }

    public async Task<PagedResponse<bool>> UpdateRoomAsync(int id, UpdateRoomDto dto)
    {
        var room = new Room()
        {
            Id = id,
            Name = dto.Name,
            IsActive = dto.IsActive
        };
        var res = await repository.UpdateRoomAsync(room);
        return res==true
        ? new PagedResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new PagedResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}