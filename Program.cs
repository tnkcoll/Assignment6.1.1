using Assignment6._1._1.Controls.Classes;
using System.ComponentModel.Design;

namespace Assignment6._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //I declared these 6 variables, and intiated 2 of them, here so they will be in scope when I need them later.
            int i = 0;
            int houseNumber;
            string? houseAddress;
            string? houseType;
            bool addAnotherHouse = true;
            House newHouse;

            //Instantiated a linked list. The list holds a KeyValuePair class which holds the House and integer classes.
            LinkedList<KeyValuePair<House, int>> houseList = new LinkedList<KeyValuePair<House, int>>();
           

            do
            {                
                houseNumber = Convert.ToInt32(GetHouseInfoFromUser("Enter the street number of the house to add to the list."));
                houseAddress = GetHouseInfoFromUser("Enter the street name of the house to add to the list.");
                houseType = GetHouseInfoFromUser("Enter the type of the house ");

                string? userResponse = "";

                //Call the AddHouse method to instantiate a new House object.
                newHouse = AddHouse(houseNumber, houseAddress, houseType);

                //Instantiates a KeyValuePair that pairs a House object to an integer. The integer i + 1 sets the pointer to the next list item in the linkedlist.
                KeyValuePair<House, int> newHousePair = new KeyValuePair<House, int>(newHouse, i + 1);

                //Adds the KeyValuePair to the linkedlist called houseList.
                houseList.AddLast(newHousePair);

                Console.WriteLine("Do you want to add another house? Type Y or N.");
                userResponse = Console.ReadLine().ToUpper();

                do
                {
                    if (userResponse == "Y")
                    {
                        addAnotherHouse = true;
                        i++; //Increments i so the next KeyValuePair to be added to the linkedlist called houseList will set the pointer to the next list item.
                    }
                    else if (userResponse == "N")
                    {
                        addAnotherHouse = false;
                    }
                } while (userResponse == "");


            } while (addAnotherHouse != false);

            houseNumber = Convert.ToInt32(GetHouseInfoFromUser("Please enter the street number of the house that you want info of."));

            //Writes the string that is returned from the GetHouseDetails method.
            Console.WriteLine(GetHouseDetails(houseNumber, houseList));
        }

        static string? GetHouseInfoFromUser(string prompt)
        {
            string? userInput = "";

            do
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();
            } while (userInput == "");

            return userInput;
        }

        static House AddHouse(int number, string? address, string? type)
        {
            House newHouse = new House(number, address, type);
            
            return newHouse;
        }

        static string GetHouseDetails(int house, LinkedList<KeyValuePair<House, int>> houseList)
        {
            //Iterate through the linkedlist called houseList to see if the KeyValuePair item in house contains the house number the user provided. If so, it returns the house object information.
            //If not, it returns the string "There is no house with that number in the list".
            foreach (var pair in houseList) 
            {

                if (house == pair.Key.Number)
                {
                    return pair.Key.Number.ToString() + " " + pair.Key.Address.ToString() + ", " + pair.Key.Type.ToString();
                }
            }
            return "There is no house with that number in the list";
        }
    }
}
