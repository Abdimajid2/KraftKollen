namespace KraftKollen.Helpers
{
    public class GwhTwhResult
    {
        public double Gwh { get; set; }
        public double Twh { get; set; }

        public override string ToString() // For a more user-friendly representation of the object.
        {
            return $"Gwh: {Gwh} | Twh: {Twh}";
        }
    }
}
