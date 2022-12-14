namespace OOP_Lab;

public class Driver {
    internal List<Cat> cats = new();

    public Driver() {}

    public static IEnumerable<Cat> FindCats(ref List<Cat> cats, string filter) => cats.Where(x => x.Name.ToLower() == filter.ToLower() || x.Id.ToString() == filter.ToLower());

    public static int DeleteCats(ref List<Cat> cats, string filter) => cats.RemoveAll(x => x.Name.ToLower() == filter.ToLower() || x.Id.ToString() == filter.ToLower());
    public static void PrintHelp() => Console.WriteLine("Commands: add, list, find, delete, edit, meow, purr, feed, isacat, save, load, exit");
    public void Main() {
        string? input;


        #if DEBUG
        cats.Add(new Cat("Clunk", 1.4, Gender.Male, CatType.Tabby));
        cats.Add(new Cat("Tux", 1.7, Gender.Male, CatType.Tuxedo));
        cats.Add(new Cat("Jellie", 1.4, Gender.Female, CatType.Jellie));
        Console.WriteLine("DEBUG");
        #endif


        PrintHelp();
        while (true) {
            Console.Write("> ");
            input = Console.ReadLine();
            if (input == null) { continue; }

            // Common variables
            string filter;
            Cat[] result;

            var cmdArgs = input.Trim().Split(' ');
            if (input != null) {
                switch (cmdArgs[0]) {
                    case "?":
                    case "help":
                        PrintHelp();
                        break;
                    case "+":
                    case "add":
                        // Check if string was given
                        if (cmdArgs.Length == 2) {
                            // Try to parse the string
                            if (Cat.TryParse(cmdArgs[1], out Cat? cat) && cat != null) {
                                // Add the cat
                                cats.Add(cat);
                                Console.WriteLine($"Added cat (id: {cat.Id}, name: {cat.Name}).");
                            }
                            else {
                                Console.WriteLine("Invalid cat string.");
                            }
                        }
                        else if (cmdArgs.Length >= 3) {
                            Console.WriteLine("Usage: add [cat string]");
                        }
                        else {
                            // Create object without parameters to trigger default constructor
                            cats.Add(new Cat());
                        }
                        break;
                    case "ls":
                    case "list":
                        // List all cats
                        Console.WriteLine($"Cats ({cats.Count}):");
                        foreach (Cat cat in cats) {
                            Console.WriteLine($"{cat.Id} | {cat.Repr()}");
                        }
                        break;
                    case "show":
                    case "find":
                        // Find cat(s) by Name/Id
                        if (cmdArgs.Length != 2) { Console.WriteLine($"Usage: {cmdArgs[0]} <Id | Name>"); break; }
                        filter = string.Join(' ', cmdArgs[1..]).ToLower().Trim();
                        result = FindCats(ref cats, filter).ToArray();
                        if (result.Length != 0) {
                            Console.WriteLine($"Cats ({cats.Count}):");
                            foreach (Cat cat in result) {
                                Console.WriteLine($"{cat.Id} | {cat.Repr()}");
                            }
                        }
                        else {
                            Console.WriteLine("No results for given Id/Name");
                        }
                        break;
                    case "meow":
                        // Find cat(s) by Name/Id
                        if (cmdArgs.Length != 2) { Console.WriteLine($"Usage: {cmdArgs[0]} <Id | Name>"); break; }
                        filter = string.Join(' ', cmdArgs[1..]).ToLower().Trim();
                        result = FindCats(ref cats, filter).ToArray();
                        if (result.Length != 0) {
                            foreach (Cat cat in result) {
                                cat.Meow();
                            }
                        }
                        else {
                            Console.WriteLine("No results for given Id/Name");
                        }
                        break;
                    case "feed":
                        // Find cat(s) by Name/Id
                        if (cmdArgs.Length < 2) { Console.WriteLine($"Usage: {cmdArgs[0]} <Id | Name> [Fish | Meat]"); break; }
                        // Get filter
                        filter = cmdArgs[1].ToLower();
                        // Treat the rest as food type
                        FoodType? foodType = null;
                        // String variant
                        string food = string.Join(' ', cmdArgs[2..]).ToLower();
                        // You can input number to break it
                        if (cmdArgs.Length == 3 && Enum.TryParse(typeof(FoodType), food, true, out _)) {
                            foodType = (FoodType)Enum.Parse(typeof(FoodType), food, true);
                        }

                        result = FindCats(ref cats, filter).ToArray();
                        if (result.Length != 0) {
                            foreach (Cat cat in result) {
                                if (foodType.HasValue) {
                                    cat.Eat(foodType.Value);
                                }
                                else {
                                    cat.Eat();
                                }
                            }
                        }
                        else {
                            Console.WriteLine("No results for given Id/Name");
                        }
                        break;
                    case "purr":
                        // Find cat(s) by Name/Id
                        if (cmdArgs.Length != 2) { Console.WriteLine($"Usage: {cmdArgs[0]} <Id | Name>"); break; }
                        filter = cmdArgs[1].ToLower().Trim();
                        result = FindCats(ref cats, filter).ToArray();
                        if (result.Length != 0) {
                            foreach (Cat cat in result) {
                                cat.Purr();
                            }
                        }
                        else {
                            Console.WriteLine("No results for given Id/Name");
                        }
                        break;
                    case "-":
                    case "rm":
                    case "del":
                    case "delete":
                        // Delete cat(s) by Name/Id
                        if (cmdArgs.Length != 2) { Console.WriteLine($"Usage: {cmdArgs[0]} <Id | Name>"); break; }
                        filter = string.Join(' ', cmdArgs[1..]).ToLower().Trim();

                        if (filter == "*") {
                            cats.Clear();
                            Console.WriteLine("Cat list was cleared.");
                            break;
                        }

                        // Store cats that will be deleted
                        result = FindCats(ref cats, filter).ToArray();
                        // Actually remove from the list
                        if (DeleteCats(ref cats, filter) != 0) {
                            Console.WriteLine($"The following entries were deleted:");
                            foreach (Cat cat in result) {
                                Console.WriteLine($"{cat.Id} | {cat.Repr()}");
                            }
                        }
                        else {
                            Console.WriteLine("No results for given Id/Name");
                        }

                        break;
                    case "edit":
                        // Edit cat by Id
                        if (cmdArgs.Length != 2) { Console.WriteLine("Usage: edit <Id>"); break; }
                        filter = cmdArgs[1].ToLower();
                        if (!int.TryParse(filter, out int filter_id)) {
                            Console.WriteLine("Usage: edit <Id>");
                        }

                        int index = -1;
                        // Iterate through array
                        // This doesn't use FindCats() function
                        for (int i = 0; i < cats.Count; i++) {
                            if (cats[i].Id == filter_id) {
                                cats[i] = Utils.EditCat(cats[i]);
                                index = i;
                                break;
                            }
                        }

                        if (index >= 0) {
                            Console.WriteLine("Edit result:");
                            Console.WriteLine($"{cats[index].Id} | {cats[index]}");
                        }
                        else {
                            Console.WriteLine("No results for given Id");
                        }
                        break;
                    case "isacat":
                        // Check if a string is a cat
                        if (cmdArgs.Length != 2) { Console.WriteLine("Usage: isacat <animal type>"); break; }
                        Cat.IsACat(cmdArgs[1]);
                        break;
                    case "exit":
                        Console.WriteLine("Bye bye.");
                        Environment.Exit(0);
                        // Fall through case after exit? What? VS, you good?
                        break;
                    case "save":
                        // Save to file as json or csv
                        if (cmdArgs.Length < 3) { Console.WriteLine("Usage: save <json | csv> <filename>"); break; }
                        if (cmdArgs[1].ToLower() == "json") {
                            try {
                                Utils.SaveAsJson(ref cats, string.Join(' ', cmdArgs[2..]));
                            } catch (Exception e) {
                                Console.WriteLine($"Error: {e.Message}");
                            }
                        }
                        else if (cmdArgs[1].ToLower() == "csv") {
                            try {
                            Utils.SaveAsCsv(ref cats, string.Join(' ', cmdArgs[2..]));
                            } catch (Exception e) {
                                Console.WriteLine($"Error: {e.Message}");
                            }
                        }
                        else {
                            Console.WriteLine("Usage: save <json | csv> <filename>");
                        }
                        break;
                    case "load":
                        // Load from file as json or csv
                        if (cmdArgs.Length < 3) { Console.WriteLine("Usage: load <json | csv> <filename>"); break; }
                        if (cmdArgs[1].ToLower() == "json") {
                            int loaded = Utils.LoadFromJson(ref cats, string.Join(' ', cmdArgs[2..]));
                            if (loaded > 0) {
                                Console.WriteLine($"Loaded {loaded} entries from file.");
                            }
                            else {
                                Console.WriteLine("No entries loaded.");
                            }
                        }
                        else if (cmdArgs[1].ToLower() == "csv") {
                            int loaded = Utils.LoadFromCsv(ref cats, string.Join(' ', cmdArgs[2..]));
                            if (loaded > 0) {
                                Console.WriteLine($"Loaded {loaded} entries from file.");
                            }
                            else {
                                Console.WriteLine("No entries loaded.");
                            }
                        }
                        else {
                            Console.WriteLine("Usage: load <json | csv> <filename>");
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}