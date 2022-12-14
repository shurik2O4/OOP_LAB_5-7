using OOP_Lab;

namespace OOP_Lab.Test {
    [TestClass]
    public class DriverTest {
        
        [TestMethod]
        public void FindCats_FindByName() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));

            List<Cat> result = Driver.FindCats(ref cats, "Clunk").ToList();

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public void FindCats_FindByNameUpper() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));

            List<Cat> result = Driver.FindCats(ref cats, "Tux").ToList();

            Assert.AreEqual(result.Count, 1);
        }
        
        [TestMethod]
        public void FindCats_FindById() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));

            List<Cat> result = Driver.FindCats(ref cats, "1").ToList();

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public void DeleteCats_DeleteByNameOne() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));

            int result = Driver.DeleteCats(ref cats, "Clunk");

            Assert.AreEqual(result, 1);
            Assert.AreEqual(cats.Count, 2);
        }

        [TestMethod]
        public void DeleteCats_DeleteByNameMultiple() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));
            cats.Add(new Cat("Clunk", 1.9, Gender.Male, CatType.Ragdoll));

            int result = Driver.DeleteCats(ref cats, "Clunk");

            Assert.AreEqual(result, 2);
            Assert.AreEqual(cats.Count, 2);
        }

        [TestMethod]
        public void DeleteCats_DeleteByNameFail() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));

            int result = Driver.DeleteCats(ref cats, "Non-existent");

            Assert.AreEqual(result, 0);
            Assert.AreEqual(cats.Count, 3);
        }

        [TestMethod]
        public void DeleteCats_DeleteById() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));

            int result = Driver.DeleteCats(ref cats, "1");

            Assert.AreEqual(result, 1);
            Assert.AreEqual(cats.Count, 2);
        }

        [TestMethod]
        public void DeleteCats_DeleteByIdFail() {
            List<Cat> cats = new();
            cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
            cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
            cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));

            int result = Driver.DeleteCats(ref cats, "5");

            Assert.AreEqual(result, 0);
            Assert.AreEqual(cats.Count, 3);
        }
    }
}