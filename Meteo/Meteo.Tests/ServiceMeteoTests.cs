using Meteo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace Meteo.Tests;

[TestClass]
public class ServiceMeteoTests
{
    [TestMethod]
    public void ObtenirBulletin_TemperatureDisponibleAuPremierAppel_Affiche18Degres()
    {
        // Pour Montréal, le fournisseur renvoie 18 au premier appel.
        Assert.Inconclusive("À compléter");
    }

    [TestMethod]
    public void ObtenirBulletin_TemperatureDisponibleAuDeuxiemeAppel_Affiche21Degres()
    {
        // Pour Montréal, le fournisseur renvoie null, puis 21.
        Assert.Inconclusive("À compléter");
    }

    [TestMethod]
    public void ObtenirBulletin_TemperatureAbsenteAuxDeuxAppels_AfficheMeteoIndisponible()
    {
        // Pour Montréal, le fournisseur renvoie null aux deux appels.
        Assert.Inconclusive("À compléter");
    }
}
