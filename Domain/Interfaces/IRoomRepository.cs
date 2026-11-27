using Domain.Models;
using Domain.Filters;

namespace Domain.Interfaces;

public interface IRoomRepository
{
    Task<bool> AddRoomAsync(Room room);
    Task<bool> UpdateRoomAsync(Room room);
    Task<bool> DeactivateRoomAsync(int id);
    Task<PagedResult<Room>> GetRoomsAsync(RoomFilter filter);
}
