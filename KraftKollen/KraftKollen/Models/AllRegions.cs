namespace KraftKollen.Models;

public class AllRegions
{
    public static List<Region> GetAllRegions()
    {
        return new List<Region>
        {
            new Region { Id = "0001", Name = "Region Stockholm" },
            new Region { Id = "0003", Name = "Region Uppsala" },
            new Region { Id = "0004", Name = "Region Sörmland" },
            new Region { Id = "0005", Name = "Region Östergötland" },
            new Region { Id = "0006", Name = "Region Jönköpings län" },
            new Region { Id = "0007", Name = "Region Kronoberg" },
            new Region { Id = "0008", Name = "Region Kalmar" },
            new Region { Id = "0009", Name = "Region Gotland" },
            new Region { Id = "0010", Name = "Region Blekinge" },
            new Region { Id = "0012", Name = "Region Skåne" },
            new Region { Id = "0013", Name = "Region Halland" },
            new Region { Id = "0014", Name = "Västra Götalandsregionen" },
            new Region { Id = "0017", Name = "Region Värmland" },
            new Region { Id = "0018", Name = "Region Örebro län" },
            new Region { Id = "0019", Name = "Region Västmanland" },
            new Region { Id = "0020", Name = "Region Dalarna" },
            new Region { Id = "0021", Name = "Region Gävleborg" },
            new Region { Id = "0022", Name = "Region Västernorrland" },
            new Region { Id = "0023", Name = "Region Jämtland Härjedalen" },
            new Region { Id = "0024", Name = "Region Västerbotten" },
            new Region { Id = "0025", Name = "Region Norrbotten" }
        };
    }
}