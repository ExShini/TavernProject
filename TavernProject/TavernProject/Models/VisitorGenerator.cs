using System;
using System.Collections.Generic;
using System.Diagnostics;
using TavernProject.Models;

public class VisitorGenerator
{
    Random _rnd = new Random();

    List<string> _humanNames = new List<string>();
    List<string> _elfNames = new List<string>();
    List<string> _dwarfNames = new List<string>();
    List<string> _orcNames = new List<string>();



    public VisitorGenerator()
    {
        _humanNames.Add("Isolda");
        _humanNames.Add("Boris");
        _humanNames.Add("Artem");
        _humanNames.Add("Ignat");
        
        _elfNames.Add("Duadrial");
        _elfNames.Add("LadaNivia");
        _elfNames.Add("Zelda");
        
        _dwarfNames.Add("Gomly");
        _dwarfNames.Add("Bimbo");
        _dwarfNames.Add("Torin");

        _orcNames.Add("Uluk Hoi");
        _orcNames.Add("Go Kun");
        _orcNames.Add("Ubu Udu");
    }


    public Visitor CreateVisitor()
    {
        var visitorToGenerate = new Visitor();

        VisitorRace race = (VisitorRace)_rnd.Next(0, (int)VisitorRace.NumOfRaces);
        visitorToGenerate.Race = race;

        visitorToGenerate.Name = GetVisitorName(visitorToGenerate.Race);
        visitorToGenerate.Hunger = _rnd.Next(visitorToGenerate.MaxHunger / 10, visitorToGenerate.MaxHunger);
        visitorToGenerate.Gold = _rnd.Next(10, 100);
        
        // TODO: возраст должен зависить от расы
        visitorToGenerate.Age = _rnd.Next(18, 100);

        return visitorToGenerate;
    }


    public string GetVisitorName(VisitorRace race)
    {
        switch (race)
        {
            case VisitorRace.Human:
                return _humanNames[_rnd.Next(0, _humanNames.Count)];
            case VisitorRace.Elf:
                return _elfNames[_rnd.Next(0, _elfNames.Count)];
            case VisitorRace.Dwarf:
                return _dwarfNames[_rnd.Next(0, _dwarfNames.Count)];
            case VisitorRace.Orc:
                return _orcNames[_rnd.Next(0, _orcNames.Count)];
            default:
                Console.WriteLine("unsupported race: " + race);
                return string.Empty;
        }
    }



}
