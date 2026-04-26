using System.Text.Json;
using System.Text.Json.Serialization;

namespace TP_MODUL9_103022400008 {
    public class CovidConfig {

        [JsonInclude]
        public string satuan_suhu { get; set; }
        [JsonInclude]
        public int batas_hari_deman { get; set; }
        [JsonInclude]
        public string pesan_ditolak { get; set; }
        [JsonInclude]
        public string pesan_diterima { get; set; }

        public CovidConfig() {
            this.satuan_suhu = "celcius";
            this.batas_hari_deman = 12;
            this.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            this.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public static CovidConfig LoadJson() {
            string path = "covid_config.json";

            if (File.Exists(path)) {
                string JsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<CovidConfig>(JsonString);
            }

            return new CovidConfig();
        }


        public void UbahSatuan() {
            if (this.satuan_suhu == "celcius")
            {
                this.satuan_suhu = "fahrenheit";
            }
            else {
                this.satuan_suhu = "celcius";
            }
        }

    }
}