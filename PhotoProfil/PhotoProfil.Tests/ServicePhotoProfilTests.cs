using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace PhotoProfil.Tests;

[TestClass]
public class ServicePhotoProfilTests
{
    [TestMethod]
    public void Publier_PhotoAcceptee_RetourneAdresse()
    {
        // Pour lea, le stockage renvoie "/photos/lea.png".
       
    }

    [TestMethod]
    public void Publier_PhotoRefusee_RetourneImageInvalide()
    {
        Assert.Inconclusive("À compléter");
    }

    [TestMethod]
    public void Publier_PanneDeStockage_RetourneStockageIndisponible()
    {
        // La photo est valide et le stockage lance une IOException.
        Assert.Inconclusive("À compléter");
    }

    [TestMethod]
    public void Publier_AdresseCalculee_UtiliseLeNomRecu()
    {
        // Appelle Publier pour lea et sam et vérifie les deux adresses.
        Assert.Inconclusive("À compléter");
    }
}
