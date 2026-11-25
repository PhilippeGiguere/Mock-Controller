namespace Cinema;

public enum ResultatReservation
{
    Confirmee,
    PlaceInvalide,
    PlaceOccupee
}

public interface ISalleCinema
{
    bool EstDisponible(int numeroPlace);
    void Reserver(int numeroPlace);
}

public class ServiceReservation
{
    private readonly ISalleCinema _salle;

    public ServiceReservation(ISalleCinema salle)
    {
        _salle = salle;
    }

    public ResultatReservation ReserverPlace(int numeroPlace)
    {
        if (numeroPlace < 1 || numeroPlace > 50)
        {
            return ResultatReservation.PlaceInvalide;
        }

        if (!_salle.EstDisponible(numeroPlace))
        {
            return ResultatReservation.PlaceOccupee;
        }

        _salle.Reserver(numeroPlace);
        return ResultatReservation.Confirmee;
    }
}
