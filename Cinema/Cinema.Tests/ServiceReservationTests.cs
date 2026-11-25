using Cinema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace Cinema.Tests;

[TestClass]
public class ServiceReservationTests
{
    [TestMethod]
    public void ReserverPlace_Place12Disponible_ConfirmeLaReservation()
    {
        Mock<ISalleCinema> salle = new Mock<ISalleCinema>();
        salle.Setup(s => s.EstDisponible(12)).Returns(true);
        ServiceReservation service = new ServiceReservation(salle.Object);
        ResultatReservation resultat = service.ReserverPlace(12);
        Assert.AreEqual(ResultatReservation.Confirmee, resultat);
    }

    [TestMethod]
    public void ReserverPlace_Place12Occupee_RetournePlaceOccupee()
    {
        Mock<ISalleCinema> salle = new Mock<ISalleCinema>();
        salle.Setup(s => s.EstDisponible(12)).Returns(false);
        ServiceReservation service = new ServiceReservation(salle.Object);
        ResultatReservation resultat = service.ReserverPlace(12);
        Assert.AreEqual(ResultatReservation.PlaceOccupee, resultat);
    }

    [TestMethod]
    public void ReserverPlace_Place0_RetournePlaceInvalide()
    {
        Mock<ISalleCinema> salle = new Mock<ISalleCinema>();
        ServiceReservation service = new ServiceReservation(salle.Object);
        ResultatReservation resultat = service.ReserverPlace(0);
        Assert.AreEqual(ResultatReservation.PlaceInvalide, resultat);
    }

    [TestMethod]
    public void ReserverPlace_Place51_RetournePlaceInvalide()
    {
        Mock<ISalleCinema> salle = new Mock<ISalleCinema>();
        ServiceReservation service = new ServiceReservation(salle.Object);
        ResultatReservation resultat = service.ReserverPlace(51);
        Assert.AreEqual(ResultatReservation.PlaceInvalide, resultat);
    }
}
