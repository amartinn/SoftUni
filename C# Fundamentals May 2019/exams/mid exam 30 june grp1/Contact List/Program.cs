    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Contact_List
    {
        class Program
        {
            static void Main(string[] args)
            {
                var contacts = Console.ReadLine()
                .Split()
                .ToList();
                var commandArgs = Console.ReadLine();
                while (true)
                {
                    var tokens = commandArgs.Split();
                    var command = tokens[0];
                    if (command.Equals("Print"))
                    {
                        var temp = tokens[1];
                        Console.Write("Contacts: ");
                        if (temp.Equals("Reversed"))
                        {
                        contacts.Reverse();
                    }
                    Console.WriteLine(string.Join(" ", contacts));
                    break;
                }
                    else if (command.Equals("Add"))
                    {
                        
                       var contact = tokens[1];
                       var index = int.Parse(tokens[2]);
                       if (!contacts.Contains(contact))
                       {
                           contacts.Add(contact);
                       }
                       else
                       {
                           if (index>=0 && index<contacts.Count)
                           {
                               contacts.Insert(index, contact);
                           }
                       }
                }
                    else if (command.Equals("Remove"))
                    {
                        var index = int.Parse(tokens[1]);
                        if (index >= 0 && index < contacts.Count)
                        {
                            contacts.RemoveAt(index);
                        }
                    }
                    else if (command.Equals("Export"))
                    {
                       var startIndex = int.Parse(tokens[1]);
                       var count = int.Parse(tokens[2]);
                    var temp = new List<string>();
                    if (count>contacts.Count || count<0)
                       {
                           count = contacts.Count;
                        for (int i = startIndex; i < count; i++)
                        {
                            temp.Add(contacts[i]);

                        }
                    }
                    else
                    {
                        for (int i = startIndex; i < count+startIndex; i++)
                        {
                            temp.Add(contacts[i]);

                        }
                    }
                     
                       if (temp.Count>0)
                       {
                       Console.WriteLine(string.Join(" ",temp));
                       }
                    
                    }

                    commandArgs = Console.ReadLine();

                } 
            }
        }
    }
