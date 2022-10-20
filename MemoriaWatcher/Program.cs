internal static class DriveProgram
{
    public static void Main(string[] args)
    {


        FileSystemWatcher watch = new FileSystemWatcher();

        DriveInfo[] meghajtok = DriveInfo.GetDrives();
        foreach (var m in meghajtok)
        {
            Console.Write(m.Name.Substring(0, 1));
        }

        Console.Write("\nMelyik meghajtó adatait szeretné látni? ");
        string valasz = Console.ReadLine();
        int index = -1;
        bool letezik = false;
        int i;
        for (i = 0; i < meghajtok.Length; i++)
        {
            if (meghajtok[i].Name.Substring(0, 1).Equals(valasz))
            {
                letezik = true;
                index = i;
            }
        }

        if (letezik)
        {
            if (meghajtok[index].IsReady)
            {
                Console.WriteLine("\nMeghajtó neve: " + meghajtok[index].Name);
                Console.WriteLine("Kötetcímke: " + meghajtok[index].VolumeLabel);
                Console.WriteLine("Fájlrendszer: " + meghajtok[index].DriveFormat);
                Console.WriteLine("Típus: " + meghajtok[index].DriveType);
                float totalSizeMB = (float)meghajtok[index].TotalSize / 1024 / 1024;
                float totalFreeMB = (float)meghajtok[index].TotalFreeSpace / 1024 / 1024;
                float telitettseg = (float)totalFreeMB / totalSizeMB * 100;
                Console.WriteLine("Teljes méret: " + totalSizeMB + " MB");
                Console.WriteLine("Szabadhely: " + telitettseg + "%");
            }
            else
            {
                Console.WriteLine("Nincs benne lemez, vagy nem áll készén további műveletekre!");
            }
        }
        else
        {
            Console.WriteLine("Hiba: Nincs ilyen meghajtó!");
        }
    }
}
