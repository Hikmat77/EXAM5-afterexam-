using Application.Responces;
using Domain.Models;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<ApiResronce<bool>> AddRoom(Room room);
    Task<ApiResronce<bool>> UpdateRoom(Room room);
    Task<ApiResronce<bool>> DeleteRoom(int id);
}