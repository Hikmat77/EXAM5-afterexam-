using Application.DTOs;
using Application.Responces;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<ApiResponse<bool>> AddRoomAsync(CreateRoomDto dto);
    Task<ApiResponse<bool>> UpdateRoomAsync(int id, UpdateRoomDto dto);
    Task<ApiResponse<bool>> DeactivateRoomAsync(int id);
    Task<ApiResponse<List<RoomDto>>> GetRoomsAsync();
}
