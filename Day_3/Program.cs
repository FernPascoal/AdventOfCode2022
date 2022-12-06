#region "Read input file"
using System.Collections.Generic;
using System;

string textFile = "../../../Input.txt";
string[] lines = File.ReadAllLines(textFile);
#endregion
// --- Day 3: Rucksack Reorganization ---
int totalPrioritiesSum = 0;
int totalBadgesPrioritiesSum = 0;

// Part One
// Find the item type that appears in both compartments of each rucksack and calculate the total sum of priorities.

for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];

    var firstCompartment = new HashSet<char>(line[..(line.Length / 2)]);
    var secondCompartment = new HashSet<char>(line.Substring(line.Length / 2, line.Length / 2));

    var intersection = firstCompartment.Intersect(secondCompartment);

    if (intersection.Any())
    {
        for (int j = 0; j < intersection.Count(); j++)
        {
            char elementAt = intersection.ElementAt(j);

            totalPrioritiesSum += GetPriority(elementAt);
        }
    }
}

// Part Two
// Find the item type that corresponds to the badges of each three-Elf group.

for (int i = 0; i < lines.Length; i += 3)
{
    var linesGroup = lines.ToList().GetRange(i, 3).Select(line => new HashSet<char>(line));

    var intersection = linesGroup.Aggregate<IEnumerable<char>>((previous, next) => previous.Intersect(next)).ToList();

    if (intersection.Any())
    {
        for (int j = 0; j < intersection.Count; j++)
        {
            char elementAt = intersection.ElementAt(j);

            totalBadgesPrioritiesSum += GetPriority(elementAt);
        }
    }
}

Console.WriteLine($"What is the sum of the priorities of those item types?\nR: {totalPrioritiesSum}");
Console.WriteLine($"What is the sum of the priorities of those item types?\nR: {totalBadgesPrioritiesSum}");

static int GetPriority(char character)
{
    int lowerCaseValue = 96;
    int upperCaseValue = 38;

    return char.IsLower(character) ? ((sbyte)character) - lowerCaseValue : ((sbyte)character) - upperCaseValue;
}