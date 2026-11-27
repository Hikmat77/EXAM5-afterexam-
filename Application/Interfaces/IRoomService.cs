using Application.DTOs;
using Application.Responces;
using Domain.Filters;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<PagedResponse<bool>> AddRoomAsync(CreateRoomDto dto);
    Task<PagedResponse<bool>> UpdateRoomAsync(int id, UpdateRoomDto dto);
    Task<PagedResponse<bool>> DeactivateRoomAsync(int id);
    Task<PagedResponse<List<RoomDto>>> GetRoomsAsync(RoomFilter filter);
}
