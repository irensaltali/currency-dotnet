using System.Collections.Generic;

namespace CurrencyDotNetCore.Model
{

    public class DovizComModel
    {
        public List<CurrencyType> Currencies { get; set; }
    }

    public class CurrencyType
    {
        public float selling { get; set; }
        public int update_date { get; set; }
        public int currency { get; set; }
        public float buying { get; set; }
        public float change_rate { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string code { get; set; }
    }

}
