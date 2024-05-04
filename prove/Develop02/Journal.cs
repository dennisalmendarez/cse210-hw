using System;
using System.Collections.Generic;
using System.IO;
public class Journal {
    public List<Entry> _entries;

    public Journal() {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry){
        _entries.Add(newEntry);
    }

    public void DisplayAll(){
        foreach (Entry entry in _entries) {
            entry.Display();
        };
    }

    public void SaveToFile(string fileName) {
        using (StreamWriter outputFile = new StreamWriter(fileName)) {
            foreach (Entry entry in _entries) {
                outputFile.WriteLine(entry._date);
                outputFile.WriteLine(entry._prompt);
                outputFile.WriteLine(entry._response);
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string fileName) {
        if (File.Exists(fileName)) {
            _entries.Clear(); // Clear existing content before loading new content
            string[] lines = File.ReadAllLines(fileName);
            string date = ""; 
            string prompt = "";
            string response = "";

            for (int i = 0; i < lines.Length; i++) {
                switch (i % 3) {
                    case 0:
                        date = lines[i];
                        break;
                    case 1:
                        prompt = lines[i];
                        break;
                    case 2:
                        response = lines[i];
                        _entries.Add(new Entry(prompt) { _date = date, _response = response }); // Create Entry object and add to _entries list
                        break;
                }
            }
            Console.WriteLine("Journal loaded from file.");
        }
        else {
            Console.WriteLine("Journal file not found.");
        }
    }
}