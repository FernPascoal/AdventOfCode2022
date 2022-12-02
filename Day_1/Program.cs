// Get the Input file and read lines.

string textFile = "../../../Input.txt";

string[] lines = File.ReadAllLines(textFile);

// Part One
// Find the Elf carrying the most Calories.

List<int> calories = new();

int sum = 0;

for (int i = 0; i < lines.Length; i++)
{
    if (string.IsNullOrWhiteSpace(lines[i]))
    {
        calories.Add(sum);
        sum = 0;
    }
    else
    {
        sum += int.Parse(lines[i]);
    }
}

Console.WriteLine($"How many total Calories is that Elf carrying?\nR: {calories.Max()}");

// Part Two
// Find the top three Elves carrying the most Calories.

int totalTopThreeCalories = calories.OrderByDescending(calories => calories).Take(3).Sum();

Console.WriteLine($"How many Calories are those Elves carrying in total?\nR: {totalTopThreeCalories}");
