using System.Data;
using Newtonsoft.Json;

namespace OOP_Lab {
    public static class Utils {
        public static string Capitalize(string str) => 
            str.Length switch {
                0 => str,
                1 => char.ToUpper(str[0]).ToString(),
                _ => char.ToUpper(str[0]) + str[1..],
        };
        
        public static CatData FillOutCat() {
            return FillOutCat(Console.In, Console.Out);
        }
        public static CatData FillOutCat(TextReader reader, TextWriter writer) {
            string? input;

            // Name
            while (true) {
                writer.Write("Cat name: ");
                input = reader.ReadLine();
                if (input != "" && input != null) { break; }
                else if (reader != Console.In) { throw new ArgumentException("Invalid cat name"); }
            }
            string catName = Utils.Capitalize(input.Trim());

            // Age
            while (true) {
                writer.Write("Cat age (in years): ");
                input = reader.ReadLine();
                if (Double.TryParse(input, out double tmp) && tmp > 0) { break; }
                else if (reader != Console.In) { throw new ArgumentException("Invalid cat age"); }
            }
            double catAge = double.Parse(input);

            // Gender
            while (true) {
                writer.Write("Cat gender (M or F): ");
                input = reader.ReadLine();
                if (input != null) {
                    input = input.Trim().ToLower();
                    if (input == "f" || input == "m") { break; }
                    else if (reader != Console.In) { throw new ArgumentException("Invalid cat gender"); }
                }
                else if (reader != Console.In) { throw new ArgumentException("Invalid cat gender"); }
            }
            Gender catGender = (input == "m") ? Gender.Male : Gender.Female;

            // Type
            while (true) {
                writer.Write("Cat type (British, Jellie, Persian, Ragdoll, Siamese, Tabby, Tuxedo): ");
                input = reader.ReadLine();
                if (input != null) {
                    // Do not allow typing in numbers
                    if (int.TryParse(input, out _)) { 
                        if (reader != Console.In) { throw new ArgumentException("Invalid cat type"); }
                        continue; 
                    }

                    input = Utils.Capitalize(input.Trim());
                    if (Enum.TryParse(typeof(CatType), input, true, out _)) { break; }
                    else if (reader != Console.In) { throw new ArgumentException("Invalid cat type"); }
                }
            }
            CatType catType = (CatType)Enum.Parse(typeof(CatType), input);

            return new CatData { Name = catName, Age = catAge, Gender = catGender, Type = catType };
        }

        public static Cat EditCat(Cat cat) {
            return EditCat(cat, Console.In, Console.Out);
        }
        public static Cat EditCat(Cat cat, TextReader reader, TextWriter writer) {
            string? input = "";
            writer.WriteLine($"Editing (id: {cat.Id}, name: {cat.Name}).");
            writer.WriteLine($"Press Enter to skip the field.");

            var (catName, catAge, catGender, catType) = cat;

            // Name
            // This while is kinda useless
            while (true) {
                writer.Write($"Cat name [{catName}]: ");
                input = reader.ReadLine();
                // Change name if new was given.
                if (input != "" && input != null) { catName = Utils.Capitalize(input.Trim()); break; }
                // Just exit if not
                break;
            }

            // Age
            while (true) {
                writer.Write($"Cat age (in years) [{catAge}]: ");
                input = reader.ReadLine();
                // Exit without changes
                if (input == "") { break; }
                if (Double.TryParse(input, out double tmp) && tmp > 0) { catAge = double.Parse(input); break; }
                else if (reader != Console.In) { throw new ArgumentException("Invalid cat age"); }
            }

            // Gender
            while (true) {
                writer.Write($"Cat gender (M or F) [{catGender}]: ");
                input = reader.ReadLine();
                // Try changing age if new was given (Will loop back if value is invalid).
                if (input != "" && input != null)
                {
                    input = input.Trim().ToLower();
                    if (input == "f" || input == "m") { catGender = (input == "m") ? Gender.Male : Gender.Female; break; }
                    else if (reader != Console.In) { throw new ArgumentException("Invalid cat gender"); }
                    continue;
                }
                // Just exit if not
                break;
            }

            // Type
            while (true) {
                writer.Write($"Cat type (British, Jellie, Persian, Ragdoll, Siamese, Tabby, Tuxedo) [{catType}]: ");
                input = reader.ReadLine();
                // Try changing type if new was given (Will loop back if value is invalid).
                if (input != "" && input != null) {
                    // Do not allow typing in numbers
                    if (int.TryParse(input, out _)) { 
                        if (reader != Console.In) { throw new ArgumentException("Invalid cat type"); }
                        continue; 
                    }
                    input = Utils.Capitalize(input.Trim());
                    if (Enum.TryParse(typeof(CatType), input, true, out _)) { catType = (CatType)Enum.Parse(typeof(CatType), input); break; }
                    else if (reader != Console.In) { throw new ArgumentException("Invalid cat type"); }
                    continue;
                }
                // Just exit if not
                break;
            }

            // Update properties
            cat.Name = catName;
            cat.Age = catAge;
            cat.Gender = catGender;
            cat.Type = catType;
            // and return
            return cat;
        }
        
        // At this point I gave up trying to make good names for functions
        // (Or to code this properly lol).
        public static FoodType FoodTypeForCatQuestion() {
            return FoodTypeForCatQuestion(Console.In, Console.Out);
        }
        public static FoodType FoodTypeForCatQuestion(TextReader reader, TextWriter writer) {
            string? input;

            while (true) {
                writer.Write("Food type (Fish, Meat): ");
                input = reader.ReadLine();
                if (input != null) {
                    // Do not allow typing in numbers
                    if (int.TryParse(input, out _)) { 
                        if (reader != Console.In) { throw new ArgumentException("Invalid cat food type"); }
                        continue;
                    }
                    input = Utils.Capitalize(input.Trim());
                    if (Enum.TryParse(typeof(FoodType), input, true, out _)) { break; }
                    else if (reader != Console.In) { throw new ArgumentException("Invalid cat food type"); }
                }
            }
            return (FoodType)Enum.Parse(typeof(FoodType), input);
        }


        public static void SaveAsJson(ref List<Cat> cats, string path) {
            // Create JSON
            string json = JsonConvert.SerializeObject(cats, Formatting.Indented);

            // Write to file
            File.WriteAllText(path, json);
        }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public static int LoadFromJson(ref List<Cat> cats, string path) {
            List<CatData> catDataSet;
            // Read from file
            try {
                // Read as string
                string json = File.ReadAllText(path);
                // Convert to data
                catDataSet = JsonConvert.DeserializeObject<List<CatData>>(json);
            } catch (Exception e) {
                Console.WriteLine("Error while reading JSON file: " + e.Message);
                return 0;
            }

            int i = 1;
            int loaded = 0;
            if (catDataSet != null) {
                foreach (CatData catData in catDataSet) {
                    try {
                        cats.Add(new Cat(catData));
                        loaded++;
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error loading object #{i}: {e.Message}");
                    }
                    // Increment object counter
                    i++;
                }
            }
            
            return loaded;
        }
#pragma warning restore CS8600

        public static void SaveAsCsv(ref List<Cat> cats, string path) {
            string csv = "";
            foreach (Cat cat in cats)
                csv += cat.ToString() + "\n";
                
            File.WriteAllText(path, csv);
        }

        // Load from CSV into list with ref
        public static int LoadFromCsv(ref List<Cat> cats, string path) {
            string[] lines;
            try {
                lines = File.ReadAllLines(path);
            } catch (Exception e) {
                Console.WriteLine("Error while reading CSV file: " + e.Message);
                return 0;
            }

            int i = 1;
            int loaded = 0;
            foreach (string line in lines) {
                try {
                    cats.Add(Cat.Parse(line));
                    loaded++;
                } catch (Exception e) {
                    Console.WriteLine($"Error loading line {i}: {e.Message}");
                }
                // Increment line number
                i++;
            }

            return loaded;
        }
    }
}