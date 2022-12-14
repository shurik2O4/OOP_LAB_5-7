using OOP_Lab;

namespace OOP_Lab.Test {
    [TestClass]
    public class CatTest {

        [TestMethod]
        public void Cat_Create() {
            Cat cat = new Cat("Newcat", 1.0, Gender.Male, CatType.British);

            Assert.IsInstanceOfType(cat, typeof(Cat));
        }

        [TestMethod]
        public void Cat_CreateFromCatData() {
            CatData catData = new CatData {Name = "Newcat", Age = 1.0, Gender = Gender.Male, Type = CatType.British};
            Cat cat = new Cat(catData);

            Assert.IsInstanceOfType(cat, typeof(Cat));
        }

        [TestMethod]
        public void Cat_CreateNoParameters() {
            string input = "Test\n1.0\nM\nRagdoll\n";

            Cat cat = new Cat(new StringReader(input), new StringWriter());

            Assert.IsInstanceOfType(cat, typeof(Cat));
        }

        [TestMethod]
        public void Cat_IsACat_Cat() {
            bool isCat = Cat.IsACat("Cat");

            Assert.IsTrue(isCat);
        }

        [TestMethod]
        public void Cat_IsACat_CatUpper() {
            bool isCat = Cat.IsACat("CAT");

            Assert.IsTrue(isCat);
        }

        [TestMethod]
        public void Cat_IsACat_Jaguar() {
            bool isCat = Cat.IsACat("Jaguar");

            Assert.IsTrue(isCat);
        }

        [TestMethod]
        public void Cat_IsACat_Bird() {
            bool isCat = Cat.IsACat("Bird");

            Assert.IsFalse(isCat);
        }

        [TestMethod]
        public void Cat_IsACat_Dog() {
            bool isCat = Cat.IsACat("Dog");

            Assert.IsFalse(isCat);
        }

        [TestMethod]
        public void Cat_IsACat_EmptyString() {
            bool isCat = Cat.IsACat("");

            Assert.IsFalse(isCat);
        }
    }
}