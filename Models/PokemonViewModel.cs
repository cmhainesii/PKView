using System;
using PKLib;

namespace PKView.Models;

public class PokemonViewModel
{
    public string SpeciesName { get; set; }
    public ushort Level { get; set; }
    public IV Ivs { get; set; }
    public Stats Stats { get; set; }
    public EVs Evs { get; set; }
    public string OtName { get; set; }
    public string Nickname { get; set; }
    public string[] Types { get; set; }
    public int Friendship { get; set; }
    public ushort IvScore { get; set; }

    public PokemonViewModel(Pokemon pokemon)
    {
        SpeciesName = pokemon._speciesName;
        Level = pokemon._level;
        Ivs = pokemon._ivs;
        Stats = pokemon._stats;
        Evs = pokemon._evs;
        OtName = pokemon._otName;
        Nickname = pokemon._nickname;
        Types = pokemon._types;
        Friendship = pokemon._friendship;
        IvScore = pokemon.GetIvScore();

    }

    public static IReadOnlyList<PokemonViewModel> ToPokemonViewList(IReadOnlyList<Pokemon> pokemonIn)
    {
        List<PokemonViewModel> result = new List<PokemonViewModel>();

        foreach (var pokemon in pokemonIn)
        {
            var viewModel = new PokemonViewModel(pokemon);
            result.Add(viewModel);
        }

        return result.AsReadOnly();
    }

    public static int AverageLevel(IReadOnlyList<PokemonViewModel> party)
    {
        int sum = 0;

        foreach (var pokemon in party)
        {
            sum += pokemon.Level;
        }

        return (int)Math.Round((double)sum / party.Count);
    }

    public static IReadOnlyList<PokemonViewModel> ToPokemonViewList(Party party)
    {
        List<PokemonViewModel> viewModelList = new List<PokemonViewModel>();

        foreach (var pokemon in party.GetParty())
        {
            var model = new PokemonViewModel(pokemon);
            viewModelList.Add(model);
        }

        return viewModelList.AsReadOnly();

        
    }
    
}
