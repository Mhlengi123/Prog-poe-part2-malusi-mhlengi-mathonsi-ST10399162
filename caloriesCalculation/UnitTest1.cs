using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RecipeApplicationTests
{
    [TestFixture]
    public class RecipeManagerTests
    {
        [Test]
        public void CalculateTotalCalories_CalculatesCorrectly()
        {
            // Arrange
            RecipeManager recipeManager = new RecipeManager();
            var recipe = new Recipe("Test Recipe")
            {
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Ingredient 1", Calories = 100 },
                    new Ingredient { Name = "Ingredient 2", Calories = 150 },
                    new Ingredient { Name = "Ingredient 3", Calories = 200 }
                }
            };

            // Act
            double totalCalories = recipeManager.CalculateTotalCalories(recipe);

            // Assert
            Assert.AreEqual(450, totalCalories); // Total calories should be 100 + 150 + 200 = 450
        }
    }

    internal class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }

    internal class TestAttribute : Attribute
    {
    }

    internal class TestFixtureAttribute : Attribute
    {
    }

    internal class Recipe
    {
        private string v;

        public Recipe(string v)
        {
            this.v = v;
        }

        public List<Ingredient> Ingredients { get; set; }
    }

    internal class RecipeManager
    {
        internal double CalculateTotalCalories(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}

