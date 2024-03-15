namespace ObseleteAttributeExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Update[] updates =
            {
                new Update(1 , "Potential bugs"),

                new Update(2 , "new features"),

                new Update(3 , "new app"),
            };
            /*
                        UpdateProccessor.Download(updates);
                        UpdateProccessor.Install(updates);*/
            UpdateProccessor.DownloadInstall(updates);




            Console.ReadLine();
        }
    }

    class UpdateProccessor
    {
        [Obsolete]
        public static void Download(Update[] updates)
        {
            for (int i = 0, n = updates.Length; i < n; i++)
            {
                Console.WriteLine($"Downloading {updates[i]}");
                Thread.Sleep(1000);
            }
            
        }

        [Obsolete]
        public static void Install(Update[] updates)
        {
            for (int i = 0, n = updates.Length; i < n; i++)
            {
                Console.WriteLine($"Installing {updates[i]}");
                Thread.Sleep(1000);
            }
            
        }

        //let's suppose that the client want the download and install will be in the same time
        //we need to get rid of the old methods and build new method called DownloadInstall();
        //we need to notify all developers that we need to get rid of the old two methods in the future
        public static void DownloadInstall(Update[] updates)
        {
            for (int i = 0, n = updates.Length; i < n; i++)
            {
                Console.WriteLine($"Downloading {updates[i]}");
                Console.WriteLine($"Installing {updates[i]}");
                Console.WriteLine("----");
                Thread.Sleep(1000);
            }
        }
    }
    class Update
    {
        public int No { get; set; }
        public string Title { get; set; }

        public Update(int no, string title)
        {
            No = no;
            Title = title;
        }

        public override string ToString()
        {
            return $"{No} - {Title}";
        }

    }
}
