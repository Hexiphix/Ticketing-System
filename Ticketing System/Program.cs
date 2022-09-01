namespace Ticketing_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "ticket.txt";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create new file from data. (This will replace any old file)");
                Console.WriteLine("Enter any other key to exit.");

                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        // Skips through the First Line
                        string line = sr.ReadLine();
                        // read data from file
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            // display array data
                            Console.WriteLine("\nTicketID: {0}\nSummary: {1}\nStatus: {2}\nPriority: {3}\nSubmitter: {4}\nAssigned: {5}", 
                                arr[0], arr[1], arr[2], arr[3], arr[4], arr[5]);
                            // splits up who is watching
                            string[] arr2 = arr[6].Split('|');
                            //Outputs the watchers
                            Console.Write("Watchers: ");
                            for (int i = 0; i < arr2.Length; i++)
                            {
                                if (i != 0)
                                { Console.Write(", "); }
                                Console.Write("{0}", arr2[i]);
                            }
                            Console.WriteLine("\n");
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // makes space for input
                    string[] inputarr = new string[6];
                    string watchinglist = "";

                    // declares the screen writer object creates new file and adds header
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");

                    while (true)
                    {
                        // ask a question
                        Console.WriteLine("Enter a ticket (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }

                        // gets all the ticket inputs
                        Console.WriteLine("Enter the ticket's ID: ");
                        inputarr[0] = Console.ReadLine();
                        Console.WriteLine("Describe the issue: ");
                        inputarr[1] = Console.ReadLine();
                        Console.WriteLine("Ticket Status: ");
                        inputarr[2] = Console.ReadLine();
                        Console.WriteLine("Priority: ");
                        inputarr[3] = Console.ReadLine();
                        Console.WriteLine("Submitter: ");
                        inputarr[4] = Console.ReadLine();
                        Console.WriteLine("Assigned: ");
                        inputarr[5] = Console.ReadLine();

                        watchinglist = "";
                        // gets all the watchers
                        do
                        {
                            Console.WriteLine("User watching this ticket: ");
                            watchinglist = watchinglist + Console.ReadLine();
                            Console.WriteLine("Enter another watcher (Y/N)?");
                            resp = Console.ReadLine().ToUpper();
                            if (resp != "Y") { break; }
                            else { watchinglist = watchinglist + "|"; }
                        } while (true);

                        // inputs the data to the file
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                            inputarr[0], inputarr[1], inputarr[2], inputarr[3],
                            inputarr[4], inputarr[5], watchinglist);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}