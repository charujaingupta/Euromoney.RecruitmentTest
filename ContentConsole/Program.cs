using ContentAPI;
using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
           
            Console.WriteLine("Enter number corresponds to your user type:\n1 Admin\n2 User\n3 Reader\n4 ContentCurator");
            string userType = Console.ReadLine();
            UserType ut;
            if (!string.IsNullOrEmpty(userType))
            {
                try
                {
                    ut = (UserType)Enum.Parse(typeof(UserType), userType);

                    ContentFactory fac = new ContentFactory(ut);

                    if(ut == UserType.Admin)
                    {
                        string negWords = string.Empty;
                        AdminContentService svc = (AdminContentService)fac.GetServiceInstance();
                        Console.WriteLine("Enter number corresponds to the following action you'd like to do: \n1 Show content\n2 Show negative words\n3 Add negative word\n4 Show negative word\n5 Exit");
                        string adminAction = string.Empty;

                        while (adminAction != "5")
                        {
                            adminAction = Console.ReadLine();
                            if (adminAction == "1")
                            {
                                Console.WriteLine("Displaying content: ");
                                Console.WriteLine(svc.GetContent());
                            }
                            else if (adminAction == "2")
                            {
                                negWords = string.Empty;
                                Console.WriteLine("Displaying negative words: ");
                                svc.GetNegativeWords().ForEach(x => negWords += string.Format("{0}\n", x));
                                Console.WriteLine(negWords);
                            }
                            else if (adminAction == "3")
                            {
                                Console.WriteLine("Enter a word to add a list of negative words: ");
                                string badword = Console.ReadLine();
                                svc.AddNegativeWord(badword);
                            }
                            else if (adminAction == "4")
                            {
                                Console.WriteLine("Enter a word to remove from the list of negative words: ");
                                string badword = Console.ReadLine();
                                svc.RemoveNegativeWord(badword);
                            }
                        }


                    }
                    else if(ut == UserType.User)
                    {
                        //Similar to above implemention as per rules specific to this user 
                        //not implemented due to time constraint
                    }
                    else if(ut == UserType.Reader)
                    {
                        //Similar to above implemention as per rules specific to this user 
                        //not implemented due to time constraint
                    }
                    else if(ut == UserType.ContentCurator)
                    {
                        //Similar to above implemention as per rules specific to this user 
                        //not implemented due to time constraint
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine("Press ANY key to exit.");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
            

        }
    }

}
