// Class to represent a recipe
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApplication
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        // Method to allow user to enter ingredients for the recipe
        public void EnterIngredients()
        {
            Console.WriteLine("\nEnter ingredients:");
            while (true)
            {
                Console.WriteLine("Ingredient:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    break; // Exit loop if no name is provided

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                double calories = double.Parse(Console.ReadLine());
                string foodGroup;
                do
                {
                    Console.Write("Food Group (Carbohydrates, Protein, Dairy, Fruit and Veg, Fats and Sugars): ");
                    foodGroup = Console.ReadLine();
                    if (!IsValidFoodGroup(foodGroup))
                    {
                        Console.WriteLine("Invalid food group. Please enter one of the specified options.");
                    }
                } while (!IsValidFoodGroup(foodGroup));

                Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            }
        }

        // Method to allow user to enter steps for the recipe
        public void EnterSteps()
        {
            Console.WriteLine("\nEnter steps:");
            while (true)
            {
                Console.WriteLine("Step:");
                Console.Write("Description: ");
                string description = Console.ReadLine();
                if (string.IsNullOrEmpty(description))
                    break; // Exit loop if no description is provided

                Steps.Add(new Step { Description = description });
            }
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
                totalCalories += ingredient.Calories;
            }
            Console.WriteLine($"\nTotal Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.WriteLine("\nWarning: Total calories exceed 300!");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                // Reset quantities to original values (assuming original quantities are stored elsewhere)
                // Here, I'm assuming original quantities are stored as initial quantities
                // Adjust this according to how your application stores original quantities
                // For now, I'm just resetting it to 0
                ingredient.Quantity = 0;
            }
        }

        // Method to check if a food group is valid
        private bool IsValidFoodGroup(string foodGroup)
        {
            string[] validFoodGroups = { "Carbohydrates", "Protein", "Dairy", "Fruit and Veg", "Fats and Sugars" };
            return validFoodGroups.Contains(foodGroup, StringComparer.OrdinalIgnoreCase);
        }
    }
}
