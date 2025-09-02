namespace ProjectCQRS.Models
{
    public class GasPriceData
    {
        public List<GasPriceVM> Result { get; set; }
    }
    public class GasPriceVM
    {
        public string? currency { get; set; }
        public string? lpg { get; set; }
        public string? diesel { get; set; }
        public string? gasoline { get; set; }
        public string? country { get; set; }

    }

}
