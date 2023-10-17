

var a = false;
string[] newarray = new string[10];
void Note()
{
    
    Console.WriteLine("Please write  note");

    string note = Console.ReadLine();
    newarray[0] = note;
    Console.WriteLine("Do you want see note?");
    string user = Console.ReadLine();

    if (user.ToLower() == "no" )
    {
        Console.Clear(); 
    }
    else if (user.ToLower() == "yes" || user.ToLower() == "yeah") 
    {
        
    }
}


while (a == false)
{
    Note();
}





