using InventoryBusiness;
using PantryInventoryData;
using PantryModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace PantryInventoryUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
            static void Menu()
        {
                UIOptions uiOptions = new UIOptions();

                Console.WriteLine("Welcome to the Pantry! \n\nWhat would you like to do?\n");
                Console.WriteLine("1.Display Item \n2.Get an item \n3.Exit");

                int input = Convert.ToInt16(Console.ReadLine());
                string ItemName = null, ItemType = null;
                int Quantity = 0;

                Console.WriteLine("-----------------------------------");

                switch (input)
                {
                    case 1:
                        uiOptions.Display();
                        Menu();
                        break;

                    case 2:
                        uiOptions.AddItem(ItemName, ItemType, Quantity);
                        Menu();
                        break;
                    case 3:
                        Console.WriteLine("\nThank you for your visit. Good day :) ");
                        break;

                default:
                        Console.WriteLine("\nInvalid Input!");
                        Menu();
                        break;
                }
         
           
            }
    }
}
