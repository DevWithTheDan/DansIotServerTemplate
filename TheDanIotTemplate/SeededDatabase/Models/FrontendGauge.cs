namespace SeededDatabase.Models
{
    public class FrontendGauge
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double StartAngle { get; set; } = -150;
        public double EndAngle { get; set; } = 150;
        public double Step { get; set; } = 20;
        public double Min { get; set; } = 0;
        public double Max { get; set; } = 100;
        public int GaugeTickPosition { get; set; } = 0;
        public int HeightPx { get; set; } = 250;
        public int WidthPx { get; set; } = 250;
        public string Suffix { get; set; } = "s";
    }
}
