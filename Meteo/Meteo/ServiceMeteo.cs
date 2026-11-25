namespace Meteo;

public interface IFournisseurMeteo
{
    int? LireTemperature(string ville);
}

public class ServiceMeteo
{
    private readonly IFournisseurMeteo _fournisseur;

    public ServiceMeteo(IFournisseurMeteo fournisseur)
    {
        _fournisseur = fournisseur;
    }

    public string ObtenirBulletin(string ville)
    {
        int? temperature = _fournisseur.LireTemperature(ville);

        if (temperature is null)
        {
            temperature = _fournisseur.LireTemperature(ville);
        }

        return temperature is int degres
            ? $"{ville} : {degres} °C"
            : "Météo indisponible";
    }
}
