// See https://aka.ms/new-console-template for more information


internal class Program {
    public enum Kelurahan
    {
        Batununggal,
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja 
    };
    public class KodePos_1302210006
    {
        public static int getKodePos(Kelurahan kelurahan)
        {
            int[] kodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
            return kodePos[(int)kelurahan];
        }
    }

    public static void Main(string[] args)
    {
        Kelurahan kelurahan = Kelurahan.Batununggal;
        int kodePos = KodePos_1302210006.getKodePos(kelurahan);
        Console.WriteLine("Kelurahan: " + kelurahan + "\nKode pos: " + kodePos);
    }
}

