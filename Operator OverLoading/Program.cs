using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

public class Word
{
    public Word(string? en, string? az)
    {
        En = en;
        Az = az;
    }

    public string? En { get; set; }
    public string? Az { get; set; }

    public override string ToString()
    {
        return $"{En}={Az}";
    }
}
public class Translatior
{

    public static List<Word>? words = new List<Word>();

    public Translatior()
    {
        CreateJson();
    }
    private void showAllWords()
    {
        foreach (var item in Translatior.words)
        {
            Console.WriteLine($"\n{item}");
        }

    }
    public void CreateJson()
    {
        string jsonFilePath = @"Luget.json";
        string jsonString = File.ReadAllText(jsonFilePath);
        Translatior.words = JsonSerializer.Deserialize<List<Word>>(jsonString);
    }

    private Word? FindWord(string word)
    {
        for (int i = 0; i < words.Count; i++)
        {
            if (word == words[i].En)
            {
                return words[i];
            }
        }
        for (int i = 0; i < words.Count; i++)
        {
            if (word == words[i].Az)
            {
                return words[i];
            }
        }
        return null;
    }
    private void GetTranslation()
    {
        Console.Write("Write some english word with first case upper:");
        string? word = Console.ReadLine();
        for (int i = 0; i < words.Count; i++)
        {
            if (word == words[i].En)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
    public void start()
    {
        GetTranslation();
        start();
    }
    public object this[int index]
    {
        get { return words[index]; }
    }
    public object this[string word]
    {
        get
        {
            try
            {
                if (FindWord(word) != null) { return FindWord(word); }
                else throw new Exception("Word did not found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }



}


class Program
{
    static void Main(string[] args)
    {
        Translatior translatior = new();
        Console.WriteLine($"\n{translatior["Salam"]}");
        Console.WriteLine($"\n{translatior["Goodbye"]}");
        Console.WriteLine($"\n{translatior["Push"]}");
        Console.WriteLine($"\n{translatior["Ela"]}");
        //string jsonFilePath = @"C:\Users\Crash\source\repos\Operator OverLoading\Operator OverLoading\tsconfig1.json";
        //var options = new JsonSerializerOptions();
        //options.WriteIndented = true;
        //var jsonStr = JsonSerializer.Serialize(words, options);
        //File.WriteAllText(jsonFilePath, jsonStr);
        //var readStr = File.ReadAllText(jsonFilePath);
        //var readCars = JsonSerializer.Deserialize<List<Word>>(readStr);

        //foreach (var item in readCars)
        //{
        //    Console.WriteLine(item);
        //}

        //// Json file-a listdeki lugeti qoyub sonra o fileden yeni bir liste qaytarmaq
        //string SerializedJson = JsonSerializer.Serialize(words);
        //File.WriteAllText(jsonFilePath, SerializedJson);
        //var deserialize = JsonSerializer.Deserialize<List<Word>>(SerializedJson);
        //foreach (Word item in deserialize)
        //{
        //    Console.WriteLine(item);
        //}

        ////Hazir json File-daki textleri goturub yeni bir liste gondermek
    }
}