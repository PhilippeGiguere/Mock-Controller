namespace PhotoProfil;

public interface IAnalyseurImage
{
    bool EstValide(byte[] contenu);
}

public interface IStockagePhotos
{
    string Enregistrer(string utilisateur, byte[] contenu);
}

public class ServicePhotoProfil
{
    private readonly IAnalyseurImage _analyseur;
    private readonly IStockagePhotos _stockage;

    public ServicePhotoProfil(IAnalyseurImage analyseur, IStockagePhotos stockage)
    {
        _analyseur = analyseur;
        _stockage = stockage;
    }

    public string Publier(string utilisateur, byte[] contenu)
    {
        if (!_analyseur.EstValide(contenu))
        {
            return "Image invalide";
        }

        try
        {
            return _stockage.Enregistrer(utilisateur, contenu);
        }
        catch (IOException)
        {
            return "Stockage indisponible";
        }
    }
}
