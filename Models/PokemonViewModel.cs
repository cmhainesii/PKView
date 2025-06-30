using System;
using PKLib;

namespace PKView.Models;

public class PokemonViewModel
{
    public string _speciesName { get; set; }
    public ushort _level { get; set; }
    public IV _ivs { get; set; }
    public Stats _stats { get; set; }
    public EVs _evs { get; set; }
    public string _otName { get; set; }
    public string _nickname { get; set; }
    public string[] _types { get; set; }
    public int _friendship { get; set; }

    public PokemonViewModel(Pokemon pokemon)
    {
        _speciesName = pokemon._speciesName;
        _level = pokemon._level;
        _ivs = pokemon._ivs;
        _stats = pokemon._stats;
        _evs = pokemon._evs;
        _otName = pokemon._otName;
        _nickname = pokemon._nickname;
        _types = pokemon._types;
        _friendship = pokemon._friendship;

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
            sum += pokemon._level;
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
