using OOP_Lab;

namespace OOP_Lab.Test
{
    [TestClass]
    public class Utils_Test
    {
        [TestMethod]
        public void Capitalize_OneLetterString() {
            string input = "a";
            string expected = "A";
            string actual = Utils.Capitalize(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Capitalize_TwoLetterString() {
            string input = "ab";
            string expected = "Ab";
            string actual = Utils.Capitalize(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Capitalize_EmptyString() {
            string input = "";
            string expected = "";
            string actual = Utils.Capitalize(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Capitalize_RandomString() {
            string input = "aBcDeFgHiJkLmNoPqRsTuVwXyZ";
            string expected = "ABcDeFgHiJkLmNoPqRsTuVwXyZ";
            string actual = Utils.Capitalize(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckName() {
            string input = "Test\n1.0\nM\nTuxedo\n";
            string expected = "Test";
            string actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Name;
            Assert.AreEqual(expected, actual);
        }

        // Empty string
        [TestMethod]
        public void FillOutCat_Create_CheckName_EmptyString() {
            string input = "\n1.0\nM\nTuxedo\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }

        // age
        [TestMethod]
        public void FillOutCat_Create_CheckAge() {
            string input = "Test\n1.0\nM\nTuxedo\n";
            double expected = 1.0;
            double actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Age;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckAge_Negative() {
            string input = "Test\n-1.0\nM\nTuxedo\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }

        [TestMethod]
        public void FillOutCat_Create_CheckAge_Zero() {
            string input = "Test\n0.0\nM\nTuxedo\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }

        [TestMethod]
        public void FillOutCat_Create_CheckAge_String() {
            string input = "Test\na\nM\nTuxedo\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }

        // cat gender
        [TestMethod]
        public void FillOutCat_Create_CheckGender() {
            string input = "Test\n1.0\nM\nTuxedo\n";
            Gender expected = Gender.Male;
            Gender actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Gender;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckGender_String() {
            string input = "Test\n1.0\na\nTuxedo\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }

        [TestMethod]
        public void FillOutCat_Create_CheckGender_EmptyString() {
            string input = "Test\n1.0\n\nTuxedo\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }

        // Cat breed (type)
        // Cat types: British, Jellie, Persian, Ragdoll, Siamese, Tabby, Tuxedo
        
        [TestMethod]
        public void FillOutCat_Create_CheckBreed_British() {
            string input = "Test\n1.0\nM\nBritish\n";
            CatType expected = CatType.British;
            CatType actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_Jellie() {
            string input = "Test\n1.0\nM\nJellie\n";
            CatType expected = CatType.Jellie;
            CatType actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_Persian() {
            string input = "Test\n1.0\nM\nPersian\n";
            CatType expected = CatType.Persian;
            CatType actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_Ragdoll() {
            string input = "Test\n1.0\nM\nRagdoll\n";
            CatType expected = CatType.Ragdoll;
            CatType actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_Siamese() {
            string input = "Test\n1.0\nM\nSiamese\n";
            CatType expected = CatType.Siamese;
            CatType actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_Tabby() {
            string input = "Test\n1.0\nM\nTabby\n";
            CatType expected = CatType.Tabby;
            CatType actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_Tuxedo() {
            string input = "Test\n1.0\nM\nTuxedo\n";
            CatType expected = CatType.Tuxedo;
            CatType actual = Utils.FillOutCat(new StringReader(input), new StringWriter()).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_Invalid() {
            string input = "Test\n1.0\nM\nInvalid\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }

        [TestMethod]
        public void FillOutCat_Create_CheckBreed_EmptyString() {
            string input = "Test\n1.0\nM\n\n";
            // Check if exception is thrown
            Assert.ThrowsException<ArgumentException>(() => Utils.FillOutCat(new StringReader(input), new StringWriter()));
        }
        
        // Edit cat
        // Edit cat name
        [TestMethod]
        public void EditCat_ChangeName() {
            // Create a cat
            Cat cat = new Cat("Newcat", 1.0, Gender.Male, CatType.British);
            // Edit it
            string input = "Newname\n\n\n\n";
            string expected = "Newname";
            
            Utils.EditCat(cat, new StringReader(input), new StringWriter());
            // Check if the name has changed
            string actual = cat.Name;
            Assert.AreEqual(expected, actual);
        }

        // Edit cat age
        [TestMethod]
        public void EditCat_ChangeAge() {
            // Create a cat
            Cat cat = new Cat("Newcat", 1.0, Gender.Male, CatType.British);
            // Edit it
            string input = "\n2.0\n\n\n";
            double expected = 2.0;

            Utils.EditCat(cat, new StringReader(input), new StringWriter());
            // Check if the age has changed
            double actual = cat.Age;
            Assert.AreEqual(expected, actual);
        }

        // Edit cat gender
        [TestMethod]
        public void EditCat_ChangeGender() {
            // Create a cat
            Cat cat = new Cat("Newcat", 1.0, Gender.Male, CatType.British);
            // Edit it
            string input = "\n\nF\n\n";
            Gender expected = Gender.Female;

            Utils.EditCat(cat, new StringReader(input), new StringWriter());
            
            Gender actual = cat.Gender;
            Assert.AreEqual(expected, actual);
        }

        // Edit cat breed (type)
        [TestMethod]
        public void EditCat_ChangeBreed() {
            // Create a cat
            Cat cat = new Cat("Newcat", 1.0, Gender.Male, CatType.British);
            // Edit it
            string input = "\n\n\nTuxedo\n";
            CatType expected = CatType.Tuxedo;

            Utils.EditCat(cat, new StringReader(input), new StringWriter());
            
            CatType actual = cat.Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodTypeForCatQuestion_Fish() {
            string input = "Fish\n";
            FoodType expected = FoodType.Fish;
            FoodType actual = Utils.FoodTypeForCatQuestion(new StringReader(input), new StringWriter());
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodTypeForCatQuestion_Meat() {
            string input = "Meat\n";
            FoodType expected = FoodType.Meat;
            FoodType actual = Utils.FoodTypeForCatQuestion(new StringReader(input), new StringWriter());
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodTypeForCatQuestion_Invalid() {
            string input = "None\n";
            Assert.ThrowsException<ArgumentException>(() => Utils.FoodTypeForCatQuestion(new StringReader(input), new StringWriter()));
        }

        [TestMethod]
        public void FoodTypeForCatQuestion_EmptyString() {
            string input = "\n";
            Assert.ThrowsException<ArgumentException>(() => Utils.FoodTypeForCatQuestion(new StringReader(input), new StringWriter()));
        }
    }
}