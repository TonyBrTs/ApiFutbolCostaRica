using System.Threading.Tasks;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;
public interface IPlayerRepository
{
    Task<int> RegistrarNuevoJugador(Player player);
}

