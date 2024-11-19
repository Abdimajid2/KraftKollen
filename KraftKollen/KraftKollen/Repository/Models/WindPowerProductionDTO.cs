namespace KraftKollen.Repository.Models;

public class WindPowerProductionDTO
{
    public int count { get; set; }
    public Values[] values { get; set; }

    public class Values
    {
        public string kpi { get; set; }
        public string municipality { get; set; }
        public int period { get; set; }
        public Values1[] values { get; set; }
    }

    public class Values1
    {
        public int count { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
        public double value { get; set; }
    }
}