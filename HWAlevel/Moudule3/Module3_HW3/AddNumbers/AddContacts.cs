using System;
using System.Collections.Generic;

namespace Module3_HW3.AddNumbers
{
    public sealed class AddContacts : ContactCollection
    {
        private string _answer = "";
        private string _chooseUser = "";
        private string _chooseNumbers = "";
        private string _chooseShow = "";
        public void AddContactServices()
        {
            try
            {
                while (!Program.isDone)
                {
                    Console.WriteLine("1 - add numbers" +
                    "\n2 - console clear" +
                    "\n3 - show numbers" +
                    "\n4 - Exit");

                    _chooseUser = Console.ReadLine();
                    switch (_chooseUser)
                    {
                        case "1":
                            Console.WriteLine("Please write country(UK either UA or your country)");
                            _chooseNumbers = Console.ReadLine();
                            AddNumbers();
                            break;
                        case "2":
                            ConsoleClear();
                            break;
                        case "3":
                            Console.WriteLine("1 - show all numbers " +
                            "\n2 - show only UA numbers" +
                            "\n3 - show only UK numbers" +
                            "\n4 - show other numbers" +
                            "\n5 - show other");
                            _chooseShow = Console.ReadLine();

                            ShowNumbers();
                            break;
                        case "4":
                            Program.isDone = true;
                            break;
                        default:
                            Console.WriteLine("Error: please correctly ");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLogger(ex.Message);
            }
        }

        private void ConsoleClear()
        {
            Console.Clear();
        }

        private void ShowNumbers()
        {
            switch (_chooseShow)
            {
                case "1":
                    foreach (var contact in contacts)
                    {
                        string country = contact.Key;
                        List<string> phoneNumbers = contact.Value;

                        Console.WriteLine($"{country}:");

                        foreach (string itemPhoneNumbers in phoneNumbers)
                        {
                            Console.WriteLine($"{itemPhoneNumbers}");
                        }
                    }
                    break;
                case "2":
                    if (contacts.ContainsKey("UA"))
                    {
                        List<string> phoneNumbersUA = contacts["UA"];

                        foreach (string itemUA in phoneNumbersUA)
                        {
                            Console.WriteLine($"UA: {itemUA}");
                        }
                    }
                    break;
                case "3":
                    if (contacts.ContainsKey("UK"))
                    {
                        List<string> phoneNumbersUA = contacts["UK"];

                        foreach (string itemUA in phoneNumbersUA)
                        {
                            Console.WriteLine($"UK: {itemUA}");
                        }
                    }

                    break;
                case "4":
                    if (contacts.ContainsKey("Numbers"))
                    {
                        List<string> phoneNumbersUA = contacts["Numbers"];

                        foreach (string itemUA in phoneNumbersUA)
                        {
                            Console.WriteLine($"Numbers: {itemUA}");
                        }
                    }
                    break;
                case "5":
                    if (contacts.ContainsKey("#"))
                    {
                        List<string> phoneNumbersUA = contacts["#"];

                        foreach (string itemUA in phoneNumbersUA)
                        {
                            Console.WriteLine($"#: {itemUA}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error: please write correctly");
                    break;
            }       
        }

        private void AddNumbers()
        {
            switch (_chooseNumbers)
            {
                case "UK":
                    Console.WriteLine("Please write phone number UK");
                    _chooseNumbers = string.Empty;

                    _answer = Console.ReadLine();
                    string keyUK = "UK";
                    if (_answer.Length == 10)
                    {
                        if (contacts.ContainsKey(keyUK))
                        {
                            contacts[keyUK].Add($"+44{_answer}");
                            _answer = string.Empty;
                        }
                        else
                        {
                            contacts.Add(keyUK, new List<string> { $"+44{_answer}" });
                            _answer = string.Empty;
                        }
                    }
                    else { Default(); }
                    _answer = string.Empty;
                    break;
                case "UA":
                    Console.WriteLine("Please write phone number UA");
                    _chooseNumbers = string.Empty;
                    _answer = Console.ReadLine();

                    string keyUA = "UA";
                    if (_answer.Length == 10)
                    {
                        if (contacts.ContainsKey(keyUA))
                        {
                            contacts[keyUA].Add($"+38{_answer}");
                            _answer = string.Empty;
                        }
                        else
                        {
                            contacts.Add(keyUA, new List<string> { $"+38{_answer}" });
                            _answer = string.Empty;
                        }
                    }
                    else { Default(); }

                    break;
                case null:
                    Console.WriteLine("Please write phone number UK");
                    _answer = Console.ReadLine();
                    string keyUKNull = "UK";

                    if (_answer.Length == 10)
                    {
                        if (contacts.ContainsKey(keyUKNull))
                        {
                            contacts[keyUKNull].Add($"+44{_answer}");
                            _answer = string.Empty;
                        }
                        else
                        {
                            contacts.Add(keyUKNull, new List<string> { $"+44{_answer}" });
                            _answer = string.Empty;
                        }
                    }
                    else { Default(); }
                    break;
                default:
                    if (_chooseNumbers != "UK" || _chooseNumbers != "UA")
                    {
                        Console.WriteLine($"Please write phone number {_answer}");
                        _chooseNumbers = string.Empty;
                        _answer = Console.ReadLine();

                        string keyOther = "Numbers";
                        if (_answer.Length == 10)
                        {
                            if (contacts.ContainsKey(keyOther))
                            {
                                contacts[keyOther].Add($"{_answer}");
                                _answer = string.Empty;
                            }
                            else
                            {
                                contacts.Add(keyOther, new List<string> { _answer });
                                _answer = string.Empty;
                            }
                        }
                        else { Default(); }


                    }
                    break;
            }
        }

        private void Default()
        {
            string key = "#";
            if (contacts.ContainsKey(key))
            {
                contacts[key].Add($"#{_answer}");
            }
            else
            {
                contacts.Add(key, new List<string> { $"#{_answer}" });
            }
            _answer = string.Empty;
        }
    }
}
