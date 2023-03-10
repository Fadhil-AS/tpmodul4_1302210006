// See https://aka.ms/new-console-template for more information


using System.Security;

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

    public enum statPintu
    {
        Terkunci,
        Terbuka
    }

    public enum Trigger
    {
        kunciPintu,
        bukaPintu
    }

    class DoorMachine_1302210006
    {
        

        private statPintu currentStat = statPintu.Terkunci;

        public class statTransition {
            public statPintu statAwal;
            public statPintu statAkhir;
            public Trigger trigger;

            public statTransition(statPintu statAwal, statPintu statAkhir, Trigger trigger)
            {
                this.statAwal = statAwal;
                this.statAkhir = statAkhir;
                this.trigger = trigger;
            }
        }

        statTransition[] transitions = new statTransition[]
        {
            new statTransition(statPintu.Terkunci, statPintu.Terkunci, Trigger.kunciPintu),
            new statTransition(statPintu.Terkunci, statPintu.Terbuka, Trigger.bukaPintu),
            new statTransition(statPintu.Terbuka, statPintu.Terbuka, Trigger.bukaPintu),
            new statTransition(statPintu.Terbuka, statPintu.Terkunci, Trigger.kunciPintu)
        };

        private statPintu GetNextStat(statPintu statAwal, Trigger trigger) {
            statPintu statAkhir = statAwal;
            for (int i = 0; i < transitions.Length; i++) {
                statTransition update = transitions[i];

                if (statAwal == update.statAwal && trigger == update.trigger) { 
                    statAkhir = update.statAkhir;
                }
            }
            return statAkhir;
        }

        public void activateTrigger(Trigger trigger) {
            currentStat = GetNextStat(currentStat, trigger);
            Console.WriteLine(currentStat);

            if (currentStat == statPintu.Terkunci)
            {
                Console.WriteLine("Pintu Terkunci");
            }
            else {
                Console.WriteLine("Pintu Terbuka");
            }
        }
    }

    public static void Main(string[] args)
    {
        Kelurahan kelurahan = Kelurahan.Batununggal;
        int kodePos = KodePos_1302210006.getKodePos(kelurahan);
        Console.WriteLine("Kelurahan: " + kelurahan + "\nKode pos: " + kodePos);

        
        DoorMachine_1302210006 objDoor = new DoorMachine_1302210006();
        objDoor.activateTrigger(Trigger.kunciPintu);
        objDoor.activateTrigger(Trigger.bukaPintu);
        objDoor.activateTrigger(Trigger.kunciPintu);
    }
}

