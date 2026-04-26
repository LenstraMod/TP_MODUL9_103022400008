namespace TP_MODUL9_103022400008;


public class Program {
    public static void Main(string[] args) {
        CovidConfig config = CovidConfig.LoadJson();

        string p1;
        string p2;

        for (int i = 0; i < 2; i++){

            Console.Write("Berapa suhu badan anda saat ini? ");
            p1 = Console.ReadLine();

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
            p2 = Console.ReadLine();

            bool isPermit = false;
            double temperature = Double.Parse(p1);
            int days = int.Parse(p2);

            if (config.satuan_suhu == "celcius")
            {
                if (temperature >= 36.5 && temperature <= 37.95 && days <= config.batas_hari_deman) isPermit = true;
            }
            if (config.satuan_suhu == "fahrenheit")
            {
                if (temperature >= 97.7 && temperature <= 99.5 && days <= config.batas_hari_deman) isPermit = true;
            }

            if (isPermit)
            {
                string msg = config.pesan_diterima;
                Console.WriteLine(msg);
            }
            else
            {
                string msg = config.pesan_ditolak;
                Console.WriteLine(msg);
            }

            config.UbahSatuan();
            if (i == 1)
            {
                continue;
            }
            else {
                Console.WriteLine("Satuan diubah ke fahrenheit");
            }
        }
    }
}